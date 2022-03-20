using UnityEngine;
public class WGStore_WADPets : MonoBehaviour, IStoreUI
{
    // Fields
    private UnityEngine.UI.Text bannerText;
    private UnityEngine.GameObject storePetFoodItemPrefab;
    private UnityEngine.Transform packParentXfm;
    private UnityEngine.UI.Button closeButton;
    private WADPetFoodAnimationInstantiator foodAnim;
    private static WADPets.StoreType storeType;
    private System.Collections.Generic.List<WGStoreItem_pet> packItems;
    private System.Collections.Generic.List<PurchaseModel> packages;
    
    // Properties
    private System.Collections.Generic.List<PurchaseModel> Packages { get; }
    
    // Methods
    private System.Collections.Generic.List<PurchaseModel> get_Packages()
    {
        if(this.packages != null)
        {
                if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return (System.Collections.Generic.List<PurchaseModel>)this.packages;
        }
        
        }
        
        if(WGStore_WADPets.storeType != 0)
        {
                return (System.Collections.Generic.List<PurchaseModel>)this.packages;
        }
        
        this.packages = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePetsFoodPurchasePacks();
        return (System.Collections.Generic.List<PurchaseModel>)this.packages;
    }
    public void Init(WADPets.StoreType type)
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGStore_WADPets).__il2cppRuntimeField_1C8));
        WGStore_WADPets.storeType = type;
        this.SetupPuchaseCallbacks();
        this.SetupBannerText();
        this.RefreshPackItemDisplays();
        this.SetupCurrencyAnim();
    }
    public void PurchaseItemModel(PurchaseModel pack)
    {
        MonoSingletonSelfGenerating<WGStoreController>.Instance.Purchase(purchase:  pack);
    }
    public void RefreshPackItemDisplays()
    {
        System.Collections.Generic.List<WGStoreItem_pet> val_2 = this.packItems;
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
        this.packItems = new System.Collections.Generic.List<WGStoreItem_pet>();
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
    public void MakeStoreItem(int index, UnityEngine.Transform parentXfm)
    {
        var val_6 = 1152921513413301296;
        UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.storePetFoodItemPrefab, parent:  parentXfm);
        System.Collections.Generic.List<PurchaseModel> val_2 = this.Packages;
        if(val_6 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (index << 3);
        decimal val_3 = (1152921513413301296 + (index) << 3) + 32.PetsFood;
        val_1.name = "PackItem_" + val_3;
        this.packItems.Add(item:  val_1.GetComponent<WGStoreItem_pet>());
    }
    public void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = WGStore_WADPets.<>c.<>9__15_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  WGStore_WADPets.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGStore_WADPets.<>c::<ShowConnectionRequired>b__15_0());
            WGStore_WADPets.<>c.<>9__15_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        MonoSingleton<WADPetsWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "food");
        this.Close();
    }
    public void Close()
    {
        if(this == 0)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  true);
    }
    private void SetupPuchaseCallbacks()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_WADPets::OnFoodPurchaseCompleted(PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_WADPets::OnPurchaseFailure(PurchaseModel model)));
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
    private void OnDestroy()
    {
        this.ResetPurchaseCallbacks();
    }
    private void ResetPurchaseCallbacks()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_WADPets::OnFoodPurchaseCompleted(PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseFailure, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStore_WADPets::OnPurchaseFailure(PurchaseModel model)));
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
    private void OnFoodPurchaseCompleted(PurchaseModel purchase)
    {
        var val_5;
        decimal val_1 = purchase.PetsFood;
        val_5 = null;
        val_5 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.WaitPlayFoodAnim(purchase:  purchase));
    }
    private System.Collections.IEnumerator WaitPlayFoodAnim(PurchaseModel purchase)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .purchase = purchase;
        return (System.Collections.IEnumerator)new WGStore_WADPets.<WaitPlayFoodAnim>d__21();
    }
    private void OnPurchaseFailure(PurchaseModel model)
    {
        string val_2 = Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false);
        val_2.DisplayPurchaseFail(title:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), message:  val_2);
        this.Close();
    }
    public void DisplayPurchaseFail(string title, string message)
    {
        int val_8;
        var val_9;
        System.Func<System.Boolean> val_11;
        var val_12;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_3 = new bool[2];
        val_3[0] = true;
        string[] val_4 = new string[2];
        val_8 = val_4.Length;
        val_4[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_8 = val_4.Length;
        val_4[1] = "NO";
        System.Func<System.Boolean>[] val_6 = new System.Func<System.Boolean>[2];
        val_9 = null;
        val_9 = null;
        val_11 = WGStore_WADPets.<>c.<>9__23_0;
        if(val_11 == null)
        {
                System.Func<System.Boolean> val_7 = null;
            val_11 = val_7;
            val_7 = new System.Func<System.Boolean>(object:  WGStore_WADPets.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGStore_WADPets.<>c::<DisplayPurchaseFail>b__23_0());
            WGStore_WADPets.<>c.<>9__23_0 = val_11;
        }
        
        val_6[0] = val_11;
        val_12 = null;
        val_12 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  val_3, buttonTexts:  val_4, showClose:  false, buttonCallbacks:  val_6, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "food");
    }
    private void SetupBannerText()
    {
        string val_1 = Localization.Localize(key:  "buy_food_upper", defaultValue:  "BUY FOOD", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SetupCurrencyAnim()
    {
        this.foodAnim.gameObject.SetActive(value:  true);
    }
    public WGStore_WADPets()
    {
    
    }

}
