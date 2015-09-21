using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    class Team
    {
        private int m_ID = -1;
        public string Name = "";
        public int Group = -1;
        public Dictionary<string, int> Stages = new Dictionary<string, int>();
        public bool IsReady = true;
        public int CurrentStage = -1;

        public Team()
        {
        }

        public Team(StgNode node)
        {
            m_ID = node.GetInt("ID", -1);
            Name = node.GetString("Name", "");
            Group = node.GetInt("Group", -1);
            IsReady = node.GetBoolean("IsReady", true);
            
            var stageNodes = node.GetNodes("Stage");
            foreach (var stageNode in stageNodes)
            {
                var name = stageNode.GetString("Name", "");
                if (name != "")
                {
                    var state = stageNode.GetInt("State", -1);
                    Stages.Add(name, state);
                }
            }
        }

        public int ID
        {
            get
            {
                return m_ID;
            }
        }

        public void SetID(int id)
        {
            m_ID = id;
        }

        //public List<int> CurrentStages
        //{
        //    get
        //    {
        //        var res = new List<int>();
        //        foreach (var pair in Stages)
        //        {
        //            if (pair.Value == 0)
        //            {
        //                res.Add(pair.Key);
        //            }
        //        }
        //        return res;
        //    }
        //}

        public void SaveToStg(StgNode node)
        {
            node.AddInt("ID", m_ID);
            node.AddString("Name", Name);
            node.AddInt("Group", Group);
            node.AddBoolean("IsReady", IsReady);
            foreach (var stage in Stages)
            {
                var stageNode = new StgNode("Stage");
                stageNode.AddString("Name", stage.Key);
                stageNode.AddInt("State", stage.Value);
                node.AddNode(stageNode);
            }
        }
    }
}
