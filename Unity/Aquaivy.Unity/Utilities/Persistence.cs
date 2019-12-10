using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity.Utilities
{
    /// <summary>
    /// 数据持久化工具类
    /// </summary>
    public class Persistence
    {
        /// <summary>
        /// 从Unity的Persistence目录读取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Read<T>(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Write<T>(string key, T t)
        {
            throw new NotImplementedException();
        }
    }
}
