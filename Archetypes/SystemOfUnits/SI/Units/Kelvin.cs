namespace Archetypes.SystemOfUnits.SI.Units {
    public class Kelvin : IUnit {
        private const string Name = "kelvin";
        private const string Symbol = "K";

        public string GetName() {
            return Name;
        }

        public string GetSymbol() {
            return Symbol;
        }
    }
}
