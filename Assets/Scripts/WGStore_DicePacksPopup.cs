using UnityEngine;
public class WGStore_DicePacksPopup : MonoBehaviour, IStoreUI
{
    // Fields
    private UnityEngine.GameObject storeDicePackItemPrefab;
    private UnityEngine.Transform packParentXfm;
    private LimitedTimeBundlePackDisplay ltbPackDisplay;
    private UnityEngine.UI.Button closeButton;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private WADPetFoodAnimationInstantiator foodAnim;
    private DiceRollAnimationInstantiator diceAnim;
    private System.Collections.Generic.List<WGStore_DicePackItem> packItems;
    private System.Collections.Generic.List<PurchaseModel> packages;
    
    // Properties
    private System.Collections.Generic.List<PurchaseModel> Packages { get; }
    
    // Methods
    private System.Collections.Generic.List<PurchaseModel> get_Packages()
    {
        System.Collections.Generic.List<PurchaseModel> val_5;
        if(this.packages != null)
        {
                if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_5;
        }
        
        }
        
        this.packages = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrieveDiceRollsPurchasePacks();
        return val_5;
        label_5:
        val_5 = this.packages;
        return val_5;
    }
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGStore_DicePacksPopup).__il2cppRuntimeField_1C8));
    }
    private void OnEnable()
    {
        this.SetupPuchaseCallbacks();
        this.RefreshPackItemDisplays();
        this.SetupLimitedTimeDiceBundle();
    }
    private void OnDestroy()
    {
        this.ResetPurchaseCallbacks();
    }
    public void RefreshPackItemDisplays()
    {
        System.Collections.Generic.List<WGStore_DicePackItem> val_2 = this.packItems;
        if(val_2 != null)
        {
                if(true > 0)
        {
            goto label_2;
        }
        
        }
        
        this.CreatePackItems();
        val_2 = this.packItems;
        label_2:
        var val_3 = 4;
        do
        {
            var val_1 = val_3 - 4;
            if(val_1 >= true)
        {
                return;
        }
        
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.Collections.Generic.List<PurchaseModel> val_2 = this.Packages;
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = this.packItems;
            val_3 = val_3 + 1;
        }
        while(val_2 != null);
        
        throw new NullReferenceException();
    }
    public void CreatePackItems()
    {
        this.packItems = new System.Collections.Generic.List<WGStore_DicePackItem>();
        System.Collections.Generic.List<PurchaseModel> val_2 = this.Packages;
        if(W21 < 1)
        {
                return;
        }
        
        var val_3 = 0;
        do
        {
            this.MakeStoreItem(index:  0, parentXfm:  this.packParentXfm);
            val_3 = val_3 + 1;
        }
        while(W21 != val_3);
    
    }
    public void PurchaseItemModel(PurchaseModel pack)
    {
        MonoSingletonSelfGenerating<WGStoreController>.Instance.Purchase(purchase:  pack);
    }
    public void MakeStoreItem(int index, UnityEngine.Transform parentXfm)
    {
        var val_6 = 1152921513413301296;
        UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.storeDicePackItemPrefab, parent:  parentXfm);
        System.Collections.Generic.List<PurchaseModel> val_2 = this.Packages;
        if(val_6 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (index << 3);
        decimal val_3 = (1152921513413301296 + (index) << 3) + 32.DiceRolls;
        val_1.name = "PackItem_" + val_3;
        this.packItems.Add(item:  val_1.GetComponent<WGStore_DicePackItem>());
    }
    public void ShowConnectionRequired()
    {
        int val_8;
        var val_9;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_8 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_8 = val_6.Length;
        val_6[1] = "NULL";
        val_9 = null;
        val_9 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "dice");
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void SetupPuchaseCallbacks()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_DicePacksPopup::OnPurchaseCompleted(PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_DicePacksPopup::OnPurchaseFailure(PurchaseModel purchase)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        return;
        label_6:
    }
    private void ResetPurchaseCallbacks()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_DicePacksPopup::OnPurchaseCompleted(PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseFailure, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_DicePacksPopup::OnPurchaseFailure(PurchaseModel purchase)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        return;
        label_6:
    }
    private void OnPurchaseCompleted(PurchaseModel purchase)
    {
        var val_7;
        decimal val_1 = purchase.DiceRolls;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        if((purchase.id.Contains(value:  "dice")) != true)
        {
                if((purchase.id.Contains(value:  "bundle")) == false)
        {
                return;
        }
        
        }
        
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.DisplayPurchaseSuccess(purchase:  purchase));
    }
    private void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "bundle")) != true)
        {
                if((purchase.id.Contains(value:  "dice")) == false)
        {
                return;
        }
        
        }
        
        string val_4 = Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false);
        val_4.DisplayPurchaseFail(title:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), message:  val_4);
    }
    private void AnimateCoins(decimal fromAmount, decimal toAmount, System.Action actionOnComplete)
    {
        this.coinAnim.OnCompleteCallback = actionOnComplete;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}, toValue:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void AnimatePurchase(CurrencyCollectAnimationInstantiator animControl, int fromAmount, int toAmount, System.Action actionOnComplete, float delay = 0)
    {
        animControl.OnCompleteCallback = actionOnComplete;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.StartAnimating(animControl:  animControl, fromAmount:  fromAmount, toAmount:  toAmount, delay:  delay));
    }
    private System.Collections.IEnumerator StartAnimating(CurrencyCollectAnimationInstantiator animControl, int fromAmount, int toAmount, float delay)
    {
        .animControl = animControl;
        .fromAmount = fromAmount;
        .toAmount = toAmount;
        .delay = delay;
        return (System.Collections.IEnumerator)new WGStore_DicePacksPopup.<StartAnimating>d__26(<>1__state:  0);
    }
    private System.Collections.IEnumerator DisplayPurchaseSuccess(PurchaseModel purchase)
    {
        .purchase = purchase;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGStore_DicePacksPopup.<DisplayPurchaseSuccess>d__27(<>1__state:  0);
    }
    private void DisplayPurchaseFail(string title, string message)
    {
        int val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_3 = new bool[2];
        val_3[0] = true;
        string[] val_4 = new string[2];
        val_6 = val_4.Length;
        val_4[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_6 = val_4.Length;
        val_4[1] = "NO";
        val_7 = null;
        val_7 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  val_3, buttonTexts:  val_4, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "dice");
    }
    private void SetupLimitedTimeDiceBundle()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.ltbPackDisplay)) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = MonoSingleton<LimitedTimeBundlesManager>.Instance.GetAvailableBundles().Item["id_bundles6"];
        this.ltbPackDisplay.Setup(purchase:  new PurchaseModel(packageDefinition:  val_4), valueModel:  new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_4.Item["credit_package"])), bundlePack:  val_4, timesPurchased:  0, isHot:  false, isBest:  true);
    }
    public WGStore_DicePacksPopup()
    {
    
    }

}
