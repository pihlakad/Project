using Aids;
using Logic.BaseClasses;

namespace Logic
{
    public class UnitTerms: Archetypes<UnitTerm>
    {
        private UnitTerm t1;
        private UnitTerm t2;

        public UnitTerms(UnitTerm t1, UnitTerm t2)
        {
            this.t1 = t1;
            this.t2 = t2;
        }

        public string Formula(bool isLong = false)
        {
            var s = string.Empty;
            foreach (var e in this)
            {
                var f = e.Formula(isLong);
                if (string.IsNullOrEmpty(s)) s = f;
                else s = $"{s}*{f}";
            }
            return s;
        }


        public override void Add(UnitTerm item)
        {
            var t = Find(x => x.UnitId == item.UnitId);
            if (IsNull(t)) base.Add(item);
            else t.Power = t.Power + item.Power;
        }


        public static UnitTerms Random()
        {
            var t = new UnitTerms();
            for (var i = 0; i < GetRandom.Count(); i++)
            {
                t.Add(UnitTerm.Random());
            }
            return t;
        }
    }
}
