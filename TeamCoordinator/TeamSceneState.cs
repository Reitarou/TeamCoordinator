namespace TeamCoordinator
{
    public enum TeamState
    {
        Pass = -100,
        Pause = -50,
        Incomplete = 0,
        AtOtherScene = 5,
        CallToBase = 10,
        SentToScene = 20,
        StartWork = 50,
        MoveBack = 90,
        Completed = 100,
        Ready = 200,
        Unknown = -1000,
    }
}