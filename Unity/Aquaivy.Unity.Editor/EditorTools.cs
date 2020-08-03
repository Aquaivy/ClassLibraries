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
        [MenuItem("Tools/Clear Editor Log %Q", false, 1)]
        public static void ClearEditorConsoleLog() => ConsoleLog.Clear();

        [MenuItem("Tools/Open PlayerSetting %J", false, 1)]
        public static void OpenPlayerSetting() => PlayerSettingShortcutKey.Open();


        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
        [MenuItem("Tools/Refresh Project", false, 51)]
        public static void RefreshProject() => RefreshProjectFile.Refresh();

        [MenuItem("Tools/Repair Dependence", false, 52)]
        public static void RepairDependences() => RepairDependence.Repair();

        [MenuItem("Tools/Reduce Warning Level", false, 53)]
        public static void WarningLevel() => ReduceWarningLevel.Reduce();



        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
        [MenuItem("Tools/Missing Reference/Search in current scene", false, 101)]
        public static void FindMissingReferencesInCurrentScene() => MissingReferencesFinder.FindMissingReferencesInCurrentScene();

        [MenuItem("Tools/Missing Reference/Search in BuildSetting", false, 102)]
        public static void MissingSpritesInBuildSetting() => MissingReferencesFinder.MissingSpritesInBuildSetting();

        [MenuItem("Tools/Missing Reference/Search in project assets", false, 103)]
        public static void MissingSpritesInProjectAssets() => MissingReferencesFinder.MissingSpritesInProjectAssets();


        [MenuItem("Tools/Search Script", false, 110)]
        public static void Searchscript() => SearchScriptWindow.OpenWindow();

        [MenuItem("Tools/Resource Checker", false, 120)]
        public static void OpenResourceCheckerWindow() => ResourceChecker.Init();

        [MenuItem("Tools/Namespace Checker", false, 130)]
        public static void Namespace() => NamespaceChecker.CheckerNoneNamespaceFile();


        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------        

        [MenuItem("Tools/Format/Change To Sprite", false, 1001)]
        [MenuItem("Assets/Format/Change To Sprite", false, 1001)]
        public static void ChangeTextureToSprite() => TextureImporterEditor.ChangeTextureToSprite();

        [MenuItem("Tools/Format/Change To Texture", false, 1002)]
        [MenuItem("Assets/Format/Change To Texture", false, 1002)]
        public static void ChangeSpriteToTexture() => TextureImporterEditor.ChangeSpriteToTexture();

        [MenuItem("Tools/Format/Change Audios To Mono", false, 1003)]
        [MenuItem("Assets/Format/Change Audios To Mono", false, 1003)]
        public static void ChangeAudiosToMono() => AudioImporterEditor.ChangeAudiosToMono();


        #region Scene Loader

        [MenuItem("Tools/Load Scene/Scene 0 %#1", false, 1010)]
        public static void Load_Scene_0() => EditorSceneLoader.LoadScene(0);

        [MenuItem("Tools/Load Scene/Scene 1 %#2", false, 1010)]
        public static void Load_Scene_1() => EditorSceneLoader.LoadScene(1);

        [MenuItem("Tools/Load Scene/Scene 2 %#3", false, 1010)]
        public static void Load_Scene_2() => EditorSceneLoader.LoadScene(2);

        [MenuItem("Tools/Load Scene/Scene 3 %#4", false, 1010)]
        public static void Load_Scene_3() => EditorSceneLoader.LoadScene(3);

        [MenuItem("Tools/Load Scene/Scene 4 %#5", false, 1010)]
        public static void Load_Scene_4() => EditorSceneLoader.LoadScene(4);

        [MenuItem("Tools/Load Scene/Scene 5 %#6", false, 1010)]
        public static void Load_Scene_5() => EditorSceneLoader.LoadScene(5);

        [MenuItem("Tools/Load Scene/Scene 6 %#7", false, 1010)]
        public static void Load_Scene_6() => EditorSceneLoader.LoadScene(6);

        [MenuItem("Tools/Load Scene/Scene 7 %#8", false, 1010)]
        public static void Load_Scene_7() => EditorSceneLoader.LoadScene(7);

        [MenuItem("Tools/Load Scene/Scene 8 %#9", false, 1010)]
        public static void Load_Scene_8() => EditorSceneLoader.LoadScene(8);

        [MenuItem("Tools/Load Scene/Scene 9 %#`", false, 1010)]
        public static void Load_Scene_9() => EditorSceneLoader.LoadScene(9);

        #endregion

        #region GameObjectLocater

        [MenuItem("Tools/Locate/Load Hierarchy 1 %1", false, 1011)]
        public static void Locate_Hierarchy_1() => GameObjectLocater.Locate(0);

        [MenuItem("Tools/Locate/Load Hierarchy 2 %2", false, 1011)]
        public static void Locate_Hierarchy_2() => GameObjectLocater.Locate(1);

        [MenuItem("Tools/Locate/Load Hierarchy 3 %3", false, 1011)]
        public static void Locate_Hierarchy_3() => GameObjectLocater.Locate(2);

        [MenuItem("Tools/Locate/Load Hierarchy 4 %4", false, 1011)]
        public static void Locate_Hierarchy_4() => GameObjectLocater.Locate(3);

        [MenuItem("Tools/Locate/Load Hierarchy 5 %5", false, 1011)]
        public static void Locate_Hierarchy_5() => GameObjectLocater.Locate(4);

        [MenuItem("Tools/Locate/Load Hierarchy 6 %6", false, 1011)]
        public static void Locate_Hierarchy_6() => GameObjectLocater.Locate(5);

        [MenuItem("Tools/Locate/Load Hierarchy 7 %7", false, 1011)]
        public static void Locate_Hierarchy_7() => GameObjectLocater.Locate(6);

        [MenuItem("Tools/Locate/Load Hierarchy 8 %8", false, 1011)]
        public static void Locate_Hierarchy_8() => GameObjectLocater.Locate(7);

        [MenuItem("Tools/Locate/Load Hierarchy 9 %9", false, 1011)]
        public static void Locate_Hierarchy_9() => GameObjectLocater.Locate(8);

        [MenuItem("Tools/Locate/Load Hierarchy 10 %10", false, 1011)]
        public static void Locate_Hierarchy_10() => GameObjectLocater.Locate(8);






        [MenuItem("Tools/Locate/Set Locate 1", false, 1012)]
        public static void Set_Locate_1() => GameObjectLocater.SetLocateConfig(0);

        [MenuItem("Tools/Locate/Set Locate 2", false, 1012)]
        public static void Set_Locate_2() => GameObjectLocater.SetLocateConfig(1);

        [MenuItem("Tools/Locate/Set Locate 3", false, 1012)]
        public static void Set_Locate_3() => GameObjectLocater.SetLocateConfig(2);

        [MenuItem("Tools/Locate/Set Locate 4", false, 1012)]
        public static void Set_Locate_4() => GameObjectLocater.SetLocateConfig(3);

        [MenuItem("Tools/Locate/Set Locate 5", false, 1012)]
        public static void Set_Locate_5() => GameObjectLocater.SetLocateConfig(4);

        [MenuItem("Tools/Locate/Set Locate 6", false, 1012)]
        public static void Set_Locate_6() => GameObjectLocater.SetLocateConfig(5);

        [MenuItem("Tools/Locate/Set Locate 7", false, 1012)]
        public static void Set_Locate_7() => GameObjectLocater.SetLocateConfig(6);

        [MenuItem("Tools/Locate/Set Locate 8", false, 1012)]
        public static void Set_Locate_8() => GameObjectLocater.SetLocateConfig(7);

        [MenuItem("Tools/Locate/Set Locate 9", false, 1012)]
        public static void Set_Locate_9() => GameObjectLocater.SetLocateConfig(8);

        [MenuItem("Tools/Locate/Set Locate 10", false, 1012)]
        public static void Set_Locate_10() => GameObjectLocater.SetLocateConfig(9);

        #endregion
    }
}
