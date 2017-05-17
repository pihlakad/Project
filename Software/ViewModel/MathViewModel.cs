using System.Collections.Generic;
using Logic;

namespace Software.ViewModel
{
    public class MathViewModel {
        private List<Quantity> quantityList;
        private Quantity resultQuantity = Quantity.Empty;        
        private string selectedOperation;

        public List<Quantity> QuantityList {
            get { return quantityList; }
            set { quantityList = value; }
        }

        public Quantity ResultQuantity {
            get { return resultQuantity; }
            set { resultQuantity = value; }
        }
       
        public string SelectedOperation {
            get { return selectedOperation; }
            set { selectedOperation = value; }
        }       
        public string Result { get; set; }        
    }
}