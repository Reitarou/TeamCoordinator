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
    partial class GroupsEditDlg : Form
    {
        private List<Group> m_Groups;

        public GroupsEditDlg()
        {
            InitializeComponent();
        }

        public static bool Execute(AI ai)
        {
            using (var dlg = new GroupsEditDlg())
            {

                //dlg.Top = MousePosition.Y;
                //dlg.Left = Math.Max(0, (int)(MousePosition.X - dlg.Width * 0.5));

                //dlg.m_Groups = new List<Group>();
                //foreach(var group in ai.Groups)
                //{
                //    dlg.m_Groups.Add(group);
                //}
                //dlg.UpdateControls();

                //if (dlg.ShowDialog() == DialogResult.OK)
                //{
                //    ai.Groups.Clear();
                //    foreach (var item in dlg.m_Groups)
                //    {
                //        if (item.ID >= 0)
                //        {
                //            ai.Groups.Add(item);
                //        }
                //        else
                //        {
                //            ai.AddGroup(item);
                //        }
                //    }
                //    return true;
                //}
            }
            return false;


            
        }

        private void UpdateControls()
        {
            lbGroups.Items.Clear();
            foreach (var group in m_Groups)
            {
                lbGroups.Items.Add(group.Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //var name = Microsoft.VisualBasic.Interaction.InputBox("Укажите название", "Добавить группу", "", (int)(DisplayRectangle.Width * 0.5), (int)(DisplayRectangle.Height * 0.5));
            //if (name != "")
            //{
            //    var shortName = Microsoft.VisualBasic.Interaction.InputBox("Укажите короткое название", "Добавить группу", "", (int)(DisplayRectangle.Width * 0.5), (int)(DisplayRectangle.Height * 0.5));
            //    if (shortName != "")
            //    {
            //        var group = new Group();
            //        group.Name = name;
            //        group.ShortName = shortName;
            //        m_Groups.Add(group);
            //    }
            //}
            //UpdateControls();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            var si = lbGroups.SelectedIndex;
            if (si >= 0)
            {
                var name = Microsoft.VisualBasic.Interaction.InputBox("Укажите название", "Добавить группу", lbGroups.Items[si].ToString(), (int)(DisplayRectangle.Width * 0.5), (int)(DisplayRectangle.Height * 0.5));
                if (name != "")
                {
                    var shortName = Microsoft.VisualBasic.Interaction.InputBox("Укажите короткое название", "Добавить группу", "", (int)(DisplayRectangle.Width * 0.5), (int)(DisplayRectangle.Height * 0.5));
                    if (shortName != "")
                    {
                        m_Groups[si].Name = name;
                        m_Groups[si].ShortName = shortName;
                        UpdateControls();
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var si = lbGroups.SelectedIndex;
            if (si >= 0)
            {
                m_Groups.RemoveAt(si);
                UpdateControls();
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
    }
}
