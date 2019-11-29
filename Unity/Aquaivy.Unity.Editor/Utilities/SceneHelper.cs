using Aquaivy.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// 场景相关的工具
    /// </summary>
    public class SceneHelper
    {
        /// <summary>
        /// 返回项目中所有场景，无论是否在Build Setting中，
        /// 只要在项目中，都返回
        /// </summary>
        /// <returns></returns>
        public static List<SceneInfo> GetAllScenesInProject()
        {
            //方案一
            var path = Application.dataPath;
            var prefix = Environment.CurrentDirectory;
            var scenes = Directory.GetFiles(path, "*.unity", SearchOption.AllDirectories);
            List<SceneInfo> lst = new List<SceneInfo>(8);

            foreach (var fullpath in scenes)
            {
                var assetpath = PathEx.ChangeSeparatorToPositive(fullpath.Substring(prefix.Length + 1));
                var scene = SceneManager.GetSceneByPath(assetpath);
                lst.Add(new SceneInfo { NativeScene = scene, FullPath = assetpath });
                //Debug.Log($"Found scene:  path={assetpath}");
            }

            return lst;


            //方案二
            //var scenes = AssetDatabase.GetAllAssetPaths()
            //   .Where(path => path.EndsWith(".unity"))
            //   .Where(path => path.StartsWith("Assets/"))
            //   .ToList();
        }


        /// <summary>
        /// 在Project界面中定位到当前场景
        /// </summary>
        public static void LocateCurrentSceneInProject()
        {
            EditorUtility.FocusProjectWindow();
            //Selection.activeObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UnitTest/04_Audio/GameObject.prefab");
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/UnitTest/04_Audio/04_Audio.unity");
            //ProjectWindowUtil.ShowCreatedAsset
        }

        public static void LocateSceneInProject(Scene scene)
        {
            //AssetDatabase.
        }

    }
}
