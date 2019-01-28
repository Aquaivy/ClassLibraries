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
        public Image image { get; set; }
        public InputField input { get; set; }

        public UIInputField(float x, float y, float width, float height, string text, int fontsize, Color color)
        {
#if UNITY_EDITOR
            Name = "InputField";
#endif

            image = gameObject.AddComponent<Image>();
            input = gameObject.AddComponent<InputField>();
        }
    }
}
