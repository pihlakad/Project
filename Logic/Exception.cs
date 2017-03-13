using System;
using System.Runtime.Serialization;

namespace Logic {
    public class UnitConversionException : InvalidOperationException {
        public UnitConversionException() : base() { }

        public UnitConversionException(string message) : base(message) { }

        public UnitConversionException(Unit fromUnit, Unit toUnit) : this(String.Format("Failed to convert from unit '{0}' to unit '{1}'. Units are not compatible and no conversions are defined.", fromUnit.Name, toUnit.Name)) { }

        protected UnitConversionException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
