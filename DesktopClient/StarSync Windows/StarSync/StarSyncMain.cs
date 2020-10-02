using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using StarSync.SubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StarSync
{
    public partial class StarSyncMain : Form
    {
        Guna2Transition gt = new Guna2Transition();
        private string username;
        Timer autoSyncTimer = new Timer();
        public StarSyncMain(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

        private void StarSyncMain_Load(object sender, EventArgs e)
        {
            gunaWindowAnim.SetAnimateWindow(this, Guna2AnimateWindow.AnimateWindowType.AW_BLEND, 200);
            verLabel.Text = $"{username} | Early Alpha 0.2";
            verLabel.Left = (windowPanel.Width - verLabel.Width) / 2;
            gt.Interval = 3;
            autoSyncTimer.Tick += new EventHandler(autoSyncTimer_Tick);
            AutoSyncValidator();
        }

        public void AutoSyncValidator()
        {
            if (Properties.Settings.Default.autoSync && Properties.Settings.Default.autoSyncInterval != 0)
            {
                autoSyncTimer.Stop();
                autoSyncTimer.Interval = Properties.Settings.Default.autoSyncInterval * 1000;
                autoSyncTimer.Start();
            }

            else
            {
                autoSyncTimer.Stop();
            }
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
            HistorySubForm hsf = new HistorySubForm(this);
            hsf.TopLevel = false;
            //ssf.AutoScroll = true;
            contentPanel.Controls.Add(hsf);
            hsf.Show();
        }

        public void ExternalSync(string action)
        {
            this.BeginInvoke((Action)delegate ()
            {
                contentPanel.Controls.Clear();
                SyncSubForm ssf = new SyncSubForm(action);
                ssf.TopLevel = false;
                //ssf.AutoScroll = true;
                contentPanel.Controls.Add(ssf);
                ssf.Show();
            });
        }

        private void pLogoutBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }

        private void pOptionsBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            OptionsSubForm osf = new OptionsSubForm(this);
            osf.TopLevel = false;
            contentPanel.Controls.Add(osf);
            osf.Show();
        }

        private void pAboutBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            AboutSubform asf = new AboutSubform();
            asf.TopLevel = false;
            contentPanel.Controls.Add(asf);
            asf.Show();
        }

        private void autoSyncTimer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autoSync)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    ExternalSync("autoSync");
                }
            }
            else
            {
                (sender as Timer).Stop();
            }
        }
    }
}
