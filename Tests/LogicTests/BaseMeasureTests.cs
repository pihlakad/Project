using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class BaseMeasureTests {
        private BaseMeasure b;
        [TestInitialize]
        public void InitTests() {
            b = new BaseMeasure();
        }

        [TestCleanup]
        public void CleanTests() {
            b = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(b);
        }
    }
}
