using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSync.SubForms
{
    public partial class OptionsSubForm : Form
    {
        StarSyncMain ssMain;

        bool formConfigCompleted = false;
        public OptionsSubForm(StarSyncMain referer_ssMain)
        {
            InitializeComponent();
            ssMain = referer_ssMain;
        }

        private void autoStartSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (formConfigCompleted)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                string starSyncPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                string fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

                if (autoStartSwitch.Checked)
                {
                    key.SetValue(fileName, starSyncPath);
                    Properties.Settings.Default.autoStart = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    key.DeleteValue(fileName, false);
                    Properties.Settings.Default.autoStart = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void autosyncIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formConfigCompleted) {
                switch (autosyncIntervalComboBox.SelectedIndex)
                {
                    case 0:
                        Properties.Settings.Default.autoSyncInterval = 600;
                        break;
                    case 1:
                        Properties.Settings.Default.autoSyncInterval = 1800;
                        break;
                    case 2:
                        Properties.Settings.Default.autoSyncInterval = 3600;
                        break;
                    case 3:
                        Properties.Settings.Default.autoSyncInterval = 10800;
                        break;
                }
                Properties.Settings.Default.Save();
                ssMain.AutoSyncValidator();
            }
        }

        private void autoSyncSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (formConfigCompleted)
            {
                if (autoSyncSwitch.Checked)
                {
                    Properties.Settings.Default.autoSync = true;
                    Properties.Settings.Default.Save();
                    autosyncIntervalComboBox.Enabled = true;
                    autosyncIntervalComboBox.SelectedIndex = 1;
                }

                else
                {
                    Properties.Settings.Default.autoSync = false;
                    Properties.Settings.Default.autoSyncInterval = 0;
                    Properties.Settings.Default.Save();
                    autosyncIntervalComboBox.Enabled = false;
                }
                ssMain.AutoSyncValidator();
            }
        }

        private void OptionsSubForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autoSync)
            {
                autoSyncSwitch.Checked = true;
            }

            if (Properties.Settings.Default.autoSyncInterval != 0) 
            {
                autosyncIntervalComboBox.Enabled = true;
                switch (Properties.Settings.Default.autoSyncInterval)
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

            if (Properties.Settings.Default.autoStart)
            {
                autoStartSwitch.Checked = true;
            }

            formConfigCompleted = true;
        }
    }
}
