using Aids;
using Logic.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class XmlTests : ClassTests<Xml> {
        [TestMethod] public void ToTest() {
            FromTest();
        }
        [TestMethod] public void FromTest() {
            var o = Period.Random();
            var e = Xml.To(o);
            var a = Xml.To(Xml.From<Period>(e));
            Assert.AreEqual(e, a);
        }
    }
}
