using Ionic.Zip;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace StarSync
{
    public partial class SyncSubForm : Form
    {
        private string action = null;
        private string actionKeyWord = null;
        private bool validated;
        Guna2Transition gt = new Guna2Transition();
        public SyncSubForm(string refererAction = null)
        {
            InitializeComponent();
            action = refererAction;
        }

        private void SyncSubForm_Load(object sender, EventArgs e)
        {
            // UI OnLoad Configuration
            consoleTextBox.AutoScroll = true;
            consoleTextBox.BorderRadius = 10;
            gt.Interval = 3;
            syncLabel.Left = (this.Width - syncLabel.Width) / 2;
            syncBtn.Left = (this.Width - syncBtn.Width) / 2;
            syncLoading.Visible = false;
            syncLoading.Left = (this.Width - syncLoading.Width) / 2;
            statusLabel.Left = (this.Width - statusLabel.Width) / 2;
            
            // Stardew Valley Validation
            validated = StardewValidate();

            // CultureInfo Configuration
            CultureInfo current = new CultureInfo("en-GB");
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
                statusLabel.Text = $"<font style='font-size: 12; color: crimson;'><b>ERROR:</b> A valid Stardew Valley save directory wasn't found.<br>Please make sure Stardew Valley is installed,\nand that you have a valid save.<br><br>( {Common.stardewDataDir} )</font>";
                statusLabel.Left = (this.Width - statusLabel.Width) / 2;
                gt.ShowSync(statusLabel, false, Animation.Transparent);
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void syncBtn_Click(object sender, EventArgs e)
        {
            syncLoading.Visible = true;
            syncBtn.Enabled = true;
            Task apiSyncTask = new Task(() => SyncTask());
            apiSyncTask.Start();
        }

        private void SyncTask()
        {
            CrossThreadedTextChange(statusLabel, "Getting ready...");
            SyncConsoleLog($"Masterserver has been set to {Common.baseUrl}.");
            SyncConsoleLog($"Sending initial sync POST request to masterserver...");
            DateTime lastWrite = Common.TrimMilliseconds(Common.GetLatestInDirectory(Common.stardewDataDir)).ToUniversalTime();
            SyncConsoleLog($"Established local save modify date: {lastWrite}.");
            CrossThreadedTextChange(statusLabel, "Contacting server...");
            Common.APIData responseObj = Common.APISimpleRequest("getLatest");
            SyncConsoleLog($"Received response object from masterserver.");

            if (responseObj.response != "invalidAPIKey")
            {
                if (responseObj.modifyDate != null)
                {
                    DateTime lastRemoteWrite = Convert.ToDateTime(responseObj.modifyDate);
                    SyncConsoleLog($"Established remote save modify date: {lastRemoteWrite}");
                    int comparisionResult = Common.CompareDateTime(lastWrite.Ticks, lastRemoteWrite.Ticks);
                    // -1 is local newer, 0 is same as remote source, 1 is remote newer
                    switch (comparisionResult)
                    {
                        case -1:
                            SyncConsoleLog("Local save modify date is newer. Proceeding to upload from local source...");
                            UploadTask(lastWrite);
                            CrossThreadedSyncFinish();
                            break;

                        case 0:
                            SyncConsoleLog("Local and remote save modify date is the same. Sync completed, no actions required.");
                            if (action == null)
                                CrossThreadedTextChange(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>You are already using the latest save.");
                            else
                                CrossThreadedTextChange(statusLabel, $"{actionKeyWord} Completed!<br><font style='font-size: 12;'>You are already using the latest save.");
                            CrossThreadedSyncFinish();
                            break;

                        case 1:
                            SyncConsoleLog("Remote save modify date is newer. Proceeding to download from remote source...");
                            RetrieveTask(responseObj);
                            CrossThreadedSyncFinish();
                            break;
                    }
                }

                else
                {
                    SyncConsoleLog("The response object doesn't contain any save references, prompting first-time warning...");
                    DialogResult dialogResult = MessageBox.Show("It looks like you haven't uploaded any saves yet, so here's a warning:\nStarSync is not released yet, so there may be bugs.\nAnything can and will happen. We take no responsibility, so please make sure you have a backup of your saves.\n\nAre you sure you want to continue?", "StarSync Save Sync Subroutine", MessageBoxButtons.YesNo);
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
                CrossThreadedTextChange(statusLabel, $"<font style='font-size: 14; color: crimson;'>Sync Failed!<br><b>ERROR:</b> Your API Key is either invalid or has expired.<br></font><font style='font-size: 12;'>Key: {Common.GetCurrentAPIKey()}");
                CrossThreadedSyncFinish();
            }
        }

        private void UploadTask(DateTime modifiedDate)
        {
            CrossThreadedTextChange(statusLabel, "Creating save package...");
            DateTime currentDate = DateTime.Now;
            string saveZipPath = Common.starSyncDataDir + @"\ss_" + currentDate.ToString("yyyyMMdd_HHmmss") + ".zip";
            SyncConsoleLog($"Creating save package [ss_{currentDate.ToString("yyyyMMdd_HHmmss")}.zip]...");
            using (ZipFile zip = new ZipFile()) { 
                zip.AddDirectory(Common.stardewDataDir);
                zip.Save(saveZipPath);
            }
            RestClient client = new RestClient(Common.baseUrl);
            RestRequest uploadRequest = new RestRequest("/api/api.php", Method.POST);
            uploadRequest.AddParameter("apiKey", Common.GetCurrentAPIKey());
            uploadRequest.AddParameter("action", "uploadLatest");
            uploadRequest.AddParameter("uploadDate", Common.ConvertToSQLDateTime(currentDate));
            uploadRequest.AddParameter("modifiedDate", Common.ConvertToSQLDateTime(modifiedDate));
            uploadRequest.AddFile("fileToUpload", saveZipPath);
            CrossThreadedTextChange(statusLabel, "Uploading save package...");
            SyncConsoleLog($"Sending save package upload POST request to masterserver at {Common.baseUrl}");
            var response = client.Execute(uploadRequest);
            Common.APIData responseObj = JsonConvert.DeserializeObject<Common.APIData>(response.Content);
            if (responseObj.status == "success")
            {
                if (action == null)
                    CrossThreadedTextChange(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>The new save has been uploaded.</font>");
                else
                    CrossThreadedTextChange(statusLabel, $"{actionKeyWord} Completed!<br><font style='font-size: 12;'>The new save has been uploaded.</font>");
                SyncConsoleLog($"Masterserver confirmed save package upload POST request. Sync complete.");
            }

            else
            {
                SyncConsoleLog($"An error appeared while trying to upload the save package. ErrCode: {responseObj.status}");
                CrossThreadedTextChange(statusLabel, $"<font style='color: crimson;'>Sync Failed!<br>The new save couldn't be uploaded.<br><br><b>ErrCode:</b> {responseObj.status}</font>");
            }
        }

        private void RetrieveTask(Common.APIData responseObj)
        {
            CrossThreadedTextChange(statusLabel, "Downloading save package...");
            SyncConsoleLog($@"Downloading save package from masterserver URL {Common.baseUrl}/saveData/{Properties.Settings.Default.currentUser}/{responseObj.response} as {Common.starSyncDataDir}\tempSavedata.zip");
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(new System.Uri($"{Common.baseUrl}/saveData/{Properties.Settings.Default.currentUser}/{responseObj.response}"), $@"{Common.starSyncDataDir}\tempSavedata.zip");
            }
            CrossThreadedTextChange(statusLabel, "Applying save package...");
            SyncConsoleLog($@"Extracting save package {Common.starSyncDataDir}\tempSavedata.zip to {Common.stardewDataDir}...");
            using (ZipFile zip = ZipFile.Read($@"{Common.starSyncDataDir}\tempSavedata.zip"))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(Common.stardewDataDir, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            SyncConsoleLog($@"Cleaning up temporary save package zip from {Common.starSyncDataDir}\tempSavedata.zip...");
            File.Delete($@"{Common.starSyncDataDir}\tempSavedata.zip");
            if (action == null)
                CrossThreadedTextChange(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>The new save has been applied.");
            else
                CrossThreadedTextChange(statusLabel, $"{actionKeyWord} Completed!<br><font style='font-size: 12;'>The new save file has been applied.");
            SyncConsoleLog($@"Sync complete, the new save package has been applied.");
        }

        private void CrossThreadedTextChange(Control currentControl, string text)
        {
            this.BeginInvoke((Action)delegate ()
            {
                currentControl.Text = text;
                currentControl.Left = (this.Width - currentControl.Width) / 2;
            });
        }

        private void CrossThreadedSyncFinish()
        {
           this.BeginInvoke((Action)delegate ()
           {
               gt.HideSync(syncLoading, false, Animation.Transparent);
               syncBtn.Enabled = true;
           });
        }

        private void RefererActionHandler(string action)
        {
            if (validated && action != null)
            {
                SyncConsoleLog($"An external request for {action} has been received. Initiating...");
                switch (action)
                {
                    case "restoreSync":
                        actionKeyWord = "Restore";
                        syncLoading.Visible = true;
                        syncBtn.Enabled = true;
                        Task restoreSyncTask = new Task(() => SyncTask());
                        restoreSyncTask.Start();
                        break;

                    case "autoSync":
                        SyncConsoleLog($"The external AutoSync request was received on {DateTime.Now}.");
                        actionKeyWord = "AutoSync";
                        syncLoading.Visible = true;
                        syncBtn.Enabled = true;
                        Task autoSyncTask = new Task(() => SyncTask());
                        autoSyncTask.Start();
                        break;

                    case null:
                        break;
                }
            }
        }

        private void SyncConsoleLog(string text)
        {
            this.BeginInvoke((Action)delegate ()
            {
                consoleTextBox.AppendText(text + "\r\n");
            });
        }
    }
}
