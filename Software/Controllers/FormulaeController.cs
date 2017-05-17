using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Software.ViewModel;

namespace Software.Controllers
{
    public class FormulaeController : Controller
    {
        
        public ActionResult Index()
        {
            var q = new FormulaeViewModel();
            return View("Index", q);
        }

        public ActionResult Result(FormulaeViewModel formulae) {
            DerivedMeasure derivedMeasure;
            var m1 = new BaseMeasure(formulae.MeasureList[0]);
            var m2 = new BaseMeasure(formulae.MeasureList[1]);
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);

            if (formulae.SelectedOperation == "Divide")
                derivedMeasure = m1.Divide(m2) as DerivedMeasure;
            else 
                derivedMeasure = m1.Multiply(m2) as DerivedMeasure;
            Measures.Instance.Add(derivedMeasure);
            int i = 0;
            List<DerivedUnit> derivedUnits = new List<DerivedUnit>();
            foreach (string str in formulae.UnitList1)
            {
                var baseUnit = new BaseUnit(m1, Unit.SetFactor(str), str, str);
                Units.Instance.Add(baseUnit);
                var derivedUnit = baseUnit.Exponentiation(formulae.PowerList1[i]) as DerivedUnit;
                derivedUnit.Measure = derivedMeasure;
                Units.Instance.Add(derivedUnit);
                derivedUnits.Add(derivedUnit);
                i++;
                if (i == formulae.NumberOfUnits1) {                    
                    i = 0;
                    break;
                }
            }
            foreach (string str in formulae.UnitList2)
            {
                var baseUnit = new BaseUnit(m2, Unit.SetFactor(str), str, str);
                Units.Instance.Add(baseUnit);
                DerivedUnit derivedUnit;
                if (formulae.SelectedOperation == "Divide")
                    derivedUnit = baseUnit.Exponentiation(-formulae.PowerList2[i]) as DerivedUnit;
                else
                    derivedUnit = baseUnit.Exponentiation(formulae.PowerList2[i]) as DerivedUnit;
                derivedUnit.Measure = derivedMeasure;
                Units.Instance.Add(derivedUnit);
                derivedUnits.Add(derivedUnit);
                i++;
                if (i == formulae.NumberOfUnits2)                    
                    break;                
            }
            for (int j = 0; j < formulae.NumberOfUnits1 + formulae.NumberOfUnits2 - 1; j++)
            {
                var a = derivedUnits[j].Multiply(derivedUnits[j + 1]) as DerivedUnit;
                Units.Instance.Add(a);
                derivedUnits[j + 1] = a;
                if (a.Name == null) a.Name = "1";
                if (j == formulae.NumberOfUnits1 + formulae.NumberOfUnits2 - 2)
                    formulae.Result ="Unit: " + a.Name +" Measure: " + derivedMeasure.Name??derivedMeasure.Terms[0].MeasureId;
            }
            return View("Index", formulae);
        }
    }
}