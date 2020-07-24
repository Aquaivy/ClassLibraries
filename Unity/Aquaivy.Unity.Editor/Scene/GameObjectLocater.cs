using Aquaivy.Core.Utilities;
using Aquaivy.Unity.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// Hierarchy 层级面板物体快速定位
    /// </summary>
    public class GameObjectLocater
    {
        private static string configFilePath = Path.Combine(
            PathEx.GetDirectoryName(Application.dataPath),
            "locateConfig.json");

        public class Config
        {
            public List<ItemData> items;
        }

        public class ItemData
        {
            public WindowType Window;
            public string Path;
        }

        public enum WindowType
        {
            Hierarchy,
            Project,
        }

        public static void Locate(int index)
        {
            if (index < 0 || index >= 9)
            {
                Debug.LogError($"Out of index");
                return;
            }

            if (!File.Exists(configFilePath))
            {
                Debug.LogError($"Not found:  {configFilePath}");
                return;
            }

            string json = File.ReadAllText(configFilePath, Encoding.UTF8);
            ItemData[] config = JsonConvert.DeserializeObject<ItemData[]>(json);

            if (config[index] == null)
            {
                Debug.LogError($"No Locate {index}");
                return;
            }

            var selection = config[index];
            EditorGUIUtility.PingObject(GameObject.Find(selection.Path));
        }

        public static void SetLocateConfig(int index)
        {
            if (index < 0 || index >= 9)
            {
                Debug.LogError($"Out of index");
                return;
            }

            ItemData[] config = new ItemData[10];

            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath, Encoding.UTF8);
                config = JsonConvert.DeserializeObject<ItemData[]>(json);
            }

            string selection_path = GetCurrentSelectionGameObjectPath();
            config[index] = new ItemData { Window = WindowType.Hierarchy, Path = selection_path };
            var newJson = JsonConvert.SerializeObject(config);
            File.WriteAllText(configFilePath, newJson, Encoding.UTF8);
        }

        private static string GetCurrentSelectionGameObjectPath()
        {
            var go = Selection.activeGameObject;
            if (go == null)
                return null;

            return go.transform.GetFullPath();
        }
    }


}
