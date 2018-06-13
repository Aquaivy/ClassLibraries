using Aquaivy.Core.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 语言包翻译模块(仅适用于单个语言包的情况)
    /// </summary>
    public class Lang
    {
        private static ILanguage language;
        private static Dictionary<string, string> s_dict = new Dictionary<string, string>(128);

        /// <summary>
        /// 从本地文件中解析，必须为UTF8编码
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        public static void LoadFromFile<T>(string path) where T : ILanguage, new()
        {
            if (language != null)
                throw new Exception("You've already called this method, and if you still need, call the \"Clear()\" method first");

            var content = File.ReadAllText(path, Encoding.UTF8);
            LoadFromContent<T>(content);
        }

        /// <summary>
        /// 从string字符串中解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        public static void LoadFromContent<T>(string content) where T : ILanguage, new()
        {
            if (language != null)
                throw new Exception("You've already called this method, and if you still need, call the \"Clear()\" method first");

            language = new T();
            var dict = language.ParseFromContent(content);
            if (dict == null)
                return;
            s_dict = dict;
            Log.Info("Load lang success. count={0}", dict.Count);
        }

        /// <summary>
        /// 清空语言包数据
        /// </summary>
        public static void Clear()
        {
            language = null;
            s_dict.Clear();
        }

        /// <summary>
        /// 语言包转换
        /// </summary>
        /// <param name="key"></param>
        public static string Trans(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            string ret;
            if (s_dict.TryGetValue(key, out ret))
                return ret;

            return "※" + key;
            //return source;
        }

        /// <summary>
        /// 语言包转换
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        public static string Trans(string key, params object[] args)
        {
            return string.Format(Trans(key), args);
        }
    }
}
