using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Library.Util
{
    /// <summary>
    /// 用于存储文件大小信息的类。
    /// 8Bit = 1Byte、KB、MB、GB、TB、PB、EB、ZB、YB、DB、NB
    /// 1KB=1024Byte字节
    /// </summary>
    public struct ByteSize
    {
        private ulong bytes;

        public ulong Bit { get { return bytes * 8; } }
        public ulong Byte { get { return bytes; } }

        public const ulong KB = 1024;
        public const ulong MB = 1024 * 1024;
        public const ulong GB = 1024 * 1024 * 1024;
        public const ulong TB = (ulong)(1024f * 1024 * 1024 * 1024);        //编译器默认按照int计算，所以在编译阶段超范围了

        public float TotalKBs { get { return bytes * 1f / KB; } }
        public float TotalMBs { get { return bytes * 1f / MB; } }
        public float TotalGBs { get { return bytes * 1f / GB; } }
        public float TotalTBs { get { return bytes * 1f / TB; } }

        public ByteSize(ulong bytes)
        {
            this.bytes = bytes;
        }

        public string ToString(string format)
        {
            return "";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static ByteSize operator +(ByteSize f1, ByteSize f2) => new ByteSize(f1.bytes + f2.bytes);
        public static ByteSize operator -(ByteSize f1, ByteSize f2) => new ByteSize(f1.bytes - f2.bytes);
        public static bool operator ==(ByteSize f1, ByteSize f2) => f1.bytes == f2.bytes;
        public static bool operator !=(ByteSize f1, ByteSize f2) => f1.bytes != f2.bytes;
        public static bool operator <(ByteSize f1, ByteSize f2) => f1.bytes < f2.bytes;
        public static bool operator >(ByteSize f1, ByteSize f2) => f1.bytes > f2.bytes;
        public static bool operator <=(ByteSize f1, ByteSize f2) => f1.bytes <= f2.bytes;
        public static bool operator >=(ByteSize f1, ByteSize f2) => f1.bytes >= f2.bytes;
    }
}
