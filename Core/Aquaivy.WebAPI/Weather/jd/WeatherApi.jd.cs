using Aquaivy.Core.Webs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.WebAPI.Weather
{
    public class jdResponseData
    {

    }

    /// <summary>
    /// 获取ip
    /// </summary>
    public partial class WeatherApi
    {

        /// <summary>
        /// 获取指定城市id的天气（为完成开发）
        /// </summary>
        /// <returns></returns>
        public static jdResponseData GetWeatherByjdApi()
        {
            //网址url：https://wx.jdcloud.com/market/datas/26/10610
            string url = "https://way.jd.com/he/freeweather";

            jdResponseData data = null;

            var response = HttpRequestUtils.Get(url);
            if (response.Success)
            {
                var s = response.ResponseString;


                data = JsonConvert.DeserializeObject<jdResponseData>(s);
                Console.WriteLine(s);
            }
            else
            {
                data = new jdResponseData { };
            }

            return data;
        }
    }

}
