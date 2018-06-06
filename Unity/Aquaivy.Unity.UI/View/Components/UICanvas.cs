using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class UICanvas : UIElement
    {
        public Canvas Canvas { get; set; }
        public CanvasScaler CanvasScaler { get; set; }
        public GraphicRaycaster GraphicRaycaster { get; set; }

        public UICanvas(RenderMode mode, Camera camera)
        {
#if UNITY_EDITOR
            Name = "UICanvas";
#endif

            Canvas = gameObject.AddComponent<Canvas>();
            CanvasScaler = gameObject.AddComponent<CanvasScaler>();
            GraphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();

            Canvas.renderMode = mode;
            Canvas.worldCamera = camera;
        }

#if IMPERFECTION
        public UICanvas(GameObject go)
            : base(go)
        {
            Canvas = go.GetComponent<Canvas>();
            CanvasScaler = go.GetComponent<CanvasScaler>();
            GraphicRaycaster = go.GetComponent<GraphicRaycaster>();

            if (Canvas == null)
                throw new NullReferenceException(string.Format("There is no Canvas component on {1}.", go.name));

            if (CanvasScaler == null)
                throw new NullReferenceException(string.Format("There is no CanvasScaler component on {1}.", go.name));

            if (GraphicRaycaster == null)
                throw new NullReferenceException(string.Format("There is no GraphicRaycaster component on {1}.", go.name));
        }
#endif

        //[Obsolete("use \"UICanvas(GameObject go)\" ", false)]
        //public static UICanvas Find(string name)
        //{
        //    var goc = GameObject.Find(name);
        //    if (goc == null)
        //    {
        //        Debug.LogErrorFormat("未找到Canvas【{0}】", name);
        //        return null;
        //    }

        //    var uican = new UICanvas();
        //    GameObject.Destroy(uican.gameObject);
        //    uican.gameObject = goc;
        //    uican.RectTransform = goc.GetComponent<RectTransform>();
        //    uican.Canvas = goc.GetComponent<Canvas>();
        //    uican.CanvasScaler = goc.GetComponent<CanvasScaler>();
        //    uican.GraphicRaycaster = goc.GetComponent<GraphicRaycaster>();

        //    return uican;
        //}

    }
}
