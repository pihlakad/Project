using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class TemperatureUnitsTests
    {
        [TestMethod]
        public void InitalizeTest()
        {
            Units.Instance.Clear();
            Measures.Instance.Clear();
            TemperatureUnits.Initialize();
            Assert.AreEqual("temperature", Measures.Instance.Find(x => x.Name == "temperature").Name);
            Assert.AreEqual("Celsius", Units.Instance.Find(x => x.Name == "Celsius").Name);
        }
    }
}
