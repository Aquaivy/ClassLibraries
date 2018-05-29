using System;
using Aquaivy.Core.Log;
using Aquaivy.Core.Utilities;

namespace UnitTest.Library
{
    class Util
    {
        internal void Run()
        {
            //Test_Lang();
            //Test_FileSize();
            //Test_PathEx();
            //Test_File();
            //Test_LineEndings();
            Test_RandomName();

        }

        private void Test_RandomName()
        {
            //Logs.Info(Chinese2Spell.Convert("替换图片"));
            //Logs.Info(Chinese2SpellSimple.GetPYString("替换图片"));

            //var lst = NameSimulation.GetRandomChineseNames(ChineseNameSetting.Default, 20);
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    Logs.Info(lst[i]);
            //}

            var lst = NameSimulation.GetRandomEnglishNames(EnglishNameSetting.Default, 20);
            for (int i = 0; i < lst.Count; i++)
            {
                Logs.Info(lst[i]);
            }

            //Logs.Info(ChineseWordLibrary.Common.Length.ToString());
            //Logs.Info(ChineseWordLibrary.Family.Length.ToString());
            //Logs.Info(ChineseWordLibrary.CompoundFamily.Length.ToString());
            //Logs.Info(EnglishNameLibrary.FirstName.Length.ToString());
        }

        private void Test_LineEndings()
        {
            FileUtilitiy.GetFileLineEndings(@"D:\HttpUtils.cs");
        }

        private void Test_File()
        {
            //var files = File.GetFiles(@"D:\----------------替换图片");
            //var files = FileUtilitiy.GetDirectories(@"D:\");
            var files = FileUtilitiy.GetFilesSize(@"D:\----------------替换图片", "*.*", System.IO.SearchOption.AllDirectories);
            //foreach (var item in files)
            //{
            //    Logs.Info(item);
            //}
            Logs.Info("" + files.TotalKBs);
            Logs.Info("" + files.TotalMBs);
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

            //Logs.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file.txt"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"\Parent\file.txt"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"Parent\file.txt"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"\file.txt"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"file.txt"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file\"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"\Parent\file"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"\file"));
            //Logs.Info(PathEx.GetPathWithoutExtension(@"\"));


            //Logs.Info(PathEx.GetNewFileName(@"D:\Parent\file.txt", "222"));

            //Logs.Info(PathEx.ChangeSeparatorToPositive(@"D:\\Parent\\file.txt"));

            Logs.Info(@"D:\\Parent\\file.txt");
            Logs.Info(PathEx.ChangeEscapeToPath("D:\\\"Parent\\file.txt"));
        }

        private void Test_FileSize()
        {
            Logs.Info("" + MemoryCapacity.KB);
            Logs.Info("" + MemoryCapacity.MB);
            Logs.Info("" + MemoryCapacity.GB);
            Logs.Info("" + MemoryCapacity.TB);

            ulong a = ulong.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                a /= 1024;
            }

            Logs.Info("\n{0}\n", a);

            Logs.Info("" + new MemoryCapacity(10241).TotalKBs);
        }

        private void Test_Lang()
        {
            //Lang.Init(@"D:\Unity\VSProjects\ClassLibraries\UnitTest\lang.xml");
            Lang.Init(@"D:\Unity\VSProjects\ClassLibraries\UnitTest\lang.json");

            Logs.Info(Lang.Trans("k1"));
        }
    }
}

