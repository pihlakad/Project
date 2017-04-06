namespace Logic.SIBaseUnit
{
    public static class DistanceUnit
    {
        public static void Initialize() {
            var m = Measures.Add("distance");
            Units.Add(m, 1000, "km", "kilomeeter");
            Units.Add(m, 1, "m", "meeter");
            Units.Add(m, 0.1, "dm", "detsimeeter");
            Units.Add(m, 0.01, "cm", "sentimeeter");
            Units.Add(m, 0.001, "mm", "millimeeter");
        }
    }
}
