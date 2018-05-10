using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity.Audios
{
    /// <summary>
    /// 音频资源管理器。
    /// 加载过的audio会缓存在这里，
    /// 便于下次更快速的加载
    /// </summary>
    public static class AudioManager
    {
        /// <summary>
        /// 从StreamingAssets内加载一个音频
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioClip Load(string path)
        {
            throw new NotImplementedException();
        }

        public static AudioClip Unload(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 从Resource内加载一个音频
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioClip LoadResource(string path)
        {
            throw new NotImplementedException();
        }

        public static AudioClip UnloadResource(string path)
        {
            throw new NotImplementedException();
        }
    }
}
