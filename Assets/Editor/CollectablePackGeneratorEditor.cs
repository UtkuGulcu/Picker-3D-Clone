using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CollectablePackGenerator))]
public class CollectablePackGeneratorEditor : Editor
{
    private SerializedProperty collectableReference;
    private SerializedProperty packTypeProp;
    private SerializedProperty lineLengthProp;
    private SerializedProperty gridWidthProp;
    private SerializedProperty gridHeightProp;

    private void OnEnable()
    {
        collectableReference = serializedObject.FindProperty("collectable");
        packTypeProp = serializedObject.FindProperty("packType");
        lineLengthProp = serializedObject.FindProperty("length");
        gridWidthProp = serializedObject.FindProperty("width");
        gridHeightProp = serializedObject.FindProperty("height");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(collectableReference);
        EditorGUILayout.PropertyField(packTypeProp);

        if (packTypeProp.enumValueIndex == (int) CollectablePackGenerator.PackType.Line)
        {
            EditorGUILayout.PropertyField(lineLengthProp, new GUIContent("Length"));
            
            gridWidthProp.intValue = 0;
            gridHeightProp.intValue = 0;
        }
        else if (packTypeProp.enumValueIndex == (int) CollectablePackGenerator.PackType.Grid)
        {
            EditorGUILayout.PropertyField(gridWidthProp, new GUIContent("Width"));
            EditorGUILayout.PropertyField(gridHeightProp, new GUIContent("Height"));
            
            lineLengthProp.intValue = 0;
        }

        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Generate"))
        {
            CollectablePackGenerator collectablePackGenerator = (CollectablePackGenerator)target;
            
            if (packTypeProp.enumValueIndex == (int) CollectablePackGenerator.PackType.Line)
            {
                collectablePackGenerator.GenerateLine();
            }
            else if (packTypeProp.enumValueIndex == (int) CollectablePackGenerator.PackType.Grid)
            {
                collectablePackGenerator.GenerateGrid();
            }
        }
    }
}
