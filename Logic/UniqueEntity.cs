using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids;
using Logic.BaseClasses;

namespace Logic
{
    public class UniqueEntity: Archetype
    {
        private string uniqueId;

        public string UniqueId
        {
            get { return Strings.EmptyIfNull(uniqueId); }
            set { uniqueId = value; }
        }

        protected override void SetRandomValues() {
            base.SetRandomValues();
            uniqueId = GetRandom.String();
        }
    }
}
