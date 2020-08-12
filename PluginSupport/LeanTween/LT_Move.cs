#if LEAN_TWEEN

using System;
using UnityEngine;

namespace Fopoon.ScriptBasedAnimations.LeanTweenSupport
{
    public static partial class LTAnimations
    {
        #region Methods

        /// <summary>
        /// Moves a GameObject to the given world point.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        /// <returns></returns>
        public static LTDescr Move(
            GameObject gameObject,
            Vector3 to,
            float time,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            var ltDescr = LeanTween.move(gameObject, to, time)
                                   .setEase(ease);

            if (onComplete != null)
                ltDescr.setOnComplete(onComplete);

            return ltDescr;
        }

        /// <summary>
        /// Moves a RectTransform to the given world point.
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        /// <returns></returns>
        public static LTDescr Move(
            RectTransform rectTransform,
            Vector3 to,
            float time,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            var ltDescr = LeanTween.move(rectTransform, to, time)
                                   .setEase(ease);

            if (onComplete != null)
                ltDescr.setOnComplete(onComplete);

            return ltDescr;
        }

        /// <summary>
        /// Moves a GameObject to the given local point.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        /// <returns></returns>
        public static LTDescr MoveLocal(
            GameObject gameObject,
            Vector3 to,
            float time,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            var ltDescr = LeanTween.moveLocal(gameObject, to, time)
                                   .setEase(ease);

            if (onComplete != null)
                ltDescr.setOnComplete(onComplete);

            return ltDescr;
        }

        #endregion
    }
}

#endif