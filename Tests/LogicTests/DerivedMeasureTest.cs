using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace Tests.LogicTests
{
    [TestClass]
    public class DerivedMeasureTest
    {
        private DerivedMeasure t;
        [TestInitialize]
        public void InitTests()
        {
            t = new DerivedMeasure();
        }

        [TestCleanup]
        public void CleanTests()
        {
            t = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(t);
        }

    }
}
