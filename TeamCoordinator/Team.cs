using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    class Team : Item
    {
        public string Name = "";
        public string GroupID = "";
        public Dictionary<string, int> Stages = new Dictionary<string, int>();
        public string CurrentScene = "";
        public DateTime SceneStarted = DateTime.MinValue;
        public bool IsReady = true;

        public Team(AI ai)
            :base(ai)
        {
        }

        public Team(AI ai, StgNode node)
            :base(ai, node)
        {
        }

        public int IncompleteStages
        {
            get
            {
                int cnt = 0;
                foreach(var stage in Stages)
                {
                    if (stage.Value == 0)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
        }

        public int CompleteStages
        {
            get
            {
                int cnt = 0;
                foreach (var stage in Stages)
                {
                    if (stage.Value == 1)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
        }

        #region IStgSerializable Members

        public override void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID", "");
            if (m_ID == "") m_ID = Guid.NewGuid().ToString();
            Name = node.GetString("Name", "");
            GroupID = node.GetString("GroupID", "");
            IsReady = node.GetBoolean("IsReady", true);
            var array = node.GetArray("Stages", StgType.Node);
            Stages.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var name = n.GetString("Name", "");
                if (name != "")
                {
                    int state = n.GetInt16("State", -1);
                    Stages.Add(name, state);
                }
            }
            CurrentScene = node.GetString("CurrentScene", "");
            var timeSceneStarted = node.GetString("SceneStarted", "");
            if (timeSceneStarted != "")
            {
                SceneStarted = DateTime.Parse(timeSceneStarted);
            }
        }

        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            node.AddString("Name", Name);
            node.AddString("GroupID", GroupID);
            node.AddBoolean("IsReady", IsReady);
            var array = node.AddArray("Stages", StgType.Node);
            foreach (var stage in Stages)
            {
                var n = array.AddNode();
                n.AddString("Name", stage.Key);
                n.AddInt16("State", (short)stage.Value);
            }
            node.AddString("CurrentScene", CurrentScene);
            node.AddString("SceneStarted", SceneStarted.ToShortTimeString());
        }

        #endregion
    }
}
