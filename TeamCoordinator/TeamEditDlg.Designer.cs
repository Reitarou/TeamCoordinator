namespace TeamCoordinator
{
    partial class TeamEditDlg
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvStages = new System.Windows.Forms.DataGridView();
            this.clStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStagePass = new System.Windows.Forms.Button();
            this.btnStageIncomplete = new System.Windows.Forms.Button();
            this.btnStageComplete = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(75, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(238, 20);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 292);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(238, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Группа";
            // 
            // dgvStages
            // 
            this.dgvStages.AllowUserToAddRows = false;
            this.dgvStages.AllowUserToDeleteRows = false;
            this.dgvStages.AllowUserToResizeColumns = false;
            this.dgvStages.AllowUserToResizeRows = false;
            this.dgvStages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clStage,
            this.clUsage});
            this.dgvStages.Location = new System.Drawing.Point(17, 75);
            this.dgvStages.MultiSelect = false;
            this.dgvStages.Name = "dgvStages";
            this.dgvStages.RowHeadersVisible = false;
            this.dgvStages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStages.Size = new System.Drawing.Size(296, 150);
            this.dgvStages.TabIndex = 8;
            this.dgvStages.SelectionChanged += new System.EventHandler(this.dgvStages_SelectionChanged);
            // 
            // clStage
            // 
            this.clStage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clStage.HeaderText = "Этап";
            this.clStage.Name = "clStage";
            this.clStage.ReadOnly = true;
            // 
            // clUsage
            // 
            this.clUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clUsage.FillWeight = 200F;
            this.clUsage.HeaderText = "Состояние";
            this.clUsage.Name = "clUsage";
            this.clUsage.ReadOnly = true;
            // 
            // btnStagePass
            // 
            this.btnStagePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStagePass.Location = new System.Drawing.Point(17, 231);
            this.btnStagePass.Name = "btnStagePass";
            this.btnStagePass.Size = new System.Drawing.Size(75, 23);
            this.btnStagePass.TabIndex = 9;
            this.btnStagePass.Text = "Удалить";
            this.btnStagePass.UseVisualStyleBackColor = true;
            this.btnStagePass.Click += new System.EventHandler(this.btnStagePass_Click);
            // 
            // btnStageIncomplete
            // 
            this.btnStageIncomplete.Location = new System.Drawing.Point(98, 231);
            this.btnStageIncomplete.Name = "btnStageIncomplete";
            this.btnStageIncomplete.Size = new System.Drawing.Size(75, 23);
            this.btnStageIncomplete.TabIndex = 10;
            this.btnStageIncomplete.Text = "Добавить";
            this.btnStageIncomplete.UseVisualStyleBackColor = true;
            this.btnStageIncomplete.Click += new System.EventHandler(this.btnStageIncomplete_Click);
            // 
            // btnStageComplete
            // 
            this.btnStageComplete.Location = new System.Drawing.Point(179, 231);
            this.btnStageComplete.Name = "btnStageComplete";
            this.btnStageComplete.Size = new System.Drawing.Size(75, 23);
            this.btnStageComplete.TabIndex = 11;
            this.btnStageComplete.Text = "<>";
            this.btnStageComplete.UseVisualStyleBackColor = true;
            this.btnStageComplete.Click += new System.EventHandler(this.btnStageComplete_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(279, 231);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(34, 23);
            this.btnAuto.TabIndex = 12;
            this.btnAuto.Text = "A";
            this.btnAuto.UseVisualStyleBackColor = true;
            // 
            // TeamEditDlg
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(325, 327);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnStageComplete);
            this.Controls.Add(this.btnStageIncomplete);
            this.Controls.Add(this.btnStagePass);
            this.Controls.Add(this.dgvStages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamEditDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Правка команды";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvStages;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsage;
        private System.Windows.Forms.Button btnStagePass;
        private System.Windows.Forms.Button btnStageIncomplete;
        private System.Windows.Forms.Button btnStageComplete;
        private System.Windows.Forms.Button btnAuto;
    }
}