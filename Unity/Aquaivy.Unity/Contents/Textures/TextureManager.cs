using Aquaivy.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class TextureManager
    {
        private static Dictionary<string, Sprite> m_sprites = new Dictionary<string, Sprite>(128);


        /// <summary>
        /// 从Resources下读取文件，创建一个Sprite.
        /// 需要添加".png"  ".jpg"等后缀
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Sprite CreateSprite(string path)
        {
            Sprite sprite;
            m_sprites.TryGetValue(path, out sprite);
            if (sprite != null)
                return sprite;

            sprite = Resources.Load<Sprite>(PathEx.GetPathWithoutExtension(path));
            Resources.UnloadUnusedAssets();
            if (sprite != null)
            {
                m_sprites[path] = sprite;
                return sprite;
            }

            return null;
        }

        /// <summary>
        /// 销毁Sprite，如果当前有使用该Sprite，执行后会变成白色
        /// </summary>
        /// <param name="path"></param>
        public static void UnloadSprite(string path)
        {
            Sprite sprite;
            m_sprites.TryGetValue(path, out sprite);
            if (sprite == null)
                return;

            sprite = m_sprites[path];
            m_sprites.Remove(path);
            Resources.UnloadAsset(sprite);
        }

        /// <summary>
        /// 创建一个Sprite，需要".png"
        /// </summary>
        /// <param name="path">需要".png"</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        //        public static Sprite CreateSprite(string path, int width, int height)
        //        {
        //            if (!File.Exists(path))
        //            {
        //                return null;
        //            }

        //            var bytes = File.ReadAllBytes(path);
        //            var tex = new Texture2D(width, height);
        //            tex.LoadImage(bytes);

        //            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        //#if UNITY_EDITOR
        //            sprite.name = Path.GetFileName(path);
        //#endif

        //            return sprite;
        //        }

    }
}
