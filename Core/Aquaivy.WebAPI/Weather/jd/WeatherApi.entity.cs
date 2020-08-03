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
    public class City
    {
        /// <summary>
        /// 
        /// </summary>
        public string aqi { get; set; }

        /// <summary>
        /// 优
        /// </summary>
        public string qlty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pm25 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pm10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string no2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string so2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string co { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string o3 { get; set; }

    }



    public class Aqi
    {
        /// <summary>
        /// 
        /// </summary>
        public City city { get; set; }

    }



    public class Update
    {
        /// <summary>
        /// 
        /// </summary>
        public string loc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string utc { get; set; }

    }



    public class Basic
    {
        /// <summary>
        /// 上海
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 中国
        /// </summary>
        public string cnty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string lat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string lon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Update update { get; set; }

    }



    public class Astro
    {
        /// <summary>
        /// 
        /// </summary>
        public string mr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string sr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ss { get; set; }

    }



    public class Daily_Cond
    {
        /// <summary>
        /// 
        /// </summary>
        public string code_d { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string code_n { get; set; }

        /// <summary>
        /// 多云
        /// </summary>
        public string txt_d { get; set; }

        /// <summary>
        /// 小雨
        /// </summary>
        public string txt_n { get; set; }

    }



    public class Tmp
    {
        /// <summary>
        /// 
        /// </summary>
        public string max { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string min { get; set; }

    }



    public class Wind
    {
        /// <summary>
        /// 
        /// </summary>
        public string deg { get; set; }

        /// <summary>
        /// 东南风
        /// </summary>
        public string dir { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string sc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string spd { get; set; }

    }



    public class Daily_forecastItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Astro astro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cloud { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Daily_Cond cond { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pcpn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pres { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Tmp tmp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string uv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string vis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Wind wind { get; set; }

    }



    public class Hourly_Cond
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 多云
        /// </summary>
        public string txt { get; set; }

    }


    public class Hourly_forecastItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Hourly_Cond cond { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pres { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tmp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Wind wind { get; set; }

    }



    public class Cond
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 晴
        /// </summary>
        public string txt { get; set; }

    }





    public class Now
    {
        /// <summary>
        /// 
        /// </summary>
        public Cond cond { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string dew { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string fl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pcpn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pres { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tmp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string vis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Wind wind { get; set; }

    }



    public class Air
    {
        /// <summary>
        /// 良
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 气象条件有利于空气污染物稀释、扩散和清除。
        /// </summary>
        public string txt { get; set; }

    }



    public class Comf
    {
        /// <summary>
        /// 较不舒适
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 白天天气多云，并且空气湿度偏大，在这种天气条件下，您会感到有些闷热，不很舒适。
        /// </summary>
        public string txt { get; set; }

    }



    public class Cw
    {
        /// <summary>
        /// 不宜
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 不宜洗车，未来24小时内有雨，如果在此期间洗车，雨水和路上的泥水可能会再次弄脏您的爱车。
        /// </summary>
        public string txt { get; set; }

    }



    public class Drsg
    {
        /// <summary>
        /// 炎热
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 天气炎热，建议着短衫、短裙、短裤、薄型T恤衫等清凉夏季服装。
        /// </summary>
        public string txt { get; set; }

    }



    public class Flu
    {
        /// <summary>
        /// 少发
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 各项气象条件适宜，发生感冒机率较低。但请避免长期处于空调房间中，以防感冒。
        /// </summary>
        public string txt { get; set; }

    }



    public class Sport
    {
        /// <summary>
        /// 较不宜
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 天气较好，但因风力较强，在户外要选择合适的运动；另外考虑到高温天气，建议停止高强度运动。
        /// </summary>
        public string txt { get; set; }

    }



    public class Trav
    {
        /// <summary>
        /// 一般
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 天气较好，温度高，让人感觉热，幸好风比较大，能缓解炎热的天气。外出旅游请注意防暑降温和防晒。
        /// </summary>
        public string txt { get; set; }

    }



    public class Uv
    {
        /// <summary>
        /// 中等
        /// </summary>
        public string brf { get; set; }

        /// <summary>
        /// 属中等强度紫外线辐射天气，建议涂擦SPF高于15、PA+的防晒护肤品，戴帽子、太阳镜。
        /// </summary>
        public string txt { get; set; }

    }



    public class Suggestion
    {
        /// <summary>
        /// 
        /// </summary>
        public Air air { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Comf comf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Cw cw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Drsg drsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Flu flu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Sport sport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Trav trav { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Uv uv { get; set; }

    }



    public class HeWeather5Item
    {
        /// <summary>
        /// 
        /// </summary>
        public Aqi aqi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Basic basic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Daily_forecastItem> daily_forecast { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Hourly_forecastItem> hourly_forecast { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Now now { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Suggestion suggestion { get; set; }

    }



    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public List<HeWeather5Item> HeWeather5 { get; set; }

    }



    public class JDCloudResponseData
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string charge { get; set; }

        /// <summary>
        /// 查询成功
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }

    }


}
