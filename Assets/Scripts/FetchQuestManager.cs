using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class FetchQuestManager : MonoBehaviour
{
    
    [Header("Quests")]
    [SerializeField]
    [ProgressBar("Progress", 100, EColor.Red)]
    private float questProgress = 0;

    [SerializeField]

    private List<FetchQuest> Quests = new List<FetchQuest>();

    [Header("Communities")]
    [SerializeField]
    private List<Community> communities = new List<Community>();

    [SerializeField]
    private FetchQuest currentQuest;

    [SerializeField]
    private Community currentTarget;

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    private void StartRandomQuest()
    {
        currentQuest = Quests[Random.Range(0, Quests.Count)];
        if (currentQuest.CommunitiesAreRandom)
        {
            int random1 = Random.Range(0, communities.Count);
            int random2 = Random.Range(0, communities.Count);
            if (random1 == random2)
            {
                if (random2 > communities.Count)
                {
                    random2 = 0;
                } else
                {
                    random2++;
                }
                
            }
            currentQuest.communityToDeliverTo = communities[random1];
            currentQuest.communityToGetFrom = communities[random2];
        }
        currentQuest.currentStep = FetchQuestSteps.notRetreived;
    }

    private void Update()
    {
        if (currentQuest)
        {
            if (currentQuest.currentStep == FetchQuestSteps.notRetreived)
            {
                currentTarget = currentQuest.communityToGetFrom;
            }
        }
    }

    [Button(enabledMode: EButtonEnableMode.Editor)]
    private void UpdateCommunitiesList()
    {
        GameObject[] _communities = GameObject.FindGameObjectsWithTag("Community");
        for (int i = 0; i < _communities.Length; i++)
        {
            Community com = _communities[i].GetComponent<Community>();
            if (!communities.Contains(com))
            {
                communities.Add(com);
            }
        }
    }

}
