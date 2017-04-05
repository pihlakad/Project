using System;

namespace Aids {
    public static class TimeSpanValue {
        public static int GetSeconds(TimeSpan x) { return x.Seconds; }
        public static int GetMinutes(TimeSpan x) { return x.Minutes; }
        public static int GetHours(TimeSpan x) { return x.Hours; }
        public static int GetDays(TimeSpan x) {  return x.Days; }
    }
}
