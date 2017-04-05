using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SIBaseUnit
{
   public static class SubstanceUnits
    {
        public static void Initialize() {
            var m = Measures.Add("substance");
            Units.Add(m, 1, "mol", "mole");
        }
    }
}
