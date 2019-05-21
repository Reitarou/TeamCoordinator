using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Stg;

namespace TeamCoordinator
{
    public class TeamLogRecord
    {
        public DateTime Time;
        public string Location;
        public TeamState State;

        public TeamLogRecord(string location, TeamState state)
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
            State = (TeamState)node.GetInt32("State", (int)TeamState.Unknown);
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
        private List<string> m_IncompleteStages = new List<string>();
        private List<string> m_CompleteStages = new List<string>();
        private List<TeamLogRecord> m_Log;

        public Team(AI ai)
            :base(ai)
        {
            m_Log = new List<TeamLogRecord>();
            m_Log.Add(new TeamLogRecord("", TeamState.Pause));
        }

        public TeamLogRecord LastRecord
        {
            get
            {
                return m_Log.Last();
            }
        }

        public IEnumerable<Stage> IncompletedStages
        {
            get
            {
                foreach (var stage in AI.Stages)
                {
                    if (m_IncompleteStages.Contains(stage.ID))
                        yield return stage;
                }
            }
        }

        public IEnumerable<TeamLogRecord> Records
        {
            get
            {
                foreach (var record in m_Log)
                {
                    yield return record;
                }
            }
        }

        public int IncompleteStagesCount
        {
            get
            {
                return m_IncompleteStages.Count;
            }
        }

        public int CompleteStagesCount
        {
            get
            {
                return m_CompleteStages.Count;
            }
        }

        public void NewState(string location, TeamState state)
        {
            m_Log.Add(new TeamLogRecord(location, state));
        }

        public TeamState State
        {
            get
            {
                return m_Log.Last().State;
            }
        }

        public TeamState GetStateByScene(string sceneId)
        {
            var scene = AI.GetSceneByID(sceneId);
            if (scene == null)
            {
                Debug.Fail("How??");
                return TeamState.Unknown;
            }

            var lastLog = m_Log.Last();
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
                    return TeamState.Unknown;
                }
                if (lastLogScene.StageID == scene.StageID)
                {
                    return TeamState.AtOtherScene;
                }
            }
            foreach (var id in m_IncompleteStages)
            {
                if (id == scene.StageID)
                    return TeamState.Incomplete;
            }
            foreach (var id in m_CompleteStages)
            {
                if (id == scene.StageID)
                    return TeamState.Completed;
            }
            return TeamState.Pass;
        }

        public int StageState(string id)
        {
            if (m_IncompleteStages.Contains(id))
            {
                return 0;
            }
            if (m_CompleteStages.Contains(id))
            {
                return 1;
            }
            return -1;
        }

        public void PassStage(string id)
        {
            if (m_IncompleteStages.Contains(id))
            {
                m_IncompleteStages.Remove(id);
            }
            if (m_CompleteStages.Contains(id))
            {
                m_CompleteStages.Remove(id);
            }
        }

        public void IncompleteStage(string id)
        {
            if (!m_IncompleteStages.Contains(id))
            {
                m_IncompleteStages.Add(id);
            }
            if (m_CompleteStages.Contains(id))
            {
                m_CompleteStages.Remove(id);
            }
        }

        public void CompleteStage(string id)
        {
            if (m_IncompleteStages.Contains(id))
            {
                m_IncompleteStages.Remove(id);
            }
            if (!m_CompleteStages.Contains(id))
            {
                m_CompleteStages.Add(id);
            }
        }

        public void ClearStages()
        {
            m_IncompleteStages.Clear();
            m_CompleteStages.Clear();
        }

        #region IStgSerializable Members

        protected override void OnLoad(StgNode node)
        {
            Name = node.GetString("Name", "");
            GroupID = node.GetString("GroupID", "");

            m_IncompleteStages.Clear();
            var array = node.GetArray("IncompleteStages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var id = n.GetString("ID", "");
                if (id != "")
                {
                    m_IncompleteStages.Add(id);
                }
            }

            m_CompleteStages.Clear();
            array = node.GetArray("CompleteStages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var id = n.GetString("ID", "");
                if (id != "")
                {
                    m_CompleteStages.Add(id);
                }
            }

            m_Log.Clear();
            array = node.GetArray("Log", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                m_Log.Add(new TeamLogRecord(n));
            }
        }

        protected override void OnSave(StgNode node)
        {
            node.AddString("Name", Name);
            node.AddString("GroupID", GroupID);
            var array = node.AddArray("IncompleteStages", StgType.Node);
            foreach (var stage in m_IncompleteStages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage);
            }
            array = node.AddArray("CompleteStages", StgType.Node);
            foreach (var stage in m_CompleteStages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage);
            }
            array = node.AddArray("Log", StgType.Node);
            foreach(var record in m_Log)
            {
                var n = array.AddNode();
                record.SaveToStg(n);
            }
        }

        #endregion
    }
}
