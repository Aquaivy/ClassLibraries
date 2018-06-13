using Aquaivy.Core.Logs;
using Aquaivy.Core.Utilities.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 语言翻译模块（适用于多个语言包文件，仅支持*.json类型，
    /// 暂不支持key重复检查）
    /// </summary>
    public static class LangEx
    {
        private class Config
        {
            public string Path;
            public Dictionary<string, string> Map;
        }

        private static Dictionary<string, Config> m_configs = new Dictionary<string, Config>();

        /// <summary>
        /// 从本地加载一个语言包，可加载多个
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            if (m_configs.ContainsKey(path))
                return false;

            if (!File.Exists(path))
                return false;

            var content = File.ReadAllText(path);
            var config = ParseContents(content);
            if (config == null)
                return false;

            config.Path = path;

            m_configs[path] = config;
            return true;
        }

        /// <summary>
        /// 根据给定内容加载一个语言包，需指定name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool LoadResource(string name, string content)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(content))
                return false;

            if (m_configs.ContainsKey(name))
                return false;
            var config = ParseContents(content);
            if (config == null)
                return false;

            config.Path = name;

            m_configs[name] = config;
            return true;
        }

        /// <summary>
        /// 卸载一个语言包
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Unload(string path)
        {
            if (!m_configs.ContainsKey(path))
                return false;

            return m_configs.Remove(path);
        }

        /// <summary>
        /// 卸载所有语言包
        /// </summary>
        public static void UnloadAll()
        {
            m_configs.Clear();
        }

        private static Config ParseContents(string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;

            // 方案一：使用Dictionary直接反序列化，不检查冲突
            string json = content;
            Dictionary<string, string> dict = SimpleJson.DeserializeObject<Dictionary<string, string>>(json);
            var config = new Config() { Map = dict };

            Logs.Log.Info("Init lang success. count={0}", dict.Count);

            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Trans(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            foreach (var config in m_configs.Values)
            {
                string value;
                if (config.Map.TryGetValue(key, out value))
                {
                    return value;
                }
            }

            return key;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Trans(string key, params object[] args)
        {
            return string.Format(Trans(key), args);
        }
    }

}
