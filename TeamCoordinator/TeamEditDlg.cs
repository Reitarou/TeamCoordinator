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
    partial class TeamEditDlg : Form
    {
        public TeamEditDlg()
        {
            InitializeComponent();
        }

        public static bool Execute(Team team)
        {
            using (var dlg = new TeamEditDlg())
            {
                dlg.Top = MousePosition.Y;
                dlg.Left = Math.Max(0, (int)(MousePosition.X - dlg.Width * 0.5));

                dlg.tbName.Text = team.Name;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    team.Name = dlg.tbName.Text;
                    return true;
                }
            }
            return false;
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
    }
}
