using System;

namespace Aids {
    public static class DateTimeMath {
        public static DateTime AddDays(DateTime x, double y) { return Safe.Run(() => x.AddDays(y), DateTime.MaxValue); }
        public static DateTime AddHours(DateTime x, double y) { return Safe.Run(() => x.AddHours(y), DateTime.MaxValue); }
        public static DateTime AddMinutes(DateTime x, double y) { return Safe.Run(() => x.AddMinutes(y), DateTime.MaxValue); }
        public static DateTime AddMonths(DateTime x, int y) { return Safe.Run(() => x.AddMonths(y),DateTime.MaxValue); }
        public static DateTime AddSeconds(DateTime x, double y) { return Safe.Run(() => x.AddSeconds(y), DateTime.MaxValue); }
        public static DateTime AddYears(DateTime x, int y) { return Safe.Run(() => x.AddYears(y), DateTime.MaxValue); }
        public static DateTime Add(DateTime x, DateTime y) { return Safe.Run(() => x.Add(TimeSpan.FromTicks(y.Ticks)),DateTime.MaxValue); }
        public static int GetAge(DateTime dt, DateTime? reference = null) {
            Func<int> getAge = () => {
                var now = reference ?? DateTime.Now;
                var age = now.Year - dt.Year;
                if (now < dt.AddYears(age)) age--;
                return age;
            };
            return Safe.Run(getAge, int.MaxValue);
        }
        public static int GetDays(DateTime x) { return Safe.Run(() => x.Day, int.MaxValue); }
        public static int GetHours(DateTime x) { return Safe.Run(() => x.Hour, int.MaxValue); }
        public static int GetMinutes(DateTime x) { return Safe.Run(() => x.Minute, int.MaxValue); }
        internal static TimeSpan getInterval(DateTime x, DateTime y) { return Safe.Run(() => x.Subtract(y), TimeSpan.MaxValue); }
        public static int GetMonths(DateTime x) { return Safe.Run(() => x.Month, int.MaxValue); }
        public static int GetSeconds(DateTime x) { return Safe.Run(() => x.Second, int.MaxValue); }
        public static int GetYears(DateTime x) { return Safe.Run(() => x.Year, int.MaxValue); }
        public static bool HasNoTime(DateTime d) {
            Func<bool> hasNoTime = () => {
                var s = d.ToString(DateTimePattern.LongTime);
                return StringValue.Starts(DateTimePattern.LongMidnight, s);
            };
            return Safe.Run(hasNoTime, false);
        }
        public static bool IsEqual(DateTime a, DateTime b) { return Safe.Run(() => DateTime.Compare(a, b) == 0, false); }
        public static bool IsLess(DateTime a, DateTime b) { return Safe.Run(() => DateTime.Compare(a, b) < 0, false); }
        public static bool IsGreater(DateTime a, DateTime b) { return Safe.Run(() => DateTime.Compare(a, b) > 0, false); }
        public static DateTime Subtract(DateTime d1, DateTime d2) {
            Func<DateTime> subtract = () => {
                var ts = TimeSpan.FromTicks(d2.Ticks);
                return d1.Subtract(ts);
            };
            return Safe.Run(subtract, DateTime.MaxValue);
        }
    }
}
