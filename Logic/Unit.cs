using Aids;

namespace Logic
{
    public class Unit : Metric {
        private string name;
        private string systemOfUnits;
        private string measure;

        public string Name {
            get { return Strings.EmptyIfNull(name); }
            set { name = value; }
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

        public void GetMeasure() {
            
        }

        public void GetSystemOfUnits() {
            
        }
    }
}
