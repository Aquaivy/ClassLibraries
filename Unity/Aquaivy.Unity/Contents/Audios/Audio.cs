using Aquaivy.Core.Logs;
using Aquaivy.Unity;
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
    /// 音频对象类
    /// </summary>
    /// <remarks>
    /// 即使勾选了音频文件的"Force to Mono"，播放音频时
    /// 如果stereo为true，仍然为3D立体音
    /// </remarks>
    public class Audio
    {
        /// <summary>
        /// 
        /// </summary>
        public GameObject GameObject { get; }

        /// <summary>
        /// 
        /// </summary>
        public AudioSource AudioSource { get; }

        /// <summary>
        /// 
        /// </summary>
        public AudioClip AudioClip
        {
            get { return AudioSource.clip; }
        }

        /// <summary>
        /// 声音时长，单位：s
        /// </summary>
        public float Length
        {
            get { return AudioClip.length; }
        }

        /// <summary>
        /// 是否循环播放
        /// </summary>
        public bool Loop
        {
            get { return AudioSource.loop; }
            set { AudioSource.loop = value; }
        }

        /// <summary>
        /// 音量
        /// </summary>
        public float Volume
        {
            get { return AudioSource.volume; }
            set { AudioSource.volume = value; }
        }

        /// <summary>
        /// 是否是立体声
        /// </summary>
        public bool IsStereo
        {
            get { return AudioSource.spatialBlend == 1; }
            set { AudioSource.spatialBlend = value ? 1 : 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="audioClip"></param>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        /// <param name="stereo"></param>
        private Audio(AudioClip audioClip, bool loop, float volume, bool stereo)
        {
            GameObject = new GameObject("Audio_" + audioClip.name);
            AudioSource = GameObject.AddComponent<AudioSource>();
            AudioSource.clip = audioClip;
            AudioSource.loop = loop;
            AudioSource.volume = volume;
            AudioSource.spatialBlend = stereo ? 1 : 0;
        }

        /// <summary>
        /// Play
        /// </summary>
        public void Play()
        {
            AudioSource.Play();

            if (!Loop)
            {
                DelayTask.Invoke(() =>
                {
                    Stop();
                }, (int)(AudioClip.length * 1000));
            }
        }

        /// <summary>
        /// Pause
        /// </summary>
        public void Pause()
        {
            AudioSource.Pause();
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            AudioSource.Stop();
            Dispose();
        }

        private void Dispose()
        {
            AudioManager.Remove(this);
            GameObject.Destroy(GameObject);
        }


        /// <summary>
        /// 从StreamingAssets播放一个音频，需要添加.mp3 .wav .ogg等后缀
        /// </summary>
        /// <param name="path">需要添加.mp3 .wav等音频后缀（虽然麻烦，但是辨识度更高）</param>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        /// <param name="stereo"></param>
        /// <returns></returns>
        public static Audio Play(string path, bool loop = false, float volume = 1f, bool stereo = false)
        {
            Log.Info("" + Application.streamingAssetsPath);

            var clip = AudioManager.Load(path);
            if (clip == null)
            {
                Log.Warn($"Load audio fail. path={path}");
                return null;
            }

            return PlayInternal(clip, loop, volume, stereo);
        }

        /// <summary>
        /// 从Resource播放一个音频，需要添加.mp3 .wav .ogg等后缀
        /// </summary>
        /// <param name="path">需要添加.mp3 .wav等音频后缀（虽然麻烦，但是辨识度更高）</param>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        /// <param name="stereo"></param>
        /// <returns></returns>
        public static Audio PlayResource(string path, bool loop = false, float volume = 1f, bool stereo = false)
        {
            var clip = AudioManager.LoadResource(path);
            if (clip == null)
            {
                Log.Warn($"Load audio fail. path={path}");
                return null;
            }

            return PlayInternal(clip, loop, volume, stereo);
        }

        private static Audio PlayInternal(AudioClip clip, bool loop, float volume, bool stereo)
        {
            var audio = new Audio(clip, loop, volume, stereo);

            AudioManager.Add(audio);
            audio.Play();
            return audio;
        }
    }

}
