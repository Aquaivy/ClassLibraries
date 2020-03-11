using Aquaivy.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestMSTest
{
    [TestClass]
    public class TestFileUtility
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow(@"..\..\..\PinyinMapSource.txt")]
        public void Test_GetLineEnding(string path)
        {
            FileUtility.SetFileLineEndings(path, Encoding.UTF8, LineEnding.CRLF);
            //TestContext.WriteLine($"{dec}  {ret}");
            //Assert.IsTrue(ret == pinyin);
        }
    }
}
