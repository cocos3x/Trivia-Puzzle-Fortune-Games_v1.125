using UnityEngine;
public class WGRewardedVideoPopup : WGFreeHintPopup
{
    // Fields
    private GemsCollectAnimationInstantiator myCollect;
    private UnityEngine.Sprite freeCoinSprite;
    private UnityEngine.Sprite freeGemSprite;
    private UnityEngine.Sprite collectGemIcon;
    private UnityEngine.Sprite collectCoinIcon;
    private UnityEngine.UI.Image freeCurrencyImage;
    private UnityEngine.UI.Image collectCurrencyImage;
    private UnityEngine.UI.Text bannerText;
    private UnityEngine.GameObject lowGemPopup;
    private UnityEngine.GameObject regularPromptPopup;
    private UnityEngine.UI.Text lowGemText;
    private UGUINetworkedButton lowGemWatchButton;
    private UnityEngine.UI.Button lowGemCloseButton;
    private bool isLowGems;
    
    // Methods
    public void InitAsLowGems(bool lowGems)
    {
        this.isLowGems = lowGems;
        mem[1152921517950712048] = 1;
        goto typeof(WGRewardedVideoPopup).__il2cppRuntimeField_190;
    }
    protected override void SetUp()
    {
        var val_39;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        string val_45;
        var val_46;
        string val_47;
        36496.SetActive(value:  true);
        36496.SetActive(value:  false);
        36496.SetActive(value:  false);
        this.lowGemPopup.SetActive(value:  false);
        this.regularPromptPopup.SetActive(value:  false);
        if(true == 0)
        {
            goto label_6;
        }
        
        if(this.isLowGems == false)
        {
            goto label_7;
        }
        
        this.regularPromptPopup.SetActive(value:  false);
        this.lowGemWatchButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeHintPopup::OnFreeHintClick(bool result));
        this.lowGemWatchButton.interactable = true;
        this.lowGemPopup.SetActive(value:  true);
        this.lowGemCloseButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_2 = null;
        val_39 = 0;
        val_2 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRewardedVideoPopup::<SetUp>b__15_0());
        this.lowGemCloseButton.m_OnClick.AddListener(call:  val_2);
        mem[1152921517951059504] = 36;
        goto label_16;
        label_6:
        this.SetUp();
        System.Action<System.Boolean> val_3 = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeHintPopup::OnFreeHintClick(bool result));
        mem2[0] = val_3;
        val_3.interactable = true;
        val_3.SetActive(value:  true);
        this.regularPromptPopup.SetActive(value:  true);
        this.freeCurrencyImage.sprite = this.freeCoinSprite;
        this.collectCurrencyImage.sprite = this.collectCoinIcon;
        string val_4 = Localization.Localize(key:  "earn_free_coins_upper", defaultValue:  "EARN FREE COINS", useSingularKey:  false);
        string val_5 = Localization.Localize(key:  "get_free_coins_upper", defaultValue:  "GET FREE COINS", useSingularKey:  false);
        bool val_6 = UnityEngine.Object.op_Inequality(x:  this.bannerText, y:  0);
        if(val_6 == false)
        {
                return;
        }
        
        UnityEngine.GameObject val_7 = val_6.gameObject;
        val_41 = 1;
        goto label_30;
        label_7:
        System.Action<System.Boolean> val_8 = null;
        val_39 = public System.Void System.Action<System.Boolean>::.ctor(object object, IntPtr method);
        val_8 = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeHintPopup::OnFreeHintClick(bool result));
        mem2[0] = val_8;
        val_8.interactable = true;
        val_8.SetActive(value:  true);
        this.regularPromptPopup.SetActive(value:  true);
        label_16:
        this.regularPromptPopup.SetActive(value:  false);
        this.regularPromptPopup.SetActive(value:  false);
        this.regularPromptPopup.canvasRenderer.SetAlpha(alpha:  1f);
        GameBehavior val_10 = App.getBehavior;
        val_42 = 1152921504617017344;
        decimal val_11 = System.Decimal.op_Implicit(value:  val_10.<metaGameBehavior>k__BackingField);
        mem[1152921517951059472] = val_11.flags;
        mem[1152921517951059476] = val_11.hi;
        mem[1152921517951059480] = val_11.lo;
        mem[1152921517951059484] = val_11.mid;
        bool val_12 = UnityEngine.Object.op_Inequality(x:  val_10.<metaGameBehavior>k__BackingField, y:  0);
        if(val_12 != false)
        {
                val_12.enabled = false;
        }
        
        if(X21 == 0)
        {
            goto label_55;
        }
        
        val_43 = null;
        val_43 = null;
        if(WGFreeHintPopup.dailyCollected == false)
        {
            goto label_55;
        }
        
        mem[1152921517951059508] = 18;
        val_44 = null;
        val_44 = null;
        decimal val_14;
        mem[1152921517951059520] = Events.AD_SEEN_REW_VID_DB;
        val_14 = new System.Decimal(value:  2);
        decimal val_15 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = 1152921504883736576, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_14.flags, hi = val_14.flags, lo = val_14.lo, mid = val_14.lo});
        mem[1152921517951059472] = val_15.flags;
        mem[1152921517951059476] = val_15.hi;
        mem[1152921517951059480] = val_15.lo;
        mem[1152921517951059484] = val_15.mid;
        GameEcon val_16 = App.getGameEcon;
        GameEcon val_18 = App.getGameEcon;
        string val_21 = Localization.Localize(key:  "free_gems_exclamation", defaultValue:  "Watch a quick video to receive {0} FREE GEMS!", useSingularKey:  false);
        val_45 = val_21;
        if((val_21.Contains(value:  "15")) != false)
        {
                val_45 = val_45.Replace(oldValue:  "15", newValue:  "{0}");
        }
        
        string val_24 = System.String.Format(format:  val_45, arg0:  System.String.Format(format:  "{0} {1}", arg0:  1152921504883736576.ToString(format:  val_16.numberFormatInt), arg1:  mem[1152921517951059472].ToString(format:  val_18.numberFormatInt)));
        GameEcon val_25 = App.getGameEcon;
        this.SetStrikeOutLinePos(textToStrike:  1152921504883736576.ToString(format:  val_25.numberFormatInt));
        this.enabled = true;
        val_46 = null;
        val_46 = null;
        WGFreeHintPopup.dailyCollected = false;
        goto label_73;
        label_55:
        mem[1152921517951059508] = UnityEngine.Object.__il2cppRuntimeField_cctor_finished;
        mem[1152921517951059520] = System.Decimal.__il2cppRuntimeField_cctor_finished;
        string val_27 = Localization.Localize(key:  "free_gems_exclamation", defaultValue:  "Watch a quick video to receive {0} FREE GEMS!", useSingularKey:  false);
        val_47 = val_27;
        if((val_27.Contains(value:  "15")) != false)
        {
                val_47 = val_47.Replace(oldValue:  "15", newValue:  "{0}");
        }
        
        GameEcon val_30 = App.getGameEcon;
        string val_32 = System.String.Format(format:  val_47, arg0:  mem[1152921517951059472].ToString(format:  val_30.numberFormatInt));
        label_73:
        GameEcon val_33 = App.getGameEcon;
        string val_34 = mem[1152921517951059472].ToString(format:  val_33.numberFormatInt);
        this.freeCurrencyImage.sprite = this.freeGemSprite;
        this.collectCurrencyImage.sprite = this.collectGemIcon;
        string val_35 = Localization.Localize(key:  "earn_free_gems_upper", defaultValue:  "EARN FREE GEMS", useSingularKey:  false);
        string val_36 = Localization.Localize(key:  "get_free_gems_upper", defaultValue:  "GET FREE GEMS", useSingularKey:  false);
        bool val_37 = UnityEngine.Object.op_Inequality(x:  this.bannerText, y:  0);
        if(val_37 == false)
        {
                return;
        }
        
        val_41 = 0;
        label_30:
        val_37.gameObject.SetActive(value:  false);
    }
    protected override void UpdateLogic()
    {
        object val_23;
        var val_24;
        if(true == 1)
        {
                val_23 = 1152921504893161472;
        }
        
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) == false)
        {
                return;
        }
        
        val_23 = 1152921513404906384;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) != false)
        {
                System.DateTime val_8 = MonoSingletonSelfGenerating<AdsManager>.Instance.offsetServerTime;
            val_23 = 60 - val_8.dateData.Minute.ToString(format:  "00");
            string val_19 = System.String.Format(format:  "{1} {0}", arg0:  System.String.Format(format:  "{0}:{1}:{2}", arg0:  23 - val_8.dateData.Hour.ToString(format:  "00"), arg1:  val_23, arg2:  60 - val_8.dateData.Second.ToString(format:  "00")), arg1:  "Ad Available in");
            val_24 = 0;
        }
        else
        {
                string val_22 = Localization.Localize(key:  ((MonoSingletonSelfGenerating<T>.__il2cppRuntimeField_cctor_finished) == 0) ? "get_free_coins_upper" : "get_free_gems_upper", defaultValue:  ((MonoSingletonSelfGenerating<T>.__il2cppRuntimeField_cctor_finished) == 0) ? "GET FREE COINS" : "GET FREE GEMS", useSingularKey:  false);
            val_24 = 1;
        }
        
        interactable = true;
    }
    public override void OnVideoResponse(Notification notif)
    {
        this.lowGemPopup.SetActive(value:  false);
        this.OnVideoResponse(notif:  notif);
    }
    public override void OnCollectClicked()
    {
        string val_17;
        if(true == 0)
        {
            goto label_1;
        }
        
        if(this.isLowGems != false)
        {
                this.isLowGems = false;
        }
        
        36495.interactable = false;
        mem2[0] = new System.Action(object:  this, method:  typeof(WGRewardedVideoPopup).__il2cppRuntimeField_198);
        string val_2 = ToString();
        mem[1152921517951784848] = null;
        App.Player.AddGems(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = X23, hi = X23, lo = 460035984, mid = 268435459}), source:  val_2, subsource:  0);
        val_17 = 0;
        if((MonoSingleton<TRVMainController>.Instance) != 0)
        {
                TRVMainController val_7 = MonoSingleton<TRVMainController>.Instance;
            if(val_7.currentGame != null)
        {
                TRVMainController val_8 = MonoSingleton<TRVMainController>.Instance;
        }
        
            val_17 = 0;
        }
        
        App.Player.TrackNonCoinReward(source:  val_2, subSource:  val_17, rewardType:  "Gems", rewardAmount:  ToString(), additionalParams:  0);
        if(val_2 == 0)
        {
            goto label_31;
        }
        
        Player val_12 = App.Player;
        Player val_14 = App.Player;
        decimal val_15 = System.Decimal.op_Implicit(value:  val_14._gems);
        this.myCollect.Play(fromValue:  val_12._gems - (System.Decimal.op_Explicit(value:  new System.Decimal() {lo = 460035680, mid = 268435459})), toValue:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return;
        label_1:
        this.OnCollectClicked();
        return;
        label_31:
        this.Close(dontDestroyMonolith:  false);
    }
    protected override void CloseSorry()
    {
        goto typeof(WGRewardedVideoPopup).__il2cppRuntimeField_190;
    }
    public override void OnDisable()
    {
        this.OnDisable();
        this.isLowGems = false;
    }
    public WGRewardedVideoPopup()
    {
    
    }
    private void <SetUp>b__15_0()
    {
        this.Close(dontDestroyMonolith:  false);
    }

}
