using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    /// <summary>
    /// （未完成）输入组件
    /// </summary>
    public class UIInputField : Selectable
    {
        public InputField input { get; set; }
        //public BoxCollider collider { get; set; }

        public UIInputField(float x, float y, float width, float height, string text, int fontsize, Color color)
        {
#if UNITY_EDITOR
            Name = "InputField";
#endif

            input = gameObject.AddComponent<InputField>();
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
    }
}
