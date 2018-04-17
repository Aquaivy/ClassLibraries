using Aquaivy.Library.Util;
using DogSE.Library.Log;
using DogSE.Library.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class Util
    {
        internal void Run()
        {
            //Test_Lang();
            //Test_FileSize();
            Test_PathEx();
        }

        private void Test_PathEx()
        {
            //Logs.Info(PathEx.GetDirectoryName(@"D:\Parent\file.txt"));
            //Logs.Info(PathEx.GetDirectoryName(@"\Parent\file.txt"));
            //Logs.Info(PathEx.GetDirectoryName(@"Parent\file.txt"));
            //Logs.Info(PathEx.GetDirectoryName(@"\file.txt"));
            //Logs.Info(PathEx.GetDirectoryName(@"file.txt"));

            //Logs.Info(Path.GetFileName(PathEx.GetDirectoryName(@"D:\Parent\file.txt")));
            //Logs.Info(Path.GetFileName(PathEx.GetDirectoryName(@"\Parent\file.txt")));
            //Logs.Info(Path.GetFileName(PathEx.GetDirectoryName(@"Parent\file.txt")));
            //Logs.Info(Path.GetFileName(PathEx.GetDirectoryName(@"\file.txt")));
            //Logs.Info(Path.GetFileName(PathEx.GetDirectoryName(@"file.txt")));

            Logs.Info(PathEx.GetNewFileName(@"D:\Parent\file.txt", "222"));
        }

        private void Test_FileSize()
        {
            Logs.Info("" + ByteSize.KB);
            Logs.Info("" + ByteSize.MB);
            Logs.Info("" + ByteSize.GB);
            Logs.Info("" + ByteSize.TB);

            ulong a = ulong.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                a /= 1024;
            }

            Logs.Info("\n{0}\n", a);

            Logs.Info("" + new ByteSize(10241).TotalKBs);
        }

        private void Test_Lang()
        {
            //Lang.Init("D://AndroidManifest.xml");
            Lang.Init("D://lang.json");

            Logs.Info(Lang.Trans("k1"));
        }
    }
}
