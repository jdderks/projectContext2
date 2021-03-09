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



        for (int i = 0; i < dest.currentTechnologies.Count; i++)
        {
            dest.currentTechnologies[i].active = GUILayout.Toggle(dest.currentTechnologies[i].active, dest.currentTechnologies[i].name);
            //GUILayout.Toggle(isTriggered, "Yeeaeet");
        }
    }
}
