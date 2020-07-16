using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 编码相关的工具类
    /// </summary>
    public static class EncodingUtils
    {
        /// <summary>
        /// 获取一个字符所占字节的数量
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static int GetEncodingBytesLength(string str, Encoding encoding)
        {
            return encoding.GetByteCount(str);
        }


        /// <summary>
        /// 获取UTF8编码下，一个字符所占字节的数量（只能测试UTF8编码）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        //[Obsolete("请使用CharacterUtils.GetEncodingBytesLength()代替")]
        //public static int GetUTF8CharBytesLength(char c)
        //{
        //    int maxLen = 0;

        //    var bytes = Encoding.UTF8.GetBytes(new char[] { c });
        //    for (int i = 0; i < bytes.Length;)
        //    {
        //        int len = 1;
        //        byte b = bytes[i];
        //        if (b >= 0xFC)
        //            len = 6;
        //        else if (b >= 0xF8)
        //            len = 5;
        //        else if (b >= 0xF0)
        //            len = 4;
        //        else if (b >= 0xE0)
        //            len = 3;
        //        else if (b >= 0xC0)
        //            len = 2;

        //        i += len;
        //        maxLen = Math.Max(maxLen, len);
        //    }

        //    return maxLen;
        //}


        /// <summary>
        /// UTF8编码字符串里是否包含4字节的字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasUTF8FourBytesLength(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                var s = str[i].ToString();
                int len = GetEncodingBytesLength(s, Encoding.UTF8);

                if (len >= 4)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 替换utf8不识别的超过4个字符的字母
        /// </summary>
        /// <param name="str"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// 代码来源：http://www.cnblogs.com/yangxudong/p/3737593.html
        /// </remarks>
        public static string ReplaceUTF8FourWord(string str, char replace = '?')
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

                if (len >= 4)
                {
                    retBytes[rIndex] = (byte)replace;
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

        /// <summary>
        /// 获取字符的16进制Unicode码(HEX)（类似：\u679C）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="hexPrefix"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static string GetUnicode(string str, HexPrefix hexPrefix = HexPrefix.U, Endian endian = Endian.Big)
        {
            char[] charbuffers = str.ToCharArray();
            byte[] buffer;
            var prefix = hexPrefix == HexPrefix.U ? "\\u" : string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(prefix + string.Format("{0:X2}{1:X2}", buffer[1], buffer[0]));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取字符的10进制Unicode码(DEC)（类似：27721 23383）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static string GetUnicodeDEC(string str, Endian endian = Endian.Big)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                var s = str[i].ToString();
                var hex = GetUnicode(s, HexPrefix.None);
                var dec = Convert.ToInt32(hex, 16);

                sb.Append(dec + " ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Unicode字符串转为正常字符串
        /// （目前只能支持带\u前缀的16进制Unicode码，类似：\u679C）
        /// </summary>
        /// <param name="unicode"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static string UnicodeToString(string unicode, Endian endian = Endian.Big)
        {
            StringBuilder sb = new StringBuilder();

            #region 新方案：可以只转换unicode部分，其他部分不影响
            bool backslash_ready = false;       //准备反斜杠
            bool backslash_ok = false;

            int uni_len = 0;
            char[] uni_arr = new char[4];
            char[] tmp_arr = new char[6];

            for (int i = 0; i < unicode.Length; i++)
            {

                char c = unicode[i];
                if (c == '\\')
                {
                    if (backslash_ready)
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        backslash_ready = true;
                        tmp_arr[0] = c;
                    }

                }
                else if (backslash_ready && !backslash_ok)
                {
                    if (c == 'u' || c == 'U')
                    {
                        backslash_ok = true;
                        tmp_arr[1] = c;
                    }
                    else
                    {
                        backslash_ready = false;
                        sb.Append('\\');
                        sb.Append(c);
                    }
                }
                else if (backslash_ok)
                {
                    uni_arr[uni_len] = c;
                    tmp_arr[uni_len + 2] = c;
                    uni_len++;

                    if (uni_len == 4)
                    {
                        byte[] bytes = new byte[2];

                        try
                        {
                            bytes[1] = byte.Parse(int.Parse(new string(uni_arr).Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                            bytes[0] = byte.Parse(int.Parse(new string(uni_arr).Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());

                            sb.Append(Encoding.Unicode.GetString(bytes));
                        }
                        catch (Exception)
                        {
                            sb.Append(new string(tmp_arr.ToList().Where(o => o != '\0').ToArray()));
                        }
                        finally
                        {
                            backslash_ready = false;
                            backslash_ok = false;
                            uni_len = 0;
                            uni_arr = new char[4];
                            tmp_arr = new char[6];
                        }
                    }
                }
                else
                {
                    backslash_ready = false;
                    backslash_ok = false;
                    sb.Append(c);
                }
            }

            //收尾，如果已经判断是编码状态了，但最终长度不够4，没有编码完成，则需要补充回来
            if (backslash_ready)
            {
                sb.Append(new string(tmp_arr.ToList().Where(o => o != '\0').ToArray()));
            }

            #endregion

            #region 原始方案：只能转换纯unicode码的

            ////原始方案：只能转换纯unicode码的
            //for (int i = 0; i < unicode.Length / 6; i++)
            //{
            //    //后4位具体编码
            //    string str = unicode.Substring(0, 6).Substring(2);

            //    //原始unicode字符串，截掉前6位，保留后面的
            //    unicode = unicode.Substring(6);

            //    //16进制转回10进制
            //    byte[] bytes = new byte[2];
            //    bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
            //    bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());

            //    sb.Append(Encoding.Unicode.GetString(bytes));
            //}

            #endregion

            return sb.ToString();
        }
    }

    /// <summary>
    /// 字节序
    /// </summary>
    public enum Endian
    {
        /// <summary>
        /// 默认字节序（Big）
        /// </summary>
        Default,

        /// <summary>
        /// 大头字节序（默认）
        /// </summary>
        Big,

        /// <summary>
        /// 小头字节序
        /// </summary>
        Little,
    }

    /// <summary>
    /// 16进制前缀
    /// </summary>
    public enum HexPrefix
    {
        /// <summary>
        /// \u前缀
        /// </summary>
        U,

        /// <summary>
        /// 无前缀
        /// </summary>
        None,
    }
}
