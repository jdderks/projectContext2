using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Destination))]
[CanEditMultipleObjects]
public class DestinationEditor : Editor
{


    public override void OnInspectorGUI()
    {
        Destination dest = target as Destination;
        base.OnInspectorGUI();


    }
}
