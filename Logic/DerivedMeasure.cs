using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DerivedMeasure : Measure
    {
        public DerivedMeasure(string name, string symbol = null) : base(name, symbol)
        {
        }
        public DerivedMeasure() : this(string.Empty) { }
    }
}
