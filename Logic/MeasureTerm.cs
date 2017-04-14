using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.BaseClasses;
using Microsoft.Win32;

namespace Logic
{
    public class MeasureTerm: Archetype {
        private int power;
        private string measureId;
        public MeasureTerm(BaseMeasure m, int power) {
            m = m?? Measure.Empty as BaseMeasure;
            measureId = m.UniqueId;
            this.power = power;
        }
        public string MeasureId
        {
            get { return SetDefault(ref measureId); }
            set { SetValue(ref measureId, value); }
        }
        public int Power
        {
            get { return SetDefault(ref power); }
            set { SetValue(ref power, value); }
        }
        public Measure Measure {
            get { return Measures.Instance.Find(x => x.UniqueId == MeasureId)?? Measure.Empty; }
        }
        public string Formula(bool isLong = false) {
            var n = isLong ? Measure.Name : Measure.Symbol;
            return $"{n}!{Power}";
        }

    }
}
