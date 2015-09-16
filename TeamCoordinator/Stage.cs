using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    enum StageState
    {
        Open,
        Closed,
        Occupied
    }

    class Stage
    {
        private string m_Name;
        public string Description = "";
        public StageState State = StageState.Open;

        public Stage(string name)
        {
            m_Name = name;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }
    }
}
