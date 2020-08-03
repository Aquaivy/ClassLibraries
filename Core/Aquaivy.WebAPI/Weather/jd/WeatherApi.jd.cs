using Aquaivy.Core.Webs;
using Aquaivy.WebAPI.IP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.WebAPI.Weather.JDCloud
{
    /// <summary>
    /// 获取ip
    /// </summary>
    public class JDCloudWeatherApi
    {

        /// <summary>
        /// 获取当前手机所在城市的天气
        /// </summary>
        /// <returns></returns>
        public static JDCloudResponseData GetWeatherByjdApi()
        {
            #region 第一步：获取ip
            var ip = IPApi.GetIPBySohuApi();
            #endregion


            #region 第二步：获取天气

            //网址url：https://wx.jdcloud.com/market/datas/26/10610
            string url = string.Format("https://way.jd.com/he/freeweather?city={0}&appkey=6bd19c1668f49c131027fc7ed9fb53ec", ip.cip);

            JDCloudResponseData data = null;

            var response = HttpRequestUtils.Get(url);
            if (response.Success)
            {
                var s = response.ResponseString;

                data = JsonConvert.DeserializeObject<JDCloudResponseData>(s);
                //Console.WriteLine(s);
            }
            else
            {
                data = new JDCloudResponseData { };
            }

            return data;


            #endregion
        }
    }

}
