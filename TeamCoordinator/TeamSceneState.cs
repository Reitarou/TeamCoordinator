using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCoordinator
{
    public enum TeamSceneState
    {
        Pass = -100,
        Pause = -50,
        Incomplete = 0,
        OtherSame = 5,
        Sent = 10,
        OnWork = 50,
        OnBack = 90,
        Completed = 100,
        Ready = 200,
        Unknown = -1000,
    }
}
