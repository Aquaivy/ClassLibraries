using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{

    public static class HierarchyGameObjectRenameTool
    {
        public static void Rename()
        {
            var go = Selection.activeGameObject;
            Rename(go);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        public static void Rename(GameObject gameObject)
        {
            string pattern = @" \(\d+\)";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(gameObject.name, string.Empty);
            //Debug.Log($"替换  {gameObject.name}    {result}");
            gameObject.name = result;

            int cnt = gameObject.transform.childCount;
            for (int i = 0; i < cnt; i++)
            {
                var t = gameObject.transform.GetChild(i);
                Rename(t.gameObject);
            }
        }
    }
}
