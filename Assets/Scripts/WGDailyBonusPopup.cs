using UnityEngine;
public class WGDailyBonusPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform rewardsParent;
    private UnityEngine.Sprite defaultBoxSp;
    private UnityEngine.Sprite openBoxSp;
    private UnityEngine.UI.Text pickARewardText;
    private UnityEngine.GameObject pickAnotherGroup;
    private UnityEngine.GameObject loadingVideoAnimation;
    private UnityEngine.GameObject watchVideoSprite;
    private UGUINetworkedButton pickAnotherButton;
    private UnityEngine.UI.Button buttonContinue;
    protected UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text timerText;
    protected UnityEngine.GameObject timerGroup;
    private UnityEngine.Color rewardDisabledColor;
    private UnityEngine.UI.Button rewardButton1;
    private UnityEngine.UI.Button rewardButton2;
    private UnityEngine.UI.Button rewardButton3;
    private UnityEngine.UI.Image currentRevealedReward;
    protected UnityEngine.GameObject rewardBtn;
    private System.DateTime lastCollectTime;
    
    // Properties
    private System.TimeSpan currentTimeUntilNextBonus { get; }
    
    // Methods
    private System.TimeSpan get_currentTimeUntilNextBonus()
    {
        GameEcon val_1 = App.getGameEcon;
        System.DateTime val_2 = this.lastCollectTime.AddHours(value:  (double)val_1.dailyBonusHours);
        System.DateTime val_3 = DateTimeCheat.Now;
        return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
    }
    private void Start()
    {
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_170;
    }
    protected virtual void Init_v2()
    {
        UnityEngine.Events.UnityAction val_17;
        UnityEngine.Events.UnityAction val_18;
        MonoSingleton<WGDailyBonusManager>.Instance.AddVideoObserver();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "UpdateDailyBonusUI");
        if((UnityEngine.Object.op_Implicit(exists:  this.closeButton)) != false)
        {
                UnityEngine.Events.UnityAction val_4 = null;
            val_17 = val_4;
            val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGDailyBonusPopup).__il2cppRuntimeField_1F8);
            this.closeButton.m_OnClick.AddListener(call:  val_4);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.buttonContinue)) != false)
        {
                UnityEngine.Events.UnityAction val_6 = null;
            val_17 = val_6;
            val_6 = new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGDailyBonusPopup).__il2cppRuntimeField_1E8);
            this.buttonContinue.m_OnClick.AddListener(call:  val_6);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.pickAnotherButton)) != false)
        {
                System.Action<System.Boolean> val_8 = null;
            val_17 = val_8;
            val_8 = new System.Action<System.Boolean>(object:  this, method:  typeof(WGDailyBonusPopup).__il2cppRuntimeField_1B8);
            System.Delegate val_9 = System.Delegate.Combine(a:  this.pickAnotherButton.OnConnectionClick, b:  val_8);
            if(val_9 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
            this.pickAnotherButton.OnConnectionClick = val_9;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton1)) != false)
        {
                UnityEngine.Events.UnityAction val_11 = null;
            val_17 = val_11;
            val_11 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyBonusPopup::<Init_v2>b__22_0());
            this.rewardButton1.m_OnClick.AddListener(call:  val_11);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton2)) != false)
        {
                UnityEngine.Events.UnityAction val_13 = null;
            val_17 = val_13;
            val_13 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyBonusPopup::<Init_v2>b__22_1());
            this.rewardButton2.m_OnClick.AddListener(call:  val_13);
        }
        
        val_18 = 0;
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton3)) != false)
        {
                UnityEngine.Events.UnityAction val_15 = null;
            val_17 = val_15;
            val_15 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyBonusPopup::<Init_v2>b__22_2());
            val_18 = val_17;
            this.rewardButton3.m_OnClick.AddListener(call:  val_15);
        }
        
        UnityEngine.Coroutine val_16 = this.StartCoroutine(routine:  this);
        return;
        label_22:
    }
    protected virtual System.Collections.IEnumerator CheckState()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyBonusPopup.<CheckState>d__23();
    }
    private void OnEnable()
    {
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_190;
    }
    protected virtual void OnEnable_v2()
    {
        WGDailyBonusManager val_1 = MonoSingleton<WGDailyBonusManager>.Instance;
        val_1.bonusPopup = this.gameObject;
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_1C0;
    }
    protected virtual void OnCoinsAnimFinished_v2()
    {
        WGDailyBonusManager val_1 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_1._bonusUIState == 2)
        {
                WGDailyBonusManager val_2 = MonoSingleton<WGDailyBonusManager>.Instance;
            val_2._bonusUIState = 1;
        }
    
    }
    protected virtual void OnClick_PickAnotherButton(bool result)
    {
        MonoSingleton<WGDailyBonusManager>.Instance.ShowVideo(result:  false);
    }
    protected virtual void UpdateDailyBonusUI()
    {
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        val_18 = this;
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton1)) != false)
        {
                this.rewardButton1.interactable = true;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton2)) != false)
        {
                this.rewardButton2.interactable = true;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton3)) != false)
        {
                this.rewardButton3.interactable = true;
        }
        
        val_19 = 1152921504893161472;
        val_20 = 1152921516539150208;
        System.DateTime val_5 = MonoSingleton<WGDailyBonusManager>.Instance.LastCollectTime;
        this.lastCollectTime = val_5;
        WGDailyBonusManager val_6 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_6._bonusUIState != 4)
        {
            goto label_17;
        }
        
        val_21 = 0;
        this.closeButton.gameObject.SetActive(value:  false);
        label_53:
        if((UnityEngine.Object.op_Implicit(exists:  this.timerGroup)) == false)
        {
            goto label_57;
        }
        
        val_22 = 0;
        goto label_24;
        label_17:
        WGDailyBonusManager val_9 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_9._bonusUIState != 5)
        {
            goto label_28;
        }
        
        goto label_29;
        label_28:
        WGDailyBonusManager val_10 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_10._bonusUIState != 1)
        {
            goto label_33;
        }
        
        label_58:
        label_29:
        val_21 = 0;
        this.closeButton.gameObject.SetActive(value:  false);
        if((UnityEngine.Object.op_Implicit(exists:  this.timerGroup)) == false)
        {
            goto label_57;
        }
        
        val_22 = 1;
        label_24:
        val_21 = 0;
        this.timerGroup.SetActive(value:  true);
        label_57:
        WGDailyBonusManager val_13 = MonoSingleton<WGDailyBonusManager>.Instance;
        val_18 = ???;
        val_20 = ???;
        val_19 = ???;
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_1D0;
        label_33:
        twelvegigs.Autopilot.AutopilotManager val_14 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
        if(val_14.initialized == false)
        {
            goto label_46;
        }
        
        twelvegigs.Autopilot.AutopilotManager val_15 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
        if(val_15.initialized != true)
        {
            goto label_50;
        }
        
        label_46:
        val_18 + 96.gameObject.SetActive(value:  false);
        goto label_53;
        label_50:
        twelvegigs.Autopilot.AutopilotManager val_17 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
        if(val_17.initialized != true)
        {
            goto label_57;
        }
        
        goto label_58;
    }
    protected virtual void UpdateReward(DailyBonusRevealedRewardInfo info)
    {
        UnityEngine.Sprite val_8;
        if(info != null)
        {
                UnityEngine.UI.Image val_2 = this.rewardsParent.GetChild(index:  info.revealedReward).GetComponent<UnityEngine.UI.Image>();
            if(val_2 == 0)
        {
                return;
        }
        
            this.currentRevealedReward = val_2;
            val_2.color = new UnityEngine.Color() {r = this.rewardDisabledColor};
            if((UnityEngine.Object.op_Implicit(exists:  this.openBoxSp)) == false)
        {
                return;
        }
        
            val_8 = this.openBoxSp;
        }
        else
        {
                if(this.currentRevealedReward == 0)
        {
                return;
        }
        
            UnityEngine.Color val_6 = UnityEngine.Color.white;
            this.currentRevealedReward.color = new UnityEngine.Color() {r = val_6.r, g = val_6.g, b = val_6.b, a = val_6.a};
            if((UnityEngine.Object.op_Implicit(exists:  this.defaultBoxSp)) == false)
        {
                return;
        }
        
            val_8 = this.defaultBoxSp;
        }
        
        this.currentRevealedReward.sprite = val_8;
    }
    protected virtual void OnClick_ContinueButton()
    {
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_1F0;
    }
    protected virtual void OnClick_CloseButton()
    {
        MonoSingleton<WGDailyBonusManager>.Instance.ShowPostPopups();
        WGDailyBonusManager val_2 = MonoSingleton<WGDailyBonusManager>.Instance;
        val_2.justCollectedReward = false;
        MonoSingleton<WGDailyBonusManager>.Instance.RemoveVideoObserver();
        this.ClosePopup();
    }
    protected virtual void ShowPickAnotherGroup(bool showPickAnotherButton)
    {
        var val_25;
        UnityEngine.GameObject val_26;
        var val_27;
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton1)) != false)
        {
                this.rewardButton1.interactable = false;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton2)) != false)
        {
                this.rewardButton2.interactable = false;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.rewardButton3)) != false)
        {
                this.rewardButton3.interactable = false;
        }
        
        val_25 = 1152921504893161472;
        WGDailyBonusManager val_4 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_4.revealedRewardInfo == null)
        {
                .revealedReward = UnityEngine.Random.Range(min:  0, max:  this.rewardsParent.childCount);
            WGDailyBonusManager val_8 = MonoSingleton<WGDailyBonusManager>.Instance;
            val_8.revealedRewardInfo = new DailyBonusRevealedRewardInfo();
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.pickARewardText)) != false)
        {
                this.pickARewardText.gameObject.SetActive(value:  false);
        }
        
        val_26 = this.pickAnotherGroup;
        if((UnityEngine.Object.op_Implicit(exists:  val_26)) != false)
        {
                this.pickAnotherGroup.SetActive(value:  true);
        }
        
        if((showPickAnotherButton == false) || ((MonoSingleton<WGDailyBonusManager>.Instance.IsReadyToShowRewardedVideo()) == false))
        {
            goto label_35;
        }
        
        val_26 = 1152921504893161472;
        val_25 = 1152921515825666416;
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) == false)
        {
            goto label_39;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.loadingVideoAnimation)) != false)
        {
                this.loadingVideoAnimation.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.watchVideoSprite)) == false)
        {
            goto label_48;
        }
        
        this.watchVideoSprite.SetActive(value:  true);
        goto label_48;
        label_35:
        UnityEngine.GameObject val_18 = this.pickAnotherButton.gameObject;
        val_27 = 0;
        goto label_51;
        label_39:
        if((UnityEngine.Object.op_Implicit(exists:  this.loadingVideoAnimation)) != false)
        {
                this.loadingVideoAnimation.SetActive(value:  true);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.watchVideoSprite)) != false)
        {
                this.watchVideoSprite.SetActive(value:  false);
        }
        
        this.pickAnotherButton.interactable = false;
        ApplovinMaxPlugin val_21 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_26 = val_21.RewardVideoLoaded;
        val_25 = 1152921504614248448;
        System.Delegate val_23 = System.Delegate.Combine(a:  val_26, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyBonusPopup::OnRewardedVideoLoaded(bool success)));
        if(val_23 != null)
        {
                if(null != null)
        {
            goto label_65;
        }
        
        }
        
        val_21.RewardVideoLoaded = val_23;
        label_48:
        val_27 = 1;
        label_51:
        this.pickAnotherButton.gameObject.SetActive(value:  true);
        return;
        label_65:
    }
    private void OnRewardedVideoLoaded(bool success)
    {
        UnityEngine.GameObject val_8;
        success = success;
        this.pickAnotherButton.interactable = success;
        if((UnityEngine.Object.op_Implicit(exists:  this.loadingVideoAnimation)) != false)
        {
                this.loadingVideoAnimation.SetActive(value:  (~success) & 1);
        }
        
        val_8 = this.watchVideoSprite;
        if((UnityEngine.Object.op_Implicit(exists:  val_8)) != false)
        {
                this.watchVideoSprite.SetActive(value:  success);
        }
        
        if(success == false)
        {
                return;
        }
        
        ApplovinMaxPlugin val_5 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_8 = val_5.RewardVideoLoaded;
        System.Delegate val_7 = System.Delegate.Remove(source:  val_8, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyBonusPopup::OnRewardedVideoLoaded(bool success)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        val_5.RewardVideoLoaded = val_7;
        return;
        label_15:
    }
    protected virtual void ShowFtuxPickGroup()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.pickARewardText)) == false)
        {
                return;
        }
        
        this.pickARewardText.gameObject.SetActive(value:  true);
        string val_3 = Localization.Localize(key:  "daily_reward_unlocked_excl_upper", defaultValue:  "DAILY REWARD UNLOCKED!\n\nTAP A BOX TO CLAIM\nYOUR PRIZE!", useSingularKey:  false);
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected virtual void ShowFtuxRewardGroup()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.pickARewardText)) == false)
        {
                return;
        }
        
        this.pickARewardText.gameObject.SetActive(value:  true);
        string val_3 = Localization.Localize(key:  "return_to_claim_next_reward_upper", defaultValue:  "RETURN TOMORROW TO\nCLAIM YOUR NEXT REWARD!", useSingularKey:  false);
        this.buttonContinue.gameObject.SetActive(value:  true);
    }
    protected virtual void HidePickAnotherGroup()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.pickAnotherGroup)) == false)
        {
                return;
        }
        
        this.pickAnotherGroup.SetActive(value:  false);
    }
    protected virtual void ShowPickRewardText()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.pickARewardText)) == false)
        {
                return;
        }
        
        this.pickARewardText.gameObject.SetActive(value:  true);
        string val_4 = System.String.Format(format:  "{0}{1}{2}", arg0:  "<size=80>", arg1:  Localization.Localize(key:  "pick_a_reward_upper", defaultValue:  "PICK A REWARD!", useSingularKey:  false), arg2:  "</size>");
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void ClosePopup()
    {
        ApplovinMaxPlugin val_1 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.RewardVideoLoaded, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyBonusPopup::OnRewardedVideoLoaded(bool success)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.RewardVideoLoaded = val_3;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_5:
    }
    public virtual void OnRewardButtonClick(UnityEngine.GameObject reward)
    {
        var val_17;
        var val_18;
        System.Action val_20;
        this.rewardBtn = reward;
        WGDailyBonusManager val_1 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_1.revealedRewardInfo != null)
        {
                return;
        }
        
        WGDailyBonusManager val_2 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_2._bonusUIState != 4)
        {
                WGDailyBonusManager val_3 = MonoSingleton<WGDailyBonusManager>.Instance;
            if(val_3._bonusUIState != 0)
        {
                WGDailyBonusManager val_4 = MonoSingleton<WGDailyBonusManager>.Instance;
            if(val_4._bonusUIState != 2)
        {
                return;
        }
        
        }
        
        }
        
        .revealedReward = this.rewardBtn.transform.GetSiblingIndex();
        WGDailyBonusManager val_8 = MonoSingleton<WGDailyBonusManager>.Instance;
        val_8.revealedRewardInfo = new DailyBonusRevealedRewardInfo();
        GameBehavior val_9 = App.getBehavior;
        WGDailyBonusManager val_11 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_11._bonusUIState != 4)
        {
            goto label_28;
        }
        
        val_17 = 2;
        if((val_9.<metaGameBehavior>k__BackingField) != null)
        {
            goto label_29;
        }
        
        label_28:
        WGDailyBonusManager val_12 = MonoSingleton<WGDailyBonusManager>.Instance;
        label_29:
        val_9.<metaGameBehavior>k__BackingField.Setup(rewardSource:  (val_12._bonusUIState == 2) ? 1 : 0);
        SLCWindow val_14 = val_9.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_18 = null;
        val_18 = null;
        val_20 = WGDailyBonusPopup.<>c.<>9__39_0;
        if(val_20 == null)
        {
                System.Action val_15 = null;
            val_20 = val_15;
            val_15 = new System.Action(object:  WGDailyBonusPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGDailyBonusPopup.<>c::<OnRewardButtonClick>b__39_0());
            WGDailyBonusPopup.<>c.<>9__39_0 = val_20;
        }
        
        val_14.Action_OnClose = val_20;
        WGAudioController val_16 = MonoSingleton<WGAudioController>.Instance;
        val_16.sound.PlayGameSpecificSound(id:  "SelectGift", clipIndex:  0);
        this.ClosePopup();
    }
    public WGDailyBonusPopup()
    {
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0.5f);
        this.rewardDisabledColor = val_1.r;
    }
    private void <Init_v2>b__22_0()
    {
        UnityEngine.GameObject val_1 = this.rewardButton1.gameObject;
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_250;
    }
    private void <Init_v2>b__22_1()
    {
        UnityEngine.GameObject val_1 = this.rewardButton2.gameObject;
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_250;
    }
    private void <Init_v2>b__22_2()
    {
        UnityEngine.GameObject val_1 = this.rewardButton3.gameObject;
        goto typeof(WGDailyBonusPopup).__il2cppRuntimeField_250;
    }

}
