using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aquaivy.Pinyin.PinyinMap
{
    /// <summary>
    /// 根据原始关键字文件，生成可用的Map映射表文件。
    /// 一行一个关键字，
    /// 会自动生成类似【hanzi,hz:汉字】这样的结构
    /// </summary>
    public class PinyinMapCreater
    {
        public static void Create(string srcMapPath, string destMapPath)
        {
            if (!File.Exists(srcMapPath))
                throw new FileNotFoundException();

            List<string> destMap = new List<string>();

            //方案一
            //var lines = File.ReadAllLines(srcMapPath, Encoding.UTF8);
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    var line = lines[i];

            //    var pinyin = NPinyin.Pinyin.GetPinyin(line);
            //    var initials = NPinyin.Pinyin.GetInitials(line);

            //    pinyin = pinyin.Replace(" ", "");
            //    initials = initials.ToLower();

            //    destMap.Add($"{pinyin},{initials}:{line}");
            //}

            //方案二
            string line;
            var stream = new FileStream(srcMapPath, FileMode.OpenOrCreate);
            using (StreamReader sr = new StreamReader(stream))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var pinyin = NPinyin.Pinyin.GetPinyin(line);
                    var initials = NPinyin.Pinyin.GetInitials(line);

                    pinyin = pinyin.Replace(" ", "");
                    initials = initials.ToLower();

                    destMap.Add($"{pinyin},{initials}:{line}");
                }
            }
            stream.Dispose();

            File.WriteAllLines(destMapPath, destMap, Encoding.UTF8);
        }
    }
}
