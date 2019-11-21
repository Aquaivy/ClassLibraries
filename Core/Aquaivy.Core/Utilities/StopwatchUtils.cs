using Aquaivy.Core.Logs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// Stopwatch工具类，可以直接使用Stopwatch而不用创建
    /// </summary>
    /// 
    /// <remarks>
    ///  连续获取2次Stopwatch的如下属性：
    ///  Elapsed                   值不同
    ///  ElapsedTicks              值不同
    ///  ElapsedMilliseconds       值可能相同
    /// </remarks>

    public static class StopwatchUtils
    {
        private static Dictionary<string, Stopwatch> s_stopwatches = new Dictionary<string, Stopwatch>();

        /// <summary>
        /// 开始或继续测量某个时间间隔的运行时间
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Start(string stopwatch)
        {
            if (s_stopwatches.TryGetValue(stopwatch, out Stopwatch sw))
            {
                sw.Start();
            }
            else
            {
                sw = new Stopwatch();
                s_stopwatches[stopwatch] = sw;
                sw.Start();
            }
        }

        /// <summary>
        /// 停止测量某个时间间隔的运行时间
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Stop(string stopwatch)
        {
            if (!s_stopwatches.TryGetValue(stopwatch, out Stopwatch sw))
            {
                Log.Warn($"not found stopwatch:{stopwatch}");
                return;
            }

            sw.Stop();
            s_stopwatches.Remove(stopwatch);
        }

        /// <summary>
        /// 停止计时，并将计时结果重置为0
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Reset(string stopwatch)
        {
            if (!s_stopwatches.TryGetValue(stopwatch, out Stopwatch sw))
            {
                Log.Warn($"not found stopwatch:{stopwatch}");
                return;
            }

            sw.Reset();
        }

        /// <summary>
        /// 停止计时，并将计时结果重置为0，然后重新开始计时
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Restart(string stopwatch)
        {
            if (!s_stopwatches.TryGetValue(stopwatch, out Stopwatch sw))
            {
                Log.Warn($"not found stopwatch:{stopwatch}");
                return;
            }

            sw.Restart();
        }

        /// <summary>
        /// 获取指定名称的stopwatch的Print信息
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetPrintString(string stopwatch, string msg = null)
        {
            if (!s_stopwatches.TryGetValue(stopwatch, out Stopwatch sw))
            {
                Log.Warn($"not found stopwatch:{stopwatch}");
                return string.Empty;
            }

            if (string.IsNullOrEmpty(msg))
                return ($"Stopwatch:{stopwatch}  Total:{s_stopwatches.Count}  Elapsed:{sw.Elapsed}");
            else
                return ($"Stopwatch:{stopwatch}  Total:{s_stopwatches.Count}  Msg:{msg}  Elapsed:{sw.Elapsed}");
        }

        /// <summary>
        /// 打印指定名称的stopwatch的运行数据
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Print(string stopwatch)
        {
            Print(stopwatch, null);
        }

        /// <summary>
        /// 打印指定名称的stopwatch的运行数据
        /// </summary>
        /// <param name="stopwatch"></param>
        /// <param name="msg"></param>
        public static void Print(string stopwatch, string msg = null)
        {
            var info = GetPrintString(stopwatch, msg);
            if (!string.IsNullOrEmpty(info))
                Log.Info(info);
        }

        /// <summary>
        /// 停止所有stopwatch并清空
        /// </summary>
        public static void Clear()
        {
            var watches = s_stopwatches.Values;
            foreach (var sw in watches)
            {
                sw.Stop();
            }

            s_stopwatches.Clear();
        }
    }
}
