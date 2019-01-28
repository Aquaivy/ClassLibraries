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
    /// PC平台输入事件处理器
    /// </summary>
    /// 
    /// <remarks>
    /// 自带Enter、Exit、Down、Up效果，
    /// 因此不用自己延迟100ms加Up事件
    /// </remarks>
    public class StandaloneInputHandler : BaseInputHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
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
