using System.Runtime.Serialization;
using System.Xml.Serialization;
using Aids;
using Logic.BaseClasses;

namespace Logic
{
    [KnownType(typeof(BaseUnit))]
    [KnownType(typeof(DerivedUnit))]
    [XmlInclude(typeof(BaseUnit))]
    [XmlInclude(typeof(DerivedUnit))]
    [KnownType(typeof(BaseMeasure))]
    [XmlInclude(typeof(BaseMeasure))]  
    public class Units : Archetypes<Unit>
    {        
        public static Units Instance { get;  } = new Units();

        internal static Unit Add(Measure m, double factor, string symbol, string name = null)
        {
            var u = Instance.Find(x=> x.Measure == m && x.Symbol == symbol );
            if (u != null) return u;
            u = new BaseUnit(m, factor, symbol, name);
            Instance.Add(u);
            return u;
        }

        internal static Unit Add(DerivedMeasure m, double factor, string symbol, string name = null)
        {
            var u = Instance.Find(x => x.Measure == m && x.Symbol == symbol);
            if (u != null) return u;
            u = new BaseUnit(m, factor, symbol, name);
            Instance.Add(u);
            return u;
        }

        internal static Unit Find(string unit)
        {
            return Instance.Find(x => x.UniqueId == unit);
        }

        public static Units Random() {
            var u = new Units();
            var c = GetRandom.Count(2, 5);
            for (int i = 0; i < c; i++) {
                u.Add(Unit.Random());
            }
            return u;
        }
    }
}
