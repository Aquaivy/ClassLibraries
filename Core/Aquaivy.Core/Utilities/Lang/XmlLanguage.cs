using Aquaivy.Core.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// Xml格式的语言包解析器,
    /// 形如：
    ///     &lt;?xml version="1.0" encoding="utf-8"?&gt;
    ///     &lt;lang&gt;
    ///         &lt;M k="k1"&gt;1&lt;/M&gt;
    ///         &lt;M k="k2"&gt;2&lt;/M&gt;
    ///     &lt;/lang&gt;
    /// </summary>
    public class XmlLanguage : ILanguage
    {
        /// <summary>
        /// XmlLanguage （必须有公共无参构造函数）
        /// </summary>
        public XmlLanguage() { }

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
            // xml文件格式必须如下
            // <?xml version="1.0" encoding="utf-8"?>
            // <lang>
            //     <M k="k1">1</M>
            //     <M k="k2">2</M>
            // </lang>

            if (string.IsNullOrEmpty(content))
                throw new Exception("XmlLanguage.ParseFromContent error, content is null");

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(content);

            if (xml.DocumentElement == null)
            {
                Log.Error("Lang xml file error, xml.DocumentElement is null");
                return null;
            }

            var dict = new Dictionary<string, string>(128);
            var xmlNodeList = xml.DocumentElement.SelectNodes("//M");
            if (xmlNodeList != null)
            {
                int line = 0;
                foreach (XmlNode element in xmlNodeList)
                {
                    if (element.Attributes != null)
                    {
                        line++;
                        var attribute = element.Attributes["k"];
                        if (attribute != null)
                        {
                            var key = attribute.Value;
                            var value = element.InnerText;

                            if (dict.ContainsKey(key))
                            {
                                Log.Warn("Conflict key of lang, line={0}, key={1}", key);
                            }

                            dict[key] = value;
                        }
                    }
                }
            }

            return dict;
        }
    }
}
