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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSceneProps = new System.Windows.Forms.Panel();
            this.tbCoach = new System.Windows.Forms.TextBox();
            this.lbCall = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlGroupProps = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlTeamProps = new System.Windows.Forms.Panel();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnStageComplete = new System.Windows.Forms.Button();
            this.btnStageIncomplete = new System.Windows.Forms.Button();
            this.btnStagePass = new System.Windows.Forms.Button();
            this.dgvStages = new System.Windows.Forms.DataGridView();
            this.clStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.vScrollBarProps = new System.Windows.Forms.VScrollBar();
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
            this.menuStrip1.Size = new System.Drawing.Size(1650, 24);
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
            this.tabControl.Size = new System.Drawing.Size(1650, 432);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.dgvGrid);
            this.tpGrid.Location = new System.Drawing.Point(4, 22);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.Size = new System.Drawing.Size(1642, 406);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.EnableHeadersVisualStyles = false;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGrid.Size = new System.Drawing.Size(1642, 406);
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
            this.tpLists.Size = new System.Drawing.Size(1642, 406);
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
            this.pnlProps.Controls.Add(this.vScrollBarProps);
            this.pnlProps.Location = new System.Drawing.Point(292, 3);
            this.pnlProps.Name = "pnlProps";
            this.pnlProps.Size = new System.Drawing.Size(1342, 395);
            this.pnlProps.TabIndex = 1;
            // 
            // pnlStageProps
            // 
            this.pnlStageProps.Controls.Add(this.label4);
            this.pnlStageProps.Controls.Add(this.button5);
            this.pnlStageProps.Controls.Add(this.button6);
            this.pnlStageProps.Controls.Add(this.button7);
            this.pnlStageProps.Controls.Add(this.textBox2);
            this.pnlStageProps.Controls.Add(this.button8);
            this.pnlStageProps.Controls.Add(this.button9);
            this.pnlStageProps.Controls.Add(this.button10);
            this.pnlStageProps.Controls.Add(this.listBox1);
            this.pnlStageProps.Controls.Add(this.listBox2);
            this.pnlStageProps.Controls.Add(this.label5);
            this.pnlStageProps.Location = new System.Drawing.Point(969, 3);
            this.pnlStageProps.Name = "pnlStageProps";
            this.pnlStageProps.Size = new System.Drawing.Size(316, 316);
            this.pnlStageProps.TabIndex = 40;
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(127, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 29);
            this.button5.TabIndex = 39;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
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
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(127, 132);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(63, 29);
            this.button7.TabIndex = 38;
            this.button7.Text = "<<";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(68, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(238, 20);
            this.textBox2.TabIndex = 24;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(127, 254);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(63, 29);
            this.button8.TabIndex = 37;
            this.button8.Text = ">> |";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Location = new System.Drawing.Point(3, 289);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "OK";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(127, 97);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(63, 29);
            this.button10.TabIndex = 36;
            this.button10.Text = "| <<";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 97);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(113, 186);
            this.listBox1.TabIndex = 33;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(196, 97);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(113, 186);
            this.listBox2.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Допущенные группы";
            // 
            // pnlSceneProps
            // 
            this.pnlSceneProps.Controls.Add(this.tbCoach);
            this.pnlSceneProps.Controls.Add(this.lbCall);
            this.pnlSceneProps.Controls.Add(this.textBox3);
            this.pnlSceneProps.Controls.Add(this.lbDescription);
            this.pnlSceneProps.Controls.Add(this.lbName);
            this.pnlSceneProps.Controls.Add(this.tbNumber);
            this.pnlSceneProps.Controls.Add(this.button3);
            this.pnlSceneProps.Controls.Add(this.button4);
            this.pnlSceneProps.Location = new System.Drawing.Point(647, 3);
            this.pnlSceneProps.Name = "pnlSceneProps";
            this.pnlSceneProps.Size = new System.Drawing.Size(316, 316);
            this.pnlSceneProps.TabIndex = 26;
            // 
            // tbCoach
            // 
            this.tbCoach.Location = new System.Drawing.Point(80, 55);
            this.tbCoach.Name = "tbCoach";
            this.tbCoach.Size = new System.Drawing.Size(229, 20);
            this.tbCoach.TabIndex = 40;
            // 
            // lbCall
            // 
            this.lbCall.AutoSize = true;
            this.lbCall.Location = new System.Drawing.Point(17, 32);
            this.lbCall.Name = "lbCall";
            this.lbCall.Size = new System.Drawing.Size(57, 13);
            this.lbCall.TabIndex = 32;
            this.lbCall.Text = "Название";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(229, 20);
            this.textBox3.TabIndex = 31;
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
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(80, 3);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(229, 20);
            this.tbNumber.TabIndex = 26;
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
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(3, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pnlGroupProps
            // 
            this.pnlGroupProps.Controls.Add(this.label2);
            this.pnlGroupProps.Controls.Add(this.button1);
            this.pnlGroupProps.Controls.Add(this.textBox1);
            this.pnlGroupProps.Controls.Add(this.button2);
            this.pnlGroupProps.Location = new System.Drawing.Point(325, 3);
            this.pnlGroupProps.Name = "pnlGroupProps";
            this.pnlGroupProps.Size = new System.Drawing.Size(316, 316);
            this.pnlGroupProps.TabIndex = 2;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(3, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pnlTeamProps
            // 
            this.pnlTeamProps.Controls.Add(this.btnAuto);
            this.pnlTeamProps.Controls.Add(this.btnStageComplete);
            this.pnlTeamProps.Controls.Add(this.btnStageIncomplete);
            this.pnlTeamProps.Controls.Add(this.btnStagePass);
            this.pnlTeamProps.Controls.Add(this.dgvStages);
            this.pnlTeamProps.Controls.Add(this.label3);
            this.pnlTeamProps.Controls.Add(this.cmbGroup);
            this.pnlTeamProps.Controls.Add(this.btnCancel);
            this.pnlTeamProps.Controls.Add(this.btnOk);
            this.pnlTeamProps.Controls.Add(this.label1);
            this.pnlTeamProps.Controls.Add(this.tbName);
            this.pnlTeamProps.Location = new System.Drawing.Point(3, 3);
            this.pnlTeamProps.Name = "pnlTeamProps";
            this.pnlTeamProps.Size = new System.Drawing.Size(316, 316);
            this.pnlTeamProps.TabIndex = 1;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(272, 228);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(34, 23);
            this.btnAuto.TabIndex = 23;
            this.btnAuto.Text = "A";
            this.btnAuto.UseVisualStyleBackColor = true;
            // 
            // btnStageComplete
            // 
            this.btnStageComplete.Location = new System.Drawing.Point(172, 228);
            this.btnStageComplete.Name = "btnStageComplete";
            this.btnStageComplete.Size = new System.Drawing.Size(75, 23);
            this.btnStageComplete.TabIndex = 22;
            this.btnStageComplete.Text = "<>";
            this.btnStageComplete.UseVisualStyleBackColor = true;
            // 
            // btnStageIncomplete
            // 
            this.btnStageIncomplete.Location = new System.Drawing.Point(91, 228);
            this.btnStageIncomplete.Name = "btnStageIncomplete";
            this.btnStageIncomplete.Size = new System.Drawing.Size(75, 23);
            this.btnStageIncomplete.TabIndex = 21;
            this.btnStageIncomplete.Text = "Добавить";
            this.btnStageIncomplete.UseVisualStyleBackColor = true;
            // 
            // btnStagePass
            // 
            this.btnStagePass.Location = new System.Drawing.Point(10, 228);
            this.btnStagePass.Name = "btnStagePass";
            this.btnStagePass.Size = new System.Drawing.Size(75, 23);
            this.btnStagePass.TabIndex = 20;
            this.btnStagePass.Text = "Удалить";
            this.btnStagePass.UseVisualStyleBackColor = true;
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
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(68, 29);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(238, 21);
            this.cmbGroup.TabIndex = 17;
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
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(5, 290);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
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
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(68, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(238, 20);
            this.tbName.TabIndex = 13;
            // 
            // vScrollBarProps
            // 
            this.vScrollBarProps.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBarProps.Location = new System.Drawing.Point(1325, 0);
            this.vScrollBarProps.Name = "vScrollBarProps";
            this.vScrollBarProps.Size = new System.Drawing.Size(17, 395);
            this.vScrollBarProps.TabIndex = 0;
            // 
            // tvList
            // 
            this.tvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvList.Location = new System.Drawing.Point(6, 6);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(280, 394);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            this.tvList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvList_NodeMouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 456);
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
        private System.Windows.Forms.VScrollBar vScrollBarProps;
        private System.Windows.Forms.Panel pnlTeamProps;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnStageComplete;
        private System.Windows.Forms.Button btnStageIncomplete;
        private System.Windows.Forms.Button btnStagePass;
        private System.Windows.Forms.DataGridView dgvStages;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUsage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel pnlGroupProps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlSceneProps;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlStageProps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCoach;
        private System.Windows.Forms.Label lbCall;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbNumber;
    }
}

