namespace Logic.StandardUnits {
    public static class LengthUnits {
        public static readonly Unit Meter = new Unit("meter", "m", SystemOfUnits.SI.Units.Length);
        public static readonly Unit CentiMeter = new Unit("meter", "cm", 0.001 * Meter);
        public static readonly Unit KiloMeter = new Unit("kilometer", "km", 1000.0 * Meter);
    }
}