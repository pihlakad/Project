
namespace Logic
{
    public class DerivedMeasure : Measure
    {

        public static void Initialize()
        {
            var a = Measures.Add("area");            
            Logic.Units.Add(a, 1, "m2", "ruutmeeter");

            var v = Measures.Add("volume");
            Logic.Units.Add(v, 1, "m3", "kuupmeeter");

            var s = Measures.Add("speed");
            Logic.Units.Add(s, 1, "m/s", "meetrit sekundis");

            var t = Measures.Add("acceleration");
            Logic.Units.Add(t, 1, "m/s2", "meetrit ruutsekundis");

            var c = Measures.Add("current density");
            Logic.Units.Add(c, 1, "A/m2", "amprit ruutmeetris");

            var u = Measures.Add("concentration");
            Logic.Units.Add(u, 1, "mol/m3", "mooli kuumpeetris");

            var l = Measures.Add("luminance");
            Logic.Units.Add(l, 1, "cd/m2", "meetrit sekundis");

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
