using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class UtilsTests : ClassTests<Utils> {
        [TestMethod] public void IsNullTest() {
            Assert.IsTrue(Utils.IsNull(null));
            Assert.IsFalse(Utils.IsNull(GetRandom.String()));
            Assert.IsFalse(Utils.IsNull(GetRandom.Char()));
            Assert.IsFalse(Utils.IsNull(GetRandom.Decimal()));
            Assert.IsFalse(Utils.IsNull(new object()));
        }
    }
}
