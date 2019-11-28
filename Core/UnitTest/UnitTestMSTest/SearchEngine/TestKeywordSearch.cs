using Aquaivy.Core.Utilities;
using Aquaivy.SearchEngine;
using KeywordSearchEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestMSTest
{
    [TestClass]
    public class TestKeywordSearch
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow(@"..\..\..\PinyinMapSource.txt")]
        public void Test_ExtractTopAsync(string path)
        {
            string[] query = new string[] {
                "电容器",
                "电抗器",
                "本体",
                "A相",
            };
            string[] choices = new string[] {
                "110kV72号电容器1172电抗器A相本体",
                "110kV72号电容器1172电抗器A相接地刀闸侧接头",
                "110kV72号电容器1172电抗器A相开关侧接头",
                "110kV72号电容器1172电抗器B相本体",
                "110kV72号电容器1172电抗器B相接地刀闸侧接头",
            };

            string defect = @"E:\defect.json";
            TrieKeywordSearchController.LoadChoicesFileAsync(defect, ret => { choices = ret; });

            TrieKeywordSearchController.ExtractTopAsync(query, choices, 5, results =>
            {
                foreach (var item in results)
                {
                    TestContext.WriteLine($"{item.Score}  {item.Value}");
                }
            });
            //TestContext.WriteLine($"{dec}  {ret}");
            //Assert.IsTrue(ret == pinyin);
        }
    }
}
