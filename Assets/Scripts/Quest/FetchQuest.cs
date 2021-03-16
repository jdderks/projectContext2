using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class FetchQuest
{
    public enum QuestTypes{
        FetchSomething,
        DeliverFromTo,
        Travel,
        Tutorial
    }

    public string questName;
    public QuestTypes types;
    public List<Destination> destinations;
    public int currentDestinationNumber;
    public bool isDone;
}
