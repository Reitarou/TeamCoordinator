using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamCoordinator.Properties;
using System.Xml.Linq;
using System.IO;

namespace TeamCoordinator
{
    class AI
    {
        

        private string m_Path;
        public List<Group> m_Groups;
        private int m_CurrentGroupID = 0;
        private List<Stage> m_Stages;
        private int m_CurrentStageID = 0;
        private List<Team> m_Teams;
        private int m_CurrentTeamID = 0;

        public AI(string path)
        {
            if (path != null)
            {
                m_Path = path;
                if (!File.Exists(path))
                {
                    MessageBox.Show(string.Format(Resources.eNoFile, path));
                }
                else
                {
                    var doc = XDocument.Load(path);
                    LoadFromStg(doc);
                }
            }
        }

        public bool Valid
        {
            get
            {
                if (m_Path != null)
                {
                    return File.Exists(m_Path);
                }
                return false;
            }
        }

        public string FileName
        {
            get
            {
                if (!File.Exists(m_Path))
                {
                    return "No File";
                }
                else
                {
                    return System.IO.Path.GetFileNameWithoutExtension(m_Path);
                }
            }
        }

        public List<Stage> Stages
        {
            get
            {
                m_Stages.Sort((a,b) => a.Number.CompareTo(b.Number));
                return m_Stages;
            }
        }
        
        public List<Team> Teams
        {
            get
            {
                return m_Teams;
            }
        }

        public List<Group> Groups
        {
            get
            {
                return m_Groups;
            }
        }
        
        public void AddStage(Stage stage)
        {
            stage.SetID(m_CurrentStageID++);
            m_Stages.Add(stage);
        }

        public void AddTeam(Team team)
        {
            team.SetID(m_CurrentTeamID++);
            m_Teams.Add(team);
        }

        public void AddGroup(Group group)
        {
            group.SetID(m_CurrentGroupID++);
            m_Groups.Add(group);
        }

        public Stage GetStage(int id)
        {
            foreach (var stage in m_Stages)
            {
                if (stage.ID == id)
                {
                    return stage;
                }
            }
            return null;
        }

        public Stage GetStage(string name)
        {
            foreach (var stage in m_Stages)
            {
                if (stage.Name == name)
                {
                    return stage;
                }
            }
            return null;
        }

        public Team GetTeam(int id)
        {
            foreach (var team in m_Teams)
            {
                if (team.ID == id)
                {
                    return team;
                }
            }
            return null;
        }

        public Group GetGroup(int id)
        {
            foreach (var group in m_Groups)
            {
                if (group.ID == id)
                {
                    return group;
                }
            }
            return null;
        }

        public List<int> GetStageState(Stage stage)
        {
            if (stage.IsClosed)
            {
                return null;
            }
            var res = new List<int>();

            foreach (var team in m_Teams)
            {
                var index = team.CurrentStages.BinarySearch(stage.ID);
                if (index >= 0)
                {
                    res.Add(team.ID);
                }
            }

            return res;
        }

        public int GetState(Stage stage, Team team)
        {
            if (team.Stages.ContainsKey(stage.Name))
            {
                return team.Stages[stage.Name];
            }
            return -1;
        }

        public void CheckTeams()
        {
            foreach (var team in m_Teams)
            {
                foreach (var stage in m_Stages)
                {
                    if (!team.Stages.ContainsKey(stage.Name))
                    {
                        team.Stages.Add(stage.Name, -1);
                    }
                }
            }
        }

        public void LoadFromStg(XDocument doc)
        {
            var aiNode = new StgNode(doc.Element("AI"));
            m_CurrentStageID = aiNode.GetInt("CurrentStageID", 0);
            m_CurrentTeamID = aiNode.GetInt("CurrentTeamID", 0);
            m_CurrentGroupID = aiNode.GetInt("CurrentGroupID", 0);

            m_Stages = new List<Stage>();

            var stages = aiNode.GetNode("Stages");
            foreach (var node in stages.GetNodes("Stage"))
            {
                var stage = new Stage(node);
                if (stage.ID < 0)
                {
                    stage.SetID(m_CurrentStageID++);
                }
                m_Stages.Add(stage);
            }

            m_Teams = new List<Team>();
            var teams = aiNode.GetNode("Teams");
            foreach (var node in teams.GetNodes("Team"))
            {
                var team = new Team(node);
                if (team.ID < 0)
                {
                    team.SetID(m_CurrentTeamID++);
                }
                m_Teams.Add(team);
            }

            m_Groups = new List<Group>();
            var groups = aiNode.GetNode("Groups");
            foreach (var node in groups.GetNodes("Group"))
            {
                var group = new Group(node);
                if (group.ID < 0)
                {
                    group.SetID(m_CurrentGroupID++);
                }
                m_Groups.Add(group);
            }
        }

        public void SaveToStg()
        {
            if (!File.Exists(m_Path))
            {
                File.Create(m_Path);
            }

            var doc = new XDocument(new XElement("AI",
                new XElement("Stages"),
                new XElement("Teams"), 
                new XElement("Groups")));

            var aiNode = new StgNode(doc.Element("AI"));
            aiNode.AddInt("CurrentGroupID", m_CurrentGroupID);
            aiNode.AddInt("CurrentStageID", m_CurrentStageID);
            aiNode.AddInt("CurrentTeamID", m_CurrentTeamID);

            var stages = aiNode.GetNode("Stages");
            foreach (var stage in m_Stages)
            {
                var node = new StgNode("Stage");
                stage.SaveToStg(node);
                stages.AddNode(node);
            }

            var teams = aiNode.GetNode("Teams");
            foreach (var team in m_Teams)
            {
                var node = new StgNode("Team");
                team.SaveToStg(node);
                teams.AddNode(node);
            }

            var groups = aiNode.GetNode("Groups");
            foreach (var group in m_Groups)
            {
                var node = new StgNode("Group");
                group.SaveToStg(node);
                groups.AddNode(node);
            }

            doc.Save(m_Path);
        }
    }
}
