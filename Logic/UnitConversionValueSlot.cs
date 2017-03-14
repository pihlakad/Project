namespace Logic {
    public class UnitConversionValueSlot {
        private readonly Unit _from;
        private readonly Unit _to;
        private readonly ConversionFunction _conversionFunction;

        public UnitConversionValueSlot(Unit from, Unit to, ConversionFunction conversionFunction) {
            _from = from;
            _to = to;
            _conversionFunction = conversionFunction;
        }

        public Quantity Convert(Quantity amount) {
            return _conversionFunction(amount.ConvertedTo(_from));
        }
    }
}