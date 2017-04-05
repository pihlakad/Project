using System.Globalization;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class UseCultureTests : ClassTests<UseCulture> {
        [TestMethod] public void InvariantTest() {
            Assert.AreEqual(CultureInfo.InvariantCulture, UseCulture.Invariant);
        }
        [TestMethod] public void EnglishTest() {
            Assert.AreEqual(new CultureInfo("en-GB"), UseCulture.English);
        }
        [TestMethod] public void CurrentTest() {
            Assert.AreEqual(CultureInfo.CurrentCulture, UseCulture.Current);
        }
    }
}
