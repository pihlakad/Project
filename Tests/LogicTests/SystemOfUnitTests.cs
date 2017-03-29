using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class SystemOfUnitTests {
        private SystemOfUnit s;
        [TestInitialize]
        public void InitTests(){
            s = new SystemOfUnit();
        }

        [TestCleanup]
        public void CleanTests() {
            s = null;
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(s);
        }

        [TestMethod]
        public void NameTest() {
            Assert.IsNotNull(s.Name);
            s.Name = null;
            Assert.AreEqual(String.Empty, s.Name);
            s.Name = "Some name";
            Assert.AreEqual("Some name", s.Name);
        }
    }
}
