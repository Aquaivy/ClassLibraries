using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity.Tasks
{
    public enum DelayType
    {
        /// <summary>
        /// 按照帧数延迟
        /// </summary>
        Frame,

        /// <summary>
        /// 按照时间延迟，单位：ms
        /// </summary>
        Time
    }

    /// <summary>
    /// 延迟任务，可按照帧数或者ms毫秒值来延迟
    /// </summary>
    public class DelayTask
    {
        /// <summary>
        /// 延迟类型
        /// </summary>
        DelayType Type;

        /// <summary>
        /// 累计时间
        /// </summary>
        public int Timer { get { return taskLite.Timer; } }
        public int TimerRemaining { get { return Delay - taskLite.Timer; } }

        /// <summary>
        /// 当前执行过的帧数
        /// </summary>
        public int Frame { get { return taskLite.Frame; } }
        public int FrameRemaining { get { return Delay - taskLite.Frame; } }

        /// <summary>
        /// 需要延迟的数量
        /// </summary>
        public int Delay;

        /// <summary>
        /// 关联数据
        /// </summary>
        public object Tag;

        public Action Task;

        private TaskLite taskLite;

        public void Release()
        {
            Release(this);
        }

        /// <summary>
        /// 压入一个延迟函数，可按照时间或者帧数来延迟
        /// </summary>
        /// <param name="task"></param>
        /// <param name="delay"></param>
        /// <param name="type"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static DelayTask Invoke(Action task, int delay, DelayType type = DelayType.Time, object tag = null)
        {
            var delayTask = new DelayTask
            {
                Task = task,
                Delay = delay,
                Type = type,
                Tag = tag
            };

            delayTask.taskLite = TaskLite.Invoke(t =>
            {
                if (type == DelayType.Time)
                {
                    if (t < delay)
                        return false;
                }
                else if (type == DelayType.Frame)
                {
                    if (delayTask.Frame < delay)
                        return false;
                }

                task();

                return true;
            });

            return delayTask;
        }

        public static void Release(DelayTask delayTask)
        {
            delayTask.taskLite.Release();
        }

        public override string ToString()
        {
            if (Type == DelayType.Time)
                return $"DelayTask tag={Tag}  type={Type}  Time={Timer}/{Delay}";
            else
                return $"DelayTask tag={Tag}  type={Type}  Frame={Frame}/{Delay}";
        }
    }
}
