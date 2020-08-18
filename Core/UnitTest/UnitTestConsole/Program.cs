using Aquaivy.Core.Logs;
using System;
using UnitTest.Library;
using UnitTest.Tools;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.AddConsoleAppender();

            //Common.Instance.ObjectPoolTest();
            //new Component().Run();
            //new Thread().Run();
            Serialize.Instance.CSVSerialize();
            //Serialize.Instance.WriteValues();
            //new Util().Run();
            //new VersionTest().Run();
            //new Web().Run();
            //new WebApi().Run();

            Console.ReadKey();
        }
    }
}
