using Aquaivy.Core.Logs;
using Aquaivy.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NameSpace_Test_06_Layer
{
    public class Test_06_Layer : MonoBehaviour
    {
        private void Start()
        {
            var layer = LayerExtensions.ToMask(3);
            Log.Info("" + layer);
        }

        private void Update()
        {

        }
    }
}
