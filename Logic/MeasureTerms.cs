﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
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

        //TODO 10: MeasureTerms Add on vaja ümber kirjutada, kui tahame, et 
        // BaseMeasure test MultiplySameMeasureTest töötaks 
        //public override void Add(MeasureTerm item) {
        //    var t = Find(x => x.MeasureId == item.MeasureId);
        //    if (IsNull(t)) base.Add(item);
        //    else t.Power = t.Power + item.Power;
        //}

        //TODO 11: igal klassil võiks olla Random meetod. Kui vabastate kommentaridest 
        // all oleva koodi, tuleb vabastada ka Random meetod klassis MeasureTerm
        //public static MeasureTerms Random() {
        //    var t = new MeasureTerms();
        //    for (var i = 0; i < GetRandom.Count(); i++) {
        //        t.Add(MeasureTerm.Random());
        //    }
        //    return t;
        //}
    }
}
