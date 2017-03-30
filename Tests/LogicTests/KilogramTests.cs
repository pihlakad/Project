using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class KilogramTests
    {
        private Kilogram k;
        [TestInitialize]
        public void InitTests()
        {
            k = new Kilogram();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(k);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(k.Name, "kilogram");
        }
        [TestMethod]
        public void SymbolTest()
        {
            Assert.AreEqual(k.Symbol, "kg");
        }
    }
}
