using Aquaivy.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aquaivy.Unity.Editor
{
    class SceneHelper
    {
        /// <summary>
        /// 返回项目中所有场景，无论是否在Build Setting中，
        /// 只要在项目中，都返回
        /// </summary>
        /// <returns></returns>
        public static List<SceneWrap> GetAllScenesInProject()
        {
            var path = Application.dataPath;
            var prefix = Environment.CurrentDirectory;
            var scenes = Directory.GetFiles(path, "*.unity", SearchOption.AllDirectories);
            List<SceneWrap> lst = new List<SceneWrap>(8);

            foreach (var fullpath in scenes)
            {
                var assetpath = PathEx.ChangeSeparatorToPositive(fullpath.Substring(prefix.Length + 1));
                var scene = SceneManager.GetSceneByPath(assetpath);
                lst.Add(new SceneWrap { NativeScene = scene, FullPath = assetpath });
                //Debug.Log($"Found scene:  path={assetpath}");
            }
            return lst;
        }



        //方案二
        //var scenes = AssetDatabase.GetAllAssetPaths()
        //   .Where(path => path.EndsWith(".unity"))
        //   .Where(path => path.StartsWith("Assets/"))
        //   .ToList();
    }
}
