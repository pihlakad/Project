using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Logic.BaseClasses;
using Microsoft.Win32;

namespace Logic
{
    public class MeasureTerm: Archetype {
        private int power;
        private string measureId;       
        public MeasureTerm() : this(null, 0)
        {
        }
        public MeasureTerm(BaseMeasure m, int power = 0) {
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
            if (Power == 0) return $"{n}";
            return $"{n}^{Power}";
        }
       
        public static MeasureTerm Random()
        {
            var t = new MeasureTerm();
            t.SetRandomValues();
            return t;
        }
       
        protected override void SetRandomValues()
        {
            base.SetRandomValues();
            power = GetRandom.Int8();
            measureId = GetRandom.String(2, 3);
        }
    }
}
