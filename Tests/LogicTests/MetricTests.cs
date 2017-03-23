using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class MetricTests {
        private Metric m;
        [TestInitialize]
        public void InitTests() {
            m = new Metric();
        }

        [TestCleanup]
        public void CleanTests() {
            m = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void NameTest() {
            Assert.IsNotNull(m.Name);
            m.Name = null;
            Assert.IsNotNull(m.Name);
        }
    }
}
