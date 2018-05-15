using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aquaivy.Unity.Utilities
{
    public class GameObjectHelper
    {
        /// <summary>
        /// 返回当前场景所有GameObject
        /// </summary>
        /// <returns></returns>
        public static List<GameObject> GetGameObjects()
        {
            var s = SceneManager.GetActiveScene();
            return GetGameObjects(s);
        }

        /// <summary>
        /// 返回给定场景所有GameObject
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public static List<GameObject> GetGameObjects(Scene scene)
        {
            if (!scene.IsValid())
                throw new ArgumentException("scene.IsValid() is False", "scene");

            var roots = scene.GetRootGameObjects();
            List<GameObject> gameObjects = new List<GameObject>(128);

            for (int i = 0; i < roots.Length; i++)
            {
                GetChild(roots[i], gameObjects);
            }

            return gameObjects;
        }

        private static void GetChild(GameObject go, List<GameObject> lst)
        {
            lst.Add(go);

            int cnt = go.transform.childCount;
            if (cnt > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    GetChild(go.transform.GetChild(i).gameObject, lst);
                }
            }
        }
    }
}
