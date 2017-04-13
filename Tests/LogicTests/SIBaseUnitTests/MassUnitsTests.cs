using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class MassUnitsTests
    {
        [TestMethod]
        public void InitalizeTest()
        {
            Units.Instance.Clear();
            Measures.Instance.Clear();
            MassUnits.Initialize();
            Assert.AreEqual("mass", Measures.Instance.Find(x=>x.Name =="mass").Name);
            Assert.AreEqual("kilogramm", Units.Instance.Find(x=>x.Name=="kilogramm").Name);
        }
    }
}
