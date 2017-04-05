using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public class ClassTests<T> : BaseTests {
        [TestInitialize] public override void TestInitialize() { type = typeof(T); }
        [TestCleanup] public override void TestCleanup() { type = null; }
        protected void isNotEqualTest<tk>(Func<tk> get){
            var x = get();
            var y = get();
            while (x.Equals(y)) y = get();
            Assert.AreNotEqual(x, y);
        }
        protected void isEqualTest<tk>(Func<tk> get) {
            Assert.AreEqual(get(), get());
        }
        protected void isEqualTest<tk>(tk value, Func<tk> get) {
            Assert.AreEqual(value, get());
        }
    }
}
