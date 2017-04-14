using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.BaseClasses;

namespace Logic
{
    public class MeasureTerms: Archetypes<MeasureTerm>
    {
        public string Formula(bool isLong = false) {
            var s = string.Empty;
            foreach (var e in this) {
                var f = e.Formula(isLong);
                if (string.IsNullOrEmpty(s)) s = f;
                else s = $"{s}*{f}";
            }
            return s;
        }

    }
}
