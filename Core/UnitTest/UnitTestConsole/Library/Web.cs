using Aquaivy.Core.Logs;
using Aquaivy.Core.Webs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class Web
    {
        internal void Run()
        {
            string url = "https://www.processon.com/diagrams";
            string ret = HttpRequestUtils.Get(url).ResponseString;

            Log.Info(ret);
        }
    }
}
