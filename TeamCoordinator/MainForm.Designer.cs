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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpGrid = new System.Windows.Forms.TabPage();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.tpLists = new System.Windows.Forms.TabPage();
            this.pnlProps = new System.Windows.Forms.Panel();
            this.pnlStageProps = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStageShortname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAcceptGroup = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnUnacceptGroup = new System.Windows.Forms.Button();
            this.tbStageName = new System.Windows.Forms.TextBox();
            this.btnAcceptAllGroups = new System.Windows.Forms.Button();
            this.btnStageOk = new System.Windows.Forms.Button();
            this.btnUnacceptAllGroups = new System.Windows.Forms.Button();
            this.lvOtherGroups = new System.Windows.Forms.ListBox();
            this.lvAcceptedGroups = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSceneProps = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSceneCoach = new System.Windows.Forms.TextBox();
            this.cmbSceneStage = new System.Windows.Forms.ComboBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbSceneNumber = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSceneOk = new System.Windows.Forms.Button();
            this.pnlGroupProps = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbGroupShortName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.btnGroupOk = new System.Windows.Forms.Button();
            this.pnlTeamProps = new System.Windows.Forms.Panel();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnStageComplete = new System.Windows.Forms.Button();
            this.btnStageIncomplete = new System.Windows.Forms.Button();
            this.btnStagePass = new System.Windows.Forms.Button();
            this.dgvStages = new System.Windows.Forms.DataGridView();
            this.clStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTeamGroup = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTeamOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTeamName = new System.Windows.Forms.TextBox();
            this.tvList = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.tpLists.SuspendLayout();
            this.pnlProps.SuspendLayout();
            this.pnlStageProps.SuspendLayout();
            this.pnlSceneProps.SuspendLayout();
            this.pnlGroupProps.SuspendLayout();
            this.pnlTeamProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1717, 24);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpGrid);
            this.tabControl.Controls.Add(this.tpLists);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1717, 508);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.dgvGrid);
            this.tpGrid.Location = new System.Drawing.Point(4, 22);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.Size = new System.Drawing.Size(1709, 482);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.EnableHeadersVisualStyles = false;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGrid.Size = new System.Drawing.Size(1709, 482);
            this.dgvGrid.TabIndex = 1;
            this.dgvGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvGrid_MouseClick);
            // 
            // tpLists
            // 
            this.tpLists.Controls.Add(this.pnlProps);
            this.tpLists.Controls.Add(this.tvList);
            this.tpLists.Location = new System.Drawing.Point(4, 22);
            this.tpLists.Name = "tpLists";
            this.tpLists.Padding = new System.Windows.Forms.Padding(3);
            this.tpLists.Size = new System.Drawing.Size(1709, 482);
            this.tpLists.TabIndex = 0;
            this.tpLists.Text = "Списки";
            this.tpLists.UseVisualStyleBackColor = true;
            // 
            // pnlProps
            // 
            this.pnlProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProps.Controls.Add(this.pnlStageProps);
            this.pnlProps.Controls.Add(this.pnlSceneProps);
            this.pnlProps.Controls.Add(this.pnlGroupProps);
            this.pnlProps.Controls.Add(this.pnlTeamProps);
            this.pnlProps.Location = new System.Drawing.Point(412, 6);
            this.pnlProps.Name = "pnlProps";
            this.pnlProps.Size = new System.Drawing.Size(1288, 470);
            this.pnlProps.TabIndex = 1;
            // 
            // pnlStageProps
            // 
            this.pnlStageProps.Controls.Add(this.label9);
            this.pnlStageProps.Controls.Add(this.label8);
            this.pnlStageProps.Controls.Add(this.tbStageShortname);
            this.pnlStageProps.Controls.Add(this.label4);
            this.pnlStageProps.Controls.Add(this.btnAcceptGroup);
            this.pnlStageProps.Controls.Add(this.button6);
            this.pnlStageProps.Controls.Add(this.btnUnacceptGroup);
            this.pnlStageProps.Controls.Add(this.tbStageName);
            this.pnlStageProps.Controls.Add(this.btnAcceptAllGroups);
            this.pnlStageProps.Controls.Add(this.btnStageOk);
            this.pnlStageProps.Controls.Add(this.btnUnacceptAllGroups);
            this.pnlStageProps.Controls.Add(this.lvOtherGroups);
            this.pnlStageProps.Controls.Add(this.lvAcceptedGroups);
            this.pnlStageProps.Controls.Add(this.label5);
            this.pnlStageProps.Location = new System.Drawing.Point(969, 3);
            this.pnlStageProps.Name = "pnlStageProps";
            this.pnlStageProps.Size = new System.Drawing.Size(316, 316);
            this.pnlStageProps.TabIndex = 40;
            this.pnlStageProps.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Сокращение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Недопущенные группы";
            // 
            // tbStageShortname
            // 
            this.tbStageShortname.Location = new System.Drawing.Point(82, 29);
            this.tbStageShortname.Name = "tbStageShortname";
            this.tbStageShortname.Size = new System.Drawing.Size(224, 20);
            this.tbStageShortname.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Название";
            // 
            // btnAcceptGroup
            // 
            this.btnAcceptGroup.Location = new System.Drawing.Point(127, 219);
            this.btnAcceptGroup.Name = "btnAcceptGroup";
            this.btnAcceptGroup.Size = new System.Drawing.Size(63, 29);
            this.btnAcceptGroup.TabIndex = 39;
            this.btnAcceptGroup.Text = ">>";
            this.btnAcceptGroup.UseVisualStyleBackColor = true;
            this.btnAcceptGroup.Click += new System.EventHandler(this.btnAcceptGroup_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button6.Location = new System.Drawing.Point(238, 289);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 24);
            this.button6.TabIndex = 13;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnUnacceptGroup
            // 
            this.btnUnacceptGroup.Location = new System.Drawing.Point(127, 132);
            this.btnUnacceptGroup.Name = "btnUnacceptGroup";
            this.btnUnacceptGroup.Size = new System.Drawing.Size(63, 29);
            this.btnUnacceptGroup.TabIndex = 38;
            this.btnUnacceptGroup.Text = "<<";
            this.btnUnacceptGroup.UseVisualStyleBackColor = true;
            this.btnUnacceptGroup.Click += new System.EventHandler(this.btnUnacceptGroup_Click);
            // 
            // tbStageName
            // 
            this.tbStageName.Location = new System.Drawing.Point(82, 3);
            this.tbStageName.Name = "tbStageName";
            this.tbStageName.Size = new System.Drawing.Size(224, 20);
            this.tbStageName.TabIndex = 24;
            // 
            // btnAcceptAllGroups
            // 
            this.btnAcceptAllGroups.Location = new System.Drawing.Point(127, 254);
            this.btnAcceptAllGroups.Name = "btnAcceptAllGroups";
            this.btnAcceptAllGroups.Size = new System.Drawing.Size(63, 29);
            this.btnAcceptAllGroups.TabIndex = 37;
            this.btnAcceptAllGroups.Text = ">> |";
            this.btnAcceptAllGroups.UseVisualStyleBackColor = true;
            this.btnAcceptAllGroups.Click += new System.EventHandler(this.btnAcceptAllGroups_Click);
            // 
            // btnStageOk
            // 
            this.btnStageOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStageOk.Location = new System.Drawing.Point(3, 290);
            this.btnStageOk.Name = "btnStageOk";
            this.btnStageOk.Size = new System.Drawing.Size(75, 23);
            this.btnStageOk.TabIndex = 12;
            this.btnStageOk.Text = "OK";
            this.btnStageOk.UseVisualStyleBackColor = true;
            this.btnStageOk.Click += new System.EventHandler(this.btnStageOk_Click);
            // 
            // btnUnacceptAllGroups
            // 
            this.btnUnacceptAllGroups.Location = new System.Drawing.Point(127, 97);
            this.btnUnacceptAllGroups.Name = "btnUnacceptAllGroups";
            this.btnUnacceptAllGroups.Size = new System.Drawing.Size(63, 29);
            this.btnUnacceptAllGroups.TabIndex = 36;
            this.btnUnacceptAllGroups.Text = "| <<";
            this.btnUnacceptAllGroups.UseVisualStyleBackColor = true;
            this.btnUnacceptAllGroups.Click += new System.EventHandler(this.btnUnacceptAllGroups_Click);
            // 
            // lvOtherGroups
            // 
            this.lvOtherGroups.FormattingEnabled = true;
            this.lvOtherGroups.Location = new System.Drawing.Point(8, 97);
            this.lvOtherGroups.Name = "lvOtherGroups";
            this.lvOtherGroups.Size = new System.Drawing.Size(113, 186);
            this.lvOtherGroups.TabIndex = 33;
            // 
            // lvAcceptedGroups
            // 
            this.lvAcceptedGroups.FormattingEnabled = true;
            this.lvAcceptedGroups.Location = new System.Drawing.Point(196, 97);
            this.lvAcceptedGroups.Name = "lvAcceptedGroups";
            this.lvAcceptedGroups.Size = new System.Drawing.Size(113, 186);
            this.lvAcceptedGroups.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Допущенные группы";
            // 
            // pnlSceneProps
            // 
            this.pnlSceneProps.Controls.Add(this.label7);
            this.pnlSceneProps.Controls.Add(this.tbSceneCoach);
            this.pnlSceneProps.Controls.Add(this.cmbSceneStage);
            this.pnlSceneProps.Controls.Add(this.lbDescription);
            this.pnlSceneProps.Controls.Add(this.lbName);
            this.pnlSceneProps.Controls.Add(this.tbSceneNumber);
            this.pnlSceneProps.Controls.Add(this.button3);
            this.pnlSceneProps.Controls.Add(this.btnSceneOk);
            this.pnlSceneProps.Location = new System.Drawing.Point(647, 3);
            this.pnlSceneProps.Name = "pnlSceneProps";
            this.pnlSceneProps.Size = new System.Drawing.Size(316, 316);
            this.pnlSceneProps.TabIndex = 26;
            this.pnlSceneProps.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Этап";
            // 
            // tbSceneCoach
            // 
            this.tbSceneCoach.Location = new System.Drawing.Point(80, 55);
            this.tbSceneCoach.Name = "tbSceneCoach";
            this.tbSceneCoach.Size = new System.Drawing.Size(229, 20);
            this.tbSceneCoach.TabIndex = 40;
            // 
            // cmbSceneStage
            // 
            this.cmbSceneStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSceneStage.FormattingEnabled = true;
            this.cmbSceneStage.Location = new System.Drawing.Point(80, 29);
            this.cmbSceneStage.Name = "cmbSceneStage";
            this.cmbSceneStage.Size = new System.Drawing.Size(229, 21);
            this.cmbSceneStage.TabIndex = 24;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(8, 58);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(66, 13);
            this.lbDescription.TabIndex = 28;
            this.lbDescription.Text = "Инструктор";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(33, 8);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 13);
            this.lbName.TabIndex = 27;
            this.lbName.Text = "Номер";
            // 
            // tbSceneNumber
            // 
            this.tbSceneNumber.Location = new System.Drawing.Point(80, 3);
            this.tbSceneNumber.Name = "tbSceneNumber";
            this.tbSceneNumber.Size = new System.Drawing.Size(229, 20);
            this.tbSceneNumber.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(238, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnSceneOk
            // 
            this.btnSceneOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSceneOk.Location = new System.Drawing.Point(3, 290);
            this.btnSceneOk.Name = "btnSceneOk";
            this.btnSceneOk.Size = new System.Drawing.Size(75, 23);
            this.btnSceneOk.TabIndex = 12;
            this.btnSceneOk.Text = "OK";
            this.btnSceneOk.UseVisualStyleBackColor = true;
            this.btnSceneOk.Click += new System.EventHandler(this.btnSceneOk_Click);
            // 
            // pnlGroupProps
            // 
            this.pnlGroupProps.Controls.Add(this.label6);
            this.pnlGroupProps.Controls.Add(this.tbGroupShortName);
            this.pnlGroupProps.Controls.Add(this.label2);
            this.pnlGroupProps.Controls.Add(this.button1);
            this.pnlGroupProps.Controls.Add(this.tbGroupName);
            this.pnlGroupProps.Controls.Add(this.btnGroupOk);
            this.pnlGroupProps.Location = new System.Drawing.Point(325, 3);
            this.pnlGroupProps.Name = "pnlGroupProps";
            this.pnlGroupProps.Size = new System.Drawing.Size(316, 316);
            this.pnlGroupProps.TabIndex = 2;
            this.pnlGroupProps.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Сокращение";
            // 
            // tbGroupShortName
            // 
            this.tbGroupShortName.Location = new System.Drawing.Point(82, 29);
            this.tbGroupShortName.Name = "tbGroupShortName";
            this.tbGroupShortName.Size = new System.Drawing.Size(224, 20);
            this.tbGroupShortName.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Название";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(238, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(82, 3);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(224, 20);
            this.tbGroupName.TabIndex = 24;
            // 
            // btnGroupOk
            // 
            this.btnGroupOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroupOk.Location = new System.Drawing.Point(3, 290);
            this.btnGroupOk.Name = "btnGroupOk";
            this.btnGroupOk.Size = new System.Drawing.Size(75, 23);
            this.btnGroupOk.TabIndex = 12;
            this.btnGroupOk.Text = "OK";
            this.btnGroupOk.UseVisualStyleBackColor = true;
            this.btnGroupOk.Click += new System.EventHandler(this.btnGroupOk_Click);
            // 
            // pnlTeamProps
            // 
            this.pnlTeamProps.Controls.Add(this.btnAuto);
            this.pnlTeamProps.Controls.Add(this.btnStageComplete);
            this.pnlTeamProps.Controls.Add(this.btnStageIncomplete);
            this.pnlTeamProps.Controls.Add(this.btnStagePass);
            this.pnlTeamProps.Controls.Add(this.dgvStages);
            this.pnlTeamProps.Controls.Add(this.label3);
            this.pnlTeamProps.Controls.Add(this.cmbTeamGroup);
            this.pnlTeamProps.Controls.Add(this.btnCancel);
            this.pnlTeamProps.Controls.Add(this.btnTeamOk);
            this.pnlTeamProps.Controls.Add(this.label1);
            this.pnlTeamProps.Controls.Add(this.tbTeamName);
            this.pnlTeamProps.Location = new System.Drawing.Point(3, 3);
            this.pnlTeamProps.Name = "pnlTeamProps";
            this.pnlTeamProps.Size = new System.Drawing.Size(316, 316);
            this.pnlTeamProps.TabIndex = 1;
            this.pnlTeamProps.Visible = false;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(272, 228);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(34, 23);
            this.btnAuto.TabIndex = 23;
            this.btnAuto.Text = "A";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnStageComplete
            // 
            this.btnStageComplete.Location = new System.Drawing.Point(184, 228);
            this.btnStageComplete.Name = "btnStageComplete";
            this.btnStageComplete.Size = new System.Drawing.Size(81, 23);
            this.btnStageComplete.TabIndex = 22;
            this.btnStageComplete.Text = "Пройдено";
            this.btnStageComplete.UseVisualStyleBackColor = true;
            this.btnStageComplete.Click += new System.EventHandler(this.btnStageComplete_Click);
            // 
            // btnStageIncomplete
            // 
            this.btnStageIncomplete.Location = new System.Drawing.Point(97, 228);
            this.btnStageIncomplete.Name = "btnStageIncomplete";
            this.btnStageIncomplete.Size = new System.Drawing.Size(81, 23);
            this.btnStageIncomplete.TabIndex = 21;
            this.btnStageIncomplete.Text = "Не пройдено";
            this.btnStageIncomplete.UseVisualStyleBackColor = true;
            this.btnStageIncomplete.Click += new System.EventHandler(this.btnStageIncomplete_Click);
            // 
            // btnStagePass
            // 
            this.btnStagePass.Location = new System.Drawing.Point(10, 228);
            this.btnStagePass.Name = "btnStagePass";
            this.btnStagePass.Size = new System.Drawing.Size(81, 23);
            this.btnStagePass.TabIndex = 20;
            this.btnStagePass.Text = "Пропустить";
            this.btnStagePass.UseVisualStyleBackColor = true;
            this.btnStagePass.Click += new System.EventHandler(this.btnStagePass_Click);
            // 
            // dgvStages
            // 
            this.dgvStages.AllowUserToAddRows = false;
            this.dgvStages.AllowUserToDeleteRows = false;
            this.dgvStages.AllowUserToResizeColumns = false;
            this.dgvStages.AllowUserToResizeRows = false;
            this.dgvStages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clStage,
            this.clUsage});
            this.dgvStages.Location = new System.Drawing.Point(10, 72);
            this.dgvStages.MultiSelect = false;
            this.dgvStages.Name = "dgvStages";
            this.dgvStages.RowHeadersVisible = false;
            this.dgvStages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStages.Size = new System.Drawing.Size(296, 150);
            this.dgvStages.TabIndex = 19;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Группа";
            // 
            // cmbTeamGroup
            // 
            this.cmbTeamGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamGroup.FormattingEnabled = true;
            this.cmbTeamGroup.Location = new System.Drawing.Point(68, 29);
            this.cmbTeamGroup.Name = "cmbTeamGroup";
            this.cmbTeamGroup.Size = new System.Drawing.Size(238, 21);
            this.cmbTeamGroup.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnTeamOk
            // 
            this.btnTeamOk.Location = new System.Drawing.Point(5, 291);
            this.btnTeamOk.Name = "btnTeamOk";
            this.btnTeamOk.Size = new System.Drawing.Size(75, 23);
            this.btnTeamOk.TabIndex = 15;
            this.btnTeamOk.Text = "OK";
            this.btnTeamOk.UseVisualStyleBackColor = true;
            this.btnTeamOk.Click += new System.EventHandler(this.btnTeamOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Название";
            // 
            // tbTeamName
            // 
            this.tbTeamName.Location = new System.Drawing.Point(68, 3);
            this.tbTeamName.Name = "tbTeamName";
            this.tbTeamName.Size = new System.Drawing.Size(238, 20);
            this.tbTeamName.TabIndex = 13;
            // 
            // tvList
            // 
            this.tvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvList.Location = new System.Drawing.Point(6, 6);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(400, 470);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            this.tvList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvList_NodeMouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 532);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "-= autoname =-";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.tpLists.ResumeLayout(false);
            this.pnlProps.ResumeLayout(false);
            this.pnlStageProps.ResumeLayout(false);
            this.pnlStageProps.PerformLayout();
            this.pnlSceneProps.ResumeLayout(false);
            this.pnlSceneProps.PerformLayout();
            this.pnlGroupProps.ResumeLayout(false);
            this.pnlGroupProps.PerformLayout();
            this.pnlTeamProps.ResumeLayout(false);
            this.pnlTeamProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miCreate;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpLists;
        private System.Windows.Forms.TabPage tpGrid;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.Panel pnlProps;
        private System.Windows.Forms.Panel pnlTeamProps;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnStageComplete;
        private System.Windows.Forms.Button btnStageIncomplete;
        private System.Windows.Forms.Button btnStagePass;
        private System.Windows.Forms.DataGridView dgvStages;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTeamGroup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTeamOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTeamName;
        private System.Windows.Forms.Panel pnlGroupProps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Button btnGroupOk;
        private System.Windows.Forms.Panel pnlSceneProps;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSceneOk;
        private System.Windows.Forms.Panel pnlStageProps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAcceptGroup;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnUnacceptGroup;
        private System.Windows.Forms.TextBox tbStageName;
        private System.Windows.Forms.Button btnAcceptAllGroups;
        private System.Windows.Forms.Button btnStageOk;
        private System.Windows.Forms.Button btnUnacceptAllGroups;
        private System.Windows.Forms.ListBox lvOtherGroups;
        private System.Windows.Forms.ListBox lvAcceptedGroups;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSceneCoach;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbSceneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbGroupShortName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSceneStage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbStageShortname;
    }
}

