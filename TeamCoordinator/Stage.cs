using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TeamCoordinator
{
    class Stage
    {
        private int m_ID = -1;
        public string Number = "";
        public string Name = "";
        public string Coach = "";
        public bool IsClosed = false;
        public List<int> AvaliableGroups = new List<int>();

        public Stage()
        {
        }

        public Stage(StgNode node)
        {
            m_ID = node.GetInt("ID", -1);
            Number = node.GetString("Number", "");
            Name = node.GetString("Name", "");
            Coach = node.GetString("Coach", "");
            IsClosed = node.GetBoolean("IsClosed", false);
            var avgs = node.GetInts("AvailableGroup");
            foreach (var avg in avgs)
            {
                AvaliableGroups.Add(avg);
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

        public void SaveToStg(StgNode node)
        {
            node.AddInt("ID", m_ID);
            node.AddString("Number", Number);
            node.AddString("Name", Name);
            node.AddString("Coach", Coach);
            node.AddBoolean("IsClosed", IsClosed);
            foreach (var avg in AvaliableGroups)
            {
                node.AddIntElement("AvailableGroup", avg);
            }
        }
    }
}
