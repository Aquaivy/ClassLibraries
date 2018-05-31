using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public abstract class Graphic : UIElement, IColorable
    {
        public Graphic()
        {

        }

#if IMPERFECTION
        public Graphic(GameObject go)
            : base(go)
        {

        }
#endif


        public abstract Color Colour { get; set; }

        public abstract float Alpha { get; set; }
    }
}
