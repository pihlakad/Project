using System;

namespace Logic {
    public sealed class Quantity {
        private double _value;
        private readonly Unit _unit;

        public Quantity(double value, Unit unit) {
            _value = value;
            _unit = unit;
        }

        public static Quantity Zero(Unit unit) {
            return new Quantity(0.0, unit);
        }

        public double Value {
            get { return _value; }
        }

        public Unit Unit {
            get { return _unit; }
        }

        public Quantity Add(Quantity amount) {
            return (this + amount);
        }

        public static Quantity operator +(Quantity left, Quantity right) {
            if ((left == null) && (right == null)) {
                return null;
            }

            left = left ?? Zero((right != null) ? right._unit : Unit.None);
            right = right ?? Zero(left.Unit);

            return new Quantity(
                left._value + right.ConvertedTo(left._unit)._value,
                left._unit
            );
        }

        public Quantity ConvertedTo(Unit unit) {
            return UnitManager.ConvertTo(this, unit);
        }

        public override string ToString() {
            var amount = this;
            return String.Format("{0:G} {1}", amount.Value, amount.Unit).TrimEnd(null);
        }
    }
}