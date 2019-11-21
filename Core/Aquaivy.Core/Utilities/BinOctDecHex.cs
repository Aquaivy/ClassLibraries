using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 进制转换
    /// </summary>
    /// 
    /// <remarks>
    /// BIN     二进制     binary
    /// OCT     八进制     octonary
    /// DEC     十进制     decimalism
    /// HEX     十六进制   hexadecimal
    /// </remarks>
    public static class BinOctDecHex
    {
        /// <summary>
        /// 10进制转2进制
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string Dec2Bin(int dec) => Convert.ToString(dec, 2);

        /// <summary>
        /// 10进制转8进制
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string Dec2Oct(int dec) => Convert.ToString(dec, 8);

        /// <summary>
        /// 10进制转16进制
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string Dec2Hex(int dec) => Convert.ToString(dec, 16);

        /// <summary>
        /// 【只能转2/8/10/16这4种进制】10进制转其他进制
        /// </summary>
        /// <param name="dec"></param>
        /// <param name="toNumSystem"></param>
        /// <returns></returns>
        //public static string Dec2OtherNumSystem(int dec, int toNumSystem) => Convert.ToString(dec, toNumSystem);



        /// <summary>
        /// 2进制转10进制
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static int Bin2Dec(string bin) => Convert.ToInt32(bin, 2);

        /// <summary>
        /// 8进制转10进制
        /// </summary>
        /// <param name="oct"></param>
        /// <returns></returns>
        public static int Oct2Dec(string oct) => Convert.ToInt32(oct, 8);

        /// <summary>
        /// 16进制转10进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int Hex2Dec(string hex) => Convert.ToInt32(hex, 16);

        /// <summary>
        /// 【只能转2/8/10/16这4种进制】其他进制转10进制
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromNumSystem"></param>
        /// <returns></returns>
        //public static int OtherNumSystem2Dec(string value, int fromNumSystem) => Convert.ToInt32(value, fromNumSystem);
    }
}
