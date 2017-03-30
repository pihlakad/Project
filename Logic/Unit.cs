using Aids;

namespace Logic
{
    public class Unit : Metric {
        private string systemOfUnits;
        private string measure;
        private double factor;
        public Unit() { }
        public Unit(Measure m, double factor, string symbol, string name)
        {
            measure = m.UniqueId;
            this.factor = factor;
            Symbol = symbol;
            Name = name;
            UniqueId = symbol;
        }


        public string SystemOfUnits
        {
            get { return Strings.EmptyIfNull(systemOfUnits); }
            set { systemOfUnits = value; }
        }

        public string Measure
        {
            get { return Strings.EmptyIfNull(measure); }
            set { measure = value; }
        }

        public Measure GetMeasure() {
            return Measures.Find(measure);
        }

        public void GetSystemOfUnits() {
            
        }

        public double ToBase(double amount) {
            return amount * factor;
        }

        public double FromBase(double amount) {
            return amount / factor;
        }
    }
}
