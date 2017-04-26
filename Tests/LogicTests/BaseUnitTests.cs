using System;
using Logic;
using Logic.SIBaseUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class BaseUnitTests
    {
       

       [TestMethod]
       public void ExponentationTest()
       {
          var m1 = new BaseMeasure("s");
         var u = new BaseUnit(m1, 1, "s", "pikkus");
          Units.Instance.Add(u);
          var m = u.Exponentiation(4);
          var s = u.Exponentiation(1);
          var c = u.Exponentiation(0);
          var a = u.Exponentiation(-4);
          Assert.AreEqual("s^4", m.Formula());
          Assert.AreEqual("s", s.Formula());
          Assert.AreEqual(Unit.Empty, c);
          Assert.AreEqual("s^-4", a.Formula());
      }

        [TestMethod]
        public void ReciprocalTest()
        {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var m = m1.Reciprocal();
            Assert.AreEqual("a^-1", m.Formula());
        }
        
    }
    
}


