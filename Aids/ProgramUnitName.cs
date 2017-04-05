using System.Linq;

namespace Aids {
    public static class ProgramUnitName{
        public static int CountParts(string s, char separator) {
            var r = 0;
            if (StringValue.IsNullOrEmpty(s)) return r;
            r = s.Count(c => c == separator);
            return ++r;
        }
        public static string Top( string n ){
            var r = StringValue.GetSubstringBefore( n, '.' );
            return r;
        }
        public static string Tail( string n ){
            var r = StringValue.GetSubstringAfter( n, '.' );
            return r;
        }
        public static bool IsStructured( string n ){
            if (StringValue.IsNullOrEmpty( n )) return false;
            n = n.Trim( '.' );
            var i = CountParts( n, '.' );
            return i > 1;
        }
        public static bool IsIndexed( string n ){
            var i = IntValue.GetIntBetweenLast( n, '[', ']', IntValue.MinusOne );
            if (i == IntValue.MinusOne) return false;
            var s = $"{i}{']'}";
            return StringValue.Ends( n, s );
        }
        public static string GetName( string n ){
            if (StringValue.IsNullOrEmpty( n )) return string.Empty;
            if (!IsIndexed( n )) return n;
            n = StringValue.GetSubstringBeforeLast( n, '[' );
            return n;
        }
        public static int GetIndex( string n ){
            if (StringValue.IsNullOrEmpty( n )) return IntValue.MinusOne;
            var s = IntValue.GetIntBetweenLast(n, '[', ']', IntValue.MinusOne);
            return !IsIndexed( n ) ? IntValue.MinusOne : s;
        }
        public static string GetPart( string s, char separator, int afterIdx ){
            if (StringValue.IsNullOrEmpty( s )) return string.Empty;
            for (var i = 0; i < afterIdx; i++) s = StringValue.GetSubstringAfter( s, separator );
            return StringValue.GetSubstringBefore( s, separator );
        }
    }
}