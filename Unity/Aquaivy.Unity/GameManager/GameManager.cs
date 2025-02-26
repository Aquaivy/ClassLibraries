﻿using Aquaivy.Core.Logs;
using Aquaivy.Unity;
using Aquaivy.Unity.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// Unity模块的基础管理器
    /// </summary>
    public class GameManager : UnitySingleton<GameManager>
    {

        public LogMessageType LogLevel = LogMessageType.MSG_INFO;

        /// <summary>
        /// 每一帧都会触发该事件，不管被监听物体是否显示
        /// </summary>
        public static event UpdateDelegate OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        public static event ApplicationFocusDelegate ApplicationFocus;

        /// <summary>
        /// 
        /// </summary>
        public static event ApplicationPauseDelegate ApplicationPause;

        /// <summary>
        /// 
        /// </summary>
        public static event ApplicationQuitDelegate ApplicationQuit;


        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("GameManager Awake");

            LogManager.Instance.Init(LogLevel);
            InputManager.RegisterInputHandler();
        }


        private void Start()
        {

        }

        private void Update()
        {
            int elapseTime = (int)(Time.smoothDeltaTime * 1000);

            TaskLite.Update(elapseTime);
            TweenLite.Update(elapseTime);

            OnUpdate?.Invoke(elapseTime);
        }

        private void OnApplicationFocus(bool focus)
        {
            ApplicationFocus?.Invoke(focus);
        }

        private void OnApplicationPause(bool pause)
        {
            ApplicationPause?.Invoke(pause);
        }

        private void OnApplicationQuit()
        {
            ApplicationQuit?.Invoke();
        }
    }
}
