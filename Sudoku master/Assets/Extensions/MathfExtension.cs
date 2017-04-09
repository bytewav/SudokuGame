using UnityEngine;

namespace Catalyst.Core.Utility
{
    public static class MathfExtension 
    {
		public static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4) 
		{
			Vector2 a = p2 - p1;
			Vector2 b = p3 - p4;
			Vector2 c = p1 - p3;

			float alphaNumerator = b.y*c.x - b.x*c.y;
			float alphaDenominator = a.y*b.x - a.x*b.y;
			float betaNumerator  = a.x*c.y - a.y*c.x;
			float betaDenominator  = a.y*b.x - a.x*b.y;

			bool doIntersect = true;

			if (alphaDenominator == 0 || betaDenominator == 0) 
				doIntersect = false;
			else 
			{
				if (alphaDenominator > 0) 
					if (alphaNumerator < 0 || alphaNumerator > alphaDenominator) 
						doIntersect = false;
				else if (alphaNumerator > 0 || alphaNumerator < alphaDenominator) 
					doIntersect = false;

				if (doIntersect && betaDenominator > 0) 
					if (betaNumerator < 0 || betaNumerator > betaDenominator) 
						doIntersect = false;
				else if (betaNumerator > 0 || betaNumerator < betaDenominator) 
					doIntersect = false;
			}

			return doIntersect;
		}
        /// <summary>
        /// Gets the tau.
        /// </summary>
        /// <value>The tau.</value>
        public static float Tau
        {
            get
            {
                return 6.283185307179586476925286766559f;
            }
        }

        /// <summary>
        /// Like a lerp but with ease in and out
        /// </summary>
        /// <returns>The step.</returns>
        /// <param name="x">The value to interpolate.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Maximum.</param>
        public static float SmoothStep(float x, float min, float max)
        {
            x = Mathf.Clamp(x, min, max);
            float v1 = (x - min) / (max - min);
            float v2 = (x - min) / (max - min);
            return -2 * v1 * v1 * v1 + 3 * v2 * v2;
        }

        /// <summary>
        /// Like a lerp but with ease in and out
        /// </summary>
        /// <returns>The step.</returns>
        /// <param name="vec">The value to interpolate.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Maximum.</param>
        public static Vector2 SmoothStep(Vector2 vec, float min, float max)
        {
            return new Vector2(SmoothStep(vec.x,min,max), SmoothStep(vec.y, min, max));
        }

        /// <summary>
        /// Like a lerp but with ease in and out
        /// </summary>
        /// <returns>The step.</returns>
        /// <param name="vec">The value to interpolate.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Maximum.</param>
        public static Vector3 SmoothStep(Vector3 vec, float min, float max)
        {
            return new Vector3(SmoothStep(vec.x, min, max), SmoothStep(vec.y, min, max), SmoothStep(vec.z, min, max));
        }

        /// <summary>
        /// Short for 'boing-like interpolation', this method will first overshoot, then waver back and forth around the end value before coming to a rest.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static float Berp(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }
        /// <summary>
        /// Short for 'boing-like interpolation', this method will first overshoot, then waver back and forth around the end value before coming to a rest.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector2 Berp(Vector2 start, Vector2 end, float value)
        {
            return new Vector2(Berp(start.x,end.x,value), Berp(start.y, end.y, value));
        }
        /// <summary>
        /// Short for 'boing-like interpolation', this method will first overshoot, then waver back and forth around the end value before coming to a rest.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector3 Berp(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Berp(start.x, end.x, value), Berp(start.y, end.y, value), Berp(start.z, end.z, value));
        }

        /// <summary>
        /// EaseOut
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static float Sinerp(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, Mathf.Sin(value * Mathf.PI * 0.5f));
        }

        /// <summary>
        /// EaseOut
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector2 Sinerp(Vector2 start, Vector2 end, float value)
        {
            return new Vector2(Mathf.Lerp(start.x, end.x, Mathf.Sin(value * Mathf.PI * 0.5f)), Mathf.Lerp(start.y, end.y, Mathf.Sin(value * Mathf.PI * 0.5f)));
        }

        /// <summary>
        /// EaseOut
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector3 Sinerp(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Mathf.Lerp(start.x, end.x, Mathf.Sin(value * Mathf.PI * 0.5f)), Mathf.Lerp(start.y, end.y, Mathf.Sin(value * Mathf.PI * 0.5f)), Mathf.Lerp(start.z, end.z, Mathf.Sin(value * Mathf.PI * 0.5f)));
        }

        /// <summary>
        /// Ease in
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static float Coserp(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, 1.0f - Mathf.Cos(value * Mathf.PI * 0.5f));
        }
        /// <summary>
        /// Ease in
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector2 Coserp(Vector2 start, Vector2 end, float value)
        {
            return new Vector2(Coserp(start.x,end.x,value),Coserp(start.y,end.y,value));
        }
        /// <summary>
        /// Ease in
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector3 Coserp(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Coserp(start.x, end.x, value), Coserp(start.y, end.y, value), Coserp(start.z, end.z, value));
        }


        /// <summary>
        /// Returns a value between 0 and 1 in a bounce curve value.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="freq">Frequency of the bounce.</param>
        public static float Bounce(float x,float freq)
        {
            return Mathf.Abs(Mathf.Sin(freq * 6.28f * (x + 1f) * (x + 1f)) * (1f - x));
        }
        /// <summary>
        /// Returns a value between 0 and 1 in a bounce curve value.
        /// </summary>
        /// <param name="vec">The x coordinate.</param>
        /// <param name="freq">Frequency of the bounce.</param>
        public static Vector2 Bounce(Vector2 vec,float freq)
        {
            return new Vector2(Bounce(vec.x,freq),Bounce(vec.y,freq));
        }
        /// <summary>
        /// Returns a value between 0 and 1 in a bounce curve value.
        /// </summary>
        /// <param name="vec">The x coordinate.</param>
        /// <param name="freq">Frequency of the bounce.</param>
        public static Vector3 Bounce(Vector3 vec,float freq)
        {
            return new Vector3(Bounce(vec.x,freq), Bounce(vec.y,freq), Bounce(vec.z,freq));
        }


        /// <summary>
        /// Ease in and out
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static float Hermite(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
        }

        /// <summary>
        /// Ease in and out
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector2 Hermite(Vector2 start, Vector2 end, float value)
        {
            return new Vector2(Hermite(start.x,end.x, value), Hermite(start.y, end.y, value));
        }

        /// <summary>
        /// Ease in and out
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        /// <param name="value">Value.</param>
        public static Vector3 Hermite(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Hermite(start.x, end.x, value), Hermite(start.y, end.y, value), Hermite(start.z, end.z, value));
        }
    }
}
