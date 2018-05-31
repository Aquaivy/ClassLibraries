using System;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    /// <summary>
    /// UI元素基类
    /// </summary>
    public abstract class BaseElement : IDisposable
    {
        #region Private Field

        protected string m_name;
        protected RectTransform m_rt;
        protected Vector3 m_position = Vector3.zero;
        protected Quaternion m_rotation = Quaternion.Euler(0, 0, 0);
        protected Vector3 m_scale = Vector3.one;

        #endregion

        #region Property

        public object Tag { get; set; }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; gameObject.name = value; }
        }

        public int DisplayLayer
        {
            get { return gameObject.layer; }
            set { gameObject.layer = value; }
        }

        /// <summary>
        /// 组件显示了多久的时间，单位:毫秒
        /// </summary>
        //public int ElapseMilliseconds { get; private set; }

        public GameObject gameObject { get; set; }

        public Transform transform { get { return gameObject.transform; } }

        public RectTransform RectTransform
        {
            get { return m_rt; }
            set { m_rt = value; }
        }

        public Vector2 Pivot
        {
            get { return m_rt.pivot; }
            set { m_rt.pivot = value; }
        }

        /// <summary>
        /// 相对于父物体的哪一个位置，标记为自己的(0,0)点   [0,1]
        /// </summary>
        public Vector2 AnchorMin
        {
            get { return RectTransform.anchorMin; }
            set { RectTransform.anchorMin = value; }
        }

        /// <summary>
        /// 相对于父物体的哪一个位置，标记为自己的(0,0)点   [0,1]
        /// </summary>
        public Vector2 AnchorMax
        {
            get { return RectTransform.anchorMax; }
            set { RectTransform.anchorMax = value; }
        }


        public float x
        {
            get { return m_position.x; }
            set { Position = new Vector3(value, m_position.y, m_position.z); }
        }

        public float y
        {
            get { return m_position.y; }
            set { Position = new Vector3(m_position.x, value, m_position.z); }
        }

        public float z
        {
            get { return m_position.z; }
            set { Position = new Vector3(m_position.x, m_position.y, value); }
        }


        public Vector3 Position
        {
            get { return m_position; }
            set
            {
                //方案一  不转坐标  (0,0)左下角  向下y减小
                //rt.anchoredPosition3D = value;
                //_position = rt.anchoredPosition3D;

                //方案二  转坐标   (0,0)左上角  向下y增大
                RectTransform.anchoredPosition3D = new Vector3(value.x, -value.y, value.z);
                m_position = value;
            }
        }

        public Quaternion Rotation
        {
            get { return m_rotation; }
            set
            {
                RectTransform.localRotation = value;
                m_rotation = value;
            }
        }


        public virtual float Width
        {
            get { return Size.x; }
            set { Size = new Vector2(value, Size.y); }
        }

        public virtual float Height
        {
            get { return Size.y; }
            set { Size = new Vector2(Size.x, value); }
        }

        public Vector2 Size
        {
            get { return RectTransform.sizeDelta; }
            set { RectTransform.sizeDelta = value; }
        }

        public virtual float HarfWidth { get { return Width / 2f; } }
        public virtual float HarfHeight { get { return Height / 2f; } }

        public Vector3 Scale
        {
            get { return RectTransform.localScale; }
            set { m_scale = value; RectTransform.localScale = m_scale; }
        }

        public float ScaleRatio
        {
            get { return RectTransform.localScale.x; }
            set { m_scale = new Vector3(value, value, value); RectTransform.localScale = m_scale; }
        }

        /// <summary>
        /// 获取或设置Element的显示状态（受Parent影响）
        /// </summary>
        public bool Visible
        {
            get { return gameObject.activeInHierarchy; }
            set { gameObject.SetActive(value); }
        }

        /// <summary>
        /// 获取gameObject自身的显示状态
        /// </summary>
        public bool SelfVisible
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }


        #endregion

        #region Constructor/Destructor Function

        public BaseElement()
        {
            gameObject = new GameObject();
            m_rt = gameObject.AddComponent<RectTransform>();

            m_rt.anchorMin = Anchor.UpperLeft;
            m_rt.anchorMax = Anchor.UpperLeft;

            m_rt.pivot = Anchor.UpperLeft;
        }

#if IMPERFECTION
        public BaseElement(GameObject go)
        {
            if (go == null)
                throw new ArgumentNullException();

            this.go = go;
            _rt = go.GetComponent<RectTransform>();
            if (_rt == null)
                _rt = go.AddComponent<RectTransform>();

            _name = go.name;
            _position = _rt.anchoredPosition3D;
            _scale = _rt.localScale;
        }
#endif


        ~BaseElement()
        {
            if (gameObject != null)
            {
                //放到主线程去销毁
                TaskLite.Invoke(t =>
                {
                    if (gameObject != null)
                    {
                        Debug.LogError("析构函数中销毁物体  " + Name);
                        GameObject.DestroyImmediate(gameObject, true);
                        gameObject = null;
                    }
                    return true;
                });
            }
        }

        #endregion

        #region Method

        public BaseElement SetPosition(float x, float y)
        {
            Position = new Vector3(x, y, m_position.z);
            return this;
        }

        public BaseElement SetPosition(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
            return this;
        }

        public BaseElement SetRotation(float x, float y, float z)
        {
            Rotation = Quaternion.Euler(x, y, z);
            return this;
        }

        public BaseElement SetSize(float width, float height)
        {
            Size = new Vector2(width, height);
            return this;
        }

        //protected virtual void OnUpdate(int milliseconds)
        //{
        //    ElapseMilliseconds += milliseconds;
        //}

        protected virtual void OnUpdate()
        {
        }

        public virtual void Dispose()
        {
            if (gameObject != null)
            {
                GameObject.Destroy(gameObject);
                gameObject = null;
            }

        }

        #endregion


    }
}
