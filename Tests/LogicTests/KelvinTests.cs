using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class KelvinTests
    {
        private Kelvin k;
        [TestInitialize]
        public void InitTests()
        {
            k = new Kelvin();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(k);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(k.Name, "kelvin");
        }
        [TestMethod]
        public void SymbolTest()
        {
            Assert.AreEqual(k.Symbol, "K");
        }
    }
}
