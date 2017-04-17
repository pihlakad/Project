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
        
        public Measure Multiply(BaseMeasure m)
        {
            var t1 = new MeasureTerm(this, 1);
            var t2 = new MeasureTerm(m, 1);
            var t = new MeasureTerms { t1, t2 };
            return new DerivedMeasure(t);
        }
        //public Measure Multiply(BaseMeasure m) {
        //    var t = new MeasureTerms();
        //    t.Add(new MeasureTerm(this, 1));
        //    t.Add(new MeasureTerm(m, 1));
        //    return new DerivedMeasure(t);
        //}

       
        public Measure Multiply(DerivedMeasure m)
        {
            var t = new MeasureTerms();
            t.Add(new MeasureTerm(this, 1));
            foreach (var e in m.Terms)
            {
                t.Add(new MeasureTerm(e.Measure as BaseMeasure, e.Power));
            }
            return new DerivedMeasure(t);
        }

       
        public Measure Multiply(Measure m)
        {
            if (m is DerivedMeasure) return Multiply(m as DerivedMeasure);
            return Multiply(m as BaseMeasure);
        }

        public Measure Divide(BaseMeasure m) {
            var t1 = new MeasureTerm(this, 1);
            var t2 = new MeasureTerm(m, -1);
            var t = new MeasureTerms {t1, t2};
            return new DerivedMeasure(t);
        }

       

        public Measure Exponentiation(int i) {
            if (i == 0) return Empty;
            MeasureTerm t1;
            if(i == 1)
                t1 = new MeasureTerm(this);
            else 
                t1 = new MeasureTerm(this, i);            
            var t = new MeasureTerms {t1};
            return new DerivedMeasure(t);
        }

        public Measure Reciprocal(BaseMeasure m2) {
            var t1 = new MeasureTerm(this, -1);
            var t2 = new MeasureTerm(m2, 1);
            var t = new MeasureTerms { t1, t2 };
            return new DerivedMeasure(t);
        }
    }
}
