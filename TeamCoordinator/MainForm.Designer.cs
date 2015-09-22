namespace TeamCoordinator
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelStages = new System.Windows.Forms.Panel();
            this.panelTeams = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGrid = new System.Windows.Forms.TabPage();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.tpStages = new System.Windows.Forms.TabPage();
            this.tpTeams = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.tpStages.SuspendLayout();
            this.tpTeams.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStages
            // 
            this.panelStages.BackColor = System.Drawing.SystemColors.Control;
            this.panelStages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStages.Location = new System.Drawing.Point(3, 3);
            this.panelStages.Name = "panelStages";
            this.panelStages.Size = new System.Drawing.Size(563, 566);
            this.panelStages.TabIndex = 0;
            // 
            // panelTeams
            // 
            this.panelTeams.BackColor = System.Drawing.SystemColors.Control;
            this.panelTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTeams.Location = new System.Drawing.Point(3, 3);
            this.panelTeams.Name = "panelTeams";
            this.panelTeams.Size = new System.Drawing.Size(563, 566);
            this.panelTeams.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.toolStripMenuItem2,
            this.miEditMode,
            this.miEditGroups});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(577, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreate,
            this.miOpen,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(48, 20);
            this.miFile.Text = "Файл";
            // 
            // miCreate
            // 
            this.miCreate.Name = "miCreate";
            this.miCreate.Size = new System.Drawing.Size(121, 22);
            this.miCreate.Text = "Создать";
            this.miCreate.Click += new System.EventHandler(this.miCreate_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(121, 22);
            this.miOpen.Text = "Открыть";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(121, 22);
            this.miExit.Text = "Выход";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // miEditMode
            // 
            this.miEditMode.Name = "miEditMode";
            this.miEditMode.Size = new System.Drawing.Size(35, 20);
            this.miEditMode.Text = "<>";
            this.miEditMode.Click += new System.EventHandler(this.miEditMode_Click);
            // 
            // miEditGroups
            // 
            this.miEditGroups.Name = "miEditGroups";
            this.miEditGroups.Size = new System.Drawing.Size(61, 20);
            this.miEditGroups.Text = "Группы";
            this.miEditGroups.Click += new System.EventHandler(this.miEditGroups_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGrid);
            this.tabControl1.Controls.Add(this.tpStages);
            this.tabControl1.Controls.Add(this.tpTeams);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(577, 598);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.dgvGrid);
            this.tpGrid.Location = new System.Drawing.Point(4, 22);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.Size = new System.Drawing.Size(569, 572);
            this.tpGrid.TabIndex = 2;
            this.tpGrid.Text = "Сетка";
            this.tpGrid.UseVisualStyleBackColor = true;
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.AllowUserToResizeColumns = false;
            this.dgvGrid.AllowUserToResizeRows = false;
            this.dgvGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.EnableHeadersVisualStyles = false;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGrid.Size = new System.Drawing.Size(569, 572);
            this.dgvGrid.TabIndex = 1;
            this.dgvGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvGrid_MouseClick);
            // 
            // tpStages
            // 
            this.tpStages.Controls.Add(this.panelStages);
            this.tpStages.Location = new System.Drawing.Point(4, 22);
            this.tpStages.Name = "tpStages";
            this.tpStages.Padding = new System.Windows.Forms.Padding(3);
            this.tpStages.Size = new System.Drawing.Size(569, 572);
            this.tpStages.TabIndex = 0;
            this.tpStages.Text = "Этапы";
            this.tpStages.UseVisualStyleBackColor = true;
            // 
            // tpTeams
            // 
            this.tpTeams.Controls.Add(this.panelTeams);
            this.tpTeams.Location = new System.Drawing.Point(4, 22);
            this.tpTeams.Name = "tpTeams";
            this.tpTeams.Padding = new System.Windows.Forms.Padding(3);
            this.tpTeams.Size = new System.Drawing.Size(569, 572);
            this.tpTeams.TabIndex = 1;
            this.tpTeams.Text = "Команды";
            this.tpTeams.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 622);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.tpStages.ResumeLayout(false);
            this.tpTeams.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelStages;
        private System.Windows.Forms.Panel panelTeams;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miEditMode;
        private System.Windows.Forms.ToolStripMenuItem miEditGroups;
        private System.Windows.Forms.ToolStripMenuItem miCreate;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpStages;
        private System.Windows.Forms.TabPage tpTeams;
        private System.Windows.Forms.TabPage tpGrid;
        private System.Windows.Forms.DataGridView dgvGrid;
    }
}

