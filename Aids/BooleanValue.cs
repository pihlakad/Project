using System.Linq;

namespace Aids {
    public static class BooleanValue {
        internal static string[] anyTrueString { get; }= {"TRUE", "T", "YES", "Y"};
        internal static string[] anyFalseString { get; } = { "FALSE", "F", "NO", "N", string.Empty };
        public static bool Not(bool b) { return !b; }
        public static bool And(bool x, bool y) { return x && y; }
        public static bool Or(bool x, bool y) { return x || y; }
        public static bool Xor(bool x, bool y) { return x ^ y; }
        public static bool IsGreater(bool x, bool y) { return IntValue.IsPositive(x.CompareTo(y)); }
        public static bool IsNotGreater(bool x, bool y) { return !IntValue.IsPositive(x.CompareTo(y)); }
        public static bool IsLess(bool x, bool y) { return IntValue.IsNegative(x.CompareTo(y)); }
        public static bool IsNotLess(bool x, bool y) { return !IntValue.IsNegative(x.CompareTo(y)); }
        public static bool Add(bool x, bool y) { return Or(x, y); }
        public static bool Multiply(bool x, bool y) { return And(x, y); }
        public static bool Parse(string s) {
            s = ToCorrectBoolean(s);
            if (string.IsNullOrEmpty(s)) return false;
            bool b;
            return bool.TryParse(s, out b) && b;
        }
        public static string ToCorrectBoolean(string s) {
            if (IsAnyTrueString(s)) return true.ToString(UseCulture.Invariant);
            if (IsAnyFalseString(s)) return false.ToString(UseCulture.Invariant);
            return s;
        }
        public static bool IsAnyFalseString(string s) {
            return Safe.Run(()=>anyFalseString.ToList().Contains(s.ToUpper().Trim()), false);
        }
        public static bool IsAnyTrueString(string s) {
            return Safe.Run(() => anyTrueString.ToList().Contains(s.ToUpper().Trim()), false);
        }

        public static string ToString(bool value)
        {
            return value.ToString(UseCulture.Invariant);
        }
    }
}
