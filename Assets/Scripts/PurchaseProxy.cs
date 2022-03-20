using UnityEngine;
public class PurchaseProxy
{
    // Fields
    private static TrackerPurchasePoints currentPurchasePoint;
    
    // Properties
    public static TrackerPurchasePoints CurrentPurchasePoint { get; set; }
    
    // Methods
    public static TrackerPurchasePoints get_CurrentPurchasePoint()
    {
        null = null;
        return (TrackerPurchasePoints)PurchaseProxy.currentPurchasePoint;
    }
    public static void set_CurrentPurchasePoint(TrackerPurchasePoints value)
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = value;
    }
    public static bool Purchase(PurchaseModel purchase)
    {
        PurchaseModel val_6;
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        val_6 = purchase;
        AppConfigs val_1 = App.Configuration;
        ProductDetails val_2 = val_1.storeConfig.GetProductByInternalId(internalId:  purchase.id);
        purchase.<Sku>k__BackingField = val_2.sku;
        purchase.isSubscription = (val_2.productType == 2) ? 1 : 0;
        if(purchase.trackerPurchasePoint == 0)
        {
                val_7 = null;
            val_7 = null;
            purchase.trackerPurchasePoint = PurchaseProxy.currentPurchasePoint;
        }
        
        TrackingComponent.CurrentIntent = 2;
        val_8 = null;
        val_8 = null;
        if((App.inAppPurchasesManager.Purchase(purchase:  val_6)) != false)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_5.Add(key:  "sku", value:  purchase.id);
            val_9 = null;
            val_9 = null;
            val_6 = App.trackerManager;
            val_6.track(eventName:  Events.PURCHASE_INTENT, data:  val_5);
            val_10 = 1;
            return (bool)val_10;
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    public PurchaseProxy()
    {
    
    }
    private static PurchaseProxy()
    {
    
    }

}
