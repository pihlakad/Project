using System.Reflection;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    internal class testClass {
        public void A() { b(); }
        private void b() { }
        public static void C() { d(); }
        private static void d() { }
    }
    [TestClass] public class GetPublicTests : ClassTests<GetPublic> {
        private static BindingFlags p = BindingFlags.Public;
        private static BindingFlags i = BindingFlags.Instance;
        private static BindingFlags s = BindingFlags.Static;
        private static BindingFlags d = BindingFlags.DeclaredOnly;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(testClass);
        }
        [TestMethod] public void AllTest() {
            var a = type.GetMembers(GetPublic.All);
            Assert.AreEqual(i | s | p, GetPublic.All);
            Assert.AreEqual(7, a.Length);
        }
        [TestMethod] public void InstanceTest() {
            var a = type.GetMembers(GetPublic.Instance);
            Assert.AreEqual(i | p, GetPublic.Instance);
            Assert.AreEqual(6, a.Length);
        }
        [TestMethod] public void StaticTest() {
            var a = type.GetMembers(GetPublic.Static);
            Assert.AreEqual(s | p, GetPublic.Static);
            Assert.AreEqual(1, a.Length);
        }
        [TestMethod] public void DeclaredTest() {
            var a = type.GetMembers(GetPublic.Declared);
            Assert.AreEqual(d | i | s | p, GetPublic.Declared);
            Assert.AreEqual(3, a.Length);
        }
    }
}
