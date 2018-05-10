using Aquaivy.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity.Tasks
{
    /// <summary>
    /// 主线程回调任务
    /// </summary>
    public class TaskLite
    {
        /// <summary>
        /// 累计时间
        /// </summary>
        public int Timer;

        /// <summary>
        /// 当前执行过的帧
        /// </summary>
        public int Frame;

        /// <summary>
        /// 需要延迟多少帧执行
        /// </summary>
        public int DelayFrame;

        /// <summary>
        /// 关联数据
        /// </summary>
        public object Tag;

        /// <summary>
        /// 执行函数
        /// 注意，timer的时间为时间启动后的时间，而不是间隔时间
        /// </summary>
        public Func<int, bool> Func { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public volatile bool IsDone;

        /// <summary>
        /// 是否初始化
        /// </summary>
        public volatile bool IsInited;

        /// <summary>
        /// 错误次数
        /// </summary>
        public int ErrorCount;

        private bool waitCleaned = false;


        /// <summary>
        /// 释放这个任务
        /// </summary>
        public void Release()
        {
            Release(this);
        }

        #region 静态方法

        private static List<TaskLite> m_invokeActions = new List<TaskLite>();
        private static List<TaskLite> m_willAddInvokeActions = new List<TaskLite>();

        /// <summary>
        /// 压入一个执行函数
        /// 如果函数执行完成返回true
        /// 如果返回false，则再下一帧还会继续调用
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TaskLite Invoke(Func<int, bool> action, int delayFrame = 0, object tag = null)
        {
            var r = new TaskLite();
            r.Func = action;
            r.DelayFrame = delayFrame;
            r.Tag = tag;
            m_willAddInvokeActions.Add(r);
            return r;
        }

        public static void Update(int elapseTime)
        {
            if (m_willAddInvokeActions.Count > 0)
            {
                m_invokeActions.AddRange(m_willAddInvokeActions);
                m_willAddInvokeActions.Clear();
            }

            if (m_invokeActions.Count > 0)
            {
                for (var i = 0; i < m_invokeActions.Count; i++)
                {
                    m_invokeActions[i].Timer += elapseTime;
                    m_invokeActions[i].Frame++;
                    if (m_invokeActions[i].Frame >= m_invokeActions[i].DelayFrame
                        && !m_invokeActions[i].waitCleaned)
                    {
                        try
                        {
                            m_invokeActions[i].IsDone = m_invokeActions[i].Func(m_invokeActions[i].Timer);

                            if (m_invokeActions[i].IsDone)
                            {
                                m_invokeActions.RemoveAt(i);
                                i--;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logs.Warn("run tasklite.invoke fail. {0}", ex.Message);

                            m_invokeActions[i].waitCleaned = true;
                        }

                    }
                }

                CleanLoseEfficacyTasks();
            }
        }

        private static void CleanLoseEfficacyTasks()
        {
            for (var i = 0; i < m_invokeActions.Count; i++)
            {
                if (m_invokeActions[i].waitCleaned)
                {
                    m_invokeActions.RemoveAt(i);
                    i--;
                }
            }
        }


        private static void Release(TaskLite task)
        {
            //Debug.Log($"TaskLite {task.Tag} releasing");

            task.waitCleaned = true;

            m_willAddInvokeActions.Remove(task);
            //m_invokeActions.Remove(task);
        }

        public static void ReleaseAll()
        {
            m_willAddInvokeActions.ForEach(o => o.Release());
            m_invokeActions.ForEach(o => o.Release());
        }

        #endregion
    }

}
