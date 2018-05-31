using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// 资源管理器
    /// </summary>
    public class ResourcesManager
    {
        private static Dictionary<string, GameObject> dicGameObjects = new Dictionary<string, GameObject>();

        public static GameObject Create(string name)
        {
            var template = Load(name);
            GameObject go = GameObject.Instantiate<GameObject>(template);

            return go;
        }

        /// <summary>
        /// 加载一个资源（资源只能在Resources中）
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject Load(string name)
        {
            //if (dicGameObjects.ContainsKey(name))
            //{
            //    return dicGameObjects[name];
            //}

            var go = Resources.Load<GameObject>(name);
            //dicGameObjects[name] = go;

            return go;
        }

        /// <summary>
        /// 卸载一个资源
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Unload(string name)
        {
            if (!dicGameObjects.ContainsKey(name))
            {
                return false;
            }

            var t = dicGameObjects[name];
            dicGameObjects.Remove(name);
            Resources.UnloadAsset(t);

            return true;
        }


        public static void Init()
        {

        }

        public static void Dispose()
        {

        }
    }
}
