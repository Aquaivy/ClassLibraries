using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeywordSearchEngine
{
    public class HashKeywordSearch : IKeywordSearch
    {
        private int m_maxKeywordLenght;   //关键字最大长度
        private HashSet<string> m_keys = new HashSet<string>();

        public HashKeywordSearch()
        {
        }

        public HashKeywordSearch(string[] keywords)
        {
            AddKeywords(keywords);
        }

        /// <summary>
        /// 插入新的Key.
        /// </summary>
        /// <param name="name"></param>
        public void AddKeyword(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                m_keys.Add(key);

                if (key.Length > m_maxKeywordLenght)
                {
                    m_maxKeywordLenght = key.Length;
                }
            }
        }

        public void AddKeywords(string[] keywords)
        {
            foreach (var key in keywords)
            {
                AddKeyword(key);
            }
        }

        /// <summary>
        /// 检查是否包含关键字
        /// </summary>
        /// <param name="text">要检测的文本</param>
        /// <returns>找到的第1个关键字，没有则返回string.Empty</returns>
        public bool ContainAnyKeyword(string text)
        {
            return !string.IsNullOrEmpty(FindFirstKeyword(text));
        }

        /// <summary>
        /// 检查是否包含非法字符
        /// </summary>
        /// <param name="text">输入文本</param>
        /// <returns>找到的第1个非法字符.没有则返回string.Empty</returns>
        public string FindFirstKeyword(string text)
        {
            for (int len = 1; len <= text.Length; len++)
            {
                int maxIndex = text.Length - len;
                for (int index = 0; index <= maxIndex; index++)
                {
                    string key = text.Substring(index, len);
                    if (m_keys.Contains(key))
                    {
                        return key;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 查找包含的所有的关键字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public IEnumerable<string> FindContainKeywords(string text)
        {
            for (int len = 1; len <= text.Length; len++)
            {
                int maxIndex = text.Length - len;
                for (int index = 0; index <= maxIndex; index++)
                {
                    string key = text.Substring(index, len);
                    if (m_keys.Contains(key))
                    {
                        yield return key;
                    }
                }
            }
        }

        /// <summary>
        /// 替换非法字符
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c">用于代替非法字符</param>
        /// <returns>替换后的字符串</returns>

        public string Replace(string text, char c)
        {
            int maxLen = Math.Min(m_maxKeywordLenght, text.Length);
            for (int len = 1; len <= maxLen; len++)
            {
                int maxIndex = text.Length - len;
                for (int index = 0; index <= maxIndex; index++)
                {
                    string key = text.Substring(index, len);
                    if (m_keys.Contains(key))
                    {
                        int keyLen = key.Length;
                        text = text.Replace(key, new string(c, keyLen));
                        index += (keyLen - 1);
                    }
                }
            }

            return text;
        }
    }
}
