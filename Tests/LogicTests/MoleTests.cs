using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class MoleTests {
        private Mole m;
        [TestInitialize]
        public void InitTests()
        {
            m = new Mole();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(m.Name, "mole");
        }
        [TestMethod]
        public void SymbolTest()
        {
            Assert.AreEqual(m.Symbol,"mol");
        }
    }
}
