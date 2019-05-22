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
        private Items<Group> m_Groups = new Items<Group>(Group.Comparer);
        private Items<Scene> m_Scenes = new Items<Scene>(Scene.Comparer);
        private Items<Team> m_Teams = new Items<Team>(Team.Comparer);
        private Items<Stage> m_Stages = new Items<Stage>(Stage.Comparer);

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

        public Items<Group> Groups { get { return m_Groups; } }

        public Items<Scene> Scenes { get { return m_Scenes; } }

        public Items<Team> Teams { get { return m_Teams; } }

        public Items<Stage> Stages { get { return m_Stages; } }

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

        #region IStgSerializable

        public void LoadFromStg(StgDocument doc)
        {
            var array = doc.Body.GetArray("Stages", StgType.Node);
            m_Stages.LoadFromStg(this, array, delegate (AI ai, StgNode node)
            { var item = new Stage(ai); item.LoadFromStg(node); return item; });

            array = doc.Body.GetArray("Scenes", StgType.Node);
            m_Scenes.LoadFromStg(this, array, delegate (AI ai, StgNode node)
            { var item = new Scene(ai); item.LoadFromStg(node); return item; });

            array = doc.Body.GetArray("Teams", StgType.Node);
            m_Teams.LoadFromStg(this, array, delegate (AI ai, StgNode node)
            { var item = new Team(ai); item.LoadFromStg(node); return item; });

            array = doc.Body.GetArray("Groups", StgType.Node);
            m_Groups.LoadFromStg(this, array, delegate (AI ai, StgNode node)
            { var item = new Group(ai); item.LoadFromStg(node); return item; });
        }

        public void SaveToStg()
        {
            if (!File.Exists(m_Path))
            {
                File.Create(m_Path);
            }

            var doc = new StgDocument();
            var nodes = doc.Body.AddArray("Stages", StgType.Node);
            m_Stages.SaveToStg(nodes);
            nodes = doc.Body.AddArray("Scenes", StgType.Node);
            m_Scenes.SaveToStg(nodes);
            nodes = doc.Body.AddArray("Teams", StgType.Node);
            m_Teams.SaveToStg(nodes);
            nodes = doc.Body.AddArray("Groups", StgType.Node);
            m_Groups.SaveToStg(nodes);

            doc.SaveToFileAsXml(m_Path);
        }

        #endregion
    }
}