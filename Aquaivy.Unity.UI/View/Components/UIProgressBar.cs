using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public delegate void ValueChanged(UIElement sender, float value);

    public class UIProgressBar : UIElement
    {
        public Image Background { get; private set; }
        public UIImage Progress { get; private set; }
        public UINode Head { get; private set; }
        public event ValueChanged OnValueChanged;

        private float progressValue = 0f;

        public UIProgressBar(string imgBackground, string imgProgress, float x, float y)
        {
#if UNITY_EDITOR
            Name = "UIProgressBar";
#endif
            Background = gameObject.AddComponent<Image>();
            SetBackground(imgBackground);
            Background.SetNativeSize();

            Progress = new UIImage(imgProgress, 0, 0);
            Progress.image.type = Image.Type.Filled;
            Progress.image.fillMethod = Image.FillMethod.Horizontal;
            this.AddChild(Progress);
            Progress.SetToCenter(CenterType.OnlyPosition);

            Head = new UINode();
            Head.SetSize(Progress.Height, Progress.Height);
            Head.y = Progress.HarfHeight;
            Head.Pivot = Anchor.MiddleCenter;
            Progress.AddChild(Head);

            SetPosition(x, y);

            Value = 1f;
        }

        public float Value
        {
            get { return progressValue; }
            set
            {
                if (value == progressValue)
                    return;

                value = Mathf.Clamp01(value);

                progressValue = value;
                Progress.image.fillAmount = value;
                Head.x = Progress.Width * value;

                if (OnValueChanged != null)
                    OnValueChanged(this, value);
            }
        }

        public void SetBackground(string imgPath)
        {
            if (string.IsNullOrEmpty(imgPath))
            {
                Background.sprite = null;
            }
            else
            {
                Background.sprite = TextureManager.CreateSprite(imgPath);
            }
        }
    }

}
