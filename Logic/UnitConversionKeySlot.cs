namespace Logic {
    public class UnitConversionKeySlot {
        private readonly UnitType _fromType;
        private readonly UnitType _toType;

        public UnitConversionKeySlot(Unit from, Unit to) {
            _fromType = from.UnitType;
            _toType = to.UnitType;
        }

        public override bool Equals(object obj) {
            var other = obj as UnitConversionKeySlot;
            return (_fromType == other._fromType) && (this._toType == other._toType);
        }

        public override int GetHashCode() {
            return _fromType.GetHashCode() ^ _toType.GetHashCode();
        }
    }
}