using Aquaivy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Common
{
    /// <summary>
    /// 带单例模式的对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StaticInstanceObjectPool<T> where T : new()
    {
        private readonly ObjectPool<T> instance = new ObjectPool<T>(8);

        /// <summary>
        /// 单例模式
        /// </summary>
        public ObjectPool<T> Instatnce
        {
            get { return instance; }
        }
    }
}
