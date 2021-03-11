using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FetchQuestManager : MonoBehaviour
{
    [SerializeField]
    public Destination homeBase;

    [SerializeField]
    private BoatController player;

    [Header("Quests")]
    public List<FetchQuest> Quests = new List<FetchQuest>();

    [HideInInspector]
    private FetchQuest currentQuest;

    public FetchQuest CurrentQuest { get => currentQuest; set => currentQuest = value; }

    private void Start()
    {
        CurrentQuest = Quests[0];
    }

    private void Update()
    {
        QuestProgress();
    }

    private void QuestProgress()
    {
        if (CurrentQuest != null)
        {
            for (int i = 0; i < CurrentQuest.destinations.Count; i++)
            {
                if (CurrentQuest.destinations[i].PlayerIsHere)
                {
                    if (CurrentQuest.currentDestinationNumber == i)
                    {
                        Debug.Log("Player arrived at at: " + CurrentQuest.destinations[i].CommunityName);
                        if (player.GetComponent<Rigidbody>().velocity.x < 1 && player.GetComponent<Rigidbody>().velocity.z < 1)
                        {
                            Debug.Log("Player delivered at: " + CurrentQuest.destinations[i].CommunityName);
                            CurrentQuest.currentDestinationNumber++;
                            if (CurrentQuest.currentDestinationNumber == currentQuest.destinations.Count)
                            {
                                currentQuest.isDone = true;
                                currentQuest = null;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    private FetchQuest GetNewAvailableQuest()
    {
        List<FetchQuest> availableQuests = new List<FetchQuest>();

        for (int i = 0; i < Quests.Count; i++)
        {
            if (!Quests[i].isDone)
            {
                availableQuests.Add(Quests[i]);
            }
        }
        return availableQuests[Random.Range(0,availableQuests.Count)];
    }
 
}