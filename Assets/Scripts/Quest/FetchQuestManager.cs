using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class FetchQuestManager : MonoBehaviour
{
    
    [Header("Quests")]
    [SerializeField]
    [ProgressBar("Quest Progress", 100, EColor.Red)]
    private float questProgress = 0;

    [SerializeField]

    private List<FetchQuest> Quests = new List<FetchQuest>();

    [Header("Communities")]
    [SerializeField]
    private List<Destination> destinations = new List<Destination>();

    [SerializeField]
    private FetchQuest currentQuest;

    [SerializeField]
    private Destination currentDestination;

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    private void StartRandomQuest()
    {
        currentQuest = Quests[Random.Range(0, Quests.Count)];
        if (currentQuest.DestinationsAreRandom)
        {
            int random1 = Random.Range(0, destinations.Count);
            int random2 = Random.Range(0, destinations.Count);
            if (random1 == random2)
            {
                if (random2 > destinations.Count)
                {
                    random2 = 0;
                } else
                {
                    random2++;
                }
                
            }
            currentQuest.communityToDeliverTo = destinations[random1];
            currentQuest.communityToGetFrom = destinations[random2];
        }
        currentQuest.currentStep = FetchQuestSteps.notRetreived;
    }

    private void Update()
    {
        if (currentQuest)
        {
            if (currentQuest.currentStep == FetchQuestSteps.notRetreived)
            {
                currentDestination = currentQuest.communityToGetFrom;
            }
        }
    }

    [Button(enabledMode: EButtonEnableMode.Editor)]
    private void UpdateCommunitiesList()
    {
        GameObject[] _communities = GameObject.FindGameObjectsWithTag("Community");
        for (int i = 0; i < _communities.Length; i++)
        {
            Destination com = _communities[i].GetComponent<Destination>();
            if (!destinations.Contains(com))
            {
                destinations.Add(com);
            }
        }
    }

}
