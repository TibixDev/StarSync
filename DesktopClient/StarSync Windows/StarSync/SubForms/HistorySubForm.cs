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
        private StarSyncMain initiatorBaseForm;
        public HistorySubForm(StarSyncMain starSyncMain)
        {
            initiatorBaseForm = starSyncMain;
            InitializeComponent();
        }

        private void HistorySubForm_Load(object sender, EventArgs e)
        {
            historyGrid.Visible = false;
            Task historyTask = new Task(() => GetHistoryTask());
            historyTask.Start();
        }

        private void GetHistoryTask()
        {
            Common.APIData rawHistory = Common.APISimpleRequest("getHistory");
            string decodedHistory = Encoding.UTF8.GetString(Convert.FromBase64String(rawHistory.response));
            List<Common.APIHistoryData> history = JsonConvert.DeserializeObject<List<Common.APIHistoryData>>(decodedHistory);
            this.BeginInvoke((Action)delegate ()
            {
                historyGrid.AutoGenerateColumns = true;
                historyGrid.DataSource = history;
                SetColSizes();
                /*string final = "Save Data ID-s:\n\n";
                foreach (Common.APIHistoryData data in history)
                {
                    final += $"ID FOR {data.fileName}: {data.fileID}\n";
                }
                MessageBox.Show(final);*/
            });
        }

        private void SetColSizes()
        {
            historyGrid.Visible = true;
            historyGrid.Columns["fileName"].Width = 190;
            historyGrid.Columns["fileUploadDate"].Width = 165;
            historyGrid.Columns["fileModifyDate"].Width = 165;
            historyGrid.Columns["fileOwner"].Width = 60;
            historyGrid.Columns["saveRestore"].Width = 60;
            historyGrid.Columns["saveDelete"].Width = 60;
        }

        private void historyGrid_CellClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            string saveID = historyGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            switch (e.ColumnIndex) {
                // Restore Case
                case 0:
                    Task restoreTask = new Task(() => RestoreTask(saveID));
                    restoreTask.Start();
                break;

                // Delete Case
                case 1:
                    Task deleteTask = new Task(() => DeleteTask(saveID));
                    deleteTask.Start();
                break;
            }
        }

        private void RestoreTask(string saveID)
        {
            Common.APIData restoreResp = Common.APISimpleRequest("restoreSave", null, null, saveID);
            if (restoreResp.status == "success")
            {
                initiatorBaseForm.ExternalSync("restoreSync");
            }
            else
            {
                // todo toast notification
            }
        }

        private void DeleteTask(string saveID)
        {
            Common.APIData deleteResp = Common.APISimpleRequest("deleteSave", null, null, saveID);
            if (deleteResp.status == "success")
            {
                // todo toast notification
            }
            else
            {
                // todo toast notification
            }
        }
    }
}
