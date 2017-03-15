using System;

namespace Logic {
    public sealed class Quantity {
        private readonly double _value;
        private readonly Unit _unit;

        public Quantity(double value, Unit unit) {
            _value = value;
            _unit = unit;
        }

        public static Quantity Zero(Unit unit) => new Quantity(0.0, unit);
        public double Value => _value;
        public Unit Unit => _unit;

        public Quantity Add(Quantity amount) {
            return (this + amount);
        }

        public Quantity DivideBy(Quantity amount) {
            return (this / amount);
        }

        public static Quantity operator +(Quantity left, Quantity right) {
            if ((left == null) && (right == null)) {
                return null;
            }

            left = left ?? Zero(right.Unit);
            right = right ?? Zero(left.Unit);

            return new Quantity(
                left.Value + right.ConvertedTo(left._unit).Value,
                left.Unit
            );
        }

        public static Quantity operator /(Quantity left, Quantity right) {
            if (ReferenceEquals(left, null))
                return null;
            else if (ReferenceEquals(right, null))
                return null;
            else
                return new Quantity(left._value / right._value, left._unit / right._unit);
        }

        public Quantity ConvertedTo(Unit unit) {
            return UnitManager.ConvertTo(this, unit);
        }

        public override string ToString() {
            return $"{this.Value:G} {this.Unit}".TrimEnd(null);
        }
    }
}