using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FetchQuestManager : MonoBehaviour
{


    [SerializeField]
    private GameObject player;

    [Header("Quests")]
    public List<Destination> AllDestinations = new List<Destination>();

    public List<FetchQuest> Quests = new List<FetchQuest>();

    [HideInInspector]
    private FetchQuest currentQuest = null;

    public FetchQuest CurrentQuest { get => currentQuest; set => currentQuest = value; }
    public GameObject Player { get => player; set => player = value; }

    private void Start()
    {
        FillAllDestinationsList();
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
                                        CompleteQuest();
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
                    for (int i = 0; i < AllDestinations.Count; i++)
                    {
                        if (AllDestinations[i].PlayerIsHere)
                        {
                            Debug.Log("Looking for: Sun: " + CurrentQuest.isLookingForSunlight + " Wind: " + CurrentQuest.isLookingForWind + " Water: " + CurrentQuest.isLookingForWater);
                            Debug.Log("Here be:          " + AllDestinations[i].hasSunlight    + " Wind: " + AllDestinations[i].hasWind    + " Water: " + AllDestinations[i].hasWater);
                            if (CurrentQuest.isLookingForSunlight == AllDestinations[i].hasSunlight &&
                                CurrentQuest.isLookingForWind == AllDestinations[i].hasWind &&
                                CurrentQuest.isLookingForWater == AllDestinations[i].hasWater)
                            {
                                CompleteQuest();
                                break;
                            }
                        }
                    }
                    break;
                default:
                    break;
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
        return availableQuests[Random.Range(0, availableQuests.Count)];
    }

    private void CompleteQuest()
    {
        currentQuest.isDone = true;
        currentQuest = null;
    }

    private void FillAllDestinationsList()
    {
        Destination[] dests = FindObjectsOfType<Destination>();
        for (int i = 0; i < dests.Length; i++)
        {
            AllDestinations.Add(dests[i]);
        }
    }
}