using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSE.Library.Common
{
    /// <summary>
    /// 对象池信息
    /// </summary>
    public interface IPoolInfo
    {
        /// <summary>
        /// 对象池的名字
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获得对象池信息
        /// </summary>
        /// <returns></returns>
        PoolInfo GetPoolInfo();
    }
}
