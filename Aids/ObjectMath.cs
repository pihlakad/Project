using System;

namespace Aids {
    public static class ObjectMath {
        public static object Add(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.Add((bool) x, (bool) y);
            if (ObjectValue.IsString(x, y)) return StringValue.Add((string) x, (string) y);
            if (ObjectValue.IsDateTime(x, y)) return DateTimeMath.Add((DateTime) x, (DateTime) y);
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.Add(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            if (ObjectValue.IsAnyDecimal(x, y)) return DecimalValue.Add(DecimalValue.ToDecimal(x), DecimalValue.ToDecimal(y));
            return null;
        }
        public static object Subtract(object x, object y) {
            if (ObjectValue.IsDateTime(x, y)) return DateTimeMath.Subtract((DateTime) x, (DateTime) y);
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.Subtract(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            if (ObjectValue.IsAnyDecimal(x, y)) return DecimalValue.Subtract(DecimalValue.ToDecimal(x), DecimalValue.ToDecimal(y));
            return null;
        }
        public static object And(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.And((bool) x, (bool) y);
            return null;
        }
        public static object Or(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.Or((bool) x, (bool) y);
            return null;
        }
        public static object Xor(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.Xor((bool) x, (bool) y);
            return null;
        }
        public static object Not(object x) {
            if (ObjectValue.IsBool(x)) return BooleanValue.Not((bool) x);
            return null;
        }
        public static bool IsEqual(object x, object y) {
            if (ObjectValue.IsDateTime(x, y)) return DateTimeMath.IsEqual((DateTime)x, (DateTime)y);
            if (ObjectValue.IsFloat(x, y)) return FloatValue.IsAlmost((float)x, (float)y);
            if (ObjectValue.IsDouble(x, y)) return DoubleMath.IsAlmost((double)x, (double)y);
            if (ObjectValue.IsDecimal(x, y)) return DecimalValue.IsEqual((decimal)x, (decimal)y);
            return x.Equals(y);
        }
        public static object IsGreater(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.IsGreater((bool) x, (bool) y);
            if (ObjectValue.IsString(x, y)) return StringValue.IsGreater((string) x, (string) y);
            if (ObjectValue.IsDateTime(x, y)) return DateTimeMath.IsGreater((DateTime) x, (DateTime) y);
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.IsGreater(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            if (ObjectValue.IsAnyDecimal(x, y)) return DecimalValue.IsGreater(DecimalValue.ToDecimal(x), DecimalValue.ToDecimal(y));
            return null;
        }
        public static object IsLess(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.IsLess((bool) x, (bool) y);
            if (ObjectValue.IsString(x, y)) return StringValue.IsLess((string) x, (string) y);
            if (ObjectValue.IsDateTime(x, y)) return DateTimeMath.IsLess((DateTime) x, (DateTime) y);
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.IsLess(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            if (ObjectValue.IsAnyDecimal(x, y)) return DecimalValue.IsLess(DecimalValue.ToDecimal(x), DecimalValue.ToDecimal(y));
            return null;
        }
        public static object GetSeconds(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetSeconds((DateTime) x);
            if (ObjectValue.IsTimeSpan(x)) return TimeSpanValue.GetSeconds((TimeSpan) x);
            return null;
        }
        public static object GetMinutes(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetMinutes((DateTime) x);
            if (ObjectValue.IsTimeSpan(x)) return TimeSpanValue.GetMinutes((TimeSpan) x);
            return null;
        }
        public static object GetHours(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetHours((DateTime) x);
            if (ObjectValue.IsTimeSpan(x)) return TimeSpanValue.GetHours((TimeSpan) x);
            return null;
        }
        public static object GetDays(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetDays((DateTime) x);
            if (ObjectValue.IsTimeSpan(x)) return TimeSpanValue.GetDays((TimeSpan) x);
            return null;
        }
        public static object GetMonths(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetMonths((DateTime) x);
            return null;
        }
        public static object GetYears(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetYears((DateTime) x);
            return null;
        }
        public static object AddSeconds(object x, object y) {
            if (!ObjectValue.IsAnyDouble(y)) return null;
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.AddSeconds((DateTime) x, DoubleValue.ToDouble(y));
            return null;
        }
        public static object AddMinutes(object x, object y) {
            if (!ObjectValue.IsAnyDouble(y)) return null;
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.AddMinutes((DateTime) x, DoubleValue.ToDouble(y));
            return null;
        }
        public static object AddHours(object x, object y) {
            if (!ObjectValue.IsAnyDouble(y)) return null;
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.AddHours((DateTime) x, DoubleValue.ToDouble(y));
            return null;
        }
        public static object AddDays(object x, object y)
        {
            if (!ObjectValue.IsAnyDouble(y)) return null;
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.AddDays((DateTime)x, DoubleValue.ToDouble(y));
            return null;
        }
        public static object AddMonths(object x, object y) {
            if (!ObjectValue.IsAnyInt(y)) return null;
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.AddMonths((DateTime) x, IntValue.ToInt(y));
            return null;
        }
        public static object AddYears(object x, object y) {
            if (!ObjectValue.IsAnyInt(y)) return null;
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.AddYears((DateTime) x, IntValue.ToInt(y));
            return null;
        }
        public static object GetInterval(object x, object y) {
            if (ObjectValue.IsDateTime(x, y)) return DateTimeMath.getInterval((DateTime) x, (DateTime) y);
            return null;
        }
        public static object GetAge(object x) {
            if (ObjectValue.IsDateTime(x)) return DateTimeMath.GetAge((DateTime) x);
            return null;
        }
        public static object GetLength(object x) {
            if (ObjectValue.IsString(x)) return StringValue.GetLength((string) x);
            return null;
        }
        public static object ToUpper(object x) {
            if (ObjectValue.IsString(x)) return StringValue.ToUpper((string) x);
            return null;
        }
        public static object ToLower(object x) {
            if (ObjectValue.IsString(x)) return StringValue.ToLower((string) x);
            return null;
        }
        public static object Trim(object x) {
            if (ObjectValue.IsString(x)) return StringValue.Trim((string) x);
            return null;
        }
        public static object Substring(object x, object y) {
            if (ObjectValue.IsString(x) && ObjectValue.IsAnyInt(y)) return StringValue.Substring((string) x, IntValue.ToInt(y));
            return null;
        }
        public static object Substring(object x, object y, object z) {
            if (ObjectValue.IsString(x) && ObjectValue.IsAnyInt(y, z)) return StringValue.Substring((string) x, IntValue.ToInt(y), IntValue.ToInt(z));
            return null;
        }
        public static object Contains(object x, object y) {
            if (ObjectValue.IsString(x, y)) return StringValue.Contains((string) x, (string) y);
            return null;
        }
        public static object EndsWith(object x, object y) {
            if (ObjectValue.IsString(x, y)) return StringValue.EndsWith((string) x, (string) y);
            return null;
        }
        public static object StartsWith(object x, object y) {
            if (ObjectValue.IsString(x, y)) return StringValue.StartsWith((string) x, (string) y);
            return null;
        }
        public static object Multiply(object x, object y) {
            if (ObjectValue.IsBool(x, y)) return BooleanValue.Multiply((bool) x, (bool) y);
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.Multiply(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            if (ObjectValue.IsAnyDecimal(x, y)) return DecimalValue.Multiply(DecimalValue.ToDecimal(x), DecimalValue.ToDecimal(y));
            return null;
        }
        public static object Divide(object x, object y) {
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.Divide(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            if (ObjectValue.IsAnyDecimal(x, y)) return DecimalValue.Divide(DecimalValue.ToDecimal(x), DecimalValue.ToDecimal(y));
            return null;
        }
        public static object Power(object x, object y) {
            if (ObjectValue.IsAnyDouble(x, y)) return DoubleMath.Power(DoubleValue.ToDouble(x), DoubleValue.ToDouble(y));
            return null;
        }
        public static object Inverse(object x) {
            if (ObjectValue.IsAnyDouble(x)) return DoubleMath.Inverse(DoubleValue.ToDouble(x));
            if (ObjectValue.IsAnyDecimal(x)) return DecimalValue.Inverse(DecimalValue.ToDecimal(x));
            return null;
        }
        public static object Reciprocal(object x) {
            if (ObjectValue.IsAnyDouble(x)) return DoubleMath.Reciprocal(DoubleValue.ToDouble(x));
            if (ObjectValue.IsAnyDecimal(x)) return DecimalValue.Reciprocal(DecimalValue.ToDecimal(x));
            return null;
        }
        public static object Square(object x) {
            if (ObjectValue.IsAnyDouble(x)) return DoubleMath.Square(DoubleValue.ToDouble(x));
            if (ObjectValue.IsAnyDecimal(x)) return DecimalValue.Square(DecimalValue.ToDecimal(x));
            return null;
        }
        public static object Sqrt(object x) {
            if (ObjectValue.IsAnyDouble(x)) return DoubleMath.Sqrt(DoubleValue.ToDouble(x));
            return null;
        }
    }
}