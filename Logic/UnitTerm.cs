using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class UnitTerm
    {
        private int i;
        private Unit unit;
 
         public UnitTerm(Unit unit)
         {
             this.unit = unit;
         }
 
         public UnitTerm(Unit unit, int i) : this(unit)
         {
             this.i = i;
         }
}
}
