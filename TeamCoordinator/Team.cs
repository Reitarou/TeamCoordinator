using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    class Team
    {
        public string m_Name;
        public string Desription = "";
        public Dictionary<string, bool> Stages = new Dictionary<string, bool>();

        public Team(string name)
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
