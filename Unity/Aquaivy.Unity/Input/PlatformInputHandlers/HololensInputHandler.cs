#if UNITY_WSA
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aquaivy.Unity.Input
{
#if UNITY_EDITOR
    public class HololensInputHandler : BaseInputHandler, IInputClickHandler, IFocusable, IPointerClickHandler
#else
    public class HololensInputHandler : BaseInputHandler, IInputClickHandler, IFocusable
#endif
    {

#if UNITY_EDITOR
        public void OnPointerClick(PointerEventData eventData)
        {
            Click?.Invoke(eventData);
        }
#endif

        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("Hololens Click");

            Click?.Invoke(null);
        }

        public void OnFocusEnter()
        {
            Debug.Log("Hololens Enter");
            Enter?.Invoke(null);
        }

        public void OnFocusExit()
        {
            Debug.Log("Hololens Exit");

            Exit?.Invoke(null);
        }
    }

}
#endif