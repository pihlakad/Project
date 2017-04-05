using System.Linq;

namespace Aids {
    public class IsNamespace {
        public static bool Running(string name) {
            if (string.IsNullOrEmpty(name)) return false;
            return
                Safe.Run(
                    () =>
                        GetProject.Assemblies.Any(
                            a => a.FullName.StartsWith(name)), false);
        }
    }
}
