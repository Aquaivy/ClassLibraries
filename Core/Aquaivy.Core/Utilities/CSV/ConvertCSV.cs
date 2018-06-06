using System;
using System.Collections.Generic;
using System.Text;

namespace DogSE.Library.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConvertCSV
    {

        private static readonly char[] CSVSplit = { ',' };

        /// <summary>
        /// 将 1,2,3 转换为字符串数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] ToCSVSplit(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return new string[0];

            return str.Split(CSVSplit, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 将 1,2,3 转换为字符串数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int[] ToCSVSplitToInt(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return new int[0];

            var arr = str.Split(CSVSplit, StringSplitOptions.RemoveEmptyEntries);
            var ret = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                ret[i] = int.Parse(arr[i]);

            return ret;
        }

        /// <summary>
        /// 将字符串列表转为csv格式数据
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertToCSV(this List<string> array)
        {
            if (array == null || array.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder(array.Count * 5);

            foreach (var str in array)
            {
                sb.Append(str);
                sb.Append(',');
            }

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        /// <summary>
        /// 将字符串列表转为csv格式数据
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertToCSV(this List<int> array)
        {
            if (array == null || array.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder(array.Count * 5);

            foreach (var str in array)
            {
                sb.Append(str);
                sb.Append(',');
            }

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        /// <summary>
        /// 将字符串列表转为csv格式数据
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ConvertToCSV(this int[] array)
        {
            if (array == null || array.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder(array.Length * 5);

            foreach (var str in array)
            {
                sb.Append(str);
                sb.Append(',');
            }

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
