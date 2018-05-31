using System.Collections.Generic;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public static class UIRootManager
    {
        public static UICanvas Canvas { get; private set; }
        public static UINode FormsRoot { get; private set; }

        private static bool inited = false;
        private static List<FrmBase> allForms = new List<FrmBase>();


        public static void Init()
        {
            var canvas = new UICanvas(RenderMode.WorldSpace, null);
            canvas.SetSize(UIConfig.Width, UIConfig.Height);
            Init(canvas);
        }

        public static void Init(UICanvas canvas)
        {
            if (inited)
                return;

            var node = new UINode(0, 0, UIConfig.Width, UIConfig.Height);
            node.Name = "Root";
            node.SetToUpperLeft();
            canvas.AddChild(node);
            FormsRoot = node;

            UIRootManager.Canvas = canvas;

            GameManager.OnUpdate += GameManager_OnUpdate;

            inited = true;
        }

        private static void GameManager_OnUpdate(int elapseTime)
        {
            Update(elapseTime);
        }

        public static void AddForm(FrmBase frm)
        {
            if (!inited)
            {
                Debug.LogError("You need call \"Init()\" method first");
                return;
            }

            if (frm == null)
                return;
            if (allForms.IndexOf(frm) >= 0)
                return;

            FormsRoot.AddChild(frm);
            allForms.Add(frm);
        }

        public static bool RemoveForm(FrmBase frm)
        {
            if (!inited)
            {
                Debug.LogError("You need call \"Init()\" method first");
                return false;
            }

            int index = allForms.IndexOf(frm);
            if (index < 0)
                return false;

            allForms.RemoveAt(index);
            return true;
        }

        private static void Update(int milliseconds)
        {
            if (!inited)
                return;

            for (int i = 0; i < allForms.Count; i++)
            {
                allForms[i].RunUpdate();
            }
        }
    }
}
