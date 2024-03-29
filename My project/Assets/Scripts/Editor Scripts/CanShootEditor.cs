using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
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
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fireRate"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}


#endif