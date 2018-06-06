using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionTools
{
    class VersionIncrense
    {
        /// <summary>
        /// 升级一个修订号
        /// </summary>
        public static void UpgradeRevision(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Not found: {path}");
                return;
            }

            Version version = new Version("1.0.0");
            Console.WriteLine(version);
        }
    }
}
