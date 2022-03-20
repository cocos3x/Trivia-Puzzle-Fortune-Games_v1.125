using UnityEngine;
[Serializable]
public class TRVCategoryExpertEcon
{
    // Fields
    public string Category;
    public System.Collections.Generic.List<TRVExpert> experts;
    public bool upgradeOnlyEcon;
    
    // Properties
    public string GetLocalizedName { get; }
    
    // Methods
    public string get_GetLocalizedName()
    {
        if(this.upgradeOnlyEcon == false)
        {
                return Localization.Localize(key:  System.String.Format(format:  "category_{0}", arg0:  this.Category.ToLower()), defaultValue:  this.Category.ToUpper(), useSingularKey:  false);
        }
        
        return (string)this.Category;
    }
    public TRVCategoryExpertEcon()
    {
    
    }

}
