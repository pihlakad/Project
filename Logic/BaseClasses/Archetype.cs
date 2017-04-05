using System;
using System.Diagnostics;
using Aids;

namespace Logic.BaseClasses
{
    public class Archetype : Common
    {
        protected bool isChanged;
        protected internal bool isReadOnly;
        public event EventHandler<ValueChangedEventArgs> OnChanged;
        
        protected virtual void SetRandomValues() { }

        public static string CallingMethod(){
            return Safe.Run(() => {
                var stack = new StackTrace();
                var frames = stack.GetFrames();
                int i;
                for (i = 0; i < stack.FrameCount; i++)
                {
                    var f = frames[i];
                    var m = f.GetMethod();
                    var n = m.Name;
                    if (n == "CallingMethod") break;
                }
                return frames[i + 2].GetMethod().Name;
            }, string.Empty);
        }
        public T SetDefault<T>(ref T variable, T value)
        {
            if (IsNull(variable)) SetValue(ref variable, value);
            return variable;
        }
        public void SetValue<T>(ref T variable, T value)
        {
            if (isReadOnly) return;
            if (IsNull(value)) return;
            if (value.Equals(variable)) return;
            var old = variable;
            variable = value;
            if (old == null) return;
            if (old.Equals(default(T))) return;
            doOnChanged(old, value);
        }
        protected void doOnChanged<T>(T oldValue, T newValue)
        {
            var e = new ValueChangedEventArgs
            {
                MethodName = CallingMethod(),
                OldValue = oldValue,
                NewValue = newValue
            };
            doOnChanged(e);
        }
        private void doOnChanged(ValueChangedEventArgs args)
        {
            isChanged = true;
            OnChanged?.Invoke(this, args);
        }
    }
}
