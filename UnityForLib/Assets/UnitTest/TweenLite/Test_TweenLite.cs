using Aquaivy.Core.Utilities;
using Aquaivy.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace NameSpace_Test_TaskLite
{
    public class Test_TweenLite : MonoBehaviour
    {
        public GameObject cube;

        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RunTaskAsync();
            }
        }

        private void RunTaskAsync()
        {
            string name = NameSimulation.GetRandomChinesePersonalName(2);
            for (int i = 0; i < 10; i++)
            {
                int idx = i;
                Thread thread = new Thread(() =>
                {
                    TweenLite.To(0, 10, 2000, Linear.EaseIn, v =>
                    {
                        cube.transform.position = new Vector3(0, 0, v);
                    });
                });
                thread.Start();
            }
        }
    }
}
