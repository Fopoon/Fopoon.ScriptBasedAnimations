#if LEAN_TWEEN

using UnityEngine;

namespace Fopoon.ScriptBasedAnimations.LeanTweenSupport
{
    public static partial class LTAnimations
    {
        #region Methods

        /// <summary>
        /// Moves a GameObject along the Y-axis up and down.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <returns></returns>
        public static LTDescr BouncePingPong(
            GameObject gameObject,
            float to,
            float time,
            LeanTweenType ease = LeanTweenType.linear)
        {
            return LeanTween.moveY(gameObject, to, time)
                            .setEase(ease)
                            .setLoopPingPong();
        }

        /// <summary>
        /// Moves a RectTransform along the Y-axis up and down.
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="ease"></param>
        /// <returns></returns>
        public static LTDescr BouncePingPong(
            RectTransform rectTransform,
            float to,
            float time,
            LeanTweenType ease = LeanTweenType.linear)
        {
            return LeanTween.moveY(rectTransform, to, time)
                            .setEase(ease)
                            .setLoopPingPong();
        }

        #endregion
    }
}

#endif