using Aids;

namespace Logic
{
    public class Unit : Metric {
        private string systemOfUnits;
        private string measure;
        private double factor;
        public Unit(): this(null, 0, null, null) {}

        public Unit(Measure m, double factor, string symbol, string name): base(name, symbol) {
            m = m ?? Logic.Measure.Empty;
            measure = m.UniqueId;
            this.factor = factor;
        }


        public string SystemOfUnits {
            get { return Strings.EmptyIfNull(systemOfUnits); }
            set { systemOfUnits = value; }
        }

        public string Measure {
            get { return Strings.EmptyIfNull(measure); }
            set { measure = value; }
        }

        public double Factor {
            get { return factor; }
            set { factor = value; }
        }

        public static Unit Empty { get; } = new Unit {isReadOnly = true};

        public Measure GetMeasure => Measures.Find(Measure) ?? Logic.Measure.Empty;
        public void GetSystemOfUnits() {}

        public double ToBase(double amount) {
            return amount*factor;
        }

        public double FromBase(double amount) {
            return amount/factor;
        }

        public static Unit Random() {
            var n = new Unit();
            n.SetRandomValues();
            n.Measure = GetRandom.String();
            n.Factor = GetRandom.Double();
            n.SystemOfUnits = GetRandom.String();
            return n;
        }

        public bool IsThis(string id) {
            {
                if (IsSpaces(id)) return false;
                if (UniqueId == id) return true;
                if (Name == id) return true;
                if (Symbol == id) return true;
                if (!IsFormula(id)) return false;
                if (Formula() == id) return true;
                return Formula(true) == id;
            }
        }

        public static bool IsFormula(string s) { return !IsNull(s) && s.Contains("^"); }
    }
}
