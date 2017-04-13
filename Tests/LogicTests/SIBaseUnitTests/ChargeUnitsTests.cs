using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class ChargeUnitsTests
    {
        [TestMethod]
        public void InitializeTest()
        {
            Measures.Instance.Clear();
            Units.Instance.Clear();
            ChargeUnits.Initialize();
            Assert.AreEqual("charge", Measures.Instance.Find(x => x.Name == "charge").UniqueId);
            Assert.AreEqual("ampere", Units.Instance.Find(x => x.Name == "ampere").Name);
        }
    }
}
