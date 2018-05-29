using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 随机名字
    /// </summary>
    public class NameSimulation
    {
        private static Random random = new Random();

        /// <summary>
        /// 返回一个中文姓氏
        /// （5%的概率返回2个字的复姓）
        /// </summary>
        /// <returns></returns>
        public static string GetRandomChineseFamilyName(bool useCompoundFamily)
        {
            string family = string.Empty;
            if (useCompoundFamily && random.Next(100) < 5)
            {
                family = ChineseNameLibrary.CompoundFamily[random.Next(ChineseNameLibrary.CompoundFamilyLength)];
            }
            else
            {
                family = ChineseNameLibrary.Family[random.Next(ChineseNameLibrary.FamilyLength)];
            }

            return family;
        }

        /// <summary>
        /// 返回一个中文名
        /// （不包含姓，5%概率出现叠名）
        /// </summary>
        /// <returns></returns>
        public static string GetRandomChinesePersonalName(int length)
        {
            if (length < 0)
                return string.Empty;

            string name = string.Empty;
            if (length == 2 && random.Next(100) < 5)
            {
                //5%的概率使用叠词 ^_^
                name = ChineseNameLibrary.Common[random.Next(ChineseNameLibrary.CommonLength)].ToString();
                name += name;
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    name += ChineseNameLibrary.Common[random.Next(ChineseNameLibrary.CommonLength)].ToString();
                }
            }

            return name;
        }

        /// <summary>
        /// 随机一个中文名字。
        /// 2-3个汉字，小概率4个汉字
        /// </summary>
        /// <returns></returns>
        public static string GetRandomChineseName(ChineseNameSetting setting)
        {
            int sum = setting.LengthWeight.Sum();
            int rnd = random.Next(sum);
            int wordLength = 0;
            for (int i = 0, tmp = 0; i < setting.LengthWeight.Length; i++)
            {
                tmp += setting.LengthWeight[i];
                if (rnd < tmp)
                {
                    wordLength = i;
                    break;
                }
            }

            //上面算出来是区间索引，所以这里要+1，变成真正的字数
            wordLength++;

            string familay = GetRandomChineseFamilyName(wordLength > 2);
            string personal = GetRandomChinesePersonalName(wordLength - familay.Length);
            string name = familay + personal;
            if (name.Length > wordLength)
            {
                name = name.Substring(0, wordLength);
            }

            return name;
        }

        /// <summary>
        /// 随机给定数量个中文名字。
        /// 2-3个汉字，小概率4个汉字
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<string> GetRandomChineseNames(ChineseNameSetting setting, int count)
        {
            if (count <= 0)
                throw new ArgumentException();

            var lst = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                lst.Add(GetRandomChineseName(setting));
            }

            return lst;
        }

        /// <summary>
        /// 随机一个英文名字。
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string GetRandomEnglishName(EnglishNameSetting setting)
        {
            string name = EnglishNameLibrary.FirstName[random.Next(EnglishNameLibrary.FirstNameLength)];
            return name;
        }

        /// <summary>
        /// 随机给定数量个英文名字。
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<string> GetRandomEnglishNames(EnglishNameSetting setting, int count)
        {
            if (count <= 0)
                throw new ArgumentException();

            var lst = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                lst.Add(GetRandomEnglishName(setting));
            }

            return lst;
        }

    }
}
