#if LEAN_TWEEN

using System;
using UnityEngine;

namespace Fopoon.ScriptBasedAnimations.LeanTweenSupport
{
    public static partial class LTAnimations
    {
        #region Methods

        /// <summary>
        /// Rotates the gameObject back and forth around the given axis.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        /// <param name="duration"></param>
        /// <param name="loops"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        public static void Wobble(
            GameObject gameObject,
            Vector3 axis,
            float angle,
            float duration,
            int loops,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            loops = Mathf.Clamp(loops, 0, int.MaxValue);

            var wobbleDuration = duration / (loops + 1);
            var halfWobbleDuration = wobbleDuration * 0.5f;
            var halfAngle = angle * 0.5f;

            void Start()
            {
                WobbleStart();
            }

            void WobbleStart()
            {
                LeanTween.rotateAroundLocal(gameObject, axis, -halfAngle, halfWobbleDuration)
                         .setEase(ease)
                         .setOnComplete(() =>
                         {
                             if (loops == 0)
                                 WobbleEnd();
                             else
                                 WobbleLoop();
                         });
            }

            void WobbleLoop()
            {
                LeanTween.rotateAroundLocal(gameObject, axis, angle, halfWobbleDuration)
                         .setLoopPingPong(loops)
                         .setEase(ease)
                         .setOnComplete(WobbleEnd);
            }

            void WobbleEnd()
            {
                LeanTween.rotateAroundLocal(gameObject, axis, halfAngle, halfWobbleDuration)
                         .setEase(ease)
                         .setOnComplete(OnComplete);
            }

            void OnComplete()
            {
                onComplete?.Invoke();
            }

            Start();
        }

        #endregion
    }
}

#endif