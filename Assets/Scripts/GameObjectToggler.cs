using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToggler : MonoBehaviour
{
    public void ToggleGameObject(GameObject gameObj)
    {
        if (gameObj.activeSelf)
        {
            gameObj.SetActive(false);
        } 
        else
        {
            gameObj.SetActive(true);
        }
    }
}
