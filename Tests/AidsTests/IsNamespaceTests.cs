﻿using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class IsNamespaceTests : ClassTests<IsNamespace> {
        [TestMethod] public void RunningTest() {
            Assert.IsFalse(IsNamespace.Running(null));
            Assert.IsFalse(IsNamespace.Running(string.Empty));
            Assert.IsFalse(IsNamespace.Running("Bla-bla"));
            Assert.IsTrue(IsNamespace.Running("Open.Aids"));
        }
    }
}
