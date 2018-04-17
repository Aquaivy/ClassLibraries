using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Library.Util
{
    public class PathEx
    {
        /// <summary>
        /// 返回路径的目录名。
        /// 举例：
        ///     D:\Parent\file.txt      D:\Parent
        ///     \Parent\file.txt        \Parent
        ///     Parent\file.txt         Parent
        ///     \file.txt               \
        ///     file.txt                空字符串
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        /// <summary>
        /// 返回路径的前一层目录名
        /// 举例：
        ///     D:\Parent\file.txt      Parent
        ///     \Parent\file.txt        Parent
        ///     Parent\file.txt         Parent
        ///     \file.txt               空字符串
        ///     file.txt                空字符串
        /// </summary>
        /// <param name="path"></param>
        public static string GetParentDirectoryName(string path)
        {
            return Path.GetFileName(GetDirectoryName(path));
        }

        /// <summary>
        /// 返回修改了文件名之后的路径，
        /// 只改文件名，不改父级路径，不改扩展名
        /// </summary>
        /// <param name="path">文件完整路径</param>
        /// <param name="newName">文件新名字，不包含扩展名</param>
        public static string GetNewFileName(string path, string newName)
        {
            var dir = Path.GetDirectoryName(path);
            var ext = Path.GetExtension(path);
            return Path.Combine(dir, newName + ext);
        }

        /// <summary>
        /// 修改目录中的分隔符为【正分隔符】，形如 "/"
        /// </summary>
        /// <param name="path"></param>
        public static void ChangeSeparatorToPositive(string path)
        {

        }

        /// <summary>
        /// 修改目录中的分隔符为【反分隔符】，形如 "\"
        /// </summary>
        /// <param name="path"></param>
        public static void ChangeSeparatorToPassive(string path)
        {

        }
    }
}
