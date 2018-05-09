using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Library.Util
{
    /// <summary>
    /// 字符检查/转换的工具类
    /// </summary>
    class CharacterChecker
    {
        /// <summary>
        /// 字符串里是否包含4字节的字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <remarks>
        /// 代码来源：http://www.cnblogs.com/yangxudong/p/3737593.html
        /// </remarks>
        public static bool HasUtf8FourWord(string str)
        {
            int maxLen = 0;

            var bytes = Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < bytes.Length;)
            {
                int len = 1;
                byte b = bytes[i];
                if (b >= 0xFC)
                    len = 6;
                else if (b >= 0xF8)
                    len = 5;
                else if (b >= 0xF0)
                    len = 4;
                else if (b >= 0xE0)
                    len = 3;
                else if (b >= 0xC0)
                    len = 2;

                i += len;
                maxLen = Math.Max(maxLen, len);
            }

            return maxLen > 3;
        }

        /// <summary>
        /// 替换utf8不识别的超过4个字符的字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceUtf8FourWord(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var bytes = Encoding.UTF8.GetBytes(str);
            var retBytes = new byte[bytes.Length];
            int rIndex = 0;
            for (int i = 0; i < bytes.Length;)
            {
                int len = 1;
                byte b = bytes[i];
                if (b >= 0xFC)
                    len = 6;
                else if (b >= 0xF8)
                    len = 5;
                else if (b >= 0xF0)
                    len = 4;
                else if (b >= 0xE0)
                    len = 3;
                else if (b >= 0xC0)
                    len = 2;

                if (len > 3)
                {
                    retBytes[rIndex] = (byte)'?';
                    rIndex++;
                }
                else
                {
                    Buffer.BlockCopy(bytes, i, retBytes, rIndex, len);
                    rIndex += len;
                }

                i += len;
            }

            return Encoding.UTF8.GetString(retBytes, 0, rIndex);
        }
    }
}
