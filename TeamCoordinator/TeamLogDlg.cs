using System.Windows.Forms;

namespace TeamCoordinator
{
    public partial class TeamLogDlg : Form
    {
        public TeamLogDlg()
        {
            InitializeComponent();
        }

        public void SetTeam(Team team)
        {
            this.Text = team.Name;
            foreach (var record in team.RecordsLog)
                this.lbLog.Items.Add(record);
        }
    }
}
