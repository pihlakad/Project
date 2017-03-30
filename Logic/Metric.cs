using Aids;

namespace Logic
{
    public class Metric : UniqueEntity {
        private string name;
        private string symbol;
        private string definition;

        public string Name
        {
            get { return Strings.EmptyIfNull(name); }
            set { name = value; }
        }
        public string Symbol {
            get { return Strings.EmptyIfNull(symbol); }
            set { symbol = value; }
        }

        public string Definition
        {
            get { return Strings.EmptyIfNull(definition); }
            set { definition = value; }
        }      
    }
}
