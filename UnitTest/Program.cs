using Aquaivy.Core.Logs;
using System;
using UnitTest.Library;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.AddConsoleAppender();

            //Common.Instance.ObjectPoolTest();
            //new Component().Run();
            //Serialize.Instance.ReadValues();
            //Serialize.Instance.WriteValues();
            new Util().Run();

            Console.ReadKey();
        }
    }
}
