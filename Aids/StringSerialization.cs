using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Aids {
    public static class StringSerialization{
        public static string String( object a ){
            if (a == null) return string.Empty;
            if (a is double) return DoubleValue.ToString((double) a);
            if (a is float) return String((float)a);
            if (a is decimal) return DecimalValue.ToString((decimal)a);
            if (a is DateTime) return DateTimeValue.ToString((DateTime)a);
            if (a is int) return String((int)a);
            if (a is uint) return String((uint)a);
            if (a is long) return String((long)a);
            if (a is ulong) return String((ulong)a);
            if (a is short) return String((short)a);
            if (a is ushort) return String((ushort)a);
            if (a is byte) return String((byte)a);
            if (a is sbyte) return String((sbyte)a);
            return a.ToString();
        }
        public static string String( uint a ) { return a.ToString(UseCulture.English ); }
        public static string String( ulong a ) { return a.ToString(UseCulture.English ); }
        public static string String( long a ) { return a.ToString(UseCulture.English ); }
        public static string String( List<int> list, char separator = ',' ){
            var l = list.Select( String ).ToList();
            return String( l, separator );
        }
        public static string String( List<string> list, char separator = ',' ){
            return list.Aggregate( string.Empty, ( current, e ) => String( current, e, separator ) );
        }
        public static string String( object a, object b, char separator = ',' ){
            if (a == null) return String( b );
            if (b == null) return String( a );
            var f = StringPattern.GetFormat( separator );
            return string.Format( f, a, separator, b );
        }
        public static string String( string a, object b, char separator = ',' ){
            if (string.IsNullOrEmpty( a )) return String( b );
            if (b == null) return String( a );
            var f = StringPattern.GetFormat( separator );
            return string.Format( (string) f, a, separator, b );
        }
        public static string String( string a, string b, char separator = ',' ){
            if (string.IsNullOrEmpty( a )) return String( b );
            if (string.IsNullOrEmpty( b )) return String( a );
            var f = StringPattern.GetFormat( separator );
            return string.Format( (string) f, a, separator, b );
        }
        public static string String( object a, object b, string separator ){
            if (a == null) return String( b );
            if (b == null) return String( a );
            if (StringValue.IsNullOrEmpty( separator )) return string.Format( "{0}{1}", a, b );
            const string f = "{0}{1}{2}";
            return string.Format( f, a, separator, b );
        }
        public static string String( string a, string b, string separator ){
            if (string.IsNullOrEmpty( a )) return String( b );
            if (string.IsNullOrEmpty( b )) return String( a );
            if (string.IsNullOrEmpty( separator )) return string.Format( "{0}{1}", a, b );
            const string f = "{0}{1}{2}";
            return string.Format( f, a, separator, b );
        }
        public static string String( int from, int to, char separator = ',' ){
            var r = string.Empty;
            for (var i = @from; i <= to; i++)
                r = r == string.Empty ? i.ToString(UseCulture.English ) : String( r, i, separator );
            return r;
        }
        public static string String( byte x ) { return x.ToString(UseCulture.English ); }
        public static string String( int x ) { return x.ToString(UseCulture.English ); }
        public static string String( float x ) { return x.ToString(UseCulture.English ); }
        public static string String( byte[] bytes ) { return EncodingFacade.From( bytes, EnCode.Unicode ); }
        public static float Float( string s ){
            float b;
            float.TryParse( s, NumberStyles.Any,UseCulture.English, out b );
            return b;
        }
        public static byte Byte( string s ){
            byte b;
            byte.TryParse( s, NumberStyles.Any,UseCulture.English, out b );
            return b;
        }
        public static IsoGender IsoGender( string s ){
            IsoGender gender;
            if (Enum.TryParse( s, out gender )) return gender;
            if (StringValue.Equal( s, IsoGenderFemale )) return Aids.IsoGender.Female;
            if (StringValue.Equal( s, IsoGenderFemaleCh )) return Aids.IsoGender.Female;
            if (StringValue.Equal( s, IsoGenderMale )) return Aids.IsoGender.Male;
            if (StringValue.Equal( s, IsoGenderMaleCh )) return Aids.IsoGender.Male;
            if (StringValue.Starts( IsoGenderFemale, s )) return Aids.IsoGender.Female;
            if (StringValue.Starts( IsoGenderMale, s )) return Aids.IsoGender.Male;
            return Aids.IsoGender.NotKnown;
        }
        public static sbyte SByte( string s ){
            sbyte b;
            sbyte.TryParse( s, NumberStyles.Any,UseCulture.English, out b );
            return b;
        }
        public static bool Bool( string s ){
            if (StringValue.Equal( s, TermYes )) return true;
            if (StringValue.Equal( s, TermYesCh )) return true;
            if (StringValue.Equal( s, TermTrue )) return true;
            if (StringValue.Equal( s, TermTrueCh )) return true;
            return false;
        }
        public static string ValidName( string s ){
            var r = string.Empty;
            if (StringValue.IsNullOrEmpty( s )) return String(Char.Underscore, null );
            foreach (var c in s){
                if (Char.IsLetter(c) || Char.IsNumber( c ) ||Char.IsDot( c )) r = String( r, c, null );
                else r = String( r,Char.Underscore, null );
            }
            return StringValue.StartsWithDigit( r ) ? String(Char.Underscore, r, null ) : r;
        }
        public static string Path( params string[] paths ){
            if (ReferenceEquals( null, paths )) return string.Empty;
            var list = paths.Where( s => !StringValue.IsNullOrEmpty( s ) ).ToList();
            return list.Count == 0 ? string.Empty : System.IO.Path.Combine( list.ToArray() );
        }
        public static Dictionary<string, string> Dictionary( string s, char mainSeparator = '|',
                                                             char primarySeparator = '=', char duplicationSign = '_' ){
            var d = new Dictionary<string, string>();
            var l = ToStringList( s, mainSeparator );
            foreach (var e in l){
                var key = StringValue.GetSubstringBefore( e, primarySeparator ).Trim();
                var value = StringValue.GetSubstringAfter( e, primarySeparator ).Trim();
                while (d.ContainsKey( key )){
                    key = duplicationSign + key;
                }
                d.Add( key, value );
            }
            return d;
        }
        public static int ToInteger( char c, int def ){
            if (char.IsDigit( c )) return c -Char.Zero;
            if (char.IsLetter( c ) && char.IsLower( c )) return c - char.ToLower('A' ) + 1;
            if (char.IsLetter( c ) && char.IsUpper( c )) return c - char.ToUpper('A' ) + 1;
            return def;
        }
        public static int ToInteger( string s, int def = 10, bool lettersAreNumbers = true ){
            if (StringValue.IsNullOrEmpty( s )) return def;
            s = s.Trim();
            if (StringValue.IsNullOrEmpty( s )) return def;
            if (s.Length == 1 && lettersAreNumbers) return ToInteger( s[0], def );
            int i;
            if (int.TryParse( s, out i )) return i;
            return def;
        }
        public static List<string> ToStringList( string s, char separator = ',', bool trim = true ){
            if (string.IsNullOrEmpty( s )) s = string.Empty;
            s = s.Trim().Trim( separator );
            var a = s.Split( separator );
            return a.Select( e => e.Trim() ).ToList();
        }
        public static List<string> ToStringList( string s, char separator, char startSymbol, char endSymbol ){
            var list = new List<string>();
            var length = ProgramUnitName.CountParts( s, separator );
            for (var i = 0; i < length; i++){
                var element = ProgramUnitName.GetPart( s, separator, i ).Trim();
                list.Add( element );
            }
            return ToStringList( list, separator, startSymbol, endSymbol );
        }
        public static List<string> ToStringList( List<string> list, char separator, char startSymbol, char endSymbol ){
            var l = new List<string>();
            var s = string.Empty;
            foreach (var e in list){
                if (( s != string.Empty ) && ( e.IndexOf( endSymbol ) != -1 )){
                    s = string.Format( "{0}{1}{2}", s, separator, e );
                    l.Add( s );
                    s = string.Empty;
                } else if (( s == string.Empty ) && ( e.IndexOf( startSymbol ) == -1 )) l.Add( e );
                else if (( s == string.Empty ) && ( e.IndexOf( startSymbol ) != -1 )) s = e;
                else if (( s != string.Empty ) && ( e.IndexOf( startSymbol ) == -1 ))
                    s = string.Format( "{0}{1}{2}", s, separator, e );
            }
            return l;
        }
        public static DateTime DateTime( DateTime date, DateTime time ){
            var d = date.Date;
            var t = time.TimeOfDay;
            var r = d + t;
            return r;
        }
        public static string DirName( string s ){
            if (ReferenceEquals( null, s )) return DirectoryNameTemp;
            s = s.Trim();
            if (string.IsNullOrEmpty(s)) return DirectoryNameTemp;
            var l = ToStringList( s,Char.Space );
            s = string.Empty;
            foreach (var e in l){
                var x = e.Trim();
                if (string.IsNullOrEmpty( x )) continue;
                x = StringValue.RemoveAllNotLettersAndNumbers(x);
                if (string.IsNullOrEmpty(x)) continue;
                var y = x.Substring( 0, 1 ).ToUpper();
                x = x.Substring(1).ToLower();
                x = y + x;
                s += x;
            }
            if (string.IsNullOrEmpty(s)) return DirectoryNameTemp;
            var c = s[0];
            if (char.IsDigit( c )) s ='A' + s;
            return s;
        }
        public static string ToString( char c ) { return c.ToString(UseCulture.Invariant ); }
        public static bool TryParse(string s, out char c) {
            c = string.IsNullOrEmpty(s)?Char.Space: s[0];
            return true; 
        }
        public static string ToString(int i) { return i.ToString(UseCulture.Invariant); }
        public static string ToString(ushort d) { return d.ToString(UseCulture.Invariant); }
        public static string ToString(ulong d) { return d.ToString(UseCulture.Invariant); }
        public static string ToString(double d) { return d.ToString(UseCulture.Invariant); }
        public static string ToString(float f) { return f.ToString(UseCulture.Invariant); }
        public static string ToString(DateTime dt) { return DateTimeValue.ToString(dt); }
        public static string ToString(decimal d) { return d.ToString(UseCulture.Invariant); }
        public static string ToString(EquationCode s) {
            if (s == EquationCode.NotEqualTo) return "!=";
            if (s == EquationCode.LessThan) return "<";
            if (s == EquationCode.GreaterThan) return ">";
            if (s == EquationCode.NotLessThan) return ">=";
            if (s == EquationCode.NotGreaterThan) return "<=";
            if (s == EquationCode.MuchGreaterThan) return ">>";
            if (s == EquationCode.MuchLessThan) return "<<";
            return "=";
        }
        public static EquationCode Inequality(ref string s) {
            if (string.IsNullOrEmpty(s)) return EquationCode.EqualTo;
            s = s.Trim();
            var r = EquationCode.EqualTo;
            if (s.StartsWith(ToString(EquationCode.EqualTo))) r = EquationCode.EqualTo;
            if (s.StartsWith(ToString(EquationCode.NotEqualTo))) r = EquationCode.NotEqualTo;
            if (s.StartsWith(ToString(EquationCode.LessThan))) r = EquationCode.LessThan;
            if (s.StartsWith(ToString(EquationCode.GreaterThan))) r = EquationCode.GreaterThan;
            if (s.StartsWith(ToString(EquationCode.NotLessThan))) r = EquationCode.NotLessThan;
            if (s.StartsWith(ToString(EquationCode.NotGreaterThan))) r = EquationCode.NotGreaterThan;
            if (s.StartsWith(ToString(EquationCode.MuchGreaterThan))) r = EquationCode.MuchGreaterThan;
            if (s.StartsWith(ToString(EquationCode.MuchLessThan))) r = EquationCode.MuchLessThan;
            s = s.TrimStart('!', '=', '<', '>').Trim();
            return r;
        }
        public static string TermYesCh => "y";
        public static string TermYes => "yes";
        public static string TermTrueCh => "t";
        public static string TermFalse => "False";
        public static string TermTrue => "True";
        public static string DirectoryNameTemp => "Temp";
        public static string IsoGenderFemale => "Female";
        public static string IsoGenderFemaleCh => "F";
        public static string IsoGenderMale => "Male";
        public static string IsoGenderMaleCh => "M";
    }
}