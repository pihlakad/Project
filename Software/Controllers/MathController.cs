using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using Software.ViewModel;

namespace Software.Controllers
{
    public class MathController : Controller {                
        public ActionResult Index()
        {                    
            var q = new MathViewModel();                
            return View("Index", q);
        }

        [HttpPost]
        public ActionResult Result(MathViewModel quantity) {
            var m = BaseMeasure.Random();
            Measures.Instance.Add(m);
            var u1 = new BaseUnit(m, Unit.SetFactor(quantity.QuantityList[0].Unit), quantity.QuantityList[0].Unit, quantity.QuantityList[0].Unit);            
            Units.Instance.Add(u1);            
            var q1 = new Quantity(quantity.QuantityList[0].Amount, u1);
            Quantity q2 = new Quantity();
            if (quantity.QuantityList[1].Unit != string.Empty) {
                var u2 = new BaseUnit(m, Unit.SetFactor(quantity.QuantityList[1].Unit), quantity.QuantityList[1].Unit, quantity.QuantityList[1].Unit);
                Units.Instance.Add(u2);
                q2 = new Quantity(quantity.QuantityList[1].Amount, u2);
            }            
            quantity = SetResult(quantity, q1, q2);
            return View("Index", quantity);
        }

        private MathViewModel SetResult(MathViewModel quantity, Quantity q1, Quantity q2) {
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