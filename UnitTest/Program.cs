using DogSE.Library.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Library;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Logs.AddConsoleAppender();

            Common.Instance.ObjectPoolTest();
            //new Component().Run();
            //Serialize.Instance.ReadValues();
            //Serialize.Instance.WriteValues();

            Console.ReadKey();
        }
    }
}
