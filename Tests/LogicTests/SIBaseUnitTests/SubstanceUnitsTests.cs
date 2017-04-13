using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class SubstanceUnitsTests
    {
        [TestMethod]
        public void InitalizeTest()
        {
            Units.Instance.Clear();
            Measures.Instance.Clear();
            SubstanceUnits.Initialize();
            Assert.AreEqual("substance", Measures.Instance.Find(x => x.Name == "substance").Name);
            Assert.AreEqual("mole", Units.Instance.Find(x => x.Name == "mole").Name);
        }
    }
}
