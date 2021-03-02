﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObjects/Quest")]
public class FetchQuest : ScriptableObject
{
    [Header("FetchQuest")]
    [InfoBox("With this you can configure your own quests, if something is unclear please message Joris")]

    [ResizableTextArea]
    public string FlavorText = "Default";

    public bool CommunitiesAreRandom = false;

    [DisableIf("CommunitiesAreRandom")]
    public Community communityToGetFrom;
    [DisableIf("CommunitiesAreRandom")]
    public Community communityToDeliverTo;
}
