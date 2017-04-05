using System;
using System.Globalization;

namespace Aids {
    public static class DecimalValue {
        public static bool TryParse(string s, out decimal d) {
            return decimal.TryParse(s, NumberStyles.Any,UseCulture.Invariant, out d);
        }
        public static decimal Add(decimal x, decimal y) {
            try {
                return x + y;
            } catch {
                return decimal.MaxValue;
            }
        }
        public static decimal Divide(decimal x, decimal y) {
            try {
                return x/y;
            } catch {
                return decimal.MaxValue;
            }
        }
        public static bool TryConvertToDecimal(object o, out decimal d) {
            d = decimal.Zero;
            var r = true;
            var s = o as string;
            if (s != null) return TryParse(s, out d);
            if (o is decimal) d = (decimal) o;
            else if (o is double) d = Convert.ToDecimal((double) o);
            else if (o is float) d = Convert.ToDecimal((float) o);
            else if (o is long) d = Convert.ToDecimal((long) o);
            else if (o is int) d = Convert.ToDecimal((int) o);
            else if (o is short) d = Convert.ToDecimal((short) o);
            else if (o is sbyte) d = Convert.ToDecimal((sbyte) o);
            else if (o is ulong) d = Convert.ToDecimal((ulong) o);
            else if (o is uint) d = Convert.ToDecimal((uint) o);
            else if (o is ushort) d = Convert.ToDecimal((ushort) o);
            else if (o is byte) d = Convert.ToDecimal((byte) o);
            else r = false;
            return r;
        }
        public static decimal ToDecimal(object o) {
            decimal d;
            TryConvertToDecimal(o, out d);
            return d;
        }
        public static string ToString(decimal a) { return a.ToString(UseCulture.Invariant); }
        public static decimal Subtract(decimal x, decimal y) {
            try {
                return x - y;
            } catch {
                return decimal.MaxValue;
            }
        }
        public static bool IsGreater(decimal x, decimal y) { return IntValue.IsPositive(x.CompareTo(y)); }
        public static bool IsLess(decimal x, decimal y) { return IntValue.IsNegative(x.CompareTo(y)); }
        public static bool IsEqual(decimal x, decimal y) { return x.CompareTo(y) == 0; }
        public static decimal Multiply(decimal x, decimal y) {
            try {
                return x*y;
            } catch {
                return decimal.MaxValue;
            }
        }
        public static decimal Inverse(decimal x) { return Subtract(decimal.Zero, x); }
        public static decimal Reciprocal(decimal x) { return Divide(decimal.One, x); }
        public static decimal Square(decimal x) { return Multiply(x, x); }
    }
}
