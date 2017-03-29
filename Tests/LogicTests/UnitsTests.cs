using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class UnitsTests
    {
        private Units<string> u;
        [TestInitialize]
        public void InitTests()
        {
            u = new Units<string>();
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
