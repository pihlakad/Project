using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software.ViewModel;

namespace Software.Controllers
{
    public class MathController : Controller {                
        public ActionResult Index()
        {                    
            var q = new QuantityViewModel();                
            return View("Math", q);
        }

        [HttpPost]
        public ActionResult Result(QuantityViewModel quantity) {
            var m = new BaseMeasure(quantity.Measure);
            Measures.Instance.Add(m);
            var u1 = new BaseUnit(m, Unit.SetFactor(quantity.QuantityList[0].Unit), quantity.QuantityList[0].Unit, quantity.QuantityList[0].Unit);
            var u2 = new BaseUnit(m, Unit.SetFactor(quantity.QuantityList[1].Unit), quantity.QuantityList[1].Unit, quantity.QuantityList[1].Unit);
            Units.Instance.Add(u1);
            Units.Instance.Add(u2);
            var q1 = new Quantity(quantity.QuantityList[0].Amount, u1);
            var q2 = new Quantity(quantity.QuantityList[1].Amount, u2);
            if (quantity.SelectedOperation == "Add")
                quantity.ResultQuantity = q1.Add(q2);
            else if (quantity.SelectedOperation == "Subtract")
                quantity.ResultQuantity = q1.Subtract(q2);
            else if (quantity.SelectedOperation == "Multiply")
                quantity.ResultQuantity = q1.Multiply(q2);
            else quantity.ResultQuantity = q1.Divide(q2);
            quantity.ResultAmount = quantity.ResultQuantity.Amount.ToString();
            return View("Math", quantity);
        }
        //TODO Tuleks lisada uus kalkulaatori view ja controller, mis suudaksid teha tehteid derived unititega. Kasutajale võiks anda võimaluse valida mitu liiget
        //ta soobib ja tema ül oleks ainult kirjutada powerid koos märgia.
    }
}