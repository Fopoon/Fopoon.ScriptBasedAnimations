using System.Collections;
using UnityEngine;

namespace Fopoon
{
    public static partial class SBAnimations
    {
        #region Methods

        /// <summary>
        /// Moves the transform from <paramref name="startValue"/> to <paramref name="endValue"/>.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static IEnumerator Move(
            Transform transform,
            Vector3 startValue,
            Vector3 endValue,
            float duration)
        {
            var timePassed = 0f;

            transform.position = startValue;

            while (timePassed < duration)
            {
                yield return null;

                var normalizedTimePassed = Mathf.Clamp01(timePassed / duration);
                var currentValue = Vector3.Lerp(startValue, endValue, normalizedTimePassed);
                transform.position = currentValue;

                timePassed += Time.deltaTime;
            }

            transform.position = endValue;
        }

        /// <summary>
        /// Moves the transform locally from <paramref name="startValue"/> to <paramref name="endValue"/>.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static IEnumerator MoveLocal(
            Transform transform,
            Vector3 startValue,
            Vector3 endValue,
            float duration)
        {
            var timePassed = 0f;

            transform.localPosition = startValue;

            while (timePassed < duration)
            {
                yield return null;

                var normalizedTimePassed = Mathf.Clamp01(timePassed / duration);
                var currentValue = Vector3.Lerp(startValue, endValue, normalizedTimePassed);
                transform.localPosition = currentValue;

                timePassed += Time.deltaTime;
            }

            transform.localPosition = endValue;
        }

        /// <summary>
        /// Moves the transform to a position in screen space from its current position.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="endScreenSpaceValue"></param>
        /// <param name="distanceFromCamera"></param>
        /// <param name="duration"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static IEnumerator ScreenMove(
            Transform transform,
            Vector2 endScreenSpaceValue,
            float distanceFromCamera,
            float duration,
            Camera camera)
        {
            var timePassed = 0f;

            var startValue = transform.position;
            var endValue = camera.ScreenToWorldPoint(
                new Vector3(
                    endScreenSpaceValue.x,
                    endScreenSpaceValue.y,
                    distanceFromCamera));

            while (timePassed < duration)
            {
                yield return null;

                var normalizedTimePassed = Mathf.Clamp01(timePassed / duration);
                var currentValue = Vector3.Lerp(startValue, endValue, normalizedTimePassed);
                transform.position = currentValue;

                timePassed += Time.deltaTime;
            }

            transform.position = endValue;
        }

        /// <summary>
        /// Moves the transform to a position in viewport space from its current position.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="endViewportSpaceValue"></param>
        /// <param name="distanceFromCamera"></param>
        /// <param name="duration"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static IEnumerator ViewportMove(
            Transform transform,
            Vector2 endViewportSpaceValue,
            float distanceFromCamera,
            float duration,
            Camera camera)
        {
            var timePassed = 0f;

            var startValue = transform.position;
            var endValue = camera.ViewportToWorldPoint(
                new Vector3(
                    endViewportSpaceValue.x,
                    endViewportSpaceValue.y,
                    distanceFromCamera));

            while (timePassed < duration)
            {
                yield return null;

                var normalizedTimePassed = Mathf.Clamp01(timePassed / duration);
                var currentValue = Vector3.Lerp(startValue, endValue, normalizedTimePassed);
                transform.position = currentValue;

                timePassed += Time.deltaTime;
            }

            transform.position = endValue;
        }

        /// <summary>
        /// Moves the rect transform to a position in world space from its current position.
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="endWorldSpaceValue"></param>
        /// <param name="duration"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static IEnumerator WorldMove(
            RectTransform rectTransform,
            Vector3 endWorldSpaceValue,
            float duration,
            Camera camera)
        {
            var timePassed = 0f;

            var startValue = rectTransform.anchoredPosition;
            var endValue = camera.WorldToScreenPoint(endWorldSpaceValue);

            while (timePassed < duration)
            {
                yield return null;

                var normalizedTimePassed = Mathf.Clamp01(timePassed / duration);
                var currentValue = Vector2.Lerp(startValue, endValue, normalizedTimePassed);
                rectTransform.anchoredPosition = currentValue;

                timePassed += Time.deltaTime;
            }

            rectTransform.anchoredPosition = endValue;
        }

        #endregion
    }
}