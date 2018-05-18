using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{


    public class NameSimulation
    {
        /// <summary>
        /// 随机一个中文名字。
        /// 2-3个汉字，小概率4个汉字
        /// </summary>
        /// <returns></returns>
        public static string GetRandomChineseName(ChineseNameSetting setting)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 随机给定数量个中文名字。
        /// 2-3个汉字，小概率4个汉字
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetRandomChineseNames(ChineseNameSetting setting, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 随机一个英文名字。
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string GetRandomEnglishName(EnglishNameSetting setting)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 随机给定数量个英文名字。
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetRandomEnglishNames(EnglishNameSetting setting, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chineseSetting"></param>
        /// <param name="englishSetting"></param>
        /// <param name="chineseWeighet"></param>
        /// <param name="englishWeidget"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetRandomNames(ChineseNameSetting chineseSetting, EnglishNameSetting englishSetting, uint chineseWeighet, uint englishWeidget, int count)
        {
            throw new NotImplementedException();
        }
    }
}
