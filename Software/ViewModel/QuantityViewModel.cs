using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace Software.ViewModel
{
    public class QuantityViewModel {
        private List<Quantity> quantityList;
        private Quantity resultQuantity = Quantity.Empty;
        private string measure;
        private string selectedOperation;

        public List<Quantity> QuantityList {
            get { return quantityList; }
            set { quantityList = value; }
        }

        public Quantity ResultQuantity {
            get { return resultQuantity; }
            set { resultQuantity = value; }
        }

        public string Measure
        {
            get { return measure; }
            set { measure = value; }
        }

        public string SelectedOperation {
            get { return selectedOperation; }
            set { selectedOperation = value; }
        }       
        public string ResultAmount { get; set; }
    }
}