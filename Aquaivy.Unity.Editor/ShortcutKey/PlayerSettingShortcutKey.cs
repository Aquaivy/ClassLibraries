using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Aquaivy.Unity.Editor
{
    public class PlayerSettingShortcutKey
    {
        /// <summary>
        /// 打开PlayerSetting面板
        /// </summary>
        public static void Open()
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
        }
    }
}
