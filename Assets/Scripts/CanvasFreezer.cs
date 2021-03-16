using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CanvasFreezer : MonoBehaviour
{
    

    private void Awake()
    {
        transform.eulerAngles = new Vector3(90,0,0);
    }
}
