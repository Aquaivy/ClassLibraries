using Aquaivy.Core.Logs;
using Aquaivy.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace NameSpace_Test_09_Timeline
{
    public class Test_09_Timeline : MonoBehaviour
    {
        public PlayableDirector Playable;

        private void Start()
        {
            Playable.played += p => Log.Info("Playable.played");
            Playable.stopped += p => Log.Info("Playable.stopped");
            Playable.paused += p => Log.Info("Playable.paused");

            ThrottleTask.Invoke(() =>
            {
                Log.Info(Playable.time.ToString());
            }, 1000);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayTimeline();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                StopTimeline();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                PauseTimeline();
            }

            else if (Input.GetKeyDown(KeyCode.Z))
            {
                Playable.time = 0;
            }
        }

        private void PlayTimeline()
        {
            Log.Info("Play");
            Playable.Play();
        }

        private void StopTimeline()
        {
            Log.Info("Stop");
            Playable.Stop();
        }

        private void PauseTimeline()
        {
            Log.Info("Pause");
            Playable.Pause();
        }
    }
}
