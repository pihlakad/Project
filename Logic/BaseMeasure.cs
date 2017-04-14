using System;

namespace Logic
{
    public class BaseMeasure : Measure
    {
        public BaseMeasure(string name, string symbol = null) : base(name, symbol)
        {

        }

        public BaseMeasure():this(string.Empty) {
            
        }

        public new static BaseMeasure Random() {
            var m = new BaseMeasure();
            m.SetRandomValues();
            return m;
        }

        public Measure Multiply(BaseMeasure m) {
            var t1 = new MeasureTerm(this, 1);
            var t2 = new MeasureTerm(m, 1);
            var t = new MeasureTerms {t1, t2};
            return new DerivedMeasure(t);
        }
    }
}
