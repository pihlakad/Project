using System;
using System.Globalization;

namespace Aids {
    public static class FloatValue {
        public static float Parse(string s) {
            float f;
            return TryParse(s, out f) ? f : float.NaN;
        }
        public static bool TryParse(string s, out float f) {
            return float.TryParse(s, NumberStyles.Any, UseCulture.Invariant, out f);
        }
        public static float Multiply(float x, float y) { return x * y; }
        public static bool IsZero( float x ) { return Math.Abs( x - 0 ) <= float.Epsilon; }
        public static string ToString(float x) { return x.ToString(UseCulture.Invariant); }
        public static float GetDeltaRange(float x) {
            return Math.Abs(x / 1E6f);
        }
        public static bool IsEqual(float x, float y) {
            return x.Equals(y);
        }
        public static bool IsAlmost(float a, float b, float epsilon) {
            return Math.Abs(a - b) <= epsilon;
        }
        public static bool IsAlmost(float a, float b) {
            return IsAlmost(a, b, GetDeltaRange(a));
        }
    }
}
