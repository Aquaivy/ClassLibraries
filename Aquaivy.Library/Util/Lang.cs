﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DogSE.Library.Log;
using System.Xml;
using Aquaivy.Library.Util.Json;

namespace DogSE.Library.Util
{
    /// <summary>
    /// 语言翻译模块
    /// </summary>
    public static class Lang
    {
        //private enum Type
        //{
        //    Xml,
        //    Json
        //}

        private static string LangFileName = string.Empty;
        //private static Type LangType = Type.Xml;

        private static Dictionary<string, string> s_dict = new Dictionary<string, string>();

        /// <summary>
        /// 初始化指定的翻译文件，只能是*.xml或者*.json后缀名。
        /// Xml类型，内容必须形如  <M k="k1">value1</M>  格式，
        /// Json类型，内容必须形如  "k1":"value1"  格式。
        /// </summary>
        /// <param name="langFile"></param>
        /// <param name="type"></param>
        /// 
        /// <remarks>
        ///     <?xml version="1.0" encoding="utf-8"?>
        ///     <lang>
        ///         <M k="k1">1</M>
        ///         <M k="k2">2</M>
        ///     </lang>
        /// </remarks>
        public static void Init(string langFile)
        {
            if (!File.Exists(langFile))
            {
                Logs.Error("not find xml file. {0}", langFile);
                return;
            }

            LangFileName = langFile;

            var ext = Path.GetExtension(langFile).ToLower();
            if (ext == ".xml")
            {
                //LangType = Type.Xml;
                InitXmlFile(langFile);
            }
            else if (ext == ".json")
            {
                //LangType = Type.Json;
                InitJsonFile(langFile);
            }
            else
            {
                Logs.Error("langFile's ext must be *.xml or *.json");
            }
        }

        private static void InitXmlFile(string langFile)
        {
            try
            {
                var dict = new Dictionary<string, string>();
                using (var stream = new StreamReader(langFile, Encoding.UTF8))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(stream.ReadToEnd());
                    stream.Close();

                    if (xml.DocumentElement == null)
                    {
                        Logs.Error("Lang message xml fail load is null.");
                        return;
                    }

                    var xmlNodeList = xml.DocumentElement.SelectNodes("//M");
                    if (xmlNodeList != null)
                    {
                        foreach (XmlNode element in xmlNodeList)
                        {
                            if (element.Attributes != null)
                            {
                                var attribute = element.Attributes["k"];
                                if (attribute != null)
                                {
                                    var key = attribute.Value;
                                    var value = element.InnerText;

                                    if (dict.ContainsKey(key))
                                    {
                                        Logs.Warn("Conflict lang of key: {0}", key);
                                    }

                                    dict[key] = value;
                                }
                            }
                        }
                    }

                    s_dict = dict;
                    Logs.Info("Init lang success. count={0}", dict.Count);
                }
            }
            catch (Exception ex)
            {
                Logs.Error("init lang xml fail.", ex);
            }
        }

        private static void InitJsonFile(string langFile)
        {
            try
            {
                // 方案一：使用Dictionary直接反序列化，不检查冲突
                string json = File.ReadAllText(langFile, Encoding.UTF8);
                Dictionary<string, string> dict = SimpleJson.DeserializeObject<Dictionary<string, string>>(json);

                s_dict = dict;
                Logs.Info("Init lang success. count={0}", dict.Count);

                // 方案二：使用LitJson手动反序列化，检查冲突
                //string json = File.ReadAllText(langFile, Encoding.UTF8);
                //JsonReader reader = new JsonReader(json);

                //string prop = null;
                //string v = null;

                //while (reader.Read())
                //{
                //    if (reader.Value != null)
                //    {
                //        if (reader.Token == JsonToken.PropertyName)
                //        {
                //            prop = reader.Value.ToString();
                //        }
                //        else if (reader.Token == JsonToken.String && prop != null)
                //        {
                //            v = reader.Value.ToString();
                //            if (!s_dict.ContainsKey(prop))
                //            {
                //                s_dict.Add(prop, v);
                //            }
                //            else
                //            {
                //                Logs.Warn("Conflict lang of key: {0}", prop);
                //            }

                //            prop = null;
                //            v = null;
                //        }
                //    }
                //}

                //Logs.Info("Init lang success. count={0}", dict.Count);
            }
            catch (Exception ex)
            {
                Logs.Error("init lang json fail.", ex);
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="source"></param>
        public static void Init(Dictionary<string, string> source)
        {
            if (source == null)
                return;

            s_dict = source;
        }

        /// <summary>
        /// 字典里包含翻译的数量
        /// </summary>
        public static int DictCount
        {
            get { return s_dict.Count; }
        }


        /// <summary>
        /// 重新加载文件
        /// </summary>
        public static void ReloadFile()
        {
            if (LangFileName == string.Empty)
            {
                Logs.Error("Lang file path is empty");
                return;
            }

            Init(LangFileName);
        }

        /// <summary>
        /// 将一个语言翻译为目标语言
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Trans(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            string ret;
            if (s_dict.TryGetValue(source, out ret))
                return ret;

            return "※" + source;
            //return source;
        }

        /// <summary>
        /// 将一个语言翻译为目标语言（带格式化输出）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="objParams"></param>
        /// <returns></returns>
        public static string TransFormat(string source, params object[] objParams)
        {
            return string.Format(Trans(source), objParams);
        }
    }
}