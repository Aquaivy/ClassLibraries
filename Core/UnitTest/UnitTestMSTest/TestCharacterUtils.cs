using Aquaivy.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace TestCore
{
    [TestClass]
    public class TestCharacterUtils
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow('我', 3)]
        public void Test_GetUTF8Length(char c, int len)
        {
            //int length = CharacterUtils.GetUTF8Length(c);
            //Assert.IsTrue(length == len);

            //string str = "汉字我的龍一孑孓竭蹶如果惧怕前面跌宕的山岩，生命就永远只能是死水一潭 懦弱的人只会裹足不前，莽撞的人只能引为烧身，只有真正勇敢的人才能所向披靡";
            //for (int i = 0; i < str.Length; i++)
            //{
            //    char _c = str[i];

            //    TestContext.WriteLine($"{_c}  {CharacterUtils.GetUTF8CharBytesLength(_c)}");
            //}

            string s = "汉字我的龍一孑孓";

            TestContext.WriteLine($"{s}  {EncodingUtils.GetEncodingBytesLength(s, Encoding.BigEndianUnicode)}");
        }


        [DataTestMethod]
        [DataRow("123,_!@#", "\\u0031\\u0032\\u0033\\u002C\\u005F\\u0021\\u0040\\u0023")]
        [DataRow("汉字", "\\u6C49\\u5B57")]
        [DataRow("如果", "\\u5982\\u679C")]
        [DataRow("生命", "\\u751F\\u547D")]
        public void Test_GetUnicode(string str, string unicode)
        {
            TestContext.WriteLine($"{str}  {EncodingUtils.GetUnicode(str)}");
        }

        [DataTestMethod]
        [DataRow("\\u6C49\\u5B57", "汉字")]
        [DataRow("\\u5982\\u679C", "如果")]
        public void Test_UnicodeToString(string unicode, string str)
        {
            TestContext.WriteLine($"{unicode}  {EncodingUtils.UnicodeToString(unicode)}");
        }
    }
}
