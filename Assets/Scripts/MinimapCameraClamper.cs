using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraClamper : MonoBehaviour
{
    Quaternion fixedRotation;

    private void Awake()
    {
        fixedRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = fixedRotation;
    }
}
