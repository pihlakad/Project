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
        //TODO 6b: Igal klassil peab olema ka ilma parameetriteta meetod
        // muidu ei tööta korralikult JSON ja XML serialiseerimised
        //public MeasureTerm(): this(null, 0) {
        //}
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
            //TODO 6a siin tuli vahetada ! märk ära ^ märgiks
            //return $"{n}^{Power}";
            return $"{n}!{Power}";
        }
        //TODO 4: Igal klassil on hea, kui on Random meetod
        //public static MeasureTerm Random() {
        //    var t = new MeasureTerm();
        //    t.SetRandomValues();
        //    return t;
        //}
        //TODO 5: kui on privaatseid muutujaid, siis need tuleb väärtustada
        // SetRandomValues meetodis
        //protected override void SetRandomValues() {
        //    base.SetRandomValues();
        //    power = GetRandom.Int8();
        //    measureId = GetRandom.String(2, 3);
        //}
    }
}
