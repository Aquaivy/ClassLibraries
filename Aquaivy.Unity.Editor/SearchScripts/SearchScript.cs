using Aquaivy.Unity.Common;
using Aquaivy.Unity.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aquaivy.Unity.Editor
{
    public class SearchScript
    {
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
                    Debug.Log($"Found script:  scene={scene.name}  script={script}  path={go.transform.GetFullPath()}");
                }
            }
        }

        public static void Search(Type type)
        {
            Search(type, SceneManager.GetActiveScene());
        }

        public static void Search(Type type, Scene scene)
        {
            var lst = GameObjectHelper.GetGameObjects(scene);
            foreach (var go in lst)
            {
                if (go.GetComponent(type) != null)
                {
                    Debug.Log($"Found script:  scene={scene.name}  script={type.Name}  path={go.transform.GetFullPath()}");
                }
            }
        }
    }
}
