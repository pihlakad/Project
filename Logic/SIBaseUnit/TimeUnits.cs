namespace Logic.SIBaseUnit
{
    public static class TimeUnits
    {
        public static void Initialize()
        {
            var m = Measures.Add("time");
            Units.Add(m, 3600, "h", "tund");
            Units.Add(m, 60, "min", "minut");
            Units.Add(m, 1, "s", "sekund");
            Units.Add(m, 0.01, "ms", "millisekund");
        }
    }
}
