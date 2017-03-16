namespace Logic {
    public sealed class Quantity {
        public double Value { get; set; }
        public Unit Unit { get; set; }

        public Quantity(double value, Unit unit) {
            Value = value;
            Unit = unit;
        }

        public static Quantity Zero(Unit unit) {
            return new Quantity(0.0, unit);
        }

        public static Quantity operator +(Quantity left, Quantity right) {
            left = left ?? Zero(right.Unit);
            right = right ?? Zero(left.Unit);

            return new Quantity(
                left.Value + right.ConvertedTo(left.Unit).Value,
                left.Unit
            );
        }

        public static Quantity operator /(Quantity left, Quantity right) {
            return new Quantity(
                left.Value / right.Value,
                left.Unit / right.Unit
            );
        }

        public static Quantity operator *(Quantity left, Quantity right) {
            return new Quantity(
                left.Value * right.Value,
                left.Unit * right.Unit
            );
        }

        public Quantity ConvertedTo(Unit unit) {
            return UnitManager.ConvertTo(this, unit);
        }

        public override string ToString() {
            return $"{Value:G} {Unit}".TrimEnd(null);
        }
    }
}