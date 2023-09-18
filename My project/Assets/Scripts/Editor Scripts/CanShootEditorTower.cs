using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Tower))]
[CanEditMultipleObjects]
public class CanShootEditorTower : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var myScript = (Tower)target;


        if (myScript.CanShoot)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("bulletPrefab"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rotationPoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("firePoint"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("range"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("turnSpeed"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fireRate"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}


#endif