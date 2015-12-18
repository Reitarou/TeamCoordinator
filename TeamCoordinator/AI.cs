using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamCoordinator.Properties;
using System.Xml.Linq;
using System.IO;
using Stg;

namespace TeamCoordinator
{
    class AI
    {
        private string m_Path;
        private List<Group> m_Groups;
        private List<Scene> m_Scenes;
        private List<Team> m_Teams;
        private List<Stage> m_Stages;

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
                    var doc = new StgDocument();
                    doc.LoadFromFileAsXml(path);
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
                return m_Stages;
            }
        }

        public List<Scene> Scenes
        {
            get
            {
                m_Scenes.Sort((a,b) => a.Number.CompareTo(b.Number));
                return m_Scenes;
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
            m_Stages.Add(stage);
        }

        public void AddScene(Scene scene)
        {
            m_Scenes.Add(scene);
        }

        public Team AddTeam()
        {
            var team = new Team(this);
            m_Teams.Add(team);
            return team;
        }

        public void AddGroup(Group group)
        {
            m_Groups.Add(group);
        }

        //public Scene GetScene(string id)
        //{
        //    foreach (var stage in m_Scenes)
        //    {
        //        if (stage.ID == id)
        //        {
        //            return stage;
        //        }
        //    }
        //    return null;
        //}

        //public Scene GetStage(string name)
        //{
        //    foreach (var stage in m_Scenes)
        //    {
        //        if (stage.Name == name)
        //        {
        //            return stage;
        //        }
        //    }
        //    return null;
        //}

        //public Team GetTeam(string id)
        //{
        //    foreach (var team in m_Teams)
        //    {
        //        if (team.ID == id)
        //        {
        //            return team;
        //        }
        //    }
        //    return null;
        //}

        //public Group GetGroup(int id)
        //{
        //    foreach (var group in m_Groups)
        //    {
        //        if (group.ID == id)
        //        {
        //            return group;
        //        }
        //    }
        //    return null;
        //}

        //public List<int> GetStageState(Scene stage)
        //{
        //    if (stage.IsClosed)
        //    {
        //        return null;
        //    }
        //    var res = new List<int>();

        //    foreach (var team in m_Teams)
        //    {
        //        var index = team.CurrentStages.BinarySearch(stage.ID);
        //        if (index >= 0)
        //        {
        //            res.Add(team.ID);
        //        }
        //    }

        //    return res;
        //}

        //public int GetState(Scene stage, Team team)
        //{
        //    if (team.Stages.ContainsKey(stage.Name))
        //    {
        //        return team.Stages[stage.Name];
        //    }
        //    return -1;
        //}

        //public void CheckTeams()
        //{
        //    foreach (var team in m_Teams)
        //    {
        //        foreach (var stage in m_Scenes)
        //        {
        //            if (!team.Stages.ContainsKey(stage.Name))
        //            {
        //                team.Stages.Add(stage.Name, -1);
        //            }
        //        }
        //    }
        //}

        public void LoadFromStg(StgDocument doc)
        {
            m_Stages = new List<Stage>();
            var array = doc.Body.GetArray("Stages", StgType.Node);
            for (int i = 0; i<array.Count; i++)
            {
                var node = array[i] as StgNode;
                if (node != null)
                {
                    m_Stages.Add(new Stage(this, node));
                }
            }
            
            m_Scenes = new List<Scene>();
            array = doc.Body.GetArray("Scenes", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                if (node != null)
                {
                    m_Scenes.Add(new Scene(this, node));
                }
            }

            m_Teams = new List<Team>();
            array = doc.Body.GetArray("Teams", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                if (node != null)
                {
                    m_Teams.Add(new Team(this, node));
                }
            }

            m_Groups = new List<Group>();
            array = doc.Body.GetArray("Groups", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                if (node != null)
                {
                    m_Groups.Add(new Group(this, node));
                }
            }
        }

        public void SaveToStg()
        {
            if (!File.Exists(m_Path))
            {
                File.Create(m_Path);
            }

            var doc = new StgDocument();

            var nodes = doc.Body.AddArray("Stages", StgType.Node);
            foreach (var item in m_Stages)
            {
                var node = nodes.AddNode();
                item.SaveToStg(node);
            }

            nodes = doc.Body.AddArray("Scenes", StgType.Node);
            foreach (var item in m_Scenes)
            {
                var node = nodes.AddNode();
                item.SaveToStg(node);
            }

            nodes = doc.Body.AddArray("Teams", StgType.Node);
            foreach (var item in m_Teams)
            {
                var node = nodes.AddNode();
                item.SaveToStg(node);
            }

            nodes = doc.Body.AddArray("Groups", StgType.Node);
            foreach (var item in m_Groups)
            {
                var node = nodes.AddNode();
                item.SaveToStg(node);
            }
            doc.SaveToFileAsXml(m_Path);
        }
    }
}
