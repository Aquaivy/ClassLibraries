using Aquaivy.Core.Logs;
using Aquaivy.Core.Utilities;
using Aquaivy.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace NameSpace_Test_TaskLite
{
    public class Test_03_ThrottleTask : MonoBehaviour
    {
        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CreateThrottleTask();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                TaskLite.ReleaseAll();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                WebTest();
            }
        }

        private void WebTest()
        {
            string url = "https://www.processon.com/diagrams";
            string ret = Aquaivy.Core.Webs.HttpRequestUtils.Get(url, "");

            Debug.Log(ret);
        }

        private void CreateThrottleTask()
        {
            Debug.LogError("123");
            ThrottleTask.Invoke(() =>
            {
                string name = NameSimulation.GetRandomChinesePersonalName(2);
                Debug.Log(name);
            }, 500, ThrottleStopType.Duration, 5000);
        }
    }
}
