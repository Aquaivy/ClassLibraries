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
        private string scriptName = "MyScript";
        private bool searchBtnClicked = false;

        public static void OpenWindow()
        {
            var window = GetWindow<SearchScriptWindow>();
            window.titleContent = new GUIContent("搜索脚本");
            window.Show();
        }

        public void OnGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.LabelField("* 脚本名称不用填写.cs");
            EditorGUILayout.LabelField("* 脚本名称不区分大小写");
            EditorGUILayout.LabelField("* 搜索结果显示在Console窗口");
            GUILayout.Space(30);


            GUILayout.BeginHorizontal();

            GUILayout.Label("脚本名称：");


            scriptName = GUILayout.TextField(scriptName);

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Clear"))
            {
                scriptName = string.Empty;
            }

            if (GUILayout.Button("Search") && !string.IsNullOrEmpty(scriptName))
            {
                searchBtnClicked = true;
                SearchScript.Search(scriptName);
            }

            if (GUILayout.Button("Search In All Project Scenes") && !string.IsNullOrEmpty(scriptName))
            {
                searchBtnClicked = true;

                var scenes = SceneHelper.GetAllScenesInProject();
                var currentScene = EditorSceneManager.GetActiveScene();
                if (scenes.Count > 0 && currentScene.isDirty)
                {
                    if (EditorUtility.DisplayDialog("Are you sure?", "The scene is modified, do you want to save this scene?", "Yes", "No"))
                    {
                        EditorSceneManager.SaveScene(currentScene);
                    }
                }

                foreach (var scene in scenes)
                {
                    //Debug.Log("scene.path  " + scene.FullPath);
                    var openedScene = EditorSceneManager.OpenScene(scene.FullPath, OpenSceneMode.Single);
                    SearchScript.Search(scriptName, openedScene);
                }
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            if (searchBtnClicked)
            {
                EditorGUILayout.LabelField("搜索结果已经显示在EditorConsole界面！！！");
            }

        }
    }
}
