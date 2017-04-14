using Aids;

namespace Logic
{
    public abstract class Metric : UniqueEntity {
        protected string name;
        protected string symbol;
        protected string definition;
        protected Metric(): this (null) { }
        protected Metric (string name, string symbol = null, string definition = null) {
            name = name ?? string.Empty;
            symbol = symbol ?? name;
            definition = definition ?? name;
            this.name = name;
            this.symbol = symbol;
            this.definition = definition;
            uniqueId = name;
        }
        public virtual string Formula(bool isLong = false)
        {
            return isLong ? Name : Symbol;
        }
        public string Name
        {
            get { return Strings.EmptyIfNull(name); }
            set { name = value; }
        }
        public string Symbol {
            get { return SetDefault(ref symbol); }
            set { SetValue(ref symbol, value); }
        }

        public string Definition
        {
            get { return Strings.EmptyIfNull(definition); }
            set { definition = value; }
        }

        protected override void SetRandomValues() {
            base.SetRandomValues();
            name = GetRandom.String();
            symbol = GetRandom.String();
            definition = GetRandom.String();

        }
    }
}
