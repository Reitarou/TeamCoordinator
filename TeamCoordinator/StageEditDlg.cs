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
        public StageEditDlg()
        {
            InitializeComponent();
        }

        public static bool Execute(Stage stage)
        {
            using (var dlg = new StageEditDlg())
            {
                dlg.tbName.Text = stage.Name;
                dlg.rtbDescription.Text = stage.Desription;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    stage.Name = dlg.tbName.Text;
                    stage.Desription = dlg.rtbDescription.Text;
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
