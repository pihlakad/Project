using System;
using Aids;

namespace Logic {
    public sealed class Quantity {
        private double amount;
        private string quantityUnit;

        public string QuantityUnit {
            get { return Strings.EmptyIfNull(quantityUnit); }
            set { quantityUnit = value; }
        }

        public Unit GetUnit => Units.Find(QuantityUnit);
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Quantity(): this(0, null) {
            
        }
        public Quantity(double amount, Unit u) {
            u = u ?? new Unit();
            QuantityUnit = u.Symbol;
            Amount = amount;
        }

        public bool IsEqual(Quantity q) {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return false;
            var q1 = Convert(u2);
            return Math.Abs(q1.Amount - q.Amount) < 0.00000000001;
        }

        public Quantity Convert(Unit u) {
            var a = GetUnit.ToBase(amount);
            a = u.FromBase(a);
            return new Quantity(a, u);
        }
    }
}