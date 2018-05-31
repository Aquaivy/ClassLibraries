using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    /// <summary>
    /// 封装旧版Animation组件（未完成）
    /// </summary>
    public class UIAnimation : UIElement, IAnimation
    {
        private GameObject animPrefab = null;
        private Animation animation = null;
        private string currentAnim = null;

        public int CurrentFrame { get; set; }

        public float Speed
        {
            get
            {
                if (animation == null)
                {
                    Debug.LogError("animation == null");
                    return 0;
                }

                return animation[currentAnim].normalizedSpeed;
            }

            set
            {
                if (animation == null)
                {
                    Debug.LogError("animation == null");
                    return;
                }

                animation[currentAnim].normalizedSpeed = value;
            }
        }

        public int TotalFrames { get; set; }

        public event EventHandler<AnimationFrameEventArgs> OnFrame;




        public UIAnimation(string animPath, float x, float y)
        {
#if UNITY_EDITOR
            Name = "Animation";
#endif

            LoadPrefab(animPath);
            SetPosition(x, y);
        }

        private void LoadPrefab(string path)
        {
            var obj = Resources.Load(path);
            if (obj == null)
            {
                Debug.LogWarningFormat("Load {0} error.", path);
                return;
            }

            animPrefab = GameObject.Instantiate(obj, this.transform, true) as GameObject;
            animation = animPrefab.GetComponent<Animation>();

            if (animation == null)
            {
                Debug.LogError("animation == null");
                return;
            }

            currentAnim = animation.clip.name;
        }

        public void Play()
        {
            Play(currentAnim);
        }

        public void Play(string name)
        {
            animation.Play(name);
            currentAnim = name;
        }

        public void Reset()
        {
            Reset(currentAnim);
        }

        public void Reset(string name)
        {
            animation[name].normalizedTime = 0;
            Stop();
        }

        public void Stop()
        {
            animation.Stop();
        }

        public void Stop(string name)
        {
            animation.Stop(name);
        }
    }
}
