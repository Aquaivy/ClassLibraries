using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordSearchEngine
{
    public class TrieNode
    {
        public bool IsLastNode { get; set; } = false;
        public Dictionary<char, TrieNode> Value { get; private set; }

        public TrieNode()
        {
            Value = new Dictionary<char, TrieNode>();
        }
    }

    public class TrieKeywordSearch : TrieNode, IKeywordSearch
    {
        public TrieKeywordSearch()
        {
        }

        public TrieKeywordSearch(string[] keywords)
        {
            AddKeywords(keywords);
        }

        /// <summary>
        /// 添加关键字
        /// </summary>
        /// <param name="key"></param>
        public void AddKeyword(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;

            TrieNode node = this;
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                TrieNode subnode;
                if (!node.Value.TryGetValue(c, out subnode))
                {
                    subnode = new TrieNode();
                    node.Value.Add(c, subnode);
                }
                node = subnode;
            }

            node.IsLastNode = true;
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
            for (int i = 0; i < text.Length; i++)
            {
                TrieNode node;
                if (Value.TryGetValue(text[i], out node))
                {
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if (node.Value.TryGetValue(text[j], out node))
                        {
                            if (node.IsLastNode)
                            {
                                return text.Substring(i, j + 1 - i);
                            }
                        }
                        else
                        {
                            break;
                        }
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
            for (int i = 0; i < text.Length; i++)
            {
                TrieNode node;
                if (Value.TryGetValue(text[i], out node))
                {
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if (node.Value.TryGetValue(text[j], out node))
                        {
                            if (node.IsLastNode)
                            {
                                yield return text.Substring(i, (j + 1 - i));
                            }
                        }
                        else
                        {
                            break;
                        }
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
            char[] chars = null;
            for (int i = 0; i < text.Length; i++)
            {
                TrieNode subnode;
                if (Value.TryGetValue(text[i], out subnode))
                {
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if (subnode.Value.TryGetValue(text[j], out subnode))
                        {
                            if (subnode.IsLastNode)
                            {
                                if (chars == null) chars = text.ToArray();
                                for (int t = i; t <= j; t++)
                                {
                                    chars[t] = c;
                                }
                                i = j;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return chars == null ? text : new string(chars);
        }

    }
}
