using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionTools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string path = args[0];
                string incrVer = args[1];
                AssemblyInfoIncreaser.UpgradeVersion(path, incrVer);
            }
            //else if (args.Length == 3)
            //{
            //    string path = args[0];
            //    string regex = args[1];
            //    string incrVer = args[2];
            //    RegexIncrenser.UpgradeRevision(path, regex, incrVer);
            //}
            else
            {
                Console.WriteLine("参数错误，只接受2个参数");
            }

            //Console.ReadKey();
        }
    }
}
