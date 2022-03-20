using UnityEngine;
public class WGStoreProxy : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject packItemPrefab;
    private UnityEngine.Transform packItemsParent;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private bool oocFlow;
    private TrackerPurchasePoints originalEntryPoint;
    private System.Action onClose;
    
    // Methods
    public void Init(bool outOfCredits = False, System.Action onCloseAction)
    {
        this.onClose = onCloseAction;
        this.oocFlow = outOfCredits;
    }
    private System.Collections.IEnumerator WaitForInit()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGStoreProxy.<WaitForInit>d__7();
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.WaitForInit());
        if((CPlayerPrefs.GetInt(key:  "noAdsNotifProg", defaultValue:  0)) != 1)
        {
                return;
        }
        
        CPlayerPrefs.SetInt(key:  "noAdsNotifProg", val:  2);
        CPlayerPrefs.Save();
    }
    private void ShowContent()
    {
        var val_10;
        var val_11;
        val_10 = null;
        val_10 = null;
        this.originalEntryPoint = PurchaseProxy.currentPurchasePoint;
        if(this.oocFlow != false)
        {
                if((SuperBundleEventHandler._Instance != null) && (SuperBundleEventHandler._Instance.CanShowSuperBundleOnStoreOOCFlow() != false))
        {
                val_11 = null;
            val_11 = null;
            PurchaseProxy.currentPurchasePoint = this.originalEntryPoint;
        }
        else
        {
                if((this.oocFlow != false) && ((MonoSingleton<WGWaterfallSaleManager>.Instance) != 0))
        {
                if((MonoSingleton<WGWaterfallSaleManager>.Instance.CanDisplayWaterfallSale(oocFlow:  true)) != false)
        {
                MonoSingleton<WGWaterfallSaleManager>.Instance.ShowPopup(oocFlow:  true, storeCloseCallback:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGStoreProxy::<ShowContent>b__9_0(bool purchased)));
            return;
        }
        
        }
        
        }
        
        }
        
        MonoSingletonSelfGenerating<GameStoreManager>.Instance.ShowStore(categoryFocus:  "", storeCloseCallback:  new System.Action<System.Boolean, System.Boolean>(object:  this, method:  System.Void WGStoreProxy::OnCloseCallback(bool purchased, bool forcedClose)));
    }
    private void OnCloseCallback(bool purchased, bool forcedClose)
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnWGStoreClosed");
        if(forcedClose != false)
        {
                this = this.onClose;
        }
        else
        {
                GameBehavior val_3 = App.getBehavior;
            bool val_4 = purchased;
            if(this.onClose != null)
        {
                this.onClose.Invoke();
        }
        
        }
        
        this.onClose = 0;
    }
    private void OnDisable()
    {
    
    }
    public WGStoreProxy()
    {
    
    }
    private void <ShowContent>b__9_0(bool purchased)
    {
        var val_3;
        if(purchased != false)
        {
                this.OnCloseCallback(purchased:  true, forcedClose:  true);
            return;
        }
        
        val_3 = null;
        val_3 = null;
        PurchaseProxy.currentPurchasePoint = this.originalEntryPoint;
        MonoSingletonSelfGenerating<GameStoreManager>.Instance.ShowStore(categoryFocus:  "", storeCloseCallback:  new System.Action<System.Boolean, System.Boolean>(object:  this, method:  System.Void WGStoreProxy::OnCloseCallback(bool purchased, bool forcedClose)));
    }

}
