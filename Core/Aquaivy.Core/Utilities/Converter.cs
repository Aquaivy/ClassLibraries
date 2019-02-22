using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryToList<T>(List<string> list, out List<T> result) where T : struct
        {
            result = new List<T>();

            try
            {
                foreach (var item in list)
                {
                    T t = default(T);
                    t = (T)Convert.ChangeType(item, typeof(T));
                    result.Add(t);
                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryToList<T>(List<T> list, out List<string> result) where T : struct
        {
            result = new List<string>();

            try
            {
                foreach (var item in list)
                {
                    string s = Convert.ChangeType(item, typeof(String)) as string;
                    result.Add(s);
                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }


    }
}
