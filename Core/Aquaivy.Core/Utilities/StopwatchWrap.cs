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
    /// 
    /// </summary>
    public static class StopwatchWrap
    {
        //Elapsed                   不同
        //ElapsedTicks              不同
        //ElapsedMilliseconds       可能相同


        private static Dictionary<string, Stopwatch> watches = new Dictionary<string, Stopwatch>();

        /// <summary>
        /// 停止时间间隔测量，并将运行时间重置为零
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Reset(string stopwatch)
        {
            Stopwatch sw;
            if (!watches.TryGetValue(stopwatch, out sw))
            {
                Log.Warn($"Have not find stopwatch:{stopwatch}");
                return;
            }

            sw.Reset();
        }

        /// <summary>
        /// 停止时间间隔测量，将运行时间重置为零，然后开始测量运行时间
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Restart(string stopwatch)
        {
            Stopwatch sw;
            if (!watches.TryGetValue(stopwatch, out sw))
            {
                Log.Warn($"Have not find stopwatch:{stopwatch}");
                return;
            }

            sw.Restart();
        }

        /// <summary>
        /// 开始或继续测量某个时间间隔的运行时间
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Start(string stopwatch)
        {
            Stopwatch sw;
            if (watches.TryGetValue(stopwatch, out sw))
            {
                sw.Start();
            }
            else
            {
                sw = new Stopwatch();
                watches[stopwatch] = sw;
                sw.Start();
            }
        }

        /// <summary>
        /// 停止测量某个时间间隔的运行时间
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void Stop(string stopwatch)
        {
            Stopwatch sw;
            if (!watches.TryGetValue(stopwatch, out sw))
            {
                Log.Warn($"Have not find stopwatch:{stopwatch}");
                return;
            }

            sw.Stop();
            watches.Remove(stopwatch);
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
        public static void Print(string stopwatch, string msg)
        {
            Stopwatch sw;
            if (!watches.TryGetValue(stopwatch, out sw))
            {
                Log.Warn($"Have not find stopwatch:{stopwatch}");
                return;
            }

            if (string.IsNullOrEmpty(msg))
                Log.Info($"Stopwatch:{stopwatch}  Elapsed:{sw.Elapsed}");
            else
                Log.Info($"Stopwatch:{stopwatch}  Msg:{msg}  Elapsed:{sw.Elapsed}");
            //Log.Info($"Stopwatch:{name}  Total:{watches.Count}  Elapsed:{watch.Elapsed}");
        }

        /// <summary>
        /// 停止所有stopwatch并清空
        /// </summary>
        public static void Clear()
        {
            var w = watches.Values.ToList();
            for (int i = 0; i < w.Count; i++)
            {
                var watch = w[i];
                watch.Stop();
                i--;
            }
        }
    }
}
