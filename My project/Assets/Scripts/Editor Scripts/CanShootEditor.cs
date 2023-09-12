using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Troop))]
[CanEditMultipleObjects]
public class CanShootEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var myScript = (Troop)target;


        if (myScript.CanShoot)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("bulletPrefab"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("firePoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("range"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}


