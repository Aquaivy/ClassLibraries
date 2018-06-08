using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 一些IO常用操作
    /// </summary>
    public static class FileUtilitiy
    {
        /// <summary>
        /// 返回路径下所有文件，包含隐藏文件，
        /// 使用AllDirectories搜索
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetFiles(string path)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }

        /// <summary>
        /// 返回路径下所有文件，包含隐藏文件，
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption);
        }

        /// <summary>
        /// 返回指定目录中的子目录的名称（包括其路径），
        /// 使用AllDirectories搜索
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        }

        /// <summary>
        /// 返回指定目录中的子目录的名称（包括其路径）
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption);
        }

        /// <summary>
        /// 返回一个给定文件的文件大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static MemorySize GetFileSize(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("FileNotFoundException", filePath);

            long len;
            using (var stream = File.OpenRead(filePath))
            {
                len = stream.Length;
            }

            return new MemorySize(len);
        }

        /// <summary>
        /// 返回指定目录下所有复合条件的文件大小总和
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static MemorySize GetFilesSize(string dir, string searchPattern, SearchOption searchOption)
        {
            var files = GetFiles(dir, searchPattern, searchOption);
            MemorySize sum = new MemorySize(0);
            foreach (var file in files)
            {
                sum += GetFileSize(file);
            }

            return sum;
        }

        /// <summary>
        /// 获得文件行尾类型
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void GetFileLineEndings(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("FileNotFoundException", path);

            using (StreamReader reader = File.OpenText(path))
            {
                string line = reader.ReadLine();
            }
        }

        /// <summary>
        /// 设置行尾
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void SetFileLineEndings(string path, Encoding encoding)
        {

        }

        /// <summary>
        /// 行尾标准化
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public static void StandardizeLineEndings(string path, Encoding encoding)
        {

        }

        /// <summary>
        /// 文件编码转换
        /// </summary>
        /// <param name="source">源文件</param>
        /// <param name="dest">目标文件，如果为空，则覆盖源文件</param>
        /// <param name="targetEncoding">目标编码</param>
        public static void ConvertFileEncoding(string source, string dest, Encoding targetEncoding)
        {
            dest = string.IsNullOrEmpty(dest) ? source : dest;
            string contents = File.ReadAllText(source, Encoding.Default);
            File.WriteAllText(dest, contents, targetEncoding);
        }
    }
}
