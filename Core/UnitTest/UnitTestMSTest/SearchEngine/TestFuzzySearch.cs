using Aquaivy.Core.Utilities;
using Aquaivy.SearchEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestMSTest
{
    [TestClass]
    public class TestFuzzySearch
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow(@"..\..\..\PinyinMapSource.txt")]
        public void Test_ExtractTopAsync(string path)
        {
            string query = "1000kV2号主变T02317接地闸刀";
            string[] choices = new string[] {
                "110kV72号电容器1172电抗器A相本体",
                "110kV72号电容器1172电抗器A相接地刀闸侧接头",
                "110kV72号电容器1172电抗器A相开关侧接头",
                "110kV72号电容器1172电抗器B相本体",
                "110kV72号电容器1172电抗器B相接地刀闸侧接头",
            };

            //string defect = @"E:\defect.json";
            //FuzzySearchController.LoadChoicesFileAsync(defect, ret => { choices = ret; });

            FuzzySearchController.ExtractTopAsync(query, choices, 5, results =>
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
