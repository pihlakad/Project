namespace Archetypes.SystemOfUnits.SI.Units {
    public class Meter : IUnit {
        private const string Name = "meter";
        private const string Symbol = "m";

        public string GetName() {
            return Name;
        }

        public string GetSymbol() {
            return Symbol;
        }
    }
}
