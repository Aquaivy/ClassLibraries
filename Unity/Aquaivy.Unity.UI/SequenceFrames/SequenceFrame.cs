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
        private bool isPlaying;
        private int rate;
        private int index;
        private int interval;
        private DateTime lastFrameTime;
        private TaskLite animationTask;

        public object Tag;
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
            set { rate = value; interval = 1000 / rate; }
        }


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

            Rate = rate;
            Loop = loop;
            AutoSize = autoSize;

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

            if (AutoSize)
                image.SetNativeSize();
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
            lastFrameTime = DateTime.Now;
            SetImage(frames[index]);

            animationTask = TaskLite.Invoke(t =>
            {
                if (gameObject == null || image == null)
                {
                    Debug.LogError("SequenceFrame.gameObject is null, or SequenceFrame.image is null");
                    return true;
                }

                if ((DateTime.Now - lastFrameTime).TotalMilliseconds < interval)
                    return false;

                lastFrameTime = DateTime.Now;
                index++;

                if (index >= frames.Count)
                {
                    index = 0;
                    if (!Loop)
                    {
                        OnPlayedOver?.Invoke(Tag);
                        return true;
                    }
                }

                SetImage(frames[index]);

                return false;

                //if (index < frames.Count)
                //{
                //    SetImage(frames[index]);

                //    //最后一个
                //    if (index == frames.Count - 1)
                //    {

                //    }


                //    return false;
                //}
                //else
                //{
                //    index = 0;
                //    if (Loop)
                //    {
                //        return false;
                //    }
                //    else
                //    {
                //        OnPlayedOver?.Invoke(Tag);
                //        return true;
                //    }
                //}
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
            set { image.color = new Color(image.color.r, image.color.g, image.color.b, value); }
        }


    }
}
