using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests
{
    [TestClass]
    public class StringsTests
    {
        private Strings s;
        [TestInitialize]
        public void InitTests()
        {
            s = new Strings();
        }
        [TestCleanup]
        public void CleanTests()
        {
            s = null;
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(s);
        }
        [TestMethod]
        public void EmptyIfNullTest()
        {
            string x = null;
            Assert.IsNull(x);
            x = Strings.EmptyIfNull(x);
            Assert.AreEqual(string.Empty, x);
            string abc = "abc";
            Strings.EmptyIfNull(abc);
            Assert.AreEqual("abc", abc);
        }
    }
}
