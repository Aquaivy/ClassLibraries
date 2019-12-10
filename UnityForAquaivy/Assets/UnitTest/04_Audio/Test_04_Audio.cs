using Aquaivy.Core.Logs;
using Aquaivy.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NameSpace_Test_04_Audio
{
    public class Test_04_Audio : MonoBehaviour
    {
        public GameObject go;

        Audio audio;

        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                audio = Audio.PlayResource("incoming.mp3");
                Log.Info("samples  " + audio.AudioClip.samples);
                Log.Info("channels  " + audio.AudioClip.channels);
                Log.Info("frequency  " + audio.AudioClip.frequency);
                
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                //string path = Application.streamingAssetsPath + "/扫描识别音效.mp3";
                string path = Application.streamingAssetsPath + "/incoming.mp3";

                //audio = Audio.PlayResource("incoming.mp3");
                audio = Audio.Play(path);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                audio.Stop();
            }
        }
    }
}
