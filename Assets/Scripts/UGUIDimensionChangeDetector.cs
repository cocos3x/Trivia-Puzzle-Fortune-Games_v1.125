using UnityEngine;
public class UGUIDimensionChangeDetector : UIBehaviour
{
    // Fields
    public System.Action OnDimensionChange;
    
    // Methods
    protected override void OnRectTransformDimensionsChange()
    {
        this.OnRectTransformDimensionsChange();
        if(this.OnDimensionChange == null)
        {
                return;
        }
        
        this.OnDimensionChange.Invoke();
    }
    public UGUIDimensionChangeDetector()
    {
    
    }

}
