using UnityEngine;
public class TRVCategorySelectionInfo
{
    // Fields
    public string categoryName;
    public System.Collections.Generic.List<WGEventHandler> associatedEvents;
    
    // Methods
    public TRVCategorySelectionInfo()
    {
        this.categoryName = "";
        this.associatedEvents = new System.Collections.Generic.List<WGEventHandler>();
    }

}
