using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    class Group : Item, IStgSerializable
    {
        public string Name = "";
        public string ShortName = "";

        public Group(AI ai)
            :base(ai)
        {
        }

        public Group(AI ai, StgNode node)
            :base(ai, node)
        {
        }

        public override string ToString()
        {
            return Name;
        }

        #region IStgSerializable Members

        public override void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID", "");
            if (m_ID == "") m_ID = Guid.NewGuid().ToString();
            Name = node.GetString("Name", "");
            ShortName = node.GetString("ShortName", "");
        }
        
        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            node.AddString("Name", Name);
            node.AddString("ShortName", ShortName);
        }

        #endregion
    }
}
