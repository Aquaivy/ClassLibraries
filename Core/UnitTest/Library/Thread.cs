using Aquaivy.Core.Logs;
using Aquaivy.Core.Webs;
using DogSE.Library.Thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class Thread
    {
        internal void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                int idx = i;
                ThreadQueue.Append(() =>
                {

                    Log.Info(idx.ToString());
                });
            }

        }
    }
}
