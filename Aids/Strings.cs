using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
