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
        public int Group = -1;
        public Dictionary<string, int> Stages = new Dictionary<string, int>();
        public List<int> CurrentStages = new List<int>();
        public bool IsReady = true;

        public Team(AI ai)
            :base(ai)
        {
        }

        public Team(AI ai, StgNode node)
            :base(ai, node)
        {
            
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

        #region IStgSerializable Members

        public override void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID", "");
            if (m_ID == "") m_ID = Guid.NewGuid().ToString();
            Name = node.GetString("Name", "");
            //Group = node.GetInt32("Group", -1);
            //IsReady = node.GetBoolean("IsReady", true);

            //var stageNodes = node.GetNodes("Stage");
            //foreach (var stageNode in stageNodes)
            //{
            //    var name = stageNode.GetString("Name", "");
            //    if (name != "")
            //    {
            //        var state = stageNode.GetInt("State", -1);
            //        Stages.Add(name, state);
            //    }
            //}

            //var cStageNodes = node.GetNodes("CurrentStage");
            //foreach (var cStageNode in cStageNodes)
            //{
            //    var cStageID = cStageNode.GetInt("ID", -1);
            //    if (cStageID > 0)
            //    {
            //        var index = CurrentStages.BinarySearch(cStageID);
            //        if (index < 0)
            //        {
            //            CurrentStages.Insert(~index, cStageID);
            //        }
            //    }
            //}
        }

        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            node.AddString("Name", Name);
            //node.AddInt32("Group", Group);
            //node.AddBoolean("IsReady", IsReady);
            //foreach (var stage in Stages)
            //{
            //    var stageNode = new StgNode("Stage");
            //    stageNode.AddString("Name", stage.Key);
            //    stageNode.AddInt("State", stage.Value);
            //    node.AddNode(stageNode);
            //}
            //foreach (var cstage in CurrentStages)
            //{
            //    var cstageNode = new StgNode("CurrentStage");
            //    cstageNode.AddInt("ID", cstage);
            //    node.AddNode(cstageNode);
            //}
        }

        #endregion
    }
}
