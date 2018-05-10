using Aquaivy.Unity.Tasks;
using Aquaivy.Unity.Tweens;
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
        }
    }
}
