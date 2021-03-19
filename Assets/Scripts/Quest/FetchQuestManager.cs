using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FetchQuestManager : MonoBehaviour
{


    [SerializeField]
    private GameObject player;

    [Header("Quests")]
    public List<FetchQuest> Quests = new List<FetchQuest>();

    [HideInInspector]
    private FetchQuest currentQuest = null;

    public FetchQuest CurrentQuest { get => currentQuest; set => currentQuest = value; }
    public GameObject Player { get => player; set => player = value; }

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
        if (currentQuest != null)
        {
            switch (currentQuest.types)
            {
                case FetchQuest.QuestTypes.DeliverFromTo:
                    break;
                case FetchQuest.QuestTypes.Travel:
                    for (int i = 0; i < CurrentQuest.destinations.Count; i++)
                    {
                        if (CurrentQuest.destinations[i].PlayerIsHere)
                        {
                            if (CurrentQuest.currentDestinationNumber == i)
                            {
                                Debug.Log("Player arrived at at: " + CurrentQuest.destinations[i].CommunityName);
                                if (Player.GetComponent<Rigidbody>().velocity.x < 1 && Player.GetComponent<Rigidbody>().velocity.z < 1)
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
                    break;
                case FetchQuest.QuestTypes.Tutorial:


                    break;
                case FetchQuest.QuestTypes.GoToCondition:
                    for (int i = 0; i < CurrentQuest.destinations.Count; i++)
                    {
                        if (CurrentQuest.destinations[i].PlayerIsHere && CurrentQuest.currentDestinationNumber == i)
                        {
                            if (CurrentQuest.isLookingForSunlight == CurrentQuest.destinations[i].hasSunlight && 
                                CurrentQuest.isLookingForWind == CurrentQuest.destinations[i].hasWind &&
                                CurrentQuest.isLookingForWater == currentQuest.destinations[i].hasWater)
                            {
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
                    break;
                default:
                    break;
            }
        }


        //TODO: Make this more readable by using &&
        //ALTHOUGH: this loop has given me errors in some weird scenarios in other ways so I'm keeping it like this for now.

        //if (CurrentQuest != null)
        //{
        //    for (int i = 0; i < CurrentQuest.destinations.Count; i++)
        //    {
        //        if (CurrentQuest.destinations[i].PlayerIsHere)
        //        {
        //            if (CurrentQuest.currentDestinationNumber == i)
        //            {
        //                Debug.Log("Player arrived at at: " + CurrentQuest.destinations[i].CommunityName);
        //                if (Player.GetComponent<Rigidbody>().velocity.x < 1 && Player.GetComponent<Rigidbody>().velocity.z < 1)
        //                {
        //                    Debug.Log("Player delivered at: " + CurrentQuest.destinations[i].CommunityName);
        //                    CurrentQuest.currentDestinationNumber++;
        //                    if (CurrentQuest.currentDestinationNumber == currentQuest.destinations.Count)
        //                    {
        //                        currentQuest.isDone = true;
        //                        currentQuest = null;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
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
        return availableQuests[Random.Range(0, availableQuests.Count)];
    }

}