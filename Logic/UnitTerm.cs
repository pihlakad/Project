using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Logic.BaseClasses;

namespace Logic
{
    class UnitTerm : Archetype {
        private int power;
        private string measureId;
        public UnitTerm() : this(null) { }
    
    
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

        public int Power {
            get { return SetDefault(ref power); }
            set { SetValue(ref power, value);}
        }

        public static UnitTerm Random()
        {
            var t = new UnitTerm();
            t.SetRandomValues();
            return t;
        }

        protected override void SetRandomValues() {
            base.SetRandomValues();
            power = GetRandom.Int8();
            measureId = GetRandom.String(2, 3);
        }
    }
}
