using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class UnitsTests:CommonTests<Units>
    {
        private Units unit;
        [TestInitialize]
        public override void TestInitialize()
        {
            unit = new Units();
        }
        
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(unit);
        }

        protected override Units getRandomObj() {
            var r = Units.Random();
            return r;
        }
    }
}
