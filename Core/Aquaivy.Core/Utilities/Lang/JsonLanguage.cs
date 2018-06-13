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
    /// Json格式的语言包解析器,
    /// 形如：
    ///     {
    ///         "k1":"this is k1's content",
    ///         "k2":"name {0}, height {1:F2}cm",
    ///     }
    /// </summary>
    public class JsonLanguage : ILanguage
    {
        /// <summary>
        /// JsonLanguage （必须有公共无参构造函数）
        /// </summary>
        public JsonLanguage() { }

        /// <summary>
        /// 从本地文件中解析，必须为UTF8编码
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Dictionary<string, string> ParseFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Not found file. {0}", path);

            var content = File.ReadAllText(path, Encoding.UTF8);
            return ParseFromContent(content);
        }

        /// <summary>
        /// 从string字符串中解析
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public Dictionary<string, string> ParseFromContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new Exception("JsonLanguage.ParseFromContent error, content is null");

            // 方案一：使用SimpleJson直接反序列化，不检查冲突
            var dict = SimpleJson.DeserializeObject<Dictionary<string, string>>(content);
            return dict;


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
        }
    }

}
