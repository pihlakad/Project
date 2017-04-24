using System;
using Aids;
using Logic;

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
            u = u ?? new BaseUnit();
            QuantityUnit = u.Symbol;
            Amount = amount;
        }

        public bool IsEqual(Quantity q) {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return false;
            var q1 = Convert(u2);
            return Math.Abs(q1.Amount - q.Amount) < 0.0000000001;
        }

        public bool IsGreaterThan(Quantity q) {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return false;
            var q1 = Convert(u2);
            return q.Amount > q1.Amount;
        }

        public bool IsLessThan(Quantity q) {
            return !IsGreaterThan(q);
        }

        public Quantity Convert(Unit u) {
            var a = GetUnit.ToBase(amount);
            a = u.FromBase(a);
            return new Quantity(a, u);
        }
        public Quantity ConvertTo(Unit u)
        {
            u = u ?? Unit.Empty;
            var d = convertTo(amount, u);
            return new Quantity(d, u);
        }
        private double convertTo(double d, Unit u)
        {
            if (ReferenceEquals(null, u)) return double.NaN;
            if (!IsSameMeasure(u)) return double.NaN;
            d = GetUnit.ToBase(d);
            return u.FromBase(d);
        }
        private bool IsSameMeasure(Unit u)
        {
            return GetUnit.GetMeasure.IsSameContent(u.GetMeasure);
        }

        public Quantity Add(Quantity q) {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return new Quantity(0, u1);
            var a = GetUnit.ToBase(amount);
            a = a + q.GetUnit.ToBase(q.amount);
            return new Quantity(q.GetUnit.FromBase(a), q.GetUnit);
        }

        public Quantity Subtract(Quantity q)
        {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return new Quantity(0, u1);
            var a = GetUnit.ToBase(amount);
            a = a + q.GetUnit.ToBase(q.amount);
            return new Quantity(q.GetUnit.FromBase(a), q.GetUnit);
        }

        public Quantity Multiply(double a) { return new Quantity(Amount * a, GetUnit); }

        public Quantity Divide(double a) { return new Quantity(Amount / a, GetUnit); }

        public Quantity Multiply(Quantity q)
        {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return new Quantity(0, u1);
            var a = GetUnit.ToBase(amount);
            a = a + q.GetUnit.ToBase(q.amount);
            return new Quantity(q.GetUnit.FromBase(a), q.GetUnit);
        }

        public Quantity Divide(Quantity q)
        {
            var u1 = GetUnit;
            var u2 = q.GetUnit;
            if (u1.Measure != u2.Measure) return new Quantity(0, u1);
            var a = GetUnit.ToBase(amount);
            a = a + q.GetUnit.ToBase(q.amount);
            return new Quantity(q.GetUnit.FromBase(a), q.GetUnit);
        }
        public Quantity Round(Rounding policy)
        {
            var d = RoundNumber(amount, policy);
            return new Quantity(d, GetUnit);
        }
        private static double RoundNumber(double d, Rounding p)
        {
            switch (p.Strategy)
            {
                case Approximate.Up:
                    return Logic.Round.Up(d, p.Decimals);
                case Approximate.Down:
                    return Logic.Round.Down(d, p.Decimals);
                case Approximate.UpByStep:
                    return Logic.Round.UpByStep(d, p.Step);
                case Approximate.DownByStep:
                    return Logic.Round.DownByStep(d, p.Step);
                case Approximate.TowardsPositive:
                    return Logic.Round.TowardsPositive(d, p.Decimals);
                case Approximate.TowardsNegative:
                    return Logic.Round.TowardsNegative(d, p.Decimals);
                default:
                    return Logic.Round.Off(d, p.Decimals, p.Digit);
            }
        }
    }
}