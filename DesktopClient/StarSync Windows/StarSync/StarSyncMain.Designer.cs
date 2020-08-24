namespace StarSync
{
    partial class StarSyncMain
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
            this.windowPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelHideBtn = new Guna.UI2.WinForms.Guna2Button();
            this.verLabel = new System.Windows.Forms.Label();
            this.pOptionsBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pLogoutBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pWebDashBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pHistoryBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pSyncBtn = new Guna.UI2.WinForms.Guna2Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.minimizeBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.closeBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.gunaWindowAnim = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.windowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // windowPanel
            // 
            this.windowPanel.BackColor = System.Drawing.Color.Transparent;
            this.windowPanel.Controls.Add(this.panelHideBtn);
            this.windowPanel.Controls.Add(this.verLabel);
            this.windowPanel.Controls.Add(this.pOptionsBtn);
            this.windowPanel.Controls.Add(this.pLogoutBtn);
            this.windowPanel.Controls.Add(this.pWebDashBtn);
            this.windowPanel.Controls.Add(this.pHistoryBtn);
            this.windowPanel.Controls.Add(this.pSyncBtn);
            this.windowPanel.Controls.Add(this.titleLabel);
            this.windowPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.windowPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(138)))), ((int)(((byte)(199)))));
            this.windowPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.windowPanel.Location = new System.Drawing.Point(0, 0);
            this.windowPanel.Name = "windowPanel";
            this.windowPanel.ShadowDecoration.Parent = this.windowPanel;
            this.windowPanel.Size = new System.Drawing.Size(250, 400);
            this.windowPanel.TabIndex = 2;
            // 
            // panelHideBtn
            // 
            this.panelHideBtn.CheckedState.Parent = this.panelHideBtn;
            this.panelHideBtn.CustomImages.Parent = this.panelHideBtn;
            this.panelHideBtn.FillColor = System.Drawing.Color.Transparent;
            this.panelHideBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHideBtn.ForeColor = System.Drawing.Color.White;
            this.panelHideBtn.HoverState.Parent = this.panelHideBtn;
            this.panelHideBtn.Location = new System.Drawing.Point(220, 20);
            this.panelHideBtn.Name = "panelHideBtn";
            this.panelHideBtn.ShadowDecoration.Parent = this.panelHideBtn;
            this.panelHideBtn.Size = new System.Drawing.Size(30, 30);
            this.panelHideBtn.TabIndex = 9;
            this.panelHideBtn.Text = "<";
            this.panelHideBtn.UseTransparentBackground = true;
            this.panelHideBtn.Click += new System.EventHandler(this.panelHideBtn_Click);
            // 
            // verLabel
            // 
            this.verLabel.AutoSize = true;
            this.verLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verLabel.ForeColor = System.Drawing.Color.White;
            this.verLabel.Location = new System.Drawing.Point(59, 364);
            this.verLabel.Name = "verLabel";
            this.verLabel.Size = new System.Drawing.Size(136, 17);
            this.verLabel.TabIndex = 8;
            this.verLabel.Text = "user | Early Alpha v0.2";
            // 
            // pOptionsBtn
            // 
            this.pOptionsBtn.CheckedState.Parent = this.pOptionsBtn;
            this.pOptionsBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pOptionsBtn.CustomImages.Parent = this.pOptionsBtn;
            this.pOptionsBtn.FillColor = System.Drawing.Color.Transparent;
            this.pOptionsBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pOptionsBtn.ForeColor = System.Drawing.Color.White;
            this.pOptionsBtn.HoverState.Parent = this.pOptionsBtn;
            this.pOptionsBtn.Image = global::StarSync.Properties.Resources.settings_gear_63;
            this.pOptionsBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pOptionsBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.pOptionsBtn.Location = new System.Drawing.Point(0, 225);
            this.pOptionsBtn.Name = "pOptionsBtn";
            this.pOptionsBtn.ShadowDecoration.Parent = this.pOptionsBtn;
            this.pOptionsBtn.Size = new System.Drawing.Size(250, 45);
            this.pOptionsBtn.TabIndex = 7;
            this.pOptionsBtn.Text = "Options";
            this.pOptionsBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pLogoutBtn
            // 
            this.pLogoutBtn.CheckedState.Parent = this.pLogoutBtn;
            this.pLogoutBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pLogoutBtn.CustomImages.Parent = this.pLogoutBtn;
            this.pLogoutBtn.FillColor = System.Drawing.Color.Transparent;
            this.pLogoutBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLogoutBtn.ForeColor = System.Drawing.Color.White;
            this.pLogoutBtn.HoverState.Parent = this.pLogoutBtn;
            this.pLogoutBtn.Image = global::StarSync.Properties.Resources.lock_open;
            this.pLogoutBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pLogoutBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.pLogoutBtn.Location = new System.Drawing.Point(0, 270);
            this.pLogoutBtn.Name = "pLogoutBtn";
            this.pLogoutBtn.ShadowDecoration.Parent = this.pLogoutBtn;
            this.pLogoutBtn.Size = new System.Drawing.Size(250, 45);
            this.pLogoutBtn.TabIndex = 6;
            this.pLogoutBtn.Text = "Logout";
            this.pLogoutBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pWebDashBtn
            // 
            this.pWebDashBtn.CheckedState.Parent = this.pWebDashBtn;
            this.pWebDashBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pWebDashBtn.CustomImages.Parent = this.pWebDashBtn;
            this.pWebDashBtn.FillColor = System.Drawing.Color.Transparent;
            this.pWebDashBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pWebDashBtn.ForeColor = System.Drawing.Color.White;
            this.pWebDashBtn.HoverState.Parent = this.pWebDashBtn;
            this.pWebDashBtn.Image = global::StarSync.Properties.Resources.widget;
            this.pWebDashBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pWebDashBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.pWebDashBtn.Location = new System.Drawing.Point(0, 180);
            this.pWebDashBtn.Name = "pWebDashBtn";
            this.pWebDashBtn.ShadowDecoration.Parent = this.pWebDashBtn;
            this.pWebDashBtn.Size = new System.Drawing.Size(250, 45);
            this.pWebDashBtn.TabIndex = 5;
            this.pWebDashBtn.Text = "Web Dashboard";
            this.pWebDashBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pWebDashBtn.Click += new System.EventHandler(this.pWebDashBtn_Click);
            // 
            // pHistoryBtn
            // 
            this.pHistoryBtn.CheckedState.Parent = this.pHistoryBtn;
            this.pHistoryBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pHistoryBtn.CustomImages.Parent = this.pHistoryBtn;
            this.pHistoryBtn.FillColor = System.Drawing.Color.Transparent;
            this.pHistoryBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pHistoryBtn.ForeColor = System.Drawing.Color.White;
            this.pHistoryBtn.HoverState.Parent = this.pHistoryBtn;
            this.pHistoryBtn.Image = global::StarSync.Properties.Resources.folder_15;
            this.pHistoryBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pHistoryBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.pHistoryBtn.Location = new System.Drawing.Point(0, 135);
            this.pHistoryBtn.Name = "pHistoryBtn";
            this.pHistoryBtn.ShadowDecoration.Parent = this.pHistoryBtn;
            this.pHistoryBtn.Size = new System.Drawing.Size(250, 45);
            this.pHistoryBtn.TabIndex = 4;
            this.pHistoryBtn.Text = "Save History";
            this.pHistoryBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pHistoryBtn.Click += new System.EventHandler(this.pHistoryBtn_Click);
            // 
            // pSyncBtn
            // 
            this.pSyncBtn.CheckedState.Parent = this.pSyncBtn;
            this.pSyncBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pSyncBtn.CustomImages.Parent = this.pSyncBtn;
            this.pSyncBtn.FillColor = System.Drawing.Color.Transparent;
            this.pSyncBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pSyncBtn.ForeColor = System.Drawing.Color.White;
            this.pSyncBtn.HoverState.Parent = this.pSyncBtn;
            this.pSyncBtn.Image = global::StarSync.Properties.Resources.spaceship;
            this.pSyncBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pSyncBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.pSyncBtn.Location = new System.Drawing.Point(0, 90);
            this.pSyncBtn.Name = "pSyncBtn";
            this.pSyncBtn.ShadowDecoration.Parent = this.pSyncBtn;
            this.pSyncBtn.Size = new System.Drawing.Size(250, 45);
            this.pSyncBtn.TabIndex = 3;
            this.pSyncBtn.Text = "Sync Saves";
            this.pSyncBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pSyncBtn.Click += new System.EventHandler(this.pSyncBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Trebuchet MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(31, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(181, 49);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "StarSync";
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Animated = true;
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.CheckedState.Parent = this.minimizeBtn;
            this.minimizeBtn.CustomImages.Parent = this.minimizeBtn;
            this.minimizeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(63)))));
            this.minimizeBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.HoverState.Parent = this.minimizeBtn;
            this.minimizeBtn.Location = new System.Drawing.Point(955, 11);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(63)))));
            this.minimizeBtn.ShadowDecoration.Depth = 15;
            this.minimizeBtn.ShadowDecoration.Enabled = true;
            this.minimizeBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.minimizeBtn.ShadowDecoration.Parent = this.minimizeBtn;
            this.minimizeBtn.Size = new System.Drawing.Size(15, 15);
            this.minimizeBtn.TabIndex = 9;
            this.minimizeBtn.UseTransparentBackground = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Animated = true;
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.CheckedState.Parent = this.closeBtn;
            this.closeBtn.CustomImages.Parent = this.closeBtn;
            this.closeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(86)))));
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.HoverState.Parent = this.closeBtn;
            this.closeBtn.Location = new System.Drawing.Point(975, 11);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(86)))));
            this.closeBtn.ShadowDecoration.Depth = 15;
            this.closeBtn.ShadowDecoration.Enabled = true;
            this.closeBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closeBtn.ShadowDecoration.Parent = this.closeBtn;
            this.closeBtn.Size = new System.Drawing.Size(15, 15);
            this.closeBtn.TabIndex = 8;
            this.closeBtn.UseTransparentBackground = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Location = new System.Drawing.Point(250, 40);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.ShadowDecoration.Parent = this.contentPanel;
            this.contentPanel.Size = new System.Drawing.Size(750, 360);
            this.contentPanel.TabIndex = 10;
            // 
            // gunaWindowAnim
            // 
            this.gunaWindowAnim.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_SLIDE;
            this.gunaWindowAnim.Interval = 1000;
            // 
            // StarSyncMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1000, 400);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.windowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StarSyncMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StarSyncMain";
            this.Load += new System.EventHandler(this.StarSyncMain_Load);
            this.windowPanel.ResumeLayout(false);
            this.windowPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel windowPanel;
        private Guna.UI2.WinForms.Guna2CircleButton minimizeBtn;
        private Guna.UI2.WinForms.Guna2CircleButton closeBtn;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2Button pSyncBtn;
        private Guna.UI2.WinForms.Guna2Button pOptionsBtn;
        private Guna.UI2.WinForms.Guna2Button pLogoutBtn;
        private Guna.UI2.WinForms.Guna2Button pWebDashBtn;
        private Guna.UI2.WinForms.Guna2Button pHistoryBtn;
        private System.Windows.Forms.Label verLabel;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;
        private Guna.UI2.WinForms.Guna2Button panelHideBtn;
        private Guna.UI2.WinForms.Guna2AnimateWindow gunaWindowAnim;
    }
}