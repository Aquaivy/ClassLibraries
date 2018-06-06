using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public interface IEnable
    {
        bool Enable { get; set; }
    }

    public interface IColorable
    {
        /// <summary>
        /// 避免与Unity的Color结构体发生冲突，这里用Colour
        /// </summary>
        Color Colour { get; set; }
        float Alpha { get; set; }
    }

    /// <summary>
    /// 可有<see cref="Image"/>组件的
    /// </summary>
    public interface IImageable : IColorable
    {
        void SetImage(string imgPath);
        void SetNativeSize();
    }

    /// <summary>
    /// 可有<see cref="Text"/>组件的
    /// </summary>
    public interface ITextable : IColorable
    {
        string Text { get; set; }
        Font Font { get; set; }
        int FontSize { get; set; }
        TextAnchor Alignment { get; set; }
    }

    //interface IColliderResetable
    //{
    //    void ResetCollider();
    //}

    public class AnimationFrameEventArgs : EventArgs
    {
        int Frame;
        string Name { get; set; }
    }

    interface IAnimation
    {
        int TotalFrames { get; set; }
        int CurrentFrame { get; set; }
        float Speed { get; set; }

        void Play();
        void Play(string name);
        void Stop();
        void Stop(string name);
        void Reset();
        void Reset(string name);

        event EventHandler<AnimationFrameEventArgs> OnFrame;
    }
}
