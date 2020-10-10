namespace StarSync
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.gunaElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.gunaDrag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.windowPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.minimizeBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.closeBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.apiKeyBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.rememberMeBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.genericLoading = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.loginBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.statusLabel = new System.Windows.Forms.Label();
            this.gunaColorTransition = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.gunaWindowAnimate = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.windowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse
            // 
            this.gunaElipse.TargetControl = this;
            // 
            // gunaDrag
            // 
            this.gunaDrag.TargetControl = this.windowPanel;
            // 
            // windowPanel
            // 
            this.windowPanel.BackColor = System.Drawing.Color.Transparent;
            this.windowPanel.Controls.Add(this.minimizeBtn);
            this.windowPanel.Controls.Add(this.closeBtn);
            this.windowPanel.Controls.Add(this.subtitleLabel);
            this.windowPanel.Controls.Add(this.titleLabel);
            this.windowPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.windowPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(138)))), ((int)(((byte)(199)))));
            this.windowPanel.Location = new System.Drawing.Point(-3, -4);
            this.windowPanel.Name = "windowPanel";
            this.windowPanel.ShadowDecoration.Parent = this.windowPanel;
            this.windowPanel.Size = new System.Drawing.Size(442, 100);
            this.windowPanel.TabIndex = 1;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Animated = true;
            this.minimizeBtn.CheckedState.Parent = this.minimizeBtn;
            this.minimizeBtn.CustomImages.Parent = this.minimizeBtn;
            this.minimizeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(63)))));
            this.minimizeBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.HoverState.Parent = this.minimizeBtn;
            this.minimizeBtn.Location = new System.Drawing.Point(396, 10);
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
            this.closeBtn.CheckedState.Parent = this.closeBtn;
            this.closeBtn.CustomImages.Parent = this.closeBtn;
            this.closeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(86)))));
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.HoverState.Parent = this.closeBtn;
            this.closeBtn.Location = new System.Drawing.Point(415, 10);
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
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Trebuchet MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.White;
            this.subtitleLabel.Location = new System.Drawing.Point(253, 63);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(104, 29);
            this.subtitleLabel.TabIndex = 3;
            this.subtitleLabel.Text = "Desktop";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Trebuchet MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(108, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(223, 61);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "StarSync";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(29, 112);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(379, 75);
            this.welcomeLabel.TabIndex = 4;
            this.welcomeLabel.Text = "Welcome! To use StarSync Desktop you are\r\ngoing to need an API Key.\r\nPlease enter" +
    " it below.\r\n";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apiKeyBox
            // 
            this.apiKeyBox.Animated = true;
            this.apiKeyBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.apiKeyBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.apiKeyBox.DefaultText = "";
            this.apiKeyBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.apiKeyBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.apiKeyBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.apiKeyBox.DisabledState.Parent = this.apiKeyBox;
            this.apiKeyBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.apiKeyBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.apiKeyBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.apiKeyBox.FocusedState.Parent = this.apiKeyBox;
            this.apiKeyBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.apiKeyBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(237)))));
            this.apiKeyBox.HoverState.Parent = this.apiKeyBox;
            this.apiKeyBox.Location = new System.Drawing.Point(23, 204);
            this.apiKeyBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.apiKeyBox.Name = "apiKeyBox";
            this.apiKeyBox.PasswordChar = '*';
            this.apiKeyBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.apiKeyBox.PlaceholderText = "StarSync API Key";
            this.apiKeyBox.SelectedText = "";
            this.apiKeyBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.apiKeyBox.ShadowDecoration.Enabled = true;
            this.apiKeyBox.ShadowDecoration.Parent = this.apiKeyBox;
            this.apiKeyBox.Size = new System.Drawing.Size(391, 39);
            this.apiKeyBox.TabIndex = 5;
            this.apiKeyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.apiKeyBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.apiKeyBox_MouseClick);
            // 
            // rememberMeBox
            // 
            this.rememberMeBox.Animated = true;
            this.rememberMeBox.AutoSize = true;
            this.rememberMeBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rememberMeBox.CheckedState.BorderRadius = 2;
            this.rememberMeBox.CheckedState.BorderThickness = 0;
            this.rememberMeBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rememberMeBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberMeBox.ForeColor = System.Drawing.Color.White;
            this.rememberMeBox.Location = new System.Drawing.Point(162, 250);
            this.rememberMeBox.Name = "rememberMeBox";
            this.rememberMeBox.Size = new System.Drawing.Size(114, 21);
            this.rememberMeBox.TabIndex = 6;
            this.rememberMeBox.Text = "Remember Me";
            this.rememberMeBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rememberMeBox.UncheckedState.BorderRadius = 2;
            this.rememberMeBox.UncheckedState.BorderThickness = 0;
            this.rememberMeBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rememberMeBox.UseVisualStyleBackColor = true;
            // 
            // genericLoading
            // 
            this.genericLoading.Animated = true;
            this.genericLoading.AnimationSpeed = 3F;
            this.genericLoading.BackColor = System.Drawing.Color.Transparent;
            this.genericLoading.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.genericLoading.FillThickness = 10;
            this.genericLoading.Location = new System.Drawing.Point(173, 294);
            this.genericLoading.Name = "genericLoading";
            this.genericLoading.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.genericLoading.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(138)))), ((int)(((byte)(199)))));
            this.genericLoading.ProgressThickness = 10;
            this.genericLoading.ShadowDecoration.BorderRadius = 10;
            this.genericLoading.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(138)))), ((int)(((byte)(199)))));
            this.genericLoading.ShadowDecoration.Parent = this.genericLoading;
            this.genericLoading.Size = new System.Drawing.Size(80, 80);
            this.genericLoading.TabIndex = 8;
            this.genericLoading.UseTransparentBackground = true;
            this.genericLoading.Value = 20;
            this.genericLoading.Visible = false;
            // 
            // loginBtn
            // 
            this.loginBtn.Animated = true;
            this.loginBtn.AutoRoundedCorners = true;
            this.loginBtn.BackColor = System.Drawing.Color.Transparent;
            this.loginBtn.BorderRadius = 21;
            this.loginBtn.CheckedState.Parent = this.loginBtn;
            this.loginBtn.CustomImages.Parent = this.loginBtn;
            this.loginBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.loginBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(138)))), ((int)(((byte)(199)))));
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.HoverState.Parent = this.loginBtn;
            this.loginBtn.Image = global::StarSync.Properties.Resources.login_key_icon;
            this.loginBtn.Location = new System.Drawing.Point(125, 421);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.ShadowDecoration.BorderRadius = 21;
            this.loginBtn.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.loginBtn.ShadowDecoration.Enabled = true;
            this.loginBtn.ShadowDecoration.Parent = this.loginBtn;
            this.loginBtn.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.loginBtn.Size = new System.Drawing.Size(180, 45);
            this.loginBtn.TabIndex = 7;
            this.loginBtn.Text = "Login";
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(162, 391);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(114, 25);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Login Status";
            this.statusLabel.Visible = false;
            // 
            // gunaColorTransition
            // 
            this.gunaColorTransition.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            this.gunaColorTransition.EndColor = System.Drawing.Color.Crimson;
            this.gunaColorTransition.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(435, 500);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.genericLoading);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.rememberMeBox);
            this.Controls.Add(this.apiKeyBox);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.windowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StarSync Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.windowPanel.ResumeLayout(false);
            this.windowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse gunaElipse;
        private Guna.UI2.WinForms.Guna2DragControl gunaDrag;
        private Guna.UI2.WinForms.Guna2GradientPanel windowPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2TextBox apiKeyBox;
        private Guna.UI2.WinForms.Guna2CheckBox rememberMeBox;
        private Guna.UI2.WinForms.Guna2GradientButton loginBtn;
        private Guna.UI2.WinForms.Guna2CircleButton minimizeBtn;
        private Guna.UI2.WinForms.Guna2CircleButton closeBtn;
        private Guna.UI2.WinForms.Guna2CircleProgressBar genericLoading;
        private System.Windows.Forms.Label statusLabel;
        private Guna.UI2.WinForms.Guna2ColorTransition gunaColorTransition;
        private Guna.UI2.WinForms.Guna2AnimateWindow gunaWindowAnimate;
    }
}

