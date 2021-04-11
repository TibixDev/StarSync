using System;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using StarSync.Properties;

namespace StarSync.SubForms
{
    public partial class OptionsSubForm : Form
    {
        private bool formConfigCompleted;
        private readonly StarSyncMain ssMain;

        public OptionsSubForm(StarSyncMain referer_ssMain)
        {
            InitializeComponent();
            ssMain = referer_ssMain;
        }

        private void autoStartSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (formConfigCompleted)
            {
                var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                var starSyncPath = Assembly.GetEntryAssembly().Location;
                var fileName = Assembly.GetExecutingAssembly().GetName().Name;

                if (autoStartSwitch.Checked)
                {
                    key.SetValue(fileName, starSyncPath);
                    Settings.Default.autoStart = true;
                    Settings.Default.Save();
                }
                else
                {
                    key.DeleteValue(fileName, false);
                    Settings.Default.autoStart = false;
                    Settings.Default.Save();
                }
            }
        }

        private void autosyncIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formConfigCompleted)
            {
                switch (autosyncIntervalComboBox.SelectedIndex)
                {
                    case 0:
                        Settings.Default.autoSyncInterval = 600;
                        break;
                    case 1:
                        Settings.Default.autoSyncInterval = 1800;
                        break;
                    case 2:
                        Settings.Default.autoSyncInterval = 3600;
                        break;
                    case 3:
                        Settings.Default.autoSyncInterval = 10800;
                        break;
                }

                Settings.Default.Save();
                ssMain.AutoSyncValidator();
            }
        }

        private void autoSyncSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (formConfigCompleted)
            {
                if (autoSyncSwitch.Checked)
                {
                    Settings.Default.autoSync = true;
                    Settings.Default.Save();
                    autosyncIntervalComboBox.Enabled = true;
                    autosyncIntervalComboBox.SelectedIndex = 1;
                }

                else
                {
                    Settings.Default.autoSync = false;
                    Settings.Default.autoSyncInterval = 0;
                    Settings.Default.Save();
                    autosyncIntervalComboBox.Enabled = false;
                }

                ssMain.AutoSyncValidator();
            }
        }

        private void OptionsSubForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.autoSync) autoSyncSwitch.Checked = true;

            if (Settings.Default.autoSyncInterval != 0)
            {
                autosyncIntervalComboBox.Enabled = true;
                switch (Settings.Default.autoSyncInterval)
                {
                    case 600:
                        autosyncIntervalComboBox.SelectedIndex = 0;
                        break;
                    case 1800:
                        autosyncIntervalComboBox.SelectedIndex = 1;
                        break;
                    case 3600:
                        autosyncIntervalComboBox.SelectedIndex = 2;
                        break;
                    case 10800:
                        autosyncIntervalComboBox.SelectedIndex = 3;
                        break;
                }
            }

            if (Settings.Default.autoStart) autoStartSwitch.Checked = true;

            formConfigCompleted = true;
        }
    }
}