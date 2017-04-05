using System;
using System.Linq;
using System.Reflection;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class GetSolutionTests : ClassTests<GetProject> {
        private const string name = "Aids";
        [TestMethod] public void DomainTest() {
            var e = AppDomain.CurrentDomain;
            var a = GetProject.Domain;
            Assert.AreEqual(e, a);
        }
        [TestMethod] public void AssembliesTest() {
            var e = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var a = GetProject.Assemblies;
            Assert.AreEqual(e.Count, a.Count);
            foreach (var x in e)
                Assert.IsNotNull(a.Find(o => o.FullName == x.FullName));
        }
        [TestMethod] public void AssemblyTest() {
            var a = GetProject.Assembly(name);
            var e = Assembly.Load(name);
            Assert.AreEqual(e, a);
            Assert.IsNull(GetProject.Assembly(null));
            Assert.IsNull(GetProject.Assembly(string.Empty));
        }
        [TestMethod] public void ClassesTest() {
            var a = GetProject.Classes(name);
            var e = Assembly.Load(name).GetTypes().ToList();
            Assert.AreEqual(e.Count, a.Count);
            foreach (var x in a) { Assert.IsTrue(e.Contains(x)); }
        }
        [TestMethod] public void ClassesNamesTest() {
            var a = GetProject.ClassesNames(name);
            var e =
                Assembly.Load(name).GetTypes().Select(t => t.FullName).ToList();
            Assert.AreEqual(e.Count, a.Count);
            foreach (var x in a) { Assert.IsTrue(e.Contains(x)); }
        }
        [TestMethod] public void NameTest() {
            Assert.AreEqual("Aids", GetProject.Name);
        }
    }
}
