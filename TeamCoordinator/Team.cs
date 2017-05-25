using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    public class TeamLogRecord
    {
        public DateTime Time;
        public string Location;
        public TeamSceneState State;

        public TeamLogRecord(string location, TeamSceneState state)
        {
            Time = DateTime.Now;
            Location = location;
            State = state;
        }

        public TeamLogRecord(StgNode node)
        {
            var time = node.GetString("Time", "");
            if (!DateTime.TryParse(time, out Time))
            {
                Debug.Fail("How?");
                Time = DateTime.Now;
            }
            Location = node.GetString("Location", "");
            State = (TeamSceneState)node.GetInt32("State", (int)TeamSceneState.Unknown);
        }

        public void SaveToStg(StgNode node)
        {
            node.AddString("Time", Time.ToShortTimeString());
            node.AddString("Location", Location);
            node.AddInt32("State", (int)State);
        }
    }

    public class Team : Item
    {
        #region Comparer

        public class TeamComparer : IComparer<Team>
        {
            public int Compare(Team x, Team y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        public static readonly IComparer<Team> Comparer = new TeamComparer();

        #endregion

        public string Name = "";
        public string GroupID = "";
        public List<string> IncompleteStages = new List<string>();
        public List<string> CompleteStages = new List<string>();
        public List<TeamLogRecord> Log;

        public Team(AI ai)
            :base(ai)
        {
            Log = new List<TeamLogRecord>();
            Log.Add(new TeamLogRecord("", TeamSceneState.Pause));
        }

        public int GetState()
        {
            var lastLog = Log.Last();
            if (lastLog.Location == "")
            {
                if (lastLog.State == TeamSceneState.Pause)
                    return -1;
                else if (lastLog.State == TeamSceneState.Ready)
                    return 1;
                else
                    Debug.Fail("How?");
                return 1;
            }
            return 0;
        }

        public TeamSceneState GetStateByScene(string sceneId)
        {
            var scene = AI.GetSceneByID(sceneId);
            if (scene == null)
            {
                Debug.Fail("How??");
                return TeamSceneState.Unknown;
            }

            var lastLog = Log.Last();
            if (lastLog.Location == sceneId)
            {
                return lastLog.State;
            }

            if (lastLog.Location != "")
            {
                var lastLogScene = AI.GetSceneByID(lastLog.Location);
                if (lastLogScene == null)
                {
                    Debug.Fail("How??");
                    return TeamSceneState.Unknown;
                }
                if (lastLogScene.StageID == scene.StageID)
                {
                    return TeamSceneState.OtherSame;
                }
            }
            foreach (var id in IncompleteStages)
            {
                if (id == scene.StageID)
                    return TeamSceneState.Incomplete;
            }
            foreach (var id in CompleteStages)
            {
                if (id == scene.StageID)
                    return TeamSceneState.Completed;
            }
            return TeamSceneState.Pass;
        }

        #region IStgSerializable Members

        protected override void OnLoad(StgNode node)
        {
            Name = node.GetString("Name", "");
            GroupID = node.GetString("GroupID", "");

            IncompleteStages.Clear();
            var array = node.GetArray("IncompleteStages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var id = n.GetString("ID", "");
                if (id != "")
                {
                    IncompleteStages.Add(id);
                }
            }

            CompleteStages.Clear();
            array = node.GetArray("CompleteStages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var id = n.GetString("ID", "");
                if (id != "")
                {
                    CompleteStages.Add(id);
                }
            }

            Log.Clear();
            array = node.GetArray("Log", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                Log.Add(new TeamLogRecord(n));
            }
        }

        protected override void OnSave(StgNode node)
        {
            node.AddString("Name", Name);
            node.AddString("GroupID", GroupID);
            var array = node.AddArray("IncompleteStages", StgType.Node);
            foreach (var stage in IncompleteStages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage);
            }
            array = node.AddArray("CompleteStages", StgType.Node);
            foreach (var stage in CompleteStages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage);
            }
            array = node.AddArray("Log", StgType.Node);
            foreach(var record in Log)
            {
                var n = array.AddNode();
                record.SaveToStg(n);
            }
        }

        #endregion
    }
}
