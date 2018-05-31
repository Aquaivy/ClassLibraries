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
    public class TextureImporter
    {
        public static void ChangeTextureToSprite()
        {
            SetTextureInfo(TextureImporterType.Sprite, true, TextureImporterNPOTScale.None, TextureWrapMode.Clamp, TextureSize.Size2048, tex =>
            {

            });
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
                UnityEditor.TextureImporter tex = global::UnityEditor.TextureImporter.GetAtPath(path) as UnityEditor.TextureImporter;
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
    }
}
