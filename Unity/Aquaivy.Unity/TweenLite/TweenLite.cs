using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aquaivy.Unity
{

    /// <summary>
    /// 缓动函数
    /// </summary>
    /// <param name="timeElapsed">当前时间的间隔</param>
    /// <param name="start">起始值</param>
    /// <param name="change">起始值到终点值的差值</param>
    /// <param name="duration">持续时间</param>
    /// <returns></returns>
    /// <remarks>
    /// 该版本为修复过的版本，最后一针必定为设定值
    /// </remarks>
    public delegate float TweeningFunction(float timeElapsed, float start, float change, float duration);

    /// <summary>
    /// 缓动计算类
    /// </summary>
    public partial class TweenLite
    {
        #region Static Members

        private static readonly object m_tasklock = new object();
        private static List<TweenLite> m_tweeners = new List<TweenLite>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elapsedTime"></param>
        public static void Update(int elapsedTime)
        {
            lock (m_tasklock)
            {
                if (m_tweeners.Count > 0)
                {
                    // 更新每一个tween
                    for (var i = 0; i < m_tweeners.Count; i++)
                    {
                        var tween = m_tweeners[i];
                        if (!tween.waitRelease && tween.InternalUpdate(elapsedTime))
                        {
                            m_tweeners.RemoveAt(i);
                            i--;
                        }
                    }

                    // 移出被标记为waitRelease的
                    for (var i = 0; i < m_tweeners.Count; i++)
                    {
                        var tween = m_tweeners[i];
                        if (tween.waitRelease)
                        {
                            m_tweeners.RemoveAt(i);
                            tween.Released?.Invoke();
                            i--;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from">起始值</param>
        /// <param name="to">结束值</param>
        /// <param name="duration">缓动时间（单位：毫秒）</param>
        /// <param name="tweeningFunction">缓动方式</param>
        /// <param name="onupdate">
        /// 每帧Update的回调
        /// 参数 float 标示当前的插值
        /// </param>
        /// <param name="onend">缓动结束时的回调</param>
        /// <returns></returns>
        public static TweenLite To(float from, float to, float duration, TweeningFunction tweeningFunction, Action<float> onupdate, Action onend = null)
        {
            lock (m_tasklock)
            {
                var tween = new TweenLite(from, to, duration, tweeningFunction, onupdate);
                if (onend != null)
                    tween.Ended += () => { onend(); };
                m_tweeners.Add(tween);
                return tween;
            }
        }

        /// <summary>
        /// 释放所有任务
        /// </summary>
        public static void ReleaseAll()
        {
            lock (m_tasklock)
            {
                m_tweeners.ForEach(o => o.Release());
            }
        }

        #endregion

        private TweenLite(float from, float to, float duration, TweeningFunction tweeningFunction, Action<float> onupdate)
        {
            _from = from;
            _position = from;
            _change = to - from;
            _tweeningFunction = tweeningFunction;
            _duration = duration;
            _onupdate = onupdate;
        }

        private TweenLite(float from, float to, TimeSpan duration, TweeningFunction tweeningFunction, Action<float> onupdate)
            : this(from, to, (float)duration.TotalSeconds, tweeningFunction, onupdate)
        {
        }

        #region Properties
        private float _position;

        /// <summary>
        /// 当前值
        /// from->to的插值
        /// </summary>
        public float Position
        {
            get
            {
                return _position;
            }
            protected set
            {
                _position = value;
            }
        }

        private float _from;

        /// <summary>
        /// 起始值
        /// </summary>
        protected float from
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        private float _change;

        /// <summary>
        /// 变化的值
        /// </summary>
        protected float change
        {
            get
            {
                return _change;
            }
            set
            {
                _change = value;
            }
        }

        private float _duration;

        /// <summary>
        /// 时间
        /// </summary>
        protected float duration
        {
            get
            {
                return _duration;
            }
        }

        private float _elapsed = 0.0f;
        protected float elapsed
        {
            get
            {
                return _elapsed;
            }
            set
            {
                _elapsed = value;
            }
        }

        private bool _running = true;

        /// <summary>
        /// 是否正在执行
        /// </summary>
        public bool Running
        {
            get { return _running; }
            protected set { _running = value; }
        }

        private TweeningFunction _tweeningFunction;
        protected TweeningFunction tweeningFunction
        {
            get
            {
                return _tweeningFunction;
            }
        }

        private Action<float> _onupdate;
        protected Action<float> onUpdate
        {
            get { return _onupdate; }
        }

        public delegate void EndHandler();
        public event EndHandler Ended;


        public delegate void ReleaseHandler();
        public event ReleaseHandler BeforeRelease;
        public event ReleaseHandler Released;
        #endregion

        #region Methods

        private bool InternalUpdate(int elapsedTime)
        {
            if (!Running || (elapsed == duration))
            {
                return false;
            }

            if (elapsed + elapsedTime < duration)
            {
                Position = tweeningFunction(elapsed, from, change, duration);
                if (onUpdate != null)
                    onUpdate(Position);
            }

            elapsed += elapsedTime;
            if (elapsed >= duration)
            {
                elapsed = duration;

                //方案一：本次计算已满足条件，不在调用onUpdate
                //Position = from + change;

                //方案二：调用onUpdate，补充一个执行最后1帧
                Position = tweeningFunction(elapsed, from, change, duration);
                if (onUpdate != null)
                    onUpdate(Position);

                OnEnd();
                return true;
            }

            return false;
        }

        protected void OnEnd()
        {
            if (Ended != null)
            {
                Ended();
            }
        }

        public void Start()
        {
            Running = true;
        }

        public void Stop()
        {
            Running = false;
        }

        public void Reset()
        {
            elapsed = 0.0f;
            from = Position;
        }

        public void Reset(float to)
        {
            change = to - Position;
            Reset();
        }

        public void Reverse()
        {
            elapsed = 0.0f;
            change = -change + (from + change - Position);
            from = Position;
        }


        private bool waitRelease = false;
        public void Release()
        {
            BeforeRelease?.Invoke();

            Stop();
            waitRelease = true;
        }

        //public override string ToString()
        //{
        //    return String.Format("{0}.{1}. Tween {2} -> {3} in {4}s. Elapsed {5:##0.##}s",
        //        tweeningFunction.Method.DeclaringType.Name,
        //        tweeningFunction.Method.Name,
        //        from,
        //        from + change,
        //        duration,
        //        elapsed);
        //}

        #endregion
    }
}
