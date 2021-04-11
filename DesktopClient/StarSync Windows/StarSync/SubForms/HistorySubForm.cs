using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StarSync.SubForms
{
    public partial class HistorySubForm : Form
    {
        private readonly StarSyncMain initiatorBaseForm;

        public HistorySubForm(StarSyncMain starSyncMain)
        {
            initiatorBaseForm = starSyncMain;
            InitializeComponent();
        }

        private void HistorySubForm_Load(object sender, EventArgs e)
        {
            historyGrid.Visible = false;
            var historyTask = new Task(() => GetHistoryTask());
            historyTask.Start();
        }

        private void GetHistoryTask()
        {
            var rawHistory = Common.APISimpleRequest("getHistory");
            var decodedHistory = Encoding.UTF8.GetString(Convert.FromBase64String(rawHistory.response));
            var history = JsonConvert.DeserializeObject<List<Common.APIHistoryData>>(decodedHistory);
            BeginInvoke((Action) delegate
            {
                historyGrid.AutoGenerateColumns = true;
                historyGrid.DataSource = history;
                SetColSizes();
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
            var saveID = historyGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            switch (e.ColumnIndex)
            {
                // Restore Case
                case 0:
                    var restoreTask = new Task(() => RestoreTask(saveID));
                    restoreTask.Start();
                    break;

                // Delete Case
                case 1:
                    var deleteTask = new Task(() => DeleteTask(saveID));
                    deleteTask.Start();
                    break;
            }
        }

        private void RestoreTask(string saveID)
        {
            var restoreResp = Common.APISimpleRequest("restoreSave", null, null, saveID,
                Common.ConvertToSQLDateTime(DateTime.Now));
            if (restoreResp.status == "success")
            {
                initiatorBaseForm.ExternalSync("restoreSync");
            }
        }

        private void DeleteTask(string saveID)
        {
            var deleteResp = Common.APISimpleRequest("deleteSave", null, null, saveID);
            if (deleteResp.status == "success")
            {
                MessageBox.Show($"Deletion of save with saveID: {saveID} was successful.");
                var historyTask = new Task(() => GetHistoryTask());
                historyTask.Start();
                // todo toast notification
            }
            else
            {
                MessageBox.Show(
                    $"An error occured while trying to delete save with saveID: {saveID}. ErrCode: {deleteResp.response}");
                // todo toast notification
            }
        }
    }
}