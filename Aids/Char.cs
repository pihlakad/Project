namespace Aids {
    public class Char {
        public static char Comma => ',';
        public static char Space => ' ';
        public static char Eol => '\n';
        public static char Tab => '\t';
        public static char Zero => '0';
        public static object Underscore => '_';
        public static bool IsDot(char c) => c.Equals('.');
        public static bool IsLetter(char c) { return char.IsLetter(c); }
        public static bool IsNumber(char c) { return char.IsNumber(c); }
    }
}

