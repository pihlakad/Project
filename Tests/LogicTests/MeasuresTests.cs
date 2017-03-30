using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class MeasuresTest {
        private Measures _measures;

        [TestInitialize]
        public void InitTests() {
            _measures = new Measures();
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(_measures);
        }
    }
}
