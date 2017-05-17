using System.Collections.Generic;
using Logic;

namespace Software.ViewModel
{
    public class ComplexMathViewModel
    {
        public Quantity FirstQuantity { get; set; }
        public Quantity SecondQuantity { get; set; }
        public Quantity ResultQuantity { get; set; } = Quantity.Empty;        
        public string SelectedOperation { get; set; }  
        public int NumberOfUnits { get; set; }     
        public List<int> PowerList { get; set; }
        public List<string> UnitList { get; set; }   
        public string Result { get; set; }    
    }
}