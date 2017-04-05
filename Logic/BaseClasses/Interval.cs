﻿using System;

namespace Logic.BaseClasses {
    public class Interval<T> : Archetype where T : IComparable {
        protected T fromField;
        protected T toField;
        public virtual T From {
            get { return SetDefault(ref fromField, default(T)); }
            set {
                if (isChanged && value.CompareTo(toField) > 0) return;
                SetValue(ref fromField, value);
            }
        }
        public virtual T To {
            get { return SetDefault(ref toField, default(T)); }
            set {
                if (isChanged && value.CompareTo(fromField) < 0) return;
                SetValue(ref toField, value);
            }
        }
        public bool IsInside(T value) {
            if (value.CompareTo(toField) >= 0) return false;
            return value.CompareTo(fromField) > 0;
        }
        public bool IsOutside(T value) {
            if (value.CompareTo(fromField) < 0) return true;
            return value.CompareTo(toField) > 0;
        }
    }
}
