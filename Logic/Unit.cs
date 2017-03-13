namespace Logic {
    public sealed class Unit {
        private static readonly Unit _none = new Unit(string.Empty, string.Empty, UnitType.None);

        private readonly string _name;
        private readonly string _symbol;
        private readonly double _factor;
        private readonly UnitType _unitType;
        private bool _isNamed;

        public Unit(string name, string symbol, UnitType unitType)
            : this(name, symbol, 1.0, unitType, true) {}

        public Unit(string name, string symbol, Unit baseUnit)
            : this(name, symbol, baseUnit._factor, baseUnit._unitType, true) {}

        private Unit(string name, string symbol, double factor, UnitType unitType, bool isNamed) {
            _name = name;
            _symbol = symbol;
            _factor = factor;
            _unitType = unitType;
            _isNamed = isNamed;
        }

        public static Unit None {
            get { return _none; }
        }

        public string Name {
            get { return _name; }
        }

        public string Symbol {
            get { return _symbol; }
        }

        public double Factor {
            get { return _factor; }
        }

        public UnitType UnitType {
            get { return _unitType; }
        }

        public bool IsNamed {
            get { return _isNamed; }
        }

        public override string ToString() {
            return Symbol;
        }

        public static Unit operator *(Unit left, double right) {
            return (right * left);
        }

        public static Unit operator *(Unit left, Unit right) {
            left = left ?? _none;
            right = right ?? _none;

            return new Unit(
                string.Concat('(', left._name, '*', right._name, ')'),
                left._symbol + '*' + right._symbol, left._factor * right._factor,
                left._unitType * right._unitType,
                false
           );
        }

        public static Unit operator *(double left, Unit right) {
            if (left == 1) {
                return right;
            }

            right = right ?? _none;

            return new Unit(
                string.Concat('(', left.ToString(), '*', right._name, ')'),
                left.ToString() + '*' + right._symbol, left * right._factor,
                right._unitType, false
            );
        }

        public bool IsCompatibleTo(Unit otherUnit) {
            return (_unitType == (otherUnit ?? _none)._unitType);
        }
    }
}