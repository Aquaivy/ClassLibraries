using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// 降低*.csproj文件的警告等级
    /// </summary>
    public class ReduceWarningLevel
    {
        /// <summary>
        /// 提升到最高级：4级
        /// </summary>
        public static void Raise() => SetLevel(4);

        /// <summary>
        /// 降低到最低级：0级
        /// </summary>
        public static void Reduce() => SetLevel(0);

        /// <summary>
        /// 设置警告等级
        /// </summary>
        /// <param name="level">level应在[0,4]之间</param>
        public static void SetLevel(int level)
        {
            string basePath = Environment.CurrentDirectory;
            string projectName = Application.productName;
            string path = Path.Combine(basePath, projectName + ".csproj");
            if (File.Exists(path))
            {
                SetLevel(level, path, false);
                return;
            }

            path = Path.Combine(basePath, projectName + ".CSharp.csproj");
            if (File.Exists(path))
            {
                SetLevel(level, path, false);
                return;
            }

            Debug.LogError($"not found file: {path}");
        }

        public static void SetLevel(int level, string projectFilePath)
        {
            SetLevel(level, projectFilePath, false);
        }

        public static void SetLevel(int level, string projectFilePath, bool backup)
        {
            string path = projectFilePath;
            if (!File.Exists(path))
            {
                Debug.LogError($"not found file: {path}");
                return;
            }

            level = Mathf.Clamp(level, 0, 4);

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", (root as XmlElement).GetAttribute("xmlns"));

            var group = root.SelectNodes("ns:PropertyGroup/ns:WarningLevel", nsmgr);

            foreach (XmlNode node in group)
            {
                node.InnerText = level.ToString();
            }

            string backpath = string.Empty;
            if (backup)
            {
                string basePath = Environment.CurrentDirectory;
                string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                string name = Path.GetFileName(path);

                backpath = Path.Combine(basePath, "Backup", date, name);

                Directory.CreateDirectory(Path.GetDirectoryName(backpath));
                File.Copy(path, backpath, true);
            }

            doc.Save(path);

            if (backup)
                Debug.Log($"Set warning level success:  level={level}  path={path}  backup={backpath}");
            else
                Debug.Log($"Set warning level success:  level={level}  path={path}");
        }
    }
}
