namespace Logic
{
    public class DerivedMeasure : Measure
    {

        public static void Initialize()
        {
            var m = DerivedMeasure.Add("area");
            Units.Add(m, "m" * "m", "m2", "ruutmeeter");

            var m = DerivedMeasure.Add("volume");
            Units.Add(m, "m" * "m" * "m", "m3", "kuupmeeter");

            var m = DerivedMeasure.Add("speed");
            Units.Add(m, "m" / "s", "m/s", "meetrit sekundis");

            var m = DerivedMeasure.Add("acceleration");
            Units.Add(m, "m" / "s" * "s", "m/s2", "meetrit ruutsekundis");

            var m = DerivedMeasure.Add("current density");
            Units.Add(m, "A" / "m" * "m", "A/m2", "amprit ruutmeetris");

            var m = DerivedMeasure.Add("concentration");
            Units.Add(m, "mol" / "m" * "m" * "m", "mol/m3", "mooli kuumpeetris");

            var m = DerivedMeasure.Add("luminance");
            Units.Add(m, "cd" / "m" * "m", "cd/m2", "meetrit sekundis");

        }
        public DerivedMeasure(string name, string symbol = null) : base(name, symbol)
        {
        
        }
        public DerivedMeasure() : this(string.Empty) { }

        public new static DerivedMeasure Random() {
            var m = new DerivedMeasure();
            m.SetRandomValues();
            return m;
        }
    }
}
