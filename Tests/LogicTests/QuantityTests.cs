using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class QuantityTest: CommonTests<Quantity> {
        private Quantity quantity;

        [TestInitialize]
        public void InitTests() {
            quantity = new Quantity();
        }

        [TestCleanup]
        public void CleanTests() {
            quantity = null;
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(quantity);
        }

        protected override Quantity getRandomObj() {
            return Quantity.Random();
        }
    }
}
