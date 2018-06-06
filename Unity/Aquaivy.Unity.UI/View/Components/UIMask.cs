using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class UIMask : UIElement, IImageable, IEnable
    {
        public Image image { get; set; }
        public Mask mask { get; set; }

#if IMPERFECTION
        public UIMask(GameObject go)
            : base(go)
        {
            mask = go.GetComponent<Mask>();
            if (mask == null)
                mask = go.AddComponent<Mask>();
        }
#endif

        public UIMask(float x, float y, float width, float height)
            : this(x, y, width, height, true)
        {
        }

        public UIMask(float x, float y, float width, float height, bool showGraphic)
        {
#if UNITY_EDITOR
            Name = "Mask";
#endif

            image = gameObject.AddComponent<Image>();
            mask = gameObject.AddComponent<Mask>();

            SetPosition(x, y);
            Size = new Vector2(width, height);
            ShowGraphic = showGraphic;
        }

        public bool ShowGraphic
        {
            get { return mask.showMaskGraphic; }
            set { mask.showMaskGraphic = value; }
        }

        public bool Enable
        {
            get { return mask.enabled; }
            set { mask.enabled = value; }
        }

        public Color Colour
        {
            get { return image.color; }
            set { image.color = value; }
        }

        /// <summary>
        /// 图片透明度  [0,1]
        /// </summary>
        public float Alpha
        {
            get { return image.color.a; }
            set { image.color = new Color(image.color.r, image.color.g, image.color.b, value); }
        }

        /// <summary>
        /// 从Resources下读取文件，创建一个Sprite.
        /// 不要添加".png"
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
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
            if (image != null)
            {
                image.SetNativeSize();
            }
        }
    }
}
