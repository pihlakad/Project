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
    }
}
