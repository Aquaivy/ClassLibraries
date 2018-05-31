using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public class Anchor
    {
        //常用pivot
        public static readonly Vector2 UpperLeft = new Vector2(0f, 1f);
        public static readonly Vector2 UpperCenter = new Vector2(0.5f, 1f);
        public static readonly Vector2 UpperRight = new Vector2(1f, 1f);

        public static readonly Vector2 MiddleLeft = new Vector2(0f, 0.5f);
        public static readonly Vector2 MiddleCenter = new Vector2(0.5f, 0.5f);
        public static readonly Vector2 MiddleRight = new Vector2(1f, 0.5f);

        public static readonly Vector2 LowerLeft = new Vector2(0f, 0f);
        public static readonly Vector2 LowerCenter = new Vector2(0.5f, 0f);
        public static readonly Vector2 LowerRight = new Vector2(1f, 0f);
    }

    public class Border
    {
        //常用border
        public static readonly Vector4 Border10 = new Vector4(10, 10, 10, 10);
        public static readonly Vector4 Border15 = new Vector4(15, 15, 15, 15);
        public static readonly Vector4 Border20 = new Vector4(20, 20, 20, 20);
        public static readonly Vector4 Border25 = new Vector4(25, 25, 25, 25);
        public static readonly Vector4 Border30 = new Vector4(30, 30, 30, 30);

    }
}
