using System.Collections.Generic;

namespace Aquaivy.Core.Common
{
    /// <summary>
    /// 并发队列，线程安全
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentQueue<T>
    {
        private Queue<T> queue = new Queue<T>();

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="p"></param>
        public void Enqueue(T p)
        {
            lock (queue)
            {
                queue.Enqueue(p);
            }
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="returnT"></param>
        /// <returns></returns>
        public bool TryDequeue(out T returnT)
        {
            returnT = default(T);

            lock (queue)
            {
                if (queue.Count == 0)
                    return false;
                returnT = queue.Dequeue();

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long Count
        {
            get
            {
                return queue.Count;
            }
            
        }
    }
}
