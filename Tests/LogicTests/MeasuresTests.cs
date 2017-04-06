using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class MeasuresTest: CommonTests<Measures> {
        private Measures _measures;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            _measures = new Measures();
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(_measures);
        }

        protected override Measures getRandomObj() {
            var r = Measures.Random();
            return r;
        }
    }
}
