﻿using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StarSync
{
    public partial class LoginForm : Form
    {
        private Guna2Transition gt = new Guna2Transition();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // UI OnLoad Configuration
            gunaWindowAnimate.SetAnimateWindow(this, Guna2AnimateWindow.AnimateWindowType.AW_BLEND, 200);
            gt.Interval = 3;
            welcomeLabel.Left = (this.Width - welcomeLabel.Width) / 2;
            titleLabel.Left = (this.Width - titleLabel.Width) / 2;
            genericLoading.Left = (this.Width - genericLoading.Width) / 2;
            apiKeyBox.PlaceholderText = "StarSync API Key";

            // AutoLogin on RememberMe
            if (Properties.Settings.Default.savedApiKey != string.Empty && Properties.Settings.Default.rememberMe == true)
            {
                Task verifyTask = new Task(() => APIVerifyTask(Properties.Settings.Default.savedApiKey));
                verifyTask.Start();
            }

            // Folder Structure Setup
            if (!Directory.Exists(Common.starSyncDataDir))
            {
                Directory.CreateDirectory(Common.starSyncDataDir);
            }

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (apiKeyBox.Text == string.Empty)
            {
                apiKeyBox.BorderColor = Color.Crimson;
                apiKeyBox.ShadowDecoration.Color = Color.Crimson;
            }

            else
            {
                Task verifyTask = new Task(() => APIVerifyTask(apiKeyBox.Text));
                verifyTask.Start();
            }
        }

        private void APIVerifyTask(string apiKey)
        {
            this.BeginInvoke((Action)delegate ()
            {
                loginBtn.Enabled = false;
                gt.ShowSync(genericLoading, true, Animation.Transparent);
                if (statusLabel.Visible)
                {
                    gt.HideSync(statusLabel, true, Animation.Transparent);
                }
            });

            Common.APIData objectResp = Common.APISimpleRequest("validateAuth", apiKey);
            APILogonHandler(objectResp, apiKey);
        }

        private async void APILogonHandler(Common.APIData logonResponse, string apiKey)
        {
            if (logonResponse.status == "success")
            {
                if (rememberMeBox.Checked)
                {
                    Properties.Settings.Default.savedApiKey = apiKey;
                    Properties.Settings.Default.rememberMe = true;
                    Properties.Settings.Default.Save();
                }

                Properties.Settings.Default.currentApiKey = apiKey;
                Properties.Settings.Default.currentUser = logonResponse.response;

                this.BeginInvoke((Action)delegate ()
                {
                    gt.HideSync(loginBtn, true, Animation.Scale);
                    statusLabel.Text = $"Welcome aboard, {logonResponse.response}!";
                    statusLabel.Left = (this.Width - statusLabel.Width) / 2;
                    gt.ShowSync(statusLabel, false, Animation.Transparent);
                    this.Height = this.Height - 55;
                });

                await Task.Delay(1500);

                this.BeginInvoke((Action)delegate ()
                {
                    gt.HideSync(statusLabel, false, Animation.Transparent);
                    statusLabel.Text = $"Enhancing your experience...";
                    statusLabel.Left = (this.Width - statusLabel.Width) / 2;
                    gt.ShowSync(statusLabel, false, Animation.Transparent);
                });

                await Task.Delay(1000);

                this.BeginInvoke((Action)delegate ()
                {
                    StarSyncMain ssMain = new StarSyncMain(logonResponse.response);
                    ssMain.Show();
                    this.Hide();
                });
            }

            else
            {
                this.BeginInvoke((Action)delegate ()
                {
                    gt.HideSync(genericLoading, false, Animation.Scale);
                    statusLabel.Text = "Login failed!";
                    statusLabel.Left = (this.Width - statusLabel.Width) / 2;
                    gt.ShowSync(statusLabel, false, Animation.Transparent);
                    loginBtn.Enabled = true;
                });
            }
        }

        private void apiKeyBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (apiKeyBox.BorderColor != Color.FromArgb(116, 116, 191) || apiKeyBox.ShadowDecoration.Color != Color.FromArgb(116, 116, 191))
            {
                apiKeyBox.BorderColor = Color.FromArgb(116, 116, 191);
                apiKeyBox.ShadowDecoration.Color = Color.FromArgb(116, 116, 191);
            }
        }
    }
}
