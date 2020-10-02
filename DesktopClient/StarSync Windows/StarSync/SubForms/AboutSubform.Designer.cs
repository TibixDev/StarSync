namespace StarSync.SubForms
{
    partial class AboutSubform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutSubform));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentHtmlLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.aboutContentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.aboutContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(230, 40);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "StarSync - About";
            // 
            // contentHtmlLabel
            // 
            this.contentHtmlLabel.BackColor = System.Drawing.Color.Transparent;
            this.contentHtmlLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentHtmlLabel.ForeColor = System.Drawing.Color.White;
            this.contentHtmlLabel.Location = new System.Drawing.Point(20, 0);
            this.contentHtmlLabel.MaximumSize = new System.Drawing.Size(710, 0);
            this.contentHtmlLabel.Name = "contentHtmlLabel";
            this.contentHtmlLabel.Size = new System.Drawing.Size(710, 299);
            this.contentHtmlLabel.TabIndex = 2;
            this.contentHtmlLabel.Text = resources.GetString("contentHtmlLabel.Text");
            // 
            // aboutContentPanel
            // 
            this.aboutContentPanel.AutoScroll = true;
            this.aboutContentPanel.Controls.Add(this.contentHtmlLabel);
            this.aboutContentPanel.Location = new System.Drawing.Point(0, 50);
            this.aboutContentPanel.Name = "aboutContentPanel";
            this.aboutContentPanel.ShadowDecoration.Parent = this.aboutContentPanel;
            this.aboutContentPanel.Size = new System.Drawing.Size(750, 410);
            this.aboutContentPanel.TabIndex = 3;
            // 
            // AboutSubform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.aboutContentPanel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutSubform";
            this.Text = "AboutSubform";
            this.Load += new System.EventHandler(this.AboutSubform_Load);
            this.aboutContentPanel.ResumeLayout(false);
            this.aboutContentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel contentHtmlLabel;
        private Guna.UI2.WinForms.Guna2Panel aboutContentPanel;
    }
}