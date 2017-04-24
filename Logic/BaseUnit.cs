﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BaseUnit: Unit {
        public BaseUnit() : this(Logic.Measure.Empty, 0, string.Empty, string.Empty) { }
        public BaseUnit(Measure m, double factor, string symbol, string name): base(name, symbol) {
            m = m ?? Logic.Measure.Empty;
            measure = m.UniqueId;
            this.factor = factor;
        }

        public Measure Exponentiation(int i)
        {
            if (i == 0) return Logic.Measure.Empty;
            UnitTerm t1;
            if (i == 1)
                t1 = new UnitTerm(this);
            else
            {
                t1 = new UnitTerm(this, i);
                var t = new UnitTerms();
            }
            return new DerivedMeasure();
        }

        //public Unit Exponentiation(int i) {
        //    if (i == 0) return Empty;
        //    UnitTerm t1;
        //    if(i==1)
        //        t1 = new UnitTerm(this);
        //    else
        //        t1 = new UnitTerm(this, i);
        //    var t = new UnitTerms {t1};
        //    return new DerivedUnit(t);
        //}

        public Measure Reciprocal()
        {
            var t1 = new UnitTerm(this, -1);
            var t = new UnitTerms();
            return new DerivedMeasure();
        }
        //public Unit Reciprocal()
        //{
        //    var t1 = new UnitTerm(this, -1);
        //    var t = new UnitTerms { t1 };
        //    return new DerivedUnit(t);
        //}

        public Measure Multiply(int i)
        {
            var t1 = new UnitTerm(this, i);
            var t = new UnitTerms();
            return new DerivedMeasure();
        }
        //public Unit Multiply(Unit i)
        //{
        //    var t1 = new UnitTerm(this, 1);
        //    var t2 = new UnitTerm(i, 1);
        //    var t = new UnitTerms {t1,t2};
        //    return new DerivedUnit(t);
        //}

        public Measure Divide(int i)
        {
            var t1 = new UnitTerm(this, i);
            var t = new UnitTerms();
            return new DerivedMeasure();
        }

        //public Unit Divide(Unit i) {
        //    var t1= new UnitTerm(this, 1);
        //    var t2 = new UnitTerm(i, -1);
        //    var t = new UnitTerms { t1, t2 };
        //    return new DerivedUnit(t);
        //}

    }
}
