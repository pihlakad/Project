namespace Archetypes.SystemOfUnits.SI.Units {
    public class Second : IUnit {
        private const string Name = "second";
        private const string Symbol = "s";

        public string GetName() {
            return Name;
        }

        public string GetSymbol() {
            return Symbol;
        }
    }
}
