using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    //[ExecuteInEditMode]
    public class EditorTools
    {
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------

        [MenuItem("Tools/Clear Log %Q", false, 1)]
        public static void CorrectCsprojFile() => ConsoleLog.Clear();

        [MenuItem("Tools/Open PlayerSetting %J", false, 1)]
        public static void OpenPlayerSetting() => PlayerSettingShortcutKey.Open();


        [MenuItem("Tools/Refresh Project", false, 51)]
        public static void RefreshProject() => RefreshProjectFile.Refresh();

        [MenuItem("Tools/Repair Dependence", false, 52)]
        public static void RepairDependences() => RepairDependence.Repair();

        [MenuItem("Tools/Reduce Warning Level", false, 53)]
        public static void WarningLevel() => ReduceWarningLevel.Reduce();

        [MenuItem("Tools/Search Script Window", false, 101)]
        public static void Searchscript() => SearchScriptWindow.OpenWindow();

        [MenuItem("Tools/Test", false, 1001)]
        public static void TestNewScript() => SearchScript.Search(typeof(Camera));



        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------

        [MenuItem("Assets/Format/Change Audios To Mono", false, 1001)]
        public static void ChangeAudiosToMono() => AudioImporter.ChangeAudiosToMono();

        [MenuItem("Assets/Format/Change Texture To Sprite", false, 1002)]
        public static void ChangeTextureToSprite() => TextureImporter.ChangeTextureToSprite();

        [MenuItem("Assets/Format/Change Sprite To Texture", false, 1003)]
        public static void ChangeSpriteToTexture() => TextureImporter.ChangeSpriteToTexture();

    }
}
