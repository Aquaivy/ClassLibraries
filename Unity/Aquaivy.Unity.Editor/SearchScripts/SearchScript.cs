using Aquaivy.Unity.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// 脚本搜索
    /// </summary>
    public class SearchScript
    {
        public static void Search(Type type)
        {
            Search(type.Name, SceneManager.GetActiveScene());
        }

        public static void Search(Type type, Scene scene)
        {
            Search(type.Name, scene);
        }

        public static void Search(string script)
        {
            Search(script, SceneManager.GetActiveScene());
        }

        public static void Search(string script, Scene scene)
        {
            var lst = GameObjectHelper.GetGameObjects(scene);
            foreach (var go in lst)
            {
                if (go.GetComponent(script) != null)
                {
                    Debug.Log($"Found script:    Scene={scene.name}.unity    Script={script}.cs    Path={go.transform.GetFullPath("/", "")}\n", go);
                }
            }
        }
    }
}
