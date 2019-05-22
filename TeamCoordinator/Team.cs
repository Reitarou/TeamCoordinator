using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Stg;
using TeamCoordinator.Properties;

namespace TeamCoordinator
{
    public class TeamLogRecord
    {
        public DateTime Time;
        public Guid Location = Guid.Empty;
        public string LocationName;
        public TeamState State;

        public TeamLogRecord(Scene scene, TeamState state)
        {
            Time = DateTime.Now;
            if (scene != null)
            {
                Location = scene.ID;
                LocationName = scene.Name;
            }
            else
            {
                Location = Guid.Empty;
                LocationName = Resources.sBase;
            }
            State = state;
        }

        public TeamLogRecord(string comment, TeamLogRecord prev, bool setTimeStamp)
        {
            Time = setTimeStamp ? DateTime.Now : prev.Time;
            Location = prev.Location;
            LocationName = comment;
            State = prev.State;
        }

        public TeamLogRecord(StgNode node)
        {
            var time = node.GetString("Time", string.Empty);
            if (!DateTime.TryParse(time, out Time))
            {
                Debug.Fail("How?");
                Time = DateTime.Now;
            }
            Location = Tools.CreateFromString(node.GetString("Location", string.Empty));
            LocationName = node.GetString("LocationName", string.Empty);
            State = (TeamState)node.GetInt32("State", (int)TeamState.Unknown);
        }

        public void SaveToStg(StgNode node)
        {
            node.AddString("Time", Time.ToShortTimeString());
            node.AddString("Location", Location.ToString());
            node.AddString("LocationName", LocationName);
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

        public string Name = "Команда";
        public Guid GroupID = Guid.Empty;
        private List<Guid> m_IncompleteStages = new List<Guid>();
        private List<Guid> m_CompleteStages = new List<Guid>();
        private List<TeamLogRecord> m_Log;

        public Team(AI ai)
            : base(ai)
        {
            m_Log = new List<TeamLogRecord>();
            m_Log.Add(new TeamLogRecord(null, TeamState.Pause));
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
                foreach (var stage in AI.Stages.All)
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

        public IEnumerable<string> RecordsLog
        {
            get
            {
                yield return string.Format("=== {0} ===", Name);
                foreach (var record in Records)
                {
                    var time = record.Time.ToShortTimeString();
                    var location = record.LocationName;

                    #region подгрузка старых данных
                    if (location.Length == 0)
                    {
                        if (record.Location == Guid.Empty)
                            location = Resources.sBase;
                        else
                        {
                            var scene = AI.Scenes[record.Location];
                            if (scene != null)
                            {
                                location = scene.Name;
                            }
                        }
                    }
                    #endregion

                    while (location.Length < 8)
                        location += " ";
                    var action = string.Empty;
                    if (record.State != TeamState.Comment)
                        action = TeamStateEnumConverter.Current.ConvertToString(record.State);
                    yield return string.Format("{0}  {1} [{2}]", time, location, action);
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

        public void NewState(Scene scene, TeamState state)
        {
            m_Log.Add(new TeamLogRecord(scene, state));
        }

        public void AddComment(string comment, bool setTimeStamp)
        {
            m_Log.Add(new TeamLogRecord(comment, m_Log.Last(), setTimeStamp));
        }

        public Scene CurrentScene
        {
            get
            {
                var record = m_Log.Last();
                return AI.Scenes[record.Location];
            }
        }

        public TeamState State
        {
            get
            {
                return m_Log.Last().State;
            }
        }

        public TeamState GetStateByScene(Guid sceneId)
        {
            var scene = AI.Scenes[sceneId];
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

            if (lastLog.Location != Guid.Empty)
            {
                var lastLogScene = AI.Scenes[lastLog.Location];
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

        public int StageState(Guid id)
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

        public void PassStage(Guid id)
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

        public void IncompleteStage(Guid id)
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

        public void CompleteStage(Guid id)
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
            GroupID = Tools.CreateFromString(node.GetString("GroupID", string.Empty));

            m_IncompleteStages.Clear();
            var array = node.GetArray("IncompleteStages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var id = Tools.CreateFromString(n.GetString("ID", string.Empty));
                if (id != Guid.Empty)
                {
                    m_IncompleteStages.Add(id);
                }
            }

            m_CompleteStages.Clear();
            array = node.GetArray("CompleteStages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var id = Tools.CreateFromString(n.GetString("ID", string.Empty));
                if (id != Guid.Empty)
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
            node.AddString("GroupID", GroupID.ToString());
            var array = node.AddArray("IncompleteStages", StgType.Node);
            foreach (var stage in m_IncompleteStages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage.ToString());
            }
            array = node.AddArray("CompleteStages", StgType.Node);
            foreach (var stage in m_CompleteStages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage.ToString());
            }
            array = node.AddArray("Log", StgType.Node);
            foreach (var record in m_Log)
            {
                var n = array.AddNode();
                record.SaveToStg(n);
            }
        }

        #endregion
    }
}
