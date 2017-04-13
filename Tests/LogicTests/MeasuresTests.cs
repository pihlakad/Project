using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class MeasuresTest: CommonTests<Measures> {
        private Measures measures;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            measures = new Measures();
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(measures);
        }

        protected override Measures getRandomObj() {
            var r = Measures.Random();
            return r;
        }
    }
}
