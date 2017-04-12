using Aids;
using Logic.BaseClasses;

namespace Logic {
    public class Rounding : Archetype {
        private const byte maxDigit = 9;
        private const byte maxDecimals = 10;

        private Approximate strategy;
        private sbyte decimals;
        private byte digit;
        private double step;

        public Rounding() : this(Approximate.Common) { }

        public Rounding(Approximate s, sbyte decimals = 2, byte digit = 5,
            double step = 0.1) {
            strategy = s;
            this.decimals = validateDecimals(decimals);
            this.digit = validateDigit(digit);
            this.step = validateStep(step);
        }
        private static double validateStep(double x) {
            if (x > 0 && x <= 1.0) return x;
            return 1.0;
        }
        private static byte validateDigit(byte x) { return x < maxDigit ? x : maxDigit; }

        private static sbyte validateDecimals(sbyte x) {
            if (x > maxDecimals) return 2;
            if (x < - maxDecimals) return 2;
            return x;
        }
        public Approximate Strategy {
            get { return SetDefault(ref strategy); }
            set { SetValue(ref strategy, value); }
        }
        public double Step {
            get { return step; }
            set { SetValue(ref step, validateStep(value)); }
        }
        public sbyte Decimals {
            get { return decimals; }
            set { SetValue(ref decimals, validateDecimals(value)); }
        }
        public byte Digit {
            get { return digit; }
            set { SetValue(ref digit, validateDigit(value)); }
        }
        public static Rounding Random() {
            var s = GetRandom.Enum<Approximate>();
            var decimals = GetRandom.Int8(-10, 10);
            var rd = GetRandom.UInt8(0, 9);
            var rs = 0.05*GetRandom.UInt8(0, 10);
            return new Rounding(s, decimals, rd, rs);
        }
        public static Rounding Empty { get; } = new Rounding();
        public override bool IsEmpty() {return Equals(Empty); } 
    }
}
