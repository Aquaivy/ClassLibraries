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
    /// 修复*.csproj.cs的依赖关系
    /// </summary>
    public class RepairDependence
    {
        public static void Repair()
        {
            string basePath = Environment.CurrentDirectory;
            string projectName = Application.productName;
            string path = Path.Combine(basePath, projectName + ".csproj");
            if (File.Exists(path))
            {
                Repair(path, false);
                return;
            }

            path = Path.Combine(basePath, projectName + ".CSharp.csproj");
            if (File.Exists(path))
            {
                Repair(path, false);
                return;
            }

            Debug.LogError($"not found file: {path}");
        }

        public static void Repair(string projectFilePath, bool backup)
        {
            string path = projectFilePath;
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Not found file: {path}", path);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", (root as XmlElement).GetAttribute("xmlns"));

            XmlNode itemGroupNode = root.SelectSingleNode("ns:ItemGroup[2]", nsmgr);

            //遍历所有引用文件，将*.designer.cs合并到原文件下
            foreach (XmlNode compile in itemGroupNode.ChildNodes)
            {
                string fullpath = compile.Attributes["Include"].Value;
                if (Path.GetFileName(fullpath).Contains(".designer."))
                {
                    if (!compile.HasChildNodes)
                    {
                        XmlElement newElement = doc.CreateElement("DependentUpon", doc.DocumentElement.NamespaceURI);
                        newElement.InnerText = Path.GetFileName(fullpath).Replace(".designer.", ".");
                        compile.AppendChild(newElement);
                    }
                }
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
                Debug.Log($"Repaired Dependence success:  path={path}  backup={backpath}");
            else
                Debug.Log($"Repaired Dependence success:  path={path}");
        }
    }
}
