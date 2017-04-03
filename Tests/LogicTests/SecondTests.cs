using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class SecondTests
    {
        private Second s;
        [TestInitialize]
        public void InitTests()
        {
            s = new Second();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(s.Name, "second");
        }
        [TestMethod]
        public void SymbolTest()
        {
            Assert.AreEqual(s.Symbol, "s");
        }
    }
}
