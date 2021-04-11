using System;
using System.Diagnostics;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using StarSync.Properties;
using StarSync.SubForms;

namespace StarSync
{
    public partial class StarSyncMain : Form
    {
        private readonly Timer autoSyncTimer = new Timer();
        private readonly Guna2Transition gt = new Guna2Transition();
        private readonly string username;

        public StarSyncMain(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

        private void StarSyncMain_Load(object sender, EventArgs e)
        {
            Common.MainContextConfigurator(ssNotifyIco, ssNotifyIco_ItemClickHandler);
            gunaWindowAnim.SetAnimateWindow(this, Guna2AnimateWindow.AnimateWindowType.AW_BLEND, 200);
            verLabel.Text = $"{username} | Early Alpha";
            verLabel.Left = (windowPanel.Width - verLabel.Width) / 2;
            gt.Interval = 3;
            autoSyncTimer.Tick += autoSyncTimer_Tick;
            AutoSyncValidator();
        }

        public void AutoSyncValidator()
        {
            if (Settings.Default.autoSync && Settings.Default.autoSyncInterval != 0)
            {
                autoSyncTimer.Stop();
                autoSyncTimer.Interval = Settings.Default.autoSyncInterval * 1000;
                autoSyncTimer.Start();
            }

            else
            {
                autoSyncTimer.Stop();
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pWebDashBtn_Click(object sender, EventArgs e)
        {
            Process.Start(Common.baseUrl);
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
            BeginInvoke((Action) delegate
            {
                contentPanel.Controls.Clear();
                var ssf = new SyncSubForm(this, action);
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
            if (Settings.Default.autoSync)
            {
                if (WindowState == FormWindowState.Minimized) ExternalSync("autoSync");
            }
            else
            {
                (sender as Timer).Stop();
            }
        }

        private void StarSyncMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                ssNotifyIco.Visible = true;
            }
            else
            {
                ShowInTaskbar = true;
                ssNotifyIco.Visible = false;
            }
        }

        private void ssNotifyIco_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void ssNotifyIco_ItemClickHandler(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem;
            switch (item.Text)
            {
                case "Sync":
                    WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new SyncSubForm(null));
                    break;
                case "History":
                    WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new HistorySubForm(this));
                    break;
                case "Web Dashboard":
                    Process.Start(Common.baseUrl);
                    break;
                case "Options":
                    WindowState = FormWindowState.Normal;
                    Common.ChangeSubform(contentPanel, new OptionsSubForm(this));
                    break;
                case "About":
                    WindowState = FormWindowState.Normal;
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
            Settings.Default.savedApiKey = string.Empty;
            Settings.Default.currentApiKey = string.Empty;
            Settings.Default.Save();
            var lf = new LoginForm();
            lf.Visible = true;
            Dispose();
        }
    }
}