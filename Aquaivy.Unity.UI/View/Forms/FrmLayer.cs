using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquaivy.Unity.UI
{
    /// <summary>
    /// 窗体层级
    /// </summary>
    public enum FrmLayer
    {
        /// <summary>
        /// 底板窗体
        /// </summary>
        Background = 0,

        /// <summary>
        /// 用户自定义窗体
        /// </summary>
        Custom,

        /// <summary>
        /// 弹出窗（弹出效果）
        /// </summary>
        Popup,

        /// <summary>
        /// 顶部、底部窗体
        /// </summary>
        Banner,

        /// <summary>
        /// 特效
        /// </summary>
        Effect
    }
}
