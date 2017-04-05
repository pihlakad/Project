using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aids;

namespace Tests.AidsTests {
    [TestClass] public class CharTests : ClassTests<Char> {
        [TestMethod] public void IsDotTest() {
            for (var i = 0; i < 10; i++) {
                var c = GetRandom.Char();
                if (c == '.') Assert.IsTrue(Char.IsDot('.'));
                else Assert.IsFalse(Char.IsDot(','));
            }
        }
        [TestMethod] public void SpaceTest() { Assert.AreEqual(' ', Char.Space); }
        [TestMethod] public void EolTest() { Assert.AreEqual('\n', Char.Eol); }
        [TestMethod] public void TabTest() { Assert.AreEqual('\t', Char.Tab); }
        [TestMethod]
        public void CommaTest() { Assert.AreEqual(',', Char.Comma); }
    }
}
