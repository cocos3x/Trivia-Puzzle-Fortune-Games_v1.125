using UnityEngine;
public class UGUIPurchasePointButtonTracker : MonoBehaviour
{
    // Fields
    private TrackerPurchasePoints purchasePoint;
    protected UnityEngine.UI.Button button;
    
    // Methods
    protected virtual void Start()
    {
        UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
        this.button = val_1;
        if(val_1 == 0)
        {
                return;
        }
        
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void UGUIPurchasePointButtonTracker::OnButtonClick()));
    }
    public void OnButtonClick()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = this.purchasePoint;
    }
    public UGUIPurchasePointButtonTracker()
    {
    
    }

}
