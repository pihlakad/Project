﻿using System;

namespace Logic
{
    public class BaseMeasure : Measure
    {
        public BaseMeasure(string name, string symbol = null) : base(name, symbol)
        {

        }

        public BaseMeasure():this(string.Empty) {
            
        }

        public new static BaseMeasure Random() {
            var m = new BaseMeasure();
            m.SetRandomValues();
            return m;
        }

        public static Unit GetBaseMeasure(Measure measure) {
            return Logic.Units.Instance.Find(x => x.Factor == 1);
        }
    }
}
