using Aids;
using Logic.BaseClasses;

namespace Logic
{
    public class UnitTerm : Archetype
    {       
        private int power;
        protected string unitId;
        public UnitTerm() : this(null)
        {
        }
        public UnitTerm(Unit m, int power = 0)
        {
            m = m ?? Unit.Empty;
            if (m != null) unitId = m.UniqueId;
            this.power = power;
        }

        public string UnitId
        {
            get { return SetDefault(ref unitId); }
            set { SetValue(ref unitId, value); }
        }
        public int Power
        {
            get { return SetDefault(ref power); }
            set { SetValue(ref power, value); }
        }
        public Unit Unit
        {
            get { return Units.Instance.Find(x => x.UniqueId == UnitId) ?? Unit.Empty; }
        }
        public string Formula(bool isLong = false)
        {
            var n = isLong ? Unit.Name : Unit.Symbol;
            if (Power == 0) return $"{n}";
            return $"{n}^{Power}";
        }

        public static UnitTerm Random()
        {
            var t = new UnitTerm();
            t.SetRandomValues();
            return t;
        }

        protected override void SetRandomValues()
        {
            base.SetRandomValues();
            power = GetRandom.Int8();
            unitId = GetRandom.String(2, 3);
        }
    }
}
