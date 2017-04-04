namespace Logic.SIBaseUnit
{
    public static class TemperatureUnits
    {
        public static void Initialize()
        {
            var m = Measures.Add("temperature");
            Units.Add(m, 1, "°C", "Celsius");
            Units.Add(m, 274.15, "K", "Kelvin");
            Units.Add(m, 33.8, "°F", "Fahrenheit");
        }
    }
}
