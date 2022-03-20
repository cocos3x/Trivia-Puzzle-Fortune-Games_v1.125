using UnityEngine;
public class WGStarterPackPopup : MonoBehaviour
{
    // Fields
    private bool madePurchase;
    private UGUINetworkedButton button;
    private UnityEngine.UI.Text timeRemaining;
    private UnityEngine.UI.Text text_coins_amount;
    private UnityEngine.UI.Text text_purchase_price;
    private UnityEngine.UI.Text text_dollar_value;
    private GridCoinCollectAnimationInstantiator coinAnimator;
    
    // Methods
    private void Start()
    {
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGStarterPackPopup::UpdateTimeRemaining()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        val_2.updateLogic = val_4;
        this.button.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGStarterPackPopup::OnPurchaseClicked(bool success));
        CPlayerPrefs.SetInt(key:  "starterPackPrompted", val:  1);
        WGStarterPackController.SetTimeShown();
        System.TimeSpan val_7 = MonoSingleton<WGStarterPackController>.Instance.timeRemaining;
        if(val_7._ticks.TotalSeconds <= 0f)
        {
                this.Close();
        }
        
        PurchaseModel val_9 = WGStarterPackController.GetStarterPack();
        decimal val_10 = val_9.Credits;
        string val_13 = System.String.Format(format:  "{0} {1}", arg0:  val_10.flags.ToString(format:  "#,##0"), arg1:  Localization.Localize(key:  "coins_upper", defaultValue:  "COINS", useSingularKey:  false));
        string val_14 = val_9.LocalPrice;
        return;
        label_3:
    }
    private void OnPurchaseClicked(bool success)
    {
        int val_15;
        var val_16;
        if(success != false)
        {
                this.button.interactable = false;
            Player val_1 = App.Player;
            WGStarterPackController val_2 = MonoSingleton<WGStarterPackController>.Instance;
            val_2.purchaseResult = new System.Action<System.Boolean, System.Decimal>(object:  this, method:  System.Void WGStarterPackPopup::OnPurchaseResponse(bool result, decimal coins));
            MonoSingleton<WGStarterPackController>.Instance.TryMakePurchase();
            return;
        }
        
        this.gameObject.SetActive(value:  false);
        bool[] val_10 = new bool[2];
        val_10[0] = true;
        string[] val_11 = new string[2];
        val_15 = val_11.Length;
        val_11[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_15 = val_11.Length;
        val_11[1] = "NULL";
        System.Func<System.Boolean>[] val_13 = new System.Func<System.Boolean>[2];
        val_13[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGStarterPackPopup::<OnPurchaseClicked>b__8_0());
        val_16 = null;
        val_16 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_10, buttonTexts:  val_11, showClose:  false, buttonCallbacks:  val_13, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void UpdateTimeRemaining()
    {
        System.TimeSpan val_2 = MonoSingleton<WGStarterPackController>.Instance.timeRemaining;
        if(val_2._ticks.TotalSeconds > 0f)
        {
                System.TimeSpan val_5 = MonoSingleton<WGStarterPackController>.Instance.timeRemaining;
            string val_6 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_5._ticks}, formatted:  true);
            return;
        }
        
        System.TimeSpan val_7 = new System.TimeSpan(hours:  0, minutes:  0, seconds:  0);
        string val_8 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_7._ticks}, formatted:  true);
        this.gameObject.GetComponent<FrameSkipper>().enabled = false;
        this.Close();
    }
    private void OnPurchaseResponse(bool result, decimal coins)
    {
        int val_21;
        System.Boolean[] val_22;
        int val_23;
        var val_24;
        val_21 = coins.flags;
        if(result != false)
        {
                this.madePurchase = true;
            val_22 = 1152921504884269056;
            App.Player.RemovedAds = true;
            if(this.coinAnimator == 0)
        {
                return;
        }
        
            this.coinAnimator.gameObject.SetActive(value:  true);
            this.coinAnimator.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGStarterPackPopup::Close());
            Player val_5 = App.Player;
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = 489931360, mid = 268435459}, d2:  new System.Decimal() {flags = val_21, hi = coins.hi, lo = coins.lo, mid = coins.mid});
            Player val_7 = App.Player;
            this.coinAnimator.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
        val_21 = Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false);
        bool[] val_12 = new bool[2];
        val_22 = val_12;
        val_22[0] = true;
        string[] val_13 = new string[2];
        val_23 = val_13.Length;
        val_13[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_23 = val_13.Length;
        val_13[1] = "NULL";
        System.Func<System.Boolean>[] val_15 = new System.Func<System.Boolean>[2];
        val_15[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGStarterPackPopup::<OnPurchaseResponse>b__10_0());
        val_24 = null;
        val_24 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  val_21, messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_12, buttonTexts:  val_13, showClose:  false, buttonCallbacks:  val_15, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        if(this == 0)
        {
                return;
        }
        
        if(this.gameObject == 0)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void OnFailure()
    {
        System.TimeSpan val_2 = MonoSingleton<WGStarterPackController>.Instance.timeRemaining;
        if(val_2._ticks.TotalSeconds > 0f)
        {
                WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterPackPopup>(showNext:  false);
            return;
        }
        
        WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true);
        mem2[0] = 0;
        mem2[0] = 0;
    }
    private void Close()
    {
        if(this.madePurchase != true)
        {
                WGStarterPackController val_1 = MonoSingleton<WGStarterPackController>.Instance;
            if(val_1._ap == 47)
        {
                WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true);
            mem2[0] = 0;
            mem2[0] = 0;
        }
        
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public WGStarterPackPopup()
    {
    
    }
    private bool <OnPurchaseClicked>b__8_0()
    {
        this.OnFailure();
        return true;
    }
    private bool <OnPurchaseResponse>b__10_0()
    {
        this.OnFailure();
        return true;
    }

}
