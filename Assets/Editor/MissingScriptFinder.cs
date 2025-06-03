using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class MissingScriptFinder : MonoBehaviour
{
    [MenuItem("Tools/Find Missing Scripts in Project")]
    public static void FindMissingScriptsInProject()
    {
        int goCount = 0;
        int componentsCount = 0;
        int missingCount = 0;

        string[] allPrefabs = AssetDatabase.GetAllAssetPaths();
        foreach (string path in allPrefabs)
        {
            if (path.EndsWith(".prefab") || path.EndsWith(".unity"))
            {
                GameObject[] roots = null;

                if (path.EndsWith(".prefab"))
                {
                    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                    if (prefab == null) continue;
                    roots = new GameObject[] { prefab };
                }
                else if (path.EndsWith(".unity"))
                {
                    var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
                    roots = scene.GetRootGameObjects();
                }

                foreach (var root in roots)
                {
                    Transform[] transforms = root.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in transforms)
                    {
                        goCount++;
                        var components = t.gameObject.GetComponents<Component>();
                        for (int i = 0; i < components.Length; i++)
                        {
                            componentsCount++;
                            if (components[i] == null)
                            {
                                missingCount++;
                                Debug.Log($"Missing script found in: {path} > {GetGameObjectPath(t)}", t.gameObject);
                            }
                        }
                    }
                }
            }
        }

        Debug.Log($"Tarama tamamlandý: {goCount} GameObject, {componentsCount} bileþen tarandý, {missingCount} eksik script bulundu.");
    }

    private static string GetGameObjectPath(Transform transform)
    {
        string path = transform.name;
        while (transform.parent != null)
        {
            transform = transform.parent;
            path = transform.name + "/" + path;
        }
        return path;
    }
}
