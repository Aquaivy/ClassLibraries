using Aquaivy.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// Unity模块的基础管理器，
    /// 使用其他模块前先调用GameManager.Init()
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private static GameObject gameManagerObject;

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
        /// 初始化游戏世界管理器
        /// </summary>
        public static void Init()
        {
            if (gameManagerObject != null)
                return;

            gameManagerObject = new GameObject("GameManager");
            gameManagerObject.AddComponent<GameManager>();
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
