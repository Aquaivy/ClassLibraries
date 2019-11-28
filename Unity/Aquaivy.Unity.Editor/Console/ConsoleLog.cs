using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// 编辑器log操作
    /// </summary>
    class ConsoleLog
    {
        /// <summary>
        /// 清空编辑器log
        /// （Unity 2017.1.0以及之后的版本）
        /// </summary>
        public static void Clear()
        {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }

        /// <summary>
        /// 清空编辑器log
        /// (Unity 2017.1.0之前的版本)
        /// </summary>
        public static void Clear_BeforeUnity2017()
        {
            var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
            var clearMethod = logEntries.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
            clearMethod.Invoke(null, null);
        }
    }
}
