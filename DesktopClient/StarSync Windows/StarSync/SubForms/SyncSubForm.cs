using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Ionic.Zip;
using Newtonsoft.Json;
using RestSharp;
using StarSync.Properties;

namespace StarSync
{
    public partial class SyncSubForm : Form
    {
        private readonly string action;
        private readonly Guna2Transition gt = new Guna2Transition();
        private readonly StarSyncMain ssMain;
        private string actionKeyWord;
        private bool validated;

        public SyncSubForm(StarSyncMain referer_ssMain, string refererAction = null)
        {
            InitializeComponent();
            ssMain = referer_ssMain;
            action = refererAction;
        }

        private void SyncSubForm_Load(object sender, EventArgs e)
        {
            // UI OnLoad Configuration
            consoleTextBox.AutoScroll = true;
            consoleTextBox.BorderRadius = 10;
            gt.Interval = 3;
            syncLabel.Left = (Width - syncLabel.Width) / 2;
            syncBtn.Left = (Width - syncBtn.Width) / 2;
            syncLoading.Visible = false;
            syncLoading.Left = (Width - syncLoading.Width) / 2;
            statusLabel.Left = (Width - statusLabel.Width) / 2;

            // Stardew Valley Validation
            validated = StardewValidate();

            // CultureInfo Configuration
            var current = new CultureInfo("en-GB");
            Application.CurrentCulture = current;

            // Handle Referer Action If Present
            if (action != null)
                RefererActionHandler(action);
        }

        private bool StardewValidate()
        {
            if (!Directory.Exists(Common.stardewDataDir))
            {
                syncBtn.Enabled = false;
                consoleTextBox.Visible = false;
                statusLabel.Text =
                    $"<font style='font-size: 12; color: crimson;'><b>ERROR:</b> A valid Stardew Valley save directory wasn't found.<br>Please make sure Stardew Valley is installed,\nand that you have a valid save.<br><br>( {Common.stardewDataDir} )</font>";
                statusLabel.Left = (Width - statusLabel.Width) / 2;
                gt.ShowSync(statusLabel, false, Animation.Transparent);
                return false;
            }

            return true;
        }

        private void syncBtn_Click(object sender, EventArgs e)
        {
            var apiSyncTask = new Task(() => SyncTask());
            apiSyncTask.Start();
        }

        private void SyncTask()
        {
            if (Process.GetProcessesByName("Stardew Valley").Length == 0)
            {
                BeginInvoke((Action) delegate
                {
                    syncLoading.Visible = true;
                    syncBtn.Enabled = true;
                });
                CrossThreadedTextChange(statusLabel, "Getting ready...");
                SyncConsoleLog($"Masterserver has been set to {Common.baseUrl}.");
                SyncConsoleLog("Sending initial sync POST request to masterserver...");
                var lastWrite = Common.TrimMilliseconds(Common.GetLatestInDirectory(Common.stardewDataDir))
                    .ToUniversalTime();
                SyncConsoleLog($"Established local save modify date: {lastWrite}.");
                CrossThreadedTextChange(statusLabel, "Contacting server...");
                var responseObj = Common.APISimpleRequest("getLatest");
                SyncConsoleLog("Received response object from masterserver.");

                if (responseObj.response != "invalidAPIKey")
                {
                    if (responseObj.modifyDate != null)
                    {
                        var lastRemoteWrite = Convert.ToDateTime(responseObj.modifyDate);
                        SyncConsoleLog($"Established remote save modify date: {lastRemoteWrite}");
                        var comparisionResult = Common.CompareDateTime(lastWrite.Ticks, lastRemoteWrite.Ticks);
                        // -1 is local newer, 0 is same as remote source, 1 is remote newer
                        switch (comparisionResult)
                        {
                            case -1:
                                SyncConsoleLog(
                                    "Local save modify date is newer. Proceeding to upload from local source...");
                                UploadTask(lastWrite);
                                CrossThreadedSyncFinish();
                                break;

                            case 0:
                                SyncConsoleLog(
                                    "Local and remote save modify date is the same. Sync completed, no actions required.");
                                if (action == null)
                                    CrossThreadedTextChange(statusLabel,
                                        "Sync Completed!<br><font style='font-size: 12;'>You are already using the latest save.");
                                else
                                    CrossThreadedTextChange(statusLabel,
                                        $"{actionKeyWord} Completed!<br><font style='font-size: 12;'>You are already using the latest save.");
                                CrossThreadedSyncFinish();
                                break;

                            case 1:
                                SyncConsoleLog(
                                    "Remote save modify date is newer. Proceeding to download from remote source...");
                                RetrieveTask(responseObj);
                                CrossThreadedSyncFinish();
                                break;
                        }
                    }

                    else
                    {
                        SyncConsoleLog(
                            "The response object doesn't contain any save references, prompting first-time warning...");
                        var dialogResult = MessageBox.Show(
                            "It looks like you haven't uploaded any saves yet, so here's a warning:\nStarSync is not released yet, so there may be bugs.\nAnything can and will happen. We take no responsibility, so please make sure you have a backup of your saves.\n\nAre you sure you want to continue?",
                            "StarSync Save Sync Subroutine", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SyncConsoleLog("Prompt agreement received, proceeding to upload...");
                            UploadTask(lastWrite);
                        }

                        else
                        {
                            SyncConsoleLog("Prompt has been declined, sync terminated.");
                            CrossThreadedTextChange(statusLabel, "Sync Cancelled By User");
                            CrossThreadedSyncFinish();
                        }
                    }
                }

                else
                {
                    SyncConsoleLog("An invalid API key was supplied.");
                    CrossThreadedTextChange(statusLabel,
                        $"<font style='font-size: 14; color: crimson;'>Sync Failed!<br><b>ERROR:</b> Your API Key is either invalid or has expired.<br></font><font style='font-size: 12;'>Key: {Common.GetCurrentAPIKey()}");
                    CrossThreadedSyncFinish();
                }
            }
            else
            {
                if (action != null || action != string.Empty)
                    CrossThreadedTextChange(statusLabel,
                        $"<font>{action} Failed!</font><br><font style='font-size: 12;'>Close Stardew Valley before syncing.");
                else
                    CrossThreadedTextChange(statusLabel,
                        "<font>Sync Failed!</font><br><font style='font-size: 12;'>Close Stardew Valley before syncing.");
                SyncConsoleLog("Sync Failed, because Stardew Valley is already running.");
            }
        }

        private void UploadTask(DateTime modifiedDate)
        {
            CrossThreadedTextChange(statusLabel, "Creating save package...");
            var currentDate = DateTime.Now;
            var saveZipPath = Common.starSyncDataDir + @"\ss_" + currentDate.ToString("yyyyMMdd_HHmmss") + ".zip";
            SyncConsoleLog($"Creating save package [ss_{currentDate.ToString("yyyyMMdd_HHmmss")}.zip]...");
            using (var zip = new ZipFile())
            {
                zip.AddDirectory(Common.stardewDataDir);
                zip.Save(saveZipPath);
            }

            var client = new RestClient(Common.baseUrl);
            var uploadRequest = new RestRequest("/api/api.php", Method.POST);
            uploadRequest.AddParameter("apiKey", Common.GetCurrentAPIKey());
            uploadRequest.AddParameter("action", "uploadLatest");
            uploadRequest.AddParameter("uploadDate", Common.ConvertToSQLDateTime(currentDate));
            uploadRequest.AddParameter("modifiedDate", Common.ConvertToSQLDateTime(modifiedDate));
            uploadRequest.AddFile("fileToUpload", saveZipPath);
            CrossThreadedTextChange(statusLabel, "Uploading save package...");
            SyncConsoleLog($"Sending save package upload POST request to masterserver at {Common.baseUrl}");
            var response = client.Execute(uploadRequest);
            var responseObj = JsonConvert.DeserializeObject<Common.APIData>(response.Content);
            if (responseObj.status == "success")
            {
                if (action == null)
                    CrossThreadedTextChange(statusLabel,
                        "Sync Completed!<br><font style='font-size: 12;'>The new save has been uploaded.</font>");
                else
                    CrossThreadedTextChange(statusLabel,
                        $"{actionKeyWord} Completed!<br><font style='font-size: 12;'>The new save has been uploaded.</font>");
                SyncConsoleLog("Masterserver confirmed save package upload POST request. Sync complete.");
            }

            else
            {
                SyncConsoleLog(
                    $"An error appeared while trying to upload the save package. ErrCode: {responseObj.status}");
                CrossThreadedTextChange(statusLabel,
                    $"<font style='color: crimson;'>Sync Failed!<br>The new save couldn't be uploaded.<br><br><b>ErrCode:</b> {responseObj.status}</font>");
            }
        }

        private void RetrieveTask(Common.APIData responseObj)
        {
            CrossThreadedTextChange(statusLabel, "Downloading save package...");
            SyncConsoleLog(
                $@"Downloading save package from masterserver URL {Common.baseUrl}/saveData/{Settings.Default.currentUser}/{responseObj.response} as {Common.starSyncDataDir}\tempSavedata.zip");
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(
                    new Uri($"{Common.baseUrl}/saveData/{Settings.Default.currentUser}/{responseObj.response}"),
                    $@"{Common.starSyncDataDir}\tempSavedata.zip");
            }

            CrossThreadedTextChange(statusLabel, "Applying save package...");
            SyncConsoleLog(
                $@"Extracting save package {Common.starSyncDataDir}\tempSavedata.zip to {Common.stardewDataDir}...");
            using (var zip = ZipFile.Read($@"{Common.starSyncDataDir}\tempSavedata.zip"))
            {
                foreach (var entry in zip)
                    entry.Extract(Common.stardewDataDir, ExtractExistingFileAction.OverwriteSilently);
            }

            SyncConsoleLog(
                $@"Cleaning up temporary save package zip from {Common.starSyncDataDir}\tempSavedata.zip...");
            File.Delete($@"{Common.starSyncDataDir}\tempSavedata.zip");
            if (action == null)
                CrossThreadedTextChange(statusLabel,
                    "Sync Completed!<br><font style='font-size: 12;'>The new save has been applied.");
            else
                CrossThreadedTextChange(statusLabel,
                    $"{actionKeyWord} Completed!<br><font style='font-size: 12;'>The new save file has been applied.");
            SyncConsoleLog(@"Sync complete, the new save package has been applied.");
        }

        private void CrossThreadedTextChange(Control currentControl, string text)
        {
            BeginInvoke((Action) delegate
            {
                currentControl.Text = text;
                currentControl.Left = (Width - currentControl.Width) / 2;
            });
        }

        private void CrossThreadedSyncFinish()
        {
            BeginInvoke((Action) delegate
            {
                gt.HideSync(syncLoading, false, Animation.Transparent);
                syncBtn.Enabled = true;
                if (action == "autoSync")
                    ssMain.WindowState = FormWindowState.Minimized;
            });
        }

        private void RefererActionHandler(string action)
        {
            if (validated && action != null)
            {
                SyncConsoleLog($"An external {action} request was received on {DateTime.Now}. Initiating...");
                switch (action)
                {
                    case "restoreSync":
                        actionKeyWord = "Restore";
                        syncLoading.Visible = true;
                        syncBtn.Enabled = true;
                        var restoreSyncTask = new Task(() => SyncTask());
                        restoreSyncTask.Start();
                        break;

                    case "autoSync":
                        actionKeyWord = "AutoSync";
                        syncLoading.Visible = true;
                        syncBtn.Enabled = true;
                        var autoSyncTask = new Task(() => SyncTask());
                        autoSyncTask.Start();
                        break;

                    case null:
                        break;
                }
            }
        }

        private void SyncConsoleLog(string text)
        {
            BeginInvoke((Action) delegate { consoleTextBox.AppendText(text + "\r\n"); });
        }
    }
}