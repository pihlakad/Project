using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class AmpereTests {
        private Ampere a;
        [TestInitialize]
        public void InitTests()
        {
            a = new Ampere();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(a.Name, "ampere");
        }
        [TestMethod]
        public void SymbolTest() {
            Assert.AreEqual(a.Symbol, "A");
        }
    }
}
