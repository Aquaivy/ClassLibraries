using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Aquaivy.Unity.Input
{
    public class BaseHoldHandler
    {
        public Action<PointerEventData> BaginHold;
        public Action<PointerEventData> HoldCompleted;
        public Action<PointerEventData> HoldCanceled;
    }
}
