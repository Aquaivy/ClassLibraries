using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity
{
    /// <summary>
    /// 按照固定时间间隔执行的任务，
    /// 可设置自动结束任务的方式
    /// </summary>
    public class ThrottleTask
    {
        private static readonly object m_tasklock = new object();

        private ThrottleStopType stopType;
        private int stopValue;

        /// <summary>
        /// 每次执行任务间隔时长，单位：ms
        /// </summary>
        public int Interval;

        /// <summary>
        /// 当前任务执行过的次数
        /// </summary>
        public int Times { get; private set; }

        /// <summary>
        /// 累计时间
        /// </summary>
        public int Timer { get { return taskLite.Timer; } }

        /// <summary>
        /// 剩余时间（只有当stopType为Duration时才有意义）
        /// </summary>
        public int TimerRemaining
        {
            get
            {
                if (stopType == ThrottleStopType.Duration)
                    return stopValue - Timer;

                return 0;
            }
        }

        /// <summary>
        /// 关联数据
        /// </summary>
        public object Tag;

        /// <summary>
        /// Task
        /// </summary>
        public Action Task;

        private TaskLite taskLite;

        private int lastRunTime = 0;

        /// <summary>
        /// 压入一个任务，按照一定时间间隔来执行
        /// </summary>
        /// <param name="task"></param>
        /// <param name="interval"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static ThrottleTask Invoke(Action task, int interval, object tag = null)
        {
            return Invoke(task, interval, ThrottleStopType.Forever, 0, tag);
        }

        /// <summary>
        /// 压入一个任务，按照一定时间间隔来执行
        /// </summary>
        /// <param name="task"></param>
        /// <param name="interval"></param>
        /// <param name="stopType"></param>
        /// <param name="stopValue"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static ThrottleTask Invoke(Action task, int interval, ThrottleStopType stopType, int stopValue, object tag = null)
        {
            lock (m_tasklock)
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
        }

        /// <summary>
        /// 释放某个任务
        /// </summary>
        /// <param name="throttleTask"></param>
        public static void Release(ThrottleTask throttleTask)
        {
            lock (m_tasklock)
            {
                throttleTask.taskLite.Release();
            }
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
}
