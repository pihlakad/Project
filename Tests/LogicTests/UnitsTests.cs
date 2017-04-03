using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class UnitsTests
    {
        private Units u;
        [TestInitialize]
        public void InitTests()
        {
            u = new Units();
        }

        [TestCleanup]
        public void CleanTests()
        {
            u = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(u);
        }
    }
}
