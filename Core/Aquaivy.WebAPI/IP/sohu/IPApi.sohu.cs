using Aquaivy.Core.Webs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.WebAPI.IP
{
    /// <summary>
    /// 获取ip
    /// </summary>
    public partial class IPApi
    {
        public class SohuResponseData
        {
            public string cip;
            public string cid;
            public string cname;
        }

        /// <summary>
        /// 获取自身ip
        /// </summary>
        /// <returns></returns>
        public static SohuResponseData GetIPBySohuApi()
        {
            string url = "http://pv.sohu.com/cityjson";

            SohuResponseData data = null;

            var response = HttpRequestUtils.Get(url, "text/html;charset=UTF-8", 10 * 1000, Encoding.Default);
            if (response.Success)
            {
                var s = response.ResponseString;

                s = s.Substring(s.IndexOf('{')).TrimEnd(';');

                data = JsonConvert.DeserializeObject<SohuResponseData>(s);
                Console.WriteLine(s);
            }
            else
            {
                data = new SohuResponseData { };
            }

            return data;
        }
    }

}
