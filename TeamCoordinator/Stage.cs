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
        public int ID;
        public string Name;
        public string Desription;
        public StageState State = StageState.Open;
        public List<Team> Teams;

        public Stage()
        {
            Teams = new List<Team>();
        }
    }
}
