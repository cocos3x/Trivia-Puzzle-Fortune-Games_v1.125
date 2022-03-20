using UnityEngine;
public class WGWaterfallSalePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text titleTxt;
    private UnityEngine.UI.Text buyBtnTxt;
    private UnityEngine.UI.Text valueTxt;
    private UnityEngine.UI.Text descriptionTxt;
    private UnityEngine.UI.Button CloseBtn;
    private UGUINetworkedButton BuyBtn;
    private TimerText timer;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    
    // Methods
    private void Start()
    {
        this.SetupPopup();
    }
    private void SetupPopup()
    {
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        val_20 = null;
        val_20 = null;
        if(App.game == 1)
        {
            goto label_18;
        }
        
        val_21 = null;
        val_21 = null;
        if(App.game == 4)
        {
            goto label_18;
        }
        
        val_22 = null;
        val_22 = null;
        if(App.game == 18)
        {
            goto label_18;
        }
        
        val_23 = null;
        val_23 = null;
        if(App.game != 16)
        {
            goto label_24;
        }
        
        label_18:
        string val_2 = MonoSingleton<WGWaterfallSaleManager>.Instance.GetCoins();
        WGWaterfallSaleManager val_3 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        string val_4 = val_3.purchaseModel.LocalPrice;
        label_53:
        WGWaterfallSaleManager val_5 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        string val_6 = val_5.valueModel.LocalPrice;
        WGWaterfallSaleManager val_7 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        this.timer.SetTime(value:  val_7.MinutesToDisplay * 60);
        this.timer.countUp = false;
        this.timer.Run();
        System.Delegate val_10 = System.Delegate.Combine(a:  this.timer.onCountDownComplete, b:  new System.Action(object:  this, method:  System.Void WGWaterfallSalePopup::<SetupPopup>b__9_2()));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_43;
        }
        
        }
        
        this.timer.onCountDownComplete = val_10;
        this.CloseBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGWaterfallSalePopup::<SetupPopup>b__9_0()));
        this.BuyBtn.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGWaterfallSalePopup::<SetupPopup>b__9_1(bool success));
        this.coinsAnimControl.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGWaterfallSalePopup::OnCoinsAnimFinished());
        return;
        label_24:
        WGWaterfallSaleManager val_17 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        string val_19 = System.String.Format(format:  Localization.Localize(key:  "#_coins_for_n_only_#", defaultValue:  "{0} Coins for\nOnly {1}", useSingularKey:  false), arg0:  MonoSingleton<WGWaterfallSaleManager>.Instance.GetCoins(), arg1:  val_17.purchaseModel.LocalPrice);
        if(this.descriptionTxt != null)
        {
            goto label_53;
        }
        
        throw new NullReferenceException();
        label_43:
    }
    public void AnimateCoins(int coinsPurchased)
    {
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  coinsPurchased);
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41963520}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        Player val_4 = App.Player;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, toValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void OnCoinsAnimFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGWaterfallSalePopup()
    {
    
    }
    private void <SetupPopup>b__9_2()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <SetupPopup>b__9_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <SetupPopup>b__9_1(bool success)
    {
        int val_12;
        var val_13;
        System.Func<System.Boolean> val_15;
        var val_16;
        if(success != false)
        {
                MonoSingleton<WGWaterfallSaleManager>.Instance.BuyWaterfallSpecial();
            this.BuyBtn.interactable = false;
            return;
        }
        
        bool[] val_6 = new bool[2];
        val_6[0] = true;
        string[] val_7 = new string[2];
        val_12 = val_7.Length;
        val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_7.Length;
        val_7[1] = "NULL";
        System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
        val_13 = null;
        val_13 = null;
        val_15 = WGWaterfallSalePopup.<>c.<>9__9_3;
        if(val_15 == null)
        {
                System.Func<System.Boolean> val_10 = null;
            val_15 = val_10;
            val_10 = new System.Func<System.Boolean>(object:  WGWaterfallSalePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGWaterfallSalePopup.<>c::<SetupPopup>b__9_3());
            WGWaterfallSalePopup.<>c.<>9__9_3 = val_15;
        }
        
        val_9[0] = val_15;
        val_16 = null;
        val_16 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
