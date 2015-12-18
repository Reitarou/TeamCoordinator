using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Stg;

namespace TeamCoordinator
{
    class Scene : Item
    {
        public Stage m_Stage = null;
        public string Number = "";
        public string Coach = "";
        public DateTime? ClosedTime = null;

        public Scene(AI ai)
            :base(ai)
        {
        }

        public Scene(AI ai, StgNode node)
            :base(ai, node)
        {
        }

        #region IStgSerializable Members

        public override void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID", "");
            if (m_ID == "") m_ID = Guid.NewGuid().ToString();
            //m_Stage = node.GetString("Stage", "");
            Number = node.GetString("Number", "");
            Coach = node.GetString("Coach", "");
            var closedTime = node.GetString("ClosedTime", null);
            if (closedTime != "null")
            {
                ClosedTime = DateTime.Parse(closedTime);
            }
        }

        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            //node.AddString("Stage", Stage);
            node.AddString("Number", Number);
            node.AddString("Coach", Coach);
            node.AddString("ClosedTime", (ClosedTime.HasValue)? ClosedTime.Value.ToShortTimeString() : "null");
        }

        #endregion
    }
}
