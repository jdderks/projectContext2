using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaveGenerator : MonoBehaviour
{
    [SerializeField]
    private float WaveHeight = 0.1f;
    private MeshFilter mf;
    void Start()
    {
        mf = GetComponent<MeshFilter>();
    }

    void Update()
    {

    }
}
