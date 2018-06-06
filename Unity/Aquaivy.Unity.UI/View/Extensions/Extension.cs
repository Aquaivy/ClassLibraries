using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    public static class Extension
    {

        public static void DisposeAllChilds(this UIElement element)
        {
            for (int i = element.Childs.Count - 1; i >= 0; i--)
            {
                element.Childs[i].Dispose();
            }
        }

        public static string ToStringEx(this Quaternion q)
        {
            return string.Format("({0:F6},{1:F6},{2:F6},{3:F6})", q.x, q.y, q.z, q.w);
        }

        /// <summary>
        /// 获取所有包含UIImage组件的物体（包含自身和孩子）
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        //public static List<UIElement> GetAllAlphableElements(this UIElement parent)
        //{
        //    var lst = new List<UIElement>();

        //    if (parent is IAlphable)
        //        lst.Add(parent);

        //    foreach (var item in parent.AllChilds)
        //    {
        //        if (item is IAlphable)
        //            lst.Add(item);
        //    }

        //    return lst;
        //}

        //public static List<IAlphable> GetAllAlphable(this UIElement parent)
        //{
        //    var allElements = parent.GetAllAlphableElements();
        //    List<IAlphable> allAlpha = new List<IAlphable>(allElements.Count);
        //    for (int i = 0; i < allElements.Count; i++)
        //    {
        //        allAlpha.Add(allElements[i] as IAlphable);
        //    }

        //    return allAlpha;
        //}

        //public static TweenLite[] FadeInExtension(this UIElement element, float duration, Action callback)
        //{
        //    var all = element.GetAllAlphable();
        //    float[] targetAlpha = new float[all.Count];
        //    for (int i = 0; i < all.Count; i++)
        //    {
        //        targetAlpha[i] = all[i].Alpha;
        //        all[i].Alpha = 0;
        //    }

        //    TweenLite[] tl = new TweenLite[all.Count];

        //    for (int i = 0; i < all.Count; i++)
        //    {
        //        int index = i;

        //        tl[index] = TweenLite.To(0, targetAlpha[index], duration, Linear.EaseIn, v =>
        //        {
        //            all[index].Alpha = v;
        //        }, () =>
        //        {
        //            all[index].Alpha = targetAlpha[index];

        //            //只有在最后一个才回调
        //            if (index == all.Count - 1)
        //            {
        //                //callback();
        //            }
        //        });
        //    }

        //    return tl;
        //}

        //public static TweenLite[] FadeOutExtension(this UIElement element, float duration, Action callback)
        //{
        //    var all = element.GetAllAlphable();
        //    float[] targetAlpha = new float[all.Count];
        //    for (int i = 0; i < all.Count; i++)
        //    {
        //        targetAlpha[i] = all[i].Alpha;
        //    }

        //    TweenLite[] tl = new TweenLite[all.Count];

        //    for (int i = 0; i < all.Count; i++)
        //    {
        //        int index = i;

        //        TweenLite.To(targetAlpha[index], 0, duration, Linear.EaseIn, v =>
        //        {
        //            all[index].Alpha = v;
        //        }, () =>
        //        {
        //            //只有在最后一个才回调
        //            if (index == all.Count - 1)
        //            {
        //                callback();
        //            }
        //        });
        //    }

        //    return tl;
        //}

    }
}
