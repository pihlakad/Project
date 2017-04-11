using System.Security.Cryptography.X509Certificates;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class DistanceUnitsTests{
        [TestMethod]
        public void InitializeTest() {
            Measures.Instance.Clear();
            Units.Instance.Clear();
            DistanceUnit.Initialize();
            Assert.AreEqual("distance", Measures.Instance.Find(x=>x.Name == "distance").UniqueId);
            Assert.AreEqual("kilomeeter",Units.Instance.Find(x => x.Name == "kilomeeter").UniqueId);
            Assert.AreEqual("meeter", Units.Instance.Find(x => x.Name == "meeter").UniqueId);
            Assert.AreEqual("detsimeeter", Units.Instance.Find(x => x.Name == "detsimeeter").UniqueId);
            Assert.AreEqual("sentimeeter", Units.Instance.Find(x => x.Name == "sentimeeter").UniqueId);
            Assert.AreEqual("millimeeter", Units.Instance.Find(x => x.Name == "millimeeter").UniqueId);

        }
    }
}
