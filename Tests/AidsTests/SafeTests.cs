using System;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class SafeTests : ClassTests<Safe> {
        [TestMethod] public void RunTest() {
            var a = Safe.Run(() => { throw new Exception(); }, false);
            Assert.AreEqual(false, a);
        }
        [TestMethod] public void RunActionTest() {
            Safe.Run(() => { throw new Exception(); });
        }
    }
}
