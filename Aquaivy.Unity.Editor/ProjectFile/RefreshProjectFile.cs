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
    /// 刷新*.csproj文件，以解决vs中无法识别新建*.cs代码问题
    /// 操作步骤：
    ///     1.执行本方法
    ///     2.切到别的某个应用
    ///     3.切回到Unity
    ///     4.切到vs
    /// </summary>
    public class RefreshProjectFile
    {
        /// <summary>
        /// 刷新
        /// </summary>
        public static void Refresh()
        {
            string basePath = Environment.CurrentDirectory;
            string projectName = Application.productName;
            string path = Path.Combine(basePath, projectName + ".csproj");
            if (File.Exists(path))
            {
                Refresh(path);
                return;
            }

            path = Path.Combine(basePath, projectName + ".CSharp.csproj");
            if (File.Exists(path))
            {
                Refresh(path);
                return;
            }

            Debug.LogError($"not found file: {path}");
        }

        public static void Refresh(string projectFilePath)
        {
            string path = projectFilePath;
            if (!File.Exists(path))
            {
                Debug.LogError($"not found file: {path}");
                return;
            }

            using (var writer = File.AppendText(path))
            {
                writer.Write(" ");
                writer.Flush();
            }

            Debug.Log($"Refresh project file success:  path={path}");
        }

        //public static void Refresh(string projectFilePath)
        //{
        //    string path = projectFilePath;
        //    if (!File.Exists(path))
        //    {
        //        Debug.LogError($"not found file: {path}");
        //        return;
        //    }

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(path);

        //    XmlNode root = doc.DocumentElement;
        //    XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        //    nsmgr.AddNamespace("ns", (root as XmlElement).GetAttribute("xmlns"));


        //    var flag = doc.CreateElement("RefreshFlag");
        //    root.AppendChild(flag);

        //    doc.Save(path);

        //    Debug.Log($"Refresh project file success:  path={path}");
        //}

    }
}
