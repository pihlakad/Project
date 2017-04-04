namespace Logic.SIBaseUnit
{
    public static class ChargeUnits
    {
        public static void Initialize()
        {
            var m = Measures.Add("charge");
            Units.Add(m, 1000, "kA", "kiloampere");
            Units.Add(m, 1, "A", "ampere");
            Units.Add(m, 0.001, "mA", "milliampere");
            Units.Add(m, 0.000001, "μA", "microampere");
        }
    }
}
