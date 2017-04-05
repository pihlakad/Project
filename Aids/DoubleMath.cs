using System;

namespace Aids {
    public static class DoubleMath {
        public static double Add(double x, double y) {
            return x + y;
        }
        public static double GetDeltaRange(double d) {
            return Math.Abs(d/1E7);
        }
        public static double Divide(double x, double y) {
            return x/y;
        }
        public static double Inverse(double x) {
            return -x;
        }
        public static bool IsAlmost(double a, double b, double epsilon) {
            return Math.Abs(a - b) < epsilon;
        }
        public static bool IsAlmost(double a, double b) {
            return IsAlmost(a, b, GetDeltaRange(a) );
        }
        public static bool IsEqual(double x, double y) {
            return double.Equals(x, y);
        }
        public static bool IsGreater(double x, double y) {
            return IntValue.IsPositive(x.CompareTo(y));
        }
        public static bool IsLess(double x, double y) {
            return IntValue.IsNegative(x.CompareTo(y));
        }
        public static double Multiply(double x, double y) {
            return x*y;
        }
        public static double Power(double x, double y) {
            return Math.Pow(x, y);
        }
        public static double Reciprocal(double x) {
            return 1/x;
        }
        public static double Sqrt(double x) {
            return Math.Sqrt(x);
        }
        public static double Subtract(double x, double y) {
            return x - y;
        }
        public static double Square(double x) {
            return x*x;
        }
    }
}
