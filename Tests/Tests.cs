using System;
using Aids;
using Logic.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public class Tests: Serializable {
        protected void testProperty(Func<string> get, Action<string> set) {
            var s = GetRandom.String();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
            set(null);
            Assert.AreEqual(s, get());
        }
        protected void testProperty<T>(Func<T> get, Action<T> set) where T : new() {
            Assert.IsNotNull(get());
            Assert.IsInstanceOfType(get(), typeof(T));
            var a1 = get();
            var a2 = new T();
            Assert.AreNotEqual(a2, get());
            set(a2);
            Assert.AreEqual(a2, get());
            Assert.AreNotEqual(a1, get());
            set(default(T));
            Assert.IsNotNull(get());
        }
        protected void testProperty(Func<DateTime> get, Action<DateTime> set) {
            var s = GetRandom.DateTime();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testProperty(Func<bool> get, Action<bool> set) {
            var s = !get();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testProperty(Func<double> get, Action<double> set) {
            var s = GetRandom.Double();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testProperty(Func<decimal> get, Action<decimal> set)
        {
            var s = GetRandom.Decimal();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testProperty(Func<int> get, Action<int> set) {
            var s = GetRandom.Int32();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testProperty(Func<uint> get, Action<uint> set) {
            var s = GetRandom.UInt32();
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testEnumProperty<T>(Func<T> get, Action<T> set) {
            Assert.IsTrue(typeof(T).IsEnum);
            var x = get();
            var s = GetRandom.Enum< T>();
            while (x.Equals(s)) { s = GetRandom.Enum<T>();}
            Assert.AreNotEqual(s, get());
            set(s);
            Assert.AreEqual(s, get());
        }
        protected void testSingleton<T>(Func<T> get) {
            var s = get();
            Assert.IsNotNull(s);
            Assert.AreEqual(s, get());
        }
    }
}
