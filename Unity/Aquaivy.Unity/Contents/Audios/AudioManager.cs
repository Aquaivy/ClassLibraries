﻿using Aquaivy.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity
{
    /// <summary>
    /// 音频资源管理器。
    /// 加载过的audio会缓存在这里，
    /// 便于下次更快速的加载
    /// </summary>
    public static class AudioManager
    {
        //clip resources
        private static Dictionary<string, AudioClip> s_clips = new Dictionary<string, AudioClip>();
        //all playing audios
        private static List<Audio> s_audios = new List<Audio>(8);

        private static GameObject s_audiosParent;

        internal static void Add(Audio audio)
        {
            s_audios.Add(audio);

            if (s_audiosParent == null)
            {
                s_audiosParent = new GameObject("Audios");
                GameObject.DontDestroyOnLoad(s_audiosParent);
            }

            audio.GameObject.transform.SetParent(s_audiosParent.transform);
        }

        internal static void Remove(Audio audio)
        {
            s_audios.Remove(audio);
        }

        /// <summary>
        /// 停止播放所有声音
        /// </summary>
        public static void StopAll()
        {
            for (int i = 0; i < s_audios.Count; i++)
            {
                s_audios[i].Stop();
                i--;
            }
        }

        /// <summary>
        /// 设置所有音量的大小
        /// </summary>
        /// <param name="volume"></param>
        public static void SetVolume(float volume)
        {
            for (int i = 0; i < s_audios.Count; i++)
            {
                s_audios[i].Volume = volume;
            }
        }

        /// <summary>
        /// 从StreamingAssets内加载一个音频（暂未实现，因为暂未找到直接读取MP3文件的方式，目前只能读AssetBundle）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioClip Load(string path)
        {
            //var name = Path.GetFileName(path);
            //var bytes = File.ReadAllBytes(path);
            //AudioClip clip = AudioClip.Create(name, 843264, 2, 32000, true);
            //clip.SetData(Convert.ToSingle(), 0);
            //return clip;

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
            s_clips.TryGetValue(path, out clip);
            if (clip != null)
                return clip;

            clip = Resources.Load<AudioClip>(PathEx.GetPathWithoutExtension(path));
            Resources.UnloadUnusedAssets();
            if (clip != null)
            {
                s_clips[path] = clip;
                return clip;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void UnloadResource(string path)
        {
            AudioClip clip;
            s_clips.TryGetValue(path, out clip);
            if (clip == null)
                return;

            clip = s_clips[path];
            s_clips.Remove(path);
            Resources.UnloadAsset(clip);
        }
    }
}
