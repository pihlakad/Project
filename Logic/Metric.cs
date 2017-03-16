using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aids;
using System.Threading.Tasks;

namespace Logic
{
    public class Metric: Archetype {
        private string name;
        public string Name {
            get { return Strings.EmptyIfNull(name); }   
            set { name = value; }         
        }
    }
}
