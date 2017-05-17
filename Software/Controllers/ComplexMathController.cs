using System.Collections.Generic;
using System.EnterpriseServices;
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
            var baseMeasure = BaseMeasure.Random();
            Measures.Instance.Add(baseMeasure);
            var derivedMeasure = DerivedMeasure.Random();
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
                if(i==quantity.NumberOfUnits) break;
            }            
            for (int j = 0; j < quantity.NumberOfUnits - 1; j++)
            {
                var a = derivedUnits[j].Multiply(derivedUnits[j + 1]) as DerivedUnit;
                Units.Instance.Add(a);
                derivedUnits[j + 1] = a;
                if (j == quantity.NumberOfUnits - 2) {
                    q1.Unit = a.Name;
                    q2.Unit = a.Name;
                }                                   
            }
            quantity = SetResults(quantity, q1, q2);                                           
            return View("Index", quantity);
        }

        private ComplexMathViewModel SetResults(ComplexMathViewModel quantity, Quantity q1, Quantity q2) {
            if (quantity.SelectedOperation == "Add")
                quantity.ResultQuantity = q1.Add(q2);
            else if (quantity.SelectedOperation == "Subtract")
                quantity.ResultQuantity = q1.Subtract(q2);
            else if (quantity.SelectedOperation == "Multiply")
                quantity.ResultQuantity = q1.Multiply(q2);
            else if (quantity.SelectedOperation == "Divide")
                quantity.ResultQuantity = q1.Divide(q2);
            else if (quantity.SelectedOperation == "Compare")
                quantity.Result = SetComparingResult(q1, q2);
            else if (quantity.SelectedOperation == "Round")
                quantity.ResultQuantity = q1.Round(new Rounding());
            if (quantity.Result == null)
                quantity.Result = quantity.ResultQuantity.Amount.ToString();
            return quantity;
        }

        private string SetComparingResult(Quantity q1, Quantity q2) {
            var b = q1.IsGreaterThan(q2);
            if (b) return "Second Amount is Greater";
            return "First Amount is Greater";
        }
    }
}