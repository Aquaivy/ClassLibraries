using Aquaivy.Core.Utilities;
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
    /// 获取天气
    /// </summary>
    public partial class WeatherApi
    {
        public class TianqiResponseData
        {
            public string cityid;           //"101020100",
            public string city;             //"上海",
            public string country;          //"中国",
            public string update_time;      //"2020-07-16 13:29:57",
            public DayWeather[] data;
            public AirQualityIndex aqi;
        }

        public class DayWeather
        {
            public string day;              //"16日（星期四）"
            public string date;             //"2020-07-16",
            public string week;             //"星期四",
            public string wea;              //"雨",
            public string pressure;         //大气压,
            public string win_speed;        //"3-4级",
            public string air;              //"25",
            public string air_level;        //"优",
            public string air_tips;         //"空气很好，可以外出活动，呼吸新鲜空气，拥抱大自然！",
        }

        public class AirQualityIndex
        {
            public string air;              //"25",
            public string air_level;        //"优",
            public string air_tips;         //"空气很好，可以外出活动，呼吸新鲜空气，拥抱大自然！",

            public string pm25;             //"14",
            public string pm25_desc;        //"优",

            public string pm10;             //"14",
            public string pm10_desc;        //"优",

            public string no2;              //"14",
            public string no2_desc;         //"优",

            public string so2;              //"14",
            public string so2_desc;         //"优",

            public string kouzhao;          //"无需戴口罩",
            public string waichu;           //"适宜外出",

            public string kaichuang;        //"适宜开窗",
        }

        /// <summary>
        /// 获取当前地点天气
        /// </summary>
        /// <returns></returns>
        public static TianqiResponseData GetWeatherByTianqiApi()
        {
            //文档url:http://doc.tianqiapi.com/603579

            string url = "http://www.tianqiapi.com/api?version=v9&appid=23035354&appsecret=8YvlPNrz";

            TianqiResponseData data = null;

            var response = HttpRequestUtils.Get(url);
            if (response.Success)
            {
                var s = response.ResponseString;
                s = EncodingUtils.UnicodeToString(s);

                data = JsonConvert.DeserializeObject<TianqiResponseData>(s);
                //Console.WriteLine(s);
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }

            return data;
        }
    }
}
