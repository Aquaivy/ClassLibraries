using Aquaivy.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// 命名空间检查
    /// </summary>
    public class NamespaceChecker
    {
        /// <summary>
        /// 
        /// </summary>
        public static void CheckerNoneNamespaceFile()
        {
            string projectPath = Application.dataPath;

            var files = FileUtility.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                var f = files[i];
                if (!IsCSharpFileContainsNamespace(f))
                {
                    Debug.Log($"[No Namespace]    {f}");
                }
            }
        }

        /// <summary>
        /// *.cs 文件是否包含命名空间
        /// </summary>
        /// <returns></returns>
        public static bool IsCSharpFileContainsNamespace(string path)
        {
            if (!File.Exists(path))
                return false;

            String line;
            bool ret = false;

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.TrimStart().StartsWith("namespace "))
                    {
                        ret = true;
                        break;
                    }
                }

            }

            return ret;
        }
    }
}
