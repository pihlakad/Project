namespace Aids
{
    public class Strings
    {
        public static string EmptyIfNull(string s) {
            string x = s ?? string.Empty;
            return x;
        }
    }
}
