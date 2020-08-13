using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace StarSync.SubForms
{
    public partial class HistorySubForm : Form
    {
        public HistorySubForm()
        {
            InitializeComponent();
        }

        private void HistorySubForm_Load(object sender, EventArgs e)
        {
            Task historyTask = new Task(() => GetHistoryTask());
            historyTask.Start();
        }

        private async void GetHistoryTask()
        {
            RestClient client = new RestClient(Common.baseUrl);
            RestRequest retrieveRequest = new RestRequest("/api/api.php", Method.POST);
            retrieveRequest.AddParameter("apiKey", Common.GetCurrentAPIKey());
            retrieveRequest.AddParameter("action", "getHistory");
            var response = await client.ExecuteAsync(retrieveRequest);
            Common.APIData rawHistory = JsonConvert.DeserializeObject<Common.APIData>(response.Content);
            string decodedHistory = Encoding.UTF8.GetString(Convert.FromBase64String(rawHistory.response));
            List<Common.APIHistoryData> history = JsonConvert.DeserializeObject<List<Common.APIHistoryData>>(decodedHistory);
            foreach (Common.APIHistoryData currentEntry in history)
            {
               this.BeginInvoke((Action)delegate ()
               {
                   historyConsole.Text += $"{currentEntry.fileName} | {currentEntry.fileUploadDate} | {currentEntry.fileModifyDate} | {currentEntry.fileOwner}\n";
               });
            }
        }
    }
}
