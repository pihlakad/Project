namespace Archetypes.Metric {
    public class MetricSingleton {
        private static Metric _instance;

        private MetricSingleton() { }

        public static Metric Instance {
            get {
                if (_instance == null) {
                    _instance = new Metric();
                }

                return _instance;
            }
        }
    }
}
