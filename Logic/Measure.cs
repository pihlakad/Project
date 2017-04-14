using System;
using Aids;

namespace Logic
{
    public abstract class Measure : Metric {

        protected Measure(string name, string symbol= null) : base(name, symbol) {
        }

        protected Measure() : this(String.Empty) {
            
        }
        public void Units() {
            
        }
        public static Measure Random() {
            if (GetRandom.Bool()) return BaseMeasure.Random();
            return DerivedMeasure.Random();
        }
        public static Measure Empty { get; } = new BaseMeasure { isReadOnly = true };
    }
}
