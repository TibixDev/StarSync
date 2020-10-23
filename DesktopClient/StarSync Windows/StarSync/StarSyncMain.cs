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
            Common.MainContextConfigurator(ssNotifyIco, new ToolStripItemClickedEventHandler(ssNotifyIco_ItemClickHandler));
            gunaWindowAnim.SetAnimateWindow(this, Guna2AnimateWindow.AnimateWindowType.AW_BLEND, 200);
            verLabel.Text = $"{username} | Early Alpha";
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

        private void pSyncBtn_Click(object sender, EventArgs e)
        {
            Common.ChangeSubform(contentPanel, new SyncSubForm(null));
        }

        private void pHistoryBtn_Click(object sender, EventArgs e)
        {
            Common.ChangeSubform(contentPanel, new HistorySubForm(this));
        }

        public void ExternalSync(string action)
        {
            this.BeginInvoke((Action)delegate ()
            {
                contentPanel.Controls.Clear();
                SyncSubForm ssf = new SyncSubForm(this, action);
                ssf.TopLevel = false;
                contentPanel.Controls.Add(ssf);
                ssf.Show();
            });
        }

        private void pLogoutBtn_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void pOptionsBtn_Click(object sender, EventArgs e)
        {
            Common.ChangeSubform(contentPanel, new OptionsSubForm(this));
        }

        private void pAboutBtn_Click(object sender, EventArgs e)
        {
            Common.ChangeSubform(contentPanel, new AboutSubform());
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

        private void StarSyncMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                ssNotifyIco.Visible = true;
            }
            else
            {
                this.ShowInTaskbar = true;
                ssNotifyIco.Visible = false;
            }
        }

        private void ssNotifyIco_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void ssNotifyIco_ItemClickHandler(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            switch (item.Text)
            {
                case "Sync":
                    this.WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new SyncSubForm(null));
                    break;
                case "History":
                    this.WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new HistorySubForm(this));
                    break;
                case "Web Dashboard":
                    System.Diagnostics.Process.Start(Common.baseUrl);
                    break;
                case "Options":
                    this.WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new OptionsSubForm(this));
                    break;
                case "About":
                    this.WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new AboutSubform());
                    break;
                case "Logout":
                    Logout();
                    break;
                case "Exit":
                    Application.Exit();
                    break;
            }
        }

        private void Logout()
        {
            Properties.Settings.Default.savedApiKey = string.Empty;
            Properties.Settings.Default.currentApiKey = string.Empty;
            Properties.Settings.Default.Save();
            LoginForm lf = new LoginForm();
            lf.Visible = true;
            this.Dispose();
        }
    }
}
