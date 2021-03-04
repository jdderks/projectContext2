using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum FetchQuestSteps
{
    notRetreived = 0,
    retrieved = 1,
    delivered = 2
}

[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObjects/Quest")]
public class FetchQuest : ScriptableObject
{
    [Header("FetchQuest")]
    [InfoBox("With this you can configure your own quests, if something is unclear please message Joris")]

    [ResizableTextArea]
    public string FlavorText = "Default";

    public bool DestinationsAreRandom = false;

    [DisableIf("CommunitiesAreRandom")]
    public Destination communityToGetFrom;
    [DisableIf("CommunitiesAreRandom")]
    public Destination communityToDeliverTo;

    public FetchQuestSteps currentStep = FetchQuestSteps.notRetreived;
}
