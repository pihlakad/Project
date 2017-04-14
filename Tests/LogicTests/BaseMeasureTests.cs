using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class BaseMeasureTests: CommonTests<BaseMeasure> {
        protected override BaseMeasure getRandomObj() {
            return BaseMeasure.Random();
        }
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
        [TestMethod] public void FormulaTest() {
            Assert.AreEqual(Obj.Symbol, Obj.Formula());
        }
        [TestMethod] public void MultiplyTest() {
            var m1 = new BaseMeasure("v");
            var m2 = new BaseMeasure("t");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            var m = m1.Multiply(m2);
            Assert.AreEqual("", m.Formula());
        }
    }
}
