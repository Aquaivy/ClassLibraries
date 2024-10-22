﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquaivy.Core.Common
{
    /// <summary>
    /// 线程安全的静态对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class StaticObjectPool<T> where T : new()
    {
        private static readonly ObjectPool<T> pool = new ObjectPool<T>();

        /// <summary>
        /// 内存池请求数据
        /// </summary>
        /// <returns></returns>
        public static T AcquireContent()
        {
            return pool.AcquireContent();
        }

        /// <summary>
        /// 回收内存
        /// </summary>
        /// <param name="contentT"></param>
        public static void ReleaseContent(T contentT)
        {
            pool.ReleaseContent(contentT);
        }
    }
}
