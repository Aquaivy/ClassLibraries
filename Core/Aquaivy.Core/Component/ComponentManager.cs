using System;
using System.Collections.Generic;
using System.Linq;

namespace DogSE.Library.Component
{
    /// <summary>
    /// 组件管理器的实现模式
    /// </summary>
    public class ComponentManager : IComponentManager
    {
        private readonly Dictionary<string, object> m_ComponentDictionary =
            new Dictionary<string, object>();

        /// <summary>
        /// 注册一个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentId"></param>
        /// <param name="component"></param>
        public void RegisterComponent<T>(string componentId, T component) where T : class
        {
            if (string.IsNullOrEmpty(componentId))
                throw new ArgumentNullException("componentId");

            if (component == null)
                throw new ArgumentNullException("component");

            m_ComponentDictionary[componentId] = component;
        }

        /// <summary>
        /// 获得一个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public T GetComponent<T>(string componentId) where T : class
        {
            if (string.IsNullOrEmpty(componentId))
                throw new ArgumentNullException("componentId");

            object value;
            if (m_ComponentDictionary.TryGetValue(componentId, out value))
                return value as T;

            return null;
        }

        /// <summary>
        /// 释放组件资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void ReleaseComponent(string componentId)
        {
            if (string.IsNullOrEmpty(componentId))
                throw new ArgumentNullException("componentId");

            if (m_ComponentDictionary.ContainsKey(componentId))
                m_ComponentDictionary.Remove(componentId);
        }

        /// <summary>
        /// 释放组件资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void ReleaseComponent<T>()
        {
            var components = m_ComponentDictionary.Keys.Where(o => m_ComponentDictionary[o] is T).ToArray();
            for (int i = 0; i < components.Length; i++)
            {
                m_ComponentDictionary.Remove(components[i]);
            }
        }

        /// <summary>
        /// 清理所有数据（为GC用，注意使用场所）
        /// </summary>
        public void Clear()
        {
            m_ComponentDictionary.Clear();
        }
    }
}
