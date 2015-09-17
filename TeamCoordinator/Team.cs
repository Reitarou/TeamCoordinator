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
        public string Description = "";
        public List<KeyValuePair<int, int>> Stages = new List<KeyValuePair<int, int>>();
        public bool IsReady = true;

        public Team()
        {
        }

        public Team(StgNode node)
        {
            m_ID = node.GetInt("ID", -1);
            Name = node.GetString("Name", "");
            Description = node.GetString("Description", "");
            IsReady = node.GetBoolean("IsReady", true);
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

        public List<int> CurrentStages
        {
            get
            {
                var res = new List<int>();
                foreach (var pair in Stages)
                {
                    if (pair.Value == 0)
                    {
                        res.Add(pair.Key);
                    }
                }
                return res;
            }
        }

        public void SaveToStg(StgNode node)
        {
            node.AddInt("ID", m_ID);
            node.AddString("Name", Name);
            node.AddString("Description", Description);
            node.AddBoolean("IsReady", IsReady);
        }
    }
}
