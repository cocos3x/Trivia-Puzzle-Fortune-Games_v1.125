using UnityEngine;
public class TRVIconConfig : ScriptableObject
{
    // Fields
    public System.Collections.Generic.List<TRVIconConfig.TRVIcon> icons;
    public System.Collections.Generic.List<TRVIconConfig.TRVIcon> eventIcons;
    public System.Collections.Generic.List<TRVIconConfig.TRVIcon> specialCats;
    
    // Methods
    public TRVIconConfig()
    {
        this.icons = new System.Collections.Generic.List<TRVIcon>();
        this.eventIcons = new System.Collections.Generic.List<TRVIcon>();
        this.specialCats = new System.Collections.Generic.List<TRVIcon>();
    }

}
