using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    public class EditorUtils
    {
        /// <summary>
        /// 打开persistentDataPath目录
        /// </summary>
        public static void OpenPersistentDataPath()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        /// <summary>
        /// 打开streamingAssetsPath目录
        /// </summary>
        public static void OpenStreamingAssetsPath()
        {
            EditorUtility.RevealInFinder(Application.streamingAssetsPath);
        }

        /// <summary>
        /// 打开dataPath目录
        /// </summary>
        public static void OpenDataPath()
        {
            EditorUtility.RevealInFinder(Application.dataPath);
        }
    }
}
