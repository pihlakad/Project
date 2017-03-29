using Aids;

namespace Logic
{
    public class Measure : Metric {
        private string name;
        public string Name
        {
            get { return Strings.EmptyIfNull(name); }
            set { name = value; }
        }

        public void Units() {
            
        }
    }
}
