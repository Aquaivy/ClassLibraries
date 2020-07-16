using Aquaivy.Core.Webs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.WebAPI.Weather
{
    /// <summary>
    /// 获取ip
    /// </summary>
    public partial class WeatherApi
    {
        public class sojsonResponseData
        {

        }

        /// <summary>
        /// 获取指定城市id的天气(未完成，需要根据城市名查找城市id)
        /// </summary>
        /// <returns></returns>
        public static sojsonResponseData GetWeatherBySojsonApi()
        {
            string url = "http://t.weather.sojson.com/api/weather/city/101020100";

            sojsonResponseData data = null;

            var response = HttpRequestUtils.Get(url);
            if (response.Success)
            {
                var s = response.ResponseString;


                data = JsonConvert.DeserializeObject<sojsonResponseData>(s);
                Console.WriteLine(s);
            }
            else
            {
                data = new sojsonResponseData { };
            }

            return data;
        }
    }

}
