using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class DistanceUnitsTests {
        [TestMethod]
        public void InitializeTest() {
            Measures.Instance.Clear();
            Units.Instance.Clear();
            DistanceUnit.Initialize();
            Assert.AreEqual("distance", Measures.Instance.Find(x=>x.Name == "distance").UniqueId);
            Assert.AreEqual("meeter", Units.Instance.Find(x => x.Name == "meeter").Name);
        }
    }
}
