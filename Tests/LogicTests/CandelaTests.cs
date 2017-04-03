using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class CandelaTests
    {
        private Candela c;

        [TestInitialize]
        public void InitTests()
        {
            c = new Candela();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(c.Name, "candela");
        }

        [TestMethod]
        public void SymbolTest() {
            Assert.AreEqual(c.Symbol,"cd");
        }
    }
}
