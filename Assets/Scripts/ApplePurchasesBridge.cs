using UnityEngine;
public class ApplePurchasesBridge : PurchasesBridge, PluginObserver
{
    // Fields
    private bool initialized;
    
    // Methods
    public PluginObserverManager.ObserverType getType()
    {
        return 3;
    }
    public string pluginName()
    {
        return "Apple Store";
    }
    public string errorMessage()
    {
        var val_2;
        if(this.initialized != false)
        {
                var val_1 = ((this.initialized + 24) == 0) ? "Failed to query the inventory, service not working." : "Bridge working correctly.";
            return (string)val_2;
        }
        
        val_2 = "Not initialized!";
        return (string)val_2;
    }
    public bool isWorking()
    {
        if(X8 != 0)
        {
                return (bool)X8 + 24;
        }
        
        throw new NullReferenceException();
    }
    public bool isInitialized()
    {
        return (bool)this.initialized;
    }
    public ApplePurchasesBridge(InAppPurchasesManager manager)
    {
    
    }

}
