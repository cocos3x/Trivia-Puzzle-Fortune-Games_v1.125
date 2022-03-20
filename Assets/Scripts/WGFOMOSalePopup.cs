using UnityEngine;
public class WGFOMOSalePopup : MonoBehaviour
{
    // Fields
    private bool madePurchase;
    private UGUINetworkedButton button;
    private UnityEngine.UI.Button CloseBtn;
    private UnityEngine.UI.Text timeRemaining;
    private UnityEngine.UI.Text text_coins_amount;
    private UnityEngine.UI.Text text_purchase_price;
    private GridCoinCollectAnimationInstantiator coinAnimator;
    private CurrencyCollectAnimationInstantiator gemAnimator;
    private bool isOOC;
    private float remainingTime;
    
    // Methods
    public void Setup(bool outOfCurrency)
    {
        this.isOOC = outOfCurrency;
        if((MonoSingleton<TRVGameplayUI>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<TRVGameplayUI>.Instance.StopTimer();
        TRVGameplayUI val_5 = MonoSingleton<TRVGameplayUI>.Instance;
        this.remainingTime = val_5.timer.TimeRemaining();
    }
    private void Start()
    {
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGFOMOSalePopup::UpdateTimeRemaining()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        val_2.updateLogic = val_4;
        this.button.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGFOMOSalePopup::OnPurchaseClicked(bool success));
        FOMOPackEventHandler.<Instance>k__BackingField.SetTimeShown();
        System.TimeSpan val_6 = FOMOPackEventHandler.<Instance>k__BackingField.timeRemaining;
        if(val_6._ticks.TotalSeconds <= 0f)
        {
                this.Close();
        }
        
        this.CloseBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFOMOSalePopup::<Start>b__11_0()));
        string val_9 = FOMOPackEventHandler.<Instance>k__BackingField.GetAmount;
        string val_10 = FOMOPackEventHandler.<Instance>k__BackingField.GetPrice;
        if(this.coinAnimator != 0)
        {
                GameBehavior val_13 = App.getBehavior;
            string val_19 = "credits";
            val_19 = System.String.op_Equality(a:  val_13.<metaGameBehavior>k__BackingField, b:  val_19);
            this.coinAnimator.gameObject.SetActive(value:  val_19);
        }
        
        if(this.gemAnimator == 0)
        {
                return;
        }
        
        this = this.gemAnimator.gameObject;
        GameBehavior val_17 = App.getBehavior;
        string val_20 = "gems";
        val_20 = System.String.op_Equality(a:  val_17.<metaGameBehavior>k__BackingField, b:  val_20);
        this.SetActive(value:  val_20);
        return;
        label_3:
    }
    private void OnPurchaseClicked(bool success)
    {
        int val_12;
        var val_13;
        if(success != false)
        {
                this.button.interactable = false;
            FOMOPackEventHandler.<Instance>k__BackingField.purchaseResult = new System.Action<System.Boolean, System.Decimal>(object:  this, method:  System.Void WGFOMOSalePopup::OnPurchaseResponse(bool result, decimal amount));
            FOMOPackEventHandler.<Instance>k__BackingField.TryMakePurchase();
            return;
        }
        
        this.gameObject.SetActive(value:  false);
        GameBehavior val_3 = App.getBehavior;
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_12 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_8.Length;
        val_8[1] = "NULL";
        System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
        val_10[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGFOMOSalePopup::<OnPurchaseClicked>b__12_0());
        if((((X0 + 303) & 2) != 0) && ((X0 + 224) == 0))
        {
                val_13 = null;
        }
        
        val_3.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void UpdateTimeRemaining()
    {
        System.TimeSpan val_1 = FOMOPackEventHandler.<Instance>k__BackingField.timeRemaining;
        string val_3 = Localization.Localize(key:  "limited_time_upper", defaultValue:  "LIMITED TIME", useSingularKey:  false);
        if(val_1._ticks.TotalSeconds > 0f)
        {
                System.TimeSpan val_4 = FOMOPackEventHandler.<Instance>k__BackingField.timeRemaining;
            string val_6 = System.String.Format(format:  "{0}: {1}", arg0:  val_3, arg1:  GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_4._ticks}, formatted:  true));
            return;
        }
        
        System.TimeSpan val_7 = new System.TimeSpan(hours:  0, minutes:  0, seconds:  0);
        string val_9 = System.String.Format(format:  "{0}: {1}", arg0:  val_3, arg1:  GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_7._ticks}, formatted:  true));
        this.gameObject.GetComponent<FrameSkipper>().enabled = false;
        this.Close();
    }
    private void OnPurchaseResponse(bool result, decimal amount)
    {
        int val_32;
        System.Boolean[] val_33;
        int val_34;
        var val_35;
        val_32 = amount.flags;
        if(result == false)
        {
            goto label_1;
        }
        
        this.madePurchase = true;
        val_33 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if(((System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField, b:  "credits")) == false) || (this.coinAnimator == 0))
        {
            goto label_9;
        }
        
        this.coinAnimator.gameObject.SetActive(value:  true);
        this.coinAnimator.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGFOMOSalePopup::Close());
        Player val_6 = App.Player;
        decimal val_7 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = 351133440, mid = 268435459}, d2:  new System.Decimal() {flags = val_32, hi = amount.hi, lo = amount.lo, mid = amount.mid});
        Player val_8 = App.Player;
        this.coinAnimator.Play(fromValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, toValue:  new System.Decimal() {flags = val_8._credits, hi = val_8._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return;
        label_1:
        GameBehavior val_9 = App.getBehavior;
        val_32 = Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false);
        bool[] val_13 = new bool[2];
        val_33 = val_13;
        val_33[0] = true;
        string[] val_14 = new string[2];
        val_34 = val_14.Length;
        val_14[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_34 = val_14.Length;
        val_14[1] = "NULL";
        System.Func<System.Boolean>[] val_16 = new System.Func<System.Boolean>[2];
        val_16[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGFOMOSalePopup::<OnPurchaseResponse>b__14_0());
        val_35 = null;
        val_35 = null;
        val_9.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  val_32, messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_13, buttonTexts:  val_14, showClose:  false, buttonCallbacks:  val_16, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        if(this == 0)
        {
                return;
        }
        
        if(this.gameObject == 0)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
        return;
        label_9:
        GameBehavior val_22 = App.getBehavior;
        if((System.String.op_Equality(a:  val_22.<metaGameBehavior>k__BackingField, b:  "gems")) == false)
        {
                return;
        }
        
        if(this.gemAnimator == 0)
        {
                return;
        }
        
        this.gemAnimator.gameObject.SetActive(value:  true);
        this.gemAnimator.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGFOMOSalePopup::Close());
        Player val_27 = App.Player;
        Player val_29 = App.Player;
        decimal val_30 = System.Decimal.op_Implicit(value:  val_29._gems);
        this.gemAnimator.Play(fromValue:  val_27._gems - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_32, hi = amount.hi, lo = amount.lo, mid = amount.mid})), toValue:  new System.Decimal() {flags = val_30.flags, hi = val_30.hi, lo = val_30.lo, mid = val_30.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void OnFailure()
    {
        System.TimeSpan val_1 = FOMOPackEventHandler.<Instance>k__BackingField.timeRemaining;
        if(val_1._ticks.TotalSeconds <= 0f)
        {
                return;
        }
        
        bool val_3 = FOMOPackEventHandler.<Instance>k__BackingField.TryShowPopup(isOOC:  this.isOOC);
    }
    private void Close()
    {
        if((MonoSingleton<TRVGameplayUI>.Instance) != 0)
        {
                MonoSingleton<TRVGameplayUI>.Instance.ContinueTimer(duration:  this.remainingTime);
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public WGFOMOSalePopup()
    {
    
    }
    private void <Start>b__11_0()
    {
        this.Close();
    }
    private bool <OnPurchaseClicked>b__12_0()
    {
        this.OnFailure();
        return true;
    }
    private bool <OnPurchaseResponse>b__14_0()
    {
        this.OnFailure();
        return true;
    }

}
