using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class IntensityUnitsTests
    {
        [TestMethod]
        public void InitializeTest()
        {
            Measures.Instance.Clear();
            Units.Instance.Clear();
            IntensityUnits.Initialize();
            Assert.AreEqual("intensity", Measures.Instance.Find(x => x.Name == "intensity").UniqueId);
            Assert.AreEqual("candela", Units.Instance.Find(x => x.Name == "candela").Name);
        }
    }
}
