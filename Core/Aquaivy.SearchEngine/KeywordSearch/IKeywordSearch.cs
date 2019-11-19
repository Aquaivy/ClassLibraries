using System;
using System.Collections.Generic;
using System.Text;

namespace KeywordSearchEngine
{
    public interface IKeywordSearch
    {
        void AddKeyword(string keyword);
        void AddKeywords(string[] keywords);
        bool ContainAnyKeyword(string text);
        string FindFirstKeyword(string text);
        IEnumerable<string> FindContainKeywords(string text);
    }
}
