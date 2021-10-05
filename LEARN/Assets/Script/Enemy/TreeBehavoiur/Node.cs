



using UnityEngine;

public enum NodeStat
    {
        SUCCESS,
        RUNNING,
        FAILURE
    }
public abstract class Node 
{
    protected NodeStat currentStat;
    public NodeStat _currentStat { get => currentStat; }



    public abstract NodeStat Evaluate();
}
