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
            EditorGUILayout.LabelField("还没增加场景保存确认，请先手动保存场景！！！");
            EditorGUILayout.LabelField("还没增加场景保存确认，请先手动保存场景！！！");
            EditorGUILayout.LabelField("还没增加场景保存确认，请先手动保存场景！！！");
            GUILayout.Space(10);


            GUILayout.BeginHorizontal();

            GUILayout.Label("脚本名称：");
            scriptName = GUILayout.TextField(scriptName);
            if (GUILayout.Button("Search") && !string.IsNullOrEmpty(scriptName))
            {
                searchBtnClicked = true;
                SearchScript.Search(scriptName);
            }

            if (GUILayout.Button("Search In All Scenes") && !string.IsNullOrEmpty(scriptName))
            {
                searchBtnClicked = true;

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

            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            if (searchBtnClicked)
            {
                EditorGUILayout.LabelField("搜索结果已经显示在EditorConsole界面！！！");
            }

        }
    }
}
