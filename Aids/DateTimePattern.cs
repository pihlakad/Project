using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Aids {
    public static class DateTimePattern {
        public static ReadOnlyCollection<string> AllDate {
            get {
                var r = new List<string>();
                r.AddRange(AllMonthFirst);
                r.AddRange(AllDayFirst);
                return new ReadOnlyCollection<string>(r);
            }
        }
        public static ReadOnlyCollection<string> AllDateTime {
            get {
                var s = new List<string>();
                s.AddRange(AllDate);
                s.AddRange(AllTime);
                foreach (var d in AllDate) {
                    foreach (var t in AllTime) {
                        s.Add(string.Format(Dot, d, t));
                        s.Add(string.Format(Space, d, t));
                        s.Add(string.Format(Invariant, d, t));
                    }
                }
                return new ReadOnlyCollection<string>(s);
            }
        }
        public static ReadOnlyCollection<string> AllDayFirst {
            get {
                var s = new []{
                    "dd.MM.yyyy",
                    "dd.M.yyyy",
                    "d.MM.yyyy",
                    "d.M.yyyy",
                    "dd.MM.yy",
                    "dd.M.yy",
                    "d.MM.yy",
                    "d.M.yy",
                    "dd/MM/yyyy",
                    "dd/M/yyyy",
                    "d/MM/yyyy",
                    "d/M/yyyy",
                    "dd/MM/yy",
                    "dd/M/yy",
                    "d/MM/yy",
                    "d/M/yy",
                    "dd-MM-yyyy",
                    "dd-M-yyyy",
                    "d-MM-yyyy",
                    "d-M-yyyy",
                    "dd-MM-yy",
                    "dd-M-yy",
                    "d-MM-yy",
                    "d-M-yy",
                };
                return new ReadOnlyCollection<string>(s);
            }
        }
        public static ReadOnlyCollection<string> AllMonthFirst {
            get {
                var s = new [] {
                    "yyyy.MM.dd",
                    "yyyy.MM.d",
                    "yyyy.M.dd",
                    "yyyy.M.d",
                    "yy.MM.dd",
                    "yy.MM.d",
                    "yy.M.dd",
                    "yy.M.d",
                    "yyyy/MM/dd",
                    "yyyy/MM/d",
                    "yyyy/M/dd",
                    "yyyy/M/d",
                    "yy/MM/dd",
                    "yy/MM/d",
                    "yy/M/dd",
                    "yy/M/d",
                    "yyyy-MM-dd",
                    "yyyy-MM-d",
                    "yyyy-M-dd",
                    "yyyy-M-d",
                    "yy-MM-dd",
                    "yy-MM-d",
                    "yy-M-dd",
                    "yy-M-d",
                };
                return new ReadOnlyCollection<string>(s);
            }
        }
        public static ReadOnlyCollection<string> AllTime {
            get {
                var s = new [] {
                    "H.m.s",
                    "H:m:s",
                    "HH.mm.ss",
                    "HH:mm:ss",
                    "HH.mm.s",
                    "HH:mm:s",
                    "HH.m.ss",
                    "HH:m:ss",
                    "H.mm.ss",
                    "H:mm:ss",
                    "HH.m.s",
                    "HH:m:s",
                    "H.m.ss",
                    "H:m:ss",
                    "H.mm.s",
                    "H:mm:s",
                    "H.mm",
                    "H:mm",
                    "HH.m",
                    "HH:m",
                    "HH.mm",
                    "HH:mm",
                    "H.m",
                    "H:m",
                    "H:m.s",
                    "HH:mm.ss",
                    "HH:mm.s",
                    "HH:m.ss",
                    "H:mm.ss",
                    "HH:m.s",
                    "H:m.ss",
                    "H:mm.s"
                };
                return new ReadOnlyCollection<string>(s);
            }
        }
        public static string Dot => "{0}.{1}";
        public static string LongMorning => "08:00:00";
        public static string LongMidnight => "00:00:00";
        public static string LongDateTime => "yyyy-MM-dd HH:mm:ss";
        public static string LongTime => "HH:mm:ss";
        public static string LongDate => "yyyy-MM-dd";
        public static string Invariant => "{0}T{1}";
        public static string ShortDate => LongDate;
        public static string ShortDateTime => "yyyy-MM-dd HH:mm";
        public static string ShortMidnight => "00:00";
        public static string ShortMorning => "08:00";
        public static string ShortTime => "HH:mm";
        public static string Space => "{0} {1}";
        public static string ShortForFileName => "yy.MM.dd";
        //TODO: try to refactore those following two to be one instead of two different
        public static string LongForFileName => "yy.MM.dd.HH.mm.ss";
        public static string LongForArchiveFileName => "dd.MM.yyyy.HH.mm.ss";
        public static string TimeSeparators => ". Tt";
        public static bool IsTimeOnly(string pattern) { return AllTime.Contains(pattern); }
        public static bool IsDateOnly(string pattern) { return AllDate.Contains(pattern); }
        public static bool IsDateTime(string pattern) {
            if (IsTimeOnly(pattern)) return false;
            return !IsDateOnly(pattern) && IsCorrect(pattern);
        }
        public static bool IsCorrect(string pattern) { return AllDateTime.Contains(pattern); }
    }
}