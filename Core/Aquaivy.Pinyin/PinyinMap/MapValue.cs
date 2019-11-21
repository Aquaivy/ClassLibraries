using System;
using System.Collections.Generic;
using System.Text;

namespace Aquaivy.Pinyin.PinyinMap
{
    public class MapValue
    {
        public List<string> Values { get; } = new List<string>();

        public void Add(string value)
        {
            if (Values.Contains(value))
                return;

            Values.Add(value);
        }

        public void Remove(string value)
        {
            //if (!Values.Contains(value))
            //    return;

            Values.Remove(value);
        }
    }
}
