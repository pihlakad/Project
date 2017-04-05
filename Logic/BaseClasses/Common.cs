namespace Logic.BaseClasses {
    public class Common : Serializable {
        public static T Clone<T>(T obj) where T : Serializable, new() {
            var s = ToJson(obj);
            return FromJson<T>(s);
        }
        public bool IsSameContent(object x) { return IsSameContent(this, x); }
        public static bool IsSameContent(object x, object y) {
            if (IsNull(x) && IsNull(y)) return false;
            var sy = y.ToString();
            var sx = x.ToString();
            if (!IsNull(y) && string.IsNullOrEmpty(sy)) return false;
            var r = sy.Equals(sx);
            return r;
        }
        public override string ToString() { return ToJson(this); }
        public static T Parse<T>(string s) where T : Serializable, new() { return FromJson<T>(s); }
        public static bool TryParse<T>(string s, out T obj) where T : Serializable, new() {
            obj = FromJson<T>(s);
            return obj.ToString() == s;
        }
    }
}
