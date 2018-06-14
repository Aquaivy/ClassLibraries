using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Webs
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpRequestUtils
    {
        /// <summary>
        /// Http发送Get请求方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string Get(string url, string postData)
        {
            var data = string.IsNullOrEmpty(postData) ? string.Empty : ("?" + postData);
            url = url + data;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string retString = reader.ReadToEnd();

            reader.Close();
            stream.Close();
            reader.Dispose();
            stream.Dispose();

            return retString;
        }
        /// <summary>
        /// Http发送Post请求方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string Post(string url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码 
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }

        public static string GetAsnyc(string url, string postDataStr)
        {
            throw new NotImplementedException();
        }

        public static string PostAsnyc(string url, string postDataStr)
        {
            throw new NotImplementedException();
        }
    }
}
