using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Aids {
    public static class DateTimeValue {
        public static DateTime FromOaDateString(string s, DateTime? defaultValue = null) {
            var dt = defaultValue ?? DateTime.MinValue;
            double d;
            if (!DoubleValue.TryParse(StringValue.Trim(s), out d)) return dt;
            try {
                return DateTime.FromOADate(d);
            } catch {
                return dt;
            }
        }
        public static string FromOaDateStringToShortTimeString(string s) {
            var dt = FromOaDateString(s);
            return dt == DateTime.MinValue ? s : ToShortTimeString(dt);
        }
        public static string GetDateTimeStringAfter(string s, string after) {
            var s1 = StringValue.GetNumbersAfter(s, after);
            foreach (var c in DateTimePattern.TimeSeparators) {
                var s2 = StringValue.GetNumbersAfter(s, after + s1 + c);
                if (!string.IsNullOrEmpty(s2)) return s1 + c + s2;
            }
            return s1;
        }
        internal static DateTime getDefaultDateTime(bool defaultIsMinValue) {
            return defaultIsMinValue ? DateTime.MinValue : DateTime.MaxValue;
        }
        public static bool IsSameDateOrTime(object o, string s) {
            if (!(o is DateTime)) return false;
            var d = (DateTime) o;
            if (ToShortDateString(d) == s) return true;
            if (ToShortTimeString(d) == s) return true;
            if (ToLongDateString(d) == s) return true;
            if (ToLongTimeString(d) == s) return true;
            return d.ToString(UseCulture.Invariant) == s;
        }
        public static DateTime Parse(string s) { return Parse(s, true); }
        public static DateTime Parse(string s, string after, bool defaultIsMinValue = true) {
            s = GetDateTimeStringAfter(s, after);
            return Parse(s, defaultIsMinValue);
        }
        public static DateTime Parse(string s, bool defaultIsMinValue) {
            return Parse(s, getDefaultDateTime(defaultIsMinValue));
        }
        public static DateTime Parse(string s, DateTime defaultValue) {
            s = MonthsInEnglish.CorrectAbbreviatedName(s);
            DateTime d;
            return TryParse(s, out d) ? d : defaultValue;
        }
        public static DateTime ParseTime(string s, DateTime? dateValue = null, DateTime? defaultTime = null ) {
            var def = defaultTime ?? DateTime.MinValue;
            var date = dateValue ?? DateTime.MinValue;
            s = MonthsInEnglish.CorrectAbbreviatedName(s);
            DateTime time;
            if (!TryParse(s, out time)) time = def;
            return UniteDateAndTime(date, time);
        }
        public static DateTime UniteDateAndTime(DateTime date, DateTime time) {
            return date.Date.Add(time.TimeOfDay);
        }
        public static string ToCorrectHours(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.Length != 8) return s;
            if (s[0] != '0') return s;
            if (s[1] != '0') return s;
            if (s[2] != ':') return s;
            if (s[3] != '0') return s;
            if (s[4] != '0') return s;
            if (s[5] != ':') return s;
            if (!char.IsNumber(s[6])) return s;
            if (!char.IsNumber(s[7])) return s;
            return s.Substring(6, 2) + ":" + s.Substring(0, 5);
        }
        public static string ToLongDateString(DateTime d) {
            return d.ToString(DateTimePattern.LongDate, CultureInfo.InvariantCulture);
        }
        public static string ToLongDateTimeString(DateTime d) {
            return d.ToString(DateTimePattern.LongDateTime, CultureInfo.InvariantCulture);
        }
        public static string ToLongTimeString(DateTime d) {
            return d.ToString(DateTimePattern.LongTime, CultureInfo.InvariantCulture);
        }
        public static string ToLongTimeString(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.Length != 5) return s;
            if (!char.IsNumber(s[0])) return s;
            if (!char.IsNumber(s[1])) return s;
            if (s[2] != ':') return s;
            if (!char.IsNumber(s[3])) return s;
            if (!char.IsNumber(s[4])) return s;
            return s + ":00";
        }
        public static string ToMySqlDate(string s) {
            DateTime d;
            if (!TryParse(s, out d)) return s;
            s = d.ToString((string) DateTimePattern.LongDate);
            return s;
        }
        public static string ToShortDateString(DateTime d) {
            return d.ToString(DateTimePattern.ShortDate, CultureInfo.InvariantCulture);
        }
        public static string ToShortDateTimeString(DateTime d) {
            return d.ToString(DateTimePattern.ShortDateTime, CultureInfo.InvariantCulture);
        }
        public static string ToShortTimeString(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.Length != 2) return s;
            if (!char.IsNumber(s[0])) return s;
            if (!char.IsNumber(s[1])) return s;
            return s + ":00";
        }
        public static string ToShortTimeString(DateTime date, DateTime time) {
            if (date == DateTime.MinValue) return string.Empty;
            return time.TimeOfDay <= DateTime.Parse(DateTimePattern.LongMorning).TimeOfDay
                ? string.Empty
                : ToShortTimeString(time);
        }
        public static string ToShortTimeString(DateTime d) {
            return d.ToString(DateTimePattern.ShortTime, CultureInfo.InvariantCulture);
        }
        public static string ToString(DateTime a) { return ToString(a, (string) DateTimePattern.LongDateTime); }
        public static string ToString(DateTime a, string format) {
            return a.ToString(format, CultureInfo.InvariantCulture);
        }
        public static bool TryParse(string s, out DateTime d) {
            return tryParse(s, out d, DateTimePattern.AllDateTime) ||
                DateTime.TryParse(s, UseCulture.Invariant, DateTimeStyles.None, out d)||
                DateTime.TryParse(s, UseCulture.Current, DateTimeStyles.None, out d);
        }
        internal static bool tryParse(string s, out DateTime d, IEnumerable<string> patterns) {
            d = DateTime.MinValue;
            var d1 = d;
            if (!patterns.Any(f => DateTime.TryParseExact(s, (string) f, UseCulture.Invariant, DateTimeStyles.None, out d1))) return false;
            d = d1;
            return true;
        }
        public static bool TryParseTime(string s, out DateTime d) {
            return tryParse(s, out d, DateTimePattern.AllTime);
        }

        public static bool TryParseDate(string s, out DateTime d) {
            return tryParse(s, out d, DateTimePattern.AllDate);
        }
        public static bool IsDate( string s, out DateTime d){
            return TryParseDate( s, out d );
        }
        public static bool IsTime( string s, out DateTime d ){
            return TryParseTime(s, out d);
        }
        public static bool IsMinOrMaxValue(DateTime d) {
            return IsMinValue(d) || IsMaxValue(d);
        }
        public static bool IsMaxValue(DateTime d) {
            return d == DateTime.MaxValue;
        }
        public static bool IsMinValue(DateTime d) {
            return d == DateTime.MinValue;
        }
        public static object ToString(DateTime d, CultureInfo ci) {
            return d.ToString(ci);
        }
        public static string ToStringUsedInArchiveFileName(DateTime dt) {
            return ToString(dt, (string) DateTimePattern.LongForArchiveFileName);
            
        }
    }
}
