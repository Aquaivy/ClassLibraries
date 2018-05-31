using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public class UIHitArea : Selectable, IEnable
    {
        //public BoxCollider collider { get; set; }

        public UIHitArea(float x, float y, float width, float height)
            : this(x, y, width, height, Anchor.UpperLeft)
        {

        }

        public UIHitArea(float x, float y, float width, float height, Vector2 pivot)
        {
#if UNITY_EDITOR
            Name = "HitArea";
#endif

            //collider = gameObject.AddComponent<BoxCollider>();

            this.Pivot = pivot;
            SetPosition(x, y);
            Size = new Vector2(width, height);
            //ResetCollider();
        }

        /// <summary>
        /// 重置Collider，使其与图像完全重合
        /// </summary>
        //public override void ResetCollider()
        //{
        //    collider.size = new Vector3(Width, Height, 0.1f);
        //    float ccx = (0.5f - Pivot.x) * Width;
        //    float ccy = (0.5f - Pivot.y) * Height;
        //    collider.center = new Vector3(ccx, ccy, 0);
        //}

        public bool Enable
        {
            get;
            set;
        }
    }
}
