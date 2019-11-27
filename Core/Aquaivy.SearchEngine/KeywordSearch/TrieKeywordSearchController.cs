using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearchEngine
{
    /// <summary>
    /// Trie结构关键字搜索Controller
    /// </summary>
    public static class TrieKeywordSearchController
    {
        public static void LoadChoicesFileAsync(string path, Action<string[]> loaded)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            Task.Run(() =>
            {
                string[] _choices = File.ReadAllLines(path);
                loaded?.Invoke(_choices);
            });
        }

        public static void ExtractTopAsync(string[] keywords, string[] choices, int limit, Action<List<ExtractedResult>> results)
        {
            Task.Run(() =>
            {
                var trie = new TrieKeywordSearch(keywords);

                var extracted = new List<ExtractedResult>();

                foreach (var choice in choices)
                {
                    var score = trie.FindContainKeywords(choice).Count();
                    extracted.Add(new ExtractedResult { Score = score, Value = choice });
                }

                extracted = extracted.OrderByDescending(x => x.Score).Take(limit).ToList();

                results?.Invoke(extracted);
            });
        }
    }
}
