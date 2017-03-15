namespace Logic {
    public sealed class Unit {
        public static Unit None {
            get {
                return new Unit(string.Empty, string.Empty, UnitType.None);
            }
        }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Factor { get; set; }
        public UnitType UnitType { get; set; }
        public bool IsNamed { get; set; }

        public Unit(string name, string symbol, UnitType unitType)
            : this(name, symbol, 1.0, unitType, true) {}

        public Unit(string name, string symbol, Unit baseUnit)
            : this(name, symbol, baseUnit.Factor, baseUnit.UnitType, true) {}

        private Unit(string name, string symbol, double factor, UnitType unitType, bool isNamed) {
            this.Name = name;
            this.Symbol = symbol;
            this.Factor = factor;
            this.UnitType = unitType;
            this.IsNamed = isNamed;
        }

        public override string ToString() {
            return Symbol;
        }

        public static Unit operator *(Unit left, double right) {
            return (right * left);
        }

        public static Unit operator *(Unit left, Unit right) {
            return new Unit(
                string.Concat('(', left.Name, '*', right.Name, ')'),
                left.Symbol + '*' + right.Symbol,
                left.Factor * right.Factor,
                left.UnitType * right.UnitType,
                false
            );
        }

        public static Unit operator *(double left, Unit right) {
            return new Unit(
                string.Concat('(', left, '*', right.Name, ')'),
                left + '*' + right.Symbol, left * right.Factor,
                right.UnitType, false
            );
        }

        public static Unit operator /(Unit left, Unit right) {
            return new Unit(
                string.Concat('(', left.Name, '/', right.Name, ')'),
                left.Symbol + '/' + right.Symbol,
                left.Factor / right.Factor,
                left.UnitType / right.UnitType,
                false
            );
        }

        public static Unit operator /(double left, Unit right) {
            return new Unit(
                string.Concat('(', left, '*', right.Name, ')'),
                left + '*' + right.Symbol,
                left / right.Factor,
                right.UnitType.Power(-1),
                false
            );
        }

        public static Unit operator /(Unit left, double right) {
            return new Unit(
                string.Concat('(', left.Name, '/', right, ')'),
                left.Symbol + '/' + right,
                left.Factor / right,
                left.UnitType,
                false
            );
        }

        public bool IsCompatibleTo(Unit otherUnit) {
            return (this.UnitType == (otherUnit ?? None).UnitType);
        }
    }
}