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
    private Community communityToGoTo;


    private void Start()
    {

    }

    [Button]
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
    [Button]
    private void ClearCommunitiesList()
    {
        communities = new List<Community>();
    }
}
