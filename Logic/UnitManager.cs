using System;
using System.Collections.Generic;

namespace Logic {
    public delegate Unit UnitResolveEventHandler(object sender, ResolveEventArgs args);
    public delegate Quantity ConversionFunction(Quantity originalAmount);

    public sealed class UnitManager {
        private static UnitManager _instance;
        private readonly Dictionary<UnitConversionKeySlot, UnitConversionValueSlot> _conversions = new Dictionary<UnitConversionKeySlot, UnitConversionValueSlot>();

        public static UnitManager Instance {
            get {
                if (_instance == null) {
                    _instance = new UnitManager();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public static Quantity ConvertTo(Quantity amount, Unit toUnit) {
            try {
                // Performance optimalization:
                if (Object.ReferenceEquals(amount.Unit, toUnit)) {
                    return amount;
                }

                // Perform conversion:
                if (amount.Unit.IsCompatibleTo(toUnit)) {
                    return new Quantity(amount.Value * amount.Unit.Factor / toUnit.Factor, toUnit);
                } else {
                    UnitConversionKeySlot expectedSlot = new UnitConversionKeySlot(amount.Unit, toUnit);
                    return Instance._conversions[expectedSlot].Convert(amount).ConvertedTo(toUnit);
                }
            } catch (KeyNotFoundException) {
                throw new UnitConversionException(amount.Unit, toUnit);
            }
        }

        private class UnitConversionKeySlot {
            private UnitType fromType, toType;

            public UnitConversionKeySlot(Unit from, Unit to) {
                this.fromType = from.UnitType;
                this.toType = to.UnitType;
            }

            public override bool Equals(object obj) {
                UnitConversionKeySlot other = obj as UnitConversionKeySlot;
                return (this.fromType == other.fromType) && (this.toType == other.toType);
            }

            public override int GetHashCode() {
                return this.fromType.GetHashCode() ^ this.toType.GetHashCode();
            }
        }

        private class UnitConversionValueSlot {
            private Unit from, to;
            private ConversionFunction conversionFunction;

            public UnitConversionValueSlot(Unit from, Unit to, ConversionFunction conversionFunction) {
                this.from = from;
                this.to = to;
                this.conversionFunction = conversionFunction;
            }

            public Quantity Convert(Quantity amount) {
                return this.conversionFunction(amount.ConvertedTo(from));
            }
        }
    }
}
