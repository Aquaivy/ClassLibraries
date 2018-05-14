using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeProfiler : MonoBehaviour
{
    [Flags]
    public enum Profiler
    {
        Fps = 0,
        Mem = (1 << 0),
        Total = (1 << 1)
    }

    public static void Show()
    {

    }

    public static void Hide()
    {

    }

    public static void SetProfiler(Profiler profilers)
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


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
