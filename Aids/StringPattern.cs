using System.Collections;

namespace Aids {
    public static class StringPattern {
        internal const string commaSeparated = "{0}, {1}";
        internal const string moreElements = "{0}...";
        internal const string manyToString = "{0}<{1}>[{2}] = {{{3}}}";
        internal const string many = "Many";
        internal const string element = "Element";
        public static string ToCommaSeparated(string s1, string s2) {
            if (string.IsNullOrEmpty(s2)) s2 = string.Empty;
            return string.IsNullOrEmpty(s1) ? s2 : string.Format(commaSeparated, s1, s2);
        }
        public static string ToMoreElements(string s) {
            if (string.IsNullOrEmpty(s)) s = string.Empty;
            return string.Format(moreElements, s);
        }
        public static string ToManyString(string elementTypeName, int count, string elements, string typeName = null) {
            if (string.IsNullOrEmpty(typeName)) typeName = many;
            if (string.IsNullOrEmpty(elementTypeName)) elementTypeName = element;
            if (string.IsNullOrEmpty(elements)) elements = string.Empty;
            return string.Format(manyToString, typeName, elementTypeName, count, elements);
        }
        public static string ListElements(IEnumerable list, int lenght = 50) {
            var s = string.Empty;
            foreach (var e in list) {
                var s1 = e.ToString();
                s = ToCommaSeparated(s, s1);
                if (s.Length <= lenght) continue;
                s = s.Substring(0, lenght);
                s = ToMoreElements(s);
                break;
            }
            return s;
        }
        internal static string tripletPattern => "{0}{1}{2}";
        internal static string commaPattern => "{0}{1} {2}";
        public static string GetFormat( char separator = ',' ){
            return separator ==Char.Space ? tripletPattern : commaPattern;
        }
    }
}
