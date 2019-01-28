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
                maxCellCount = (int)Math.Ceiling(_contentWidth / cellWidth);
                //Log.Info($"_contentWidth:{_contentWidth}    maxCellCount:{maxCellCount}    cellWidth:{cellWidth}");

                RefreshArrowState();
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

                RefreshArrowState();
            }
        }

        public override UIElement AddChild(UIElement element)
        {
            return content.AddChild(element);
        }

        public override void Dispose()
        {
            tl?.Release();
            tl = null;

            base.Dispose();
        }

        private int maxCellCount;
        private int currentCellIndex;
        private float cellWidth = 100;
        private float cellHeight = 100;
        private TweenLite tl;


        public int CurrentCellIndex { get { return currentCellIndex; } }

        /// <summary>
        /// 同时显示出来的cell数量
        /// </summary>
        public int ShownCellCount
        {
            get { return shownCellCount; }

            set
            {
                shownCellCount = value;
                RefreshArrowState();
            }
        }

        private int shownCellCount = 3;

        /// <summary>
        /// 是否显示最后几个的空白（暂时不起作用）
        /// </summary>
        public bool ShowSpace = false;

        public int Duration = 1000;

        public void SetIndex(int index)
        {
            if (index == currentCellIndex)
                return;
        }

        public void SetCellInfo(float cellWidth, float cellHeight)
        {
            if (cellWidth <= 0 || cellHeight <= 0)
                throw new ArgumentException($"cellWidth,cellHeight must greater than 0");

            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;

            maxCellCount = (int)Math.Ceiling(_contentWidth / cellWidth);
            RefreshArrowState();
        }

        /// <summary>
        /// 内容左移
        /// </summary>
        public void MoveLeft()
        {
            //Log.Info($"MoveLeft  currentCellIndex:{currentCellIndex}    targetCellIndex:{currentCellIndex + 1}    ShownCellCount:{ShownCellCount}    maxCellCount:{maxCellCount}");

            if (currentCellIndex + ShownCellCount >= maxCellCount)
            {
                return;
            }

            float from = content.x;
            float to = -(currentCellIndex + 1) * cellWidth;
            currentCellIndex++;

            tl?.Release();
            tl = TweenLite.To(from, to, Duration, Cubic.EaseOut, v =>
            {
                content.x = v;
            });

            RefreshArrowState();
        }

        /// <summary>
        /// 内容右移
        /// </summary>
        public void MoveRight()
        {
            //Log.Info($"MoveRight  currentCellIndex:{currentCellIndex}    targetCellIndex:{currentCellIndex - 1}");

            if (currentCellIndex - 1 < 0)
            {
                return;
            }

            float from = content.x;
            float to = -(currentCellIndex - 1) * cellWidth;
            currentCellIndex--;

            tl?.Release();
            tl = TweenLite.To(from, to, Duration, Cubic.EaseOut, v =>
            {
                content.x = v;
            });

            RefreshArrowState();
        }

        private void RefreshArrowState()
        {
            if (maxCellCount <= ShownCellCount)
            {
                ArrowShownStateChanged?.Invoke(this, new ArrowShownStateEventArgs { State = ArrowShownState.None });
            }
            else if (currentCellIndex + ShownCellCount >= maxCellCount)
            {
                ArrowShownStateChanged?.Invoke(this, new ArrowShownStateEventArgs { State = ArrowShownState.LeftOrTop });
            }
            else if (currentCellIndex - 1 < 0)
            {
                ArrowShownStateChanged?.Invoke(this, new ArrowShownStateEventArgs { State = ArrowShownState.RightOrBottom });
            }
            else
            {
                ArrowShownStateChanged?.Invoke(this, new ArrowShownStateEventArgs { State = ArrowShownState.Both });
            }
        }

        /// <summary>
        /// 下一页（暂未实现）
        /// </summary>
        public void MoveNextPage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 上一页（暂未实现）
        /// </summary>
        public void MovePrevPage()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<ArrowShownStateEventArgs> ArrowShownStateChanged;

    }

    public class ArrowShownStateEventArgs : EventArgs
    {
        public ArrowShownState State { get; set; }
    }

    public enum ArrowShownState
    {
        /// <summary>
        /// 内容数量<=显示数量，不显示左右箭头
        /// </summary>
        None,

        /// <summary>
        /// 左右箭头都显示
        /// </summary>
        Both,

        /// <summary>
        /// 只显示左（上）箭头
        /// </summary>
        LeftOrTop,

        /// <summary>
        /// 只显示右（下）箭头
        /// </summary>
        RightOrBottom,
    }
}
