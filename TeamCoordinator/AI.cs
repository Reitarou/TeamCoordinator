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
        private Dictionary<string, Stage> m_Stages;
        private Dictionary<string, Team> m_Teams;

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

        public Dictionary<string, Stage> Stages
        {
            get
            {
                return m_Stages;
            }
        }

        public void LoadFromStg(XDocument doc)
        {
            m_Stages = new Dictionary<string, Stage>();

            var stages = doc.Element("AI").Element("Stages").Elements("Stage");
            foreach (var xStage in stages)
            {
                var xName = xStage.Attribute("Name");
                if (xName != null && !m_Stages.ContainsKey(xName.Value))
                {
                    var stage = new Stage(xName.Value);
                    var xDescription = xStage.Attribute("Description");
                    stage.Description = (xDescription == null)? "" : xDescription.Value;
                    m_Stages.Add(stage.Name, stage);
                }
            }

            m_Teams = new Dictionary<string, Team>();
            var teams = doc.Element("AI").Element("Teams").Elements("Team");

            foreach (var xTeam in teams)
            {
                var xName = xTeam.Attribute("Name");
                if (xName != null && !m_Teams.ContainsKey(xName.Value))
                {
                    var team = new Team(xName.Value);
                    var xDescription = xTeam.Attribute("Description");
                    team.Desription = (xDescription == null) ? "" : xDescription.Value;
                    m_Teams.Add(team.Name, team);
                }
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
                new XElement("Teams")));

            foreach (var pair in m_Stages)
            {
                var stage = pair.Value;
                var xStage = new XElement("Stage");
                xStage.Add(new XAttribute("Name", stage.Name));
                xStage.Add(new XAttribute("Description", stage.Description));
                doc.Element("AI").Element("Stages").Add(xStage);
            }

            foreach (var pair in m_Teams)
            {
                var team = pair.Value;
                var xTeam = new XElement("Team");
                xTeam.Add(new XAttribute("Name", team.Name));
                xTeam.Add(new XAttribute("Description", team.Desription));
                doc.Element("AI").Element("Teams").Add(xTeam);
            }

            doc.Save(m_Path);
        }
    }
}
