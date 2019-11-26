using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aquaivy.Pinyin.PinyinMap
{
    /// <summary>
    /// pinyin和汉字的对应表控制器，用于快速检索pinyin所对应的汉字
    /// </summary>
    public class PinyinMapController
    {
        private static Dictionary<string, MapValue> s_map = new Dictionary<string, MapValue>();

        /// <summary>
        /// 加载映射文件
        /// 
        /// 需要是如下结构
        /// hanzi,hz:汉字
        /// yingshe,ys:映射
        /// </summary>
        /// <param name="path"></param>
        public void LoadMapFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            //方案一
            //var lines = File.ReadAllLines(path, Encoding.UTF8);
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    var line = lines[i];

            //    var array = line.Split(':');
            //    if (array.Length != 2)
            //        throw new Exception("Pinyin映射文件配置错误，解析失败");

            //    var pinyin = array[0];
            //    var hanzi = array[1];

            //    var keys = pinyin.Split(',');
            //    for (int k = 0; k < keys.Length; k++)
            //    {
            //        var key = keys[k];
            //        if (!s_map.TryGetValue(key, out MapValue map))
            //            map = new MapValue();

            //        map.Add(hanzi);

            //        s_map[key] = map;
            //    }
            //}

            //方案二
            string line;
            var stream = new FileStream(path, FileMode.OpenOrCreate);
            using (StreamReader sr = new StreamReader(stream))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var array = line.Split(':');
                    if (array.Length != 2)
                        throw new Exception("Pinyin映射文件配置错误，解析失败");

                    var pinyin = array[0];
                    var hanzi = array[1];

                    var keys = pinyin.Split(',');
                    for (int k = 0; k < keys.Length; k++)
                    {
                        var key = keys[k];
                        if (!s_map.TryGetValue(key, out MapValue map))
                            map = new MapValue();

                        map.Add(hanzi);

                        s_map[key] = map;
                    }
                }
            }
            stream.Dispose();
        }

        public void SetMap(Dictionary<string, MapValue> map)
        {
            s_map = map;
        }

        /// <summary>
        /// 查询指定pinyin的关键字
        /// </summary>
        /// <param name="pinyin"></param>
        /// <returns></returns>
        public MapValue Query(string pinyin)
        {
            if (!s_map.TryGetValue(pinyin, out MapValue map))
            {
                return null;
            }

            return map;
        }
    }
}
