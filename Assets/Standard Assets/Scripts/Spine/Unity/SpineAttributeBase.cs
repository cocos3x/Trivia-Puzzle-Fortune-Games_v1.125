using UnityEngine;

namespace Spine.Unity
{
    public abstract class SpineAttributeBase : PropertyAttribute
    {
        // Fields
        public string dataField;
        public string startsWith;
        public bool includeNone;
        
        // Methods
        protected SpineAttributeBase()
        {
            this.includeNone = true;
            this.dataField = "";
            this.startsWith = "";
        }
    
    }

}
