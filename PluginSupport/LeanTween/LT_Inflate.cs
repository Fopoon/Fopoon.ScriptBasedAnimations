#if LEAN_TWEEN

using UnityEngine;

namespace Fopoon.ScriptBasedAnimations.LeanTweenSupport
{
    public static partial class LTAnimations
    {
        #region Methods

        /// <summary>
        /// Scales a GameObject up and down.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <returns></returns>
        public static LTDescr InflatePingPong(
            GameObject gameObject,
            Vector3 to,
            float time,
            LeanTweenType ease = LeanTweenType.linear)
        {
            return LeanTween.scale(gameObject, to, time)
                            .setEase(ease)
                            .setLoopPingPong();
        }

        /// <summary>
        /// Scales a RectTransform up and down.
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <returns></returns>
        public static LTDescr InflatePingPong(
            RectTransform rectTransform,
            Vector3 to,
            float time,
            LeanTweenType ease = LeanTweenType.linear)
        {
            return LeanTween.scale(rectTransform, to, time)
                            .setEase(ease)
                            .setLoopPingPong();
        }

        #endregion
    }
}

#endif