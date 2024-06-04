using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShaderPropertyEdit))]
public class ShaderPropertiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ShaderPropertyEdit myScript = (ShaderPropertyEdit)target;
        if (GUILayout.Button("Load Properties"))
        {
            myScript.LoadProperties();
        }
        if (GUILayout.Button("Generate Properties"))
        {
            myScript.GenerateRandomProperties();
        }
    }
}
