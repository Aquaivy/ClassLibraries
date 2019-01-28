using System.Collections.Generic;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public abstract class FrmBase : UIElement
    {
        public abstract FrmLayer Layer { get; }
        public bool IsShowing { get; private set; }

        protected TweenLite TweenAdder { set { tweens.Add(value); } }
        protected List<TweenLite> tweens = new List<TweenLite>();

        protected TaskLite TaskAdder { set { tasks.Add(value); } }
        protected List<TaskLite> tasks = new List<TaskLite>();

        protected List<TweenLite> Tweens
        {
            set
            {
                foreach (var item in value)
                {
                    TweenAdder = item;
                }
            }
        }

        public FrmBase()
        {
#if UNITY_EDITOR
            Name = "FrmBase";
#endif

            UIRootManager.AddForm(this);
            Hide();
        }


        public void Show()
        {
            if (OnShowing())
            {
                gameObject.SetActive(true);
                IsShowing = true;

                OnShowed();
            }
        }

        protected virtual bool OnShowing()
        {
            return true;
        }

        protected virtual void OnShowed()
        {
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            IsShowing = false;
        }

        public void Close()
        {
            if (OnClosing())
            {
                this.DisposeAllChilds();
                if (this.gameObject != null)
                    GameObject.Destroy(this.gameObject);
                IsShowing = false;

                ReleaseTasksAndTweens();

                UIRootManager.RemoveForm(this);
                OnClosed();
            }
        }

        protected virtual bool OnClosing()
        {
            return true;
        }

        protected virtual void OnClosed()
        {
        }

        public override void Dispose()
        {
            Close();
        }

        /// <summary>
        /// 由UIRootManager每帧调用一次，
        /// 一般情况下请勿调用该方法
        /// </summary>
        public virtual void RunUpdate(/*int milliseconds*/)
        {
            OnUpdate();
        }

        public void ReleaseTasksAndTweens()
        {
            tweens.ForEach(o => o?.Release());
            tasks.ForEach(o => o?.Release());
        }
    }
}
