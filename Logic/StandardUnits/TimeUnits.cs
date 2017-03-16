namespace Logic.StandardUnits {
    public static class TimeUnits {
        public static readonly Unit Second = new Unit("second", "s", SystemOfUnits.SI.Units.Time);
        public static readonly Unit Minute = new Unit("minute", "min", 60.0 * Second);
        public static readonly Unit Hour = new Unit("hour", "h", 3600.0 * Second);
    }
}
