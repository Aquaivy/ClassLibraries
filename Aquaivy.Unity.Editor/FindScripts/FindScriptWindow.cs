using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    class FindScriptWindow : EditorWindow
    {
        private string scriptName;

        public void OnGUI()
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label("Search for Mame:");
            scriptName = GUILayout.TextField(scriptName);
            if (GUILayout.Button("Search"))
            {

            }

            GUILayout.EndHorizontal();



            GUILayout.BeginHorizontal();

            GUILayout.Label("Search for MonoScript:");
            scriptName = GUILayout.TextField(scriptName);
            if (GUILayout.Button("Search"))
            {

            }

            GUILayout.EndHorizontal();



        }
    }
}
