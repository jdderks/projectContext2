using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField]
    private string destinationName;
    [SerializeField]
    private int workProgress = 0;
    public string CommunityName { get => destinationName; set => destinationName = value; }
    public int WorkProgress { get => workProgress; set => workProgress = value; }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            workProgress++;
        }
    }

}
