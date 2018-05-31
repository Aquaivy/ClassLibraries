using Aquaivy.Unity.UI.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Aquaivy.Unity.UI
{
    public abstract class Selectable : UIElement
    {
        public event PointerGazeEvent Click;
        public event PointerGazeEvent Enter;
        public event PointerGazeEvent Exit;
        //public event PointerGazeEvent Move;

        private static Type inputHandlerType;
        private BaseInputHandler inputHandler;

        public Selectable()
        {
            if (inputHandlerType == null)
                inputHandlerType = InputManager.InputHandlerType;

            inputHandler = gameObject.AddComponent(inputHandlerType) as BaseInputHandler;

            RegistEvent();
        }

        private void RegistEvent()
        {
            inputHandler.Click += data => Click?.Invoke(this, data);
            inputHandler.Enter += data => Enter?.Invoke(this, data);
            inputHandler.Exit += data => Exit?.Invoke(this, data);
            //basePointerHandler.Move += data => Move?.Invoke(this, data);
        }
    }

}