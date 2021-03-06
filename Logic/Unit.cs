﻿using Aids;

namespace Logic
{
    public abstract class Unit : Metric {
        protected string systemOfUnits;
        protected Measure measure;
        protected double factor;

        protected Unit(string name, string symbol = null, string definition = null) : base(name, symbol, definition)
        {
        }

        protected Unit() : this(string.Empty) { }

        public string SystemOfUnits {
            get { return Strings.EmptyIfNull(systemOfUnits); }
            set { systemOfUnits = value; }
        }

        public Measure Measure {
            get { return measure?? Measure.Empty; }
            set { measure = value; }
        }

        public double Factor {
            get { return factor; }
            set { factor = value; }
        }

        public static Unit Empty { get; } = new BaseUnit {isReadOnly = true};

        public Measure GetMeasure => Measures.Find(Measure.Name) ?? Logic.Measure.Empty;

        public void GetSystemOfUnits() {}

        public double ToBase(double amount) {
            return amount*factor;
        }

        public double FromBase(double amount) {
            return amount/factor;
        }

        public static double SetFactor(string s) {
            if (s.Length == 1) return 1;
            string firstLetter = s.Substring(0,1);
            string secondLetter = s.Substring(1, 1);            
            if (firstLetter == "c") return Factors.Centi;
            if (firstLetter == "d" && secondLetter =="a") return Factors.Deca;
            if (firstLetter == "d") return Factors.Deci;
            if (firstLetter == "h") return Factors.Hecto;
            if (firstLetter == "k") return Factors.Kilo;
            if (firstLetter == "M") return Factors.Mega;
            if (firstLetter == "G") return Factors.Giga;
            if (firstLetter == "T") return Factors.Tera;
            if (firstLetter == "μ") return Factors.Micro;
            if (firstLetter == "n") return Factors.Nano;
            if (firstLetter == "p") return Factors.Pico;            
            return 1;
        }

        public static Unit Random() {
            var n = new BaseUnit();
            n.SetRandomValues();
            n.Measure = Measure.Random();
            n.Factor = GetRandom.Double();
            n.SystemOfUnits = GetRandom.String();
            return n;
        }        
    }
}


