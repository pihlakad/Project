using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.BaseClasses;

namespace Logic
{
    public class UnitTerm : MeasureTerm
    {
        public UnitTerm() : this(null) { }

        public UnitTerm(Unit u, int power = 0) : base(u, power){}

        public string Unit
        {
            get { return SetDefault(ref measureId); }
            set { SetValue(ref measureId, value); }
        }
        public Unit GetUnit
        {
            get
            {
                var u = Units.Instance.Find(o => o.IsThis(Unit));
                return !IsNull(u) ? u : Logic.Unit.Empty;
            }
        }
    }
}
