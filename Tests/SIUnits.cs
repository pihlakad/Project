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
}
