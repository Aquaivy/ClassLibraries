using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Aquaivy.Unity.UI
{
    public class UIScrollRect : UIElement
    {
        public ScrollRect scrollRect { get; set; }
        public UIMask viewport { get; set; }
        public UINode content { get; set; }

        public Layout layout = Layout.Horizontal;

        private float scrollrectWidth = 100f;         //可视区域宽度
        private float scrollrectHeight = 100f;        //可视区域高度
        private float _contentWidth = 100f;     //内容宽度
        private float _contentHeight = 100f;    //内容高度

        private bool isNeedMask = false;

        /// <summary>
        /// 默认Pivot在左上角
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="layout"></param>
        public UIScrollRect(float x, float y, float width, float height, Layout layout)
            : this(x, y, width, height, layout, Anchor.UpperLeft, true)
        {
        }

        public UIScrollRect(float x, float y, float width, float height, Layout layout, Vector2 pivot)
            : this(x, y, width, height, layout, pivot, true)
        {
        }

        public UIScrollRect(float x, float y, float width, float height, Layout layout, Vector2 pivot, bool isNeedMask)
        {
#if UNITY_EDITOR
            Name = "ScrollRect";
#endif

            this.scrollrectWidth = width;
            this.scrollrectHeight = height;
            this.isNeedMask = isNeedMask;
            this.layout = layout;

            Pivot = pivot;
            SetPosition(x, y);
            Size = new Vector2(width, height);

            // 1. ScrollRect 组件
            scrollRect = gameObject.AddComponent<ScrollRect>();
            scrollRect.horizontal = layout == Layout.Horizontal || layout == Layout.Grid;
            scrollRect.vertical = layout == Layout.Vertical || layout == Layout.Grid;

            // 2. 裁切区域
            if (isNeedMask)
            {
                viewport = new UIMask(0, 0, 0, 0, false);
                viewport.Name = "Viewport";
                base.AddChild(viewport);
                viewport.AnchorMin = Vector2.zero;
                viewport.AnchorMax = Vector2.one;
            }

            // 3. 内容区
            content = new UINode(0, 0);
            content.Name = "Content";
            ContentWidth = width;
            ContentHeight = height;

            // 4. 给ScrollRect赋值
            if (isNeedMask)
            {
                viewport.AddChild(content);
            }
            else
            {
                base.AddChild(content);
            }

            // 5. 修复Anchor
            //if (layout == Layout.Horizontal)
            //{
            //    content.AnchorMin = UIUtils.UpperLeft;
            //    content.AnchorMax = UIUtils.UpperRight;
            //}
            //else if (layout == Layout.Vertical)
            //{
            //    content.AnchorMin = UIUtils.LowerLeft;
            //    content.AnchorMax = UIUtils.UpperLeft;
            //}
            //else if (layout == Layout.Grid)
            //{
            //    content.AnchorMin = UIUtils.UpperLeft;
            //    content.AnchorMax = UIUtils.UpperRight;
            //}

            content.AnchorMin = Anchor.UpperLeft;
            content.AnchorMax = Anchor.UpperLeft;

            scrollRect.content = content.RectTransform;
            if (isNeedMask)
            {
                scrollRect.viewport = viewport.RectTransform;
            }
        }

        public float ContentWidth
        {
            get { return _contentWidth; }
            set
            {
                switch (layout)
                {
                    case Layout.Horizontal:
                        //content.Width = value - scrollrectWidth;
                        content.Width = value;
                        break;
                    case Layout.Vertical:
                        content.Width = value;
                        break;
                    case Layout.Grid:
                        //content.Width = value - scrollrectWidth;
                        content.Width = value;
                        break;
                }
                _contentWidth = value;
            }
        }

        public float ContentHeight
        {
            get { return _contentHeight; }
            set
            {
                switch (layout)
                {
                    case Layout.Horizontal:
                        content.Height = value;
                        break;
                    case Layout.Vertical:
                        content.Height = value;
                        break;
                    case Layout.Grid:
                        content.Height = value;
                        break;
                }
                _contentHeight = value;
            }
        }

        public override UIElement AddChild(UIElement element)
        {
            return content.AddChild(element);
        }
    }
}
