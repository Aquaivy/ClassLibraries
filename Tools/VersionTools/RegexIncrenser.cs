using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VersionTools
{
    class RegexIncrenser
    {
        /// <summary>
        /// 升级一个修订号，使用正则表达式查询（未完成）
        /// </summary>
        public static void UpgradeRevision(string path, string regex, string incrVer)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(regex) || string.IsNullOrEmpty(incrVer))
            {
                Console.WriteLine($"args error");
                return;
            }

            if (!File.Exists(path))
            {
                Console.WriteLine($"Not found: {path}");
                return;
            }

            try
            {
                bool matched = false;
                var lines = File.ReadAllLines(path, Encoding.UTF8);
                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];
                    foreach (Match match in Regex.Matches(line, regex))
                    {
                        matched = true;
                        Console.WriteLine($"matched, line {i + 1}, " + match.Value);

                        var oriVersionStr = GetVersion(line);
                        var newVersionStr = IncreaseVersion(oriVersionStr, incrVer);

                        lines[i] = line.Replace(oriVersionStr, newVersionStr);

                        Console.WriteLine($"new line:{lines[i]}");
                    }
                }

                if (!matched)
                {
                    Console.WriteLine($"Not matched");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            //Version version = new Version("[assembly: AssemblyVersion(\"1.0.0.0\")]");
            //Console.WriteLine(version);
        }

        /// <summary>
        /// 移除字符串中的非数字、非小数点部分，对剩余字符串尝试进行版本转换
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static string GetVersion(string content)
        {
            throw new NotImplementedException();
        }

        private static string IncreaseVersion(string content, string incrVer)
        {
            throw new NotImplementedException();
        }
    }
}
