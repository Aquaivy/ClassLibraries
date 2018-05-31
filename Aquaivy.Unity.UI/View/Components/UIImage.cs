using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class UIImage : Graphic, IImageable
    {
        public Image image { get; set; }

#if IMPERFECTION
        public UIImage(GameObject go)
            : base(go)
        {
            image = go.GetComponent<Image>();
            if (image == null)
                image = go.AddComponent<Image>();
        }
#endif

        public UIImage(string imgPath, float x, float y)
            : this(imgPath, x, y, Anchor.UpperLeft)
        {

        }

        public UIImage(string imgPath, float x, float y, Vector2 pivot)
        {
#if UNITY_EDITOR
            Name = "Image";
#endif

            image = gameObject.AddComponent<Image>();
            image.raycastTarget = false;

            SetImage(imgPath);
            SetNativeSize();
            this.Pivot = pivot;
            SetPosition(x, y);
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

        public override Color Colour
        {
            get { return image.color; }
            set { image.color = value; }
        }

        /// <summary>
        /// 图片透明度  [0,1]
        /// </summary>
        public override float Alpha
        {
            get { return image.color.a; }
            set { image.color = new Color(image.color.r, image.color.g, image.color.b, value); }
        }


        #region 裁剪sprite透明边框的pivot设置方式

        //private Vector2 _pivot = UIUtils.UpperLeft;
        //public override Vector2 Pivot
        //{
        //    get { return _pivot; }
        //    set
        //    {
        //        _pivot = value;

        //        if (spriteWrap == null || spriteWrap.sample == null)
        //        {
        //            base.Pivot = value;
        //            return;
        //        }

        //        var sample = spriteWrap.sample;

        //        float pivot_zero_x = (-sample.offset.x / sample.size.x);            //原始sprite以左上角为(0,0)时的pivot.x
        //        float pivot_zero_y = 1 - (-sample.offset.y / sample.size.y);        //原始sprite以左上角为(0,0)时的pivot.y

        //        float pivot_x = pivot_zero_x + (sample.sourceSize.x / sample.size.x * value.x);
        //        float pivot_y = pivot_zero_y - (sample.sourceSize.y / sample.size.y * (1 - value.y));

        //        //_pivot = new Vector2(pivot_x, pivot_y);
        //        //rt.pivot = _pivot;
        //        base.Pivot = new Vector2(pivot_x, pivot_y);
        //    }
        //}

        #endregion
    }
}
