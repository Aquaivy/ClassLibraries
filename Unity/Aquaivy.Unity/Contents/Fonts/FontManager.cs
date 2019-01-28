using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity
{
    public class FontManager
    {
        private static Font font_zh;
        private static Font font_en;
        private static Font defaultFont;

        public static Font Font_zh
        {
            get { return font_zh; }
        }

        public static Font Font_en
        {
            get { return font_en; }
        }

        public static Font DefaultFont
        {
            get { return defaultFont; }
            set { defaultFont = value; }
        }

        public static void Init()
        {
            var arial = Resources.Load<Font>("Arial");
            font_zh = Resources.Load<Font>("Fonts/FZLTH");   //方正兰亭黑
            font_en = Resources.Load<Font>("Fonts/Helvetica");
        }

        public static void SetDefaultFont(Font font) => DefaultFont = font;
    }
}
