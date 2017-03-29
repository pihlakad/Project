using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class UnitTests
    {
        private Unit u;
        [TestInitialize]
        public void InitTests()
        {
            u = new Unit();
        }

        [TestCleanup]
        public void CleanTests()
        {
            u = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(u);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.IsNotNull(u.Name);
            u.Name = null;
            Assert.AreEqual(String.Empty, u.Name);
            u.Name = "Some name";
            Assert.AreEqual("Some name", u.Name);
        }

        [TestMethod]
        public void SystemOfUnitsTest() {
            Assert.IsNotNull(u.SystemOfUnits);
            u.SystemOfUnits = null;
            Assert.AreEqual(String.Empty, u.SystemOfUnits);
            u.SystemOfUnits = "Some System";
            Assert.AreEqual("Some System", u.SystemOfUnits);
        }
        [TestMethod]
        public void Measure()
        {
            Assert.IsNotNull(u.Measure);
            u.Measure = null;
            Assert.AreEqual(String.Empty, u.Measure);
            u.Measure = "Some Measure";
            Assert.AreEqual("Some Measure", u.Measure);
        }
    }
}
