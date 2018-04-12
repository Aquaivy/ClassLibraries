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
            //Common.Instance.Run();
            //new Component().Run();
            //Serialize.Instance.ReadValues();
            Serialize.Instance.WriteValues();

            Console.ReadKey();
        }
    }
}
