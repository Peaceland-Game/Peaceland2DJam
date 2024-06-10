using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MushroomTool)), CanEditMultipleObjects]
public class MushroomToolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MushroomTool myScript = (MushroomTool)target;
        if (GUILayout.Button("Reset Mushrooms"))
        {
            myScript.ResetMushrooms();
        }
    }
}
