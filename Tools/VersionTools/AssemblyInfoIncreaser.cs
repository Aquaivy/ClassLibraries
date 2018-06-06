using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionTools
{
    class AssemblyInfoIncreaser
    {
        internal static void UpgradeVersion(string path, string incrVer)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(incrVer))
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

                    //增加AssemblyVersion版本
                    if (line.StartsWith("[assembly: AssemblyVersion("))
                    {
                        matched = true;

                        var oriVersionStr = line.Replace("[assembly: AssemblyVersion(\"", string.Empty).Replace("\")]", string.Empty);
                        var newVersionStr = IncreaseVersion(oriVersionStr, incrVer);

                        lines[i] = line.Replace(oriVersionStr, newVersionStr);

                        Console.WriteLine($"matched, line {i + 1}, " + lines[i]);
                    }

                    //增加AssemblyFileVersion版本
                    if (line.StartsWith("[assembly: AssemblyFileVersion("))
                    {
                        matched = true;

                        var oriVersionStr = line.Replace("[assembly: AssemblyFileVersion(\"", string.Empty).Replace("\")]", string.Empty);
                        var newVersionStr = IncreaseVersion(oriVersionStr, incrVer);

                        lines[i] = line.Replace(oriVersionStr, newVersionStr);

                        Console.WriteLine($"matched, line {i + 1}, " + lines[i]);
                    }
                }

                File.WriteAllLines(path, lines, Encoding.UTF8);

                if (!matched)
                {
                    Console.WriteLine($"Not matched");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// 移除字符串中的非数字、非小数点部分，对剩余字符串尝试进行版本转换
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static string GetVersion(string content)
        {
            return content.Replace("[assembly: AssemblyVersion(", string.Empty).Replace("\"", string.Empty).Replace(")]", string.Empty);
        }

        private static string IncreaseVersion(string oldVersionStr, string incrVer)
        {
            try
            {
                var baseVersion = new Version(oldVersionStr);
                int revision = baseVersion.Revision + Convert.ToInt32(incrVer);
                string newVersionStr = new Version(baseVersion.Major, baseVersion.Minor, baseVersion.Build, revision).ToString();
                return newVersionStr;
            }
            catch (Exception)
            {
                Console.WriteLine($"incrVer error:{incrVer}");
                return oldVersionStr;
            }
        }
    }
}
