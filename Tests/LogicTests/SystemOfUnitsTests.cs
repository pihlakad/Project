using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class SystemOfUnitsTests
    {

        private SystemOfUnits<string> s;
        [TestInitialize]
        public void InitTests()
        {
            s = new SystemOfUnits<string>();
        }

        [TestCleanup]
        public void CleanTests()
        {
            s = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(s);
        }
    }
}
