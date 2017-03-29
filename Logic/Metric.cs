using Aids;

namespace Logic
{
    public class Metric : Archetype {
        private string _name;
        private string _symbol;
        private string _definition;

        public string Name
        {
            get { return Strings.EmptyIfNull(_name); }
            set { _name = value; }
        }
        public string Symbol {
            get { return Strings.EmptyIfNull(_symbol); }
            set { _symbol = value; }
        }

        public string Definition
        {
            get { return Strings.EmptyIfNull(_definition); }
            set { _definition = value; }
        }      
    }
}
