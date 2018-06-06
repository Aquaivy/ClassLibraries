using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public class UINode : UIElement
    {
#if IMPERFECTION
        public UINode(GameObject go)
            : base(go)
        {

        }
#endif

        public UINode()
            : this(0, 0)
        {

        }

        public UINode(float x, float y)
            : this(x, y, 100, 100)
        {

        }

        public UINode(float x, float y, float width, float height)
        {
#if UNITY_EDITOR
            Name = "Node";
#endif

            SetPosition(x, y);
            SetSize(width, height);
        }
    }
}
