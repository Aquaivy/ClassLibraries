#if SFTOOLKIT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aquaivy.Unity.Input
{
    /// <summary>
    /// Sunflower平台输入事件处理器
    /// </summary>
    /// 
    /// <remarks>
    /// Sunflower点击时会在同一帧依次触发Down、Up、Click事件，
    /// 所以看不到Down的Highlight效果，
    /// 这里需要抛弃IPointerDownHandler, IPointerUpHandler，并自己模拟Down、Up事件
    /// </remarks>
    public class SunflowerInputHandler : BaseInputHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Click?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Enter?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Exit?.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Down?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Up?.Invoke(eventData);
        }
    }

}
#endif