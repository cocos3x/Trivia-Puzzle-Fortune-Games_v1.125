using UnityEngine;
public class SuperBundleEventPopup : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<UnityEngine.UI.Text> coinTexts;
    private System.Collections.Generic.List<UnityEngine.UI.Text> appleTexts;
    private UnityEngine.UI.Text percentageFreeText;
    private UnityEngine.UI.Text valueText;
    private UnityEngine.UI.Text openButtonText;
    private UnityEngine.UI.Text timerText;
    private UGUINetworkedButton openButton;
    private UnityEngine.UI.Button closeButton;
    private GridCoinCollectAnimationInstantiator coinAnimation;
    private GoldenCurrencyCollectAnimationInstantiator goldAnimation;
    private GemsCollectAnimationInstantiator gemAnimation;
    private decimal coinRewardAmount;
    private int appleRewardAmount;
    private System.DateTime dealEndTime;
    
    // Methods
    private void OnEnable()
    {
        var val_6;
        this.SetRewardAmounts();
        val_6 = null;
        val_6 = null;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.dealEndTime}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.UpdateTimer());
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.closeButton)) != false)
        {
                this.closeButton.m_OnClick.RemoveAllListeners();
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SuperBundleEventPopup::Close()));
        }
        
        this.SetupReady();
    }
    private void SetupReady()
    {
        string val_1 = System.String.Format(format:  "{0}%", arg0:  SuperBundleEventHandler._Instance.discount);
        string val_4 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "open_upper", defaultValue:  "OPEN", useSingularKey:  false), arg1:  LocalPrice);
        System.DateTime val_5 = SuperBundleEventHandler._Instance.GetBundleExpireTime;
        this.dealEndTime = val_5;
        System.Delegate val_7 = System.Delegate.Combine(a:  this.openButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SuperBundleEventPopup::OnOpenButtonClick(bool result)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        this.openButton.OnConnectionClick = val_7;
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.UpdateTimer());
        return;
        label_15:
    }
    private void OnOpenButtonClick(bool result)
    {
        int val_14;
        var val_15;
        System.Func<System.Boolean> val_17;
        var val_18;
        if(result != false)
        {
                this.openButton.interactable = false;
            this.closeButton.gameObject.SetActive(value:  false);
            System.Delegate val_3 = System.Delegate.Combine(a:  SuperBundleEventHandler._Instance.OnPurchaseAttemptResult, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SuperBundleEventPopup::OnPurchaseAttemptResult(bool result)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
            SuperBundleEventHandler._Instance.OnPurchaseAttemptResult = val_3;
            SuperBundleEventHandler._Instance.TryPurchase();
            return;
        }
        
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_14 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_14 = val_9.Length;
        val_9[1] = "NULL";
        System.Func<System.Boolean>[] val_11 = new System.Func<System.Boolean>[2];
        val_15 = null;
        val_15 = null;
        val_17 = SuperBundleEventPopup.<>c.<>9__16_0;
        if(val_17 == null)
        {
                System.Func<System.Boolean> val_12 = null;
            val_17 = val_12;
            val_12 = new System.Func<System.Boolean>(object:  SuperBundleEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SuperBundleEventPopup.<>c::<OnOpenButtonClick>b__16_0());
            SuperBundleEventPopup.<>c.<>9__16_0 = val_17;
        }
        
        val_11[0] = val_17;
        val_18 = null;
        val_18 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  val_11, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_8:
    }
    private void OnPurchaseAttemptResult(bool result)
    {
        SuperBundleEventHandler val_29;
        int val_30;
        var val_31;
        System.Func<System.Boolean> val_33;
        var val_34;
        val_29 = SuperBundleEventHandler._Instance;
        System.Delegate val_2 = System.Delegate.Remove(source:  SuperBundleEventHandler._Instance.OnPurchaseAttemptResult, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void SuperBundleEventPopup::OnPurchaseAttemptResult(bool result)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        SuperBundleEventHandler._Instance.OnPurchaseAttemptResult = val_2;
        if(result == false)
        {
            goto label_5;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_10;
        }
        
        mem2[0] = new System.Action(object:  this, method:  System.Void SuperBundleEventPopup::OnCollectAnimationComplete());
        Player val_5 = App.Player;
        decimal val_6 = System.Decimal.op_Implicit(value:  val_5._gems);
        decimal val_7 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, d2:  new System.Decimal() {flags = this.coinRewardAmount, hi = this.coinRewardAmount});
        Player val_9 = App.Player;
        decimal val_10 = System.Decimal.op_Implicit(value:  val_9._gems);
        this.gemAnimation.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}), toValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
        goto label_19;
        label_5:
        GameBehavior val_11 = App.getBehavior;
        bool[] val_15 = new bool[2];
        val_15[0] = true;
        string[] val_16 = new string[2];
        val_30 = val_16.Length;
        val_16[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_30 = val_16.Length;
        val_16[1] = "NO";
        System.Func<System.Boolean>[] val_18 = new System.Func<System.Boolean>[2];
        val_31 = null;
        val_31 = null;
        val_33 = SuperBundleEventPopup.<>c.<>9__17_0;
        if(val_33 == null)
        {
                System.Func<System.Boolean> val_19 = null;
            val_33 = val_19;
            val_19 = new System.Func<System.Boolean>(object:  SuperBundleEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SuperBundleEventPopup.<>c::<OnPurchaseAttemptResult>b__17_0());
            SuperBundleEventPopup.<>c.<>9__17_0 = val_33;
        }
        
        val_18[0] = val_33;
        val_34 = null;
        val_34 = null;
        val_11.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_15, buttonTexts:  val_16, showClose:  false, buttonCallbacks:  val_18, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_10:
        this.coinAnimation.OnCompleteCallback = new System.Action(object:  this, method:  System.Void SuperBundleEventPopup::OnCollectAnimationComplete());
        Player val_22 = App.Player;
        decimal val_23 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_22._credits, hi = val_22._credits, lo = val_29, mid = val_29}, d2:  new System.Decimal() {flags = this.coinRewardAmount, hi = this.coinRewardAmount, lo = this.coinAnimation, mid = this.coinAnimation});
        Player val_24 = App.Player;
        this.coinAnimation.Play(fromValue:  new System.Decimal() {flags = val_23.flags, hi = val_23.hi, lo = val_23.lo, mid = val_23.mid}, toValue:  new System.Decimal() {flags = val_24._credits, hi = val_24._credits}, textTickTime:  -1f, delayBeforeComplete:  1.5f);
        label_19:
        Player val_25 = App.Player;
        Player val_26 = App.Player;
        decimal val_27 = System.Decimal.op_Implicit(value:  val_26._stars);
        this.goldAnimation.Play(fromValue:  val_25._stars - this.appleRewardAmount, toValue:  new System.Decimal() {flags = val_27.flags, hi = val_27.hi, lo = val_27.lo, mid = val_27.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
        return;
        label_4:
    }
    private void OnCollectAnimationComplete()
    {
        this.Close();
    }
    private void SetRewardAmounts()
    {
        System.Collections.Generic.List<UnityEngine.UI.Text> val_4;
        decimal val_1 = System.Decimal.op_Implicit(value:  SuperBundleEventHandler._Instance.coinReward);
        this.coinRewardAmount = val_1;
        mem[1152921516751621624] = val_1.lo;
        mem[1152921516751621628] = val_1.mid;
        int val_4 = SuperBundleEventHandler._Instance.goldReward;
        this.appleRewardAmount = val_4;
        var val_5 = 0;
        label_11:
        if(val_5 >= val_4)
        {
            goto label_8;
        }
        
        if(val_4 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + 0;
        string val_2 = this.coinRewardAmount.ToString();
        val_5 = val_5 + 1;
        if(this.coinTexts != null)
        {
            goto label_11;
        }
        
        label_8:
        val_4 = this.appleTexts;
        var val_6 = 0;
        do
        {
            if(val_6 >= val_4)
        {
                return;
        }
        
            if(val_4 <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_4 = val_4 + 0;
            string val_3 = this.appleRewardAmount.ToString();
            val_4 = this.appleTexts;
            val_6 = val_6 + 1;
        }
        while(val_4 != null);
        
        throw new NullReferenceException();
    }
    private void StartTimer()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateTimer());
    }
    private System.Collections.IEnumerator UpdateTimer()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new SuperBundleEventPopup.<UpdateTimer>d__21();
    }
    private string GetDateString()
    {
        var val_19;
        var val_20;
        System.Object[] val_21;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.dealEndTime}, d2:  new System.DateTime() {dateData = val_1.dateData});
        val_19 = null;
        val_19 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_2._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_20 = null;
            val_20 = null;
        }
        
        if(System.TimeSpan.Zero.Days >= 1)
        {
                object[] val_5 = new object[4];
            val_21 = val_5;
            val_21[0] = System.TimeSpan.Zero.Days;
            val_21[1] = System.TimeSpan.Zero.Hours;
            val_21[2] = System.TimeSpan.Zero.Minutes;
            val_21[3] = System.TimeSpan.Zero.Seconds;
            string val_10 = System.String.Format(format:  "{0:00}:{1:00}:{2:00}:{3:00}", args:  val_5);
            return (string)System.String.Format(format:  "{0:00}:{1:00}", arg0:  int val_16 = System.TimeSpan.Zero.Minutes, arg1:  System.TimeSpan.Zero.Seconds);
        }
        
        if(System.TimeSpan.Zero.Hours >= 1)
        {
                int val_12 = System.TimeSpan.Zero.Hours;
            val_21 = val_12;
            string val_15 = System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_12, arg1:  System.TimeSpan.Zero.Minutes, arg2:  System.TimeSpan.Zero.Seconds);
            return (string)System.String.Format(format:  "{0:00}:{1:00}", arg0:  val_16, arg1:  System.TimeSpan.Zero.Seconds);
        }
        
        val_21 = val_16;
        return (string)System.String.Format(format:  "{0:00}:{1:00}", arg0:  val_16, arg1:  System.TimeSpan.Zero.Seconds);
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public SuperBundleEventPopup()
    {
        this.coinTexts = new System.Collections.Generic.List<UnityEngine.UI.Text>();
        this.appleTexts = new System.Collections.Generic.List<UnityEngine.UI.Text>();
    }

}
