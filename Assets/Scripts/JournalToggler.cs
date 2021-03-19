using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JournalToggler : MonoBehaviour
{
    public Sprite eerstePagina;
    public Sprite tweedePagina;
    public Sprite derdePagina;

    [HideInInspector]
    public Image CurrentImage;

    public int activePage = 0;

    private void Start()
    {
        CurrentImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (activePage == 0)
        {
            CurrentImage.sprite = eerstePagina;
        } 
        else if(activePage == 1)
        {
            CurrentImage.sprite = tweedePagina;
        }
        else if (activePage == 2)
        {
            CurrentImage.sprite = derdePagina;
        }
    }

    public void ToggleJournal()
    {
        if (gameObject.active)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


    public void NextPage()
    {
        if (activePage < 2)
        {
            activePage++;
        } else
        {
            activePage = 0;
        }
    }

    public void PreviousPage()
    {
        if (activePage > 0)
        {
            activePage--;
        }
        else
        {
            activePage = 2;
        }
    }

}
