using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class DerivedUnitTests {
        private DerivedUnit t;
        private BaseUnit m1;
        private BaseUnit m2;
        private BaseUnit m3;
        private DerivedUnit d1;
        private DerivedUnit d2;
        private DerivedUnit d3;
        private DerivedUnit d4;

        [TestInitialize]
        public void InitTests() {
            t = new DerivedUnit();
            m1 = new BaseUnit();
            m2 = new BaseUnit();
            m3 = new BaseUnit();
            Units.Instance.Add(m1);
            Units.Instance.Add(m2);
            Units.Instance.Add(m3);
            d1 = (DerivedUnit) m1.Multiply(m2);
            d2 = (DerivedUnit) m1.Multiply(m3);
            d3 = (DerivedUnit) m2.Multiply(m3);
            d4 = (DerivedUnit) m3.Multiply(m3);
            
        }

        [TestCleanup]
        public void CleanTests() {t = null;}

        [TestMethod]
        public void ExponentationTest() {
            var a = d1.Exponentiation(3);
            var b = d2.Exponentiation(5);
            var c = d3.Exponentiation(0);
            Assert.AreEqual("k^3*p^3", a.Formula());
            Assert.AreEqual("k^10", b.Formula());
            Assert.AreEqual(Unit.Empty,c);
        }

        [TestMethod]
        public void ReciprocalTest() {
            var a = d1.Reciprocal();
            var b = d3.Reciprocal();
            Assert.AreEqual("v^-1*t^-1", a.Formula());
            Assert.AreEqual("c^-2", b.Formula());
        }

       
    }

  }

