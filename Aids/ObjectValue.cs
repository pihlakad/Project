using System;
using System.Linq;

namespace Aids {
    public static class ObjectValue {
        public static bool IsAllNull(params object[] objects) {
            if (ReferenceEquals(null, objects)) return true;
            return !objects.Any() || objects.All(o => ReferenceEquals(null, o));
        }
        public static bool IsAnyDecimal(object x) {
            if (x is decimal) return true;
            return IsAnyDouble(x);
        }
        public static bool IsAnyDouble(object x) {
            if (x is double) return true;
            if (x is float) return true;
            if (x is ulong) return true;
            return IsAnyLong(x);
        }
        public static bool IsAnyInt(object x) {
            if (x is short) return true;
            if (x is sbyte) return true;
            if (x is ushort) return true;
            if (x is byte) return true;
            return x is int;
        }
        public static bool IsAnyLong(object x) {
            if (x is long) return true;
            if (x is uint) return true;
            return IsAnyInt(x);
        }

        public static bool IsTimeSpan(object x) { return x is TimeSpan; }
        public static bool IsDateTime(object x) { return x is DateTime; }
        public static bool IsString(object x) { return x is string; }
        public static bool IsBool(object x) { return x is bool; }
        public static bool IsLong(object x) { return x is long; }
        public static bool IsInt(object x) { return x is int; }
        public static bool IsShort(object x) { return x is short; }
        public static bool IsSByte(object x) { return x is sbyte; }

        internal static string toString(object x) {
            return IsNull(x) ? string.Empty : x.ToString();
        }
        public static bool IsULong(object x) { return x is ulong; }
        public static bool IsUInt(object x) { return x is uint; }
        public static bool IsUShort(object x) { return x is ushort; }
        public static bool IsByte(object x) { return x is byte; }
        public static bool IsFloat(object x) { return x is float; }
        public static bool IsDouble(object x) { return x is double; }
        public static bool IsDecimal(object x) { return x is decimal; }
        public static bool IsDateTime(params object[] values) { return IsTypeOf(values, IsDateTime); }
        public static bool IsString(params object[] values) { return IsTypeOf(values, IsString); }
        public static bool IsBool(params object[] values) { return IsTypeOf(values, IsBool); }
        public static bool IsDouble(params object[] values) { return IsTypeOf(values, IsDouble); }
        public static bool IsFloat(params object[] values) { return IsTypeOf(values, IsFloat); }
        public static bool IsDecimal(params object[] values) { return IsTypeOf(values, IsDecimal); }
        public static bool IsAnyDouble(params object[] values) { return IsTypeOf(values, IsAnyDouble); }
        public static bool IsAnyDecimal(params object[] values) { return IsTypeOf(values, IsAnyDecimal); }
        private static bool IsTypeOf(object[] values, Func<object, bool> isTypeOf) {
            if (ReferenceEquals(null, values)) return false;
            return values.Any() && values.All(isTypeOf);
        }

        internal static bool isTimeSpan(params object[] values)
        {
            return IsTypeOf(values, IsTimeSpan);
        }

        public static bool IsAnyInt(params object[] values)
        {
            return IsTypeOf(values, IsAnyInt);
        }
        internal static bool isAnyLong(params object[] values)
        {
            return IsTypeOf(values, IsAnyLong);
        }
        public static bool IsNull(object o) { return ReferenceEquals(null, o); }
        public static bool IsAnyNull(params object[] objects)
        {
            if (ReferenceEquals(null, objects)) return true;
            if (!objects.Any()) return true;
            return objects.Any(o => ReferenceEquals(null, o));
        }
    }
}
