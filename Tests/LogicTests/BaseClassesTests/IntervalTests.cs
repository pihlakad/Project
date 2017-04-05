﻿using Aids;
using Logic;
using Logic.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests.BaseClassesTests {
    [TestClass] public class IntervalTests : CommonTests<Interval<int>> {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            Obj.From = int.MinValue;
            Obj.To = int.MaxValue;
        }
        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(Obj.GetType().BaseType, typeof(Archetype));
        }
        [TestMethod] public void FromTest() {
            testProperty(() => Obj.From, x => Obj.From = x);
        }
        [TestMethod] public void ToTest() {
            testProperty(() => Obj.To, x => Obj.To = x);
        }
        [TestMethod] public void FromIsLessThanToTest() {
            Assert.AreEqual(int.MinValue, Obj.From);
            Assert.AreEqual(int.MaxValue, Obj.To);
            Obj.To = 0;
            Assert.AreEqual(int.MinValue, Obj.From);
            Assert.AreEqual(0, Obj.To);
            Obj.From = 1;
            Assert.AreEqual(int.MinValue, Obj.From);
            Assert.AreEqual(0, Obj.To);
        }
        [TestMethod] public void ToIsGreaterThanFromTest() {
            Assert.AreEqual(int.MinValue, Obj.From);
            Assert.AreEqual(int.MaxValue, Obj.To);
            Obj.From = 0;
            Assert.AreEqual(0, Obj.From);
            Assert.AreEqual(int.MaxValue, Obj.To);
            Obj.To = -1;
            Assert.AreEqual(0, Obj.From);
            Assert.AreEqual(int.MaxValue, Obj.To);
        }
        [TestMethod] public void FromAndToCanBeEqualTest() {
            Assert.AreEqual(int.MinValue, Obj.From);
            Assert.AreEqual(int.MaxValue, Obj.To);
            Obj.From = 0;
            Obj.To = 0;
            Assert.AreEqual(0, Obj.From);
            Assert.AreEqual(0, Obj.To);
        }
        [TestMethod] public void IsInsideTest() {
            Assert.IsTrue(Obj.IsInside(0));
            Assert.IsFalse(Obj.IsInside(int.MinValue));
            Assert.IsFalse(Obj.IsInside(int.MaxValue));
        }
        [TestMethod] public void IsOutsideTest() {
            Assert.IsFalse(Obj.IsOutside(0));
            Assert.IsFalse(Obj.IsOutside(int.MinValue));
            Assert.IsFalse(Obj.IsOutside(int.MaxValue));
            Obj.To = 0;
            Assert.IsFalse(Obj.IsOutside(0));
            Assert.IsTrue(Obj.IsOutside(1));
        }
        [TestMethod] public void IsFromAllowedTest() { }
        protected override Interval<int> getRandomObj() {
            var o = new Interval<int> {From = GetRandom.Int32()};
            o.To = GetRandom.Int32(o.From);
            return o;
        }
    }
}
