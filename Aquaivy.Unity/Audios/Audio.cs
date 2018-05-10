using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity.Audios
{
    public class Audio
    {
        public GameObject GameObject { get; }
        public AudioSource AudioSource { get; }
        public AudioClip AudioClip { get; }

        public float Length { get { return AudioClip.length; } }
        public bool Loop { get { return AudioSource.loop; } set { AudioSource.loop = value; } }
        public float Volume { get { return AudioSource.volume; } set { AudioSource.volume = value; } }

        /// <summary>
        /// 是否是立体声
        /// </summary>
        public bool IsStereo { get; set; }

        public bool LoadCompleted { get; private set; }

        private bool isPausing = false;
        private bool released = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">需要添加.mp3 .wav等音频后缀</param>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        public Audio(string path, bool loop, float volume)
        {
            path = TrimExtension(path);

            var audioClip = AudioManager.LoadResource(path);
            if (audioClip == null)
            {
                LoadCompleted = false;
                return;
            }

            AudioClip = audioClip;
            GameObject = new GameObject("Audio_" + Path.GetFileName(path));
            AudioSource = GameObject.AddComponent<AudioSource>();

            AudioSource.clip = AudioClip;
            AudioSource.loop = loop;
            AudioSource.volume = volume;

            LoadCompleted = true;
        }

        public void Play()
        {
            AudioSource.Play();
            isPausing = false;

            if (!Loop)
            {
                TaskLite.Invoke(t =>
                {
                    if (released)
                        return true;

                    if (isPausing)
                        return true;

                    if (AudioSource.isPlaying)
                        return false;

                    Destroy(this);
                    return true;
                });
            }
        }

        public void Pause()
        {
            AudioSource.Pause();
            isPausing = true;
        }

        public void Stop()
        {
            AudioSource.Stop();
            Destroy(this);
        }

        private static string TrimExtension(string path)
        {
            var ext = Path.GetExtension(path).ToLower();
            if (ext == ".mp3" || ext == ".wav")
            {
                path = path.Substring(0, path.Length - 4);
            }

            return path;
        }

        private static List<Audio> audios = new List<Audio>(8);
        private static GameObject audiosParent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">需要添加.mp3 .wav等音频后缀</param>
        /// <param name="loop"></param>
        /// <param name="volume"></param>
        /// <param name="stereo"></param>
        /// <returns></returns>
        public static Audio Play(string path, bool loop = false, float volume = 1f, bool stereo = false)
        {
            if (audiosParent == null)
                audiosParent = new GameObject("Audios");

            var audio = new Audio(path, loop, volume);
            if (!audio.LoadCompleted)
                return null;

            audio.GameObject.transform.SetParent(audiosParent.transform);
            audio.IsStereo = stereo;

            audios.Add(audio);

            audio.Play();

            return audio;
        }

        private static void Destroy(Audio audio)
        {
            if (audio == null)
                return;

            audios.Remove(audio);
            GameObject.Destroy(audio.GameObject);
            audio.released = true;
        }
    }

}
