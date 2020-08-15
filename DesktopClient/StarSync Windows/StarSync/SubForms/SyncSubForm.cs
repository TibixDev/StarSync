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
        Guna2Transition gt = new Guna2Transition();
        public SyncSubForm()
        {
            InitializeComponent();
        }

        private void SyncSubForm_Load(object sender, EventArgs e)
        {
            // UI OnLoad Configuration
            gt.Interval = 3;
            syncLabel.Left = (this.Width - syncLabel.Width) / 2;
            syncBtn.Left = (this.Width - syncBtn.Width) / 2;
            syncLoading.Visible = false;
            syncLoading.Left = (this.Width - syncLoading.Width) / 2;
            statusLabel.Left = (this.Width - statusLabel.Width) / 2;
            
            // Stardew Valley Validation
            StardewValidate();

            // CultureInfo Configuration
            CultureInfo current = new CultureInfo("en-GB");
            Application.CurrentCulture = current;
        }

        private void StardewValidate()
        {
            if (!Directory.Exists(Common.stardewDataDir))
            {
                syncBtn.Enabled = false;
                statusLabel.Text = $"<font style='font-size: 12; color: crimson;'><b>ERROR:</b> A valid Stardew Valley save directory wasn't found.<br>Please make sure Stardew Valley is installed,\nand that you have a valid save.<br><br>( {Common.stardewDataDir} )</font>";
                statusLabel.Left = (this.Width - statusLabel.Width) / 2;
                gt.ShowSync(statusLabel, false, Animation.Transparent);
            }
        }

        private async void syncBtn_Click(object sender, EventArgs e)
        {
            syncLoading.Visible = true;
            syncBtn.Enabled = true;
            Task apiSyncTask = new Task(() => SyncTask());
            apiSyncTask.Start();
        }

        private async void SyncTask()
        {
            CrossThreadedTextChange(statusLabel, "Getting ready...");
            DateTime lastWrite = Common.TrimMilliseconds(Common.GetLatestInDirectory(Common.stardewDataDir));
            CrossThreadedTextChange(statusLabel, "Contacting server...");
            Common.APIData responseObj = Common.APISimpleRequest("getLatest");
            MessageBox.Show(responseObj.response);

            if (responseObj.response != "invalidAPIKey")
            {
                if (responseObj.modifyDate != null)
                {
                    DateTime lastRemoteWrite = Convert.ToDateTime(responseObj.modifyDate);
                    //MessageBox.Show($"Local Stardew Valley Write Date: {common.ConvertToSQLDateTime(lastWrite)}\nRemote Stardew Valley Write Date: {common.ConvertToSQLDateTime(lastRemoteWrite)}");
                    MessageBox.Show($"Local Stardew Valley Write Date: {lastWrite}\nRemote Stardew Valley Write Date: {lastRemoteWrite}");
                    int comparisionResult = Common.CompareDateTime(lastWrite.Ticks, lastRemoteWrite.Ticks);
                    MessageBox.Show($"Comparision result ({lastWrite} | {lastRemoteWrite}): {comparisionResult}\n\nTicks:\nLW: {lastWrite.Ticks}\nLRW: {lastRemoteWrite.Ticks}");
                    // -1 is local newer, 0 is same as remote source, 1 is remote newer
                    switch (comparisionResult)
                    {
                        case -1:
                            UploadTask(lastWrite);
                            CrossThreadedSyncFinish();
                            break;

                        case 0:
                            CrossThreadedTextChange(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>You are already using the latest save.");
                            CrossThreadedSyncFinish();
                            break;

                        case 1:
                            RetrieveTask(responseObj);
                            CrossThreadedSyncFinish();
                            break;
                    }
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("It looks like you haven't uploaded any saves yet, so here's a warning:\nStarSync is not released yet, so there may be bugs.\nAnything can and will happen. We take no responsibility, so please make sure you have a backup of your saves.\n\nAre you sure you want to continue?", "StarSync Save Sync Subroutine", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        UploadTask(lastWrite);
                    }

                    else
                    {
                        CrossThreadedTextChange(statusLabel, "Sync Cancelled By User");
                        CrossThreadedSyncFinish();
                    }
                }
            }

            else
            {
                CrossThreadedTextChange(statusLabel, $"<font style='font-size: 14; color: crimson;'>Sync Failed!<br><b>ERROR:</b> Your API Key is either invalid or has expired.<br></font><font style='font-size: 12;'>Key: {Common.GetCurrentAPIKey()}");
                CrossThreadedSyncFinish();
            }
        }

        private void UploadTask(DateTime modifiedDate)
        {
            CrossThreadedTextChange(statusLabel, "Creating save package...");
            DateTime currentDate = DateTime.Now;
            string saveZipPath = Common.starSyncDataDir + @"\ss_" + currentDate.ToString("yyyyMMdd_HHmmss") + ".zip";
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
            var response = client.Execute(uploadRequest);
            Common.APIData responseObj = JsonConvert.DeserializeObject<Common.APIData>(response.Content);
            if (responseObj.status == "success")
            {
                CrossThreadedTextChange(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>The new save has been uploaded.</font>");
            }

            else
            {
                CrossThreadedTextChange(statusLabel, $"<font style='color: crimson;'>Sync Failed!<br>The new save couldn't be uploaded.<br><br><b>Error:</b> {responseObj.response}</font>");
            }
        }

        private async void RetrieveTask(Common.APIData responseObj)
        {
            CrossThreadedTextChange(statusLabel, "Download save package...");
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(new System.Uri($"{Common.baseUrl}/saveData/{Properties.Settings.Default.currentUser}/{responseObj.response}"), $@"{Common.starSyncDataDir}\tempSavedata.zip");
            }
            CrossThreadedTextChange(statusLabel, "Applying save package...");
            using (ZipFile zip = ZipFile.Read($@"{Common.starSyncDataDir}\tempSavedata.zip"))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(Common.stardewDataDir, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            File.Delete($@"{Common.starSyncDataDir}\tempSavedata.zip");
            CrossThreadedTextChange(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>The new save has been applied.");
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
           this.BeginInvoke((Action)async delegate ()
           {
               gt.HideSync(syncLoading, false, Animation.Transparent);
               syncBtn.Enabled = true;
           });
        }
    }
}
