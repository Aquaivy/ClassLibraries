using DogSE.Library.Log;
using DogSE.Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class Util
    {
        internal void Run()
        {
            Test_Lang();
            
        }

        private void Test_Lang()
        {
            //Lang.Init("D://AndroidManifest.xml");
            Lang.Init("D://lang.json");

            Logs.Info(Lang.Trans("k1"));
        }
    }
}
