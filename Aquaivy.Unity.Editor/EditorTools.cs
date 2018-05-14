using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    //[ExecuteInEditMode]
    public class EditorTools
    {
        [MenuItem("Tools/Clear Log %Q", false, 1)]
        public static void CorrectCsprojFile() => ConsoleLog.Clear();


    }
}
