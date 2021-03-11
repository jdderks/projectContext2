using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField]
    private string destinationName;
    [SerializeField]
    private bool playerIsHere;

    private bool playerIsNotMoving;


    public string CommunityName { get => destinationName; set => destinationName = value; }
    public bool PlayerIsHere { get => playerIsHere; set => playerIsHere = value; }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = false;
        }
    }

}
