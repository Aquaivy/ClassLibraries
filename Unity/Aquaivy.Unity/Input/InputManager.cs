using Aquaivy.Unity.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity.Input
{
    public class InputManager
    {
        public static Type InputHandlerType = typeof(StandaloneInputHandler);

        public static void RegisterInputHandler(Type type) => InputHandlerType = type;

        public static void RegisterInputHandler()
        {
#if UNITY_WSA
            RegisterInputHandler(typeof(HololensInputHandler));


#elif SFTOOLKIT
#if UNITY_STANDALONE || UNITY_EDITOR
            RegisterInputHandler(typeof(SunflowerInputHandler));
#else
            RegisterInputHandler(typeof(SunflowerInputHandler));
#endif


#else
            RegisterInputHandler(typeof(StandaloneInputHandler));
#endif
        }
    }
}
