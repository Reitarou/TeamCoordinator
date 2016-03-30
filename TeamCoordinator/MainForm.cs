using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamCoordinator.Properties;
using System.Xml.Linq;
using System.IO;

namespace TeamCoordinator
{
    public partial class MainForm : Form
    {
        private Color c_Green = Color.FromArgb(120, 255, 120);
        private Color c_Yellow = Color.FromArgb(255, 160, 0);
        private Color c_Red = Color.FromArgb(255, 120, 120);
        private Color c_Violet = Color.FromArgb(230, 100, 230);
        private Color c_Gray = Color.FromArgb(180, 180, 180);

        private const string c_Groups = "Группы";
        private const string c_Stages = "Этапы";
        private const string c_Scenes = "Сцены";
        private const string c_Teams = "Команды";

        private AI m_AI;

        public MainForm()
        {
            InitializeComponent();
            m_AI = new AI(null);

            pnlTeamProps.Location = new Point(3, 3);
            pnlSceneProps.Location = new Point(3, 3);
            pnlGroupProps.Location = new Point(3, 3);
            pnlStageProps.Location = new Point(3, 3);
            pnlProps.Width = 324;
            pnlProps.Left = Width - pnlProps.Width - 24;
            tvList.Width = pnlProps.Left - 12;
            Width = 750;


            UpdateData();
        }

        private void UpdateData()
        {
            this.Text = m_AI.FileName;
            if (!m_AI.Valid)
            {
                return;
            }

            //m_AI.CheckTeams();

            #region Grid

            Point selectedCell = new Point(-1, -1);
            int firstRow = dgvGrid.FirstDisplayedScrollingRowIndex;
            int horizontalScroll = dgvGrid.HorizontalScrollingOffset;

            //if (dgvGrid.CurrentCell != null)
            //{
            //    selectedCell = new Point(dgvGrid.CurrentCell.RowIndex, dgvGrid.CurrentCell.ColumnIndex);
            //}

            dgvGrid.Columns.Clear();
            dgvGrid.Rows.Clear();
            dgvGrid.ColumnHeadersHeight = 60;
            foreach (var scene in m_AI.Scenes)
            {
                var stage = m_AI.GetStageByID(scene.StageID);
                if (stage == null) continue;
                var stageName = (stage.ShortName == "") ? stage.Name : stage.ShortName;
                string sceneName = (scene.Number == "") ? stageName : string.Format("{0} - {1}", stageName, scene.Number);

                var col = new DataGridViewTextBoxColumn();
                col.Name = scene.ID;
                col.Tag = scene;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                var sceneTime = scene.ChangeStateTime;
                var lastMins = Math.Truncate((DateTime.Now - scene.ChangeStateTime).TotalMinutes);
                var lastSecs = Math.Truncate((DateTime.Now - scene.ChangeStateTime).TotalSeconds) - (60 * lastMins);

                col.HeaderText = string.Format("{0}\n{1}\n{2}\n(+{3}:{4})", sceneName, scene.Coach, 
                    sceneTime.ToShortTimeString(), lastMins, lastSecs);

                col.HeaderCell.Style.BackColor = (scene.IsReady) ? c_Green : c_Red;
                foreach (var team in m_AI.Teams)
                {
                    if (team.CurrentScene == scene.ID)
                    {
                        col.HeaderCell.Style.BackColor = c_Yellow;
                        break;
                    }
                }

                //var state = m_AI.GetStageState(stage);
                //if (state == null)
                //{
                //    col.HeaderCell.Style.BackColor = c_Red;
                //}
                //else if (state.Count == 0)
                //{
                //    col.HeaderCell.Style.BackColor = c_Green;
                //}
                //else
                //{
                //    col.HeaderCell.Style.BackColor = c_Yellow;
                //}
                //col.HeaderCell.ToolTipText = scene.Name;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = 80;
                dgvGrid.Columns.Add(col);
            }
            if (dgvGrid.Columns.Count > 0)
            {
                foreach (var team in m_AI.Teams)
                {
                    var row = new DataGridViewRow();
                    row.Tag = team;
                    row.HeaderCell.Value = string.Format("{0}\n{1} - {2}", team.Name, team.CompleteStages, team.IncompleteStages);
                    row.Height = 40;
                    if (team.CurrentScene != "")
                    {
                        row.HeaderCell.Style.BackColor = c_Yellow;
                    }
                    else
                    {
                        if (team.IsReady)
                        {
                            row.HeaderCell.Style.BackColor = c_Green;
                        }
                        else
                        {
                            row.HeaderCell.Style.BackColor = c_Red;
                        }
                    }

                    dgvGrid.Rows.Add(row);

                    for (int i = 0; i < dgvGrid.Columns.Count; i++)
                    {
                        var col = dgvGrid.Columns[i];
                        var scene = col.Tag as Scene;
                        if (scene != null)
                        {
                            switch (m_AI.GetState(team, scene))
                            {
                                case -1:
                                    row.Cells[i].Style.BackColor = c_Gray;
                                    break;
                                case 0:
                                    row.Cells[i].Style.BackColor = c_Red;
                                    break;
                                case 1:
                                    row.Cells[i].Style.BackColor = c_Yellow;
                                    break;
                                case 2:
                                    row.Cells[i].Style.BackColor = c_Green;
                                    break;
                            }
                        }
                    }
                }
            }
            dgvGrid.ClearSelection();
            //if (selectedCell.X != -1 && selectedCell.Y != -1)
            //{
            //    dgvGrid.CurrentCell = dgvGrid.Rows[selectedCell.X].Cells[selectedCell.Y];
            //    dgvGrid.CurrentCell.Selected = false;
            //}
            dgvGrid.HorizontalScrollingOffset = horizontalScroll;
            if (firstRow != -1) dgvGrid.FirstDisplayedScrollingRowIndex = firstRow;

            #endregion

            #region Props

            var teamsExpanded = (tvList.Nodes[c_Teams] != null) ? tvList.Nodes[c_Teams].IsExpanded : false;
            var scenesExpanded = (tvList.Nodes[c_Scenes] != null) ? tvList.Nodes[c_Scenes].IsExpanded : false;
            var groupsExpanded = (tvList.Nodes[c_Groups] != null) ? tvList.Nodes[c_Groups].IsExpanded : false;
            var stagesExpanded = (tvList.Nodes[c_Stages] != null) ? tvList.Nodes[c_Stages].IsExpanded : false;

            tvList.Nodes.Clear();

            TreeNode coreNode;

            coreNode = new TreeNode(c_Teams);
            coreNode.Name = c_Teams;
            coreNode.Tag = c_Teams;
            foreach (var item in m_AI.Teams)
            {
                string s = "";
                var group = m_AI.GetGroupByID(item.GroupID);
                if (group != null)
                {
                    s = (group.ShortName != "") ? group.ShortName : group.Name;
                }
                var node = new TreeNode(string.Format("{0} ({1})", item.Name, s));
                node.Name = item.ID;
                node.Tag = item;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);
            
            coreNode = new TreeNode(c_Scenes);
            coreNode.Name = c_Scenes;
            coreNode.Tag = c_Scenes;
            foreach (var item in m_AI.Scenes)
            {
                string s = "";
                var stage = m_AI.GetStageByID(item.StageID);
                if (stage != null)
                {
                    s = (stage.ShortName != "") ? stage.ShortName : stage.Name;
                }
                var node = new TreeNode((item.Number == "") ? s : string.Format("{0} - {1}", s, item.Number));
                node.Tag = item;
                node.Name = item.ID;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);
            
            coreNode = new TreeNode(c_Groups);
            coreNode.Name = c_Groups;
            coreNode.Tag = c_Groups;
            foreach (var item in m_AI.Groups)
            {
                var node = new TreeNode(item.Name);
                node.Tag = item;
                node.Name = item.ID;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);
            
            coreNode = new TreeNode(c_Stages);
            coreNode.Name = c_Stages;
            coreNode.Tag = c_Stages;
            foreach (var item in m_AI.Stages)
            {
                var node = new TreeNode((item.ShortName == "") ? item.Name : string.Format("{0} ({1})", item.Name, item.ShortName));
                node.Tag = item;
                node.Name = item.ID;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            if (teamsExpanded) tvList.Nodes[c_Teams].Expand();
            if (scenesExpanded) tvList.Nodes[c_Scenes].Expand();
            if (groupsExpanded) tvList.Nodes[c_Groups].Expand();
            if (stagesExpanded) tvList.Nodes[c_Stages].Expand();

            if (m_SelectedItem != null)
            {
                var nodes = tvList.Nodes.Find(m_SelectedItem.ToString(), true);
                if (nodes.Length > 0)
                {
                    tvList.SelectedNode = nodes[0];
                }
            }

            RefreshPropsPnl();

            #endregion

            m_AI.SaveToStg();
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
                    cmbTeamGroup.Items.Clear();
                    int selectedGroup = 0;
                    for (int i = 0; i < m_AI.Groups.Count; i++)
                    {
                        var aiGroup = m_AI.Groups[i];
                        cmbTeamGroup.Items.Add(aiGroup.Name);
                        if (aiGroup.ID == team.GroupID)
                        {
                            selectedGroup = i;
                        }
                    }
                    if (cmbTeamGroup.Items.Count > 0)
                    {
                        cmbTeamGroup.SelectedIndex = selectedGroup;
                    }

                    RefreshTeamStages();                   

                    pnlTeamProps.Visible = true;
                    return;
                }

                var scene = m_SelectedItem as Scene;
                if (scene != null)
                {
                    tbSceneNumber.Text = scene.Number;

                    cmbSceneStage.Items.Clear();
                    int selectedStage = 0;
                    for (int i = 0; i < m_AI.Stages.Count; i++)
                    {
                        var aiStage = m_AI.Stages[i];
                        cmbSceneStage.Items.Add(aiStage.Name);
                        if (aiStage.ID == scene.StageID)
                        {
                            selectedStage = i;
                        }
                    }
                    if (cmbSceneStage.Items.Count > 0)
                    {
                        cmbSceneStage.SelectedIndex = selectedStage;
                    }

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

        private void miEditMode_Click(object sender, EventArgs e)
        {
            //if (m_AI.Valid)
            //{
            //    m_EditMode = !m_EditMode;
            //    UpdateControls();
            //}
        }

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
                new XElement("Groups")));
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

        private void miEditGroups_Click(object sender, EventArgs e)
        {
            if (m_AI.Valid)
            {
                if (GroupsEditDlg.Execute(m_AI))
                {
                    UpdateData();
                }
            }
        }

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

                if (hitTest.ColumnIndex == -1 && hitTest.RowIndex == -1)
                {
                    mi = new MenuItem("Обновить");
                    mi.Click += new EventHandler(refresh_Click);
                    m.MenuItems.Add(mi);

                    mi = new MenuItem("--------");
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
                else
                {
                    if (hitTest.ColumnIndex == -1)
                    {
                        var team = dgvGrid.Rows[hitTest.RowIndex].Tag;
                        if (team != null)
                        {
                            mi = new MenuItem("Ready/Wait");
                            mi.Click += new EventHandler(changeReadyState_Click);
                            mi.Tag = team;
                            m.MenuItems.Add(mi);

                            var editTeam = new MenuItem("Редактировать команду");
                            editTeam.Click += new EventHandler(editTeam_Click);
                            editTeam.Tag = team;
                            m.MenuItems.Add(editTeam);

                            mi = new MenuItem("Удалить команду");
                            mi.Click += new EventHandler(removeItem_Click);
                            mi.Tag = team;
                            m.MenuItems.Add(mi);

                            m.MenuItems.Add("-------");

                            mi = new MenuItem("Добавить команду");
                            mi.Click += new EventHandler(addItem_Click);
                            mi.Tag = new Team(m_AI);
                            m.MenuItems.Add(mi);
                        }
                    }
                    else if (hitTest.RowIndex == -1)
                    {
                        var stage = dgvGrid.Columns[hitTest.ColumnIndex].Tag;
                        if (stage != null)
                        {
                            mi = new MenuItem("Open/Close");
                            mi.Click += new EventHandler(changeReadyState_Click);
                            mi.Tag = stage;
                            m.MenuItems.Add(mi);

                            var editStage = new MenuItem("Редактировать сцену");
                            editStage.Click += new EventHandler(editStage_Click);
                            editStage.Tag = stage;
                            m.MenuItems.Add(editStage);

                            mi = new MenuItem("Удалить сцену");
                            mi.Click += new EventHandler(removeItem_Click);
                            mi.Tag = stage;
                            m.MenuItems.Add(mi);

                            m.MenuItems.Add("-------");

                            mi = new MenuItem("Добавить сцену");
                            mi.Click += new EventHandler(addItem_Click);
                            mi.Tag = new Scene(m_AI);
                            m.MenuItems.Add(mi);
                        }
                    }
                    else
                    {
                        var team = dgvGrid.Rows[hitTest.RowIndex].Tag as Team;
                        var scene = dgvGrid.Columns[hitTest.ColumnIndex].Tag as Scene;
                        if (team != null && scene != null)
                        {
                            var tag = new object[2] { team, scene };

                            var sendTeam = new MenuItem("Отправить команду");
                            sendTeam.Tag = tag;
                            sendTeam.Click += new EventHandler(sendTeam_Click);

                            var stageClear = new MenuItem("Этап свободен");
                            stageClear.Tag = tag;
                            stageClear.Click += new EventHandler(stageClear_Click);

                            var spacer = new MenuItem("--------");

                            var stagePass = new MenuItem("Пропустить");
                            stagePass.Tag = tag;
                            stagePass.Click += new EventHandler(stagePass_Click);

                            var stageIncomplete = new MenuItem("Не пройден");
                            stageIncomplete.Tag = tag;
                            stageIncomplete.Click += new EventHandler(stageIncomplete_Click);

                            var stageCompleted = new MenuItem("Пройден");
                            stageCompleted.Tag = tag;
                            stageCompleted.Click += new EventHandler(stageCompleted_Click);

                            var state = m_AI.GetState(team, scene);
                            switch(state)
                            {
                                case -1:
                                    m.MenuItems.Add(stageIncomplete);
                                    m.MenuItems.Add(stageCompleted);
                                    break;
                                case 0:
                                    if (scene.IsReady && team.IsReady)
                                    {
                                        m.MenuItems.Add(sendTeam);
                                        m.MenuItems.Add(spacer);
                                    }
                                    m.MenuItems.Add(stagePass);
                                    m.MenuItems.Add(stageCompleted);
                                    break;
                                case 1:
                                    m.MenuItems.Add(stageClear);
                                    m.MenuItems.Add(spacer);
                                    m.MenuItems.Add(stagePass);
                                    m.MenuItems.Add(stageIncomplete);
                                    m.MenuItems.Add(stageCompleted);
                                    break;
                                case 2:
                                    m.MenuItems.Add(stagePass);
                                    m.MenuItems.Add(stageIncomplete);
                                    break;

                            }
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

        #region actions

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

                var team = mi.Tag as Team;
                if (team != null)
                {
                    m_AI.Teams.Add(team);
                }
                var scene = mi.Tag as Scene;
                if (scene != null)
                {
                    m_AI.Scenes.Add(scene);
                }
                var group = mi.Tag as Group;
                if (group != null)
                {
                    m_AI.Groups.Add(group);
                }
                var stage = mi.Tag as Stage;
                if (stage != null)
                {
                    m_AI.Stages.Add(stage);
                }

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
                if (!(mi.Tag is Item))
                {
                    return;
                }
                var team = mi.Tag as Team;
                if (team != null)
                {
                    m_AI.Teams.Remove(team);
                }
                var scene = mi.Tag as Scene;
                if (scene != null)
                {
                    m_AI.Scenes.Remove(scene);
                }
                var group = mi.Tag as Group;
                if (group != null)
                {
                    m_AI.Groups.Remove(group);
                }
                var stage = mi.Tag as Stage;
                if (stage != null)
                {
                    m_AI.Stages.Remove(stage);
                }
                m_SelectedItem = null;
                UpdateData();
            }
        }

        void changeReadyState_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var team = mi.Tag as Team;
                if (team != null)
                {
                    team.IsReady = !team.IsReady;
                    UpdateData();
                }
                var scene = mi.Tag as Scene;
                if (scene != null)
                {
                    scene.IsReady = !scene.IsReady;
                    scene.ChangeStateTime = DateTime.Now;
                    UpdateData();
                }
            }
        }


        void sendTeam_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (GetPairFromTag(sender, out team, out scene))
            {
                team.CurrentScene = scene.ID;
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        void stageClear_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (GetPairFromTag(sender, out team, out scene))
            {
                team.Stages[scene.StageID] = 1;
                team.CurrentScene = "";
                team.IsReady = false;
                scene.ChangeStateTime = DateTime.Now;
                UpdateData();
            }
        }

        void stagePass_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (GetPairFromTag(sender, out team, out scene))
            {
                team.Stages[scene.StageID] = -1;
                team.CurrentScene = "";
                UpdateData();
            }
        }

        void stageIncomplete_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (GetPairFromTag(sender, out team, out scene))
            {
                team.Stages[scene.StageID] = 0;
                team.CurrentScene = "";
                UpdateData();
            }
        }

        void stageCompleted_Click(object sender, EventArgs e)
        {
            Team team;
            Scene scene;
            if (GetPairFromTag(sender, out team, out scene))
            {
                team.Stages[scene.StageID] = 1;
                team.CurrentScene = "";
                UpdateData();
            }
        }

        private bool GetPairFromTag(object sender, out Team team, out Scene scene)
        {
            team = null;
            scene = null;
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    team = tag[0] as Team;
                    scene = tag[1] as Scene;

                    if (team != null && scene != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        private void btnTeamOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var team = m_SelectedItem as Team;
            if (team == null) return;
            team.Name = tbTeamName.Text;
            var group = m_AI.GetGroupByName(cmbTeamGroup.Text);
            team.GroupID = (group == null) ? "" : group.ID;

            UpdateData();
        }

        private void btnSceneOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var scene = m_SelectedItem as Scene;
            if (scene == null) return;
            scene.Number = tbSceneNumber.Text;
            var stage = m_AI.GetStageByName(cmbSceneStage.Text);
            scene.StageID = (stage == null) ? "" : stage.ID;
            UpdateData();
        }

        private void btnGroupOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var group = m_SelectedItem as Group;
            if (group == null) return;
            group.Name = tbGroupName.Text;
            group.ShortName = tbGroupShortName.Text;
            UpdateData();
        }

        private void btnStageOk_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var stage = m_SelectedItem as Stage;
            if (stage == null) return;
            stage.Name = tbStageName.Text;
            stage.ShortName = tbStageShortname.Text;
            foreach (var item in lvAcceptedGroups.Items)
            {
                var group = m_AI.GetGroupByName(item.ToString());
                if (group != null)
                {
                    stage.AvailableGroups.Add(group.ID);
                }
            }
            UpdateData();
        }

        private void btnUnacceptAllGroups_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var stage = m_SelectedItem as Stage;
            if (stage == null) return;
            stage.AvailableGroups.Clear();

            RefreshStageGroups();
        }

        private void btnUnacceptGroup_Click(object sender, EventArgs e)
        {
            if (lvAcceptedGroups.SelectedIndex != -1)
            {
                lvAcceptedGroups.Items.RemoveAt(lvAcceptedGroups.SelectedIndex);

                if (m_SelectedItem == null) return;
                var stage = m_SelectedItem as Stage;
                if (stage == null) return;
                stage.AvailableGroups.Clear();
                foreach (var item in lvAcceptedGroups.Items)
                {
                    var group = m_AI.GetGroupByName(item.ToString());
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

                if (m_SelectedItem == null) return;
                var stage = m_SelectedItem as Stage;
                if (stage == null) return;
                stage.AvailableGroups.Clear();
                foreach (var item in lvAcceptedGroups.Items)
                {
                    var group = m_AI.GetGroupByName(item.ToString());
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
            if (m_SelectedItem == null) return;
            var stage = m_SelectedItem as Stage;
            if (stage == null) return;

            stage.AvailableGroups.Clear();
            foreach (var group in m_AI.Groups)
            {
                stage.AvailableGroups.Add(group.ID);
            }
            RefreshStageGroups();
        }

        private void RefreshStageGroups()
        {
            if (m_SelectedItem == null) return;
            var stage = m_SelectedItem as Stage;
            if (stage == null) return;

            lvOtherGroups.Items.Clear();
            lvAcceptedGroups.Items.Clear();

            foreach(var group in m_AI.Groups)
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
            if (m_SelectedItem == null) return;
            var team = m_SelectedItem as Team;
            if (team == null) return;

            int selectedIndex = -1;
            if (dgvStages.SelectedRows.Count > 0)
            {
                selectedIndex = dgvStages.SelectedRows[0].Index;
            }

            dgvStages.SelectionChanged -= dgvStages_SelectionChanged;
            dgvStages.Rows.Clear();
            foreach (var stage in m_AI.Stages)
            {
                var index = dgvStages.Rows.Add();
                var row = dgvStages.Rows[index];
                row.Cells[0].Value = stage.Name;
                row.Tag = stage;
                int res = -1;
                if (team.Stages.ContainsKey(stage.ID))
                {
                    res = team.Stages[stage.ID];
                }
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
            if (m_SelectedItem == null) return;
            var team = m_SelectedItem as Team;
            if (team == null) return;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var stage = row.Tag as Stage;
                if (stage != null)
                {
                    if (!team.Stages.ContainsKey(stage.ID))
                    {
                        team.Stages.Add(stage.ID, -1);
                    }
                    else
                    {
                        team.Stages[stage.ID] = -1;
                    }
                }
                RefreshTeamStages();
                UpdateButtons();
            }
        }

        private void btnStageIncomplete_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var team = m_SelectedItem as Team;
            if (team == null) return;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var stage = row.Tag as Stage;
                if (stage != null)
                {
                    if (!team.Stages.ContainsKey(stage.ID))
                    {
                        team.Stages.Add(stage.ID, 0);
                    }
                    else
                    {
                        team.Stages[stage.ID] = 0;
                    }
                }
                RefreshTeamStages();
                UpdateButtons();
            }
        }

        private void btnStageComplete_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var team = m_SelectedItem as Team;
            if (team == null) return;

            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var stage = row.Tag as Stage;
                if (stage != null)
                {
                    if (!team.Stages.ContainsKey(stage.ID))
                    {
                        team.Stages.Add(stage.ID, 1);
                    }
                    else
                    {
                        team.Stages[stage.ID] = 1;
                    }
                }
                RefreshTeamStages();
                UpdateButtons();
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (m_SelectedItem == null) return;
            var team = m_SelectedItem as Team;
            if (team == null) return;

            team.Stages.Clear();
            foreach (var stage in m_AI.Stages)
            {
                team.Stages.Add(stage.ID, (stage.AvailableGroups.Contains(team.GroupID)) ? 0 : -1);
            }

            RefreshTeamStages();
            UpdateButtons();
        }
    }
}
