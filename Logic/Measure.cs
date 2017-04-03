using System;
using Aids;

namespace Logic
{
    public class Measure : Metric {

        public Measure(string name, string symbol= null) {
            symbol = symbol ?? name;
            Name = name;
            Symbol = symbol;
            UniqueId = name;
        }

        public Measure() : this(String.Empty) {
            
        }


        public void Units() {
            
        }
    }
}
