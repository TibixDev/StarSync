using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace StarSync
{
    class Common
    {
        public static readonly string baseUrl = "http://starsync.000webhostapp.com/";
        public static readonly string appdataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string starSyncDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StarSync";
        public static readonly string stardewDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StardewValley\Saves";

        public class apiData
        {
            public string response { get; set; }
            public string status { get; set; }
            public string uploadDate { get; set; }
            public string modifyDate { get; set; }

            public apiData(string response, string status, string uploadDate = null, string modifyDate = null)
            {
                this.response = response;
                this.status = status;
                this.uploadDate = uploadDate;
                this.modifyDate = modifyDate;
            }
        }

        public static string ConvertToSQLDateTime(DateTime entry)
        {
            return entry.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime ConvertToGlobalDateTime(DateTime entry)
        {
            return DateTime.Now;
        }
        public static DateTime GetLatestInDirectory(string dir)
        {
            DateTime latest = new DateTime();
            DirectoryInfo folder = new DirectoryInfo(dir);
            FileInfo latestFile = folder.GetFiles("*", SearchOption.AllDirectories).OrderByDescending(f => f.LastWriteTimeUtc).First();
            latest = latestFile.LastWriteTimeUtc;
            return latest;
        }

        public static DateTime TrimMilliseconds(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind);
        }

        public static string GetCurrentAPIKey()
        {
            return Properties.Settings.Default.currentApiKey;
        }
    }
}
