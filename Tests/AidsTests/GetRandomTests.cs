using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.AidsTests {
    [TestClass] public class GetRandomTests : ClassTests<GetRandom> {
        [TestMethod] public void BoolTest() {
            isNotEqualTest(GetRandom.Bool);
        }
        [TestMethod] public void CharTest() {
            var x = GetRandom.Char(GetRandom.Char());
            var y = GetRandom.Char(max: x);
            isNotEqualTest(() => GetRandom.Char());
            isEqualTest(() => GetRandom.Char(x, x));
            isEqualTest(x, () => GetRandom.Char(x, y));
        }
        [TestMethod] public void CountTest() {
            var x = GetRandom.Count(GetRandom.Count());
            var y = GetRandom.Count(max: x);
            isNotEqualTest(() => GetRandom.Count());
            isEqualTest(() => GetRandom.Count(x, x));
            isEqualTest(x, () => GetRandom.Count(x, y));
        }
        [TestMethod] public void DateTimeTest() {
            var x = GetRandom.DateTime(GetRandom.DateTime());
            var y = GetRandom.DateTime(max: x);
            isNotEqualTest(() => GetRandom.DateTime());
            isEqualTest(() => GetRandom.DateTime(x, x));
            isEqualTest(x, () => GetRandom.DateTime(x, y));
        }
        [TestMethod] public void DecimalTest() {
            var x = GetRandom.Decimal(GetRandom.Decimal());
            var y = GetRandom.Decimal(max: x);
            isNotEqualTest(() => GetRandom.Decimal());
            isEqualTest(() => GetRandom.Decimal(x, x));
            isEqualTest(x, () => GetRandom.Decimal(x, y));
        }
        [TestMethod] public void DoubleTest() {
            var x = GetRandom.Double(GetRandom.Double());
            var y = GetRandom.Double(max: x);
            isNotEqualTest(() => GetRandom.Double());
            isEqualTest(() => GetRandom.Double(x, x));
            isEqualTest(x, () => GetRandom.Double(x, y));
        }
        [TestMethod] public void EnumTest() {
            isNotEqualTest(GetRandom.Enum<IsoGender>);
        }
        [TestMethod] public void FloatTest() {
            var x = GetRandom.Float(GetRandom.Float());
            var y = GetRandom.Float(max: x);
            isNotEqualTest(() => GetRandom.Float());
            isEqualTest(() => GetRandom.Float(x, x));
            isEqualTest(x, () => GetRandom.Float(x, y));
        }
        [TestMethod] public void Int8Test() {
            var x = GetRandom.Int8(GetRandom.Int8());
            var y = GetRandom.Int8(max:x);
            isNotEqualTest(() => GetRandom.Int8());
            isEqualTest(() => GetRandom.Int8(x, x));
            isEqualTest(x, () => GetRandom.Int8(x, y));
        }
        [TestMethod] public void Int16Test() {
            var x = GetRandom.Int16(GetRandom.Int16());
            var y = GetRandom.Int16(max: x);
            isNotEqualTest(() => GetRandom.Int16());
            isEqualTest(() => GetRandom.Int16(x, x));
            isEqualTest(x, () => GetRandom.Int16(x, y));
        }
        [TestMethod] public void Int32Test() {
            var x = GetRandom.Int32(GetRandom.Int32());
            var y = GetRandom.Int32(max: x);
            isNotEqualTest(() => GetRandom.Int32());
            isEqualTest(() => GetRandom.Int32(x, x));
            isEqualTest(x, () => GetRandom.Int32(x, y));
        }
        [TestMethod] public void Int64Test() {
            var x = GetRandom.Int64(GetRandom.Int64());
            var y = GetRandom.Int64(max: x);
            isNotEqualTest(() => GetRandom.Int64());
            isEqualTest(() => GetRandom.Int64(x, x));
            isEqualTest(x, () => GetRandom.Int64(x, y));
        }
        [TestMethod] public void StringTest() {
            isNotEqualTest(()=>GetRandom.String());
        }
        [TestMethod] public void StringsTest() {
            isNotEqualTest(GetRandom.Strings);
        }
        [TestMethod] public void UInt8Test() {
            var x = GetRandom.UInt8(GetRandom.UInt8());
            var y = GetRandom.UInt8(max: x);
            isNotEqualTest(() => GetRandom.UInt8());
            isEqualTest(() => GetRandom.UInt8(x, x));
            isEqualTest(x, () => GetRandom.UInt8(x, y));
        }
        [TestMethod] public void UInt16Test() {
            var x = GetRandom.UInt16(GetRandom.UInt16());
            var y = GetRandom.UInt16(max: x);
            isNotEqualTest(() => GetRandom.UInt16());
            isEqualTest(() => GetRandom.UInt16(x, x));
            isEqualTest(x, () => GetRandom.UInt16(x, y));
        }
        [TestMethod] public void UInt32Test() {
            var x = GetRandom.UInt32(GetRandom.UInt32());
            var y = GetRandom.UInt32(max: x);
            isNotEqualTest(() => GetRandom.UInt32());
            isEqualTest(() => GetRandom.UInt32(x, x));
            isEqualTest(x, () => GetRandom.UInt32(x, y));
        }
        [TestMethod] public void UInt64Test() {
            var x = GetRandom.UInt64(GetRandom.UInt64());
            var y = GetRandom.UInt64(max: x);
            isNotEqualTest(() => GetRandom.UInt64());
            isEqualTest(() => GetRandom.UInt64(x, x));
            isEqualTest(x, () => GetRandom.UInt64(x, y));
        }
    }
}
