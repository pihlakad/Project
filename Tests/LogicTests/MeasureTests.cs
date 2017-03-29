using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class MeasureTests
    {
        private Measure m;
        [TestInitialize]
        public void InitTests()
        {
            m = new Measure();
        }

        [TestCleanup]
        public void CleanTests()
        {
            m = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void NameTest() {
            Assert.IsNotNull(m.Name);
            m.Name = null;
            Assert.AreEqual(String.Empty, m.Name);
            m.Name = "Some name";
            Assert.AreEqual("Some name", m.Name);
        }
    }
}
