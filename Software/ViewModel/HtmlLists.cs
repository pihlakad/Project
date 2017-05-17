using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Software.ViewModel
{
    public static class HtmlLists
    {
        public static IEnumerable<string> Operations = new List<string> {
            "Add", "Subtract", "Multiply", "Divide", "Compare", "Round"
        };
        public static IEnumerable<string> Numbers = new List<string> {
            "1","2","3","4","5"
        };
    }
  }