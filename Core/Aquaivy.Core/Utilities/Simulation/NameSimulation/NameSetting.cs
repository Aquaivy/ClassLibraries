using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 名称设置
    /// </summary>
    public class NameSetting
    {
        //private int minLength;
        //private int maxLength;

        ///// <summary>
        ///// 最少名字数量，最小为1
        ///// </summary>
        //public int MinLength
        //{
        //    get => minLength;
        //    set { if (value < 1) return; minLength = value; }
        //}

        ///// <summary>
        ///// 最多名字数量，最小为1
        ///// </summary>
        //public int MaxLength
        //{
        //    get => maxLength;
        //    set { if (value < 1) return; maxLength = value; }
        //}

        /// <summary>
        /// 是否允许使用特殊字符
        /// </summary>
        public bool CanUseSpecialChar;

        /// <summary>
        /// 名字字符个数权重，权重越大，该个数的名字数量越多。
        /// 如：{0,100,100,10}
        /// 表示：
        ///     0%的可能性是1个字，
        ///     100/210的可能性是2个字
        ///     100/210的可能性是3个字
        ///     10/210的可能性是4个字
        /// </summary>
        public int[] LengthWeight;

    }

    /// <summary>
    /// 中文名称设置
    /// </summary>
    public class ChineseNameSetting : NameSetting
    {
        private static ChineseNameSetting defaultSetting;
        public static ChineseNameSetting Default
        {
            get
            {
                if (defaultSetting == null)
                {
                    defaultSetting = new ChineseNameSetting
                    {
                        //MinLength = 2,
                        //MaxLength = 4,
                        CanUseSpecialChar = false,
                        LengthWeight = new int[] { 0, 100, 100, 10 }
                    };
                }

                return defaultSetting;
            }
        }
    }

    /// <summary>
    /// 英文名称设置
    /// </summary>
    public class EnglishNameSetting : NameSetting
    {
        private static EnglishNameSetting defaultSetting;
        public static EnglishNameSetting Default
        {
            get
            {
                if (defaultSetting == null)
                {
                    defaultSetting = new EnglishNameSetting
                    {
                        CanUseSpecialChar = false,
                    };
                }

                return defaultSetting;
            }
        }

        /// <summary>
        /// 英文名称中的“姓”是否写在前边（左边）
        /// </summary>
        public bool LastNameInFront = true;

        /// <summary>
        /// 是否使用中文“姓”
        /// </summary>
        public bool UseChineseFamilyName = true;
    }
}


