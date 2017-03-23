using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class ArchetypesTests
    {
        private Archetypes<string> a;
        [TestInitialize]
        public void InitTests()
        {
            a = new Archetypes<string>();
        }

        [TestCleanup]
        public void CleanTests()
        {
            a = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(a);
        }
    }
}
