using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Unity.UI
{
    interface ISequenceFrame
    {
        int Index { get; set; }
        int Rate { get; set; }
        bool Loop { get; set; }
        void Play();
        void Pause();
        void Stop();
        void SkipToFirstFrame();
        void SkipToLastFrame();
    }
}
