using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class MeterTests
    {
        private Meter m;
        [TestInitialize]
        public void InitTests()
        {
            m = new Meter();
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(m.Name, "meter");
        }
        [TestMethod]
        public void SymbolTest()
        {
            Assert.AreEqual(m.Symbol, "m");
        }
    }
}
