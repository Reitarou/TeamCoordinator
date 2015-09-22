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

            m_AI.CheckTeams();

            miEditMode.Text = "";

            //var cSize = 32; //размер кнопок контролов

            #region Stages
            //panelStages.Controls.Clear();
            //Panel panel;
            //PictureBox ImgControl;


            //var minWidth = 200;
            //var columns = (int)(panelStages.Width / minWidth);

            //int x = 8, y = 8;
            //var stages = m_AI.Stages;

            //for (int i = 0; i < stages.Count; i++)
            //{
            //    var stage = stages[i];

            //    panel = new Panel();
            //    panel.Location = new Point(x, y);
            //    panel.Width = (panelStages.Width - (8 * (columns + 1))) / columns;
            //    panel.Height = 8 * 4 + 32 * 3;

            //    var font = new Font("TimesNewRoman", 10f);

            //    var nameLabel = new Label();
            //    nameLabel.Font = font;
            //    nameLabel.Text = string.Format(Resources.sStageHeader, stage.Number, stage.Name, stage.Coach);
            //    nameLabel.Size = new Size(panel.Width - 2 * 8 - cSize, (int)(font.Size * 2));
            //    nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            //    nameLabel.Location = new Point(8, 8);
            //    panel.Controls.Add(nameLabel);

            //    var groupsLabel = new Label();
            //    groupsLabel.Font = font;
            //    var s = "";
            //    foreach (var avstage in stage.AvaliableGroups)
            //    {
            //        var group = m_AI.GetGroup(avstage);
            //        if (group != null)
            //        {
            //            s += group.ShortName + ", ";
            //        }
            //    }
            //    if (s.Length > 0)
            //    {
            //        s = s.Remove(s.Length - 2);
            //    }
            //    groupsLabel.Text = s;
            //    groupsLabel.Size = new Size(panel.Width - 2 * 8 - cSize, (int)(font.Size * 2));
            //    groupsLabel.TextAlign = ContentAlignment.MiddleCenter;
            //    groupsLabel.Location = new Point(8, panel.Height - (8 + (int)(font.Size * 2)) * 2);
            //    panel.Controls.Add(groupsLabel);

            //    var stateLabel = new Label();
            //    stateLabel.Font = font;
            //    stateLabel.Text = m_AI.GetStageState(stage);
            //    stateLabel.Size = new Size(panel.Width - 2 * 8 - cSize, (int)(font.Size * 2));
            //    stateLabel.TextAlign = ContentAlignment.MiddleCenter;
            //    stateLabel.Location = new Point(8, panel.Height - (8 + (int)(font.Size * 2)));
            //    panel.Controls.Add(stateLabel);

            //    panel.BackColor = c_Green;
            //    //if (m_EditMode)
            //    //{
            //    //    panel.BackColor = c_Violet;
            //    //}
            //    //else
            //    //{
            //    //    if (stage.IsClosed)
            //    //    {
            //    //        panel.BackColor = c_Red;
            //    //    }
            //    //    else
            //    //    {
            //    //        if (stateLabel.Text == Resources.sStageFree)
            //    //        {
            //    //            panel.BackColor = c_Green;
            //    //        }
            //    //        else
            //    //        {
            //    //            panel.BackColor = c_Yellow;
            //    //        }
            //    //    }
            //    //}

            //    //if (m_EditMode)
            //    //{
            //    int imgY = 8;
            //    ImgControl = new PictureBox();
            //    ImgControl.Size = new Size(16, 16);
            //    ImgControl.Image = Resources.Settings;
            //    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
            //    ImgControl.Tag = stage;
            //    ImgControl.MouseClick += EditStage_MouseClick;
            //    panel.Controls.Add(ImgControl);
            //    imgY += (int)(ImgControl.Height * 0.5 + 8);

            //    ImgControl = new PictureBox();
            //    ImgControl.Size = new Size(16, 16);
            //    ImgControl.Image = Resources.Remove;
            //    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
            //    ImgControl.Tag = stage;
            //    ImgControl.MouseClick += RemoveStage_MouseClick;
            //    panel.Controls.Add(ImgControl);
            //    imgY += (int)(ImgControl.Height * 0.5 + 8);
            //    //}
            //    //else
            //    //{
            //    //ImgControl = new PictureBox();
            //    //ImgControl.Size = new Size(32, 32);
            //    ////ImgControl.Image = Resources.ArrowLeft;
            //    //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8);
            //    //ImgControl.Enabled = false;
            //    ////ImgControl.Tag = stage;
            //    ////ImgControl.MouseClick += Stage_MouseClick;
            //    //panel.Controls.Add(ImgControl);

            //    //ImgControl = new PictureBox();
            //    //ImgControl.Size = new Size(32, 32);
            //    ////ImgControl.Image = Resources.ArrowRight;
            //    //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8 + 32 + 8);
            //    //ImgControl.Enabled = false;
            //    ////ImgControl.Tag = stage;
            //    ////ImgControl.MouseClick += Stage_MouseClick;
            //    //panel.Controls.Add(ImgControl);
            //    //}
            //    panelStages.Controls.Add(panel);

            //    if ((i + 1) % columns != 0)
            //    {
            //        x += 8 + panel.Width;
            //    }
            //    else
            //    {
            //        y += 8 + panel.Height;
            //        x = 8;
            //    }
            //}
            ////if (m_EditMode)
            ////{
            //panel = new Panel();
            //panel.Location = new Point(x, y);
            //panel.Width = (panelStages.Width - (8 * (columns + 1))) / columns;
            //panel.Height = 8 * 4 + 32 * 3;

            //panel.BackColor = c_Violet;

            //ImgControl = new PictureBox();
            //ImgControl.Size = new Size(16, 16);
            //ImgControl.Image = Resources.Add;
            //ImgControl.Location = new Point((int)(panel.Width * 0.5 - ImgControl.Height * 0.5), (int)(panel.Height * 0.5 - ImgControl.Height * 0.5));
            //ImgControl.MouseClick += AddStage_MouseClick;
            //panel.Controls.Add(ImgControl);

            //panel.MouseClick += AddStage_MouseClick;

            //panelStages.Controls.Add(panel);
            //}

            #endregion

            #region Teams
            //panelTeams.Controls.Clear();

            //minWidth = 300;
            //columns = (int)(panelTeams.Width / minWidth);
            //x = 8;
            //y = 8;
            //var teams = m_AI.Teams;

            //for (int i = 0; i < teams.Count; i++)
            //{
            //    var team = teams[i];

            //    var panel = new Panel();
            //    panel.Location = new Point(x, y);
            //    panel.Width = (panelTeams.Width - (8 * (columns + 1))) / columns;
            //    panel.Height = 8 * 4 + 32 * 3;

            //    var font = new Font("TimesNewRoman", 10f);

            //    var nameLabel = new Label();
            //    nameLabel.Font = font;
            //    nameLabel.Text = team.Name;
            //    nameLabel.Size = new Size(panel.Width - 8 - 32 - 8, (int)font.Size + 4);
            //    nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            //    nameLabel.Location = new Point(8, 8);
            //    panel.Controls.Add(nameLabel);

            //    var descriptionLabel = new Label();
            //    descriptionLabel.Font = font;
            //    descriptionLabel.AutoSize = true;
            //    descriptionLabel.Location = new Point(8, 28);
            //    panel.Controls.Add(descriptionLabel);

            //    if (m_EditMode)
            //    {
            //        panel.BackColor = c_Violet;
            //    }
            //    else
            //    {
            //        if (team.CurrentStage == -1)
            //        {
            //            panel.BackColor = c_Red;
            //        }
            //        else
            //        {
            //            if (team.IsReady)
            //            {
            //                panel.BackColor = c_Green;
            //            }
            //            else
            //            {
            //                panel.BackColor = c_Yellow;
            //            }
            //        }
            //    }

            //    PictureBox ImgControl;

            //    if (m_EditMode)
            //    {
            //        int imgY = 8;
            //        ImgControl = new PictureBox();
            //        ImgControl.Size = new Size(16, 16);
            //        ImgControl.Image = Resources.Settings;
            //        ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
            //        ImgControl.Tag = team;
            //        ImgControl.MouseClick += EditTeam_MouseClick;
            //        panel.Controls.Add(ImgControl);
            //        imgY += (int)(ImgControl.Height * 0.5 + 8);

            //        ImgControl = new PictureBox();
            //        ImgControl.Size = new Size(16, 16);
            //        ImgControl.Image = Resources.Remove;
            //        ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
            //        ImgControl.Tag = team;
            //        ImgControl.MouseClick += RemoveTeam_MouseClick;
            //        panel.Controls.Add(ImgControl);
            //        imgY += (int)(ImgControl.Height * 0.5 + 8);
            //    }
            //    else
            //    {
            //        //ImgControl = new PictureBox();
            //        //ImgControl.Size = new Size(32, 32);
            //        ////ImgControl.Image = Resources.ArrowLeft;
            //        //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8);
            //        //ImgControl.Enabled = false;
            //        ////ImgControl.Tag = stage;
            //        ////ImgControl.MouseClick += Stage_MouseClick;
            //        //panel.Controls.Add(ImgControl);

            //        //ImgControl = new PictureBox();
            //        //ImgControl.Size = new Size(32, 32);
            //        ////ImgControl.Image = Resources.ArrowRight;
            //        //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8 + 32 + 8);
            //        //ImgControl.Enabled = false;
            //        ////ImgControl.Tag = stage;
            //        ////ImgControl.MouseClick += Stage_MouseClick;
            //        //panel.Controls.Add(ImgControl);
            //    }
            //    panelTeams.Controls.Add(panel);

            //    if ((i + 1) % columns != 0)
            //    {
            //        x += 8 + panel.Width;
            //    }
            //    else
            //    {
            //        y += 8 + panel.Height;
            //        x = 8;
            //    }
            //}

            //if (m_EditMode)
            //{
            //    var panel = new Panel();
            //    panel.Location = new Point(x, y);
            //    panel.Width = (panelTeams.Width - (8 * (columns + 1))) / columns;
            //    panel.Height = 8 * 4 + 32 * 3;

            //    panel.BackColor = c_Violet;

            //    PictureBox ImgControl;

            //    ImgControl = new PictureBox();
            //    ImgControl.Size = new Size(16, 16);
            //    ImgControl.Image = Resources.Add;
            //    ImgControl.Location = new Point((int)(panel.Width * 0.5 - ImgControl.Height * 0.5), (int)(panel.Height * 0.5 - ImgControl.Height * 0.5));
            //    ImgControl.MouseClick += AddTeam_MouseClick;
            //    panel.Controls.Add(ImgControl);

            //    panel.MouseClick += AddTeam_MouseClick;

            //    panelTeams.Controls.Add(panel);
            //}

            #endregion

            #region Grid

            dgvGrid.Columns.Clear();
            dgvGrid.Rows.Clear();
            foreach (var stage in m_AI.Stages)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = stage.Name;
                col.Tag = stage;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderText = string.Format("{0} [{1}]", stage.Number, stage.Coach);
                var state = m_AI.GetStageState(stage);
                if (state == null)
                {
                    col.HeaderCell.Style.BackColor = c_Red;
                }
                else if (state.Count == 0)
                {
                    col.HeaderCell.Style.BackColor = c_Green;
                }
                else
                {
                    col.HeaderCell.Style.BackColor = c_Yellow;
                }
                col.HeaderCell.ToolTipText = stage.Name;
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvGrid.Columns.Add(col);
            }
            foreach (var team in m_AI.Teams)
            {
                var row = new DataGridViewRow();
                row.Tag = team;
                row.HeaderCell.Value = team.Name;

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
                    var stage = col.Tag as Stage;
                    if (stage != null)
                    {
                        var state = m_AI.GetState(stage, team);
                        switch (state)
                        {
                            case -1:
                                row.Cells[i].Style.BackColor = c_Gray;
                                break;
                            case 0:
                                row.Cells[i].Style.BackColor = c_Red;
                                break;
                            case 1:
                                row.Cells[i].Style.BackColor = c_Green;
                                break;
                        }
                    }
                    if (team.CurrentStages.Contains(stage.ID))
                    {
                        row.Cells[i].Style.BackColor = c_Yellow;
                    }
                }
            }

            dgvGrid.ClearSelection();

            #endregion

            m_AI.SaveToStg();
        }

        #region Ненужное

        private void AddStage_MouseClick(object sender, MouseEventArgs e)
        {
            var stage = new Stage();
            if (StageEditDlg.Execute(m_AI, stage))
            {
                m_AI.AddStage(stage);
                UpdateData();
            }
        }

        private void EditStage_MouseClick(object sender, MouseEventArgs e)
        {
            var panel = sender as Control;
            if (panel == null)
                return;

            var stage = panel.Tag as Stage;
            if (stage == null)
                return;

            if (StageEditDlg.Execute(m_AI, stage))
            {
                UpdateData();
            }
        }

        private void RemoveStage_MouseClick(object sender, MouseEventArgs e)
        {
            var panel = sender as Control;
            if (panel == null)
                return;

            var stage = panel.Tag as Stage;
            if (stage == null)
                return;

            m_AI.Stages.Remove(stage);
            UpdateData();
        }

        private void AddTeam_MouseClick(object sender, MouseEventArgs e)
        {
            var team = new Team();
            if (TeamEditDlg.Execute(m_AI, team))
            {
                m_AI.AddTeam(team);
                UpdateData();
            }
        }

        private void EditTeam_MouseClick(object sender, MouseEventArgs e)
        {
            var panel = sender as Control;
            if (panel == null)
                return;

            var team = panel.Tag as Team;
            if (team == null)
                return;

            if (TeamEditDlg.Execute(m_AI, team))
            {
                UpdateData();
            }
        }

        private void RemoveTeam_MouseClick(object sender, MouseEventArgs e)
        {
            var panel = sender as Control;
            if (panel == null)
                return;

            var team = panel.Tag as Team;
            if (team == null)
                return;

            m_AI.Teams.Remove(team);
            UpdateData();
        }

        #endregion

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
            if (e.Button == MouseButtons.Left)
            {
                dgvGrid.ClearSelection();
            }
            else if (e.Button == MouseButtons.Right)
            {
                var hitTest = dgvGrid.HitTest(e.X, e.Y);
                if (hitTest.ColumnIndex == -1 && hitTest.RowIndex == -1)
                {
                    return;
                }

                ContextMenu m = new ContextMenu();

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
                    var stage = dgvGrid.Columns[hitTest.ColumnIndex].Tag as Stage;
                    if (team != null && stage != null)
                    {
                        var tag = new object[2] { team, stage };

                        var state = m_AI.GetState(stage, team);

                        var index = team.CurrentStages.BinarySearch(stage.ID);
                        if (index < 0)
                        {
                            var sendTeam = new MenuItem("Отправить команду");
                            sendTeam.Tag = tag;
                            sendTeam.Click += new EventHandler(sendTeam_Click);
                            m.MenuItems.Add(sendTeam);
                        }
                        else
                        {
                            var stageClear = new MenuItem("Этап свободен");
                            stageClear.Tag = tag;
                            stageClear.Click += new EventHandler(stageClear_Click);
                            m.MenuItems.Add(stageClear);
                        }

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

                if (m.MenuItems.Count > 0)
                {
                    m.Show(dgvGrid, new Point(e.X, e.Y));
                }
            }
        }

        void stageCompleted_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    var team = tag[0] as Team;
                    var stage = tag[1] as Stage;

                    if (team != null && stage != null)
                    {
                        if (team.Stages.ContainsKey(stage.Name))
                        {
                            team.Stages[stage.Name] = 1;
                            UpdateData();
                        }
                    }
                }
            }
        }

        void stageIncomplete_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    var team = tag[0] as Team;
                    var stage = tag[1] as Stage;

                    if (team != null && stage != null)
                    {
                        if (team.Stages.ContainsKey(stage.Name))
                        {
                            team.Stages[stage.Name] = 0;
                            UpdateData();
                        }
                    }
                }
            }
        }

        void stagePass_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    var team = tag[0] as Team;
                    var stage = tag[1] as Stage;

                    if (team != null && stage != null)
                    {
                        if (team.Stages.ContainsKey(stage.Name))
                        {
                            team.Stages[stage.Name] = -1;
                            UpdateData();
                        }
                    }
                }
            }
        }

        void stageClear_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    var team = tag[0] as Team;
                    var stage = tag[1] as Stage;

                    if (team != null && stage != null)
                    {
                        var index = team.CurrentStages.BinarySearch(stage.ID);
                        if (index >= 0)
                        {
                            team.Stages[stage.Name] = 1;
                            team.CurrentStages.RemoveAt(index);
                            team.IsReady = false;
                            UpdateData();
                        }
                    }
                }
            }
        }

        void sendTeam_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var tag = mi.Tag as object[];
                if (tag != null && tag.Length == 2)
                {
                    var team = tag[0] as Team;
                    var stage = tag[1] as Stage;

                    if (team != null && stage != null)
                    {
                        var index = team.CurrentStages.BinarySearch(stage.ID);
                        if (index < 0)
                        {
                            team.CurrentStages.Insert(~index, stage.ID);
                            UpdateData();
                        }
                    }
                }
            }
        }

        

        void stageIsClosed_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var stage = mi.Tag as Stage;
                if (stage != null)
                {
                    stage.IsClosed = !stage.IsClosed;
                    UpdateData();
                }
            }
        }

        void addStage_Click(object sender, EventArgs e)
        {
            var stage = new Stage();
            if (StageEditDlg.Execute(m_AI, stage))
            {
                m_AI.AddStage(stage);
                UpdateData();
            }
        }

        void editStage_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var stage = mi.Tag as Stage;
                if (stage != null)
                {
                    if (StageEditDlg.Execute(m_AI, stage))
                    {
                        UpdateData();
                    }
                }
            }
        }

        void removeStage_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var stage = mi.Tag as Stage;
                if (stage != null)
                {
                    m_AI.Stages.Remove(stage);
                    UpdateData();
                }
            }
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

        void addTeam_Click(object sender, EventArgs e)
        {
            var team = new Team();
            if (TeamEditDlg.Execute(m_AI, team))
            {
                m_AI.AddTeam(team);
                UpdateData();
            }
        }

        void editTeam_Click(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                var team = mi.Tag as Team;
                if (team != null)
                {
                    if (TeamEditDlg.Execute(m_AI, team))
                    {
                        UpdateData();
                    }
                }
            }
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
    }
}
