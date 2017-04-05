using System.Collections;
using Aids;
using Logic.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public abstract class CommonTests<T> : ClassTests<T> where T : Common, new() {
        protected T Obj { get; set; }
        private object obj;
        private ValueChangedEventArgs args;
        protected abstract T getRandomObj();
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            Obj = getRandomObj();
            clearDoOnChanged();
        }
        [TestCleanup] public override void TestCleanup() {
            base.TestCleanup();
            Obj = default(T);
            clearDoOnChanged();
        }
        [TestMethod] public void FromJsonTest() {
            toFromJsonTest(new T());
            toFromJsonTest(getRandomObj());
        }
        [TestMethod] public virtual void IsEqualTest() {
            var a = getRandomObj();
            var b = a;
            Assert.IsTrue(a.IsEqual(b));
        }
        [TestMethod] public void IsSameContentTest() {
            var a = getRandomObj();
            var s = a.ToString();
            var b = Json.From<T>(s);
            Assert.IsTrue(a.IsSameContent(b));
        }
        [TestMethod] public void ToJsonTest() { FromJsonTest(); }
        [TestMethod] public void ParseTest() {
            var a = getRandomObj();
            var s = a.ToString();
            var b = Common.Parse<T>(s);
            Assert.IsTrue(a.IsSameContent(b));
        }
        [TestMethod] public void TryParseTest() {
            var a = getRandomObj();
            var s = a.ToString();
            T b;
            Assert.IsTrue(Common.TryParse(s, out b));
            Assert.IsTrue(a.IsSameContent(b));
        }
        [TestMethod] public virtual void RandomTest() {
            var x = getRandomObj();
            var y = getRandomObj();
            while (ToJson(x) == ToJson(y)) 
                y = getRandomObj();
            Assert.IsNotNull(x);
            Assert.AreEqual(x.GetType(), typeof(T));
            Assert.AreNotEqual((object) ToJson(x), ToJson(y));
        }
        [TestMethod] public void ToStringTest() {
            toStringTest(new T());
            toStringTest(getRandomObj());
        }
        [TestMethod] public virtual void XmlSerializationTest() {
            toFromXmlTest(new T());
            toFromXmlTest(getRandomObj());
        }
        private static void toStringTest(T o) {
            var expected = ToJson(o);
            var actual = o.ToString();
            Assert.AreEqual((object) expected, actual);
        }
        private static void toFromXmlTest(T o) {
            var expected = ToXml(o);
            var x = FromXml<T>(expected);
            var actual = ToXml(x);
            Assert.AreEqual((object) expected, actual);
            Assert.IsFalse(string.IsNullOrEmpty(expected));
            if (!(o is IEnumerable))
                isPublicPropertiesSerialized(x, expected);
        }
        private static void toFromJsonTest(T o) {
            var expected = ToJson(o);
            var x = FromJson<T>(expected);
            var actual = ToJson(x);
            Assert.AreEqual((object) expected, actual);
            Assert.IsFalse(string.IsNullOrEmpty(expected));
            if (!(o is IEnumerable))
                isPublicPropertiesSerialized(x, expected);
        }
        protected void clearDoOnChanged() {
            obj = null;
            args = null;
        }
        protected void doOnChanged(object sender, ValueChangedEventArgs e) {
            obj = sender;
            args = e;
        }
        protected void testDoOnChange(string method, object newValue, object oldValue, int index) {
            Assert.AreEqual(Obj, obj);
            Assert.IsTrue(args.MethodName.Contains(method));
            Assert.AreEqual(newValue, args.NewValue);
            Assert.AreEqual(oldValue, args.OldValue);
            Assert.AreEqual(index, args.Index);
        }
        protected void testDoOnChange() {
            Assert.IsNull(obj);
            Assert.IsNull(args);
        }
        private static void isPublicPropertiesSerialized(object o, string s) {
            Assert.IsNotNull(o);
            Assert.IsNotNull(s);
            var properties = GetClass.Properties(o.GetType());
            foreach (var p in properties) {
                if (!p.CanRead) continue;
                if (!p.CanWrite) continue;
                if (p.GetGetMethod(false) == null) { continue; }
                if (p.GetSetMethod(false) == null) { continue; }
                var n = p.Name;
                Assert.IsTrue(s.Contains(n), n);
            }
        }
    }
}
