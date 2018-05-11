using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Common
{
    /// <summary>
    /// 对象池信息
    /// </summary>
    public struct PoolInfo
    {
        #region zh-CHS 共有属性 | en Public Properties

        /// <summary>
        /// 空闲数量
        /// </summary>
        public long FreeCount { get; internal set; }

        /// <summary>
        /// 申请的数量
        /// </summary>
        public long AcquireCount { get; internal set; }

        /// <summary>
        /// 释放的数量
        /// </summary>
        public long ReleaseCount { get; internal set; }

        /// <summary>
        /// 初始化池数量
        /// </summary>
        public long InitialCapacity { get; internal set; }

        /// <summary>
        /// 当前池数量
        /// </summary>
        public long CurrentCapacity { get; internal set; }

        /// <summary>
        /// 请求失败次数
        /// </summary>
        public long Misses { get; internal set; }

        /// <summary>
        /// 对象池的名字
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 输出当前数据
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} FreeCount={1} CurrentCapacity={2} Misses={3} freerate={4:f3}% AcquireCount={5} ReleaseCount={6}",
                Name, FreeCount, CurrentCapacity, Misses, FreeCount * 100f / CurrentCapacity,
                AcquireCount, ReleaseCount);
        }

        #endregion
    }

}
