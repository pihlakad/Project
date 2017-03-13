using System;
using System.Collections.Generic;
using System.Threading;

namespace Logic {
    public sealed class UnitType {
        private static ReaderWriterLock baseUnitTypeLock = new ReaderWriterLock();
        private static IList<string> baseUnitTypeNames = new List<string>();
        private sbyte[] baseUnitIndices;
        private static UnitType none = new UnitType(0);

        public UnitType(string unitTypeName) {
            int unitIndex = GetBaseUnitIndex(unitTypeName);
            this.baseUnitIndices = new sbyte[unitIndex + 1];
            this.baseUnitIndices[unitIndex] = 1;
        }

        private UnitType(int indicesLength) {
            this.baseUnitIndices = new sbyte[indicesLength];
        }

        private UnitType(sbyte[] baseUnitIndices) {
            this.baseUnitIndices = (sbyte[])baseUnitIndices.Clone();
        }

        public static UnitType None {
            get { return UnitType.none; }
        }

        private static int GetBaseUnitIndex(string unitTypeName) {
            // Lock baseUnitTypeNames:
            baseUnitTypeLock.AcquireReaderLock(2000);

            try {
                // Retrieve index of unitTypeName:
                int index = baseUnitTypeNames.IndexOf(unitTypeName);

                // If not found, register unitTypeName:
                if (index == -1) {
                    baseUnitTypeLock.UpgradeToWriterLock(2000);
                    index = baseUnitTypeNames.Count;
                    baseUnitTypeNames.Add(unitTypeName);
                }

                // Return index:
                return index;
            } finally {
                // Release lock:
                baseUnitTypeLock.ReleaseLock();
            }
        }

        public static UnitType operator *(UnitType left, UnitType right) {
            var result = new UnitType(Math.Max(left.baseUnitIndices.Length, right.baseUnitIndices.Length));

            left.baseUnitIndices.CopyTo(result.baseUnitIndices, 0);

            for (var i = 0; i < right.baseUnitIndices.Length; i++) {
                result.baseUnitIndices[i] += right.baseUnitIndices[i];
            }

            return result;
        }

        public static UnitType operator /(UnitType left, UnitType right) {
            var result = new UnitType(Math.Max(left.baseUnitIndices.Length, right.baseUnitIndices.Length));

            left.baseUnitIndices.CopyTo(result.baseUnitIndices, 0);

            for (var i = 0; i < right.baseUnitIndices.Length; i++) {
                result.baseUnitIndices[i] -= right.baseUnitIndices[i];
            }

            return result;
        }

        public UnitType Power(int power) {
            var result = new UnitType(baseUnitIndices);

            for (var i = 0; i < result.baseUnitIndices.Length; i++) {
                result.baseUnitIndices[i] = (sbyte) (result.baseUnitIndices[i] * power);
            }

            return result;
        }
    }
}