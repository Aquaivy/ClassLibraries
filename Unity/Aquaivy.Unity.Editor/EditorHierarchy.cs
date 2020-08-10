using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    /// <summary>
    /// Hierarchy面板添加右键菜单，
    /// 参考网址：https://www.cnblogs.com/yangrouchuan/p/6690689.html
    /// </summary>
    public class EditorHierarchy
    {
        [MenuItem("GameObject/Remove GameObject Name (1)   %F2", false, 11)]
        [MenuItem("Tools/Remove GameObject Name (1)", false, 131)]
        public static void 移除复制物体名字后的括号()
        {
            HierarchyGameObjectRenameTool.Rename();
        }
    }
}
