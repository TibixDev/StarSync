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
    public partial class AboutSubform : Form
    {
        public AboutSubform()
        {
            InitializeComponent();
        }

        private void AboutSubform_Load(object sender, EventArgs e)
        {
            contentHtmlLabel.Text = "<b>StarSync</b> - Created with <font style='color: red;'>❤️</font> by Tibix<br>StarSync is an open-source cross-platform cloud save management app created for Stardew Valley.<br><br>StarSync is free, and it will always be free. I do not earn any revenue from this project. Hosting is covered by me, and any donations are welcome.<br><br>Special thanks to:<br><b>ConcernedApe - For creating Stardew Valley</b>‎<br>‎<b>Icons8 - For the icons</b>‎<br><b>Material Icons - For the icons</b>‎<br><b>StackOverflow - For everything else</b>‎<br><br>Open-Source Libraries Used:<br>RestSharp, Newtonsoft.JSON, DotNetZip, Bootstrap, Bootstrap Dark, PHPQRCode<br><br>Copyright (c) 2020 TibixDev<br>Licensed under the MIT license";
            contentHtmlLabel.Visible = true;
            this.Update();
        }
    }
}
