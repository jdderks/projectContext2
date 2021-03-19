using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;



public class Destination : MonoBehaviour
{
    [SerializeField]
    public string destinationName;

    [SerializeField]
    private TextMeshProUGUI destinationText;
    [SerializeField]
    private bool playerIsHere;

    public bool hasSunlight;
    public bool hasWind;
    public bool hasWater;

    //These variables will do something in the future.
    public Resources currentResource;

    [SerializeField]
    public UnityEvent destinationEvent = null;

    public string CommunityName { get => destinationName; set => destinationName = value; }
    public bool PlayerIsHere { get => playerIsHere; set => playerIsHere = value; }

    private void Awake()
    {
        if (destinationText != null)
        {
            destinationText.text = destinationName;
        }
    }

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