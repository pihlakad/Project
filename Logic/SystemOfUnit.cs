using Aids;

namespace Logic
{
    public class SystemOfUnit: Metric {
        private string name;

        public string Name {
            get { return Strings.EmptyIfNull(name); }
            set { name = value; }
        }
    }
}
