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
            Assert.AreEqual("v^1*t^1", m.Formula());
        }

        
        [TestMethod]
        public void MultiplySameMeasuresTest()
        {
            var m1 = new BaseMeasure("s");
            Measures.Instance.Add(m1);
            var m = m1.Multiply(m1);
            Assert.AreEqual("s^2", m.Formula());
        }

       
        [TestMethod]
        public void MultiplyBaseWithDerivedTest()
        {
            var m1 = new BaseMeasure("v");
            Measures.Instance.Add(m1);
            var m = m1.Multiply(m1);
            var m2 = m1.Multiply(m);
            Assert.AreEqual("v^3", m2.Formula());
        }

        [TestMethod]
        public void DivideTest() {
            var m1 = new BaseMeasure("a");
            var m2 = new BaseMeasure("b");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            var m = m1.Divide(m2);
            Assert.AreEqual("a^1*b^-1", m.Formula());
        }

        //[TestMethod]
        //public void DivideWithDerived() {
        //    var m1 = new BaseMeasure("a");
        //    var m2 = new BaseMeasure("b");
        //    Measures.Instance.Add(m1);
        //    Measures.Instance.Add(m2);
        //    var d1 = m1.Multiply(m1);
        //    var d2 = m2.Multiply(m2);
        //    var d = d1.Divide(d2);
        //}

        [TestMethod]
        public void ExponentiationTest() {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var m = m1.Exponentiation(5);
            var s = m1.Exponentiation(1);
            var c = m1.Exponentiation(0);
            var a = m1.Exponentiation(-5);
            Assert.AreEqual("a^5", m.Formula());
            Assert.AreEqual("a", s.Formula());
            Assert.AreEqual(Measure.Empty, c);
            Assert.AreEqual("a^-5", a.Formula());
        }

        [TestMethod]
        public void ReciprocalTest() {
            var m1 = new BaseMeasure("a");
            var m2 = new BaseMeasure("b");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            var m = m1.Reciprocal(m2);
            Assert.AreEqual("a^-1*b^1", m.Formula());
        }
        //TODO 16: analoogiliselt tuleks nüüd teha Multiply eeskujul ka sellised meetodid
        // astendamise, pöördväärtuse ja jagamise kohta ja need ka testida
        // tuletan meelde, et kui MeasureTerms sisse jääb ainult üks element astmega 1
        // on tehte tulemuseks DerivedMeasure asemel BaseMeasure ja et kui 
        // aste muutub nulliks, siis seda elementi ei ole.
        // Kui jääb ainult üks element ja selle aste on null, siis peab aga tehte tulemus 
        // olema Measure.Empty   

    }
}
