using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.SIBaseUnitTests
{
    [TestClass]
    public class DistanceUnitsTests {
        [TestMethod]
        public void InitializeTest() {
            var m = Measures.Instance.Find(x => x.Name =="distance");
            if (m != null)
                Measures.Instance.Remove(m);
            var n = Measures.Instance.Find(x => x.Name == "distance");
            Assert.IsNull(n);
            DistanceUnits.Initialize();
            n = Measures.Instance.Find(x => x.Name == "distance");
            Assert.IsNotNull(n);
            Assert.AreEqual("distance", n.Name);
        }
    }
}
