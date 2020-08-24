using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using StarSync.SubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StarSync
{
    public partial class StarSyncMain : Form
    {
        Guna2Transition gt = new Guna2Transition();
        Common common = new Common();
        string username;
        public StarSyncMain(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

        private void StarSyncMain_Load(object sender, EventArgs e)
        {
            
            verLabel.Text = $"{username} | Early Alpha 0.2";
            verLabel.Left = (windowPanel.Width - verLabel.Width) / 2;
            gt.Interval = 3;
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pWebDashBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Common.baseUrl);
        }

        private void panelHideBtn_Click(object sender, EventArgs e)
        {
            if (windowPanel.Visible)
            {
                gt.HideSync(windowPanel, false, Animation.HorizSlide);
                panelHideBtn.Parent = this;
                panelHideBtn.Top += windowPanel.Top;
                panelHideBtn.Left = 0;
                panelHideBtn.Text = ">";
                //contentPanel.Left = 0;
                //contentPanel.Size = new Size(800, 370);
            }

            else
            {
                panelHideBtn.Parent = windowPanel;
                panelHideBtn.Top -= windowPanel.Top;
                panelHideBtn.Left = 220;
                gt.ShowSync(windowPanel, false, Animation.HorizSlide);
                panelHideBtn.Text = "<";
            }
        }

        private void pSyncBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            SyncSubForm ssf = new SyncSubForm();
            ssf.TopLevel = false;
            //ssf.AutoScroll = true;
            contentPanel.Controls.Add(ssf);
            ssf.Show();
        }

        private void pHistoryBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            HistorySubForm hsf = new HistorySubForm();
            hsf.TopLevel = false;
            //ssf.AutoScroll = true;
            contentPanel.Controls.Add(hsf);
            hsf.Show();
        }
    }
}
