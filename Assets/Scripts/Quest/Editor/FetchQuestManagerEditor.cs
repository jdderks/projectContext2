using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

/*
[CustomPropertyDrawer(typeof(Destination))] 
public class DestinationDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        GUI.Label(position, new GUIContent("TEST"));
        //EditorGUILayout.LabelField("TEST");
	}
}
*/

[CustomEditor(typeof(FetchQuestManager))]
public class FetchQuestManagerEditor : Editor
{
    SerializedProperty quest;

    ReorderableList questList;

    static Dictionary<int, int> heights = new Dictionary<int, int>();

    private void OnEnable()
    {
        quest = serializedObject.FindProperty("Quests");
        questList = new ReorderableList(serializedObject, quest, true, true, true, true);

        questList.drawElementCallback = DrawQuestListItems;
        questList.drawHeaderCallback = DrawQuestHeader;
        questList.elementHeightCallback = DrawHeight;
    }
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        serializedObject.Update();
        questList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    void DrawQuestListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = questList.serializedProperty.GetArrayElementAtIndex(index);
        SerializedProperty destList = element.FindPropertyRelative("destinations");

        //var height = (questList.count + 3) * EditorGUIUtility.singleLineHeight;
        //questList.DoList(new Rect(rect.x, rect.y, rect.width, height));

        //The Quest name
        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y, 160, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("questName"),
            GUIContent.none);

        //The Locations enum
        EditorGUI.PropertyField(
            new Rect(rect.x + 165, rect.y, 120, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("types"),
            GUIContent.none);

        //The text part of the Destination part
        EditorGUI.LabelField(new Rect(rect.x + 290, rect.y, 200, EditorGUIUtility.singleLineHeight), "Destination Number:");

        //The text input field of the Destination part
        EditorGUI.PropertyField(
            new Rect(rect.x + 415, rect.y, 20, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("currentDestinationNumber"),
            GUIContent.none
        );

        //EditorGUILayout.PropertyField(destList, true);
        if (EditorGUI.PropertyField(new Rect(rect.x + 455, rect.y, 20, EditorGUIUtility.singleLineHeight), destList))
        {
            if (destList.arraySize <= 0)
            {
                EditorGUI.LabelField(new Rect(rect.x + 455, rect.y + 20, 250f, EditorGUIUtility.singleLineHeight), "You have not assigned any destinations");
                heights[index] = 20;
            }

            for (int i = 0; i < destList.arraySize; ++i)
            {
                SerializedProperty destination = destList.GetArrayElementAtIndex(i);

                SerializedProperty destName = destination.FindPropertyRelative("destinationName");

                Destination d = destination.objectReferenceValue as Destination;

                if (d != null)
                {
                    EditorGUI.LabelField(new Rect(rect.x + 455, rect.y + 20 + 20 * i, 100f, EditorGUIUtility.singleLineHeight), d.destinationName);
                    if (GUI.Button(new Rect(rect.x + 550, rect.y + 20 + 20 * i, 15f, EditorGUIUtility.singleLineHeight),"-"))
                    {
                        var elementProperty = destList.GetArrayElementAtIndex(i);
                        if (destList.GetArrayElementAtIndex(i).objectReferenceValue != null)
                        {
                            destList.GetArrayElementAtIndex(i).objectReferenceValue = null;
                        }
                        destList.DeleteArrayElementAtIndex(i);
                    }
                }
            }
            heights[index] = destList.arraySize * 20;
        }
        else
        {
            heights[index] = 0;
        }
        GUI.enabled = false;
        EditorGUI.Toggle(
            new Rect(rect.x + 600, rect.y, 20, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("isDone").boolValue
        );
        GUI.enabled = true;


    }

    void DrawQuestHeader(Rect rect)
    {
        string name = "Quests";
        EditorGUI.LabelField(rect, name);
    }

    public float DrawHeight(int index)
    {

        if (heights.ContainsKey(index))
        {
            return 20 + heights[index];
        }
        else return 20;
    }
}
