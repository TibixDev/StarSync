namespace StarSync.SubForms
{
    partial class HistorySubForm
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
            this.historyConsole = new System.Windows.Forms.RichTextBox();
            this.HistoryTitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // historyConsole
            // 
            this.historyConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.historyConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyConsole.ForeColor = System.Drawing.Color.Green;
            this.historyConsole.Location = new System.Drawing.Point(12, 112);
            this.historyConsole.Name = "historyConsole";
            this.historyConsole.ReadOnly = true;
            this.historyConsole.Size = new System.Drawing.Size(526, 246);
            this.historyConsole.TabIndex = 0;
            this.historyConsole.Text = "";
            // 
            // HistoryTitleLabel
            // 
            this.HistoryTitleLabel.AutoSize = true;
            this.HistoryTitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryTitleLabel.ForeColor = System.Drawing.Color.White;
            this.HistoryTitleLabel.Location = new System.Drawing.Point(167, 9);
            this.HistoryTitleLabel.Name = "HistoryTitleLabel";
            this.HistoryTitleLabel.Size = new System.Drawing.Size(243, 32);
            this.HistoryTitleLabel.TabIndex = 1;
            this.HistoryTitleLabel.Text = "StarSync Save History";
            // 
            // HistorySubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(550, 370);
            this.Controls.Add(this.HistoryTitleLabel);
            this.Controls.Add(this.historyConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistorySubForm";
            this.Text = "HistorySubForm";
            this.Load += new System.EventHandler(this.HistorySubForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.RichTextBox historyConsole;
        private System.Windows.Forms.Label HistoryTitleLabel;
    }
}