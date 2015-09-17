using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeamCoordinator
{
    partial class StageEditDlg : Form
    {
        private List<int> AvGroups;
        private List<int> AiGroups;
        private AI m_AI;
        private Stage m_Stage;

        public StageEditDlg(AI ai, Stage stage)
        {
            InitializeComponent();
            m_AI = ai;
            m_Stage = stage;
        }

        public static bool Execute(AI ai, Stage stage)
        {
            using (var dlg = new StageEditDlg(ai, stage))
            {
                dlg.Top = MousePosition.Y;
                dlg.Left = Math.Max(0, (int)(MousePosition.X - dlg.Width * 0.5));

                dlg.tbNumber.Text = stage.Number;
                dlg.tbName.Text = stage.Name;
                dlg.tbCoach.Text = stage.Coach;

                dlg.UpdateControls();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    stage.Number = dlg.tbNumber.Text;
                    stage.Name = dlg.tbName.Text;
                    stage.Coach = dlg.tbCoach.Text;
                    return true;
                }
            }
            return false;
        }

        private void UpdateControls()
        {
            AvGroups = new List<int>();
            AiGroups = new List<int>();

            for (int i = 0; i<m_AI.Groups.Count; i++)
            {
                var group = m_AI.Groups[i];
                if (m_Stage.AvaliableGroups.Contains(group.ID))
                {
                    AvGroups.Add(i);
                }
                else
                {
                    AiGroups.Add(i);
                }
            }

            listAvg.Items.Clear();
            foreach (var index in AvGroups)
            {
                listAvg.Items.Add(m_AI.Groups[index].Name);
            }

            listAig.Items.Clear();
            foreach (var index in AiGroups)
            {
                listAig.Items.Add(m_AI.Groups[index].Name);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            m_Stage.AvaliableGroups.Clear();
            foreach (var group in m_AI.Groups)
            {
                m_Stage.AvaliableGroups.Add(group.ID);
            }
            UpdateControls();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var index = listAig.SelectedIndex;
            if (index >= 0)
            {
                m_Stage.AvaliableGroups.Add(m_AI.Groups[AiGroups[index]].ID);
                UpdateControls();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var index = listAvg.SelectedIndex;
            if (index >= 0)
            {
                m_Stage.AvaliableGroups.Remove(m_AI.Groups[AvGroups[index]].ID);
                UpdateControls();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            m_Stage.AvaliableGroups.Clear();
            UpdateControls();
        }
    }
}
