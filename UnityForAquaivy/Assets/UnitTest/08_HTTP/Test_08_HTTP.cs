using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace NameSpace_Test_08_HTTP
{
    public class Test_08_HTTP : MonoBehaviour
    {

        private void Update()
        {

        }

        void Start()
        {
            //Debug.Log(PostWebRequest("http://192.168.1.1/EntryformServlet", "weixinid=测试&pwd=1234567"));

            //Get1();

            string uri = "http://tst2.shai.cloud:7070/saas/api/user/login";
            WWWForm form = new WWWForm();
            form.AddField("name", "engineer1");
            form.AddField("password", "111111");
            StartCoroutine(UnityWebRequest_POST(uri, form, null, null));
        }

        public static IEnumerator UnityWebRequest_GET(string url, Dictionary<string, string> headers, Action<UnityWebRequest, string> callback, Action<UnityWebRequest, string> error = null)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                webRequest.useHttpContinue = false;
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.timeout = 10;    //单位：秒

                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        webRequest.SetRequestHeader(h.Key, h.Value);
                    }
                }

                Debug.Log($"[UnityWebRequest  GET] {url}");
                yield return webRequest.SendWebRequest();

                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    Debug.LogError($"[UnityWebRequest error] {webRequest.error}");
                    error?.Invoke(webRequest, webRequest.error);
                }
                else
                {
                    if (webRequest.responseCode == 200)
                    {
                        Debug.Log($"[UnityWebRequest result] {webRequest.downloadHandler.text}");
                        callback?.Invoke(webRequest, webRequest.downloadHandler.text);
                    }
                    else
                    {
                        Debug.LogError($"[UnityWebRequest Error responseCode] {webRequest.responseCode}");
                        error?.Invoke(webRequest, webRequest.responseCode.ToString());
                    }
                }
            }

        }


        public static IEnumerator<UnityWebRequestAsyncOperation> UnityWebRequest_POST(string url, Dictionary<string, string> headers, byte[] post_data, Action<UnityWebRequest, string> callback, Action<UnityWebRequest, string> error = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
            {
                webRequest.useHttpContinue = false;
                webRequest.uploadHandler = new UploadHandlerRaw(post_data);
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.timeout = 10;    //单位：秒

                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        webRequest.SetRequestHeader(h.Key, h.Value);
                    }
                }

                Debug.Log($"[UnityWebRequest  Post] {url}");
                yield return webRequest.SendWebRequest();

                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    Debug.LogError($"[UnityWebRequest error] {webRequest.error}");
                    error?.Invoke(webRequest, webRequest.error);
                }
                else
                {
                    if (webRequest.responseCode == 200)
                    {
                        Debug.Log($"[UnityWebRequest result] {webRequest.downloadHandler.text}");
                        callback?.Invoke(webRequest, webRequest.downloadHandler.text);
                    }
                    else
                    {
                        Debug.LogError($"[UnityWebRequest Error responseCode] {webRequest.responseCode}");
                        error?.Invoke(webRequest, webRequest.responseCode.ToString());
                    }
                }
            }

        }


        public static IEnumerator<UnityWebRequestAsyncOperation> UnityWebRequest_POST(string url, WWWForm form, Action<UnityWebRequest, string> callback, Action<UnityWebRequest, string> error = null)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
            {
                webRequest.useHttpContinue = false;
                webRequest.timeout = 10;    //单位：秒

                Debug.Log($"[UnityWebRequest  Post] {url}");
                yield return webRequest.SendWebRequest();

                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    Debug.LogError($"[UnityWebRequest error] {webRequest.error}");
                    error?.Invoke(webRequest, webRequest.error);
                }
                else
                {
                    if (webRequest.responseCode == 200)
                    {
                        Debug.Log($"[UnityWebRequest result] {webRequest.downloadHandler.text}");
                        callback?.Invoke(webRequest, webRequest.downloadHandler.text);
                    }
                    else
                    {
                        Debug.LogError($"[UnityWebRequest Error responseCode] {webRequest.responseCode}");
                        error?.Invoke(webRequest, webRequest.responseCode.ToString());
                    }
                }
            }

        }



        private string PostWebRequest(string postUrl, string paramData)
        {
            // 把字符串转换为bype数组
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(paramData);

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
            webReq.ContentLength = bytes.Length;
            using (Stream newStream = webReq.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
            }

            using (WebResponse res = webReq.GetResponse())
            {
                //在这里对接收到的页面内容进行处理
                Stream responseStream = res.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
                string str = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                //返回：服务器响应流 
                return str;
            }
        }
    }

}
