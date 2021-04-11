using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using RestSharp;
using StarSync.Properties;

namespace StarSync
{
    internal class Common
    {
        public static string baseUrl = GetSavedHost();
        public static readonly string appdataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string starSyncDataDir =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StarSync";

        public static readonly string stardewDataDir =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StardewValley\Saves";

        public static APIData APISimpleRequest(string action, string apiKey = null, string path = null,
            string saveID = null, string restoreDate = null)
        {
            if (apiKey == null) apiKey = GetCurrentAPIKey();
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/api.php", Method.POST);
            request.AddParameter("apiKey", apiKey);
            request.AddParameter("action", action);
            if (path != null) request.AddFile("fileToUpload", path);
            if (saveID != null) request.AddParameter("saveID", saveID);
            if (restoreDate != null) request.AddParameter("restoreDate", restoreDate);
            var response = client.Execute(request);
            var responseObj = JsonConvert.DeserializeObject<APIData>(response.Content);
            return responseObj;
        }

        public static string ConvertToSQLDateTime(DateTime entry)
        {
            return entry.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime ConvertToGlobalDateTime(DateTime entry)
        {
            return DateTime.Now;
        }

        public static DateTime GetLatestInDirectory(string dir)
        {
            var latest = new DateTime();
            var folder = new DirectoryInfo(dir);
            var latestFile = folder.GetFiles("*", SearchOption.AllDirectories)
                .OrderByDescending(f => f.LastWriteTimeUtc).First();
            latest = latestFile.LastWriteTimeUtc;
            return latest;
        }

        public static DateTime TrimMilliseconds(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind);
        }

        public static string GetCurrentAPIKey()
        {
            return Settings.Default.currentApiKey;
        }

        public static string GetSavedHost()
        {
            return Settings.Default.savedHost;
        }

        public static int CompareDateTime(long d1Ticks, long d2Ticks)
        {
            return d1Ticks > d2Ticks ? -1 : d1Ticks < d2Ticks ? 1 : 0;
        }

        public static void ChangeSubform(Guna2Panel panel, dynamic form)
        {
            var currentForm = form as Form;
            panel.Controls.Clear();
            currentForm.TopLevel = false;
            panel.Controls.Add(currentForm);
            currentForm.Show();
        }

        public static void MainContextConfigurator(NotifyIcon notifyIco, ToolStripItemClickedEventHandler eventHandler)
        {
            var strip = new ContextMenuStrip();
            var titleLabel = new ToolStripLabel("StarSync");
            titleLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            strip.Items.Add(titleLabel);
            strip.Items.Add(new ToolStripSeparator());
            strip.Items.Add("Sync");
            strip.Items.Add("History");
            strip.Items.Add("Web Dashboard");
            strip.Items.Add("Options");
            strip.Items.Add("About");
            strip.Items.Add("Logout");
            strip.Items.Add(new ToolStripSeparator());
            strip.Items.Add("Exit");
            strip.ItemClicked += eventHandler;
            notifyIco.ContextMenuStrip = strip;
        }

        public class APIData
        {
            public APIData(string response, string status, string uploadDate = null, string modifyDate = null)
            {
                this.response = response;
                this.status = status;
                this.uploadDate = uploadDate;
                this.modifyDate = modifyDate;
            }

            public string response { get; set; }
            public string status { get; set; }
            public string uploadDate { get; set; }
            public string modifyDate { get; set; }
        }

        public class APIHistoryData
        {
            public APIHistoryData(string fileID, string fileName, string fileUploadDate, string fileModifyDate,
                string fileOwner)
            {
                this.fileID = fileID;
                this.fileName = fileName;
                this.fileUploadDate = fileUploadDate;
                this.fileModifyDate = fileModifyDate;
                this.fileOwner = fileOwner;
            }

            public string fileID { get; set; }
            public string fileName { get; set; }
            public string fileUploadDate { get; set; }
            public string fileModifyDate { get; set; }
            public string fileOwner { get; set; }
        }
    }
}