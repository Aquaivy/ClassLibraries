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
    class SearchScriptWindow : EditorWindow
    {
        private string scriptName;

        public static void OpenWindow()
        {
            var window = GetWindow<SearchScriptWindow>();
            window.titleContent = new GUIContent("Search Script");
            window.Show();
        }

        public void OnGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.LabelField(new GUIContent("还没增加场景保存确认，请先手动保存场景！！！","123"));
            EditorGUILayout.LabelField("还没增加场景保存确认，请先手动保存场景！！！");
            EditorGUILayout.LabelField("还没增加场景保存确认，请先手动保存场景！！！");

            GUILayout.Space(10);

            //Search for Mame
            GUILayout.BeginHorizontal();

            GUILayout.Label("Search with Name:");
            scriptName = GUILayout.TextField(scriptName);
            if (GUILayout.Button("Search") && !string.IsNullOrEmpty(scriptName))
            {
                SearchScript.Search(scriptName);
            }

            GUILayout.EndHorizontal();


            if (GUILayout.Button("Search In All Scenes") && !string.IsNullOrEmpty(scriptName))
            {
                var scenes = SceneHelper.GetAllScenesInProject();
                var currentScene = EditorSceneManager.GetActiveScene();
                if (scenes.Count > 0 && currentScene.isDirty)
                {
                    //这里补充一个场景保存确认
                }


                foreach (var scene in scenes)
                {
                    //Debug.Log("scene.path  " + scene.FullPath);
                    var openedScene = EditorSceneManager.OpenScene(scene.FullPath, OpenSceneMode.Single);
                    SearchScript.Search(scriptName, openedScene);
                }
            }


        }
    }
}
