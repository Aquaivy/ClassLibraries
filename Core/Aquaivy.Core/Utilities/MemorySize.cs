using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 用于存储文件大小信息的类。
    /// 8Bit = 1Byte、KB、MB、GB、TB、PB、EB、ZB、YB、DB、NB
    /// 1KB=1024Byte字节
    /// </summary>
    public struct MemorySize
    {
        private long bytes;

        public long Bit { get { return bytes * 8; } }
        public long Byte { get { return bytes; } }

        public const long KB = 1024;
        public const long MB = 1024 * 1024;
        public const long GB = 1024 * 1024 * 1024;
        public const long TB = (long)(1024f * 1024 * 1024 * 1024);        //编译器默认按照int计算，所以在编译阶段超范围了

        public float TotalKBs { get { return bytes * 1f / KB; } }
        public float TotalMBs { get { return bytes * 1f / MB; } }
        public float TotalGBs { get { return bytes * 1f / GB; } }
        public float TotalTBs { get { return bytes * 1f / TB; } }

        public MemorySize(long bytes)
        {
            this.bytes = bytes;
        }

        public string ToString(string format)
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static MemorySize operator +(MemorySize memory1, MemorySize memory2) => new MemorySize(memory1.bytes + memory2.bytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static MemorySize operator -(MemorySize memory1, MemorySize memory2) => new MemorySize(memory1.bytes - memory2.bytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static bool operator ==(MemorySize memory1, MemorySize memory2) => memory1.bytes == memory2.bytes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static bool operator !=(MemorySize memory1, MemorySize memory2) => memory1.bytes != memory2.bytes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static bool operator <(MemorySize memory1, MemorySize memory2) => memory1.bytes < memory2.bytes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static bool operator >(MemorySize memory1, MemorySize memory2) => memory1.bytes > memory2.bytes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static bool operator <=(MemorySize memory1, MemorySize memory2) => memory1.bytes <= memory2.bytes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public static bool operator >=(MemorySize memory1, MemorySize memory2) => memory1.bytes >= memory2.bytes;
    }
}
