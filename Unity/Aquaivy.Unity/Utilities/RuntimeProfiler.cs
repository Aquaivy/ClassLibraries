using Aquaivy.Core.Logs;
using Aquaivy.Core.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;

namespace Aquaivy.Unity.Profiling
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ProfilerType : int
    {
        Fps = 0,
        TotalMem = (1 << 0),
        MonoMem = (1 << 1)
    }

    /// <summary>
    /// 以最原始的OnGUI进行显示的性能检测工具
    /// </summary>
    public class RuntimeProfiler : MonoBehaviour
    {
        private static RuntimeProfiler instance;

        private static int fps = 0;
        private static int fpsCount = 0;
        private static StringBuilder sb = new StringBuilder();              //存储Gui显示内容
        private static float lastFpsTime = 0;
        private static float lastRefreshGuiTime = 0;                        //上一次刷新Gui的时间

        /// <summary>
        /// 刷新Profiler信息的时间间隔，单位：s
        /// </summary>
        public static float RefreshGuiInterval = 0.33f;                        //刷新Gui的时间间隔

        /// <summary>
        /// 在屏幕左上角显示Profiler信息
        /// </summary>
        public static void Show()
        {
            if (instance != null)
                return;

            var go = new GameObject("RuntimeProfiler");
            instance = go.AddComponent<RuntimeProfiler>();
        }

        /// <summary>
        /// 取消显示Profiler信息
        /// </summary>
        public static void Hide()
        {
            if (instance == null)
                return;

            Release();
        }

        private static void Release()
        {
            GameObject.Destroy(instance.gameObject);
            instance = null;
            fps = 0;
            fpsCount = 0;
            lastFpsTime = 0;
            lastRefreshGuiTime = 0;
            sb.Clear();
        }

        /// <summary>
        /// 设置显示的Profiler信息种类
        /// </summary>
        /// <param name="profilers"></param>
        public static void SetProfiler(ProfilerType profilers)
        {

        }

        /// <summary>
        /// 添加/更新 自定义帧率统计
        /// </summary>
        /// <param name="key"></param>
        public static void UpdateCustomFps(string key)
        {

        }

        /// <summary>
        /// 移除自定义帧率统计
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCustomFps(string key)
        {

        }

        /// <summary>
        /// 清除所有自定义帧率统计
        /// </summary>
        /// <param name="key"></param>
        public static void ClearCustomFps(string key)
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            fpsCount++;
            if (Time.realtimeSinceStartup - lastFpsTime >= 1)
            {
                lastFpsTime = Time.realtimeSinceStartup;
                fps = fpsCount;
                fpsCount = 0;
            }
        }

        private void OnGUI()
        {
            if (Time.realtimeSinceStartup - lastRefreshGuiTime < RefreshGuiInterval)
            {
                return;
            }

            sb.Clear();
            sb.AppendFormat("FPS: {0}\n", fps);
            sb.AppendFormat("Total Mem: {0:F1}MB\n", GetTotalAllocatedMemory());
            sb.AppendFormat("Mono Use: {0:F1}MB\n", GetMonoUsedSize());

            GUILayout.Label(sb.ToString());
        }

        /// <summary>
        /// 返回Mono堆大小（已转为MB单位）
        /// </summary>
        /// <returns></returns>
        public static float GetMonoHeapSize()
        {
            return new MemorySize(Profiler.GetMonoHeapSizeLong()).TotalMBs;
        }

        /// <summary>
        /// 返回Mono使用大小（已转为MB单位）
        /// </summary>
        /// <returns></returns>
        public static float GetMonoUsedSize()
        {
            return new MemorySize(Profiler.GetMonoUsedSizeLong()).TotalMBs;
        }

        /// <summary>
        /// 返回所有的内存申请大小（已转为MB单位）
        /// </summary>
        /// <returns></returns>
        public static float GetTotalAllocatedMemory()
        {
            return new MemorySize(Profiler.GetTotalAllocatedMemoryLong()).TotalMBs;
        }

    }
}