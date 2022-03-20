using UnityEngine;
public class WGLightningLevelsPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Text description;
    protected UnityEngine.UI.Slider progressBar;
    protected UnityEngine.UI.Text progressText;
    protected UnityEngine.UI.Button playButton;
    protected UnityEngine.UI.Button continueButton;
    protected UGUINetworkedButton collectButton;
    protected UnityEngine.UI.Button closeButton;
    protected GridCoinCollectAnimationInstantiator coinAnim;
    protected UnityEngine.GameObject timerGroup;
    protected UnityEngine.UI.Text eventEndsText;
    protected UnityEngine.UI.Text timer;
    protected UnityEngine.GameObject rewardCoinObject;
    protected UnityEngine.UI.Text reward;
    protected UnityEngine.GameObject rewardBonusGameObject;
    protected UnityEngine.UI.Text rewardBonusGameLabel;
    protected UnityEngine.UI.Image rewardBonusGameIcon;
    protected UnityEngine.Sprite bonusIconWheel;
    protected UnityEngine.Sprite bonusIconSlots;
    private UnityEngine.UI.Text playButtonText;
    protected float progress;
    
    // Methods
    protected virtual void Awake()
    {
        this.playButton.gameObject.SetActive(value:  false);
        this.collectButton.gameObject.SetActive(value:  false);
        this.timerGroup.SetActive(value:  false);
        this.coinAnim.gameObject.SetActive(value:  false);
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningLevelsPopup::OnClick_PlayButton()));
        if((UnityEngine.Object.op_Implicit(exists:  this.continueButton)) != false)
        {
                this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningLevelsPopup::OnClick_PlayButton()));
        }
        
        System.Delegate val_8 = System.Delegate.Combine(a:  this.collectButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGLightningLevelsPopup::OnClick_CollectButton(bool connected)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
        this.collectButton.OnConnectionClick = val_8;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGLightningLevelsPopup).__il2cppRuntimeField_258));
        System.Delegate val_11 = System.Delegate.Combine(a:  this.coinAnim.OnCompleteCallback, b:  new System.Action(object:  this, method:  System.Void WGLightningLevelsPopup::OnCoinAminFinished()));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
        this.coinAnim.OnCompleteCallback = val_11;
        if(this.playButtonText == 0)
        {
                UnityEngine.Debug.LogError(message:  "Play button text not set on Lightning Levels Popup");
            return;
        }
        
        string val_15 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        return;
        label_22:
    }
    protected virtual void OnEnable()
    {
        this.progress = ;
        this.ShowProgress();
        this.UpdateRewardInfo();
        if(this.progress < 0)
        {
                this.ShowEventIncompleteUI();
            return;
        }
        
        this.ShowEventCompletedUI();
    }
    protected void OnCoinAminFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected void OnClick_PlayButton()
    {
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_3;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance;
        if((41963520 == 0) || ((MonoSingleton<WGWindowManager>.Instance.GetComponentInChildren<WGLevelClearPopup>()) == 0))
        {
            goto label_18;
        }
        
        goto label_18;
        label_3:
        GameBehavior val_7 = App.getBehavior;
        label_18:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected void ShowProgress()
    {
        goto typeof(UnityEngine.UI.Slider).__il2cppRuntimeField_420;
    }
    protected void ShowEventIncompleteUI()
    {
        var val_12;
        var val_13;
        string val_1 = System.String.Format(format:  "{0}:", arg0:  this);
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this.timer);
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGLightningLevelsPopup::UpdateEventTimer()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        val_2.updateLogic = val_4;
        val_12 = this.playButton.gameObject;
        if(this.continueButton != 0)
        {
                GameBehavior val_7 = App.getBehavior;
            val_12.SetActive(value:  ((val_7.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
            val_12 = this.continueButton.gameObject;
            GameBehavior val_10 = App.getBehavior;
            var val_11 = ((val_10.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0;
        }
        else
        {
                val_13 = 1;
        }
        
        val_12.SetActive(value:  true);
        this.timerGroup.SetActive(value:  true);
        return;
        label_4:
    }
    protected void ShowEventCompletedUI()
    {
        this.collectButton.gameObject.SetActive(value:  true);
        this.closeButton.gameObject.SetActive(value:  false);
    }
    protected void UpdateEventTimer()
    {
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected void UpdateRewardInfo()
    {
        UnityEngine.UI.Text val_4;
        if(this == 4)
        {
            goto label_1;
        }
        
        if(this == 3)
        {
            goto label_2;
        }
        
        if(this != 1)
        {
            goto label_16;
        }
        
        this.rewardCoinObject.SetActive(value:  true);
        this.rewardBonusGameObject.SetActive(value:  false);
        string val_1 = 0.ToString();
        if(this.progress >= 0)
        {
                return;
        }
        
        return;
        label_1:
        string val_2 = Localization.Localize(key:  "bonus_spin_upper", defaultValue:  "BONUS SPIN", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconSlots;
        if(this.progress >= 0)
        {
            goto label_16;
        }
        
        val_4 = this.description;
        goto label_13;
        label_2:
        string val_3 = Localization.Localize(key:  "bonus_wheel_upper", defaultValue:  "BONUS WHEEL", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconWheel;
        if(this.progress >= 0)
        {
            goto label_16;
        }
        
        val_4 = this.description;
        label_13:
        label_16:
        this.rewardCoinObject.SetActive(value:  false);
        this.rewardBonusGameObject.SetActive(value:  true);
    }
    protected void OnClick_CollectButton(bool connected)
    {
        this.collectButton.interactable = false;
        if(connected == false)
        {
            goto label_2;
        }
        
        if(this == 4)
        {
            goto label_3;
        }
        
        if(this == 3)
        {
            goto label_4;
        }
        
        if(this != 1)
        {
                return;
        }
        
        this.coinAnim.gameObject.SetActive(value:  true);
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  268435458);
        val_2.AddCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  this, subSource:  0, externalParams:  0, doTrack:  true);
        Player val_4 = App.Player;
        decimal val_5 = System.Decimal.op_Implicit(value:  268435458);
        decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits, lo = val_2, mid = val_2}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        Player val_7 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return;
        label_2:
        label_25:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_4:
        WGWindowManager val_10 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BonusGameWheelPopup>(showNext:  true);
        mem2[0] = this;
        mem2[0] = new System.Action(object:  this, method:  typeof(WGLightningLevelsPopup).__il2cppRuntimeField_228);
        goto label_25;
        label_3:
        WGWindowManager val_13 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BonusGameSlotMachinePopup>(showNext:  true);
        mem2[0] = this;
        val_13.waitingForGeneration = new System.Action(object:  this, method:  typeof(WGLightningLevelsPopup).__il2cppRuntimeField_228);
        goto label_25;
    }
    protected virtual string GetEventRemainingTime()
    {
        return LightningLevelsEventHandler.<Instance>k__BackingField.GetEventRemainingTime();
    }
    protected virtual string GetEventEndsText()
    {
        null = null;
        return Localization.Localize(key:  "lightning_levels_ends_upper", defaultValue:  (App.game == 18) ? "EVENT ENDS IN" : "LIGHTNING LEVELS ENDS", useSingularKey:  false);
    }
    protected virtual System.Collections.Generic.KeyValuePair<GameEventRewardType, int> GetRewardInfo()
    {
        System.Collections.Generic.KeyValuePair<GameEventRewardType, System.Int32> val_1 = new System.Collections.Generic.KeyValuePair<GameEventRewardType, System.Int32>(key:  typeof(LightningLevelsEcon).__il2cppRuntimeField_14, value:  -1488238000);
        return (System.Collections.Generic.KeyValuePair<GameEventRewardType, System.Int32>)val_1.Value;
    }
    protected virtual string GetCoinRewardDescription()
    {
        return Localization.Localize(key:  "lightning_levels_coin_description", defaultValue:  "Lightning Levels appear randomly during gameplay. Complete the levels before time expires to earn a reward!", useSingularKey:  false);
    }
    protected virtual string GetBonusSlotsRewardDescription()
    {
        return Localization.Localize(key:  "lightning_levels_bonus_slots_description", defaultValue:  "Lightning Levels appear randomly during gameplay. Complete the levels before time expires for a chance to earn up to 900 Coins and Golden Apples on the Bonus Spinner!", useSingularKey:  false);
    }
    protected virtual string GetBonusWheelRewardDescription()
    {
        return (string)System.String.Format(format:  Localization.Localize(key:  "lightning_levels_bonus_wheel_description", defaultValue:  "Lightning Levels appear randomly during gameplay. Complete the levels before time expires for a chance to earn up to {0} Coins or {1} Golden Apples on the Bonus Wheel!", useSingularKey:  false), arg0:  App.getGameEcon.maxBonusGameWheelAwardCoins, arg1:  App.getGameEcon.maxBonusGameWheelAwardGoldenCurrency);
    }
    protected virtual string GetCongratsDescription()
    {
        return (string)System.String.Format(format:  Localization.Localize(key:  "lightning_levels_congrats", defaultValue:  "Congratulations! You identified {0} Lightning Levels!", useSingularKey:  false), arg0:  LightningLevelsEcon.__il2cppRuntimeField_namespaze);
    }
    protected virtual string GetEventProgressText()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_810;
    }
    protected virtual float GetEventProgressValue()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_820;
    }
    protected virtual void MarkEventRewarded()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_570;
    }
    protected virtual string GetTrackRewardSource()
    {
        return "Lightning Levels Event Reward";
    }
    protected virtual void ShowInternetRequiredPopup()
    {
        LightningLevelsEventHandler.<Instance>k__BackingField.ShowInternetRequiredPopup();
    }
    protected virtual void OnClick_CloseButton()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        LightningLevelsEventHandler.<Instance>k__BackingField.OnMyEventPopupClosed();
    }
    public WGLightningLevelsPopup()
    {
    
    }

}
