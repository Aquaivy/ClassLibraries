using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity
{
    /// <summary>
    /// 自动结束任务的方式
    /// </summary>
    public enum ThrottleStopType
    {
        /// <summary>
        /// 永不结束
        /// </summary>
        Forever,

        /// <summary>
        /// 持续的时间，单位：ms
        /// </summary>
        Duration,

        /// <summary>
        /// 执行的次数
        /// </summary>
        Times
    }

    /// <summary>
    /// 延迟任务，可按照帧数或者ms毫秒值来延迟
    /// </summary>
    public class ThrottleTask
    {
        private ThrottleStopType stopType;
        private int stopValue;

        /// <summary>
        /// 执行任务间隔时长，单位：ms
        /// </summary>
        public int Interval;

        /// <summary>
        /// 任务执行过的次数
        /// </summary>
        public int Times { get; private set; }

        /// <summary>
        /// 累计时间
        /// </summary>
        public int Timer { get { return taskLite.Timer; } }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public int TimerRemaining { get { return stopValue - taskLite.Timer; } }

        /// <summary>
        /// 关联数据
        /// </summary>
        public object Tag;

        public Action Task;

        private TaskLite taskLite;

        private int lastRunTime = 0;


        /// <summary>
        /// 压入一个延迟函数，按照时间来延迟
        /// </summary>
        /// <param name="task"></param>
        /// <param name="interval"></param>
        /// <param name="stopType"></param>
        /// <param name="stopValue"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static ThrottleTask Invoke(Action task, int interval, ThrottleStopType stopType = ThrottleStopType.Forever, int stopValue = 0, object tag = null)
        {
            var throttleTask = new ThrottleTask
            {
                Task = task,
                Interval = interval,
                stopType = stopType,
                stopValue = stopValue,
                Tag = tag
            };

            throttleTask.taskLite = TaskLite.Invoke(t =>
            {
                if (t < throttleTask.lastRunTime + throttleTask.Interval)
                    return false;

                throttleTask.lastRunTime = t;

                task?.Invoke();

                throttleTask.Times++;

                if (throttleTask.stopType == ThrottleStopType.Times)
                {
                    return throttleTask.Times >= stopValue;
                }
                else if (throttleTask.stopType == ThrottleStopType.Duration)
                {
                    return throttleTask.Timer >= stopValue;
                }
                else
                {
                    return false;
                }

            });

            return throttleTask;
        }

        /// <summary>
        /// 释放某个任务
        /// </summary>
        /// <param name="throttleTask"></param>
        public static void Release(ThrottleTask throttleTask)
        {
            throttleTask.taskLite.Release();
        }


        /// <summary>
        /// 释放这个任务
        /// </summary>
        public void Release()
        {
            Release(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (stopType == ThrottleStopType.Forever)
                return $"DelayTask tag={Tag}  type={stopType}  Times={Times}  Timer={Timer}";
            else if (stopType == ThrottleStopType.Times)
                return $"DelayTask tag={Tag}  type={stopType}  Times={Times}";
            else if (stopType == ThrottleStopType.Duration)
                return $"DelayTask tag={Tag}  type={stopType}  Timer={Timer}  Remaining={TimerRemaining}";
            else
                return string.Empty;
        }
    }
}
