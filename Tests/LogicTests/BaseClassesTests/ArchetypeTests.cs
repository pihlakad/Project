using Logic.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.BaseClassesTests
{
    [TestClass]
    public class ArchetypeTests
    {
        private Archetype a;
        [TestInitialize]
        public void InitTests()
        {
            a = new Archetype();
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
