using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using TeamCoordinator.Properties;

namespace TeamCoordinator
{
    struct MouseClickMoveEvent
    {
        public MouseButtons Button;
        public Point MousePosition;
        public Point GridPosition;
        public int FirstDisplayedRow;
        public DataGridViewCell SelectedCell;
    }

    public partial class MainForm : Form
    {

        //private const int c_RowHeight = 35;
        //private const int c_ColHeadersHeight = 50;

        //private const int c_ColWidth = 54;
        //private const int c_RowHeadersWidth = 60;

        private float m_FontSize = 6f;
        private double m_ColWidthMultiplier = 100;

        private int RowHeight
        {
            get
            {
                var rows = 3;
                return (int)(m_FontSize * rows + m_FontSize * (rows + 2) * 0.8);
            }
        }
        private int ColHeadersHeight
        {
            get
            {
                var rows = 4;
                return (int)(m_FontSize * rows + m_FontSize * (rows + 2) * 0.8);
            }
        }
        private int ColWidth
        {
            get
            {
                return (int)(m_FontSize * 10 * m_ColWidthMultiplier / 100.0);
            }
        }
        private int RowHeadersWidth
        {
            get
            {
                var add = 6;
                return (int)m_FontSize * 9 + add;
            }
        }

        private Color c_Green = Color.FromArgb(128, 255, 128);
        private Color c_Yellow = Color.FromArgb(255, 255, 128);
        private Color c_Red = Color.FromArgb(255, 174, 201);
        private Color c_Blue = Color.FromArgb(0, 128, 255);
        private Color c_Violet = Color.FromArgb(230, 100, 230);
        private Color c_Gray = Color.FromArgb(180, 180, 180);

        private const string c_Groups = "Группы";
        private const string c_Stages = "Этапы";
        private const string c_Scenes = "Сцены";
        private const string c_Teams = "Команды";

        private AI m_AI;

        private MouseClickMoveEvent m_LastMouseClick;

        public MainForm()
        {
            InitializeComponent();
            m_AI = new AI(null);

            //Width = 750;
            tvList.Location = new Point(3, 3);
            pnlTeamProps.Location = new Point(3, 3);
            pnlSceneProps.Location = new Point(3, 3);
            pnlGroupProps.Location = new Point(3, 3);
            pnlStageProps.Location = new Point(3, 3);
            pnlProps.Width = 324;
            pnlProps.Left = Width - pnlProps.Width - 24;
            tvList.Width = pnlProps.Left - 12;

            SetDoubleBuffered(dgvGrid, true);

            UpdateData();
        }

        void SetDoubleBuffered(Control c, bool value)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);

                MethodInfo mi = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(c, new object[] { ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true });
                }

                mi = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(c, null);
                }
            }
        }

        private void UpdateGridCells()
        {
            m_AI.RebuildGrid = false;
            //Point selectedCell = new Point(-1, -1);
            int firstRow = dgvGrid.FirstDisplayedScrollingRowIndex;
            int horizontalScroll = dgvGrid.HorizontalScrollingOffset;

            //if (dgvGrid.CurrentCell != null)
            //{
            //    selectedCell = new Point(dgvGrid.CurrentCell.RowIndex, dgvGrid.CurrentCell.ColumnIndex);
            //}

            var font = new Font(dgvGrid.Font.Name, m_FontSize);
            dgvGrid.Font = font;

            dgvGrid.Columns.Clear();
            dgvGrid.Rows.Clear();

            dgvGrid.ColumnHeadersHeight = ColHeadersHeight;
            dgvGrid.RowHeadersWidth = RowHeadersWidth;

            foreach (var scene in m_AI.Scenes.AllSorted)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Tag = scene;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = ColWidth;
                dgvGrid.Columns.Add(col);
            }
            if (dgvGrid.ColumnCount > 0)
            {
                foreach (var team in m_AI.Teams.AllSorted)
                {
                    var row = new DataGridViewRow();
                    row.Tag = team;
                    row.Height = RowHeight;
                    dgvGrid.Rows.Add(row);

                }
            }
            dgvGrid.ClearSelection();
            //if (selectedCell.X != -1 && selectedCell.Y != -1)
            //{
            //    dgvGrid.CurrentCell = dgvGrid.Rows[selectedCell.X].Cells[selectedCell.Y];
            //    dgvGrid.CurrentCell.Selected = false;
            //}

            if (dgvGrid.RowCount > 0 && dgvGrid.ColumnCount > 0)
            {
                if (firstRow != -1)
                    dgvGrid.FirstDisplayedScrollingRowIndex = firstRow;
                dgvGrid.HorizontalScrollingOffset = horizontalScroll;
            }
        }

        private void UpdateGridData()
        {
            for (int c = 0; c < dgvGrid.ColumnCount; c++)
            {
                var col = dgvGrid.Columns[c];
                var scene = col.Tag as Scene;
                if (scene == null)
                {
                    Debug.Fail("How??");
                    continue;
                }

                var stage = m_AI.Stages[scene.StageID];
                if (stage == null)
                {
                    continue;
                }

                col.HeaderText = string.Format("{0}\r\n{1}\r\n{2}\r\n(+{3})", scene.Name, scene.Coach,
                    scene.ChangeStateTime.ToShortTimeString(), GetDiffFromNow(scene.ChangeStateTime));

                Color color = Color.Teal;
                switch (scene.State)
                {
                    case SceneState.NotReady:
                        color = c_Red;
                        break;
                    case SceneState.Occuped:
                        color = c_Yellow;
                        break;
                    case SceneState.Ready:
                        color = c_Green;
                        break;

                    default:
                        Debug.Fail("NotImplemented");
                        break;
                }
                if (col.HeaderCell.Style.BackColor != color)
                    col.HeaderCell.Style.BackColor = color;
            }

            for (int r = 0; r < dgvGrid.RowCount; r++)
            {
                var row = dgvGrid.Rows[r];
                var team = row.Tag as Team;
                if (team == null)
                {
                    Debug.Fail("How??");
                    continue;
                }
                row.HeaderCell.Value = string.Format("{0}\r\n{1} - {2}\r\n({3})", team.Name, team.CompleteStagesCount, team.IncompleteStagesCount, GetDiffFromNow(team.LastRecord.Time));
                row.Height = RowHeight;

                Color color = Color.Teal;
                switch (team.State)
                {
                    case TeamState.Ready:
                        color = c_Green;
                        break;

                    case TeamState.Pause:
                        color = c_Red;
                        break;

                    case TeamState.MoveBack:
                        color = c_Blue;
                        break;

                    default:
                        color = c_Yellow;
                        break;
                }
                if (row.HeaderCell.Style.BackColor != color)
                    row.HeaderCell.Style.BackColor = color;

                for (int c = 0; c < dgvGrid.Columns.Count; c++)
                {
                    var col = dgvGrid.Columns[c];
                    var scene = col.Tag as Scene;
                    if (scene != null)
                    {
                        var cell = row.Cells[c];
                        string state = string.Empty;
                        color = c_Gray;
                        switch (team.GetStateByScene(scene.ID))
                        {
                            case TeamState.Pass:
                                color = c_Gray;
                                break;
                            case TeamState.Incomplete:
                                color = c_Red;
                                break;
                            case TeamState.CallToBase:
                                state = "Вызвана";
                                color = c_Yellow;
                                break;
                            case TeamState.SentToScene:
                                state = "Отправлена";
                                color = c_Yellow;
                                break;
                            case TeamState.StartWork:
                                state = "Работает";
                                color = c_Yellow;
                                break;
                            case TeamState.Completed:
                                color = c_Green;
                                break;
                            case TeamState.AtOtherScene:
                                color = c_Yellow;
                                break;

                            default:
                                Debug.Fail("NotImplemented");
                                break;
                        }
                        if (state != string.Empty)
                        {
                            state = string.Format("{0}\r\n{1}", state, GetDiffFromNow(team.LastRecord.Time));
                        }
                        if (cell.Value == null)
                        {
                            if (state != string.Empty)
                                cell.Value = state;
                        }
                        else if (cell.Value.ToString() != state)
                            cell.Value = state;
                        if (cell.Style.BackColor != color)
                            cell.Style.BackColor = color;
                    }
                }

            }
        }

        private string GetDiffFromNow(DateTime time)
        {
            var lastMins = Math.Truncate((DateTime.Now - time).TotalMinutes);
            var lastSecs = Math.Truncate((DateTime.Now - time).TotalSeconds) - (60 * lastMins);
            return string.Format("{0}:{1}", lastMins, lastSecs);
        }

        private void FillLog()
        {
            lbLog.Items.Clear();
            var cc = dgvGrid.CurrentCell;
            if (cc != null && cc.RowIndex >= 0)
            {
                var row = dgvGrid.Rows[cc.RowIndex];
                var team = row.Tag as Team;
                if (team != null)
                {
                    foreach (var record in team.RecordsLog)
                    {
                        lbLog.Items.Add(record);
                    }
                }
            }

        }

        private void UpdateData()
        {
            this.Text = m_AI.FileName;
            if (!m_AI.Valid)
            {
                return;
            }

            if (tabControl.SelectedIndex == 0)
            {
                if (m_AI.RebuildGrid)
                {
                    UpdateGridCells();
                }
                UpdateGridData();
            }

            //m_AI.CheckTeams();
            #region Props

            if (tabControl.SelectedIndex == 1)
            {
                RefreshTreeView();
                RefreshPropsPnl();
            }
            #endregion

            FillLog();

            m_AI.SaveToStg();
        }

        private void RefreshTreeView()
        {
            var teamsExpanded = (tvList.Nodes[c_Teams] != null) ? tvList.Nodes[c_Teams].IsExpanded : false;
            var scenesExpanded = (tvList.Nodes[c_Scenes] != null) ? tvList.Nodes[c_Scenes].IsExpanded : false;
            var groupsExpanded = (tvList.Nodes[c_Groups] != null) ? tvList.Nodes[c_Groups].IsExpanded : false;
            var stagesExpanded = (tvList.Nodes[c_Stages] != null) ? tvList.Nodes[c_Stages].IsExpanded : false;

            tvList.Nodes.Clear();

            TreeNode coreNode;

            coreNode = new TreeNode(c_Teams);
            coreNode.Name = c_Teams;
            coreNode.Tag = c_Teams;
            foreach (var item in m_AI.Teams.AllSorted)
            {
                string s = "";
                var group = m_AI.Groups[item.GroupID];
                if (group != null)
                {
                    s = (group.ShortName != "") ? group.ShortName : group.Name;
                }
                var node = new TreeNode(string.Format("{0} ({1})", item.Name, s));
                node.Name = item.ID.ToString();
                node.Tag = item;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            coreNode = new TreeNode(c_Scenes);
            coreNode.Name = c_Scenes;
            coreNode.Tag = c_Scenes;
            foreach (var item in m_AI.Scenes.AllSorted)
            {
                string s = "";
                var stage = m_AI.Stages[item.StageID];
                if (stage != null)
                {
                    s = (stage.ShortName != "") ? stage.ShortName : stage.Name;
                }
                var node = new TreeNode((item.Number == "") ? s : string.Format("{0} - {1}", s, item.Number));
                node.Tag = item;
                node.Name = item.ID.ToString();
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            coreNode = new TreeNode(c_Groups);
            coreNode.Name = c_Groups;
            coreNode.Tag = c_Groups;
            foreach (var item in m_AI.Groups.AllSorted)
            {
                var node = new TreeNode(item.Name);
                node.Tag = item;
                node.Name = item.ID.ToString();
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            coreNode = new TreeNode(c_Stages);
            coreNode.Name = c_Stages;
            coreNode.Tag = c_Stages;
            foreach (var item in m_AI.Stages.AllSorted)
            {
                var node = new TreeNode((item.ShortName == "") ? item.Name : string.Format("{0} ({1})", item.Name, item.ShortName));
                node.Tag = item;
                node.Name = item.ID.ToString();
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            if (teamsExpanded)
                tvList.Nodes[c_Teams].Expand();
            if (scenesExpanded)
                tvList.Nodes[c_Scenes].Expand();
            if (groupsExpanded)
                tvList.Nodes[c_Groups].Expand();
            if (stagesExpanded)
                tvList.Nodes[c_Stages].Expand();

            if (m_SelectedItem != null)
            {
                var nodes = tvList.Nodes.Find(m_SelectedItem.ToString(), true);
                if (nodes.Length > 0)
                {
                    tvList.SelectedNode = nodes[0];
                }
            }
        }

        private void RefreshPropsPnl()
        {
            pnlTeamProps.Visible = false;
            pnlGroupProps.Visible = false;
            pnlSceneProps.Visible = false;
            pnlStageProps.Visible = false;

            if (m_SelectedItem != null)
            {
                var team = m_SelectedItem as Team;
                if (team != null)
                {
                    tbTeamName.Text = team.Name;

                    var cnt = 0;
                    var index = -1;
                    cmbTeamGroup.Items.Clear();
                    foreach (var aiGroup in m_AI.Groups.AllSorted)
                    {
                        cmbTeamGroup.Items.Add(aiGroup.Name);
                        if (aiGroup.ID == team.GroupID)
                            index = cnt;
                        cnt++;
                    }
                    if (cmbTeamGroup.Items.Count > 0)
                    {
                        cmbTeamGroup.SelectedIndex = index;
                    }

                    RefreshTeamStages();

                    pnlTeamProps.Visible = true;
                    return;
                }

                var scene = m_SelectedItem as Scene;
                if (scene != null)
                {
                    tbSceneNumber.Text = scene.Number;

                    var cnt = 0;
                    var index = -1;
                    cmbSceneStage.Items.Clear();
                    foreach (var aiStage in m_AI.Stages.AllSorted)
                    {
                        cmbSceneStage.Items.Add(aiStage.Name);
                        if (aiStage.ID == scene.StageID)
                            index = cnt;
                        cnt++;
                    }
                    if (cmbSceneStage.Items.Count > 0)
                    {
                        cmbSceneStage.SelectedIndex = index;
                    }

                    tbSceneCoach.Text = scene.Coach;

                    pnlSceneProps.Visible = true;
                    return;
                }

                var group = m_SelectedItem as Group;
                if (group != null)
                {
                    tbGroupName.Text = group.Name;
                    tbGroupShortName.Text = group.ShortName;

                    pnlGroupProps.Visible = true;
                    return;
                }

                var stage = m_SelectedItem as Stage;
                if (stage != null)
                {
                    tbStageName.Text = stage.Name;
                    tbStageShortname.Text = stage.ShortName;
                    RefreshStageGroups();

                    pnlStageProps.Visible = true;
                    return;
                }
            }
        }

        private void dgvStages_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            btnStagePass.Enabled = false;
            btnStageIncomplete.Enabled = false;
            btnStageComplete.Enabled = false;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                int value = (int)row.Cells[1].Tag;
                switch (value)
                {
                    case -1:
                        btnStageIncomplete.Enabled = true;
                        btnStageComplete.Enabled = true;
                        break;
                    case 0:
                        btnStagePass.Enabled = true;
                        btnStageComplete.Enabled = true;
                        break;
                    case 1:
                        btnStagePass.Enabled = true;
                        btnStageIncomplete.Enabled = true;
                        break;
                }
            }
        }

        #region MainMenu

        private void miCreate_Click(object sender, EventArgs e)
        {
            var day = DateTime.Today.Day.ToString();
            var month = DateTime.Today.Month.ToString();
            var year = DateTime.Today.Year.ToString();

            var fileName = string.Format("{0}-{1}-{2}", day, month, year);

            fileName = Microsoft.VisualBasic.Interaction.InputBox("Укажите имя файла", "Создать новую базу", fileName, (int)(DisplayRectangle.Width * 0.5), (int)(DisplayRectangle.Height * 0.5));
            if (fileName == "")
            {
                return;
            }
            fileName += ".xml";

            var folderName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var pathString = System.IO.Path.Combine(folderName, fileName);

            if (System.IO.File.Exists(pathString))
            {
                var result = MessageBox.Show(Resources.eFileAlreadyExists, Resources.mWarning, MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK)
                {
                    return;
                }
            }

            var ms = File.Create(pathString);
            ms.Close();
            var doc = new XDocument(new XElement("AI",
                new XElement("Stages"),
                new XElement("Teams"),
                new XElement("Groups"),
                new XElement("Scenes")));
            doc.Save(pathString);
            m_AI = new AI(pathString);

            UpdateData();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            openFileDialog.Filter = "XML file|*.xml";
            openFileDialog.Title = "Выберите файл базы";

            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            m_AI = new AI(openFileDialog.FileName);
            UpdateData();
        }

        private void miChangeTextSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sFontSize = m_FontSize.ToString();
            if (Input.ShowInputDialog("Задайте новый размер шрифта", ref sFontSize) == DialogResult.OK)
            {
                float fs;
                if (float.TryParse(sFontSize, out fs))
                {
                    m_FontSize = fs;
                    m_AI.RebuildGrid = true;
                    UpdateData();
                }
            }
        }

        private void изменитьШиринуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sColWidth = m_ColWidthMultiplier.ToString();
            if (Input.ShowInputDialog("Задайте новый размер шрифта", ref sColWidth) == DialogResult.OK)
            {
                double d;
                if (double.TryParse(sColWidth, out d))
                {
                    m_ColWidthMultiplier = d;
                    m_AI.RebuildGrid = true;
                    UpdateData();
                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateGridData();
        }

        private void tsmiTimerSwitcher_Click(object sender, EventArgs e)
        {
            RefreshTimer.Enabled ^= true;
            if (RefreshTimer.Enabled)
            {
                tsmiTimerSwitcher.Text = Resources.sRefreshTimerSwitchOn;
            }
            else
            {
                tsmiTimerSwitcher.Text = Resources.sRefreshTimerSwitchOff;
            }
        }

        #endregion

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        #region dgvGrid_MouseClick

        private void dgvGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (!m_AI.Valid)
            {
                return;
            }

            var hitTest = dgvGrid.HitTest(e.X, e.Y);
            if (hitTest.RowIndex != -1 && hitTest.ColumnIndex != -1)
            {
                dgvGrid.CurrentCell = dgvGrid.Rows[(hitTest.RowIndex == -1) ? 0 : hitTest.RowIndex].Cells[(hitTest.ColumnIndex == -1) ? 0 : hitTest.ColumnIndex];
            }
            dgvGrid.ClearSelection();

            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem mi;
                var spacer = "---------";
                if (hitTest.ColumnIndex == -1 && hitTest.RowIndex == -1) //Нулевая ячейка
                {
                    mi = new MenuItem("Обновить");
                    mi.Click += new EventHandler(refresh_Click);
                    m.MenuItems.Add(mi);

                    mi = new MenuItem(spacer);
                    m.MenuItems.Add(mi);

                    mi = new MenuItem("Добавить команду");
                    mi.Tag = new Team(m_AI);
                    mi.Click += new EventHandler(addItem_Click);
                    m.MenuItems.Add(mi);

                    mi = new MenuItem("Добавить сцену");
                    mi.Tag = new Scene(m_AI);
                    mi.Click += new EventHandler(addItem_Click);
                    m.MenuItems.Add(mi);
                }
                else if (hitTest.ColumnIndex == -1) //Команды
                {
                    var team = dgvGrid.Rows[hitTest.RowIndex].Tag as Team;
                    if (team != null)
                    {
                        var teamReady = new MenuItem("Команда готова");
                        teamReady.Click += new EventHandler(teamReady_Click);
                        teamReady.Tag = team;

                        var teamPause = new MenuItem("Команда на паузе");
                        teamPause.Click += new EventHandler(teamPause_Click);
                        teamPause.Tag = team;

                        var teamReturned = new MenuItem("Команда вернулась");
                        teamReturned.Click += new EventHandler(teamReturned_Click);
                        teamReturned.Tag = team;

                        switch (team.State)
                        {
                            case TeamState.MoveBack:
                                m.MenuItems.Add(teamReady);
                                m.MenuItems.Add(teamPause);
                                break;

                            case TeamState.Pause:
                                m.MenuItems.Add(teamReady);
                                break;

                            case TeamState.Ready:
                                m.MenuItems.Add(teamPause);
                                break;

                            case TeamState.CallToBase:
                            case TeamState.SentToScene:
                            case TeamState.StartWork:
                                m.MenuItems.Add(teamReturned);
                                break;

                            default:
                                Debug.Fail("How??");
                                m.MenuItems.Add(teamReady);
                                m.MenuItems.Add(teamPause);
                                break;
                        }

                        m.MenuItems.Add(spacer);

                        mi = new MenuItem("Добавить комментарий");
                        mi.Tag = team;
                        mi.Click += new EventHandler(teamAddCommentaryWithTime_Click);
                        m.MenuItems.Add(mi);

                        mi = new MenuItem("Добавить комментарий без времени");
                        mi.Tag = team;
                        mi.Click += new EventHandler(teamAddCommentaryWithoutTime_Click);
                        m.MenuItems.Add(mi);

                        m.MenuItems.Add(spacer);

                        mi = new MenuItem("Редактировать команду");
                        mi.Click += new EventHandler(editTeam_Click);
                        mi.Tag = team;
                        m.MenuItems.Add(mi);

                        mi = new MenuItem("Удалить команду");
                        mi.Click += new EventHandler(removeItem_Click);
                        mi.Tag = team;
                        m.MenuItems.Add(mi);

                        m.MenuItems.Add(spacer);

                        foreach (var stage in team.IncompletedStages)
                        {
                            foreach (var scene in m_AI.Scenes.AllSorted)
                            {
                                if (scene.StageID == stage.ID && scene.State == SceneState.Ready)
                                {
                                    mi = new MenuItem(string.Format("Вызвать на этап {0}", scene.Name));
                                    mi.Click += new EventHandler(teamCalled_Click);
                                    mi.Tag = new object[2] { team, scene };
                                    m.MenuItems.Add(mi);
                                }
                            }
                        }

                        m.MenuItems.Add(spacer);

                        mi = new MenuItem("Показать лог");
                        mi.Click += new EventHandler(teamShowLog_Click);
                        mi.Tag = team;
                        m.MenuItems.Add(mi);

                        m.MenuItems.Add(spacer);

                        mi = new MenuItem("Добавить команду");
                        mi.Click += new EventHandler(addItem_Click);
                        mi.Tag = new Team(m_AI);
                        m.MenuItems.Add(mi);
                    }
                }
                else if (hitTest.RowIndex == -1) //Этапы
                {
                    var scene = dgvGrid.Columns[hitTest.ColumnIndex].Tag as Scene;
                    if (scene != null)
                    {
                        switch (scene.State)
                        {
                            case SceneState.Ready:
                                mi = new MenuItem("На паузу");
                                mi.Click += new EventHandler(sceneChangeReady_Click);
                                mi.Tag = scene;
                                m.MenuItems.Add(mi);
                                break;

                            case SceneState.NotReady:
                                mi = new MenuItem("Открыть");
                                mi.Click += new EventHandler(sceneChangeReady_Click);
                                mi.Tag = scene;
                                m.MenuItems.Add(mi);
                                break;

                            case SceneState.Occuped:
                                mi = new MenuItem("Команды ушли, этап готов");
                                mi.Tag = scene;
                                mi.Click += new EventHandler(teamsFinishedAndSceneReady_Click);
                                m.MenuItems.Add(mi);

                                mi = new MenuItem("Команды ушли, этап на паузе");
                                mi.Tag = scene;
                                mi.Click += new EventHandler(teamsFinishedAndScenePause_Click);
                                m.MenuItems.Add(mi);

                                break;
                        }

                        m.MenuItems.Add(spacer);

                        var editStage = new MenuItem("Редактировать сцену");
                        editStage.Click += new EventHandler(editStage_Click);
                        editStage.Tag = scene;
                        m.MenuItems.Add(editStage);

                        mi = new MenuItem("Удалить сцену");
                        mi.Click += new EventHandler(removeItem_Click);
                        mi.Tag = scene;
                        m.MenuItems.Add(mi);

                        m.MenuItems.Add(spacer);

                        mi = new MenuItem("Добавить сцену");
                        mi.Click += new EventHandler(addItem_Click);
                        mi.Tag = new Scene(m_AI);
                        m.MenuItems.Add(mi);
                    }
                }
                else //Ячейка
                {
                    var team = dgvGrid.Rows[hitTest.RowIndex].Tag as Team;
                    var scene = dgvGrid.Columns[hitTest.ColumnIndex].Tag as Scene;
                    if (team != null && scene != null)
                    {
                        var tag = new object[2] { team, scene };

                        var callTeam = new MenuItem("Вызвать команду");
                        callTeam.Tag = tag;
                        callTeam.Click += new EventHandler(teamCalled_Click);

                        var sendTeam = new MenuItem("Отправить команду");
                        sendTeam.Tag = tag;
                        sendTeam.Click += new EventHandler(teamSent_Click);

                        var teamArrived = new MenuItem("Команда прибыла");
                        teamArrived.Tag = tag;
                        teamArrived.Click += new EventHandler(teamArrived_Click);

                        var teamFinishStageReady = new MenuItem("Команда ушла, этап готов");
                        teamFinishStageReady.Tag = tag;
                        teamFinishStageReady.Click += new EventHandler(teamFinishedAndSceneReady_Click);

                        var teamFinishStagePause = new MenuItem("Команда ушла, этап на паузе");
                        teamFinishStagePause.Tag = tag;
                        teamFinishStagePause.Click += new EventHandler(teamFinishedAndScenePause_Click);

                        var stagePass = new MenuItem("Пропустить");
                        stagePass.Tag = tag;
                        stagePass.Click += new EventHandler(stagePass_Click);

                        var stageIncomplete = new MenuItem("Не пройден");
                        stageIncomplete.Tag = tag;
                        stageIncomplete.Click += new EventHandler(stageIncomplete_Click);

                        var stageCompleted = new MenuItem("Пройден");
                        stageCompleted.Tag = tag;
                        stageCompleted.Click += new EventHandler(stageCompleted_Click);

                        switch (team.GetStateByScene(scene.ID))
                        {
                            case TeamState.Pass:
                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(stageIncomplete);
                                m.MenuItems.Add(stageCompleted);
                                break;
                            case TeamState.Incomplete:
                                if (scene.State == SceneState.Ready && team.State == TeamState.Ready)
                                {
                                    m.MenuItems.Add(callTeam);
                                    m.MenuItems.Add(spacer);
                                    m.MenuItems.Add(sendTeam);
                                    m.MenuItems.Add(teamArrived);
                                    m.MenuItems.Add(teamFinishStageReady);
                                    m.MenuItems.Add(teamFinishStagePause);
                                }
                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(stagePass);
                                m.MenuItems.Add(stageCompleted);
                                break;
                            case TeamState.CallToBase:
                                m.MenuItems.Add(sendTeam);
                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(teamArrived);
                                m.MenuItems.Add(teamFinishStageReady);
                                m.MenuItems.Add(teamFinishStagePause);

                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(stagePass);
                                m.MenuItems.Add(stageIncomplete);
                                m.MenuItems.Add(stageCompleted);
                                break;
                            case TeamState.SentToScene:
                                m.MenuItems.Add(teamArrived);
                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(teamFinishStageReady);
                                m.MenuItems.Add(teamFinishStagePause);

                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(stagePass);
                                m.MenuItems.Add(stageIncomplete);
                                m.MenuItems.Add(stageCompleted);
                                break;
                            case TeamState.StartWork:
                                m.MenuItems.Add(teamFinishStageReady);
                                m.MenuItems.Add(teamFinishStagePause);

                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(stagePass);
                                m.MenuItems.Add(stageIncomplete);
                                m.MenuItems.Add(stageCompleted);
                                break;
                            case TeamState.Completed:
                                m.MenuItems.Add(spacer);
                                m.MenuItems.Add(stagePass);
                                m.MenuItems.Add(stageIncomplete);
                                break;
                        }
                    }
                }
                if (m.MenuItems.Count > 0)
                {
                    m.Show(dgvGrid, new Point(e.X, e.Y));
                }
            }
        }

        void editStage_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var stage = mi.Tag as Scene;
            //    if (stage != null)
            //    {
            //        if (StageEditDlg.Execute(m_AI, stage))
            //        {
            //            UpdateData();
            //        }
            //    }
            //}
        }

        void editTeam_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var team = mi.Tag as Team;
            //    if (team != null)
            //    {
            //        if (TeamEditDlg.Execute(m_AI, team))
            //        {
            //            UpdateData();
            //        }
            //    }
            //}
        }

        #endregion

        #region DgvActions

        void refresh_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        void addItem_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var item = mi.Tag as Item;
                if (item == null)
                {
                    return;
                }

                m_AI.Teams.AddItem(item);
                m_AI.Scenes.AddItem(item);
                m_AI.Groups.AddItem(item);
                m_AI.Stages.AddItem(item);

                m_SelectedItem = item;

                UpdateData();

                if (tabControl.SelectedIndex == 0)
                {
                    tabControl.SelectedIndex = 1;
                }
            }
        }

        void removeItem_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var item = mi.Tag as Item;
                if (item == null)
                    return;

                m_AI.Teams.RemoveItem(item);
                m_AI.Scenes.RemoveItem(item);
                m_AI.Groups.RemoveItem(item);
                m_AI.Stages.RemoveItem(item);

                m_SelectedItem = null;
                UpdateData();
            }
        }

        void sceneChangeReady_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var scene = mi.Tag as Scene;
                if (scene != null)
                {
                    scene.IsReady ^= true;
                    scene.ChangeStateTime = DateTime.Now;
                    UpdateData();
                }
            }
        }

        void teamReady_Click(object sender, EventArgs e)
        {
            Team team;
            if (ParseTag(sender, out team))
            {
                team.NewState(null, TeamState.Ready);
                UpdateData();
            }
        }

        void teamPause_Click(object sender, EventArgs e)
        {
            Team team;
            if (ParseTag(sender, out team))
            {
                team.NewState(null, TeamState.Pause);
                UpdateData();
            }
        }

        /// <summary>
        /// Вызвать команду на этап
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamCalled_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.NewState(scene, TeamState.CallToBase);
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Отправить команду на этап
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamSent_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.NewState(scene, TeamState.SentToScene);
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Команда прибыла на этап
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamArrived_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.NewState(scene, TeamState.StartWork);
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Команда прибыла на этап
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamReturned_Click(object sender, EventArgs e)
        {
            Team team;
            if (ParseTag(sender, out team))
            {
                var lastScene = team.CurrentScene;
                if (lastScene != null)
                {
                    team.CompleteStage(lastScene.StageID);
                    lastScene.ChangeStateTime = DateTime.Now;
                    lastScene.IsReady = false;
                }
                team.NewState(null, TeamState.Ready);
                UpdateData();
            }
        }

        /// <summary>
        /// Добавить комментарий с актуальным временем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamAddCommentaryWithTime_Click(object sender, EventArgs e)
        {
            Team team;
            if (ParseTag(sender, out team))
            {
                var s = string.Empty;
                if (Input.ShowInputDialog(Resources.sAddComment, ref s) == DialogResult.OK)
                {
                    if (s != string.Empty)
                    {
                        team.AddComment(s, true);
                        UpdateData();
                    }
                }
            }
        }

        /// <summary>
        /// Добавить комментарий без указания времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamAddCommentaryWithoutTime_Click(object sender, EventArgs e)
        {
            Team team;
            if (ParseTag(sender, out team))
            {
                var s = string.Empty;
                if (Input.ShowInputDialog(Resources.sAddComment, ref s) == DialogResult.OK)
                {
                    if (s != string.Empty)
                    {
                        team.AddComment(s, false);
                        UpdateData();
                    }
                }
            }
        }

        /// <summary>
        /// Показать лог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamShowLog_Click(object sender, EventArgs e)
        {
            Team team;
            if (ParseTag(sender, out team))
            {
                var dlg = new TeamLogDlg();
                dlg.SetTeam(team);
                dlg.Show();
            }
        }

        /// <summary>
        /// Команда покинула этап, этап готов к новой команде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamFinishedAndSceneReady_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.CompleteStage(scene.StageID);
                team.NewState(null, TeamState.MoveBack);
                scene.IsReady = true;
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Команда покинула этап, этап закрыт на паузу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamFinishedAndScenePause_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.CompleteStage(scene.StageID);
                team.NewState(null, TeamState.MoveBack);
                scene.IsReady = false;
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Команды покинули этап, этап готов к новой команде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamsFinishedAndSceneReady_Click(object sender, EventArgs e)
        {
            Scene scene;
            if (ParseTag(sender, out scene))
            {
                foreach (var team in m_AI.Teams.All)
                {
                    if (team.CurrentScene == scene)
                    {
                        team.CompleteStage(scene.StageID);
                        team.NewState(null, TeamState.MoveBack);
                    }
                }
                scene.IsReady = true;
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Команды покинули этап, этап закрыт на паузу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void teamsFinishedAndScenePause_Click(object sender, EventArgs e)
        {
            Scene scene;
            if (ParseTag(sender, out scene))
            {
                foreach (var team in m_AI.Teams.All)
                {
                    if (team.CurrentScene == scene)
                    {
                        team.CompleteStage(scene.StageID);
                        team.NewState(null, TeamState.MoveBack);
                    }
                }
                scene.IsReady = false;
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        /// <summary>
        /// Пропустить этап (тех.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stagePass_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.PassStage(scene.StageID);
                UpdateData();
            }
        }

        /// <summary>
        /// Этап не выполнен (тех.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stageIncomplete_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.IncompleteStage(scene.StageID);
                UpdateData();
            }
        }

        /// <summary>
        /// Этап выполнен (тех.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void stageCompleted_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (ParseTag(sender, out team, out scene))
            {
                team.CompleteStage(scene.StageID);
                UpdateData();
            }
        }

        private bool ParseTag(object sender, out Team team)
        {
            Scene scene;
            if (ParseTag(sender, out team, out scene))
                return team != null;
            return false;
        }

        private bool ParseTag(object sender, out Scene scene)
        {
            Team team;
            if (ParseTag(sender, out team, out scene))
                return scene != null;
            return false;
        }

        private bool ParseTag(object sender, out Team team, out Scene scene)
        {
            team = null;
            scene = null;
            var mi = sender as MenuItem;
            if (mi != null)
            {
                if (mi.Tag is Team)
                {
                    team = mi.Tag as Team;
                    return true;
                }
                if (mi.Tag is Scene)
                {
                    scene = mi.Tag as Scene;
                    return true;
                }
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    team = tag[0] as Team;
                    scene = tag[1] as Scene;

                    if (team != null && scene != null)
                    {
                        return true;
                    }

                    team = tag[1] as Team;
                    scene = tag[0] as Scene;

                    if (team != null && scene != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region tvList_MouseClick

        private void tvList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!m_AI.Valid)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                //dgvGrid.ClearSelection();
            }
            else if (e.Button == MouseButtons.Right)
            {
                var tag = e.Node.Tag;
                ContextMenu m = new ContextMenu();
                MenuItem mi = null;

                var s = tag as string;
                if (s != null)
                {
                    switch (s)
                    {
                        case c_Teams:
                            mi = new MenuItem("Добавить команду");
                            mi.Tag = new Team(m_AI);
                            break;
                        case c_Scenes:
                            mi = new MenuItem("Добавить сцену");
                            mi.Tag = new Scene(m_AI);
                            break;
                        case c_Groups:
                            mi = new MenuItem("Добавить группу");
                            mi.Tag = new Group(m_AI);
                            break;
                        case c_Stages:
                            mi = new MenuItem("Добавить этап");
                            mi.Tag = new Stage(m_AI);
                            break;
                    }
                    if (mi != null)
                    {
                        mi.Click += new EventHandler(addItem_Click);
                        m.MenuItems.Add(mi);
                    }
                }

                mi = null;
                var team = tag as Team;
                if (team != null)
                {
                    mi = new MenuItem("Удалить команду");
                }
                var scene = tag as Scene;
                if (scene != null)
                {
                    mi = new MenuItem("Удалить сцену");
                }
                var group = tag as Group;
                if (group != null)
                {
                    mi = new MenuItem("Удалить группу");
                }
                var stage = tag as Stage;
                if (stage != null)
                {
                    mi = new MenuItem("Удалить этап");
                }
                if (mi != null)
                {
                    mi.Click += new EventHandler(removeItem_Click);
                    mi.Tag = tag;
                    m.MenuItems.Add(mi);
                }

                //if (hitTest.ColumnIndex == -1 && hitTest.RowIndex == -1)
                //{
                //    var addTeam = new MenuItem("Добавить команду");
                //    addTeam.Click += new EventHandler(addTeam_Click);
                //    m.MenuItems.Add(addTeam);

                //    var addStage = new MenuItem("Добавить этап");
                //    addStage.Click += new EventHandler(addStage_Click);
                //    m.MenuItems.Add(addStage);
                //}
                //else
                //{
                //    if (hitTest.ColumnIndex == -1)
                //    {
                //        var team = dgvGrid.Rows[hitTest.RowIndex].Tag;
                //        if (team != null)
                //        {
                //            var teamIsReady = new MenuItem("Ready/Wait");
                //            teamIsReady.Click += new EventHandler(teamIsReady_Click);
                //            teamIsReady.Tag = team;
                //            m.MenuItems.Add(teamIsReady);

                //            var editTeam = new MenuItem("Редактировать команду");
                //            editTeam.Click += new EventHandler(editTeam_Click);
                //            editTeam.Tag = team;
                //            m.MenuItems.Add(editTeam);

                //            var removeTeam = new MenuItem("Удалить команду");
                //            removeTeam.Click += new EventHandler(removeTeam_Click);
                //            removeTeam.Tag = team;
                //            m.MenuItems.Add(removeTeam);


                //            m.MenuItems.Add("-------");
                //            var addTeam = new MenuItem("Добавить команду");
                //            addTeam.Click += new EventHandler(addTeam_Click);
                //            m.MenuItems.Add(addTeam);
                //        }
                //    }
                //    else if (hitTest.RowIndex == -1)
                //    {
                //        var stage = dgvGrid.Columns[hitTest.ColumnIndex].Tag;
                //        if (stage != null)
                //        {
                //            var stageIsClosed = new MenuItem("Open/Close");
                //            stageIsClosed.Click += new EventHandler(stageIsClosed_Click);
                //            stageIsClosed.Tag = stage;
                //            m.MenuItems.Add(stageIsClosed);

                //            var editStage = new MenuItem("Редактировать этап");
                //            editStage.Click += new EventHandler(editStage_Click);
                //            editStage.Tag = stage;
                //            m.MenuItems.Add(editStage);

                //            var removeStage = new MenuItem("Удалить этап");
                //            removeStage.Click += new EventHandler(removeStage_Click);
                //            removeStage.Tag = stage;
                //            m.MenuItems.Add(removeStage);

                //            m.MenuItems.Add("-------");

                //            var addStage = new MenuItem("Добавить этап");
                //            addStage.Click += new EventHandler(addStage_Click);
                //            m.MenuItems.Add(addStage);
                //        }
                //    }
                //    else
                //    {
                //        var team = dgvGrid.Rows[hitTest.RowIndex].Tag as Team;
                //        var stage = dgvGrid.Columns[hitTest.ColumnIndex].Tag as Scene;
                //        if (team != null && stage != null)
                //        {
                //            var tag = new object[2] { team, stage };

                //            //var state = m_AI.GetState(stage, team);

                //            //var index = team.CurrentStages.BinarySearch(stage.ID);
                //            //if (index < 0)
                //            //{
                //            //    var sendTeam = new MenuItem("Отправить команду");
                //            //    sendTeam.Tag = tag;
                //            //    sendTeam.Click += new EventHandler(sendTeam_Click);
                //            //    m.MenuItems.Add(sendTeam);
                //            //}
                //            //else
                //            //{
                //            //    var stageClear = new MenuItem("Этап свободен");
                //            //    stageClear.Tag = tag;
                //            //    stageClear.Click += new EventHandler(stageClear_Click);
                //            //    m.MenuItems.Add(stageClear);
                //            //}

                //            m.MenuItems.Add("-------");

                //            var stagePass = new MenuItem("Пропустить");
                //            stagePass.Tag = tag;
                //            stagePass.Click += new EventHandler(stagePass_Click);
                //            m.MenuItems.Add(stagePass);

                //            var stageIncomplete = new MenuItem("Не пройден");
                //            stageIncomplete.Tag = tag;
                //            stageIncomplete.Click += new EventHandler(stageIncomplete_Click);
                //            m.MenuItems.Add(stageIncomplete);

                //            var stageCompleted = new MenuItem("Пройден");
                //            stageCompleted.Tag = tag;
                //            stageCompleted.Click += new EventHandler(stageCompleted_Click);
                //            m.MenuItems.Add(stageCompleted);
                //        }
                //    }
                if (m.MenuItems.Count > 0)
                {
                    m.Show(tvList, new Point(e.X, e.Y));
                }
            }
        }

        private object m_SelectedItem = null;

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = tvList.SelectedNode;
            m_SelectedItem = node.Tag;
            RefreshPropsPnl();
        }

        #endregion

        #region PropsActions

        private void btnTeamOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;
            team.Name = tbTeamName.Text;
            var group = m_AI.Groups.GetByName(cmbTeamGroup.Text);
            team.GroupID = (group == null) ? Guid.Empty : group.ID;

            UpdateData();
        }

        private void btnSceneOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var scene = m_SelectedItem as Scene;
            if (scene == null)
                return;
            scene.Number = tbSceneNumber.Text;
            var stage = m_AI.Stages.GetByName(cmbSceneStage.Text);
            scene.StageID = (stage == null) ? Guid.Empty : stage.ID;
            scene.Coach = tbSceneCoach.Text;
            UpdateData();
        }

        private void btnGroupOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var group = m_SelectedItem as Group;
            if (group == null)
                return;
            group.Name = tbGroupName.Text;
            group.ShortName = tbGroupShortName.Text;
            UpdateData();
        }

        private void btnStageOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var stage = m_SelectedItem as Stage;
            if (stage == null)
                return;
            stage.Name = tbStageName.Text;
            stage.ShortName = tbStageShortname.Text;
            foreach (var item in lvAcceptedGroups.Items)
            {
                var group = m_AI.Groups.GetByName(item.ToString());
                if (group != null)
                {
                    stage.AvailableGroups.Add(group.ID);
                }
            }
            UpdateData();
        }

        private void btnUnacceptAllGroups_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var stage = m_SelectedItem as Stage;
            if (stage == null)
                return;
            stage.AvailableGroups.Clear();

            RefreshStageGroups();
        }

        private void btnUnacceptGroup_Click(object sender, EventArgs e)
        {
            if (lvAcceptedGroups.SelectedIndex != -1)
            {
                lvAcceptedGroups.Items.RemoveAt(lvAcceptedGroups.SelectedIndex);

                if (m_SelectedItem == null)
                    return;
                var stage = m_SelectedItem as Stage;
                if (stage == null)
                    return;
                stage.AvailableGroups.Clear();
                foreach (var item in lvAcceptedGroups.Items)
                {
                    var group = m_AI.Groups.GetByName(item.ToString());
                    if (group != null)
                    {
                        stage.AvailableGroups.Add(group.ID);
                    }
                }
                RefreshStageGroups();
            }
        }

        private void btnAcceptGroup_Click(object sender, EventArgs e)
        {
            if (lvOtherGroups.SelectedIndex != -1)
            {
                lvAcceptedGroups.Items.Add(lvOtherGroups.Items[lvOtherGroups.SelectedIndex]);

                if (m_SelectedItem == null)
                    return;
                var stage = m_SelectedItem as Stage;
                if (stage == null)
                    return;
                stage.AvailableGroups.Clear();
                foreach (var item in lvAcceptedGroups.Items)
                {
                    var group = m_AI.Groups.GetByName(item.ToString());
                    if (group != null)
                    {
                        stage.AvailableGroups.Add(group.ID);
                    }
                }
                RefreshStageGroups();
            }
        }

        private void btnAcceptAllGroups_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var stage = m_SelectedItem as Stage;
            if (stage == null)
                return;

            stage.AvailableGroups.Clear();
            foreach (var group in m_AI.Groups.AllSorted)
            {
                stage.AvailableGroups.Add(group.ID);
            }
            RefreshStageGroups();
        }

        private void RefreshStageGroups()
        {
            if (m_SelectedItem == null)
                return;
            var stage = m_SelectedItem as Stage;
            if (stage == null)
                return;

            lvOtherGroups.Items.Clear();
            lvAcceptedGroups.Items.Clear();

            foreach (var group in m_AI.Groups.AllSorted)
            {
                if (stage.AvailableGroups.Contains(group.ID))
                {
                    lvAcceptedGroups.Items.Add(group.Name);
                }
                else
                {
                    lvOtherGroups.Items.Add(group.Name);
                }
            }
        }

        private void RefreshTeamStages()
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;

            int selectedIndex = -1;
            if (dgvStages.SelectedRows.Count > 0)
            {
                selectedIndex = dgvStages.SelectedRows[0].Index;
            }

            dgvStages.SelectionChanged -= dgvStages_SelectionChanged;
            dgvStages.Rows.Clear();
            foreach (var stage in m_AI.Stages.AllSorted)
            {
                var index = dgvStages.Rows.Add();
                var row = dgvStages.Rows[index];
                row.Cells[0].Value = stage.Name;
                row.Tag = stage;
                var res = team.StageState(stage.ID);

                string stageState;
                switch (res)
                {
                    case -1:
                        stageState = Resources.sStagePass;
                        break;
                    case 0:
                        stageState = Resources.sStageIncomplete;
                        break;
                    case 1:
                        stageState = Resources.sStageComplete;
                        break;
                    default:
                        stageState = "";
                        break;
                }
                row.Cells[1].Value = stageState;
                row.Cells[1].Tag = res;
            }

            if (selectedIndex >= 0)
            {
                dgvStages.ClearSelection();
                dgvStages.Rows[selectedIndex].Selected = true;
            }
            UpdateButtons();
            dgvStages.SelectionChanged += dgvStages_SelectionChanged;
        }

        private void btnStagePass_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var stage = row.Tag as Stage;
                if (stage != null)
                    team.PassStage(stage.ID);
                RefreshTeamStages();
                UpdateButtons();
            }
        }

        private void btnStageIncomplete_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var stage = row.Tag as Stage;
                if (stage != null)
                    team.IncompleteStage(stage.ID);
                RefreshTeamStages();
                UpdateButtons();
            }
        }

        private void btnStageComplete_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var stage = row.Tag as Stage;
                if (stage != null)
                {
                    team.CompleteStage(stage.ID);
                }
                RefreshTeamStages();
                UpdateButtons();
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;

            team.ClearStages();
            foreach (var stage in m_AI.Stages.All)
            {
                if (stage.AvailableGroups.Contains(team.GroupID))
                    team.IncompleteStage(stage.ID);
            }

            RefreshTeamStages();
            UpdateButtons();
        }

        private void dgvGrid_MouseDown(object sender, MouseEventArgs e)
        {
            m_LastMouseClick = new MouseClickMoveEvent()
            {
                Button = e.Button,
                MousePosition = e.Location,
                GridPosition = new Point(dgvGrid.HorizontalScrollingOffset, dgvGrid.VerticalScrollingOffset),
                FirstDisplayedRow = dgvGrid.FirstDisplayedScrollingRowIndex,
                SelectedCell = null
            };

            var test = dgvGrid.HitTest(m_LastMouseClick.MousePosition.X, m_LastMouseClick.MousePosition.Y);
            if (test.RowIndex >= 0 && test.ColumnIndex >= 0)
                m_LastMouseClick.SelectedCell = dgvGrid.Rows[test.RowIndex].Cells[test.ColumnIndex];

            dgvGrid.SuspendLayout();
        }

        private void dgvGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && m_LastMouseClick.Button == MouseButtons.Middle)
            {
                var startPos = m_LastMouseClick.MousePosition;
                var endPos = e.Location;

                var horOffs = startPos.X - endPos.X;
                var newHorPos = m_LastMouseClick.GridPosition.X + horOffs;
                dgvGrid.HorizontalScrollingOffset = (newHorPos > 0) ? newHorPos : 0;


                int vertOffs = (startPos.Y - endPos.Y) / RowHeight;
                var oldIndex = m_LastMouseClick.FirstDisplayedRow;
                dgvGrid.FirstDisplayedScrollingRowIndex = (oldIndex + vertOffs < 0) ? 0 : oldIndex + vertOffs;
            }
        }

        private void dgvGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_LastMouseClick.Button == MouseButtons.Middle && e.Button == MouseButtons.Middle)
            {
                UpdateData();
            }
            if (m_LastMouseClick.SelectedCell != null)
            {
                dgvGrid.CurrentCell = m_LastMouseClick.SelectedCell;
                m_LastMouseClick.SelectedCell.Selected = false;
            }
            //dgvGrid.CurrentCell = null;

            dgvGrid.ResumeLayout();
        }

        private void dgvGrid_SelectionChanged(object sender, EventArgs e)
        {
            FillLog();
        }

        #endregion

        private void cmbTeamGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_SelectedItem == null)
                return;
            var team = m_SelectedItem as Team;
            if (team == null)
                return;
            var group = m_AI.Groups.GetByName(cmbTeamGroup.Text);
            team.GroupID = (group == null) ? Guid.Empty : group.ID;

            RefreshTeamStages();
            UpdateButtons();
        }

        private void btnTeamShowLog_Click(object sender, EventArgs e)
        {
            var team = m_SelectedItem as Team;
            if (team != null)
            {
                var dlg = new TeamLogDlg();
                dlg.SetTeam(team);
                dlg.Show();
            }
        }
    }
}