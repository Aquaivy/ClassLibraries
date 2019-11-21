using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 字符类型
    /// </summary>
    [Flags]    
    public enum CharacterType
    {
        /// <summary>
        /// 小写字母
        /// </summary>
        AlphabetLower,

        /// <summary>
        /// 大写字母
        /// </summary>
        AlphabetUpper,

        /// <summary>
        /// 数字
        /// </summary>
        Number,

        /// <summary>
        /// 下划线
        /// </summary>
        UnderLine,

        /// <summary>
        /// 符号，包含  `~!@#$%^&*()-+=[]{}|\/;:'",.<>?*.
        /// 共33个
        /// </summary>
        Symbol,

        /// <summary>
        /// 其他字符
        /// </summary>
        Others,
    }
}
