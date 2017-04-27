using Aids;

namespace Logic
{
    public abstract class Unit : Metric {
        protected string systemOfUnits;
        protected Measure measure;
        protected double factor;
       // public Unit(): this(null, 0, null, null) {}

        protected Unit(string name, string symbol = null, string definition = null) : base(name, symbol, definition)
        {
        }

        protected Unit() : this(string.Empty) { }

        protected Unit(Measure m, double factor, string symbol, string name): base(name, symbol) {
            m = m ?? Logic.Measure.Empty;
            measure = m;
            this.factor = factor;
        }

        public string SystemOfUnits {
            get { return Strings.EmptyIfNull(systemOfUnits); }
            set { systemOfUnits = value; }
        }

        public Measure Measure {
            get { return measure?? Measure.Empty; }
            set { measure = value; }
        }

        public double Factor {
            get { return factor; }
            set { factor = value; }
        }

        public static Unit Empty { get; } = new BaseUnit {isReadOnly = true};

        public Measure GetMeasure => Measures.Find(Measure.Name) ?? Logic.Measure.Empty;

        public void GetSystemOfUnits() {}

        public double ToBase(double amount) {
            return amount*factor;
        }

        public double FromBase(double amount) {
            return amount/factor;
        }

        public static Unit Random() {
            var n = new BaseUnit();
            n.SetRandomValues();
            n.Measure = Measure.Random();
            n.Factor = GetRandom.Double();
            n.SystemOfUnits = GetRandom.String();
            return n;
        }        
    }
}


