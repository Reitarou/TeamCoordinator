using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    class Stage : Item
    {
        public string Name = "";
        public string ShortName = "";
        public List<string> AvailableGroups = new List<string>();

        public Stage(AI ai)
            : base(ai)
        {
        }

        public Stage(AI ai, StgNode node)
            : base(ai, node)
        {
        }

        #region IStgSerializable Members

        public override void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID", "");
            if (m_ID == "") m_ID = Guid.NewGuid().ToString();
            Name = node.GetString("Name", "");
            ShortName = node.GetString("ShortName", "");
            var array = node.GetArray("AvailableGroups", StgType.String);
            for (int i = 0; i < array.Count; i++)
            {
                var s = array[i] as string;
                if (s != string.Empty)
                {
                    AvailableGroups.Add(s);
                }
            }
        }

        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            node.AddString("Name", Name);
            node.AddString("ShortName", ShortName);
            var array = node.AddArray("AvailableGroups", StgType.String);
            foreach (var item in AvailableGroups)
            {
                array.AddString(item);
            }
        }

        #endregion
    }
}
