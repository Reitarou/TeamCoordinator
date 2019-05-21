using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Stg;
using TeamCoordinator.Properties;

namespace TeamCoordinator
{
    public class AI
    {
        private string m_Path;
        private Dictionary<string, Group> m_Groups;
        private Dictionary<string, Scene> m_Scenes;
        private Dictionary<string, Team> m_Teams;
        private Dictionary<string, Stage> m_Stages;

        public bool RebuildGrid { get; set; } = true;

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

        #region Collection

        #region Teams

        public IEnumerable<Team> Teams
        {
            get
            {
                var list = new List<Team>();
                foreach (var pair in m_Teams)
                {
                    var index = list.BinarySearch(pair.Value, Team.Comparer);
                    list.Insert(~index, pair.Value);
                }
                return list;
            }
        }

        public Team AddTeam()
        {
            var team = new Team(this);
            m_Teams.Add(team.ID, team);
            RebuildGrid = true;
            return team;
        }

        public Team GetTeamByID(string id)
        {
            if (m_Teams.ContainsKey(id))
                return m_Teams[id];
            return null;
        }

        public Team GetTeamByName(string name)
        {
            foreach (var pair in m_Teams)
            {
                if (pair.Value.Name == name)
                    return pair.Value;
            }
            return null;
        }

        public void RemoveTeam(string id)
        {
            if (m_Teams.ContainsKey(id))
            {
                m_Teams.Remove(id);
                RebuildGrid = true;
            }
        }

        #endregion

        #region Groups

        public IEnumerable<Group> Groups
        {
            get
            {
                var list = new List<Group>();
                foreach (var pair in m_Groups)
                {
                    var index = list.BinarySearch(pair.Value, Group.Comparer);
                    list.Insert(~index, pair.Value);
                }
                return list;
            }
        }

        public Group AddGroup()
        {
            var team = new Group(this);
            m_Groups.Add(team.ID, team);
            RebuildGrid = true;
            return team;
        }

        public Group GetGroupByID(string id)
        {
            if (m_Groups.ContainsKey(id))
                return m_Groups[id];
            return null;
        }

        public Group GetGroupByName(string name)
        {
            foreach (var pair in m_Groups)
            {
                if (pair.Value.Name == name)
                    return pair.Value;
            }
            return null;
        }

        public void RemoveGroup(string id)
        {
            if (m_Groups.ContainsKey(id))
            {
                m_Groups.Remove(id);
                RebuildGrid = true;
            }
        }

        #endregion

        #region Stages

        public IEnumerable<Stage> Stages
        {
            get
            {
                var list = new List<Stage>();
                foreach (var pair in m_Stages)
                {
                    var index = list.BinarySearch(pair.Value, Stage.Comparer);
                    list.Insert(~index, pair.Value);
                }
                return list;
            }
        }

        public Stage AddStage()
        {
            var team = new Stage(this);
            m_Stages.Add(team.ID, team);
            RebuildGrid = true;
            return team;
        }

        public Stage GetStageByID(string id)
        {
            if (m_Stages.ContainsKey(id))
                return m_Stages[id];
            return null;
        }

        public Stage GetStageByName(string name)
        {
            foreach (var pair in m_Stages)
            {
                if (pair.Value.Name == name)
                    return pair.Value;
            }
            return null;
        }

        public void RemoveStage(string id)
        {
            if (m_Stages.ContainsKey(id))
            {
                m_Stages.Remove(id);
                RebuildGrid = true;
            }
        }

        #endregion

        #region Scenes

        public IEnumerable<Scene> Scenes
        {
            get
            {
                var list = new List<Scene>();
                foreach (var pair in m_Scenes)
                {
                    var index = list.BinarySearch(pair.Value, Scene.Comparer);
                    if (index < 0)
                        index = ~index;
                    list.Insert(index, pair.Value);
                }
                return list;
            }
        }

        public Scene AddScene()
        {
            var scene = new Scene(this);
            m_Scenes.Add(scene.ID, scene);
            RebuildGrid = true;
            return scene;
        }

        public Scene GetSceneByID(string id)
        {
            if (m_Scenes.ContainsKey(id))
                return m_Scenes[id];
            return null;
        }

        //public Scene GetSceneByName(string name)
        //{
        //    foreach (var pair in m_Scenes)
        //    {
        //        if (pair.Value.Name == name)
        //            return pair.Value;
        //    }
        //    return null;
        //}

        public void RemoveScene(string id)
        {
            if (m_Scenes.ContainsKey(id))
            {
                m_Scenes.Remove(id);
                RebuildGrid = true;
            }
        }

        #endregion

        #endregion

        #region IStgSerializable

        public void LoadFromStg(StgDocument doc)
        {
            m_Stages = new Dictionary<string, Stage>();
            var array = doc.Body.GetArray("Stages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                var item = new Stage(this);
                item.LoadFromStg(node);
                m_Stages.Add(item.ID, item);
            }

            m_Scenes = new Dictionary<string, Scene>();
            array = doc.Body.GetArray("Scenes", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                var item = new Scene(this);
                item.LoadFromStg(node);
                m_Scenes.Add(item.ID, item);
            }

            m_Teams = new Dictionary<string, Team>();
            array = doc.Body.GetArray("Teams", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                var item = new Team(this);
                item.LoadFromStg(node);
                m_Teams.Add(item.ID, item);
            }

            m_Groups = new Dictionary<string, Group>();
            array = doc.Body.GetArray("Groups", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                var item = new Group(this);
                item.LoadFromStg(node);
                m_Groups.Add(item.ID, item);
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
            foreach (var pair in m_Stages)
            {
                var node = nodes.AddNode();
                pair.Value.SaveToStg(node);
            }

            nodes = doc.Body.AddArray("Scenes", StgType.Node);
            foreach (var pair in m_Scenes)
            {
                var node = nodes.AddNode();
                pair.Value.SaveToStg(node);
            }

            nodes = doc.Body.AddArray("Teams", StgType.Node);
            foreach (var pair in m_Teams)
            {
                var node = nodes.AddNode();
                pair.Value.SaveToStg(node);
            }

            nodes = doc.Body.AddArray("Groups", StgType.Node);
            foreach (var pair in m_Groups)
            {
                var node = nodes.AddNode();
                pair.Value.SaveToStg(node);
            }
            doc.SaveToFileAsXml(m_Path);
        }

        #endregion
    }
}