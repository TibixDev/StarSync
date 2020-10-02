namespace StarSync.SubForms
{
    partial class OptionsSubForm
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
            this.GunaElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.autoStartSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.enableAutostartLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.enableSyncLabel = new System.Windows.Forms.Label();
            this.autoSyncSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.autosyncIntervalComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GunaElipse
            // 
            this.GunaElipse.TargetControl = this;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(232, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "StarSync Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "General";
            // 
            // autoStartSwitch
            // 
            this.autoStartSwitch.Animated = true;
            this.autoStartSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.autoStartSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.autoStartSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.autoStartSwitch.CheckedState.InnerColor = System.Drawing.Color.White;
            this.autoStartSwitch.CheckedState.Parent = this.autoStartSwitch;
            this.autoStartSwitch.Location = new System.Drawing.Point(19, 108);
            this.autoStartSwitch.Name = "autoStartSwitch";
            this.autoStartSwitch.ShadowDecoration.Parent = this.autoStartSwitch;
            this.autoStartSwitch.Size = new System.Drawing.Size(35, 20);
            this.autoStartSwitch.TabIndex = 2;
            this.autoStartSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.autoStartSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.autoStartSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.autoStartSwitch.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.autoStartSwitch.UncheckedState.Parent = this.autoStartSwitch;
            this.autoStartSwitch.CheckedChanged += new System.EventHandler(this.autoStartSwitch_CheckedChanged);
            // 
            // enableAutostartLabel
            // 
            this.enableAutostartLabel.AutoSize = true;
            this.enableAutostartLabel.BackColor = System.Drawing.Color.Transparent;
            this.enableAutostartLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableAutostartLabel.ForeColor = System.Drawing.Color.White;
            this.enableAutostartLabel.Location = new System.Drawing.Point(62, 105);
            this.enableAutostartLabel.Name = "enableAutostartLabel";
            this.enableAutostartLabel.Size = new System.Drawing.Size(213, 25);
            this.enableAutostartLabel.TabIndex = 3;
            this.enableAutostartLabel.Text = "Autostart with Windows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(62, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "AutoSync";
            // 
            // enableSyncLabel
            // 
            this.enableSyncLabel.AutoSize = true;
            this.enableSyncLabel.BackColor = System.Drawing.Color.Transparent;
            this.enableSyncLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableSyncLabel.ForeColor = System.Drawing.Color.White;
            this.enableSyncLabel.Location = new System.Drawing.Point(62, 193);
            this.enableSyncLabel.Name = "enableSyncLabel";
            this.enableSyncLabel.Size = new System.Drawing.Size(152, 25);
            this.enableSyncLabel.TabIndex = 8;
            this.enableSyncLabel.Text = "Enable AutoSync";
            // 
            // autoSyncSwitch
            // 
            this.autoSyncSwitch.Animated = true;
            this.autoSyncSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.autoSyncSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.autoSyncSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.autoSyncSwitch.CheckedState.InnerColor = System.Drawing.Color.White;
            this.autoSyncSwitch.CheckedState.Parent = this.autoSyncSwitch;
            this.autoSyncSwitch.Location = new System.Drawing.Point(19, 196);
            this.autoSyncSwitch.Name = "autoSyncSwitch";
            this.autoSyncSwitch.ShadowDecoration.Parent = this.autoSyncSwitch;
            this.autoSyncSwitch.Size = new System.Drawing.Size(35, 20);
            this.autoSyncSwitch.TabIndex = 7;
            this.autoSyncSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.autoSyncSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.autoSyncSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.autoSyncSwitch.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.autoSyncSwitch.UncheckedState.Parent = this.autoSyncSwitch;
            this.autoSyncSwitch.CheckedChanged += new System.EventHandler(this.autoSyncSwitch_CheckedChanged);
            // 
            // autosyncIntervalComboBox
            // 
            this.autosyncIntervalComboBox.Animated = true;
            this.autosyncIntervalComboBox.AutoRoundedCorners = true;
            this.autosyncIntervalComboBox.BackColor = System.Drawing.Color.Transparent;
            this.autosyncIntervalComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.autosyncIntervalComboBox.BorderRadius = 14;
            this.autosyncIntervalComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.autosyncIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autosyncIntervalComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.autosyncIntervalComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.autosyncIntervalComboBox.FocusedState.Parent = this.autosyncIntervalComboBox;
            this.autosyncIntervalComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.autosyncIntervalComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.autosyncIntervalComboBox.FormattingEnabled = true;
            this.autosyncIntervalComboBox.HoverState.Parent = this.autosyncIntervalComboBox;
            this.autosyncIntervalComboBox.ItemHeight = 25;
            this.autosyncIntervalComboBox.Items.AddRange(new object[] {
            "Every 10 Minutes",
            "Every 30 Minutes",
            "Every Hour",
            "Every 3 Hours"});
            this.autosyncIntervalComboBox.ItemsAppearance.Parent = this.autosyncIntervalComboBox;
            this.autosyncIntervalComboBox.Location = new System.Drawing.Point(178, 227);
            this.autosyncIntervalComboBox.Name = "autosyncIntervalComboBox";
            this.autosyncIntervalComboBox.ShadowDecoration.Parent = this.autosyncIntervalComboBox;
            this.autosyncIntervalComboBox.Size = new System.Drawing.Size(163, 31);
            this.autosyncIntervalComboBox.TabIndex = 9;
            this.autosyncIntervalComboBox.SelectedIndexChanged += new System.EventHandler(this.autosyncIntervalComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "AutoSync Interval";
            // 
            // OptionsSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.autosyncIntervalComboBox);
            this.Controls.Add(this.enableSyncLabel);
            this.Controls.Add(this.autoSyncSwitch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enableAutostartLabel);
            this.Controls.Add(this.autoStartSwitch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsSubForm";
            this.Text = "OptionsSubForm";
            this.Load += new System.EventHandler(this.OptionsSubForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse GunaElipse;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2ToggleSwitch autoStartSwitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label enableAutostartLabel;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox autosyncIntervalComboBox;
        private System.Windows.Forms.Label enableSyncLabel;
        private Guna.UI2.WinForms.Guna2ToggleSwitch autoSyncSwitch;
        private System.Windows.Forms.Label label4;
    }
}