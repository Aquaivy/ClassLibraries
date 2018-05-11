using Aquaivy.Core.Log;
using Aquaivy.Library.Util;
using DogSE.Library.Util;

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
            //Logs.Info(PathEx.GetDirectoryName(@"D:\Parent\file\"));
            //Logs.Info(PathEx.GetDirectoryName(@"D:\Parent\file"));
            //Logs.Info(PathEx.GetDirectoryName(@"\Parent\file"));
            //Logs.Info(PathEx.GetDirectoryName(@"\file"));
            //Logs.Info(PathEx.GetDirectoryName(@"\"));

            //Logs.Info(PathEx.GetParentDirectoryName(@"D:\Parent\file.txt"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"\Parent\file.txt"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"Parent\file.txt"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"\file.txt"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"file.txt"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"D:\Parent\file\"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"D:\Parent\file"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"\Parent\file"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"\file"));
            //Logs.Info(PathEx.GetParentDirectoryName(@"\"));

            Logs.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file.txt"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"\Parent\file.txt"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"Parent\file.txt"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"\file.txt"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"file.txt"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file\"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"\Parent\file"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"\file"));
            Logs.Info(PathEx.GetPathWithoutExtension(@"\"));


            //Logs.Info(PathEx.GetNewFileName(@"D:\Parent\file.txt", "222"));

            //Logs.Info(PathEx.ChangeSeparatorToPositive(@"D:\\Parent\\file.txt"));
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
