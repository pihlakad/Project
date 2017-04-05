using System;
using Aids;
using Logic.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.BaseClassesTests {
    [TestClass] public class PeriodTests : CommonTests<Period> {
        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(Obj.GetType().BaseType, typeof(Interval<DateTime>));
        }
        [TestMethod] public void EmptyTest() {
            Assert.AreEqual(Period.Empty, Period.Empty);
            Assert.AreNotEqual(new Period(), Period.Empty);
        }
        [TestMethod] public void FromTest() {
            testProperty(() => Obj.From, x => Obj.From = x);
        }
        [TestMethod] public void IsEmptyTest() {
            Assert.IsTrue(Period.Empty.IsEmpty());
            Assert.IsFalse(new Period().IsEmpty());
            Assert.IsFalse(Period.Random().IsEmpty());
        }
        [TestMethod] public void IsValidTest() {
            Obj = getRandomObj();
            Obj.To = GetRandom.DateTime(Obj.From);
            var d = GetRandom.DateTime(Obj.From, Obj.To);
            Assert.IsTrue(Obj.IsValid(d));
            Assert.IsTrue(Obj.IsValid(Obj.From));
            Assert.IsTrue(Obj.IsValid(Obj.To));
            Assert.IsFalse(Obj.IsValid(Obj.From.AddTicks(-1)));
            Assert.IsFalse(Obj.IsValid(Obj.To.AddTicks(1)));
        }
        [TestMethod] public void IsValidStaticTest() {
            Assert.IsTrue(Period.IsValid(DateTime.MinValue, DateTime.MaxValue));
            Assert.IsTrue(Period.IsValid(DateTime.Now, DateTime.Now.AddTicks(10)));
            Assert.IsFalse(Period.IsValid(DateTime.Now.AddTicks(-2), DateTime.Now.AddTicks(-1)));
        }
        [TestMethod] public void MinValueTest() {
            Assert.AreEqual(DateTime.MinValue.AddHours(12), Period.MinValue);
        }
        [TestMethod] public void MaxValueTest() {
            Assert.AreEqual(DateTime.MaxValue.AddHours(-12), Period.MaxValue);
        }
        [TestMethod] public void ToTest() {
            testProperty(() => Obj.To, x => Obj.To = x);
        }
        protected override Period getRandomObj() { return Period.Random(); }
    }
}
