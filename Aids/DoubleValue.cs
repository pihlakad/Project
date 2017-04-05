using System;
using System.Globalization;

namespace Aids {
    public static class DoubleValue {
        public static bool IsDouble(object o) {
            if (ObjectValue.IsNull(o)) return false;
            if (o is double) return true;
            double i;
            return TryParse(o.ToString(), out i);
        }
        public static double Next(double x) {
            if (double.IsNaN(x)) return x;
            if (double.IsPositiveInfinity(x)) return x;
            if (double.IsNegativeInfinity(x)) return double.MinValue;
            var bits = BitConverter.DoubleToInt64Bits(x);
            if (x > 0) return BitConverter.Int64BitsToDouble(bits + 1);
            if (x < 0) return BitConverter.Int64BitsToDouble(bits - 1);
            return double.Epsilon;
        }
        public static double Parse(string s) {
            double d;
            return TryParse(s, out d) ? d : double.NaN;
        }
        public static double Previous(double x) {
            if (double.IsNaN(x)) return x;
            if (double.IsNegativeInfinity(x)) return x;
            if (double.IsPositiveInfinity(x)) return double.MaxValue;
            var bits = BitConverter.DoubleToInt64Bits(x);
            if (x > 0) return BitConverter.Int64BitsToDouble(bits - 1);
            if (x < 0) return BitConverter.Int64BitsToDouble(bits + 1);
            return -double.Epsilon;
        }
        public static double ToDouble(object o) {
            double d;
            TryConvertToDouble(o, out d);
            return d;
        }
        public static bool TryParse(string s, out double d) {
            return double.TryParse(s, NumberStyles.Any,UseCulture.Invariant, out d);
        }
        public static string ToString(double a) {
            return a.ToString(UseCulture.Invariant);
        }
        public static bool TryConvertToDouble(object o, out double d) {
            d = double.NaN;
            var r = true;
            var s = o as string;
            if (s != null) return TryParse(s, out d);
            if (o is double) d = (double) o;
            else if (o is float) d = Convert.ToDouble((float) o);
            else if (o is long) d = Convert.ToDouble((long) o);
            else if (o is int) d = Convert.ToDouble((int) o);
            else if (o is short) d = Convert.ToDouble((short) o);
            else if (o is sbyte) d = Convert.ToDouble((sbyte) o);
            else if (o is ulong) d = Convert.ToDouble((ulong) o);
            else if (o is uint) d = Convert.ToDouble((uint) o);
            else if (o is ushort) d = Convert.ToDouble((ushort) o);
            else if (o is byte) d = Convert.ToDouble((byte) o);
            else if (o is decimal) d = Convert.ToDouble((decimal)o);
            else r = false;
            return r;
        }
    }
}

