// File: Assets/Editor/RemoveMissingComponents.cs

using UnityEngine;
using UnityEditor;

public class RemoveMissingComponents : MonoBehaviour
{
    [MenuItem("Tools/Remove Missing Components In Scene")]
    static void RemoveMissing()
    {
        int count = 0;
        // Use FindObjectsByType instead of FindObjectsOfType
        foreach (GameObject go in GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            SerializedObject so = new SerializedObject(go);
            SerializedProperty prop = so.FindProperty("m_Component");
            int r = 0;
            for (int i = 0; i < prop.arraySize; i++)
            {
                var component = prop.GetArrayElementAtIndex(i).objectReferenceValue;
                if (component == null)
                {
                    prop.DeleteArrayElementAtIndex(i);
                    r++;
                }
            }
            if (r > 0)
            {
                count += r;
                so.ApplyModifiedProperties();
                Debug.Log($"Removed {r} missing components from {go.name}");
            }
        }
        Debug.Log($"Done! Total missing components removed: {count}");
    }
}
