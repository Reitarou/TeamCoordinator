using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    class Team
    {
        public int ID;
        public string Name;
        public Dictionary<int, bool> Stages = new Dictionary<int, bool>();
    }
}
