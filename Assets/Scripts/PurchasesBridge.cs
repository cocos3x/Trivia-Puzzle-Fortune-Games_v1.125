using UnityEngine;
public class PurchasesBridge
{
    // Fields
    protected InAppPurchasesManager manager;
    protected bool isLogging;
    
    // Methods
    public PurchasesBridge(InAppPurchasesManager manager)
    {
        this.Log(message:  "PurchasesBridge");
        this.manager = manager;
    }
    public virtual void init(string key)
    {
    
    }
    public virtual void queryInventory(string[] productSkus, string[] subSkus)
    {
        if(this.manager != null)
        {
                this.manager.Initialized = true;
            return;
        }
        
        throw new NullReferenceException();
    }
    public virtual void queryHistory()
    {
    
    }
    public virtual void Purchase(string sku)
    {
        goto typeof(PurchasesBridge).__il2cppRuntimeField_1D0;
    }
    public virtual void Subscribe(string sku)
    {
        goto typeof(PurchasesBridge).__il2cppRuntimeField_1D0;
    }
    public virtual void RestorePreviousTransactions()
    {
    
    }
    public virtual void Consume(NativePurchase nativePurchase)
    {
        if(nativePurchase.isSubscription != false)
        {
                this.manager.notifySubscription(success:  true, purchaseInfo:  nativePurchase);
            return;
        }
        
        this.manager.notify(success:  true, purchaseInfo:  nativePurchase);
    }
    protected virtual NativePurchase BuildPurchase(object parameters)
    {
        string val_2;
        if(parameters != null)
        {
                parameters = (null == null) ? parameters : 0;
        }
        else
        {
                val_2 = 0;
        }
        
        new NativePurchase() = new NativePurchase(sku:  val_2);
        return (NativePurchase)new NativePurchase();
    }
    public virtual void setLogging(bool isLogging)
    {
        this.isLogging = isLogging;
    }
    public virtual void setPurchasePackages(string[] purchasePackages)
    {
    
    }
    protected void Log(string message)
    {
        if(this.isLogging == false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  message);
    }

}
