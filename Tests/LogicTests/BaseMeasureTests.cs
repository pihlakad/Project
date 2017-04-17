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
            //TODO 7: ega siin muud teha tulnud, kui asendada "" vajalikuga
            // sest nüüd meil Formula ilusasti töötab
            //Assert.AreEqual("v^1*t^1", m.Formula());
            Assert.AreEqual("", m.Formula());
        }

        //TODO 8: Tuleks kirjutada ja realiseerida ka test et m1.Multiplay(m1) 
        // valem on v^2
        //[TestMethod]
        //public void MultiplySameMeasuresTest()
        //{
        //    var m1 = new BaseMeasure("v");
        //    Measures.Instance.Add(m1);
        //    var m = m1.Multiply(m1);
        //    Assert.AreEqual("v^2", m.Formula());
        //}

        //TODO 13: Tuleks kirjutada ja realiseerida ka test et saaksime 
        // valemi on v^3, 
        //[TestMethod]
        //public void MultiplyBaseWithDerivedTest()
        //{
        //    var m1 = new BaseMeasure("v");
        //    Measures.Instance.Add(m1);
        //    var m = m1.Multiply(m1);
        //    var m2 = m1.Multiply(m);
        //    Assert.AreEqual("v^2", m.Formula());
        //}

        //TODO 16: analoogiliselt tuleks nüüd teha Multiply eeskujul ka sellised meetodid
        // astendamise, pöördväärtuse ja jagamise kohta ja need ka testida
        // tuletan meelde, et kui MeasureTerms sisse jääb ainult üks element astmega 1
        // on tehte tulemuseks DerivedMeasure asemel BaseMeasure ja et kui 
        // aste muutub nulliks, siis seda elementi ei ole.
        // Kui jääb ainult üks element ja selle aste on null, siis peab aga tehte tulemus 
        // olema Measure.Empty   

    }
}
