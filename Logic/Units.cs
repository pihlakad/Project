using System;
using Logic.BaseClasses;

namespace Logic
{
    public class Units : Archetypes<Unit>
    {
        public static Units Instance { get;  } = new Units();

        internal static Unit Add(Measure m, double factor, string symbol, string name = null)
        {
            var u = Instance.Find(x=> x.Measure == m.UniqueId && x.Symbol == symbol );
            if (u != null) return u;
            u = new Unit(m, factor, symbol, name);
            Instance.Add(u);
            return u;
        }

        internal static Unit Find(string unit)
        {
            return Instance.Find(x => x.UniqueId == unit);
        }
    }
}
