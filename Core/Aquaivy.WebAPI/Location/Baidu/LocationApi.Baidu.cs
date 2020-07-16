using Aquaivy.Core.Utilities;
using Aquaivy.Core.Webs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.WebAPI.Location
{
    public class BaiduResponseData
    {
        public string address;
        public Content content;
        public int status;
    }

    public class Content
    {
        public string address;
        public Address_Detail address_detail;
        public Point point;
    }

    public class Address_Detail
    {

        public string city;
        public int city_code;
        public string district;
        public string province;
        public string street;
        public string street_number;
    }

    public class Point
    {
        public string x;
        public string y;
    }

    /// <summary>
    /// 获取位置
    /// </summary>
    public partial class LocationApi
    {
        /// <summary>
        /// 
        /// </summary>
        public static BaiduResponseData GetLocationByBaiduApi()
        {
            string url = "http://api.map.baidu.com/location/ip?ak=bretF4dm6W5gqjQAXuvP0NXW6FeesRXb&coor=bd09ll";

            BaiduResponseData data = null;

            var response = HttpRequestUtils.Get(url);
            if (response.Success)
            {
                var s = response.ResponseString;
                s = EncodingUtils.UnicodeToString(s);
                data = JsonConvert.DeserializeObject<BaiduResponseData>(s);
                Console.WriteLine(s);
            }
            else
            {
                data = new BaiduResponseData { status = -1 };
            }

            return data;
        }
    }
}
