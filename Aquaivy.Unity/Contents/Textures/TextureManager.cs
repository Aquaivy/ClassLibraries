using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity
{
    public class TextureManager
    {
        /// <summary>
        /// 创建一个Sprite，需要".png"
        /// </summary>
        /// <param name="path">需要".png"</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Sprite CreateSprite(string path, int width, int height)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            var bytes = File.ReadAllBytes(path);
            var tex = new Texture2D(width, height);
            tex.LoadImage(bytes);

            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
#if UNITY_EDITOR
            sprite.name = Path.GetFileName(path);
#endif

            return sprite;
        }

        /// <summary>
        /// 从Resources下读取文件，创建一个Sprite.
        /// 不要添加".png"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Sprite CreateSprite(string path)
        {
            return Resources.Load<Sprite>(path);
        }
    }
}
