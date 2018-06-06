using Aquaivy.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class SequenceFrame : Graphic, IImageable, ISequenceFrame
    {
        private List<string> frames = new List<string>();

        public Image image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> FramesPath
        {
            get { return frames; }
            set { frames = value; }
        }

        public SequenceFrame(string pathPattern, int startIndex, int endIndex, int rate, bool loop, bool autoSize, float x, float y, Vector2 pivot)
        {
#if UNITY_EDITOR
            Name = "SequenceFrame";
#endif

            image = gameObject.AddComponent<Image>();
            image.raycastTarget = false;

            if (!string.IsNullOrEmpty(pathPattern))
            {
                SetFramesPath(pathPattern, startIndex, endIndex);
                SetImage(frames[0]);
                SetNativeSize();
            }
            this.Pivot = pivot;
            SetPosition(x, y);
        }

        /// <summary>
        /// 设置序列帧图片，
        /// pathPattern应形如：Images/Frames_{0:D3}.png 这种格式，
        /// 则会检测 Images/Frames_001.png,Images/Frames_002.png这样的图片
        /// </summary>
        /// <param name="pathPattern"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public void SetFramesPath(string pathPattern, int startIndex, int endIndex)
        {
            SetFramesPath(pathPattern, startIndex, endIndex, 1);
        }

        public void SetFramesPath(string pathPattern, int startIndex, int endIndex, int interval)
        {
            if (interval < 1)
            {
                Log.Warn("SequenceFrame.SetFramesPath(), interval must >=1");
                interval = 1;
            }

            var framesPath = new List<string>((endIndex - startIndex) / interval + 1);
            for (int i = startIndex; i <= endIndex; i += interval)
            {
                framesPath.Add(string.Format(pathPattern, i));
            }
            //Log.Info($"framesPath  Capacity={framesPath.Capacity}  Count={framesPath.Count}");

            SetFramesPath(framesPath);
        }

        public void SetFramesPath(List<string> framesPath)
        {
            frames = framesPath;
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
            if (image != null)
            {
                image.SetNativeSize();
            }
        }

        public void Play()
        {

        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }

        public void SkipToFirstFrame()
        {
            Stop();
            SetImage(frames[0]);
        }

        public void SkipToLastFrame()
        {
            Stop();
            SetImage(frames[frames.Count - 1]);
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

        public int Index { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Rate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Loop { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
