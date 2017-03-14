using System;
using System.Collections.Generic;
using System.Threading;

namespace Logic {
    public sealed class UnitType {
        private static ReaderWriterLock _baseUnitTypeLock = new ReaderWriterLock();
        private static IList<string> _baseUnitTypeNames = new List<string>();
        private readonly sbyte[] _baseUnitIndices;
        private static UnitType _none = new UnitType(0);

        public UnitType(string unitTypeName) {
            var unitIndex = GetBaseUnitIndex(unitTypeName);

            _baseUnitIndices = new sbyte[unitIndex + 1];
            _baseUnitIndices[unitIndex] = 1;
        }

        private UnitType(int indicesLength) {
            _baseUnitIndices = new sbyte[indicesLength];
        }

        private UnitType(sbyte[] baseUnitIndices) {
            _baseUnitIndices = (sbyte[])baseUnitIndices.Clone();
        }

        public static UnitType None => _none;

        private static int GetBaseUnitIndex(string unitTypeName) {
            // Lock baseUnitTypeNames:
            _baseUnitTypeLock.AcquireReaderLock(2000);

            try {
                // Retrieve index of unitTypeName:
                var index = _baseUnitTypeNames.IndexOf(unitTypeName);

                // If not found, register unitTypeName:
                if (index == -1) {
                    _baseUnitTypeLock.UpgradeToWriterLock(2000);
                    index = _baseUnitTypeNames.Count;
                    _baseUnitTypeNames.Add(unitTypeName);
                }

                // Return index:
                return index;
            } finally {
                // Release lock:
                _baseUnitTypeLock.ReleaseLock();
            }
        }

        public static UnitType operator *(UnitType left, UnitType right) {
            var result = new UnitType(Math.Max(left._baseUnitIndices.Length, right._baseUnitIndices.Length));

            left._baseUnitIndices.CopyTo(result._baseUnitIndices, 0);

            for (var i = 0; i < right._baseUnitIndices.Length; i++) {
                result._baseUnitIndices[i] += right._baseUnitIndices[i];
            }

            return result;
        }

        public static UnitType operator /(UnitType left, UnitType right) {
            var result = new UnitType(Math.Max(left._baseUnitIndices.Length, right._baseUnitIndices.Length));

            left._baseUnitIndices.CopyTo(result._baseUnitIndices, 0);

            for (var i = 0; i < right._baseUnitIndices.Length; i++) {
                result._baseUnitIndices[i] -= right._baseUnitIndices[i];
            }

            return result;
        }

        public UnitType Power(int power) {
            var result = new UnitType(_baseUnitIndices);

            for (var i = 0; i < result._baseUnitIndices.Length; i++) {
                result._baseUnitIndices[i] = (sbyte) (result._baseUnitIndices[i] * power);
            }

            return result;
        }
    }
}