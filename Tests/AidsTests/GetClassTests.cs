using System;
using System.Collections.Generic;
using System.Reflection;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class GetClassTests : ClassTests<GetClass> {
        internal class classTest : testClass {
            public int e = 0;
            public string F { get; set; }
        }
        [TestMethod] public void NamespaceTest() {
            var t = typeof(object);
            Assert.AreEqual(t.Namespace, GetClass.Namespace(t));
            Assert.AreEqual(string.Empty, GetClass.Namespace(null));
        }
        [TestMethod] public void MembersTest() {
            testMember(typeof(classTest));
            testNull(null);
        }
        private static void testNull(Type t) {
            var a = GetClass.Members(t);
            Assert.IsInstanceOfType(a, typeof(List<MemberInfo>));
            Assert.AreEqual(0, a.Count);
        }
        private static void testMember(Type t) {
            var a = GetClass.Members(t, GetPublic.All, false);
            var e = t.GetMembers(GetPublic.All);
            Assert.AreEqual(e.Length, a.Count);
            Assert.AreEqual(10, a.Count);
            foreach (var v in e) Assert.IsTrue(a.Contains(v));
            Assert.AreEqual(7, GetClass.Members(t).Count);
        }
        [TestMethod] public void PropertiesTest() {
            var a = GetClass.Properties(typeof(classTest));
            Assert.IsNotNull(a);
            Assert.IsInstanceOfType(a, typeof(List<PropertyInfo>));
            Assert.AreEqual(1, a.Count);
            Assert.AreEqual("F", a[0].Name);
        }
    }
}
