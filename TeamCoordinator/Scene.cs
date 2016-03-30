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
        public string StageID = "";
        public string Number = "";
        public string Coach = "";
        public bool IsReady = true;
        public DateTime ChangeStateTime = DateTime.MinValue;

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
            StageID = node.GetString("StageID", "");
            Number = node.GetString("Number", "");
            Coach = node.GetString("Coach", "");
            IsReady = node.GetBoolean("IsReady", true);
            var closedTime = node.GetString("ChangeStateTime", "");
            if (closedTime != "")
            {
                ChangeStateTime = DateTime.Parse(closedTime);
            }
        }

        public override void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            node.AddString("StageID", StageID);
            node.AddString("Number", Number);
            node.AddString("Coach", Coach);
            node.AddBoolean("IsReady", IsReady);
            node.AddString("ChangeStateTime", ChangeStateTime.ToShortTimeString());
        }

        #endregion
    }
}
