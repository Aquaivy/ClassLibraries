using BoomTown.FuzzySharp;
using BoomTown.FuzzySharp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch
{
    public static class FuzzySearchController
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

        public static void ExtractTopAsync(string query, string[] choices, int limit, Action<List<ExtractedResult>> results)
        {
            Task.Run(() =>
            {
                Extractor _extractor = new Extractor();
                var _results = _extractor.ExtractTop(query, choices, limit).ToList();
                results?.Invoke(_results);
            });
        }
    }
}
