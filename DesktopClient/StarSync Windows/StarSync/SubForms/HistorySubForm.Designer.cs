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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.HistoryTitleLabel = new System.Windows.Forms.Label();
            this.historyGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileUploadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveRestore = new System.Windows.Forms.DataGridViewImageColumn();
            this.saveDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // HistoryTitleLabel
            // 
            this.HistoryTitleLabel.AutoSize = true;
            this.HistoryTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HistoryTitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryTitleLabel.ForeColor = System.Drawing.Color.White;
            this.HistoryTitleLabel.Location = new System.Drawing.Point(263, 3);
            this.HistoryTitleLabel.Name = "HistoryTitleLabel";
            this.HistoryTitleLabel.Size = new System.Drawing.Size(243, 32);
            this.HistoryTitleLabel.TabIndex = 1;
            this.HistoryTitleLabel.Text = "StarSync Save History";
            // 
            // historyGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.historyGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.historyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historyGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.historyGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.historyGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.historyGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.historyGrid.ColumnHeadersHeight = 30;
            this.historyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.historyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.fileUploadDate,
            this.fileModifyDate,
            this.fileOwner,
            this.saveRestore,
            this.saveDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.historyGrid.EnableHeadersVisualStyles = false;
            this.historyGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.historyGrid.Location = new System.Drawing.Point(16, 57);
            this.historyGrid.Name = "historyGrid";
            this.historyGrid.RowHeadersVisible = false;
            this.historyGrid.RowHeadersWidth = 50;
            this.historyGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.historyGrid.RowTemplate.Height = 40;
            this.historyGrid.RowTemplate.ReadOnly = true;
            this.historyGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.historyGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyGrid.Size = new System.Drawing.Size(720, 291);
            this.historyGrid.TabIndex = 2;
            this.historyGrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.historyGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.historyGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.historyGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.historyGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.historyGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.historyGrid.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.historyGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.historyGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(191)))));
            this.historyGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.historyGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.historyGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.historyGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.historyGrid.ThemeStyle.HeaderStyle.Height = 30;
            this.historyGrid.ThemeStyle.ReadOnly = false;
            this.historyGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.historyGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.historyGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.historyGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.historyGrid.ThemeStyle.RowsStyle.Height = 40;
            this.historyGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.historyGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Restore";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 140;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Delete";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 140;
            // 
            // fileName
            // 
            this.fileName.DataPropertyName = "fileName";
            this.fileName.FillWeight = 78.53725F;
            this.fileName.HeaderText = "File Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // fileUploadDate
            // 
            this.fileUploadDate.DataPropertyName = "fileUploadDATE";
            this.fileUploadDate.FillWeight = 78.53725F;
            this.fileUploadDate.HeaderText = "Upload Date";
            this.fileUploadDate.Name = "fileUploadDate";
            this.fileUploadDate.ReadOnly = true;
            // 
            // fileModifyDate
            // 
            this.fileModifyDate.DataPropertyName = "fileModifyDate";
            this.fileModifyDate.FillWeight = 78.53725F;
            this.fileModifyDate.HeaderText = "Modify Date";
            this.fileModifyDate.Name = "fileModifyDate";
            this.fileModifyDate.ReadOnly = true;
            // 
            // fileOwner
            // 
            this.fileOwner.DataPropertyName = "fileOwner";
            this.fileOwner.FillWeight = 78.53725F;
            this.fileOwner.HeaderText = "Owner";
            this.fileOwner.Name = "fileOwner";
            this.fileOwner.ReadOnly = true;
            // 
            // saveRestore
            // 
            this.saveRestore.HeaderText = "Restore";
            this.saveRestore.Image = global::StarSync.Properties.Resources.ss_restore_ico;
            this.saveRestore.Name = "saveRestore";
            this.saveRestore.ReadOnly = true;
            // 
            // saveDelete
            // 
            this.saveDelete.HeaderText = "Delete";
            this.saveDelete.Image = global::StarSync.Properties.Resources.ss_remove_ico;
            this.saveDelete.Name = "saveDelete";
            this.saveDelete.ReadOnly = true;
            // 
            // HistorySubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(750, 360);
            this.Controls.Add(this.historyGrid);
            this.Controls.Add(this.HistoryTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistorySubForm";
            this.Text = "HistorySubForm";
            this.Load += new System.EventHandler(this.HistorySubForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label HistoryTitleLabel;
        private Guna.UI2.WinForms.Guna2DataGridView historyGrid;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileUploadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileOwner;
        private System.Windows.Forms.DataGridViewImageColumn saveRestore;
        private System.Windows.Forms.DataGridViewImageColumn saveDelete;
    }
}