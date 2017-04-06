namespace Logic.SIBaseUnit
{
    public static class MassUnits
    {
        public static void Initialize()
        {
            var m = Measures.Add("mass");
            Units.Add(m, 1000, "t", "tonn");
            Units.Add(m, 1, "kg", "kilogramm");
            Units.Add(m, 0.001, "g", "gramm");
            Units.Add(m, 0.000001, "mg", "milligramm");
        }
    }
}
