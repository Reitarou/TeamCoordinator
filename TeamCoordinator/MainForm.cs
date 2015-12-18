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

            dgvGrid.Columns.Clear();
            dgvGrid.Rows.Clear();
            dgvGrid.ColumnHeadersHeight = 50;
            foreach (var scene in m_AI.Scenes)
            {
                var col = new DataGridViewTextBoxColumn();
                //col.Name = scene.Name;
                col.Tag = scene;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderText = string.Format("{0}\n{1}\n{2}", scene.Number, scene.Coach, "time here");
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
                    row.HeaderCell.Value = team.Name;
                    row.Height = 40;
                    if (team.CurrentStages.Count > 0)
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
                        var stage = col.Tag as Scene;
                        if (stage != null)
                        {
                            //var state = m_AI.GetState(stage, team);
                            //switch (state)
                            //{
                            //    case -1:
                            //        row.Cells[i].Style.BackColor = c_Gray;
                            //        break;
                            //    case 0:
                            //        row.Cells[i].Style.BackColor = c_Red;
                            //        break;
                            //    case 1:
                            //        row.Cells[i].Style.BackColor = c_Green;
                            //        break;
                            //}
                        }
                        //if (team.CurrentStages.Contains(stage.ID))
                        //{
                        //    row.Cells[i].Style.BackColor = c_Yellow;
                        //}
                    }
                }
            }
            dgvGrid.ClearSelection();

            #endregion

            #region Props

            tvList.Nodes.Clear();

            var coreNode = new TreeNode(c_Groups);
            coreNode.Tag = c_Groups;
            foreach (var item in m_AI.Groups)
            {
                var node = new TreeNode(item.Name);
                node.Tag = item;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);


            coreNode = new TreeNode(c_Stages);
            coreNode.Tag = c_Stages;
            foreach (var item in m_AI.Stages)
            {
                var node = new TreeNode(item.Name);
                node.Tag = item;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            coreNode = new TreeNode(c_Scenes);
            coreNode.Tag = c_Scenes;
            foreach (var item in m_AI.Scenes)
            {
                var node = new TreeNode(item.Number);
                node.Tag = item;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            coreNode = new TreeNode(c_Teams);
            coreNode.Tag = c_Teams;
            foreach (var item in m_AI.Teams)
            {
                var node = new TreeNode(item.Name);
                node.Tag = item;
                coreNode.Nodes.Add(node);
            }
            tvList.Nodes.Add(coreNode);

            #endregion

            m_AI.SaveToStg();
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
            if (e.Button == MouseButtons.Left)
            {
                dgvGrid.ClearSelection();
            }
            else if (e.Button == MouseButtons.Right)
            {
                var hitTest = dgvGrid.HitTest(e.X, e.Y);
                ContextMenu m = new ContextMenu();

                if (hitTest.ColumnIndex == -1 && hitTest.RowIndex == -1)
                {
                    var addTeam = new MenuItem("Добавить команду");
                    addTeam.Click += new EventHandler(addTeam_Click);
                    m.MenuItems.Add(addTeam);

                    var addStage = new MenuItem("Добавить этап");
                    addStage.Click += new EventHandler(addStage_Click);
                    m.MenuItems.Add(addStage);
                }
                else
                {
                    if (hitTest.ColumnIndex == -1)
                    {
                        var team = dgvGrid.Rows[hitTest.RowIndex].Tag;
                        if (team != null)
                        {
                            var teamIsReady = new MenuItem("Ready/Wait");
                            teamIsReady.Click += new EventHandler(teamIsReady_Click);
                            teamIsReady.Tag = team;
                            m.MenuItems.Add(teamIsReady);

                            var editTeam = new MenuItem("Редактировать команду");
                            editTeam.Click += new EventHandler(editTeam_Click);
                            editTeam.Tag = team;
                            m.MenuItems.Add(editTeam);

                            var removeTeam = new MenuItem("Удалить команду");
                            removeTeam.Click += new EventHandler(removeTeam_Click);
                            removeTeam.Tag = team;
                            m.MenuItems.Add(removeTeam);


                            m.MenuItems.Add("-------");
                            var addTeam = new MenuItem("Добавить команду");
                            addTeam.Click += new EventHandler(addTeam_Click);
                            m.MenuItems.Add(addTeam);
                        }
                    }
                    else if (hitTest.RowIndex == -1)
                    {
                        var stage = dgvGrid.Columns[hitTest.ColumnIndex].Tag;
                        if (stage != null)
                        {
                            var stageIsClosed = new MenuItem("Open/Close");
                            stageIsClosed.Click += new EventHandler(stageIsClosed_Click);
                            stageIsClosed.Tag = stage;
                            m.MenuItems.Add(stageIsClosed);

                            var editStage = new MenuItem("Редактировать этап");
                            editStage.Click += new EventHandler(editStage_Click);
                            editStage.Tag = stage;
                            m.MenuItems.Add(editStage);

                            var removeStage = new MenuItem("Удалить этап");
                            removeStage.Click += new EventHandler(removeStage_Click);
                            removeStage.Tag = stage;
                            m.MenuItems.Add(removeStage);

                            m.MenuItems.Add("-------");

                            var addStage = new MenuItem("Добавить этап");
                            addStage.Click += new EventHandler(addStage_Click);
                            m.MenuItems.Add(addStage);
                        }
                    }
                    else
                    {
                        var team = dgvGrid.Rows[hitTest.RowIndex].Tag as Team;
                        var stage = dgvGrid.Columns[hitTest.ColumnIndex].Tag as Scene;
                        if (team != null && stage != null)
                        {
                            var tag = new object[2] { team, stage };

                            //var state = m_AI.GetState(stage, team);

                            //var index = team.CurrentStages.BinarySearch(stage.ID);
                            //if (index < 0)
                            //{
                            //    var sendTeam = new MenuItem("Отправить команду");
                            //    sendTeam.Tag = tag;
                            //    sendTeam.Click += new EventHandler(sendTeam_Click);
                            //    m.MenuItems.Add(sendTeam);
                            //}
                            //else
                            //{
                            //    var stageClear = new MenuItem("Этап свободен");
                            //    stageClear.Tag = tag;
                            //    stageClear.Click += new EventHandler(stageClear_Click);
                            //    m.MenuItems.Add(stageClear);
                            //}

                            m.MenuItems.Add("-------");

                            var stagePass = new MenuItem("Пропустить");
                            stagePass.Tag = tag;
                            stagePass.Click += new EventHandler(stagePass_Click);
                            m.MenuItems.Add(stagePass);

                            var stageIncomplete = new MenuItem("Не пройден");
                            stageIncomplete.Tag = tag;
                            stageIncomplete.Click += new EventHandler(stageIncomplete_Click);
                            m.MenuItems.Add(stageIncomplete);

                            var stageCompleted = new MenuItem("Пройден");
                            stageCompleted.Tag = tag;
                            stageCompleted.Click += new EventHandler(stageCompleted_Click);
                            m.MenuItems.Add(stageCompleted);
                        }
                    }
                }
                if (m.MenuItems.Count > 0)
                {
                    m.Show(dgvGrid, new Point(e.X, e.Y));
                }
            }
        }

        void stageCompleted_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var tag = mi.Tag as object[];
            //    if (tag != null && tag.Length == 2)
            //    {
            //        var team = tag[0] as Team;
            //        var stage = tag[1] as Scene;

            //        if (team != null && stage != null)
            //        {
            //            if (team.Stages.ContainsKey(stage.Name))
            //            {
            //                team.Stages[stage.Name] = 1;
            //                UpdateData();
            //            }
            //        }
            //    }
            //}
        }

        void stageIncomplete_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var tag = mi.Tag as object[];
            //    if (tag != null && tag.Length == 2)
            //    {
            //        var team = tag[0] as Team;
            //        var stage = tag[1] as Scene;

            //        if (team != null && stage != null)
            //        {
            //            if (team.Stages.ContainsKey(stage.Name))
            //            {
            //                team.Stages[stage.Name] = 0;
            //                UpdateData();
            //            }
            //        }
            //    }
            //}
        }

        void stagePass_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var tag = mi.Tag as object[];
            //    if (tag != null && tag.Length == 2)
            //    {
            //        var team = tag[0] as Team;
            //        var stage = tag[1] as Scene;

            //        if (team != null && stage != null)
            //        {
            //            if (team.Stages.ContainsKey(stage.Name))
            //            {
            //                team.Stages[stage.Name] = -1;
            //                UpdateData();
            //            }
            //        }
            //    }
            //}
        }

        void stageClear_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var tag = mi.Tag as object[];
            //    if (tag != null && tag.Length == 2)
            //    {
            //        var team = tag[0] as Team;
            //        var stage = tag[1] as Scene;

            //        if (team != null && stage != null)
            //        {
            //            var index = team.CurrentStages.BinarySearch(stage.ID);
            //            if (index >= 0)
            //            {
            //                team.Stages[stage.Name] = 1;
            //                team.CurrentStages.RemoveAt(index);
            //                team.IsReady = false;
            //                UpdateData();
            //            }
            //        }
            //    }
            //}
        }

        void sendTeam_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var tag = mi.Tag as object[];
            //    if (tag != null && tag.Length == 2)
            //    {
            //        var team = tag[0] as Team;
            //        var stage = tag[1] as Scene;

            //        if (team != null && stage != null)
            //        {
            //            var index = team.CurrentStages.BinarySearch(stage.ID);
            //            if (index < 0)
            //            {
            //                team.CurrentStages.Insert(~index, stage.ID);
            //                UpdateData();
            //            }
            //        }
            //    }
            //}
        }


        void stageIsClosed_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var stage = mi.Tag as Scene;
            //    if (stage != null)
            //    {
            //        stage.IsClosed = !stage.IsClosed;
            //        UpdateData();
            //    }
            //}
        }

        void addStage_Click(object sender, EventArgs e)
        {
            //var stage = new Scene();
            //if (StageEditDlg.Execute(m_AI, stage))
            //{
            //    m_AI.AddStage(stage);
            //    UpdateData();
            //}
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

        void removeStage_Click(object sender, EventArgs e)
        {
            //var mi = sender as MenuItem;
            //if (mi != null)
            //{
            //    var stage = mi.Tag as Scene;
            //    if (stage != null)
            //    {
            //        m_AI.Stages.Remove(stage);
            //        UpdateData();
            //    }
            //}
        }


        void teamIsReady_Click(object sender, EventArgs e)
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
            }
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

        void removeTeam_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var team = mi.Tag as Team;
                if (team != null)
                {
                    m_AI.Teams.Remove(team);
                    UpdateData();
                }
            }
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

                var s = tag as string;
                if (s != null)
                {
                    switch (s)
                    {
                        case c_Teams:
                            var addTeam = new MenuItem("Добавить команду");
                            addTeam.Click += new EventHandler(addTeam_Click);
                            m.MenuItems.Add(addTeam);
                            break;

                    }
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

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var t = 1;
        }

        #endregion

        #region actions
        
        void addTeam_Click(object sender, EventArgs e)
        {
            var team = m_AI.AddTeam();
            UpdateData();
            if (tabControl.SelectedIndex == 0)
            {
                tabControl.SelectedIndex = 1;
            }

            for (int i = 0; i < tvList.Nodes.Count; i++)
            {
                var node = tvList.Nodes[i];
                var nodeCore = node.Tag as string;
                if (nodeCore != null && nodeCore == c_Teams)
                {
                    var coreNode = node;
                    for (int j = 0; j < coreNode.Nodes.Count; j++)
                    {
                        node = coreNode.Nodes[j];
                        var nodeTeam = node.Tag as Team;
                        if (nodeTeam != null && nodeTeam == team)
                        {
                            tvList.SelectedNode = node;
                            break;
                        }
                    }
                }
            }

            //var team = new Team();
            //if (TeamEditDlg.Execute(m_AI, team))
            //{
            //    m_AI.AddTeam(team);
            //    UpdateData();
            //}
        }

        #endregion

        


    }
}
