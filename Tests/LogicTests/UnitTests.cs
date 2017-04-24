using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class UnitTests
    {
        private Unit u;
        [TestInitialize]
        public void InitTests(){
            u = new BaseUnit();
        }

        [TestCleanup]
        public void CleanTests(){
            u = null;
        }
        [TestMethod]
        public void ConstructorTest(){
            Assert.IsNotNull(u);
        }

        [TestMethod]
        public void NameTest(){
            Assert.IsNotNull(u.Name);
            u.Name = null;
            Assert.AreEqual(String.Empty, u.Name);
            u.Name = "Some name";
            Assert.AreEqual("Some name", u.Name);
        }

        [TestMethod]
        public void SystemOfUnitsTest() {
            Assert.IsNotNull(u.SystemOfUnits);
            u.SystemOfUnits = null;
            Assert.AreEqual(String.Empty, u.SystemOfUnits);
            u.SystemOfUnits = "Some System";
            Assert.AreEqual("Some System", u.SystemOfUnits);
        }
        [TestMethod]
        public void Measure(){
            Assert.IsNotNull(u.Measure);
            u.Measure = null;
            Assert.AreEqual(String.Empty, u.Measure);
            u.Measure = "Some Measure";
            Assert.AreEqual("Some Measure", u.Measure);
        }

        [TestMethod]
        public void ExponentationTest()
        {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var m = m1.Exponentiation(5);
            var s = m1.Exponentiation(1);
            var c = m1.Exponentiation(0);
            var a = m1.Exponentiation(-5);
            Assert.AreEqual("a^5", m.Formula());
            Assert.AreEqual("a", s.Formula());
            Assert.AreEqual(Logic.Measure.Empty, c);
            Assert.AreEqual("a^-5", a.Formula());
        }

        //[TestMethod]
        //public void ExponentationTest()
        //{
        //    var m1 = new BaseMeasure("a");
        //    var u = new BaseUnit(m1, 1, "s", "pikkus");
        //    Units.Instance.Add(u);
        //    var m = u.Exponentiation(5);
        //    var s = u.Exponentiation(1);
        //    var c = u.Exponentiation(0);
        //    var a = u.Exponentiation(-5);
        //    Assert.AreEqual("s^5", m.Formula());
        //    Assert.AreEqual("s", s.Formula());
        //    Assert.AreEqual(Logic.Unit.Empty, c);
        //    Assert.AreEqual("s^-5", a.Formula());
        //}

        [TestMethod]
        public void ReciprocalTest() {
           var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var m = m1.Reciprocal();
            Assert.AreEqual("a^-1",m.Formula());
        }

        [TestMethod]

        public void MultiplyTest()
        {
        }

        [TestMethod]
        public void DivideTest()
        {
        }

    }

}
