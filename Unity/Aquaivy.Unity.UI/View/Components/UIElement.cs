using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Aquaivy.Unity.UI
{
    /// <summary>
    /// 具有继承关系的UI基类
    /// </summary>
    public abstract class UIElement : BaseElement
    {
        #region Private Field

        private UIElement parent;
        private List<UIElement> lstChild = new List<UIElement>();

        #endregion

        #region Property

        /// <summary>
        /// 返回自己的直系子孩子
        /// </summary>
        public List<UIElement> Childs { get { return lstChild; } }

        /// <summary>
        /// 返回自己的所有子孩子，包括非直系的
        /// </summary>
        public List<UIElement> AllChilds
        {
            get
            {
                List<UIElement> lst = new List<UIElement>();
                FindAllChilds(this, ref lst); return lst;
            }
        }

        /// <summary>
        /// 自身的父节点，可能为null
        /// </summary>
        public UIElement Parent
        {
            get { return parent; }
            set
            {
                if (parent == value)
                    return;

                if (this.RectTransform == null)
                    return;

                //1.移除原先parent的计数
                if (this.parent != null)
                {
                    this.parent.lstChild.Remove(this);
                }

                //2.设置新parent
                if (value != null)
                {
                    this.RectTransform.SetParent(value.RectTransform, false);
                    value.lstChild.Add(this);
                    this.parent = value;
                }
                else
                {
                    this.RectTransform.SetParent(null, false);
                    this.parent = null;
                }

                //3.重新设定transform信息
                //rt.localScale = _scale;
                //this.Position = _position;
            }
        }


        #endregion

        #region Constructor/Destructor Function

        public UIElement()
        {

        }

#if IMPERFECTION
        public UIElement(GameObject go)
            : base(go)
        {

        }
#endif

        #endregion

        #region Method

        /// <summary>
        /// 添加一个孩子
        /// </summary>
        /// <param name="element"></param>
        /// <remarks>
        /// 这里写为虚方法，目的是为了让<see cref="UIScrollRect"/>这种复杂组件好重载
        /// </remarks>
        public virtual UIElement AddChild(UIElement element)
        {
            if (element.Parent != null)
            {
                throw new InvalidOperationException($"{element.Name} 对象已被AddChild到其他节点上");
            }

            element.Parent = this;

            //element.AnchorMin = this.Pivot;
            //element.AnchorMax = this.Pivot;

            ////element.SetPosition(element.Position.x, element.Position.y, element.Position.z);

            return this;
        }

        public virtual void RemoveChild(UIElement element)
        {
            if (element.Parent != this)
                return;

            element.Parent = null;
        }

        private void FindAllChilds(UIElement element, ref List<UIElement> lst)
        {
            foreach (var item in element.Childs)
            {
                if (item.Childs.Count > 0)
                    FindAllChilds(item, ref lst);

                lst.Add(item);
            }
        }



        /// <summary>
        /// 将自身位置设置到父物体的正中心，
        /// Parent不可为null
        /// </summary>
        /// <param name="type">
        /// type==CenterType.Both时Anchor和Pivot都会设置到正中心，
        /// type==CenterType.OnlyPosition时只修改自身x,y值，Parent不可为null
        /// </param>
        public void SetToCenter(CenterType type)
        {
            if (type == CenterType.Both)
            {
                AnchorMin = Anchor.MiddleCenter;
                AnchorMax = Anchor.MiddleCenter;
                Pivot = Anchor.MiddleCenter;
                SetPosition(0, 0);
            }
            else if (type == CenterType.OnlyPosition)
            {
                if (this.Parent != null)
                {
                    if (this.AnchorMin == this.AnchorMax)
                    {
                        float parentx = (0.5f - this.AnchorMin.x) * Parent.Width;
                        float parenty = (0.5f - this.AnchorMin.y) * Parent.Height;

                        float selfx = (this.Pivot.x - 0.5f) * this.Width;
                        float selfy = (this.Pivot.y - 0.5f) * this.Height;

                        SetPosition(parentx + selfx, -(parenty + selfy));
                    }
                    else
                    {
                        Debug.LogError($"\"{Name}\" SetToCenter() error, because \"this.AnchorMin != this.AnchorMax\"");
                    }
                }
                else
                {
                    Debug.LogError($"\"{Name}\" SetToCenter() error, because parent is null");
                }
            }
        }

        /// <summary>
        /// 将anchor和pivot都设置为左上角
        /// </summary>
        public void SetToUpperLeft()
        {
            AnchorMin = Anchor.UpperLeft;
            AnchorMax = Anchor.UpperLeft;
            Pivot = Anchor.UpperLeft;
        }

        protected override void OnUpdate()
        {
            if (!gameObject.activeInHierarchy)
                return;

            base.OnUpdate();

            //这里用倒序更新   是正确逻辑么？
            for (int i = lstChild.Count - 1; i >= 0; i--)
            {
                lstChild[i].OnUpdate();
            }
        }

        public override void Dispose()
        {
            if (lstChild.Count > 0)
            {
                for (int i = lstChild.Count - 1; i >= 0; i--)
                {
                    lstChild[i].Dispose();
                }
            }

            if (Parent != null)
            {
                Parent.RemoveChild(this);
            }

            base.Dispose();
        }

        /// <summary>
        /// 设置渲染顺序（0为第一个，count-1为最后一个）
        /// </summary>
        /// <param name="index"></param>
        public void SetSiblingIndex(int index)
        {
            RectTransform.SetSiblingIndex(index);
        }

        public void SetSiblingFirst()
        {
            RectTransform.SetAsFirstSibling();
        }

        public void SetSiblingLast()
        {
            RectTransform.SetAsLastSibling();
        }


        #endregion
    }
}
