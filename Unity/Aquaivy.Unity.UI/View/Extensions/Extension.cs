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


        //public static List<T> GetComponents<T>(this UIElement element)
        //{
        //    var lst = new List<T>();

        //    if (element is T)
        //        lst.Add(element as T);

        //    return null;
        //}

        /// <summary>
        /// 获取所有包含UIImage组件的物体（包含自身和孩子）
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        //public static List<UIElement> GetColorableElements(this UIElement element)
        //{
        //    var lst = new List<UIElement>();

        //    if (element is IColorable)
        //        lst.Add(element);

        //    foreach (var item in element.AllChilds)
        //    {
        //        if (item is IColorable)
        //            lst.Add(item);
        //    }

        //    return lst;
        //}

        //public static List<IColorable> GetAlphableInterfaces(this UIElement element)
        //{
        //    var allElements = element.GetColorableElements();
        //    List<IColorable> allAlpha = new List<IColorable>(allElements.Count);
        //    for (int i = 0; i < allElements.Count; i++)
        //    {
        //        allAlpha.Add(allElements[i] as IColorable);
        //    }

        //    return allAlpha;
        //}

        public static List<IColorable> GetAlphableInterfaces(this UIElement element)
        {
            List<IColorable> lstColorable = new List<IColorable>(4);

            if (element is IColorable)
                lstColorable.Add(element as IColorable);

            var childs = element.AllChilds;
            foreach (var item in childs)
            {
                if (item is IColorable)
                    lstColorable.Add(item as IColorable);
            }

            return lstColorable;
        }

        /// <summary>
        /// 渐渐显示
        /// </summary>
        /// <param name="element"></param>
        /// <param name="duration"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static List<TweenLite> FadeIn(this UIElement element, float duration, Action callback = null)
        {
            var all = element.GetAlphableInterfaces();
            float[] targetAlpha = new float[all.Count];
            for (int i = 0; i < all.Count; i++)
            {
                //targetAlpha[i] = all[i].Alpha;
                targetAlpha[i] = 1;     //这里默认alpha恢复到1吧，不太好处理
                all[i].Alpha = 0;
            }

            List<TweenLite> tl = new List<TweenLite>(all.Count);

            for (int i = 0; i < all.Count; i++)
            {
                int index = i;

                var t = TweenLite.To(0, targetAlpha[index], duration, Linear.EaseIn, v =>
                {
                    all[index].Alpha = v;
                }, () =>
                {
                    all[index].Alpha = targetAlpha[index];

                    //只有在最后一个才回调
                    if (index == all.Count - 1)
                    {
                        callback?.Invoke();
                    }
                });

                tl.Add(t);
            }

            return tl;
        }

        /// <summary>
        /// 渐渐消失
        /// </summary>
        /// <param name="element"></param>
        /// <param name="duration"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static List<TweenLite> FadeOut(this UIElement element, float duration, Action callback = null)
        {
            var all = element.GetAlphableInterfaces();
            float[] targetAlpha = new float[all.Count];
            for (int i = 0; i < all.Count; i++)
            {
                targetAlpha[i] = all[i].Alpha;
            }

            List<TweenLite> tl = new List<TweenLite>(all.Count);

            for (int i = 0; i < all.Count; i++)
            {
                int index = i;

                var t = TweenLite.To(targetAlpha[index], 0, duration, Linear.EaseIn, v =>
                {
                    all[index].Alpha = v;
                }, () =>
                {
                    //只有在最后一个才回调
                    if (index == all.Count - 1)
                    {
                        callback?.Invoke();
                    }
                });

                tl.Add(t);
            }

            return tl;
        }


        //public static List<TweenLite> FlyUp(this UIElement element, float duration, Displacement disY, Displacement disZ, Displacement disRot, Action callback = null)
        //{
        //    List<TweenLite> tl = new List<TweenLite>(128);

        //    //上移
        //    float start_y = element.y;
        //    float end_y = element.y - element.HarfHeight;
        //    var t1 = TweenLite.To(disY.Start, disY.End, duration, Linear.EaseIn, v =>
        //    {
        //        element.y = v;
        //    });

        //    //后移
        //    float start_z = element.z;
        //    float end_z = element.z + element.Height;
        //    var t2 = TweenLite.To(disZ.Start, disZ.End, duration, Linear.EaseIn, v =>
        //    {
        //        element.z = v;
        //    });

        //    //旋转
        //    float start_rot = 0;
        //    float end_rot = 90;
        //    var t3 = TweenLite.To(disRot.Start, disRot.End, duration, Linear.EaseIn, v =>
        //    {
        //        element.SetRotation(v, 0, 0);
        //    });

        //    //逐渐消失
        //    var t4 = element.FadeOut(duration, callback);


        //    tl.Add(t1);
        //    tl.Add(t2);
        //    tl.Add(t3);
        //    tl.AddRange(t4);

        //    return tl;
        //}

        //public static List<TweenLite> FlyDown(this UIElement element, float duration, Displacement disY, Displacement disZ, Displacement disRot, Action callback = null)
        //{
        //    List<TweenLite> tl = new List<TweenLite>(128);

        //    //上移
        //    float start_y = element.y;
        //    float end_y = element.y - element.HarfHeight;
        //    var t1 = TweenLite.To(disY.Start, disY.End, duration, Linear.EaseIn, v =>
        //    {
        //        element.y = v;
        //    });

        //    //后移
        //    float start_z = element.z;
        //    float end_z = element.z + element.Height;
        //    var t2 = TweenLite.To(disZ.Start, disZ.End, duration, Linear.EaseIn, v =>
        //    {
        //        element.z = v;
        //    });

        //    //旋转
        //    float start_rot = 0;
        //    float end_rot = 90;
        //    var t3 = TweenLite.To(disRot.Start, disRot.End, duration, Linear.EaseIn, v =>
        //    {
        //        element.SetRotation(v, 0, 0);
        //    });

        //    //逐渐消失
        //    var t4 = element.FadeIn(duration, callback);


        //    tl.Add(t1);
        //    tl.Add(t2);
        //    tl.Add(t3);
        //    tl.AddRange(t4);

        //    return tl;
        //}
    }
}
