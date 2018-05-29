using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 与字符相关的操作类，字符检测，名字模拟等功能
    /// </summary>
    public class Character
    {
        private static CharOperation m_char;
        private static NameSimulation m_name;

        static Character()
        {
            m_char = new CharOperation();
            m_name = new NameSimulation();
        }

        public static CharOperation Char { get { return m_char; } }
        public static NameSimulation Name { get { return m_name; } }
    }
}
