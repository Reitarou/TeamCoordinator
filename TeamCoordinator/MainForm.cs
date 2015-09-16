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
            panelStages.Controls.Clear();
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


            var stages = m_AI.Stages;

            var columns = 3;

            int x = 8, y = 8;
            var list = new List<Stage>();
            foreach (var pair in stages)
            {
                list.Add(pair.Value);
            }

            //list.Sort

            for (int i = 0; i < list.Count; i++)
            {
                var stage = list[i];

                var panel = new Panel();
                panel.Location = new Point(x, y);
                panel.Width = (panelStages.Width-(8*(columns+1)))/columns;
                panel.Height = 8*4+32*3;

                var font = new Font("TimesNewRoman", 12f);

                var nameLabel = new Label();
                nameLabel.Font = font;
                nameLabel.Text = stage.Name;
                nameLabel.Size = new Size(panel.Width-8-32-8, (int)font.Size+4);
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Location = new Point(8, 8);
                panel.Controls.Add(nameLabel);

                var descriptionLabel = new Label();
                descriptionLabel.Font = font;
                descriptionLabel.Text = stage.Description;
                descriptionLabel.AutoSize = true;
                descriptionLabel.Location = new Point(8, 28);
                panel.Controls.Add(descriptionLabel);

                if (m_EditMode)
                {
                    panel.BackColor = Color.FromArgb(230, 0, 230);
                }
                else
                {
                    switch (stage.State)
                    {
                        case StageState.Closed:
                            panel.BackColor = Color.FromArgb(120, 50, 50);
                            break;

                        case StageState.Occupied:
                            panel.BackColor = Color.FromArgb(120, 120, 50);
                            break;

                        case StageState.Open:
                            panel.BackColor = Color.FromArgb(150, 200, 150);
                            break;
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
                    ImgControl = new PictureBox();
                    ImgControl.Size = new Size(32, 32);
                    //ImgControl.Image = Resources.ArrowLeft;
                    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8);
                    ImgControl.Enabled = false;
                    //ImgControl.Tag = stage;
                    //ImgControl.MouseClick += Stage_MouseClick;
                    panel.Controls.Add(ImgControl);

                    ImgControl = new PictureBox();
                    ImgControl.Size = new Size(32, 32);
                    //ImgControl.Image = Resources.ArrowRight;
                    ImgControl.Location = new Point(panel.Width - ImgControl.Width - 8, 8 + 32 + 8 + 32 + 8);
                    ImgControl.Enabled = false;
                    //ImgControl.Tag = stage;
                    //ImgControl.MouseClick += Stage_MouseClick;
                    panel.Controls.Add(ImgControl);
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

                panel.BackColor = Color.FromArgb(230, 0, 230);

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

            m_AI.SaveToStg();
        }

        private void AddStage_MouseClick(object sender, MouseEventArgs e)
        {
            var name = "";
            var description = "";
            while (true)
            {
                if (StageEditDlg.Execute(ref name, ref description))
                {
                    if (!m_AI.Stages.ContainsKey(name))
                    {
                        var stage = new Stage(name);
                        stage.Description = description;
                        m_AI.Stages.Add(name, stage);
                        UpdateControls();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(Resources.eStageAlreadyExist);
                    }
                }
                else
                {
                    return;
                }
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

            var name = stage.Name;
            var description = stage.Description;
            if (StageEditDlg.Execute(ref name, ref description))
            {
                if (m_AI.Stages.ContainsKey(name))
                {
                    MessageBox.Show(Resources.eStageAlreadyExist);
                    return;
                }
                else
                {
                    m_AI.Stages.Remove(stage.Name);
                    var newStage = new Stage(name);
                    newStage.Description = description;
                    newStage.State = stage.State;
                    m_AI.Stages.Add(name, newStage);
                    UpdateControls();
                }
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

            m_AI.Stages.Remove(stage.Name);

            UpdateControls();
        }

        private void miEditMode_Click(object sender, EventArgs e)
        {
            m_EditMode = !m_EditMode;
            UpdateControls();
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
                new XElement("Teams")));
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
    }
}
