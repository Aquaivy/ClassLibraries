using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Aquaivy.Unity
{
    public partial class TweenLite
    {
        public static TweenLite To(Color from, Color to, float duration, TweeningFunction tweeningFunction, Action<Color> onupdate, Action onend = null)
        {
            float r = 0;
            float g = 0;
            float b = 0;
            var _rTween = TweenLite.To(from.r, to.r, duration, tweeningFunction, v => r = v);
            var _gTween = TweenLite.To(from.g, to.g, duration, tweeningFunction, v => g = v);
            var _bTween = TweenLite.To(from.b, to.b, duration, tweeningFunction, v => b = v);
            var _aTween = TweenLite.To(from.a, to.a, duration, tweeningFunction, a => onupdate?.Invoke(new Color(r, g, b, a)), onend);

            _aTween.BeforeRelease += () =>
            {
                _rTween.Release();
                _gTween.Release();
                _bTween.Release();
            };

            return _aTween;
        }
    }
}
