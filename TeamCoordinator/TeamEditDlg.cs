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
    partial class TeamEditDlg : Form
    {
        private AI m_AI;
        private Team m_Team;

        public TeamEditDlg(AI ai, Team team)
        {
            InitializeComponent();
            m_AI = ai;
            m_Team = team;
            btnStagePass.Text = Resources.sStagePass;
            btnStageIncomplete.Text = Resources.sStageIncomplete;
            btnStageComplete.Text = Resources.sStageComplete;

            cmbGroup.Items.Clear();
            cmbGroup.Items.Add("Не выбрано");
            foreach (var group in ai.Groups)
            {
                cmbGroup.Items.Add(group);
            }
        }

        public static bool Execute(AI ai, Team team)
        {
            using (var dlg = new TeamEditDlg(ai, team))
            {
                dlg.Top = MousePosition.Y;
                dlg.Left = Math.Max(0, (int)(MousePosition.X - dlg.Width * 0.5));

                dlg.tbName.Text = team.Name;
                dlg.cmbGroup.SelectedIndex = 0;
                if (team.Group != -1)
                {
                    for (int i = 1; i < dlg.cmbGroup.Items.Count; i++)
                    {
                        var group = dlg.cmbGroup.Items[i] as Group;
                        if (group != null)
                        {
                            if (team.Group == group.ID)
                            {
                                dlg.cmbGroup.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }

                dlg.UpdateControls();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    team.Name = dlg.tbName.Text;
                    if (dlg.cmbGroup.SelectedIndex == 0)
                    {
                        team.Group = -1;
                    }
                    else
                    {
                        var group = dlg.cmbGroup.Items[dlg.cmbGroup.SelectedIndex] as Group;
                        if (group == null)
                        {
                            team.Group = -1;
                        }
                        else
                        {
                            team.Group = group.ID;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        private void UpdateControls()
        {
            int selectedIndex = -1;
            if (dgvStages.SelectedRows.Count > 0)
            {
                selectedIndex = dgvStages.SelectedRows[0].Index;
            }

            dgvStages.SelectionChanged -= dgvStages_SelectionChanged;
            dgvStages.Rows.Clear();
            var stages = m_AI.Stages;
            foreach (var stage in stages)
            {
                var index = dgvStages.Rows.Add();
                var row = dgvStages.Rows[index];
                var name = stage.Name;
                row.Tag = name;
                row.Cells[0].Value = name;
                int res;
                if (m_Team.Stages.ContainsKey(name))
                {
                    res = m_Team.Stages[name];
                }
                else
                {
                    res = -1;
                    m_Team.Stages.Add(name, -1);
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
            }


            if (selectedIndex >= 0)
            {
                dgvStages.ClearSelection();
                dgvStages.Rows[selectedIndex].Selected = true;
            }
            UpdateButtons();
            dgvStages.SelectionChanged += dgvStages_SelectionChanged;
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
                var name = row.Cells[0].Value.ToString();
                int value = -1;
                if (m_Team.Stages.ContainsKey(name))
                {
                    value = m_Team.Stages[name];
                }
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

        private void btnStagePass_Click(object sender, EventArgs e)
        {
            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var name = row.Cells[0].Value.ToString();
                if (!m_Team.Stages.ContainsKey(name))
                {
                    m_Team.Stages.Add(name, -1);
                }
                else
                {
                    m_Team.Stages[name] = -1;
                }
                UpdateControls();
            }
        }

        private void btnStageIncomplete_Click(object sender, EventArgs e)
        {
            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var name = row.Cells[0].Value.ToString();
                if (!m_Team.Stages.ContainsKey(name))
                {
                    m_Team.Stages.Add(name, 0);
                }
                else
                {
                    m_Team.Stages[name] = 0;
                }
                UpdateControls();
            }
        }

        private void btnStageComplete_Click(object sender, EventArgs e)
        {
            if (dgvStages.SelectedRows.Count > 0)
            {
                var row = dgvStages.SelectedRows[0];
                var name = row.Cells[0].Value.ToString();
                if (!m_Team.Stages.ContainsKey(name))
                {
                    m_Team.Stages.Add(name, 1);
                }
                else
                {
                    m_Team.Stages[name] = 1;
                }
                UpdateControls();
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedIndex != 0)
            {
                var group = cmbGroup.Items[cmbGroup.SelectedIndex] as Group;
                if (group != null)
                {
                    foreach (var stage in m_AI.Stages)
                    {
                        if (m_Team.Stages.ContainsKey(stage.Name))
                        {
                            if (stage.AvaliableGroups.Contains(group.ID))
                            {
                                m_Team.Stages[stage.Name] = 0;
                            }
                            else
                            {
                                m_Team.Stages[stage.Name] = -1;
                            }
                        }
                    }
                    UpdateControls();
                }
            }
        }
    }
}
