using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentQuestText;

    [SerializeField]
    private GameObject destinationPanel;

    [SerializeField]
    private TextMeshProUGUI nextDestinationText;

    [SerializeField]
    private FetchQuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAllUIElements();
    }

    private void UpdateAllUIElements()
    {
        UpdateQuestUI();
        UpdateDestinationUI();
    }

    private void UpdateQuestUI()
    {
        if (questManager.CurrentQuest != null) {
            currentQuestText.text = questManager.CurrentQuest.questName;
        } else
        {
            currentQuestText.text = "No active quests.";
        }
    }

    private void UpdateDestinationUI()
    {
        if (questManager.CurrentQuest != null)
        {
            destinationPanel.SetActive(true);
            nextDestinationText.text = questManager.CurrentQuest.destinations[questManager.CurrentQuest.currentDestinationNumber].CommunityName;
        } 
        else
        {
            destinationPanel.SetActive(false);
        }

    }
}
