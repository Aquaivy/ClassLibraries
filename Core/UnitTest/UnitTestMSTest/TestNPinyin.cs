using Aquaivy.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPinyin;

namespace TestCore
{
    [TestClass]
    public class TestNPinyin
    {
        [DataTestMethod]
        [DataRow("我", "W")]
        [DataRow("炉甘石洗剂", "LGSXJ")]
        [DataRow("红霉素软膏", "HMSRG")]
        public void Test_Initials(string hanzi, string pinyin)
        {
            string converted = Pinyin.GetInitials(hanzi);
            Assert.IsTrue(converted == pinyin);
        }

        [DataTestMethod]
        [DataRow("我", "wo")]
        [DataRow("事常与人违，事总在人为", "shi chang yu ren wei ， shi zong zai ren wei")]
        [DataRow("骏马是跑出来的，强兵是打出来的", "jun ma shi pao chu lai de ， qiang bing shi da chu lai de")]
        public void Test_GetPinyin(string hanzi, string pinyin)
        {
            string converted = Pinyin.GetPinyin(hanzi);
            Assert.IsTrue(converted == pinyin);
        }

        [DataTestMethod]
        [DataRow("ai", "爱埃碍矮挨唉哎哀皑癌蔼艾隘捱嗳嗌嫒瑷暧砹锿霭")]
        [DataRow("shi", "是时十使事实式识世试石什示市史师始施士势湿适食失视室氏蚀诗释拾饰驶狮尸虱矢屎柿拭誓逝嗜噬仕侍恃谥埘莳蓍弑轼贳炻铈螫舐筮酾豕鲥鲺")]
        public void Test_GetChineseText(string pinyin, string hanzi)
        {
            string converted = Pinyin.GetChineseText(pinyin);
            Assert.IsTrue(converted == hanzi);
        }
    }
}
