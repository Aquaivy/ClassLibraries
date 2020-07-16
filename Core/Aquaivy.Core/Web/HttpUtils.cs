using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Webs
{
    public class RequestResponse
    {
        public bool Success;
        public int StatusCode;

        public string ResponseString;
    }


    /// <summary>
    /// 
    /// </summary>
    public class HttpRequestUtils
    {
        /// <summary>
        /// HTTP发送Get请求方法
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static RequestResponse Get(string uri)
        {
            var contentType = "text/html;charset=UTF-8";

            return Get(uri, contentType, 10 * 1000);
        }

        public static RequestResponse Get(string uri, string contentType, int timeout)
        {
            return Get(uri, contentType, timeout, Encoding.UTF8);
        }

        /// <summary>
        /// HTTP发送Get请求方法
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="contentType"></param>
        /// <param name="timeout"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static RequestResponse Get(string uri, string contentType, int timeout, Encoding encoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = contentType;
            request.Timeout = timeout;

            RequestResponse rr = new RequestResponse();

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream, encoding);
                string responseString = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                reader.Dispose();
                stream.Dispose();

                rr.Success = true;
                rr.ResponseString = responseString;

            }
            catch (Exception ex)
            {
                rr.Success = false;
                Console.WriteLine(ex.ToString());
            }

            return rr;
        }

        /// <summary>
        /// HTTP发送Post请求方法
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
