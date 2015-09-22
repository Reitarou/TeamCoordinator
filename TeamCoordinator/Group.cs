using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    class Group
    {
        private int m_ID = -1;
        public string Name = "";
        public string ShortName = "";

        public Group()
        {
        }

        public Group(StgNode node)
        {
            m_ID = node.GetInt("ID", -1);
            Name = node.GetString("Name", "");
            ShortName = node.GetString("ShortName", "");
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
            node.AddString("Name", Name);
            node.AddString("ShortName", ShortName);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
