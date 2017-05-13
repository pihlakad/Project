using System.Collections.Generic;
using System.Web.Mvc;
using Logic;
using Software.ViewModel;

namespace Software.Controllers
{
    public class ComplexMathController : Controller
    {
        public ActionResult Index()
        {
            var q = new ComplexMathViewModel();
            return View("Index", q);
        }

        [HttpPost]
        public ActionResult Result(ComplexMathViewModel quantity) {
            var q1 = quantity.FirstQuantity;
            var q2 = quantity.SecondQuantity;
            var baseMeasure = new BaseMeasure(quantity.Measure);
            Measures.Instance.Add(baseMeasure);
            var derivedMeasure = baseMeasure.Multiply(baseMeasure);
            Measures.Instance.Add(derivedMeasure);    
            int i = 0;
            List<DerivedUnit> derivedUnits = new List<DerivedUnit>();
            foreach (string str in quantity.UnitList) {
                var baseUnit = new BaseUnit(baseMeasure, Unit.SetFactor(str), str, str);
                Units.Instance.Add(baseUnit);
                var derivedUnit = baseUnit.Exponentiation(quantity.PowerList[i]) as DerivedUnit;
                derivedUnit.Measure = derivedMeasure;
                Units.Instance.Add(derivedUnit);
                derivedUnits.Add(derivedUnit);
                i++;
            }

            //ConcatSameUnits(derivedUnits);

            for (int j = 0; j < 3; j++)
            {
                var a = derivedUnits[j].Multiply(derivedUnits[j + 1]) as DerivedUnit;
                Units.Instance.Add(a);
                derivedUnits[j + 1] = a;
                if (j == 2)
                    q1.Unit = a.Name;
            }
            for (int j = 4; j < 7; j++)
            {
                var a = derivedUnits[j].Multiply(derivedUnits[j + 1]) as DerivedUnit;
                Units.Instance.Add(a);
                derivedUnits[j + 1] = a;
                if (j == 6)
                    q2.Unit = a.Name;
            }
            //q1.Unit = derivedUnits[0].Name;
            //q2.Unit = derivedUnits[1].Name;

            if (quantity.SelectedOperation == "Add")
                quantity.ResultQuantity = q1.Add(q2);
            else if (quantity.SelectedOperation == "Subtract")
                quantity.ResultQuantity = q1.Subtract(q2);
            else if (quantity.SelectedOperation == "Multiply")
                quantity.ResultQuantity = q1.Multiply(q2);
            else quantity.ResultQuantity = q1.Divide(q2);            

            return View("Index", quantity);
        }

        //private void ConcatSameUnits(List<DerivedUnit> DerivedUnits) {
        //    foreach (var derivedUnit in DerivedUnits) {
        //        var splitedName = derivedUnit.Name.Split('^');
        //        if(splitedName[0].Length == 1) 
        //    }

        //}
    }
}