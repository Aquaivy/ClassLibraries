using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public class UIPrefab : UIElement
    {
        public UIPrefab(string prefabPath, float x, float y)
            : this(prefabPath, x, y, 100, 100)
        {

        }

        public UIPrefab(string prefabPath, float x, float y, float width, float height)
        {
#if UNITY_EDITOR
            Name = "Prefab";
#endif

            LoadPrefab(prefabPath);
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

            var gameobject = GameObject.Instantiate(obj, this.transform, true) as GameObject;
        }
    }
}
