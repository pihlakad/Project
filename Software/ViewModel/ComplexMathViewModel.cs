using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace Software.ViewModel
{
    public class ComplexMathViewModel
    {
        public Quantity FirstQuantity { get; set; }
        public Quantity SecondQuantity { get; set; }
        public Quantity ResultQuantity { get; set; } = Quantity.Empty;
        public string Measure { get; set; }
        public string SelectedOperation { get; set; }        
        public List<int> PowerList { get; set; }
        public List<string> UnitList { get; set; }        
    }
}