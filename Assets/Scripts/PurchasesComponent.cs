using UnityEngine;
public class PurchasesComponent : AppComponent
{
    // Properties
    public override bool RunInMainThread { get; }
    
    // Methods
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public PurchasesComponent(string gameName, string gameObjectName)
    {
        mem[1152921515591088880] = "PurchasesComponent";
    }
    public override void initializeOnMainThread()
    {
        var val_6;
        var val_7;
        var val_8;
        this.Log(message:  "InitPurchasing!");
        val_6 = null;
        val_6 = null;
        App.inAppPurchasesManager.Init(key:  this.getPurchaseKey());
        val_7 = null;
        val_7 = null;
        App.inAppPurchasesManager.Logging = true;
        val_8 = null;
        val_8 = null;
        AppConfigs val_2 = App.Configuration;
        App.inAppPurchasesManager.SetPurchaseables(packs:  val_2.storeConfig.GetSkus());
        MonoSingletonSelfGenerating<AsyncExecution>.Instance.Async(callback:  new System.Action(object:  this, method:  System.Void PurchasesComponent::QueryInventory()), when:  1f);
    }
    private void QueryInventory()
    {
        var val_17;
        InAppPurchasesManager val_18;
        var val_19;
        AppConfigs val_1 = App.Configuration;
        UnityEngine.Debug.Log(message:  "SKUS " + PrettyPrint.printJSON(obj:  val_1.storeConfig.GetSkus(), types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_1.storeConfig.GetSkus(), types:  false, singleLineOutput:  false)));
        val_17 = null;
        val_17 = null;
        val_18 = App.inAppPurchasesManager;
        AppConfigs val_5 = App.Configuration;
        AppConfigs val_7 = App.Configuration;
        val_18.QueryInventory(prodSkus:  val_5.storeConfig.GetSkusBy(cat:  0), subSkus:  val_7.storeConfig.GetSkusBy(cat:  1));
        val_19 = null;
        val_19 = null;
        if(Logger.Store != false)
        {
                AppConfigs val_9 = App.Configuration;
            val_18 = "SKUS " + PrettyPrint.printJSON(obj:  val_9.storeConfig.GetSkus(), types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_9.storeConfig.GetSkus(), types:  false, singleLineOutput:  false));
            UnityEngine.Debug.Log(message:  val_18);
            val_19 = null;
        }
        
        val_19 = null;
        if(Logger.Store == false)
        {
                return;
        }
        
        AppConfigs val_13 = App.Configuration;
        UnityEngine.Debug.Log(message:  "IDS " + PrettyPrint.printJSON(obj:  val_13.storeConfig.GetIds(), types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_13.storeConfig.GetIds(), types:  false, singleLineOutput:  false)));
    }
    private string getPurchaseKey()
    {
        AppConfigs val_1 = App.Configuration;
        return val_1.appConfig.Key(key:  "googlePlayKey");
    }

}
