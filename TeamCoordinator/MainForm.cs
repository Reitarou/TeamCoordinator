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
        private Color c_Green = Color.FromArgb(150,200,150);
        private Color c_Yellow = Color.FromArgb(120, 120, 50);
        private Color c_Red = Color.FromArgb(120,50,50);
        private Color c_Violet = Color.FromArgb(230,100,230);

        private AI m_AI;

        private bool m_EditMode = true;

        public MainForm()
        {
            InitializeComponent();
            m_AI = new AI(null);
            UpdateControls();
        }

        private void UpdateControls()
        {
            this.Text = m_AI.FileName;
            if (!m_AI.Valid)
            {
                return;
            }

            if (m_EditMode)
            {
                miEditMode.Text = "Сохранить";
            }
            else
            {
                miEditMode.Text = "Редактировать";
            }


            var cSize = 32; //размер кнопок контролов

            #region Stages
            panelStages.Controls.Clear();

            var minWidth = 200;
            var columns = (int)(panelStages.Width/minWidth);

            int x = 8, y = 8;
            var stages = m_AI.Stages;

            for (int i = 0; i < stages.Count; i++)
            {
                var stage = stages[i];

                var panel = new Panel();
                panel.Location = new Point(x, y);
                panel.Width = (panelStages.Width-(8*(columns+1)))/columns;
                panel.Height = 8*4+32*3;

                var font = new Font("TimesNewRoman", 10f);

                var nameLabel = new Label();
                nameLabel.Font = font;
                nameLabel.Text = string.Format(Resources.sStageHeader, stage.Number, stage.Name, stage.Coach);
                nameLabel.Size = new Size(panel.Width-2*8-cSize, (int)(font.Size*2));
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Location = new Point(8, 8);
                panel.Controls.Add(nameLabel);

                var groupsLabel = new Label();
                groupsLabel.Font = font;
                var s = "";
                foreach (var avstage in stage.AvaliableGroups)
                {
                    var group = m_AI.GetGroup(avstage);
                    if (group != null)
                    {
                        s += group.ShortName + ", ";
                    }
                }
                if (s.Length > 0)
                {
                    s = s.Remove(s.Length - 2);
                }
                groupsLabel.Text = s;
                groupsLabel.Size = new Size(panel.Width - 2 * 8 - cSize, (int)(font.Size * 2));
                groupsLabel.TextAlign = ContentAlignment.MiddleCenter;
                groupsLabel.Location = new Point(8, panel.Height - (8 + (int)(font.Size * 2))*2);
                panel.Controls.Add(groupsLabel);

                var stateLabel = new Label();
                stateLabel.Font = font;
                stateLabel.Text = m_AI.GetStageState(stage);
                stateLabel.Size = new Size(panel.Width - 2 * 8 - cSize, (int)(font.Size * 2));
                stateLabel.TextAlign = ContentAlignment.MiddleCenter;
                stateLabel.Location = new Point(8, panel.Height - (8 + (int)(font.Size * 2)));
                panel.Controls.Add(stateLabel);

                if (m_EditMode)
                {
                    panel.BackColor = c_Violet;
                }
                else
                {
                    if (stage.IsClosed)
                    {
                        panel.BackColor = c_Red;
                    }
                    else
                    {
                        if (stateLabel.Text == Resources.sStageFree)
                        {
                            panel.BackColor = c_Green;
                        }
                        else
                        {
                            panel.BackColor = c_Yellow;
                        }
                    }
                }

                PictureBox ImgControl;

                if (m_EditMode)
                {
                    int imgY = 8;
                    ImgControl = new PictureBox();
                    ImgControl.Size = new Size(16, 16);
                    ImgControl.Image = Resources.Settings;
                    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
                    ImgControl.Tag = stage;
                    ImgControl.MouseClick += EditStage_MouseClick;
                    panel.Controls.Add(ImgControl);
                    imgY += (int)(ImgControl.Height * 0.5 + 8);

                    ImgControl = new PictureBox();
                    ImgControl.Size = new Size(16, 16);
                    ImgControl.Image = Resources.Remove;
                    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
                    ImgControl.Tag = stage;
                    ImgControl.MouseClick += RemoveStage_MouseClick;
                    panel.Controls.Add(ImgControl);
                    imgY += (int)(ImgControl.Height * 0.5 + 8);
                }
                else
                {
                    //ImgControl = new PictureBox();
                    //ImgControl.Size = new Size(32, 32);
                    ////ImgControl.Image = Resources.ArrowLeft;
                    //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8);
                    //ImgControl.Enabled = false;
                    ////ImgControl.Tag = stage;
                    ////ImgControl.MouseClick += Stage_MouseClick;
                    //panel.Controls.Add(ImgControl);

                    //ImgControl = new PictureBox();
                    //ImgControl.Size = new Size(32, 32);
                    ////ImgControl.Image = Resources.ArrowRight;
                    //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8 + 32 + 8);
                    //ImgControl.Enabled = false;
                    ////ImgControl.Tag = stage;
                    ////ImgControl.MouseClick += Stage_MouseClick;
                    //panel.Controls.Add(ImgControl);
                }
                panelStages.Controls.Add(panel);

                if ((i + 1) % columns != 0)
                {
                    x += 8 + panel.Width;
                }
                else
                {
                    y += 8 + panel.Height;
                    x = 8;
                }
            }
            if (m_EditMode)
            {
                var panel = new Panel();
                panel.Location = new Point(x, y);
                panel.Width = (panelStages.Width - (8 * (columns + 1))) / columns;
                panel.Height = 8 * 4 + 32 * 3;

                panel.BackColor = c_Violet;

                PictureBox ImgControl;

                ImgControl = new PictureBox();
                ImgControl.Size = new Size(16, 16);
                ImgControl.Image = Resources.Add;
                ImgControl.Location = new Point((int)(panel.Width * 0.5 - ImgControl.Height * 0.5), (int)(panel.Height * 0.5 - ImgControl.Height * 0.5));
                ImgControl.MouseClick += AddStage_MouseClick;
                panel.Controls.Add(ImgControl);

                panel.MouseClick += AddStage_MouseClick;

                panelStages.Controls.Add(panel);
            }

            #endregion

            #region Teams
            panelTeams.Controls.Clear();

            minWidth = 300;
            columns = (int)(panelTeams.Width / minWidth);
            x = 8;
            y = 8;
            var teams = m_AI.Teams;

            for (int i = 0; i < teams.Count; i++)
            {
                var team = teams[i];

                var panel = new Panel();
                panel.Location = new Point(x, y);
                panel.Width = (panelTeams.Width - (8 * (columns + 1))) / columns;
                panel.Height = 8 * 4 + 32 * 3;

                var font = new Font("TimesNewRoman", 10f);

                var nameLabel = new Label();
                nameLabel.Font = font;
                nameLabel.Text = team.Name;
                nameLabel.Size = new Size(panel.Width - 8 - 32 - 8, (int)font.Size + 4);
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Location = new Point(8, 8);
                panel.Controls.Add(nameLabel);

                var descriptionLabel = new Label();
                descriptionLabel.Font = font;
                descriptionLabel.AutoSize = true;
                descriptionLabel.Location = new Point(8, 28);
                panel.Controls.Add(descriptionLabel);

                if (m_EditMode)
                {
                    panel.BackColor = c_Violet;
                }
                else
                {
                    if (team.CurrentStages.Count > 0)
                    {
                        panel.BackColor = c_Red;
                    }
                    else
                    {
                        if (team.IsReady)
                        {
                            panel.BackColor = c_Green;
                        }
                        else
                        {
                            panel.BackColor = c_Yellow;
                        }
                    }
                }

                PictureBox ImgControl;

                if (m_EditMode)
                {
                    int imgY = 8;
                    ImgControl = new PictureBox();
                    ImgControl.Size = new Size(16, 16);
                    ImgControl.Image = Resources.Settings;
                    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
                    ImgControl.Tag = team;
                    ImgControl.MouseClick += EditTeam_MouseClick;
                    panel.Controls.Add(ImgControl);
                    imgY += (int)(ImgControl.Height * 0.5 + 8);

                    ImgControl = new PictureBox();
                    ImgControl.Size = new Size(16, 16);
                    ImgControl.Image = Resources.Remove;
                    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, imgY);
                    ImgControl.Tag = team;
                    ImgControl.MouseClick += RemoveTeam_MouseClick;
                    panel.Controls.Add(ImgControl);
                    imgY += (int)(ImgControl.Height * 0.5 + 8);
                }
                else
                {
                    //ImgControl = new PictureBox();
                    //ImgControl.Size = new Size(32, 32);
                    ////ImgControl.Image = Resources.ArrowLeft;
                    //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8);
                    //ImgControl.Enabled = false;
                    ////ImgControl.Tag = stage;
                    ////ImgControl.MouseClick += Stage_MouseClick;
                    //panel.Controls.Add(ImgControl);

                    //ImgControl = new PictureBox();
                    //ImgControl.Size = new Size(32, 32);
                    ////ImgControl.Image = Resources.ArrowRight;
                    //ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8 + 32 + 8);
                    //ImgControl.Enabled = false;
                    ////ImgControl.Tag = stage;
                    ////ImgControl.MouseClick += Stage_MouseClick;
                    //panel.Controls.Add(ImgControl);
                }
                panelTeams.Controls.Add(panel);
                
                if ((i + 1) % columns != 0)
                {
                    x += 8 + panel.Width;
                }
                else
                {
                    y += 8 + panel.Height;
                    x = 8;
                }
            }

            if (m_EditMode)
            {
                var panel = new Panel();
                panel.Location = new Point(x, y);
                panel.Width = (panelTeams.Width - (8 * (columns + 1))) / columns;
                panel.Height = 8 * 4 + 32 * 3;

                panel.BackColor = c_Violet;

                PictureBox ImgControl;

                ImgControl = new PictureBox();
                ImgControl.Size = new Size(16, 16);
                ImgControl.Image = Resources.Add;
                ImgControl.Location = new Point((int)(panel.Width * 0.5 - ImgControl.Height * 0.5), (int)(panel.Height * 0.5 - ImgControl.Height * 0.5));
                ImgControl.MouseClick += AddTeam_MouseClick;
                panel.Controls.Add(ImgControl);

                panel.MouseClick += AddTeam_MouseClick;

                panelTeams.Controls.Add(panel);
            }

            #endregion

            m_AI.SaveToStg();
        }

        private void AddStage_MouseClick(object sender, MouseEventArgs e)
        {
            var stage = new Stage();
            if (StageEditDlg.Execute(m_AI, stage))
            {
                m_AI.AddStage(stage);
                UpdateControls();
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
                UpdateControls();
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
            UpdateControls();
        }

        private void AddTeam_MouseClick(object sender, MouseEventArgs e)
        {
            var team = new Team();
            if (TeamEditDlg.Execute(team))
            {
                m_AI.AddTeam(team);
                UpdateControls();
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

            if (TeamEditDlg.Execute(team))
            {
                UpdateControls();
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
            UpdateControls();
        }

        private void miEditMode_Click(object sender, EventArgs e)
        {
            if (m_AI.Valid)
            {
                m_EditMode = !m_EditMode;
                UpdateControls();
            }
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

            UpdateControls();
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
            UpdateControls();
        }

        private void miEditGroups_Click(object sender, EventArgs e)
        {
            if (m_AI.Valid)
            {
                if (GroupsEditDlg.Execute(m_AI))
                {
                    UpdateControls();
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }
    }
}
