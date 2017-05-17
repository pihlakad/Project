using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace Software.ViewModel
{
    public class FormulaeViewModel
    {
        public int NumberOfUnits1 { get; set; }
        public int NumberOfUnits2 { get; set; }
        public List<string> UnitList1 { get; set; }
        public List<string> UnitList2 { get; set; }
        public List<int> PowerList1 { get; set; }
        public List<int> PowerList2 { get; set; }
        public string Result { get; set; }
        public string SelectedOperation { get; set; }
        public List<string> MeasureList { get; set; }
    }
}