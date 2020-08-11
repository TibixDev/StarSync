namespace StarSync
{
    partial class SyncSubForm
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.syncBtn = new Guna.UI2.WinForms.Guna2Button();
            this.syncLabel = new System.Windows.Forms.Label();
            this.syncLoading = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.statusLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // syncBtn
            // 
            this.syncBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.syncBtn.AutoRoundedCorners = true;
            this.syncBtn.BackColor = System.Drawing.Color.Transparent;
            this.syncBtn.BorderRadius = 64;
            this.syncBtn.CheckedState.Parent = this.syncBtn;
            this.syncBtn.CustomImages.Parent = this.syncBtn;
            this.syncBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.syncBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.syncBtn.ForeColor = System.Drawing.Color.White;
            this.syncBtn.HoverState.Parent = this.syncBtn;
            this.syncBtn.Image = global::StarSync.Properties.Resources.icons8_cloud_sync_96_alt;
            this.syncBtn.ImageSize = new System.Drawing.Size(100, 100);
            this.syncBtn.Location = new System.Drawing.Point(220, 79);
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.ShadowDecoration.BorderRadius = 60;
            this.syncBtn.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.syncBtn.ShadowDecoration.Parent = this.syncBtn;
            this.syncBtn.Size = new System.Drawing.Size(130, 130);
            this.syncBtn.TabIndex = 1;
            this.syncBtn.UseTransparentBackground = true;
            this.syncBtn.Click += new System.EventHandler(this.syncBtn_Click);
            // 
            // syncLabel
            // 
            this.syncLabel.AutoSize = true;
            this.syncLabel.BackColor = System.Drawing.Color.Transparent;
            this.syncLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncLabel.ForeColor = System.Drawing.Color.White;
            this.syncLabel.Location = new System.Drawing.Point(175, -2);
            this.syncLabel.Name = "syncLabel";
            this.syncLabel.Size = new System.Drawing.Size(211, 45);
            this.syncLabel.TabIndex = 5;
            this.syncLabel.Text = "StarSync Sync";
            this.syncLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // syncLoading
            // 
            this.syncLoading.Animated = true;
            this.syncLoading.AnimationSpeed = 2.5F;
            this.syncLoading.BackColor = System.Drawing.Color.Transparent;
            this.syncLoading.FillColor = System.Drawing.Color.Transparent;
            this.syncLoading.FillThickness = 10;
            this.syncLoading.Location = new System.Drawing.Point(283, 64);
            this.syncLoading.Name = "syncLoading";
            this.syncLoading.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.syncLoading.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.syncLoading.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.syncLoading.ProgressThickness = 10;
            this.syncLoading.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.syncLoading.ShadowDecoration.Parent = this.syncLoading;
            this.syncLoading.Size = new System.Drawing.Size(160, 160);
            this.syncLoading.TabIndex = 6;
            this.syncLoading.UseTransparentBackground = true;
            this.syncLoading.Value = 20;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(169, 230);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(261, 34);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Press the button to sync";
            this.statusLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SyncSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(550, 370);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.syncLoading);
            this.Controls.Add(this.syncLabel);
            this.Controls.Add(this.syncBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SyncSubForm";
            this.Text = "SyncSubForm";
            this.Load += new System.EventHandler(this.SyncSubForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button syncBtn;
        private System.Windows.Forms.Label syncLabel;
        private Guna.UI2.WinForms.Guna2CircleProgressBar syncLoading;
        private Guna.UI2.WinForms.Guna2HtmlLabel statusLabel;
    }
}