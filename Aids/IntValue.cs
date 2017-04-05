using System;
using System.Globalization;
using System.Linq;

namespace Aids {
    public static class IntValue {
        public static int GetIntAfter(string s, string key, bool ignoreCase = true) {
            int r;
            TryGetIntAfter(s, key, out r, ignoreCase);
            return r;
        }
        public static bool TryGetIntAfter(string s, string tryGetIntAfterThisString, out int result, bool ignoreCase = true) {
            result = 0;
            if (StringValue.IsNullOrEmpty(s)) return false;
            var idx = StringValue.IndexOfOther(s, tryGetIntAfterThisString, ignoreCase);
            if (IsNegative(idx)) return false;
            var sub = s.Substring(idx + tryGetIntAfterThisString.Length).Trim();
            var val = sub.TakeWhile(char.IsNumber).Aggregate(string.Empty, (current, v) => current + v);
            return tryParse(val, out result);
        }
        public static int GetIntBefore(string s, char c1, int defaultValue) {
            if (StringValue.IsNullOrEmpty(s)) return defaultValue;
            if (!s.Contains(c1)) return defaultValue;
            s = StringValue.GetSubstringBefore(s, c1);
            int i;
            return tryParse(s, out i) ? i : defaultValue;
        }
        public static int GetIntBetweenLast(string s, char c1, char c2, int defaultValue) {
            s = StringValue.GetSubstringAfterLast(s, c1);
            return GetIntBefore(s, c2, defaultValue);
        }

        internal static string toString(int i)
        {
            return i.ToString(UseCulture.Invariant);
        }

        public static int GetIntBetween(string s, char c1, char c2, int defaultValue) {
            s = StringValue.GetSubstringAfter(s, c1);
            return GetIntBefore(s, c2, defaultValue);
        }
        public static bool IsEqual(int a, int b) { return a == b; }
        public static bool IsInteger(object o) {
            int i;
            return tryParse(o.ToString(), out i);
        }
        public static bool IsInteger(string s) {
            int i;
            return tryParse(s, out i);
        }
        public static bool IsNegative(int x) { return x < 0; }
        public static bool IsPositive(int x) { return x > 0; }
        public static bool IsZero(int x) { return x == 0; }
        public static int MinusOne => -1;
        public static string Numbers => "0123456789";
        public static int PlusOne => 1;
        public static int ToInt(object o) {
            int i;
            TryConvertToInt(o, out i);
            return i;
        }
        private static bool tryParse(string s, out int result) {
            return int.TryParse(s, NumberStyles.Any, UseCulture.Invariant, out result);
        }
        public static bool TryConvertToInt(object o, out int i) {
            i = int.MaxValue;
            var r = true;
            var s = o as string;
            if (!ReferenceEquals(null, s)) return tryParse(s, out i);
            if (o is int) i = Convert.ToInt32((int) o);
            else if (o is short) i = Convert.ToInt32((short) o);
            else if (o is sbyte) i = Convert.ToInt32((sbyte) o);
            else if (o is uint) i = Convert.ToInt32((uint) o);
            else if (o is ushort) i = Convert.ToInt32((ushort) o);
            else if (o is byte) i = Convert.ToInt32((byte) o);
            else r = false;
            return r;
        }
        public static int Parse(string s) {
            int i;
            return tryParse(s, out i) ? i : int.MaxValue;
        }
    }
}
