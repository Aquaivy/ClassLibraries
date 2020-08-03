using Aquaivy.Core.Logs;
using Aquaivy.Core.Webs;
using Aquaivy.WebAPI.IP;
using Aquaivy.WebAPI.Location;
using Aquaivy.WebAPI.Weather;
using Aquaivy.WebAPI.Weather.JDCloud;
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
            //LocationApi.GetLocationByBaiduApi();
            //IPApi.GetIPBySohuApi();
            //WeatherApi.GetWeatherByTianqiApi();
            JDCloudWeatherApi.GetWeatherByjdApi();

            //Log.Info(ret);
        }
    }
}
