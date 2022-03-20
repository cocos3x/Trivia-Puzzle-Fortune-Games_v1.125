using UnityEngine;
public class TRVPurchasePointTracker : MonoBehaviour
{
    // Methods
    private void OnEnable()
    {
        UnityEngine.UI.Button val_2 = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        val_2.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVPurchasePointTracker::OnClick()));
    }
    private void OnClick()
    {
        var val_2;
        var val_3;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        val_2 = 1152921504891564032;
        val_3 = null;
        val_3 = null;
        PurchaseProxy.currentPurchasePoint = 1;
    }
    public TRVPurchasePointTracker()
    {
    
    }

}
