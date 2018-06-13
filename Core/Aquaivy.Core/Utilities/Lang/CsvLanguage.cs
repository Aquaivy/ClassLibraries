using Aquaivy.Core.Logs;
using Aquaivy.Core.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// Csv格式的语言包解析器,
    /// 形如：
    ///     "key1","这是key1的内,容"
    ///     "key2","这是key2的内容{0}  {1:F1}"
    /// </summary>
    public class CsvLanguage : ILanguage
    {
        /// <summary>
        /// CsvLanguage （必须有公共无参构造函数）
        /// </summary>
        public CsvLanguage() { }

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
                throw new Exception("CsvLanguage.ParseFromContent error, content is null");

            var bytes = Encoding.UTF8.GetBytes(content);
            MemoryStream memory = new MemoryStream(bytes);

            var columns = new List<string>(2);
            int line = 0;
            var dict = new Dictionary<string, string>(128);
            using (var reader = new CsvFileReader(memory))
            {
                while (reader.ReadRow(columns))
                {
                    // TODO: Do something with columns' values
                    // 这里读取一行内容，根据","来切分成多列，自行处理这些列的内容，
                    // 如果不处理，读到下一行时，上一行的数据就被丢弃了，
                    // 也就是说columns保存的是一行的列内容，并不是所有行

                    line++;
                    if (columns.Count != 2)
                    {
                        Log.Warn("Parse lang warning, line {0}, columns must be 2", (line + 1));
                        continue;
                    }

                    var key = columns[0];
                    var value = columns[1];

                    if (dict.ContainsKey(key))
                    {
                        Log.Warn("Conflict key of lang, line={0}, key={1}", line, key);
                    }

                    dict[key] = value;
                }
            }

            return dict;
        }

    }
}
