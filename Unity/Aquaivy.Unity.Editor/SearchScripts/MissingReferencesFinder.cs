using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A helper editor script for finding missing references to objects.
/// </summary>
public class MissingReferencesFinder
{
    /// <summary>
    /// Finds all missing references to objects in the currently loaded scene.
    /// </summary>
    [MenuItem("Tools/Missing References/Search in current scene", false, 50)]
    public static void FindMissingReferencesInCurrentScene()
    {
        var scenePath = EditorSceneManager.GetActiveScene().path;
        var gameObjects = GetCurrentSceneGameObjects();
        FindMissingReferences(scenePath, gameObjects);
    }

    /// <summary>
    /// Finds all missing references to objects in all enabled scenes in the project.
    /// This works by loading the scenes one by one and checking for missing object references.
    /// </summary>
    [MenuItem("Tools/Missing References/Search in BuildSetting scenes（enabled only）", false, 51)]
    public static void MissingSpritesInAllScenes()
    {
        //本想最后回到当前场景，但是发现current.path为空，先舍弃
        //var current = EditorSceneManager.GetActiveScene();

        foreach (var scene in EditorBuildSettings.scenes.Where(s => s.enabled))
        {
            Debug.Log($"Begin analyze:    {scene.path}");
            EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Single);
            FindMissingReferencesInCurrentScene();
        }

        if (EditorUtility.DisplayDialog("注意", "搜索结束，当前场景已发生修改，请手动切换回到您的场景", "OK"))
        {

        }

        //int totalInBuildSettings = EditorSceneManager.sceneCountInBuildSettings;
        //for (int i = 0; i < totalInBuildSettings; i++)
        //{
        //    var scene = EditorSceneManager.GetSceneByBuildIndex(i);
        //    scene.path
        //}

        //检索项目中所有场景的方法
        //var scenes = AssetDatabase.GetAllAssetPaths()
        //    .Where(path => path.EndsWith(".unity"))
        //    .Where(path => path.StartsWith("Assets/"))
        //    .ToList();
    }

    /// <summary>
    /// Finds all missing references to objects in assets (objects from the project window).
    /// </summary>
    [MenuItem("Tools/Missing References/Search in assets", false, 52)]
    public static void MissingSpritesInAssets()
    {
        var allAssets = AssetDatabase.GetAllAssetPaths().Where(path => path.StartsWith("Assets/")).ToArray();
        var objs = allAssets.Select(a => AssetDatabase.LoadAssetAtPath(a, typeof(GameObject)) as GameObject).Where(a => a != null).ToArray();

        FindMissingReferences("Project", objs);
    }

    private static void FindMissingReferences(string context, GameObject[] objects)
    {
        foreach (var go in objects)
        {
            var components = go.GetComponents<Component>();

            foreach (var c in components)
            {
                // Missing components will be null, we can't find their type, etc.
                if (!c)
                {
                    Debug.LogError($"Missing Component:  Path={GetFullPath(go)}", go);
                    continue;
                }

                SerializedObject so = new SerializedObject(c);
                var sp = so.GetIterator();

                // Iterate over the components' properties.
                while (sp.NextVisible(true))
                {
                    if (sp.propertyType == SerializedPropertyType.ObjectReference)
                    {
                        if (sp.objectReferenceValue == null
                            && sp.objectReferenceInstanceIDValue != 0)
                        {
                            PrintError(context, go, c.GetType().Name, ObjectNames.NicifyVariableName(sp.name));
                        }
                    }
                }
            }
        }
    }

    private static GameObject[] GetCurrentSceneGameObjects()
    {
        // 因为 GameObject.FindObjectsOfType 不会返回 disabled 的对象
        // 所以使用下面这个 Resources.FindObjectsOfTypeAll 方法
        return Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => string.IsNullOrEmpty(AssetDatabase.GetAssetPath(go)) && go.hideFlags == HideFlags.None)
            .ToArray();
    }

    private static void PrintError(string context, GameObject go, string component, string property)
    {
        var error = $"Missing Reference:  Scene=[{context}]    Path={GetFullPath(go)}    Component={component}    Property={property}";
        Debug.LogError(error, go);
    }

    /// <summary>
    /// 获取完整路径（这个方案很赞）
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    private static string GetFullPath(GameObject go)
    {
        return go.transform.parent == null
            ? go.name
            : GetFullPath(go.transform.parent.gameObject) + "/" + go.name;
    }
}