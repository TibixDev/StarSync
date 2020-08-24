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
            historyGrid.Visible = false;
            Task historyTask = new Task(() => GetHistoryTask());
            historyTask.Start();
        }

        private async void GetHistoryTask()
        {
            Common.APIData rawHistory = Common.APISimpleRequest("getHistory");
            string decodedHistory = Encoding.UTF8.GetString(Convert.FromBase64String(rawHistory.response));
            List<Common.APIHistoryData> history = JsonConvert.DeserializeObject<List<Common.APIHistoryData>>(decodedHistory);
            /*foreach (Common.APIHistoryData currentEntry in history)
            {
                this.BeginInvoke((Action)delegate ()
                {
                    historyConsole.Text += $"{currentEntry.fileName} | {currentEntry.fileUploadDate} | {currentEntry.fileModifyDate} | {currentEntry.fileOwner}\n";
                });
            }*/
            this.BeginInvoke((Action)delegate ()
            {
                historyGrid.AutoGenerateColumns = true;
                historyGrid.DataSource = history;
                setColSizes();
            });
        }

        private void setColSizes()
        {
            historyGrid.Visible = true;
            historyGrid.Columns["fileName"].Width = 190;
            historyGrid.Columns["fileUploadDate"].Width = 175;
            historyGrid.Columns["fileModifyDate"].Width = 175;
            historyGrid.Columns["fileOwner"].Width = 60;
            historyGrid.Columns["saveRestore"].Width = 70;
            historyGrid.Columns["saveDelete"].Width = 70;
        }
    }
}
