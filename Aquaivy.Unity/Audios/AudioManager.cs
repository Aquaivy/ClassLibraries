using Aquaivy.Library.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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
        private static Dictionary<string, AudioClip> m_clips = new Dictionary<string, AudioClip>();
        private static List<Audio> m_audios = new List<Audio>(8);
        private static GameObject audiosParent;

        internal static void Add(Audio audio)
        {
            m_audios.Add(audio);

            if (audiosParent == null)
                audiosParent = new GameObject("Audios");
            audio.GameObject.transform.SetParent(audiosParent.transform);
        }

        internal static void Remove(Audio audio)
        {
            m_audios.Remove(audio);
        }

        public static void StopAll()
        {
            for (int i = 0; i < m_audios.Count; i++)
            {
                m_audios[i].Stop();
                i--;
            }
        }

        public static void SetVolume(float volume)
        {
            for (int i = 0; i < m_audios.Count; i++)
            {
                m_audios[i].Volume = volume;
            }
        }

        /// <summary>
        /// 从StreamingAssets内加载一个音频（暂未实现）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioClip Load(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// （暂未实现）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
            AudioClip clip;
            m_clips.TryGetValue(path, out clip);
            if (clip != null)
                return clip;

            clip = Resources.Load<AudioClip>(PathEx.GetPathWithoutExtension(path));
            Resources.UnloadUnusedAssets();
            if (clip != null)
            {
                m_clips[path] = clip;
                return clip;
            }

            return null;
        }

        public static void UnloadResource(string path)
        {
            AudioClip clip;
            m_clips.TryGetValue(path, out clip);
            if (clip == null)
                return;

            clip = m_clips[path];
            m_clips.Remove(path);
            Resources.UnloadAsset(clip);
        }
    }
}
