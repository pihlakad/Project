using System;
using System.Collections.Generic;

namespace Logic {
    public sealed class UnitManager {
        private static UnitManager _instance;

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
                if (amount.Unit.IsCompatibleTo(toUnit)) {
                    return new Quantity(amount.Value * amount.Unit.Factor / toUnit.Factor, toUnit);
                }

                return Quantity.Zero(toUnit);
            } catch (KeyNotFoundException) {
                throw new InvalidOperationException();
            }
        }
    }
}
