using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aquaivy.Unity.UI.Input
{
    public class StandaloneInputHandler : BaseInputHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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

        //public void OnGazeMove(PointerEventData data)
        //{
        //    //使用下面这行获取cursor照射在物体上的位置
        //    //transform.InverseTransformPoint(data.pointerCurrentRaycast.worldPosition)

        //    Move?.Invoke(data);
        //}
    }
}
