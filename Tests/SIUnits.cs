using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archetypes.SystemOfUnits.SI.Units;

namespace Tests {
    [TestClass]
    public class SiUnits {
        [TestMethod]
        public void Kelvin() {
            Kelvin unit = new Kelvin();

            Assert.AreEqual("K", unit.GetSymbol());
            Assert.AreEqual("kelvin", unit.GetName());
        }
    }
    [TestClass]
    public class KilogramTest {
        [TestMethod]
        public void Kilogram()
        {
            Kilogram unit = new Kilogram();

            Assert.AreEqual("kg", unit.GetSymbol());
            Assert.AreEqual("kilogram", unit.GetName());
        }
    }
    [TestClass]
    public class MeterTest {
        [TestMethod]
        public void Meter() {
            Meter unit = new Meter();

            Assert.AreEqual("m", unit.GetSymbol());
            Assert.AreEqual("meter", unit.GetName());
        }
    }
    [TestClass]
    public class SecondTest {
        [TestMethod]
        public void Second() {
            Second unit = new Second();
            
            Assert.AreEqual("s", unit.GetSymbol());
            Assert.AreEqual("second", unit.GetName());
        }
    }
}
