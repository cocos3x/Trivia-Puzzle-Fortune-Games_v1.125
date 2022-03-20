using UnityEngine;
public class LimitedTimeBundlesPackDisplayManager : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform itemContainer;
    private LimitedTimeBundlesPopup myPopup;
    private System.Collections.Generic.List<LimitedTimeBundlePackDisplay> packDisplays;
    private System.Collections.Generic.List<string> alphabetLetters;
    
    // Methods
    public void CreatePackItems(UnityEngine.Transform packItemContainer, LimitedTimeBundlesPopup popupContainer)
    {
        LimitedTimeBundlesPopup val_9 = popupContainer;
        this.itemContainer = packItemContainer;
        this.myPopup = val_9;
        packItemContainer.GetComponent<UnityEngine.UI.VerticalLayoutGroup>().spacing = 20f;
        int val_4 = MonoSingleton<LimitedTimeBundlesManager>.Instance.GetAllBundles().Count;
        if(val_4 >= 1)
        {
                var val_9 = 0;
            do
        {
            val_9 = this.itemContainer;
            this.packDisplays.Add(item:  UnityEngine.Object.Instantiate<LimitedTimeBundlePackDisplay>(original:  MonoSingleton<LimitedTimeBundlesManager>.Instance.prefab_limited_time_bundle, parent:  val_9));
            val_9 = val_9 + 1;
        }
        while(val_9 < val_4);
        
        }
        
        this.RefreshPackItems();
        LimitedTimeBundlesManager val_8 = MonoSingleton<LimitedTimeBundlesManager>.Instance;
        val_8.CurrentPackDisplay = this;
    }
    public void RefreshPackItems()
    {
        var val_31;
        var val_32;
        var val_33;
        UnityEngine.Transform val_34;
        var val_35;
        var val_36;
        var val_37;
        val_32 = this;
        if((MonoSingleton<LimitedTimeBundlesManager>.Instance.HaveBundlesToShow()) != false)
        {
                var val_3 = (this.packDisplays > 0) ? 1 : 0;
        }
        else
        {
                val_33 = 0;
        }
        
        val_34 = this.itemContainer;
        if(val_34 != 0)
        {
                this.itemContainer.gameObject.SetActive(value:  false);
        }
        
        if(val_33 == 0)
        {
                return;
        }
        
        System.Collections.Generic.List<System.String> val_6 = LimitedTimeBundlesManager.BundlePackagesKeys;
        if(1152921515677425360 >= 1)
        {
                val_35 = 1152921516519683568;
            val_36 = 1152921516519874416;
            val_34 = MonoSingleton<LimitedTimeBundlesManager>.Instance.GetAvailableBundles();
            var val_32 = 0;
            do
        {
            if(1152921515677425360 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(44375464 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_31 = 0;
            string val_31 = "com.twelvegigs.plugins.AdIdPlugin";
            val_31 = val_34.ContainsKey(key:  val_31);
            gameObject.SetActive(value:  val_31);
            if(44375464 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((val_34.ContainsKey(key:  "com.twelvegigs.plugins.AdIdPlugin")) != false)
        {
                if(44375464 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(null <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(1152921515677425360 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(1 == 2)
        {
                var val_21 = (val_34.Count > 2) ? 1 : 0;
        }
        else
        {
                val_37 = 0;
        }
        
            if(44375464 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            Setup(purchase:  new PurchaseModel(packageDefinition:  val_34.Item["com.twelvegigs.plugins.AdIdPlugin"]), valueModel:  new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_34.Item[PurchaseModel.__il2cppRuntimeField_byval_arg].Item["credit_package"])), bundlePack:  val_34.Item["com.twelvegigs.plugins.AdIdPlugin"], timesPurchased:  MonoSingleton<LimitedTimeBundlesManager>.Instance.GetCurrentCountOfBundlePurchase(bundleId:  "com.twelvegigs.plugins.AdIdPlugin"), isHot:  false, isBest:  (1 == val_34.Count) ? 1 : 0);
            val_35 = 1152921516519683568;
            val_32 = val_32;
            val_36 = val_36;
        }
        
            val_32 = val_32 + 1;
        }
        while(val_32 < 1);
        
        }
        
        if(this.myPopup == 0)
        {
                return;
        }
        
        this.itemContainer.transform.parent.gameObject.SetActive(value:  false);
        UnityEngine.Coroutine val_30 = this.StartCoroutine(routine:  this.WaitAndActivateItemContainer());
    }
    public void PrepareBundlePurchaseSuccess(System.Collections.Generic.List<string> alphabetLettersPurchased)
    {
        object val_6;
        LimitedTimeBundlesPopup val_7;
        IntPtr val_9;
        System.Action val_10;
        System.Action val_11;
        IntPtr val_13;
        var val_14;
        val_6 = this;
        GameBehavior val_1 = App.getBehavior;
        this.alphabetLetters = alphabetLettersPurchased;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        if(this.myPopup == 0)
        {
            goto label_8;
        }
        
        val_7 = this.myPopup;
        val_9 = 1152921516525350032;
        goto label_9;
        label_5:
        if(this.myPopup == 0)
        {
            goto label_12;
        }
        
        val_7 = this.myPopup;
        System.Action val_4 = null;
        val_9 = 1152921516525359248;
        label_9:
        val_10 = val_4;
        val_4 = new System.Action(object:  this, method:  val_9);
        val_11 = this.myPopup.OnAnimationsComplete;
        goto label_14;
        label_8:
        val_13 = 1152921516525350032;
        goto label_15;
        label_12:
        System.Action val_5 = null;
        val_13 = 1152921516525359248;
        label_15:
        val_10 = val_5;
        val_5 = new System.Action(object:  this, method:  val_13);
        val_6 = 1152921504921862144;
        val_14 = null;
        val_14 = null;
        val_11 = 1152921504921866264;
        label_14:
        GameStoreUI.OnRewardAnimationsComplete = val_10;
    }
    private System.Collections.IEnumerator WaitAndActivateItemContainer()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new LimitedTimeBundlesPackDisplayManager.<WaitAndActivateItemContainer>d__7();
    }
    private void PostAnimationLogic()
    {
        var val_3;
        if(this.myPopup != 0)
        {
                this.myPopup.OnAnimationsComplete = 0;
            SLCWindow.CloseWindow(window:  this.myPopup.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        val_3 = null;
        val_3 = null;
        GameStoreUI.OnRewardAnimationsComplete = 0;
    }
    private void OnStorePurchaseFinished()
    {
        var val_6;
        if((MonoSingleton<GameStoreUI>.Instance) != 0)
        {
                MonoSingleton<GameStoreUI>.Instance.Close();
        }
        
        if(this.myPopup != 0)
        {
                this.myPopup.OnAnimationsComplete = 0;
            SLCWindow.CloseWindow(window:  this.myPopup.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        val_6 = null;
        val_6 = null;
        GameStoreUI.OnRewardAnimationsComplete = 0;
    }
    public LimitedTimeBundlesPackDisplayManager()
    {
        this.packDisplays = new System.Collections.Generic.List<LimitedTimeBundlePackDisplay>();
    }

}
