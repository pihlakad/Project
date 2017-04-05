using System;
using System.Globalization;
using System.Linq;

namespace Aids {
    public static class StringValue {
        public static string GetNumbersAfter(string s, string after) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (string.IsNullOrEmpty(after)) return string.Empty;
            if (!s.Contains(after)) return string.Empty;
            s = s.Substring(s.IndexOf(after, StringComparison.Ordinal) + after.Length);
            var r = s.TakeWhile(c => !char.IsLetter(c)).Aggregate(string.Empty, (current, c) => current + c);
            return r.Trim();
        }
        public static bool HasValue(string s) {
            s = Trim(s);
            return !string.IsNullOrEmpty(s);
        }
        public static string IfNullSetEmpty(string s) {
            return s ?? string.Empty;
        }
        public static int IndexOf(string s, string value) {
            s = IfNullSetEmpty(s);
            value = IfNullSetEmpty(value);
            if (string.IsNullOrEmpty(s)) return -1;
            if (string.IsNullOrEmpty(value)) return -1;
            return s.IndexOf(value, StringComparison.Ordinal);
        }
        public static int IndexOf(string s, char c) {
            s = IfNullSetEmpty(s);
            if (string.IsNullOrEmpty(s)) return -1;
            return s.IndexOf(c);
        }
        public static bool IsEmpty(string x) {
            return (x != null) && string.IsNullOrEmpty(x);
        }
        public static bool IsGreater(string s1, string s2) {
            var r = string.Compare(s1, s2, StringComparison.Ordinal);
            return r > 0;
        }
        public static bool IsLess(string s1, string s2) {
            var r = string.Compare(s1, s2, StringComparison.Ordinal);
            return r < 0;
        }
        public static bool IsNull(string s) {
            return s == null;
        }
        public static bool IsNullOrEmpty(string s) {
            return IsNull(s) || IsEmpty(s);
        }
        public static bool IsNullOrEmpty(object o, bool trim = false)
        {
            if (ReferenceEquals(o, null)) return true;
            var s = o as string;
            if (string.IsNullOrEmpty(s)) return true;
            if (trim) s = s.Trim();
            return IsNullOrEmpty(s);
        }
        public static bool IsNullOrEmpty(string s, bool trim) {
            if (IsNullOrEmpty(s)) return true;
            if (trim) s = s.Trim();
            return IsNullOrEmpty(s);
        }
        public static string Trim(string s) {
            return IfNullSetEmpty(s).Trim();
        }
        public static string Trim(string s, params char[] trimChars) {
            trimChars = trimChars ?? new[] {Char.Space};
            return (s ?? string.Empty).Trim(trimChars);
        }
        public static bool Contains(string s1, string s2, bool ignoreCase, bool trim = true)
        {
            if (IsNullOrEmpty(s1)) return false;
            if (IsNullOrEmpty(s2)) return false;
            ToUpper(ref s1, ignoreCase);
            TrimOther(ref s1, trim);
            ToUpper(ref s2, ignoreCase);
            TrimOther(ref s2, trim);
            return s1.Contains(s2);
        }
        public static bool Contains(string s1, string s2) {
            if (string.IsNullOrEmpty(s1)) return false;
            if (string.IsNullOrEmpty(s2)) return false;
            return s1.Contains(s2);
        }
        public static bool Ends(string s1, string s2, bool ignoreCase = true, bool trim = true)
        {
            if (IsNullOrEmpty(s1)) return false;
            if (IsNullOrEmpty(s2)) return false;
            TrimOther(ref s1, trim);
            TrimOther(ref s2, trim);
            return s1.EndsWith(s2, ignoreCase,UseCulture.English);
        }
        public static int IndexOfOther(string s1, string s2, bool ignoreCase = true, bool trim = true)
        {
            if (IsNullOrEmpty(s1)) return -1;
            if (IsNullOrEmpty(s2)) return -1;
            ToUpper(ref s1, ignoreCase);
            ToUpper(ref s2, ignoreCase);
            TrimOther(ref s1, trim);
            TrimOther(ref s2, trim);
            return s1.IndexOf(s2, StringComparison.Ordinal);
        }
        public static int IndexOfOther(int after, string s1, string s2, bool ignoreCase = true, bool trim = true)
        {
            if (after < 0) return IndexOfOther(s1, s2, ignoreCase, trim);
            if (after > s1.Length - 1) return -1;
            if (IsNullOrEmpty(s1)) return -1;
            if (IsNullOrEmpty(s2)) return -1;
            ToUpper(ref s1, ignoreCase);
            ToUpper(ref s2, ignoreCase);
            TrimOther(ref s1, trim);
            TrimOther(ref s2, trim);
            return s1.IndexOf(s2, after, StringComparison.Ordinal);
        }
        public static int IndexOfOther(string s, CharacterType t, PositionCode p)
        {
            Func<char, bool> isThis = x => {
                switch (t)
                {
                    case CharacterType.Letter:
                        return char.IsLetter(x);
                    case CharacterType.NotLetter:
                        return !char.IsLetter(x);
                    case CharacterType.LetterOrSpace:
                        return char.IsLetter(x) || (x ==Char.Space);
                    case CharacterType.Number:
                        return char.IsNumber(x);
                    default:
                        return false;
                }
            };
            if (IsNullOrEmpty(s)) return IntValue.MinusOne;
            if (p == PositionCode.Start)
            {
                for (var i = 0; i < s.Length; i++) if (isThis(s[i])) return i;
                return IntValue.MinusOne;
            }
            for (var i = s.Length - 1; i > IntValue.MinusOne; i--) if (isThis(s[i])) return i;
            return IntValue.MinusOne;
        }
        public static string UndefinedIfEmpty(string s)
        {
            if (IsNullOrEmpty(s)) return CommonTag.Undefined;
            return s;
        }

        public static int GetLength(string x)
        {
            if (!string.IsNullOrEmpty(x)) return x.Length;
            return 0;
        }

        public static bool StartsWithDigit(string s, bool trim = false)
        {
            if (IsNullOrEmpty(s)) return false;
            if (trim) s = s.Trim();
            if (IsNullOrEmpty(s)) return false;
            var c = s[0];
            return char.IsDigit(c);
        }

        public static string ToLower(string s) {
            return string.IsNullOrEmpty(s) ? string.Empty: s.ToLower();
        }
        public static string ToUpper(string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : s.ToUpper();
        }

        public static string Substring(string s, int startIndex)
        {
            if (!string.IsNullOrEmpty(s)) return s.Substring(startIndex);
            return string.Empty;
        }
        public static string Substring(string s, int startIndex, int length)
        {
            if (!string.IsNullOrEmpty(s)) return s.Substring(startIndex, length);
            return string.Empty;
        }

        public static bool EndsWith(string x, string y) {
            if (string.IsNullOrEmpty(x)) return false;
            if (string.IsNullOrEmpty(y)) return false;
            return x.EndsWith(y);
        }

        public static bool StartsWith(string x, string y) {
            if (string.IsNullOrEmpty(x)) return false;
            if (string.IsNullOrEmpty(y)) return false;
            return x.StartsWith(y);
        }

        public static bool Starts(string s, string startsWith, bool ignoreCase = true, bool trim = true)
        {
            if (IsNullOrEmpty(s)) return false;
            if (IsNullOrEmpty(startsWith)) return false;
            TrimOther(ref s, trim);
            TrimOther(ref startsWith, trim);
            return s.StartsWith(startsWith, ignoreCase,UseCulture.English);
        }
        public static void TrimOther(ref string s, bool trim = true)
        {
            if (IsNullOrEmpty(s)) s = string.Empty;
            if (trim) s = s.Trim();
        }
        public static void ToUpper(ref string s, bool ignoreCase)
        {
            if (IsNullOrEmpty(s)) s = string.Empty;
            if (ignoreCase) s = s.ToUpper();
        }
        public static bool Equal(string s1, string s2, bool ignoreCase = true, bool trim = true)
        {
            if (ReferenceEquals(s1, s2)) return true;
            if (ReferenceEquals(null, s1)) return false;
            if (ReferenceEquals(null, s2)) return false;
            TrimOther(ref s1, trim);
            TrimOther(ref s2, trim);
            ToUpper(ref s1, ignoreCase);
            ToUpper(ref s2, ignoreCase);
            return s1.Equals(s2);
        }
        public static void SetEmptyOrGivenDefaultIfIsNull(ref string s, string defaultValue = null, bool trim = false)
        {
            TrimOther(ref s, trim);
            if (IsNullOrEmpty(defaultValue)) defaultValue = string.Empty;
            if (IsNullOrEmpty(s)) s = defaultValue;
        }
        public static string AddChars(string s, int len, char c, PositionCode p = PositionCode.Start)
        {
            if (ObjectValue.IsNull(s)) s = string.Empty;
            var r = s;
            if (p == PositionCode.Start) for (var i = s.Length; i < len; i++) r = c + r;
            else for (var i = s.Length; i < len; i++) r += c;
            return r;
        }
        public static string DubChar(string s, char c)
        {
            var r = string.Empty;
            foreach (var e in s)
            {
                r = r + e;
                if (e != c) continue;
                r = r + e;
            }
            return r;
        }
        public static string AddColon(string s)
        {
            return string.Format("{0}{1}", s,':');
        }
        public static string GetSubstringAfter( string s, char c ){
            if (s == null) return string.Empty;
            var str = GetSubstringBefore( s, c );
            return str == s ? string.Empty : s.Substring( str.Length + 1 );
        }
        public static string GetSubstringAfterLast( string s, char c ){
            if (s == null) return string.Empty;
            var str = GetSubstringBeforeLast( s, c );
            return str == s ? string.Empty : s.Substring( str.Length + 1 );
        }
        public static string GetSubstringBefore( string s, char c ){
            if (s == null) return string.Empty;
            var i = s.IndexOf( c );
            return i < 0 ? s : s.Substring( 0, i );
        }
        public static string GetSubstringBeforeLast( string s, char c ){
            if (s == null) return string.Empty;
            var i = s.LastIndexOf( c );
            return i < 0 ? s : s.Substring( 0, i );
        }
        public static string GetSubstringBetween( string s, char c1, char c2 ){
            if (s == null) return string.Empty;
            var before = GetSubstringBefore( s, c2 );
            var after = GetSubstringAfter( before, c1 );
            if (IsNullOrEmpty( after )) return before;
            return after;
        }
        public static string GetSubstringBetweenLast( string s, char c1, char c2 ){
            if (s == null) return string.Empty;
            var after = GetSubstringAfterLast( s, c1 );
            if (IsNullOrEmpty( after )) return GetSubstringBeforeLast( s, c2 );
            return GetSubstringBeforeLast( after, c2 );
        }
        public static string GetSubstring( string s, int startIndex, int? lenght = null, bool returnStr = false ){
            if (IsNullOrEmpty( s )) return string.Empty;
            try{
                if (ReferenceEquals( lenght, null )) return s.Substring( startIndex );
                return s.Substring( startIndex, (int) lenght );
            } catch{
                return returnStr? s: string.Empty;
            }
        }
        public static string GetSubstringSame( string s, int startIndex, int? lenght = null ){
            if (IsNullOrEmpty( s )) return string.Empty;
            try{
                if (ReferenceEquals( lenght, null )) return s.Substring( startIndex );
                return s.Substring( startIndex, (int) lenght );
            } catch{
                return s;
            }
        }
        public static bool IncludesAllOrNoneSpecified(string s, string chars) {
            if (IsNullOrEmpty(chars)) return true;
            if (IsNullOrEmpty(s)) return true;
            return !IncludesAnySpecified(s, chars) || chars.All(c => s.IndexOf(c) >= 0);
        }
        public static bool IncludesAllSpecified(string s, string chars) {
            if (IsNullOrEmpty(chars)) return true;
            return !IsNullOrEmpty(s) && chars.All(c => s.IndexOf(c) >= 0);
        }
        public static bool IncludesAnySpecified(string s, string chars) {
            if (IsNullOrEmpty(chars)) return true;
            return !IsNullOrEmpty(s) && s.Any(c => chars.IndexOf(c) >= 0);
        }
        public static bool IncludesLetters(string s) {
            return !IsNullOrEmpty(s) && s.Any(char.IsLetter);
        }
        public static bool IncludesMoreThanOneSpecified(string s, char c) {
            var i = ProgramUnitName.CountParts(s, c);
            return i > 2;
        }
        public static bool IncludesNumbers(string s) {
            return !IsNullOrEmpty(s) && s.Any(char.IsDigit);
        }
        public static bool IncludesOnlySpecified(string s, string chars) {
            if (IsNullOrEmpty(chars)) return true;
            return !IsNullOrEmpty(s) && s.All(c => chars.IndexOf(c) >= 0);
        }
        public static string ReplaceAll( string s, char o, char n ){
            if (IsNullOrEmpty( s )) return string.Empty;
            return s.Replace( o, n );
        }
        public static string ReplaceAll( string s, string o, string n ){
            if (IsNullOrEmpty( s )) return string.Empty;
            if (IsNullOrEmpty( o )) return s;
            return s.Replace( o, n );
        }
        public static string ReplaceAllAfter( string s, string after, string n ){
            if (IsNullOrEmpty( s )) return string.Empty;
            if (IsNullOrEmpty( after )) return s;
            var vIndex = IndexOfOther( s, after, false, false ) + after.Length;
            var vFirstPart = s.Substring( 0, vIndex );
            return vFirstPart + n;
        }
        public static string ReplaceString( string s, string n, int idx, int len ){
            if (IsNullOrEmpty( s )) return string.Empty;
            if (IsNullOrEmpty( n )) return s;
            if (idx < 0) return s;
            if (len < 0) return s;
            var a = s.Substring( 0, idx );
            var b = n.Length > len ? n.Substring( 0, len ) : n;
            var c = s.Substring( idx + b.Length );
            return a + b + c;
        }
        public static void ReplaceString( ref string s, string n ){
            if (IsNullOrEmpty( n )) n = string.Empty;
            if (n.Equals( s )) return;
            s = n;
        }
        public static DateTime ReplaceTime( string s, DateTime d ){
            if (IsNullOrEmpty( s )) return d;
            double f;
            DateTime d1;
            if (( s.Length > 8 ) && double.TryParse( s.Trim(), NumberStyles.Any,UseCulture.English, out f )){
                s = DoubleValue.ToString( f / 0.000011574074074074067 );
                if (( s.IndexOf( '.' ) < 0 ) && ( s.Length < 3 )) s = s + ".";
                if (s.IndexOf( '.' ) == 1) s = "0" + s;
                if (s.IndexOf( '.' ) == 1) s = "0" + s;
                if (s.Length > 5) s = s.Substring( 0, 5 );
                if (s.Length < 5) s = AddChars( s, 5, '0', PositionCode.End );
            }
            var date = string.Format( "{0} {1}", DateTimeValue.ToShortDateString(d), DateTimePattern.LongMorning );
            DateTimeValue.TryParse( date, out d1 );
            s = s.Trim();
            s = RemoveAllExcept( s, "0123456789;:." );
            s = ReplaceAll( s, '.', ':' );
            s = ReplaceAll( s, ';', ':' );
            if (s == string.Empty) s = DateTimePattern.LongMorning;
            s = DateTimeValue.ToCorrectHours( s );
            s = DateTimeValue.ToShortTimeString( s );
            s = DateTimeValue.ToLongTimeString( s );
            date = DateTimeValue.ToShortDateString(d);
            date = string.Format( "{0} {1}", date, s );
            DateTime d2;
            DateTimeValue.TryParse( date, out d2 );
            if (d2 != DateTime.MinValue) return d2;
            if (d1 != DateTime.MinValue) return d1;
            return d;
        }
        public static DateTime ReplaceTime( string s, DateTime d, DateTime def ){
            if (IsNullOrEmpty( s )) return def;
            if (s.Trim() == string.Empty) return def;
            var r = ReplaceTime( s, d );
            return def > r ? def : r;
        }
        public static string RemoveAllBetween( string s, string s1, string s2 ){
            if (IsNullOrEmpty( s )) return string.Empty;
            SetEmptyOrGivenDefaultIfIsNull( ref s1, string.Empty );
            SetEmptyOrGivenDefaultIfIsNull( ref s2, string.Empty );
            if (( s1 == string.Empty ) && ( s2 == string.Empty )) return s;
            var fId = IndexOfOther( s, s1, false, false );
            var tId = IndexOfOther( fId + 1, s, s2, false, false );
            if (( fId < 0 ) && ( tId < 0 )) return s;
            var r = string.Empty;
            if (fId >= 0) r = r + s.Substring( 0, fId );
            if (tId >= 0) r = r + s.Substring( tId + 1 );
            return RemoveAllBetween( r, s1, s2 );
        }
        public static string RemoveAllChars( string s, string c ){
            if (IsNullOrEmpty( s )) return string.Empty;
            if (IsNullOrEmpty( c )) return s;
            return s.Where( e => c.IndexOf( e ) < 0 ).Aggregate( string.Empty, ( current, e ) => current + e );
        }
        public static string RemoveAllChars( string s, char c ){
            if (IsNullOrEmpty( s )) return string.Empty;
            return s.Where( e => e != c ).Aggregate( string.Empty, ( current, e ) => current + e );
        }
        public static string RemoveAllExcept( string s, string c ){
            if (IsNullOrEmpty( s )) return string.Empty;
            if (IsNullOrEmpty( c )) return s;
            return s.Where( e => c.IndexOf( e ) >= 0 ).Aggregate( string.Empty, ( current, e ) => current + e );
        }
        public static string RemoveAllNumbers( string s ) { return RemoveAllChars( s, IntValue.Numbers ); }
        public static string RemoveAllNotNumbers( string s ) { return RemoveAllExcept( s, IntValue.Numbers ); }
        public static string String( string t, string s ){
            if (IsNullOrEmpty( t )) return string.Empty;
            if (IsNullOrEmpty( s )) return t;
            var id = IndexOfOther( t, s, false );
            if (id < 0) return t;
            var length = s.Length;
            var str = t.Remove( id, length );
            return String( str, s );
        }
        public static string RemoveAllNotLettersAndNumbers( string s ){
            if (string.IsNullOrEmpty( s )) return string.Empty;
            return s.Where( char.IsLetterOrDigit ).Aggregate( string.Empty, ( current, c ) => current + c );
        }
        public static string RemoveAllNotLetters(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return s.Where(char.IsLetter).Aggregate(string.Empty, (current, c) => current + c);
        }
        public static bool IsSimilar( string a, string b, bool exact, string from, string to ){
            if (exact) return a == b;
            a = RemoveAllBetween( a, from, to );
            b = RemoveAllBetween( b, from, to );
            return a == b;
        }
        public static bool IsEqual(string a, string b, bool trim, bool caseSensitive) {
            if (a == null && b == null) return true;
            if (a == null) return false;
            if (b == null) return false;
            a = !caseSensitive ? a.ToUpper() : a;
            b = !caseSensitive ? b.ToUpper() : b;
            a = trim ? a.Trim() : a;
            b = trim ? b.Trim() : b;
            return a == b;
        }
        public static bool IsValueEqual(string x, string y, bool trim, bool ignoreCase) {
            if (IsNull(x) && IsNull(y)) return false;
            if (IsEmpty(x) && IsEmpty(y)) return false;
            if (string.IsNullOrEmpty(x)) return false;
            if (string.IsNullOrEmpty(y)) return false;
            x = trim ? x.Trim() : x;
            y = trim ? y.Trim() : y;
            x = ignoreCase ? x.ToUpper() : x;
            y = ignoreCase ? y.ToUpper() : y;
            return x.Equals(y);
        }
        internal static string addStringPattern => "{0}{1}";
        public static string Add(string s1, string s2)
        {
            s1 = s1 ?? string.Empty;
            s2 = s2 ?? string.Empty;
            return string.Format(addStringPattern, s1, s2);
        }
        public static string Add(char c1, char c2)
        {
            return string.Format(addStringPattern, c1, c2);
        }
        public static string Add(string s1, char c2)
        {
            s1 = s1 ?? string.Empty;
            return string.Format(addStringPattern, s1, c2);
        }
        public static string Add(char c1, string s2)
        {
            s2 = s2 ?? string.Empty;
            return string.Format(addStringPattern, c1, s2);
        }
        public static bool Add(bool b1, bool b2)
        {
            return BooleanValue.Or(b1, b2);
        }
        public static bool IsNullOrEmptyAfterTrim(string text) {
            return string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text.Trim());
        }
        public static bool IsEqualOther( string a, string b, bool trim = true, bool caseSensitive = false ) {
            return IsEqual(a, b, trim, caseSensitive);
        }
        public static bool IsValueEqualOther(string x, string y, bool trim = true, bool ignoreCase = false) {
            return IsValueEqual(x, y, trim, ignoreCase);
        }
    }
}
