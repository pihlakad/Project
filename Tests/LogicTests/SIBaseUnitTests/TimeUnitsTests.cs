using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class TimeUnitsTests
    {
        [TestMethod]
        public void InitalizeTest()
        {
            Units.Instance.Clear();
            Measures.Instance.Clear();
            TimeUnits.Initialize();
            Assert.AreEqual("time", Measures.Instance.Find(x => x.Name == "time").Name);
            Assert.AreEqual("minut", Units.Instance.Find(x => x.Name == "minut").Name);
        }
    }
}
