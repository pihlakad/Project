using Aids;
using Logic.BaseClasses;

namespace Logic
{
    public class UniqueEntity: Archetype
    {
        protected string uniqueId;

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
