
namespace Logic
{
    public class DerivedMeasure : Measure
    {
        //TODO 3: soovitan selle t nimetada ümber terms
        private MeasureTerms t;
        public MeasureTerms Terms {
            get { return SetDefault(ref t); }
            set { SetValue(ref t, value); }
        }
        public static void Initialize()
        {
            var a = Measures.Add("area");            
            Logic.Units.Add(a, 1, "m2", "ruutmeeter");

            var v = Measures.Add("volume");
            Logic.Units.Add(v, 1, "m3", "kuupmeeter");

            var s = Measures.Add("speed");
            Logic.Units.Add(s, 1, "m/s", "meetrit sekundis");

            var t = Measures.Add("acceleration");
            Logic.Units.Add(t, 1, "m/s2", "meetrit ruutsekundis");

            var c = Measures.Add("current density");
            Logic.Units.Add(c, 1, "A/m2", "amprit ruutmeetris");

            var u = Measures.Add("concentration");
            Logic.Units.Add(u, 1, "mol/m3", "mooli kuumpeetris");

            var l = Measures.Add("luminance");
            Logic.Units.Add(l, 1, "cd/m2", "meetrit sekundis");

        }
        public DerivedMeasure() : this(null) { }

        public DerivedMeasure(MeasureTerms t, string name = null, string symbol = null)
        {
            //TODO 1: viga on lauses, kus sees t.Formula(), sest t on null 
            // ja keegi seda ei kontrolli
            // kirjutage rea this.t = t ette selline rida t=t?? new MeasureTerms();
            //
            //t = t ?? new MeasureTerms();
            this.t = t;
            this.name = name ?? t.Formula();
            this.symbol = symbol ?? name;
            this.definition = name;
            this.uniqueId = name;
        }

        public new static DerivedMeasure Random() {
            var m = new DerivedMeasure();
            m.SetRandomValues();
            return m;
        }

        //TODO 2: alati, kui on klassil privaatne muutuja nagu antud klassis on t
        // kui vabastate SetRandomValues kommentaridest, kontrollige, 
        // et vabastate kommentaridest ka Random meetodi klassis MeasureTerms 
        //protected override void SetRandomValues() {
        //    base.SetRandomValues();
        //    t = MeasureTerms.Random();
        //}

        public override string Formula(bool isLong = false) {
            return t.Formula(isLong);
        }

        //TODO 17: Analogiliset BaseMeasure korrutamise, astendamise
        // pöördväärtuse leidmise ja jagamise meetoditele tuleb
        // defineerida meetodid DerivedMeasure jaoks ja need ka 
        // testida

        //TODO 18: võiksite selle kõigega enne kokkusaaamist ... edu  

    }
}
