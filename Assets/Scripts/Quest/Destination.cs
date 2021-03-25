using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class Destination : MonoBehaviour
{
    [SerializeField]
    public string destinationName;

    [SerializeField]
    private TextMeshProUGUI destinationText;

    [SerializeField]
    private bool isBase;

    private bool playerIsHere;

    public bool hasSunlight;
    public bool hasWind;
    public bool hasWater;
    [Space]
    [SerializeField]
    private Image waterImg;
    [SerializeField]
    private Image windImg;
    [SerializeField]
    private Image sunImg;
    [Space]
    public Sprite hasWaterSprite;
    public Sprite hasWindSprite;
    public Sprite hasSunSprite;
    
    public Sprite hasNoWaterSprite;
    public Sprite hasNoWindSprite;
    public Sprite hasNoSunSprite;

    //These variables will do something in the future.
    public Resources currentResource;

    [SerializeField]
    public UnityEvent destinationEvent = null;

    public string CommunityName { get => destinationName; set => destinationName = value; }
    public bool PlayerIsHere { get => playerIsHere; set => playerIsHere = value; }
    public bool IsBase { get => isBase; set => isBase = value; }

    private void Awake()
    {
        if (destinationText != null)
        {
            destinationText.text = destinationName;
        }
        if (waterImg != null)
        {
        waterImg.sprite = hasWater ? hasWaterSprite : hasNoWaterSprite;
        }
        if (windImg != null)
        {
            windImg.sprite = hasWind ? hasWindSprite : hasNoWindSprite;
        }
        if (sunImg != null)
        {
            sunImg.sprite = hasSunlight ? hasSunSprite : hasNoSunSprite;
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