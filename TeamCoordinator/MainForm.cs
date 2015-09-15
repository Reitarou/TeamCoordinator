using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamCoordinator.Properties;

namespace TeamCoordinator
{
    public partial class MainForm : Form
    {
        private AI Gantaro;

        private bool m_EditMode = true;

        public MainForm()
        {
            InitializeComponent();
            Gantaro = new AI();
            UpdateControls();
        }

        private void UpdateControls()
        {
            if (m_EditMode)
            {
                miEditMode.Text = "Сохранить";
            }
            else
            {
                miEditMode.Text = "Редактировать";
            }

            panelStages.Controls.Clear();

            var stages = Gantaro.Stages;

            var columns = 3;

            int x = 8, y = 8;
            for (int i = 0; i < stages.Count; i++)
            {
                var stage = stages[i];

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
                descriptionLabel.Text = stage.Desription;
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
                panel.Controls.Add(ImgControl);

                panel.MouseClick += AddStage_MouseClick;

                panelStages.Controls.Add(panel);
            }
        }

        private void AddStage_MouseClick(object sender, MouseEventArgs e)
        {
            var stage = new Stage();

            if (StageEditDlg.Execute(stage))
            {
                Gantaro.AddStage(stage);
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


            if (StageEditDlg.Execute(stage))
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

            Gantaro.Stages.Remove(stage);

            UpdateControls();
        }

        private void miEditMode_Click(object sender, EventArgs e)
        {
            m_EditMode = !m_EditMode;
            UpdateControls();
        }

    }
}
