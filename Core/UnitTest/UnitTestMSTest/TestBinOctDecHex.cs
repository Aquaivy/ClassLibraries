using Aquaivy.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestMSTest
{
    [TestClass]
    public class TestBinOctDecHex
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow(0, "0")]
        [DataRow(1, "1")]
        [DataRow(2, "10")]
        [DataRow(3, "11")]
        [DataRow(10, "1010")]
        public void Test_Dec2Bin(int dec, string bin)
        {
            string ret = BinOctDecHex.Dec2Bin(dec);
            TestContext.WriteLine($"{dec}  {ret}");
            //Assert.IsTrue(ret == pinyin);
        }


        [DataTestMethod]
        [DataRow(10, "0")]
        public void Test_Dec2OtherNumSystem(int dec, string other)
        {
            string ret = BinOctDecHex.Dec2OtherNumSystem(dec, 3);
            TestContext.WriteLine($"{dec}  {ret}");
            //Assert.IsTrue(ret == pinyin);
        }
    }
}
