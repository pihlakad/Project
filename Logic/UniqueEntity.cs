using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;

namespace Logic
{
    public class UniqueEntity
    {
        private string uniqueId;

        public string UniqueId
        {
            get { return Strings.EmptyIfNull(uniqueId); }
            set { uniqueId = value; }
        }

    }
}
