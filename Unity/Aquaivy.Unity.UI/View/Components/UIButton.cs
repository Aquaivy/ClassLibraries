using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class UIButton : Selectable, IImageable, IEnable
    {
        private static readonly Vector3 minScale = new Vector3(0.95f, 0.95f, 1f);

        public Button button { get; set; }
        public Image image { get; set; }
        public UIText text { get; set; }
        //public BoxCollider collider { get; set; }

        public bool IsClickScale { get; set; }

        public UIButton(string imgPath, float x, float y)
           : this(imgPath, x, y, Anchor.MiddleCenter, string.Empty, 20)
        {

        }

        public UIButton(string imgPath, float x, float y, Vector2 pivot)
           : this(imgPath, x, y, pivot, string.Empty, 20)
        {

        }

        public UIButton(string imgPath, float x, float y, string text, int fontsize)
           : this(imgPath, x, y, Anchor.MiddleCenter, text, fontsize)
        {

        }

        public UIButton(string imgPath, float x, float y, Vector2 pivot, string text, int fontsize)
        {
#if UNITY_EDITOR
            Name = "Button";
#endif
            image = gameObject.AddComponent<Image>();
            button = gameObject.AddComponent<Button>();

            SetImage(imgPath);
            SetNativeSize();

            if (!string.IsNullOrEmpty(text))
            {
                this.text = new UIText(text, 0, 0, fontsize, Color.white);
                this.text.Alignment = TextAnchor.MiddleCenter;
                AddChild(this.text);
                this.text.SetToCenter(CenterType.Both);
            }

            this.AnchorMax = this.AnchorMin = Anchor.UpperLeft;
            this.Pivot = pivot;
            SetPosition(x, y);
        }

        public Color Colour
        {
            get { return image.color; }
            set { image.color = value; }
        }

        /// <summary>
        /// 透明度  [0,1]
        /// </summary>
        public float Alpha
        {
            get { return image.color.a; }
            set { image.color = new Color(image.color.r, image.color.g, image.color.b, value); }
        }

        public void SetImage(string imgPath)
        {
            if (string.IsNullOrEmpty(imgPath))
            {
                image.sprite = null;
            }
            else
            {
                image.sprite = TextureManager.CreateSprite(imgPath);
            }
        }

        public void SetNativeSize()
        {
            if (image == null)
                return;

            image.SetNativeSize();
        }


        public bool Enable
        {
            get { return button.enabled; }
            set { button.enabled = value; }
        }

    }
}
