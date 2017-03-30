using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class QuantityTest {
        private Quantity _quantity;

        [TestInitialize]
        public void InitTests() {
            _quantity = new Quantity();
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(_quantity);
        }
    }
}
