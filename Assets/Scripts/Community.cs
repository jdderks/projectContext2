using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Community : MonoBehaviour
{
    [SerializeField]
    private string communityName;
    [SerializeField]
    private int workProgress = 0;
    public string CommunityName { get => communityName; set => communityName = value; }
    public int WorkProgress { get => workProgress; set => workProgress = value; }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            workProgress++;
        }
    }

}
