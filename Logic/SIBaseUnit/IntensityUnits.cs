using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SIBaseUnit
{
  public  static class IntensityUnits
    {
        public static void Initialize() {
            var m = Measures.Add("intensity");
            Units.Add(m, 1, "cd", "candela");
        }
    }
}
