using Aquaivy.Core.Logs;
using Aquaivy.Core.Webs;
using Aquaivy.WebAPI.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    class WebApi
    {
        internal void Run()
        {
            LocationApi.GetLocationByBaiduApi();

            //Log.Info(ret);
        }
    }
}
