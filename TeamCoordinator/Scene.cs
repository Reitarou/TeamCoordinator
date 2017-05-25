﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Stg;

namespace TeamCoordinator
{
    

    public class Scene : Item
    {
        #region Comparer

        public class SceneComparer : IComparer<Scene>
        {
            public int Compare(Scene x, Scene y)
            {
                var ai = x.AI;

                var xStage = ai.GetStageByID(x.StageID);
                var yStage = ai.GetStageByID(y.StageID);

                if (xStage == null && yStage == null)
                {
                    return 0;
                }
                else if (xStage == null)
                {
                    return -1;
                }
                else if (yStage == null)
                {
                    return 1;
                }
                //else
                var cStages = xStage.Name.CompareTo(yStage.Name);
                if (cStages != 0)
                {
                    return cStages;
                }
                //else
                return x.Number.CompareTo(y.Number);
            }
        }

        public static readonly IComparer<Scene> Comparer = new SceneComparer();

        #endregion

        public string StageID = "";
        public string Number = "";
        public string Coach = "";
        public bool IsReady = true;
        public DateTime ChangeStateTime = DateTime.Now;

        public Scene(AI ai)
            :base(ai)
        {
        }

        public int GetState()
        {
            if (!IsReady)
            {
                return -1;
            }
            foreach (var team in AI.Teams)
            {
                if (team.Log.Last().Location == ID)
                    return 0;
            }
            return 1;
        }

        #region IStgSerializable Members

        protected override void OnLoad(StgNode node)
        {
            StageID = node.GetString("StageID", "");
            Number = node.GetString("Number", "");
            Coach = node.GetString("Coach", "");
            IsReady = node.GetBoolean("IsReady", true);
            DateTime dt;
            string dts = node.GetString("ChangeStateTime", "");
            if (DateTime.TryParse(dts, out dt))
            {
                ChangeStateTime = dt;
            }
        }

        protected override void OnSave(StgNode node)
        {
            node.AddString("StageID", StageID);
            node.AddString("Number", Number);
            node.AddString("Coach", Coach);
            node.AddBoolean("IsReady", IsReady);
            node.AddString("ChangeStateTime", ChangeStateTime.ToShortTimeString());
        }

        #endregion
    }
}
