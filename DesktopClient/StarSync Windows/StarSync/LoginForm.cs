using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using StarSync.Properties;

namespace StarSync
{
    public partial class LoginForm : Form
    {
        private readonly Guna2Transition gt = new Guna2Transition();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // UI OnLoad Configuration
            gunaWindowAnimate.SetAnimateWindow(this, Guna2AnimateWindow.AnimateWindowType.AW_BLEND, 200);
            gt.Interval = 3;
            //welcomeLabel.Left = (Width - welcomeLabel.Width) / 2;
            titleLabel.Left = (Width - titleLabel.Width) / 2;
            genericLoading.Left = (Width - genericLoading.Width) / 2;
            //apiKeyBox.PlaceholderText = "StarSync API Key";

            // AutoLogin on RememberMe
            if (Settings.Default.savedApiKey != string.Empty && Settings.Default.savedHost != string.Empty && Settings.Default.rememberMe)
            {
                Common.baseUrl = Settings.Default.savedHost;
                var verifyTask = new Task(() => APIVerifyTask(Settings.Default.savedApiKey, Settings.Default.savedHost));
                verifyTask.Start();
            }

            // Folder Structure Setup
            if (!Directory.Exists(Common.starSyncDataDir)) Directory.CreateDirectory(Common.starSyncDataDir);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (apiKeyBox.Text == string.Empty)
            {
                apiKeyBox.BorderColor = Color.Crimson;
                apiKeyBox.ShadowDecoration.Color = Color.Crimson;
            }

            if (hostURIBox.Text == string.Empty)
            {
                hostURIBox.BorderColor = Color.Crimson;
                hostURIBox.ShadowDecoration.Color = Color.Crimson;
            }

            else
            {
                Common.baseUrl = hostURIBox.Text;
                var verifyTask = new Task(() => APIVerifyTask(apiKeyBox.Text, hostURIBox.Text));
                verifyTask.Start();
            }
        }

        private void APIVerifyTask(string apiKey, string host)
        {
            BeginInvoke((Action) delegate
            {
                loginBtn.Enabled = false;
                gt.ShowSync(genericLoading, true, Animation.Transparent);
                if (statusLabel.Visible) gt.HideSync(statusLabel, true, Animation.Transparent);
            });

            var objectResp = Common.APISimpleRequest("validateAuth", apiKey);
            APILogonHandler(objectResp, apiKey, host);
        }

        private async void APILogonHandler(Common.APIData logonResponse, string apiKey, string host)
        {
            if (logonResponse.status == "success")
            {
                if (rememberMeBox.Checked)
                {
                    Settings.Default.savedApiKey = apiKey;
                    Settings.Default.savedHost = Common.baseUrl;
                    Settings.Default.rememberMe = true;
                    Settings.Default.Save();
                }

                Settings.Default.currentApiKey = apiKey;
                Settings.Default.currentUser = logonResponse.response;

                BeginInvoke((Action) delegate
                {
                    gt.HideSync(loginBtn, true, Animation.Scale);
                    statusLabel.Text = $"Welcome aboard, {logonResponse.response}!";
                    statusLabel.Left = (Width - statusLabel.Width) / 2;
                    gt.ShowSync(statusLabel, false, Animation.Transparent);
                    Height = Height - 55;
                });

                await Task.Delay(1500);

                BeginInvoke((Action) delegate
                {
                    gt.HideSync(statusLabel, false, Animation.Transparent);
                    statusLabel.Text = "Enhancing your experience...";
                    statusLabel.Left = (Width - statusLabel.Width) / 2;
                    gt.ShowSync(statusLabel, false, Animation.Transparent);
                });

                await Task.Delay(1000);

                BeginInvoke((Action) delegate
                {
                    var ssMain = new StarSyncMain(logonResponse.response);
                    ssMain.Show();
                    Hide();
                });
            }

            else
            {
                BeginInvoke((Action) delegate
                {
                    gt.HideSync(genericLoading, false, Animation.Scale);
                    statusLabel.Text = "Login failed!";
                    statusLabel.Left = (Width - statusLabel.Width) / 2;
                    gt.ShowSync(statusLabel, false, Animation.Transparent);
                    loginBtn.Enabled = true;
                });
            }
        }

        private void apiKeyBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (apiKeyBox.BorderColor != Color.FromArgb(116, 116, 191) ||
                apiKeyBox.ShadowDecoration.Color != Color.FromArgb(116, 116, 191))
            {
                apiKeyBox.BorderColor = Color.FromArgb(116, 116, 191);
                apiKeyBox.ShadowDecoration.Color = Color.FromArgb(116, 116, 191);
            }
        }
    }
}