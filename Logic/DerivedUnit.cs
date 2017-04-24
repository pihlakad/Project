using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DerivedUnit: Unit
    {
        private UnitTerms terms;
        public UnitTerms Terms
        {
            get { return SetDefault(ref terms); }
            set { SetValue(ref terms, value); }
        }
        public DerivedUnit() : this(null) { }

        public DerivedUnit(UnitTerms terms, string name = null, string symbol = null)
        {
            terms = terms ?? new UnitTerms();
            this.terms = terms;
            this.name = name ?? terms.Formula();
            this.symbol = symbol ?? name;
            definition = name;
            uniqueId = name;
        }
    }
}
