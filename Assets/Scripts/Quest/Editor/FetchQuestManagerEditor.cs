using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(FetchQuestManager))]
public class FetchQuestManagerEditor : Editor
{
    SerializedProperty quest;

    ReorderableList questList;

    


    private void OnEnable()
    {
        quest = serializedObject.FindProperty("Quests");
        questList = new ReorderableList(serializedObject, quest, true, true, true, true);

        questList.drawElementCallback = DrawQuestListItems;
        questList.drawHeaderCallback = DrawQuestHeader;

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
        EditorGUI.PropertyField(new Rect(rect.x + 455, rect.y, 20, EditorGUIUtility.singleLineHeight),
            destList);

        EditorGUI.Toggle(
            new Rect(rect.x + 520, rect.y, 20, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("isDone").boolValue
        );


    }

    void DrawQuestHeader(Rect rect)
    {
        string name = "Quests";
        EditorGUI.LabelField(rect, name);
    }
}
