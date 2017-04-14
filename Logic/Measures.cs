using System;
using System.Diagnostics.PerformanceData;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Aids;
using Logic.BaseClasses;
using System.Runtime.Serialization;

namespace Logic {
    [KnownType(typeof(BaseMeasure))]
    [KnownType(typeof(DerivedMeasure))]
    [XmlInclude(typeof(BaseMeasure))]
    [XmlInclude(typeof(DerivedMeasure))]

    public class Measures:Archetypes<Measure> {
        public static Measures Instance { get; } = new Measures();

        internal static Measure Add(string name) {
            var m = Instance.Find(x => x.Name == name);
            if (m != null) return m;
            m = new BaseMeasure(name);
            Instance.Add(m);
            return m;
        }

        internal static Measure Find(string measure) {
            return Instance.Find(x => x.UniqueId == measure);
        }

        public static Measures Random() {
            var m = new Measures();
            var c = GetRandom.Count(2, 5);
            for (var i = 0; i < c; i++)
                m.Add(Measure.Random());
            return m;
        }
    }
}
