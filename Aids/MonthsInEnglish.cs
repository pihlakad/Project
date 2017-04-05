using System;

namespace Aids
{
    public static class MonthsInEnglish
    {
        public static string CorrectAbbreviatedName(string s) {
            if (StringValue.IsNullOrEmpty(s)) return string.Empty;
            var o = StringValue.RemoveAllNumbers(s);
            o = StringValue.RemoveAllNotLettersAndNumbers(o);
            if (StringValue.IsNullOrEmpty(o)) return s;
            var c = GetCode(o);
            var n = GetAbbreviatedName(c);
            if (string.IsNullOrEmpty(n)) return s;
            s = s.Replace(o, n);
            return s;
        }
        public static string GetAbbreviatedName(int i, bool toUpper = true) {
            var f = UseCulture.English.DateTimeFormat;
            Func<int, string> name = x => {
                var m = f.GetAbbreviatedMonthName(x);
                if (toUpper) m = m.ToUpper();
                return m;
            };
            if (i < 1) return string.Empty;
            if (i > 12) return string.Empty;
            return name(i);
        }
        public static string GetCodeAsString(string s, int len) {
            return StringValue.AddChars(StringSerialization.String(GetCode(s)), len, Char.Zero);
        }
        public static int GetCode(string s) {
            if (StringValue.IsNullOrEmpty(s)) return (int)MonthCode.Unknown;
            var c = UseCulture.English;
            var f = c.DateTimeFormat;
            for (var i = MonthCode.January; i <= MonthCode.December; i++) {
                var m = f.MonthNames[(int)i - 1];
                if (!StringValue.Starts(m, s)) continue;
                return (int)i;
            }
            return (int) MonthCode.Unknown;
        }
    }
}
