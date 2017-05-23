using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    struct TeamTimerEvent
    {
        public const string c_NotReady = "NotReady";
        public const string c_Ready = "Ready";
        public const string c_OnNextStages = "OnNextStages";

        public DateTime Time;
        public string Location;

        public static TeamTimerEvent LoadFromStg(StgNode node)
        {
            var result = new TeamTimerEvent();

            var time = node.GetString("Time", "");
            if (!DateTime.TryParse(time, out result.Time))
            {
                result.Time = DateTime.Now;
            }
            result.Location = node.GetString("Location", c_NotReady);
            return result;
        }

        public void SaveToStg(StgNode node)
        {
            node.AddString("Time", Time.ToShortTimeString());
            node.AddString("Location", Location);
        }
    }


    class Team : Item
    {
        public string Name = "";
        public string GroupID = "";
        public Dictionary<string, int> Stages = new Dictionary<string, int>();
        private List<TeamTimerEvent> m_Log = new List<TeamTimerEvent>();

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

        public string State
        {
            get
            {
                if (m_Log.Count==0)
                {
                    return TeamTimerEvent.c_NotReady;
                }
                return m_Log.Last().Location;
            }
            set
            {
                m_Log.Add(new TeamTimerEvent() { Time = DateTime.Now, Location = value });
            }
        }

        public DateTime ChangeStateTime
        {
            get
            {
                if (m_Log.Count==0)
                {
                    return DateTime.Now;
                }
                return m_Log.Last().Time;
            }
        }

        #region IStgSerializable Members

        public override void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID", "");
            if (m_ID == "") m_ID = Guid.NewGuid().ToString();
            Name = node.GetString("Name", "");
            GroupID = node.GetString("GroupID", "");

            Stages.Clear();
            var array = node.GetArray("Stages", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                var name = n.GetString("ID", "");
                if (name != "")
                {
                    int state = n.GetInt16("State", -1);
                    Stages.Add(name, state);
                }
            }

            m_Log.Clear();
            array = node.GetArray("Log", StgType.Node);
            for (int i = 0; i < array.Count; i++)
            {
                var n = array.GetNode(i);
                m_Log.Add(TeamTimerEvent.LoadFromStg(n));
            }
        }

        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            node.AddString("Name", Name);
            node.AddString("GroupID", GroupID);
            var array = node.AddArray("Stages", StgType.Node);
            foreach (var stage in Stages)
            {
                var n = array.AddNode();
                n.AddString("ID", stage.Key);
                n.AddInt16("State", (short)stage.Value);
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
