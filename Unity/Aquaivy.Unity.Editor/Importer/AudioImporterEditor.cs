﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Aquaivy.Unity.Editor
{
    public class AudioImporterEditor
    {
        public static void ChangeAudiosToMono() => ChangeAudios(true);

        public static void ChangeAudiosToStereo() => ChangeAudios(false);


        private static void ChangeAudios(bool mono)
        {
            AudioClip[] selections = Selection.GetFiltered<AudioClip>(SelectionMode.Assets);
            if (selections == null || selections.Length == 0)
            {
                Debug.Log("Please select some assets first");
                return;
            }

            foreach (var asset in selections)
            {

                string path = AssetDatabase.GetAssetPath(asset);
                UnityEditor.AudioImporter clip = global::UnityEditor.AudioImporter.GetAtPath(path) as UnityEditor.AudioImporter;
                clip.forceToMono = mono;

                AssetDatabase.ImportAsset(path);
                Debug.Log($"AudioImporter  {path}");
            }
        }



    }
}
