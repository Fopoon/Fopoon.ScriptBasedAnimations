using System.Collections;
using UnityEngine;

namespace Fopoon
{
    public static partial class SBAnimations
    {
        #region Methods

        /// <summary>
        /// Scales the transform using the <paramref name="squeezeScalar"/> and back to its original scale.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="squeezeScalar"></param>
        /// <param name="durationIn"></param>
        /// <param name="durationOut"></param>
        /// <returns></returns>
        public static IEnumerator SqueezeInOut(
            Transform transform,
            float squeezeScalar,
            float durationIn,
            float durationOut)
        {
            var localScale = transform.localScale;
            var originalScale = localScale;
            var squeezedScale = localScale * squeezeScalar;

            yield return Scale(transform, originalScale, squeezedScale, durationIn);
            yield return Scale(transform, squeezedScale, originalScale, durationOut);
        }

        #endregion
    }
}