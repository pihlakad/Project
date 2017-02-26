namespace Archetypes.Metric {
    public sealed class Metric: IMetric {
        private const string Name = Constants.Metric.Name;
        private const string Symbol = Constants.Metric.Symbol;

        public string GetName() {
            return Name;
        }

        public string GetSymbol() {
            return Symbol;
        }
    }
}
