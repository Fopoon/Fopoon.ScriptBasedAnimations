using System.Collections;
using UnityEngine;

namespace Fopoon
{
    public static partial class ScriptBasedAnimations
    {
        #region Methods

        /// <summary>
        /// Scales the transform from <paramref name="startValue"/> to <paramref name="endValue"/>.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static IEnumerator Scale(
            Transform transform,
            Vector3 startValue,
            Vector3 endValue,
            float duration)
        {
            var timePassed = 0f;

            transform.localScale = startValue;

            while (timePassed < duration)
            {
                yield return null;

                var normalizedTimePassed = Mathf.Clamp01(timePassed / duration);
                var currentValue = Vector3.Lerp(startValue, endValue, normalizedTimePassed);
                transform.localScale = currentValue;

                timePassed += Time.deltaTime;
            }

            transform.localScale = endValue;
        }

        /// <summary>
        /// Scales the transform with respect to its current local scale.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="startScalarValue"></param>
        /// <param name="endScalarValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static IEnumerator Scale(
            Transform transform,
            float startScalarValue,
            float endScalarValue,
            float duration)
        {
            var localScale = transform.localScale;
            var startValue = localScale * startScalarValue;
            var endValue = localScale * endScalarValue;

            yield return Scale(
                transform,
                startValue,
                endValue,
                duration);
        }

        #endregion
    }
}