#if LEAN_TWEEN

using System;
using UnityEngine;

namespace Fopoon.ScriptBasedAnimations.LeanTweenSupport
{
    public static partial class LTAnimations
    {
        /// <summary>
        /// Fades in while scaling the CanvasGroup to one.
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="duration"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        public static void PopIn(
            CanvasGroup canvasGroup,
            float duration,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            const float TO = 1f;

            PopInternal(
                canvasGroup,
                TO,
                duration,
                ease,
                onComplete);
        }

        /// <summary>
        /// Fades out while scaling the CanvasGroup to zero.
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="duration"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        public static void PopOut(
            CanvasGroup canvasGroup,
            float duration,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            const float TO = 0f;

            PopInternal(
                canvasGroup,
                TO,
                duration,
                ease,
                onComplete);
        }

        /// <summary>
        /// Fades in while scaling the GameObject to one.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="duration"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        public static void PopIn(
            GameObject gameObject,
            float duration,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            const float TO = 1f;

            PopInternal(
                gameObject,
                TO,
                duration,
                ease,
                onComplete);
        }

        /// <summary>
        /// Fades out while scaling the GameObject to zero.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="duration"></param>
        /// <param name="ease"></param>
        /// <param name="onComplete"></param>
        public static void PopOut(
            GameObject gameObject,
            float duration,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            const float TO = 0f;

            PopInternal(
                gameObject,
                TO,
                duration,
                ease,
                onComplete);
        }

        private static void PopInternal(
            CanvasGroup canvasGroup,
            float to,
            float duration,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            var fadeFinished = false;
            var scaleFinished = false;

            void Start()
            {
                FadeStart();
                ScaleStart();
            }

            void FadeStart()
            {
                LeanTween.alphaCanvas(
                             canvasGroup,
                             to,
                             duration)
                         .setEase(ease)
                         .setOnComplete(FadeEnd);
            }

            void ScaleStart()
            {
                LeanTween.scale(
                             canvasGroup.gameObject,
                             to * Vector3.one,
                             duration)
                         .setEase(ease)
                         .setOnComplete(ScaleEnd);
            }

            void FadeEnd()
            {
                fadeFinished = true;

                if (fadeFinished && scaleFinished)
                    OnComplete();
            }

            void ScaleEnd()
            {
                scaleFinished = true;

                if (fadeFinished && scaleFinished)
                    OnComplete();
            }

            void OnComplete()
            {
                onComplete?.Invoke();
            }

            Start();
        }

        private static void PopInternal(
            GameObject gameObject,
            float to,
            float duration,
            LeanTweenType ease = LeanTweenType.linear,
            Action onComplete = null)
        {
            var fadeFinished = false;
            var scaleFinished = false;

            void Start()
            {
                FadeStart();
                ScaleStart();
            }

            void FadeStart()
            {
                LeanTween.alpha(
                             gameObject,
                             to,
                             duration)
                         .setEase(ease)
                         .setOnComplete(FadeEnd);
            }

            void ScaleStart()
            {
                LeanTween.scale(
                             gameObject,
                             to * Vector3.one,
                             duration)
                         .setEase(ease)
                         .setOnComplete(ScaleEnd);
            }

            void FadeEnd()
            {
                fadeFinished = true;

                if (fadeFinished && scaleFinished)
                    OnComplete();
            }

            void ScaleEnd()
            {
                scaleFinished = true;

                if (fadeFinished && scaleFinished)
                    OnComplete();
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