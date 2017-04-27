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
            name = name ?? terms.Formula(true);
            symbol = symbol ?? terms.Formula();
            this.terms = terms;
            this.name = name;
            this.symbol = symbol;
            definition = name;
            uniqueId = name;            
        }

        public new static DerivedUnit Random() {
            var m = new DerivedUnit();
            m.SetRandomValues();
            return m;
        }

        protected override void SetRandomValues()
        {
            base.SetRandomValues();
            terms = UnitTerms.Random();
        }
        public Unit Exponentiation(int i) {
            if (i == 0) return Empty;
           var b = new UnitTerms();
            foreach (var e in Terms) {
                var c = Clone(e);
                c.Power = c.Power * i;
                b.Add(c);
            }
            return new DerivedUnit(b);
        }

        public Unit Reciprocal() {
            var a= new UnitTerms();
            foreach (var e in Terms) {
                var c = Clone(e);
                c.Power = c.Power * -1;
                a.Add(c);
                }
            return new DerivedUnit(a);
        }

        public Unit Multiply(DerivedUnit d)
        {
            var a = new UnitTerms();
            foreach (var e in Terms)
            {
                var c = Clone(e);
                a.Add(c);
            }
            foreach (var e in d.Terms)
            {
                var c = Clone(e);
                a.Add(c);
            }
            return new DerivedUnit(a);
        }

        public Unit Divide(DerivedUnit d)
        {
            if (d == this) return Empty;
            var a = new UnitTerms();
            foreach (var e in Terms)
            {
                var c = Clone(e);
                a.Add(c);
            }
            foreach (var e in d.Terms)
            {
                var c = Clone(e);
                c.Power = -c.Power;
                a.Add(c);
            }
            a.RemoveAll(x => x.Power == 0);
            return new DerivedUnit(a);
        }
    }
}
