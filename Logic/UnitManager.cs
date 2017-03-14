using System;
using System.Collections.Generic;

namespace Logic {
    public delegate Unit UnitResolveEventHandler(object sender, ResolveEventArgs args);
    public delegate Quantity ConversionFunction(Quantity originalAmount);

    public sealed class UnitManager {
        private static UnitManager _instance;
        private readonly Dictionary<UnitConversionKeySlot, UnitConversionValueSlot> _conversions = new Dictionary<UnitConversionKeySlot, UnitConversionValueSlot>();

        // UnitManager singleton
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
                if (ReferenceEquals(amount.Unit, toUnit)) {
                    return amount;
                }

                // Perform conversion:
                if (amount.Unit.IsCompatibleTo(toUnit)) {
                    return new Quantity(amount.Value * amount.Unit.Factor / toUnit.Factor, toUnit);
                }

                UnitConversionKeySlot expectedSlot = new UnitConversionKeySlot(amount.Unit, toUnit);
                return Instance._conversions[expectedSlot].Convert(amount).ConvertedTo(toUnit);
            } catch (KeyNotFoundException) {
                throw new InvalidOperationException();
            }
        }
    }
}
