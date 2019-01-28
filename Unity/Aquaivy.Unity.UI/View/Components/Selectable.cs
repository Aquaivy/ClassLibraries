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
    public abstract class Selectable : UIElement, IEnable
    {
        public event PointerGazeEvent Click;
        public event PointerGazeEvent Enter;
        public event PointerGazeEvent Exit;
        public event PointerGazeEvent Down;
        public event PointerGazeEvent Up;

        private static Type inputHandlerType;
        private BaseInputHandler inputHandler;

        public Selectable()
        {
            Enable = true;

            if (inputHandlerType == null)
                inputHandlerType = InputManager.InputHandlerType;

            inputHandler = gameObject.AddComponent(inputHandlerType) as BaseInputHandler;

            RegistEvent();
        }

        private void RegistEvent()
        {
            inputHandler.Click += data => { if (Enable) Click?.Invoke(this, data); };

            inputHandler.Enter += data => { if (Enable) Enter?.Invoke(this, data); };
            inputHandler.Exit += data => { if (Enable) Exit?.Invoke(this, data); };

            inputHandler.Down += data => { if (Enable) Down?.Invoke(this, data); };
            inputHandler.Up += data => { if (Enable) Up?.Invoke(this, data); };
        }

        public virtual bool Enable { get; set; }
    }

}