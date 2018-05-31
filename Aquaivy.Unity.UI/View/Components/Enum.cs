using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquaivy.Unity.UI
{
    /// <summary>
    /// 居中方式
    /// </summary>
    /// <remarks>必然处于父物体的正中，此枚举用于设置物体自身的 Anchor 和 Pivot </remarks>
    public enum CenterType
    {
        OnlyPosition,
        Both,
    }

    public enum Layout
    {
        Horizontal,
        Vertical,
        Grid
    }
}
