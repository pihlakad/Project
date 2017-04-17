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

        //TODO 12: kui tahame, et m1.Multiply(m2) oleks v^2, tuleb muuta siin koodi
        // nagu näidatud ... alternatiivne kood on välja kommenteeritud
        // ja tuleb minna ja muuta ka MeasureTerms Add meetodit
        //
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

        //TODO 14: Analoogiliselt kui on defineeritud Multiply(BaseMeasure m)
        // tuleb defineerida ka Multiply (DerivedMeasure m)
        //public Measure Multiply(DerivedMeasure m)
        //{
        //    var t = new MeasureTerms();
        //    t.Add(new MeasureTerm(this, 1));
        //    foreach (var e in m.Terms) {
        //        t.Add(new MeasureTerm(e.Measure as BaseMeasure, e.Power));
        //    }
        //    return new DerivedMeasure(t);
        //}

        //TODO 15: Et asjad töötaksid üldiselt, tuleb kirjutada
        // ka Multiply (Measure m)
        //public Measure Multiply(Measure m) {
        //    if (m is DerivedMeasure) return Multiply(m as DerivedMeasure);
        //    return Multiply(m as BaseMeasure);
        //}
    }
}
