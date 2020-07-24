using Aquaivy.Unity.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    public static class EditorSceneLoader
    {
        public static void LoadScene(int buildIndex)
        {
            if (buildIndex < 0 || buildIndex > EditorBuildSettings.scenes.Length - 1)
            {
                Debug.LogError("Scene build index error");
                return;
            }

            EditorSceneManager.OpenScene(EditorBuildSettings.scenes[buildIndex].path, OpenSceneMode.Single);
        }
    }
}
