using System;
using System.Collections.Generic;
using System.Diagnostics;
using Aquaivy.Core.Logs;
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
            //Test_RandomName();
            //Test_Converter();
            //Test_Stopwatch();
        }

        private void Test_Stopwatch()
        {
            //var sw = Stopwatch.StartNew();
            //Log.Info($"{sw.ElapsedTicks}  {sw.ElapsedMilliseconds}  {sw.Elapsed}");
            //Log.Info($"{sw.ElapsedTicks}  {sw.ElapsedMilliseconds}  {sw.Elapsed}");
            //Log.Info($"{sw.ElapsedTicks}  {sw.ElapsedMilliseconds}  {sw.Elapsed}");
            //sw.Stop();
            //sw.Start();
            //Log.Info($"{sw.ElapsedTicks}  {sw.ElapsedMilliseconds}  {sw.Elapsed}");
            //sw.Stop();
            //Log.Info($"{sw.ElapsedTicks}  {sw.ElapsedMilliseconds}  {sw.Elapsed}");
            //Log.Info($"{sw.ElapsedTicks}  {sw.ElapsedMilliseconds}  {sw.Elapsed}");


            Log.Info("");

            StopwatchWrap.Start("sw1");
            StopwatchWrap.Print("sw1");
            StopwatchWrap.Print("sw1");
            StopwatchWrap.Restart("sw1");
            StopwatchWrap.Print("sw1");
            StopwatchWrap.Print("sw1");
            StopwatchWrap.Print("sw1");
            StopwatchWrap.Stop("sw1");

            Log.Info("");
        }

        private void Test_Converter()
        {
            //方案一
            {
                var list = new List<string>() { "11.5", "500.3" };
                List<float> listint;
                var ret = Converter.TryToList<float>(list, out listint);
                Log.Info($"{ret}  {listint[0]}");
            }

            //方案二
            {
                var list = new List<int>() { 11, 500 };
                List<string> strlist;
                var ret = Converter.TryToList<int>(list, out strlist);
                Log.Info($"{ret}  {strlist[1].GetType()}");
            }
        }

        private void Test_RandomName()
        {
            //Log.Info(Chinese2Spell.Convert("替换图片"));
            //Log.Info(Chinese2SpellSimple.GetPYString("替换图片"));

            for (int i = 0; i < 20; i++)
            {
                Log.Info(NameSimulation.GetRandomChineseName());
            }
            for (int i = 0; i < 20; i++)
            {
                Log.Info(NameSimulation.GetRandomEnglishName());
            }

            //var lst = NameSimulation.GetRandomChineseNames(ChineseNameSetting.Default, 20);
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    Log.Info(lst[i]);
            //}

            //var lst = NameSimulation.GetRandomEnglishNames(EnglishNameSetting.Default, 20);
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    Log.Info(lst[i]);
            //}

            //Log.Info(ChineseWordLibrary.Common.Length.ToString());
            //Log.Info(ChineseWordLibrary.Family.Length.ToString());
            //Log.Info(ChineseWordLibrary.CompoundFamily.Length.ToString());
            //Log.Info(EnglishNameLibrary.FirstName.Length.ToString());
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
            //    Log.Info(item);
            //}
            Log.Info("" + files.TotalKBs);
            Log.Info("" + files.TotalMBs);
        }

        private void Test_PathEx()
        {
            //Log.Info(PathEx.GetDirectoryName(@"D:\Parent\file.txt"));
            //Log.Info(PathEx.GetDirectoryName(@"\Parent\file.txt"));
            //Log.Info(PathEx.GetDirectoryName(@"Parent\file.txt"));
            //Log.Info(PathEx.GetDirectoryName(@"\file.txt"));
            //Log.Info(PathEx.GetDirectoryName(@"file.txt"));
            //Log.Info(PathEx.GetDirectoryName(@"D:\Parent\file\"));
            //Log.Info(PathEx.GetDirectoryName(@"D:\Parent\file"));
            //Log.Info(PathEx.GetDirectoryName(@"\Parent\file"));
            //Log.Info(PathEx.GetDirectoryName(@"\file"));
            //Log.Info(PathEx.GetDirectoryName(@"\"));

            //Log.Info(PathEx.GetParentDirectoryName(@"D:\Parent\file.txt"));
            //Log.Info(PathEx.GetParentDirectoryName(@"\Parent\file.txt"));
            //Log.Info(PathEx.GetParentDirectoryName(@"Parent\file.txt"));
            //Log.Info(PathEx.GetParentDirectoryName(@"\file.txt"));
            //Log.Info(PathEx.GetParentDirectoryName(@"file.txt"));
            //Log.Info(PathEx.GetParentDirectoryName(@"D:\Parent\file\"));
            //Log.Info(PathEx.GetParentDirectoryName(@"D:\Parent\file"));
            //Log.Info(PathEx.GetParentDirectoryName(@"\Parent\file"));
            //Log.Info(PathEx.GetParentDirectoryName(@"\file"));
            //Log.Info(PathEx.GetParentDirectoryName(@"\"));

            //Log.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file.txt"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"\Parent\file.txt"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"Parent\file.txt"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"\file.txt"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"file.txt"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file\"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"D:\Parent\file"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"\Parent\file"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"\file"));
            //Log.Info(PathEx.GetPathWithoutExtension(@"\"));


            //Log.Info(PathEx.GetNewFileName(@"D:\Parent\file.txt", "222"));

            //Log.Info(PathEx.ChangeSeparatorToPositive(@"D:\\Parent\\file.txt"));

            Log.Info(@"D:\\Parent\\file.txt");
            Log.Info(PathEx.ChangeEscapeToPath("D:\\\"Parent\\file.txt"));
        }

        private void Test_FileSize()
        {
            Log.Info("" + MemorySize.KB);
            Log.Info("" + MemorySize.MB);
            Log.Info("" + MemorySize.GB);
            Log.Info("" + MemorySize.TB);

            ulong a = ulong.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                a /= 1024;
            }

            Log.Info("\n{0}\n", a);

            Log.Info("" + new MemorySize(10241).TotalKBs);
        }

        private void Test_Lang()
        {
            //Lang.Init(@"D:\Unity\VSProjects\ClassLibraries\UnitTest\lang.xml");
            //Lang3.Init(@"D:\Unity\VSProjects\ClassLibraries\UnitTest\lang.json");

            //Lang.LoadFromFile<XmlLanguage>(@"D:\Unity\VSProjects\ClassLibraries\Core\UnitTest\lang.xml");
            //Lang.LoadFromFile<JsonLanguage>(@"D:\Unity\VSProjects\ClassLibraries\Core\UnitTest\lang.json");
            Lang.LoadFromFile<CsvLanguage>(@"D:\Unity\VSProjects\ClassLibraries\Core\UnitTest\lang.csv");

            Log.Info(Lang.Trans("k2", "+", 3.56465f));
        }
    }
}

