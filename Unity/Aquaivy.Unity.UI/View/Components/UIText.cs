using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class UIText : Graphic
    {
        private string strText;

        public UnityEngine.UI.Text textComponent { get; set; }


        public UIText(float x, float y, int fontsize, Color color)
            : this(string.Empty, x, y, fontsize, color,
                  TextAnchor.UpperLeft,
                  HorizontalWrapMode.Overflow, VerticalWrapMode.Overflow)
        {

        }

        public UIText(string text, float x, float y, int fontsize, Color color)
            : this(text, x, y, fontsize, color,
                  TextAnchor.UpperLeft,
                  HorizontalWrapMode.Overflow, VerticalWrapMode.Overflow)
        {

        }

        public UIText(string text, float x, float y, int fontsize, Color color, TextAnchor alignment)
            : this(text, x, y, fontsize, color,
                  alignment,
                  HorizontalWrapMode.Overflow, VerticalWrapMode.Overflow)
        {

        }

        public UIText(string text, float x, float y, int fontsize, Color color,
            TextAnchor alignment,
            HorizontalWrapMode horizontalOverflow, VerticalWrapMode verticalOverflow)
        {
#if UNITY_EDITOR
            Name = "Text";
#endif
            this.textComponent = gameObject.AddComponent<Text>();
            this.textComponent.raycastTarget = false;

            if (FontManager.DefaultFont == null)
                Debug.LogWarning("DefaultFont is null, please call \"FontManager.SetDefaultFont()\" first");

            this.Font = FontManager.DefaultFont;
            this.FontSize = fontsize;
            this.Colour = color;
            this.Alignment = alignment;
            this.HorizontalOverflow = horizontalOverflow;
            this.VerticalOverflow = verticalOverflow;
            this.SupportRichText = false;
            this.Text = text;   //这行代码必须放在HorizontalOverflow VerticalOverflow赋值之后

            SetAnchor(alignment);

            SetPosition(x, y);
        }

        private TaskLite taskDelay;

        public string Text
        {
            get { return strText; }
            set
            {
                textComponent.text = value;
                strText = value;

                CalcTextPreferredWidth();
            }
        }

        private void CalcTextPreferredWidth()
        {
            //这里很无奈，UGUI中文字只有渲染过后才能拿到正确的preferredWidth
            //所以这里延迟1帧再进行赋值
            taskDelay?.Release();
            if (this.HorizontalOverflow == HorizontalWrapMode.Overflow && this.VerticalOverflow == VerticalWrapMode.Overflow)
            {
                taskDelay = TaskLite.Invoke(t =>
                {
                    //Debug.Log($"after one frame  {textComponent.preferredWidth}   {textComponent.preferredHeight}");
                    if (this != null && textComponent != null)
                        Size = new Vector2(textComponent.preferredWidth, textComponent.preferredHeight);
                    taskDelay = null;
                    return true;
                });
            }
        }


        /// <summary>
        /// 字体
        /// </summary>
        public Font Font
        {
            get { return textComponent.font; }
            set { textComponent.font = value; }
        }

        /// <summary>
        /// 文字的锚点位置（左距中、右距中）
        /// </summary>
        public TextAnchor Alignment
        {
            get { return textComponent.alignment; }
            set
            {
                textComponent.alignment = value;
                SetAnchor(value);
            }
        }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize
        {
            get { return textComponent.fontSize; }
            set { textComponent.fontSize = value; }
        }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public override Color Colour
        {
            get { return textComponent.color; }
            set { textComponent.color = value; }
        }

        /// <summary>
        /// 透明度  [0,1]
        /// </summary>
        public override float Alpha
        {
            get { return textComponent.color.a; }
            set { textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, value); }
        }

        /// <summary>
        /// 【水平】方向文字溢出方式
        /// </summary>
        public HorizontalWrapMode HorizontalOverflow
        {
            get { return textComponent.horizontalOverflow; }
            set { textComponent.horizontalOverflow = value; CalcTextPreferredWidth(); }
        }

        /// <summary>
        /// 【垂直】方向文字溢出方式
        /// </summary>
        public VerticalWrapMode VerticalOverflow
        {
            get { return textComponent.verticalOverflow; }
            set { textComponent.verticalOverflow = value; CalcTextPreferredWidth(); }
        }

        /// <summary>
        /// 是否支持富文本
        /// </summary>
        public bool SupportRichText
        {
            get { return textComponent.supportRichText; }
            set { textComponent.supportRichText = value; }
        }


        private void SetAnchor(TextAnchor alignment)
        {
            switch (alignment)
            {
                case TextAnchor.UpperLeft:
                    Pivot = Anchor.UpperLeft;
                    break;
                case TextAnchor.UpperCenter:
                    Pivot = Anchor.UpperCenter;
                    break;
                case TextAnchor.UpperRight:
                    Pivot = Anchor.UpperRight;
                    break;
                case TextAnchor.MiddleLeft:
                    Pivot = Anchor.MiddleLeft;
                    break;
                case TextAnchor.MiddleCenter:
                    Pivot = Anchor.MiddleCenter;
                    break;
                case TextAnchor.MiddleRight:
                    Pivot = Anchor.MiddleRight;
                    break;
                case TextAnchor.LowerLeft:
                    Pivot = Anchor.LowerLeft;
                    break;
                case TextAnchor.LowerCenter:
                    Pivot = Anchor.LowerCenter;
                    break;
                case TextAnchor.LowerRight:
                    Pivot = Anchor.LowerRight;
                    break;
            }
        }
    }
}
