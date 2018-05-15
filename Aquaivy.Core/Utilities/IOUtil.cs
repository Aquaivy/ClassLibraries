using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Aquaivy.Library.Util
{
    public static class IOUtil
    {
        public static void GetFiles(string path, string searchPattern, SearchOption searchOption)
        {

        }

        public static void GetFileCount(string path)
        {

        }

        public static void GetFileCount(string path, string searchPattern, SearchOption searchOption)
        {

        }

        public static ByteSize GetFileSize(string path)
        {
            return new ByteSize(10);
        }

        public static ByteSize GetFileSize(string path, string searchPattern, SearchOption searchOption)
        {
            return new ByteSize(10);
        }

        public static void ChangeEncoding(string path, Encoding encoding)
        {

        }

        /// <summary>
        /// 获得文件行尾类型
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void GetFileEndOfLine(string path)
        {

        }

        /// <summary>
        /// 行尾标准化
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void StandardizeEndOfLine(string path, Encoding encoding)
        {

        }
    }
}
