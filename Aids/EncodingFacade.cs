using System.Text;

namespace Aids {
    public static class EncodingFacade{
        public static byte[] ToUtf7( string s ){
            StringValue.SetEmptyOrGivenDefaultIfIsNull( ref s );
            return Encoding.UTF7.GetBytes( s );
        }
        public static string FromUtf7( byte[] b ){
            if (ObjectValue.IsNull( b )) return string.Empty;
            return Encoding.UTF7.GetString( b, 0, b.Length );
        }
        public static string From( byte[] b, EnCode t ){
            switch (t){
                case EnCode.Ascii:
                    return new ASCIIEncoding().GetString( b );
                case EnCode.Unicode:
                    return new UnicodeEncoding().GetString( b );
                case EnCode.Utf7:
                    return new UTF7Encoding().GetString( b );
                case EnCode.Utf8:
                    return new UTF8Encoding().GetString( b );

            }
            return string.Empty;
        }
    }
}