using UnityEngine;
public class PurchasePointTracker : MonoBehaviour
{
    // Fields
    private TrackerPurchasePoints currentPoint;
    
    // Methods
    private void Awake()
    {
        if((this.GetComponent<UnityEngine.UI.Button>()) != 0)
        {
                val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void PurchasePointTracker::OnClick()));
            return;
        }
        
        UnityEngine.Debug.LogWarning(message:  "PurchasePointTracker: No ugui button found.", context:  this);
    }
    public void OnClick()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = this.currentPoint;
    }
    public PurchasePointTracker()
    {
    
    }

}
