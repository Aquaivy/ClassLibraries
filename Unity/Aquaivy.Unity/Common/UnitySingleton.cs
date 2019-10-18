using System;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// Unity的单例模式，可直接使用类名访问，而不管场景中有没有这个对象，
    /// 也可事先在场景中放置这个对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
    {
        private static T instance;

        /// <summary>
        /// 
        /// </summary>
        public static T Instance
        {
            get
            {
                if (!IsInitialized)
                {
                    var go = new GameObject(typeof(T).Name);
                    go.GetParentRoot().DontDestroyOnLoad();
                    instance = go.AddComponent<T>();
                }
                return instance;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AssertIsInitialized()
        {
            Debug.Assert(IsInitialized, string.Format("The {0} singleton has not been initialized.", typeof(T).Name));
        }

        /// <summary>
        /// Returns whether the instance has been initialized or not.
        /// </summary>
        public static bool IsInitialized
        {
            get
            {
                return instance != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            if (IsInitialized && instance != this)
            {
                if (Application.isEditor)
                {
                    DestroyImmediate(this);
                }
                else
                {
                    Destroy(this);
                }

                Debug.LogErrorFormat("Trying to instantiate a second instance of singleton class {0}. Additional Instance was destroyed", GetType().Name);
            }
            else if (!IsInitialized)
            {
                instance = (T)this;
                gameObject.GetParentRoot().DontDestroyOnLoad();
            }
        }

        /// <summary>
        /// Base OnDestroy method that destroys the Singleton's unique instance.
        /// Called by Unity when destroying a MonoBehaviour. Scripts that extend
        /// Singleton should be sure to call base.OnDestroy() to ensure the
        /// underlying static Instance reference is properly cleaned up.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }

}
