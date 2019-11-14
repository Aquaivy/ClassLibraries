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
    /// 以最原始的OnGUI进行显示的性能检测工具
    /// </summary>
    public class RuntimeProfiler : UnitySingleton<RuntimeProfiler>
    {
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum Type : int
        {
            Fps = 0,
            TotalMem = (1 << 0),
            MonoMem = (1 << 1)
        }

        public class FpsData
        {
            internal int fps;
            internal string name;
            internal int fpsCount;
            internal float lastFpsTime;
        }


        private bool showing = false;
        private FpsData graphicFps = new FpsData();
        //private int fps = 0;
        //private int fpsCount = 0;
        //private float lastFpsTime = 0;
        private StringBuilder sb = new StringBuilder();              //存储Gui显示内容
        private float lastRefreshGuiTime = 0;                        //上一次刷新Gui的时间
        private Dictionary<string, FpsData> customFps = new Dictionary<string, FpsData>();

        /// <summary>
        /// 刷新Profiler信息的时间间隔，单位：s
        /// </summary>
        public float RefreshGuiInterval = 0.33f;                        //刷新Gui的时间间隔

        /// <summary>
        /// 
        /// </summary>
        public GUIStyle style = null;

        public int Fps { get { return graphicFps.fps; } }

        /// <summary>
        /// 在屏幕左上角显示Profiler信息
        /// </summary>
        public void Show()
        {
            showing = true;
        }

        /// <summary>
        /// 取消显示Profiler信息
        /// </summary>
        public void Hide()
        {
            Release();

            showing = false;
        }

        private void Release()
        {
            GameObject.Destroy(gameObject);
            graphicFps.fps = 0;
            graphicFps.fpsCount = 0;
            graphicFps.lastFpsTime = 0;
            lastRefreshGuiTime = 0;
            sb.Clear();
        }

        /// <summary>
        /// 设置显示的Profiler信息种类
        /// </summary>
        /// <param name="profilers"></param>
        public void SetProfiler(Type profilers)
        {

        }

        /// <summary>
        /// 添加/更新 自定义帧率统计
        /// </summary>
        /// <param name="key"></param>
        public void UpdateCustomFps(string key)
        {
            FpsData data;
            if (!customFps.TryGetValue(key, out data))
                data = new FpsData { name = key };
            data.fpsCount++;
        }

        /// <summary>
        /// 移除自定义帧率统计
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCustomFps(string key)
        {
            customFps.Remove(key);
        }

        /// <summary>
        /// 清除所有自定义帧率统计
        /// </summary>
        /// <param name="key"></param>
        public void ClearCustomFps(string key)
        {
            customFps.Clear();
        }

        // Use this for initialization
        void Start()
        {
            style = new GUIStyle
            {
                fontSize = 16,
                normal = new GUIStyleState { textColor = Color.green }
            };
        }

        // Update is called once per frame
        void Update()
        {
            graphicFps.fpsCount++;
            if (Time.realtimeSinceStartup - graphicFps.lastFpsTime >= 1)
            {
                graphicFps.lastFpsTime = Time.realtimeSinceStartup;

                //update grahpic fps
                graphicFps.fps = graphicFps.fpsCount;
                graphicFps.fpsCount = 0;

                //update custom fps
                foreach (var data in customFps.Values)
                {
                    data.fps = data.fpsCount;
                    data.fpsCount = 0;
                }
            }
        }

        private void OnGUI()
        {
            if (Time.realtimeSinceStartup - lastRefreshGuiTime < RefreshGuiInterval)
            {
                return;
            }

            if (!showing)
                return;

            sb.Clear();
            sb.AppendFormat("FPS: {0}\n", graphicFps.fps);
            sb.AppendFormat("Total Mem: {0:F1}MB\n", GetTotalAllocatedMemory());
            sb.AppendFormat("Mono Use: {0:F1}MB\n", GetMonoUsedSize());

            foreach (var data in customFps.Values)
            {
                sb.AppendFormat("{0} FPS: {1}\n", data.name, data.fps);
            }

            GUILayout.Label(sb.ToString(), style);
        }

        /// <summary>
        /// 返回Mono堆大小（已转为MB单位）
        /// </summary>
        /// <returns></returns>
        public float GetMonoHeapSize()
        {
            return new StorageUnit(Profiler.GetMonoHeapSizeLong()).TotalMBs;
        }

        /// <summary>
        /// 返回Mono使用大小（已转为MB单位）
        /// </summary>
        /// <returns></returns>
        public float GetMonoUsedSize()
        {
            return new StorageUnit(Profiler.GetMonoUsedSizeLong()).TotalMBs;
        }

        /// <summary>
        /// 返回所有的内存申请大小（已转为MB单位）
        /// </summary>
        /// <returns></returns>
        public float GetTotalAllocatedMemory()
        {
            return new StorageUnit(Profiler.GetTotalAllocatedMemoryLong()).TotalMBs;
        }

    }
}