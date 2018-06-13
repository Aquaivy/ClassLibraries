using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 语言包解析器接口
    /// </summary>
    public interface ILanguage
    {
        /// <summary>
        /// 从本地文件中解析
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> ParseFromFile(string path);

        /// <summary>
        /// 从string字符串中解析
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> ParseFromContent(string content);
    }
}
