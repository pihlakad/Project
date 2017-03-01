namespace Archetypes.SystemOfUnits.SI.Units {
    public class Kelvin : IUnit {
        private const string Name = "kelvin";
        private const string Symbol = "K";
        private const UnitTypes Type = UnitTypes.Temperature;

        public string GetName() {
            return Name;
        }

        public string GetSymbol() {
            return Symbol;
        }

        public new UnitTypes GetType() {
            return Type;
        }
    }
}
