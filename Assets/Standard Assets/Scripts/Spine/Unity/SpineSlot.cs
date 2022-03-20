using UnityEngine;

namespace Spine.Unity
{
    public class SpineSlot : SpineAttributeBase
    {
        // Fields
        public bool containsBoundingBoxes;
        
        // Methods
        public SpineSlot(string startsWith = "", string dataField = "", bool containsBoundingBoxes = False, bool includeNone = True)
        {
            mem[1152921513282316120] = dataField;
            mem[1152921513282316128] = startsWith;
            this.containsBoundingBoxes = containsBoundingBoxes;
            mem[1152921513282316136] = includeNone;
        }
    
    }

}
