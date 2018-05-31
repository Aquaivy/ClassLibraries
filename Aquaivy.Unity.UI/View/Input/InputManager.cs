using Aquaivy.Unity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity.UI.Input
{
    public class InputManager
    {
        public static Type InputHandlerType = typeof(StandaloneInputHandler);

        public static void RegisterInputHandler(Type type) => InputHandlerType = type;
    }
}
