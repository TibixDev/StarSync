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
            gt.Interval = 3;
            syncLabel.Left = (this.Width - syncLabel.Width) / 2;
            syncBtn.Left = (this.Width - syncBtn.Width) / 2;
            syncLoading.Visible = false;
            syncLoading.Left = (this.Width - syncLoading.Width) / 2;
            statusLabel.Left = (this.Width - statusLabel.Width) / 2;
            stardewValidate();
        }

        private void stardewValidate()
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
            Task apiSyncTask = new Task(() => syncTask());
            apiSyncTask.Start();
        }

        private async void syncTask()
        {
            crossThreadAnimText(statusLabel, "Getting ready...");
            DateTime lastWrite = Common.TrimMilliseconds(Common.GetLatestInDirectory(Common.stardewDataDir));
            RestClient client = new RestClient(Common.baseUrl);
            RestRequest retrieveRequest = new RestRequest("/api/api.php", Method.POST);
            retrieveRequest.AddParameter("apiKey", Common.GetCurrentAPIKey());
            retrieveRequest.AddParameter("action", "getLatest");
            crossThreadAnimText(statusLabel, "Contacting server...");
            var response = await client.ExecuteAsync(retrieveRequest);
            Common.apiData responseObj = JsonConvert.DeserializeObject<Common.apiData>(response.Content);
            if (responseObj.response != "invalidAPIKey")
            {
                if (responseObj.modifyDate != null)
                {
                    DateTime lastRemoteWrite = Convert.ToDateTime(responseObj.modifyDate);
                    //MessageBox.Show($"Local Stardew Valley Write Date: {common.ConvertToSQLDateTime(lastWrite)}\nRemote Stardew Valley Write Date: {common.ConvertToSQLDateTime(lastRemoteWrite)}");
                    MessageBox.Show($"Local Stardew Valley Write Date: {lastWrite}\nRemote Stardew Valley Write Date: {lastRemoteWrite}");
                    int comparisionResult = DateTime.Compare(lastWrite, lastRemoteWrite);
                    MessageBox.Show($"Comparision result ({lastWrite} | {lastRemoteWrite}): {comparisionResult}\n\nTicks:\nLW: {lastWrite.Ticks}\nLRW: {lastRemoteWrite.Ticks}");
                    // -1 is local newer, 0 is same as remote source, 1 is remote newer
                    switch (comparisionResult)
                    {
                        case -1:
                            uploadTask(lastWrite);
                            crossThreadSyncComplete();
                            break;

                        case 0:
                            crossThreadAnimText(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>You are already using the latest save.");
                            crossThreadSyncComplete();
                            break;

                        case 1:
                            retrieveTask(responseObj);
                            crossThreadSyncComplete();
                            break;
                    }
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("StarSync Save Sync Subroutine", "It looks like you haven't uploaded any saves yet, so here's a warning:\nStarSync is not released yet, so there may be bugs. Anything can and will happen. We take no responsibility, so please make sure you have a backup of your saves. Are you sure you want to continue?", MessageBoxButtons.YesNo);
                    uploadTask(lastWrite);
                }
            }

            else
            {
                crossThreadAnimText(statusLabel, $"<font style='font-size: 14; color: crimson;'>Sync Failed!<br><b>ERROR:</b> Your API Key is either invalid or has expired.<br></font><font style='font-size: 12;'>Key: {Common.GetCurrentAPIKey()}");
                crossThreadSyncComplete();
            }
        }

        private async void uploadTask(DateTime modifiedDate)
        {
            crossThreadAnimText(statusLabel, "Creating save package...");
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
            crossThreadAnimText(statusLabel, "Uploading save package...");
            var response = await client.ExecuteAsync(uploadRequest);
            Common.apiData responseObj = JsonConvert.DeserializeObject<Common.apiData>(response.Content);
            if (responseObj.status == "success")
            {
                crossThreadAnimText(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>The new save has been uploaded.</font>");
            }

            else
            {
                crossThreadAnimText(statusLabel, $"<font style='color: crimson;'>Sync Failed!<br>The new save couldn't be uploaded.<br><br><b>Error:</b> {responseObj.response}</font>");
            }
        }

        private async void retrieveTask(Common.apiData responseObj)
        {
            crossThreadAnimText(statusLabel, "Download save package...");
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(new System.Uri($"{Common.baseUrl}/saveData/{Properties.Settings.Default.currentUser}/{responseObj.response}"), $@"{Common.starSyncDataDir}\tempSavedata.zip");
            }
            crossThreadAnimText(statusLabel, "Applying save package...");
            using (ZipFile zip = ZipFile.Read($@"{Common.starSyncDataDir}\tempSavedata.zip"))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(Common.stardewDataDir, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            File.Delete($@"{Common.starSyncDataDir}\tempSavedata.zip");
            crossThreadAnimText(statusLabel, "Sync Completed!<br><font style='font-size: 12;'>The new save has been applied.");
        }

        private void crossThreadAnimText(Control currentControl, string text)
        {
            this.BeginInvoke((Action)delegate ()
            {
                gt.HideSync(currentControl, false, Animation.Transparent);
                currentControl.Text = text;
                currentControl.Left = (this.Width - currentControl.Width) / 2;
                gt.ShowSync(currentControl, false, Animation.Transparent);
            });
        }

        private void crossThreadSyncComplete()
        {
           this.BeginInvoke((Action)async delegate ()
           {
               gt.HideSync(syncLoading, false, Animation.Transparent);
               syncBtn.Enabled = true;
           });
        }
    }
}
