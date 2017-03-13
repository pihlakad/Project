namespace Logic {
    public static class SIUnitTypes {
        public static readonly UnitType Length = new UnitType("metre");
    }

    public static class LengthUnits {
        public static readonly Unit Meter = new Unit("meter", "m", SIUnitTypes.Length);
        public static readonly Unit KiloMeter = new Unit("kilometer", "km", 1000.0 * Meter);
    }
}