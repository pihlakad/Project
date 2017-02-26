namespace Archetypes.SystemOfUnits.SI.Units {
    public class Kilogram : IUnit {
        private const string Name = "kilogram";
        private const string Symbol = "kg";

        public string GetName() {
            return Name;
        }

        public string GetSymbol() {
            return Symbol;
        }
    }
}
