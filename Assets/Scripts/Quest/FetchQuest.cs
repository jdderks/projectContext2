using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FetchQuest
{
    public enum QuestTypes
    {
        DeliverFromTo,
        Travel,
        Tutorial,
        GoToCondition
    }

    public string questName;
    public QuestTypes types;

    public Destination homeDestination = null;

    public List<Destination> destinations;
    public int currentDestinationNumber;
    public bool isDone;

    public UnityEvent finishedEvent;

    public bool isLookingForWind = false;
    public bool isLookingForSunlight = false;
    public bool isLookingForWater = false;
}
