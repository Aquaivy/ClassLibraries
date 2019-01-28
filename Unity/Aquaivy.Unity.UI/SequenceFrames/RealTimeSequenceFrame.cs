using Stark.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class RealTimeSequenceFrame : Graphic, IImageable, ISequenceFrame
    {
        private List<string> frames = new List<string>();
        private bool isPlaying;
        private int rate;
        private int index;
        private int interval;
        private DateTime startPlayTime;
        private TaskLite animationTask;

        public event Action<object> OnPlayedOver;

        public Image image { get; set; }

        public bool AutoSize { get; set; } = true;

        public bool Loop { get; set; } = true;

        public int Index
        {
            get { return index; }
            set { if (value < 0 || value >= frames.Count) return; index = value; }
        }

        public int Rate
        {
            get { return rate; }
            set { rate = value; interval = (int)(1000f / rate); }
        }


        /// <summary>
        /// 
        /// </summary>
        public List<string> FramesPath
        {
            get { return frames; }
            set { frames = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathPattern">形如：Images/Frames_{0:D3}.png 这种格式</param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <param name="rate"></param>
        /// <param name="loop"></param>
        /// <param name="autoSize"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pivot"></param>
        public RealTimeSequenceFrame(string pathPattern, int startIndex, int count, int rate, bool loop, bool autoSize, float x, float y, Vector2 pivot)
        {
#if UNITY_EDITOR
            Name = "SequenceFrame";
#endif

            Rate = rate;
            Loop = loop;
            AutoSize = autoSize;

            image = gameObject.AddComponent<Image>();
            image.raycastTarget = false;

            if (!string.IsNullOrEmpty(pathPattern))
            {
                SetFramesPath(pathPattern, startIndex, count);
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
        /// <param name="pathPattern">形如：Images/Frames_{0:D3}.png 这种格式</param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        public void SetFramesPath(string pathPattern, int startIndex, int count)
        {
            var frames = new List<string>(count);
            for (int i = startIndex; i < startIndex + count; i++)
            {
                frames.Add(string.Format(pathPattern, i));
            }
            //Log.Info($"framesPath  Capacity={framesPath.Capacity}  Count={framesPath.Count}");

            SetFramesPath(frames);
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

            if (AutoSize)
                SetNativeSize();
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
            if (isPlaying)
                return;

            if (gameObject == null || image == null)
            {
                Debug.LogError("SequenceFrame.gameObject is null, or SequenceFrame.image is null");
                return;
            }

            if (frames.Count == 0)
            {
                Debug.LogError("There is no frames, please call \"SetFramesPath()\" first");
                return;
            }

            isPlaying = true;
            startPlayTime = DateTime.Now;
            SetImage(frames[index]);

            animationTask = TaskLite.Invoke(t =>
            {
                if (gameObject == null || image == null)
                {
                    Debug.LogError("SequenceFrame.gameObject is null, or SequenceFrame.image is null");
                    return true;
                }

                var now = DateTime.Now;
                var elapse = (now - startPlayTime).TotalMilliseconds;
                var standardized = elapse % (frames.Count * interval);
                int index = (int)(standardized / interval);
                if (this.index == index)
                    return false;

                this.index = index;
                SetImage(frames[index]);

                if (elapse >= frames.Count * interval
                    && !Loop)
                {
                    OnPlayedOver?.Invoke(Tag);
                    return true;
                }

                return false;
            });
        }

        public void Pause()
        {
            animationTask?.Release();
            animationTask = null;
            isPlaying = false;
        }

        public void Stop()
        {
            animationTask?.Release();
            animationTask = null;
            isPlaying = false;
            index = 0;
        }

        public void SkipToFirstFrame()
        {
            Stop();
            SetImage(frames[0]);
            index = 0;
        }

        public void SkipToLastFrame()
        {
            Stop();
            SetImage(frames[frames.Count - 1]);
            index = frames.Count - 1;
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
            set
            {
                if (image != null)
                    image.color = new Color(image.color.r, image.color.g, image.color.b, value);
            }
        }


    }
}
