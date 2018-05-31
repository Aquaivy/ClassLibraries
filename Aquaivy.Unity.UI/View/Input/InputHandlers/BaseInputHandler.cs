using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aquaivy.Unity.UI.Input
{
    public class BaseInputHandler : MonoBehaviour
    {
        public Action<PointerEventData> Click;
        public Action<PointerEventData> Enter;
        public Action<PointerEventData> Exit;
        //public Action<PointerEventData> Move;
    }
}
