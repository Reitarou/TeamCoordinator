using System;
using System.Collections.Generic;
using System.Linq;
using Stg;

namespace TeamCoordinator
{
    public enum SceneState
    {
        NotReady = -1,
        Occuped = 0,
        Ready = 1
    }

    public class Scene : Item
    {
        #region Comparer

        public class SceneComparer : IComparer<Scene>
        {
            public int Compare(Scene x, Scene y)
            {
                var ai = x.AI;

                var xStage = ai.Stages[x.StageID];
                var yStage = ai.Stages[y.StageID];

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

        public Guid StageID = Guid.Empty;
        public string Number = "Сцена";
        public string Coach = "";
        public bool IsReady = true;
        public DateTime ChangeStateTime = DateTime.Now;

        public Scene(AI ai)
            : base(ai)
        {
        }

        public SceneState State
        {
            get
            {
                if (!IsReady)
                {
                    return SceneState.NotReady;
                }
                foreach (var team in AI.Teams.All)
                {
                    var lr = team.LastRecord;
                    if (lr.Location == ID && (lr.State == TeamState.CallToBase || lr.State == TeamState.SentToScene || lr.State == TeamState.StartWork))
                        return SceneState.Occuped;
                }
                return SceneState.Ready;
            }
        }

        public string Name
        {
            get
            {
                string stageName = "N/A";
                var stage = AI.Stages[StageID];
                if (stage != null)
                {
                    stageName = (stage.ShortName == "") ? stage.Name : stage.ShortName;
                }
                return (Number == "") ? stageName : string.Format("{0} - {1}", stageName, Number);
            }
        }

        #region IStgSerializable Members

        protected override void OnLoad(StgNode node)
        {
            StageID = Tools.CreateFromString(node.GetString("StageID", string.Empty));
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
            node.AddString("StageID", StageID.ToString());
            node.AddString("Number", Number);
            node.AddString("Coach", Coach);
            node.AddBoolean("IsReady", IsReady);
            node.AddString("ChangeStateTime", ChangeStateTime.ToShortTimeString());
        }

        #endregion
    }
}
