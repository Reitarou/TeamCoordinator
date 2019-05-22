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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeTextSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTimerSwitcher = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpGrid = new System.Windows.Forms.TabPage();
            this.scGridTabSplitter = new System.Windows.Forms.SplitContainer();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tpLists = new System.Windows.Forms.TabPage();
            this.tvList = new System.Windows.Forms.TreeView();
            this.pnlProps = new System.Windows.Forms.Panel();
            this.pnlSceneProps = new System.Windows.Forms.Panel();
            this.lbSceneStage = new System.Windows.Forms.Label();
            this.tbSceneCoach = new System.Windows.Forms.TextBox();
            this.cmbSceneStage = new System.Windows.Forms.ComboBox();
            this.lbSceneCoach = new System.Windows.Forms.Label();
            this.lbSceneName = new System.Windows.Forms.Label();
            this.tbSceneNumber = new System.Windows.Forms.TextBox();
            this.btnSceneCancel = new System.Windows.Forms.Button();
            this.btnSceneOk = new System.Windows.Forms.Button();
            this.pnlTeamProps = new System.Windows.Forms.Panel();
            this.dgvStages = new System.Windows.Forms.DataGridView();
            this.clStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTeamShowLog = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnStageComplete = new System.Windows.Forms.Button();
            this.btnStageIncomplete = new System.Windows.Forms.Button();
            this.btnStagePass = new System.Windows.Forms.Button();
            this.lbTeamGroup = new System.Windows.Forms.Label();
            this.cmbTeamGroup = new System.Windows.Forms.ComboBox();
            this.btnTeamCancel = new System.Windows.Forms.Button();
            this.btnTeamOk = new System.Windows.Forms.Button();
            this.lbTeamName = new System.Windows.Forms.Label();
            this.tbTeamName = new System.Windows.Forms.TextBox();
            this.pnlStageProps = new System.Windows.Forms.Panel();
            this.lbStageShortName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStageShortname = new System.Windows.Forms.TextBox();
            this.lbStageName = new System.Windows.Forms.Label();
            this.btnAcceptGroup = new System.Windows.Forms.Button();
            this.btnStageCancel = new System.Windows.Forms.Button();
            this.btnUnacceptGroup = new System.Windows.Forms.Button();
            this.tbStageName = new System.Windows.Forms.TextBox();
            this.btnAcceptAllGroups = new System.Windows.Forms.Button();
            this.btnStageOk = new System.Windows.Forms.Button();
            this.btnUnacceptAllGroups = new System.Windows.Forms.Button();
            this.lvOtherGroups = new System.Windows.Forms.ListBox();
            this.lvAcceptedGroups = new System.Windows.Forms.ListBox();
            this.lbStageAcceptedGroups = new System.Windows.Forms.Label();
            this.pnlGroupProps = new System.Windows.Forms.Panel();
            this.lbGroupShortName = new System.Windows.Forms.Label();
            this.tbGroupShortName = new System.Windows.Forms.TextBox();
            this.lbGroupName = new System.Windows.Forms.Label();
            this.btnGroupCancel = new System.Windows.Forms.Button();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.btnGroupOk = new System.Windows.Forms.Button();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.изменитьШиринуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpGrid.SuspendLayout();
            this.scGridTabSplitter.Panel1.SuspendLayout();
            this.scGridTabSplitter.Panel2.SuspendLayout();
            this.scGridTabSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.tpLists.SuspendLayout();
            this.pnlProps.SuspendLayout();
            this.pnlSceneProps.SuspendLayout();
            this.pnlTeamProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).BeginInit();
            this.pnlStageProps.SuspendLayout();
            this.pnlGroupProps.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miProperties});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
            this.menuStrip1.TabIndex = 0;
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
            // miProperties
            // 
            this.miProperties.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChangeTextSizeToolStripMenuItem,
            this.изменитьШиринуToolStripMenuItem,
            this.tsmiTimerSwitcher});
            this.miProperties.Name = "miProperties";
            this.miProperties.Size = new System.Drawing.Size(70, 20);
            this.miProperties.Text = "Свойства";
            // 
            // miChangeTextSizeToolStripMenuItem
            // 
            this.miChangeTextSizeToolStripMenuItem.Name = "miChangeTextSizeToolStripMenuItem";
            this.miChangeTextSizeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.miChangeTextSizeToolStripMenuItem.Text = "Изменить шрифт";
            this.miChangeTextSizeToolStripMenuItem.Click += new System.EventHandler(this.miChangeTextSizeToolStripMenuItem_Click);
            // 
            // tsmiTimerSwitcher
            // 
            this.tsmiTimerSwitcher.Name = "tsmiTimerSwitcher";
            this.tsmiTimerSwitcher.Size = new System.Drawing.Size(176, 22);
            this.tsmiTimerSwitcher.Text = "Включить таймер";
            this.tsmiTimerSwitcher.Click += new System.EventHandler(this.tsmiTimerSwitcher_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpGrid);
            this.tabControl.Controls.Add(this.tpLists);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1128, 766);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.scGridTabSplitter);
            this.tpGrid.Location = new System.Drawing.Point(4, 22);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.Size = new System.Drawing.Size(1120, 740);
            this.tpGrid.TabIndex = 2;
            this.tpGrid.Text = "Сетка";
            this.tpGrid.UseVisualStyleBackColor = true;
            // 
            // scGridTabSplitter
            // 
            this.scGridTabSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGridTabSplitter.Location = new System.Drawing.Point(0, 0);
            this.scGridTabSplitter.Name = "scGridTabSplitter";
            // 
            // scGridTabSplitter.Panel1
            // 
            this.scGridTabSplitter.Panel1.Controls.Add(this.dgvGrid);
            // 
            // scGridTabSplitter.Panel2
            // 
            this.scGridTabSplitter.Panel2.Controls.Add(this.lbLog);
            this.scGridTabSplitter.Size = new System.Drawing.Size(1120, 740);
            this.scGridTabSplitter.SplitterDistance = 899;
            this.scGridTabSplitter.TabIndex = 3;
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.AllowUserToResizeColumns = false;
            this.dgvGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.EnableHeadersVisualStyles = false;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGrid.Size = new System.Drawing.Size(899, 740);
            this.dgvGrid.TabIndex = 1;
            this.dgvGrid.SelectionChanged += new System.EventHandler(this.dgvGrid_SelectionChanged);
            this.dgvGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvGrid_MouseClick);
            this.dgvGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGrid_MouseDown);
            this.dgvGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGrid_MouseMove);
            this.dgvGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvGrid_MouseUp);
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 12;
            this.lbLog.Location = new System.Drawing.Point(0, 0);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(217, 740);
            this.lbLog.TabIndex = 2;
            // 
            // tpLists
            // 
            this.tpLists.Controls.Add(this.tvList);
            this.tpLists.Controls.Add(this.pnlProps);
            this.tpLists.Location = new System.Drawing.Point(4, 22);
            this.tpLists.Name = "tpLists";
            this.tpLists.Padding = new System.Windows.Forms.Padding(3);
            this.tpLists.Size = new System.Drawing.Size(1120, 740);
            this.tpLists.TabIndex = 0;
            this.tpLists.Text = "Списки";
            this.tpLists.UseVisualStyleBackColor = true;
            // 
            // tvList
            // 
            this.tvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvList.Location = new System.Drawing.Point(6, 6);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(347, 728);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            this.tvList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvList_NodeMouseClick);
            // 
            // pnlProps
            // 
            this.pnlProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProps.Controls.Add(this.pnlSceneProps);
            this.pnlProps.Controls.Add(this.pnlTeamProps);
            this.pnlProps.Controls.Add(this.pnlStageProps);
            this.pnlProps.Controls.Add(this.pnlGroupProps);
            this.pnlProps.Location = new System.Drawing.Point(359, 6);
            this.pnlProps.Name = "pnlProps";
            this.pnlProps.Size = new System.Drawing.Size(741, 728);
            this.pnlProps.TabIndex = 1;
            // 
            // pnlSceneProps
            // 
            this.pnlSceneProps.Controls.Add(this.lbSceneStage);
            this.pnlSceneProps.Controls.Add(this.tbSceneCoach);
            this.pnlSceneProps.Controls.Add(this.cmbSceneStage);
            this.pnlSceneProps.Controls.Add(this.lbSceneCoach);
            this.pnlSceneProps.Controls.Add(this.lbSceneName);
            this.pnlSceneProps.Controls.Add(this.tbSceneNumber);
            this.pnlSceneProps.Controls.Add(this.btnSceneCancel);
            this.pnlSceneProps.Controls.Add(this.btnSceneOk);
            this.pnlSceneProps.Location = new System.Drawing.Point(345, 331);
            this.pnlSceneProps.Name = "pnlSceneProps";
            this.pnlSceneProps.Size = new System.Drawing.Size(316, 316);
            this.pnlSceneProps.TabIndex = 2;
            this.pnlSceneProps.Visible = false;
            // 
            // lbSceneStage
            // 
            this.lbSceneStage.AutoSize = true;
            this.lbSceneStage.Location = new System.Drawing.Point(43, 32);
            this.lbSceneStage.Name = "lbSceneStage";
            this.lbSceneStage.Size = new System.Drawing.Size(31, 13);
            this.lbSceneStage.TabIndex = 2;
            this.lbSceneStage.Text = "Этап";
            // 
            // tbSceneCoach
            // 
            this.tbSceneCoach.Location = new System.Drawing.Point(80, 55);
            this.tbSceneCoach.Name = "tbSceneCoach";
            this.tbSceneCoach.Size = new System.Drawing.Size(229, 20);
            this.tbSceneCoach.TabIndex = 5;
            // 
            // cmbSceneStage
            // 
            this.cmbSceneStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSceneStage.FormattingEnabled = true;
            this.cmbSceneStage.Location = new System.Drawing.Point(80, 29);
            this.cmbSceneStage.Name = "cmbSceneStage";
            this.cmbSceneStage.Size = new System.Drawing.Size(229, 21);
            this.cmbSceneStage.TabIndex = 3;
            // 
            // lbSceneCoach
            // 
            this.lbSceneCoach.AutoSize = true;
            this.lbSceneCoach.Location = new System.Drawing.Point(8, 58);
            this.lbSceneCoach.Name = "lbSceneCoach";
            this.lbSceneCoach.Size = new System.Drawing.Size(66, 13);
            this.lbSceneCoach.TabIndex = 4;
            this.lbSceneCoach.Text = "Инструктор";
            // 
            // lbSceneName
            // 
            this.lbSceneName.AutoSize = true;
            this.lbSceneName.Location = new System.Drawing.Point(33, 8);
            this.lbSceneName.Name = "lbSceneName";
            this.lbSceneName.Size = new System.Drawing.Size(41, 13);
            this.lbSceneName.TabIndex = 0;
            this.lbSceneName.Text = "Номер";
            // 
            // tbSceneNumber
            // 
            this.tbSceneNumber.Location = new System.Drawing.Point(80, 3);
            this.tbSceneNumber.Name = "tbSceneNumber";
            this.tbSceneNumber.Size = new System.Drawing.Size(229, 20);
            this.tbSceneNumber.TabIndex = 1;
            // 
            // btnSceneCancel
            // 
            this.btnSceneCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSceneCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSceneCancel.Location = new System.Drawing.Point(238, 289);
            this.btnSceneCancel.Name = "btnSceneCancel";
            this.btnSceneCancel.Size = new System.Drawing.Size(75, 24);
            this.btnSceneCancel.TabIndex = 7;
            this.btnSceneCancel.Text = "Cancel";
            this.btnSceneCancel.UseVisualStyleBackColor = true;
            // 
            // btnSceneOk
            // 
            this.btnSceneOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSceneOk.Location = new System.Drawing.Point(3, 290);
            this.btnSceneOk.Name = "btnSceneOk";
            this.btnSceneOk.Size = new System.Drawing.Size(75, 23);
            this.btnSceneOk.TabIndex = 6;
            this.btnSceneOk.Text = "OK";
            this.btnSceneOk.UseVisualStyleBackColor = true;
            this.btnSceneOk.Click += new System.EventHandler(this.btnSceneOk_Click);
            // 
            // pnlTeamProps
            // 
            this.pnlTeamProps.Controls.Add(this.dgvStages);
            this.pnlTeamProps.Controls.Add(this.btnTeamShowLog);
            this.pnlTeamProps.Controls.Add(this.btnAuto);
            this.pnlTeamProps.Controls.Add(this.btnStageComplete);
            this.pnlTeamProps.Controls.Add(this.btnStageIncomplete);
            this.pnlTeamProps.Controls.Add(this.btnStagePass);
            this.pnlTeamProps.Controls.Add(this.lbTeamGroup);
            this.pnlTeamProps.Controls.Add(this.cmbTeamGroup);
            this.pnlTeamProps.Controls.Add(this.btnTeamCancel);
            this.pnlTeamProps.Controls.Add(this.btnTeamOk);
            this.pnlTeamProps.Controls.Add(this.lbTeamName);
            this.pnlTeamProps.Controls.Add(this.tbTeamName);
            this.pnlTeamProps.Location = new System.Drawing.Point(345, 3);
            this.pnlTeamProps.Name = "pnlTeamProps";
            this.pnlTeamProps.Size = new System.Drawing.Size(316, 316);
            this.pnlTeamProps.TabIndex = 0;
            this.pnlTeamProps.Visible = false;
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
            this.dgvStages.TabIndex = 4;
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
            // btnTeamShowLog
            // 
            this.btnTeamShowLog.Location = new System.Drawing.Point(86, 290);
            this.btnTeamShowLog.Name = "btnTeamShowLog";
            this.btnTeamShowLog.Size = new System.Drawing.Size(139, 24);
            this.btnTeamShowLog.TabIndex = 10;
            this.btnTeamShowLog.Text = "Показать лог";
            this.btnTeamShowLog.UseVisualStyleBackColor = true;
            this.btnTeamShowLog.Click += new System.EventHandler(this.btnTeamShowLog_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(272, 228);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(34, 23);
            this.btnAuto.TabIndex = 8;
            this.btnAuto.Text = "A";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnStageComplete
            // 
            this.btnStageComplete.Location = new System.Drawing.Point(184, 228);
            this.btnStageComplete.Name = "btnStageComplete";
            this.btnStageComplete.Size = new System.Drawing.Size(81, 23);
            this.btnStageComplete.TabIndex = 7;
            this.btnStageComplete.Text = "Пройдено";
            this.btnStageComplete.UseVisualStyleBackColor = true;
            this.btnStageComplete.Click += new System.EventHandler(this.btnStageComplete_Click);
            // 
            // btnStageIncomplete
            // 
            this.btnStageIncomplete.Location = new System.Drawing.Point(97, 228);
            this.btnStageIncomplete.Name = "btnStageIncomplete";
            this.btnStageIncomplete.Size = new System.Drawing.Size(81, 23);
            this.btnStageIncomplete.TabIndex = 6;
            this.btnStageIncomplete.Text = "Не пройдено";
            this.btnStageIncomplete.UseVisualStyleBackColor = true;
            this.btnStageIncomplete.Click += new System.EventHandler(this.btnStageIncomplete_Click);
            // 
            // btnStagePass
            // 
            this.btnStagePass.Location = new System.Drawing.Point(10, 228);
            this.btnStagePass.Name = "btnStagePass";
            this.btnStagePass.Size = new System.Drawing.Size(81, 23);
            this.btnStagePass.TabIndex = 5;
            this.btnStagePass.Text = "Пропустить";
            this.btnStagePass.UseVisualStyleBackColor = true;
            this.btnStagePass.Click += new System.EventHandler(this.btnStagePass_Click);
            // 
            // lbTeamGroup
            // 
            this.lbTeamGroup.AutoSize = true;
            this.lbTeamGroup.Location = new System.Drawing.Point(5, 32);
            this.lbTeamGroup.Name = "lbTeamGroup";
            this.lbTeamGroup.Size = new System.Drawing.Size(42, 13);
            this.lbTeamGroup.TabIndex = 2;
            this.lbTeamGroup.Text = "Группа";
            // 
            // cmbTeamGroup
            // 
            this.cmbTeamGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamGroup.FormattingEnabled = true;
            this.cmbTeamGroup.Location = new System.Drawing.Point(68, 29);
            this.cmbTeamGroup.Name = "cmbTeamGroup";
            this.cmbTeamGroup.Size = new System.Drawing.Size(238, 21);
            this.cmbTeamGroup.TabIndex = 3;
            this.cmbTeamGroup.SelectedIndexChanged += new System.EventHandler(this.cmbTeamGroup_SelectedIndexChanged);
            // 
            // btnTeamCancel
            // 
            this.btnTeamCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTeamCancel.Location = new System.Drawing.Point(231, 290);
            this.btnTeamCancel.Name = "btnTeamCancel";
            this.btnTeamCancel.Size = new System.Drawing.Size(75, 24);
            this.btnTeamCancel.TabIndex = 11;
            this.btnTeamCancel.Text = "Cancel";
            this.btnTeamCancel.UseVisualStyleBackColor = true;
            // 
            // btnTeamOk
            // 
            this.btnTeamOk.Location = new System.Drawing.Point(5, 291);
            this.btnTeamOk.Name = "btnTeamOk";
            this.btnTeamOk.Size = new System.Drawing.Size(75, 23);
            this.btnTeamOk.TabIndex = 9;
            this.btnTeamOk.Text = "OK";
            this.btnTeamOk.UseVisualStyleBackColor = true;
            this.btnTeamOk.Click += new System.EventHandler(this.btnTeamOk_Click);
            // 
            // lbTeamName
            // 
            this.lbTeamName.AutoSize = true;
            this.lbTeamName.Location = new System.Drawing.Point(5, 6);
            this.lbTeamName.Name = "lbTeamName";
            this.lbTeamName.Size = new System.Drawing.Size(57, 13);
            this.lbTeamName.TabIndex = 0;
            this.lbTeamName.Text = "Название";
            // 
            // tbTeamName
            // 
            this.tbTeamName.Location = new System.Drawing.Point(68, 3);
            this.tbTeamName.Name = "tbTeamName";
            this.tbTeamName.Size = new System.Drawing.Size(238, 20);
            this.tbTeamName.TabIndex = 1;
            // 
            // pnlStageProps
            // 
            this.pnlStageProps.Controls.Add(this.lbStageShortName);
            this.pnlStageProps.Controls.Add(this.label8);
            this.pnlStageProps.Controls.Add(this.tbStageShortname);
            this.pnlStageProps.Controls.Add(this.lbStageName);
            this.pnlStageProps.Controls.Add(this.btnAcceptGroup);
            this.pnlStageProps.Controls.Add(this.btnStageCancel);
            this.pnlStageProps.Controls.Add(this.btnUnacceptGroup);
            this.pnlStageProps.Controls.Add(this.tbStageName);
            this.pnlStageProps.Controls.Add(this.btnAcceptAllGroups);
            this.pnlStageProps.Controls.Add(this.btnStageOk);
            this.pnlStageProps.Controls.Add(this.btnUnacceptAllGroups);
            this.pnlStageProps.Controls.Add(this.lvOtherGroups);
            this.pnlStageProps.Controls.Add(this.lvAcceptedGroups);
            this.pnlStageProps.Controls.Add(this.lbStageAcceptedGroups);
            this.pnlStageProps.Location = new System.Drawing.Point(8, 331);
            this.pnlStageProps.Name = "pnlStageProps";
            this.pnlStageProps.Size = new System.Drawing.Size(316, 316);
            this.pnlStageProps.TabIndex = 3;
            this.pnlStageProps.Visible = false;
            // 
            // lbStageShortName
            // 
            this.lbStageShortName.AutoSize = true;
            this.lbStageShortName.Location = new System.Drawing.Point(5, 32);
            this.lbStageShortName.Name = "lbStageShortName";
            this.lbStageShortName.Size = new System.Drawing.Size(71, 13);
            this.lbStageShortName.TabIndex = 2;
            this.lbStageShortName.Text = "Сокращение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Недопущенные группы";
            // 
            // tbStageShortname
            // 
            this.tbStageShortname.Location = new System.Drawing.Point(82, 29);
            this.tbStageShortname.Name = "tbStageShortname";
            this.tbStageShortname.Size = new System.Drawing.Size(224, 20);
            this.tbStageShortname.TabIndex = 3;
            // 
            // lbStageName
            // 
            this.lbStageName.AutoSize = true;
            this.lbStageName.Location = new System.Drawing.Point(5, 6);
            this.lbStageName.Name = "lbStageName";
            this.lbStageName.Size = new System.Drawing.Size(57, 13);
            this.lbStageName.TabIndex = 0;
            this.lbStageName.Text = "Название";
            // 
            // btnAcceptGroup
            // 
            this.btnAcceptGroup.Location = new System.Drawing.Point(127, 219);
            this.btnAcceptGroup.Name = "btnAcceptGroup";
            this.btnAcceptGroup.Size = new System.Drawing.Size(63, 29);
            this.btnAcceptGroup.TabIndex = 10;
            this.btnAcceptGroup.Text = ">>";
            this.btnAcceptGroup.UseVisualStyleBackColor = true;
            this.btnAcceptGroup.Click += new System.EventHandler(this.btnAcceptGroup_Click);
            // 
            // btnStageCancel
            // 
            this.btnStageCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStageCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStageCancel.Location = new System.Drawing.Point(238, 289);
            this.btnStageCancel.Name = "btnStageCancel";
            this.btnStageCancel.Size = new System.Drawing.Size(75, 24);
            this.btnStageCancel.TabIndex = 13;
            this.btnStageCancel.Text = "Cancel";
            this.btnStageCancel.UseVisualStyleBackColor = true;
            // 
            // btnUnacceptGroup
            // 
            this.btnUnacceptGroup.Location = new System.Drawing.Point(127, 132);
            this.btnUnacceptGroup.Name = "btnUnacceptGroup";
            this.btnUnacceptGroup.Size = new System.Drawing.Size(63, 29);
            this.btnUnacceptGroup.TabIndex = 9;
            this.btnUnacceptGroup.Text = "<<";
            this.btnUnacceptGroup.UseVisualStyleBackColor = true;
            this.btnUnacceptGroup.Click += new System.EventHandler(this.btnUnacceptGroup_Click);
            // 
            // tbStageName
            // 
            this.tbStageName.Location = new System.Drawing.Point(82, 3);
            this.tbStageName.Name = "tbStageName";
            this.tbStageName.Size = new System.Drawing.Size(224, 20);
            this.tbStageName.TabIndex = 1;
            // 
            // btnAcceptAllGroups
            // 
            this.btnAcceptAllGroups.Location = new System.Drawing.Point(127, 254);
            this.btnAcceptAllGroups.Name = "btnAcceptAllGroups";
            this.btnAcceptAllGroups.Size = new System.Drawing.Size(63, 29);
            this.btnAcceptAllGroups.TabIndex = 11;
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
            this.btnUnacceptAllGroups.TabIndex = 8;
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
            this.lvOtherGroups.TabIndex = 5;
            // 
            // lvAcceptedGroups
            // 
            this.lvAcceptedGroups.FormattingEnabled = true;
            this.lvAcceptedGroups.Location = new System.Drawing.Point(196, 97);
            this.lvAcceptedGroups.Name = "lvAcceptedGroups";
            this.lvAcceptedGroups.Size = new System.Drawing.Size(113, 186);
            this.lvAcceptedGroups.TabIndex = 7;
            // 
            // lbStageAcceptedGroups
            // 
            this.lbStageAcceptedGroups.AutoSize = true;
            this.lbStageAcceptedGroups.Location = new System.Drawing.Point(193, 81);
            this.lbStageAcceptedGroups.Name = "lbStageAcceptedGroups";
            this.lbStageAcceptedGroups.Size = new System.Drawing.Size(113, 13);
            this.lbStageAcceptedGroups.TabIndex = 6;
            this.lbStageAcceptedGroups.Text = "Допущенные группы";
            // 
            // pnlGroupProps
            // 
            this.pnlGroupProps.Controls.Add(this.lbGroupShortName);
            this.pnlGroupProps.Controls.Add(this.tbGroupShortName);
            this.pnlGroupProps.Controls.Add(this.lbGroupName);
            this.pnlGroupProps.Controls.Add(this.btnGroupCancel);
            this.pnlGroupProps.Controls.Add(this.tbGroupName);
            this.pnlGroupProps.Controls.Add(this.btnGroupOk);
            this.pnlGroupProps.Location = new System.Drawing.Point(8, 3);
            this.pnlGroupProps.Name = "pnlGroupProps";
            this.pnlGroupProps.Size = new System.Drawing.Size(316, 313);
            this.pnlGroupProps.TabIndex = 1;
            this.pnlGroupProps.Visible = false;
            // 
            // lbGroupShortName
            // 
            this.lbGroupShortName.AutoSize = true;
            this.lbGroupShortName.Location = new System.Drawing.Point(5, 32);
            this.lbGroupShortName.Name = "lbGroupShortName";
            this.lbGroupShortName.Size = new System.Drawing.Size(71, 13);
            this.lbGroupShortName.TabIndex = 2;
            this.lbGroupShortName.Text = "Сокращение";
            // 
            // tbGroupShortName
            // 
            this.tbGroupShortName.Location = new System.Drawing.Point(82, 29);
            this.tbGroupShortName.Name = "tbGroupShortName";
            this.tbGroupShortName.Size = new System.Drawing.Size(224, 20);
            this.tbGroupShortName.TabIndex = 3;
            // 
            // lbGroupName
            // 
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.Location = new System.Drawing.Point(5, 6);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(57, 13);
            this.lbGroupName.TabIndex = 0;
            this.lbGroupName.Text = "Название";
            // 
            // btnGroupCancel
            // 
            this.btnGroupCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGroupCancel.Location = new System.Drawing.Point(238, 286);
            this.btnGroupCancel.Name = "btnGroupCancel";
            this.btnGroupCancel.Size = new System.Drawing.Size(75, 24);
            this.btnGroupCancel.TabIndex = 5;
            this.btnGroupCancel.Text = "Cancel";
            this.btnGroupCancel.UseVisualStyleBackColor = true;
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(82, 3);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(224, 20);
            this.tbGroupName.TabIndex = 1;
            // 
            // btnGroupOk
            // 
            this.btnGroupOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroupOk.Location = new System.Drawing.Point(3, 287);
            this.btnGroupOk.Name = "btnGroupOk";
            this.btnGroupOk.Size = new System.Drawing.Size(75, 23);
            this.btnGroupOk.TabIndex = 4;
            this.btnGroupOk.Text = "OK";
            this.btnGroupOk.UseVisualStyleBackColor = true;
            this.btnGroupOk.Click += new System.EventHandler(this.btnGroupOk_Click);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 500;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // изменитьШиринуToolStripMenuItem
            // 
            this.изменитьШиринуToolStripMenuItem.Name = "изменитьШиринуToolStripMenuItem";
            this.изменитьШиринуToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.изменитьШиринуToolStripMenuItem.Text = "Изменить ширину";
            this.изменитьШиринуToolStripMenuItem.Click += new System.EventHandler(this.изменитьШиринуToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 790);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "-= autoname =-";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpGrid.ResumeLayout(false);
            this.scGridTabSplitter.Panel1.ResumeLayout(false);
            this.scGridTabSplitter.Panel2.ResumeLayout(false);
            this.scGridTabSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.tpLists.ResumeLayout(false);
            this.pnlProps.ResumeLayout(false);
            this.pnlSceneProps.ResumeLayout(false);
            this.pnlSceneProps.PerformLayout();
            this.pnlTeamProps.ResumeLayout(false);
            this.pnlTeamProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStages)).EndInit();
            this.pnlStageProps.ResumeLayout(false);
            this.pnlStageProps.PerformLayout();
            this.pnlGroupProps.ResumeLayout(false);
            this.pnlGroupProps.PerformLayout();
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
        private System.Windows.Forms.Label lbTeamGroup;
        private System.Windows.Forms.ComboBox cmbTeamGroup;
        private System.Windows.Forms.Button btnTeamCancel;
        private System.Windows.Forms.Button btnTeamOk;
        private System.Windows.Forms.Label lbTeamName;
        private System.Windows.Forms.TextBox tbTeamName;
        private System.Windows.Forms.Panel pnlGroupProps;
        private System.Windows.Forms.Label lbGroupName;
        private System.Windows.Forms.Button btnGroupCancel;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Button btnGroupOk;
        private System.Windows.Forms.Panel pnlSceneProps;
        private System.Windows.Forms.Button btnSceneCancel;
        private System.Windows.Forms.Button btnSceneOk;
        private System.Windows.Forms.Panel pnlStageProps;
        private System.Windows.Forms.Label lbStageName;
        private System.Windows.Forms.Button btnAcceptGroup;
        private System.Windows.Forms.Button btnStageCancel;
        private System.Windows.Forms.Button btnUnacceptGroup;
        private System.Windows.Forms.TextBox tbStageName;
        private System.Windows.Forms.Button btnAcceptAllGroups;
        private System.Windows.Forms.Button btnStageOk;
        private System.Windows.Forms.Button btnUnacceptAllGroups;
        private System.Windows.Forms.ListBox lvOtherGroups;
        private System.Windows.Forms.ListBox lvAcceptedGroups;
        private System.Windows.Forms.Label lbStageAcceptedGroups;
        private System.Windows.Forms.TextBox tbSceneCoach;
        private System.Windows.Forms.Label lbSceneCoach;
        private System.Windows.Forms.Label lbSceneName;
        private System.Windows.Forms.TextBox tbSceneNumber;
        private System.Windows.Forms.Label lbGroupShortName;
        private System.Windows.Forms.TextBox tbGroupShortName;
        private System.Windows.Forms.Label lbSceneStage;
        private System.Windows.Forms.ComboBox cmbSceneStage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbStageShortName;
        private System.Windows.Forms.TextBox tbStageShortname;
        private System.Windows.Forms.Button btnTeamShowLog;
        private System.Windows.Forms.ToolStripMenuItem miProperties;
        private System.Windows.Forms.ToolStripMenuItem miChangeTextSizeToolStripMenuItem;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.SplitContainer scGridTabSplitter;
        private System.Windows.Forms.ToolStripMenuItem tsmiTimerSwitcher;
        private System.Windows.Forms.ToolStripMenuItem изменитьШиринуToolStripMenuItem;
    }
}

