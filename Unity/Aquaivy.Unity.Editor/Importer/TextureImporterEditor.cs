using Aquaivy.Unity.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    public class TextureImporterEditor
    {
        public static void ChangeTextureToSprite()
        {
            Texture[] selections = Selection.GetFiltered<Texture>(SelectionMode.Assets);
            if (selections == null || selections.Length == 0)
            {
                Debug.Log("Please select some [Texture] assets first");
                return;
            }

            foreach (var asset in selections)
            {
                string path = AssetDatabase.GetAssetPath(asset);
                TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;

                //Type
                textureImporter.textureType = TextureImporterType.Sprite;

                //Sprite
                TextureImporterSettings textureImportSetting = new TextureImporterSettings();
                textureImporter.ReadTextureSettings(textureImportSetting);
                textureImporter.spriteImportMode = SpriteImportMode.Single;
                textureImporter.spritePixelsPerUnit = 100;
                textureImportSetting.spriteMeshType = SpriteMeshType.FullRect;
                textureImportSetting.spriteExtrude = 1;
                textureImportSetting.spritePivot = new Vector2(0.5f, 0.5f);
                textureImportSetting.spriteGenerateFallbackPhysicsShape = false;
                textureImporter.SetTextureSettings(textureImportSetting);

                //Advanced
                textureImporter.sRGBTexture = true;
                textureImporter.alphaSource = TextureImporterAlphaSource.FromInput;
                textureImporter.alphaIsTransparency = true;
                textureImporter.isReadable = false;
                textureImporter.mipmapEnabled = false;

                //Wrap
                textureImporter.wrapMode = TextureWrapMode.Clamp;
                textureImporter.filterMode = FilterMode.Bilinear;

                textureImporter.npotScale = TextureImporterNPOTScale.None;
                textureImporter.maxTextureSize = 2048;

                AssetDatabase.ImportAsset(path);
                Debug.Log($"TextureImporter  {path}");
            }
        }

        public static void ChangeSpriteToTexture()
        {
            SetTextureInfo(TextureImporterType.Default, false, TextureImporterNPOTScale.ToNearest, TextureWrapMode.Repeat, TextureSize.Size2048, tex =>
            {

            });
        }

        public static void SetTextureInfo(TextureImporterType textureType, bool alphaIsTransparency,
            TextureImporterNPOTScale npotScale, TextureWrapMode wrapMode, int textureSize,
            Action<UnityEditor.TextureImporter> customAction)
        {
            Texture[] selections = Selection.GetFiltered<Texture>(SelectionMode.Assets);
            if (selections == null || selections.Length == 0)
            {
                Debug.Log("Please select some assets first");
                return;
            }

            foreach (var asset in selections)
            {
                string path = AssetDatabase.GetAssetPath(asset);
                UnityEditor.TextureImporter tex = UnityEditor.TextureImporter.GetAtPath(path) as UnityEditor.TextureImporter;
                tex.textureType = textureType;
                tex.alphaIsTransparency = alphaIsTransparency;
                tex.npotScale = npotScale;
                tex.wrapMode = wrapMode;
                tex.maxTextureSize = textureSize;

                customAction?.Invoke(tex);

                AssetDatabase.ImportAsset(path);
                Debug.Log($"TextureImporter  {path}");
            }
        }


        private static void OnImportTexture(string assetPath)
        {
            TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (textureImporter != null)
            {
                string AtlasName = new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(assetPath)).Name;
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spriteImportMode = SpriteImportMode.Single;
                textureImporter.spritePixelsPerUnit = 100;
                textureImporter.spritePackingTag = AtlasName;

                TextureImporterSettings textureImportSetting = new TextureImporterSettings();
                textureImporter.ReadTextureSettings(textureImportSetting);
                textureImportSetting.spriteMeshType = SpriteMeshType.FullRect;
                textureImportSetting.spriteExtrude = 1;
                textureImportSetting.spriteGenerateFallbackPhysicsShape = false;
                textureImporter.SetTextureSettings(textureImportSetting);

                textureImporter.mipmapEnabled = false;
                textureImporter.isReadable = false;
                textureImporter.wrapMode = TextureWrapMode.Clamp;
                textureImporter.filterMode = FilterMode.Bilinear;
                textureImporter.alphaIsTransparency = true;
                textureImporter.alphaSource = TextureImporterAlphaSource.FromInput;
                textureImporter.sRGBTexture = true;

                TextureImporterPlatformSettings platformSetting = textureImporter.GetPlatformTextureSettings("Standalone");
                platformSetting.maxTextureSize = 2048;
                platformSetting.textureCompression = TextureImporterCompression.Compressed;
                platformSetting.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                platformSetting.overridden = true;
                platformSetting.textureCompression = TextureImporterCompression.Compressed;
                platformSetting.format = TextureImporterFormat.DXT5;
                textureImporter.SetPlatformTextureSettings(platformSetting);

                platformSetting = textureImporter.GetPlatformTextureSettings("iPhone");
                platformSetting.maxTextureSize = 2048;
                platformSetting.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                platformSetting.overridden = true;
                platformSetting.compressionQuality = 100;
                platformSetting.textureCompression = TextureImporterCompression.Compressed;
                platformSetting.format = TextureImporterFormat.PVRTC_RGBA4;
                textureImporter.SetPlatformTextureSettings(platformSetting);

                platformSetting = textureImporter.GetPlatformTextureSettings("Android");
                platformSetting.maxTextureSize = 2048;
                platformSetting.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                platformSetting.overridden = true;
                platformSetting.textureCompression = TextureImporterCompression.Compressed;
                platformSetting.format = TextureImporterFormat.ETC2_RGBA8;
                textureImporter.SetPlatformTextureSettings(platformSetting);

                platformSetting = textureImporter.GetPlatformTextureSettings("Web");
                platformSetting.maxTextureSize = 2048;
                platformSetting.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                platformSetting.overridden = true;
                platformSetting.format = TextureImporterFormat.RGBA32;
                textureImporter.SetPlatformTextureSettings(platformSetting);
            }
        }
    }
}
