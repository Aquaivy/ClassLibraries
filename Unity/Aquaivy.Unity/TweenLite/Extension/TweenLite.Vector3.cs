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
        public static TweenLite To(Vector3 from, Vector3 to, float duration, TweeningFunction tweeningFunction, Action<Vector3> onupdate, Action onend = null)
        {
            float _x = 0;
            float _y = 0;
            var _xTween = TweenLite.To(from.x, to.x, duration, tweeningFunction, v => _x = v);
            var _yTween = TweenLite.To(from.y, to.y, duration, tweeningFunction, v => _y = v);
            var _zTween = TweenLite.To(from.z, to.z, duration, tweeningFunction, _z => onupdate?.Invoke(new Vector3(_x, _y, _z)), onend);

            _zTween.BeforeRelease += () =>
            {
                _xTween.Release();
                _yTween.Release();
            };

            return _zTween;
        }

        public static TweenLite To(Vector2 from, Vector2 to, float duration, TweeningFunction tweeningFunction, Action<Vector2> onupdate, Action onend = null)
        {
            float _x = 0;
            var _xTween = TweenLite.To(from.x, to.x, duration, tweeningFunction, v => _x = v);
            var _yTween = TweenLite.To(from.y, to.y, duration, tweeningFunction, _y => onupdate?.Invoke(new Vector2(_x, _y)), onend);

            _yTween.BeforeRelease += () =>
            {
                _xTween.Release();
            };

            return _yTween;
        }
    }
}
