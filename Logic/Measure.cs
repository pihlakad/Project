using System;
using Aids;

namespace Logic
{
    public class Measure : Metric {

        public Measure(string name, string symbol= null) {
            name = name ?? string.Empty;
            symbol = symbol ?? name;
            Name = name;
            Symbol = symbol;
            UniqueId = name;
        }

        public Measure() : this(String.Empty) {
            
        }


        public void Units() {
            
        }

        public static Measure Random() {
            if (GetRandom.Bool()) return BaseMeasure.Random();
            return DerivedMeasure.Random();
        }
    }
}
