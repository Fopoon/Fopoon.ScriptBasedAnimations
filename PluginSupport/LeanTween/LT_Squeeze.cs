#if LEAN_TWEEN

using System;
using UnityEngine;

namespace Fopoon.ScriptBasedAnimations.LeanTweenSupport
{
    public static partial class LTAnimations
    {
        /// <summary>
        /// Scales the gameObject using the <paramref name="squeezeScalar"/> and back to its original scale.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="squeezeScalar"></param>
        /// <param name="durationIn"></param>
        /// <param name="durationOut"></param>
        /// <param name="onComplete"></param>
        public static void SqueezeInOut(
            GameObject gameObject,
            float squeezeScalar,
            float durationIn,
            float durationOut,
            Action onComplete = null)
        {
            var originalScale = gameObject.transform.localScale;
            var squeezedScale = originalScale * squeezeScalar;

            void Start()
            {
                SqueezeIn();
            }

            void SqueezeIn()
            {
                LeanTween.scale(gameObject, squeezedScale, durationIn)
                         .setOnComplete(SqueezeOut);
            }

            void SqueezeOut()
            {
                LeanTween.scale(gameObject, originalScale, durationOut)
                         .setOnComplete(OnComplete);
            }

            void OnComplete()
            {
                onComplete?.Invoke();
            }

            Start();
        }
    }
}

#endif