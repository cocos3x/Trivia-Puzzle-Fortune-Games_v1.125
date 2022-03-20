using UnityEngine;
public class WGLightningWordsPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text descriptionText;
    private UnityEngine.UI.Slider progressBar;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Button levelButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Text levelButtonText;
    private UnityEngine.GameObject timerGroup;
    private UnityEngine.UI.Text lightningWordsEndsText;
    private UnityEngine.UI.Text timerText;
    private UGUINetworkedButton collectButton;
    private UnityEngine.UI.Button closeButton;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private UnityEngine.GameObject rewardCoinObject;
    private UnityEngine.UI.Text reward;
    private UnityEngine.GameObject rewardBonusGameObject;
    private UnityEngine.UI.Text rewardBonusGameLabel;
    private UnityEngine.UI.Image rewardBonusGameIcon;
    private UnityEngine.Sprite bonusIconWheel;
    private UnityEngine.Sprite bonusIconSlots;
    private UnityEngine.ParticleSystem victorySystem;
    private float progress;
    
    // Methods
    private void Awake()
    {
        this.levelButton.gameObject.SetActive(value:  false);
        this.collectButton.gameObject.SetActive(value:  false);
        this.timerGroup.SetActive(value:  false);
        this.coinAnim.gameObject.SetActive(value:  false);
        this.levelButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningWordsPopup::OnClick_LevelButton()));
        if(this.continueButton != 0)
        {
                this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningWordsPopup::OnClick_LevelButton()));
        }
        
        System.Delegate val_8 = System.Delegate.Combine(a:  this.collectButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGLightningWordsPopup::OnClick_CollectButton(bool connected)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
        this.collectButton.OnConnectionClick = val_8;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningWordsPopup::OnClick_CloseButton()));
        System.Delegate val_11 = System.Delegate.Combine(a:  this.coinAnim.OnCompleteCallback, b:  new System.Action(object:  this, method:  System.Void WGLightningWordsPopup::OnCoinAminFinished()));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
        this.coinAnim.OnCompleteCallback = val_11;
        if(this.victorySystem == 0)
        {
                return;
        }
        
        this.victorySystem.gameObject.SetActive(value:  false);
        return;
        label_22:
    }
    private void OnEnable()
    {
        this.progress = LightningWordsHandler.DEFAULT_REWARD_VALUE.GetEventProgress();
        this.ShowProgress();
        this.UpdateRewardInfo();
        if(this.progress < 0)
        {
                this.ShowEventIncompleteUI();
            return;
        }
        
        this.ShowEventCompletedUI();
    }
    private void ShowProgress()
    {
        string val_1 = LightningWordsHandler.DEFAULT_REWARD_VALUE.GetEventProgressText(spaced:  true);
        goto typeof(UnityEngine.UI.Slider).__il2cppRuntimeField_420;
    }
    private void ShowEventIncompleteUI()
    {
        this.levelButton.gameObject.SetActive(value:  true);
        if(this.levelButtonText != 0)
        {
                string val_5 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        }
        
        if(this.continueButton != 0)
        {
                GameBehavior val_8 = App.getBehavior;
            this.continueButton.gameObject.SetActive(value:  ((val_8.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
            GameBehavior val_11 = App.getBehavior;
            this.levelButton.gameObject.SetActive(value:  ((val_11.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        }
        
        string val_14 = Localization.Localize(key:  "lightning_words_ends_upper", defaultValue:  "LIGHTNING WORDS ENDS", useSingularKey:  false)(Localization.Localize(key:  "lightning_words_ends_upper", defaultValue:  "LIGHTNING WORDS ENDS", useSingularKey:  false)) + ":"(":");
        FrameSkipper val_15 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this.timerText);
        System.Delegate val_17 = System.Delegate.Combine(a:  val_15.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGLightningWordsPopup::UpdateEventTimer()));
        if(val_17 != null)
        {
                if(null != null)
        {
            goto label_26;
        }
        
        }
        
        val_15.updateLogic = val_17;
        this.timerGroup.SetActive(value:  true);
        return;
        label_26:
    }
    private void ShowEventCompletedUI()
    {
        var val_7 = null;
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "congrats_identified_lightning", defaultValue:  "Congratulations! You identified {0} Lightning Words!", useSingularKey:  false), arg0:  LightningWordsEcon.requiredNumWords);
        this.collectButton.gameObject.SetActive(value:  true);
        this.closeButton.gameObject.SetActive(value:  false);
        if(this.victorySystem == 0)
        {
                return;
        }
        
        this.victorySystem.gameObject.SetActive(value:  true);
        this.victorySystem.Play();
    }
    private void UpdateEventTimer()
    {
        string val_1 = LightningWordsHandler.DEFAULT_REWARD_VALUE.GetEventRemainingTime();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UpdateRewardInfo()
    {
        var val_12;
        string val_13;
        var val_14;
        var val_15;
        UnityEngine.UI.Text val_16;
        val_12 = this;
        val_13 = 1152921504977719296;
        val_14 = null;
        val_14 = null;
        if(LightningWordsEcon.rewardType == 4)
        {
            goto label_3;
        }
        
        if(LightningWordsEcon.rewardType == 3)
        {
            goto label_4;
        }
        
        if(LightningWordsEcon.rewardType != 1)
        {
            goto label_20;
        }
        
        this.rewardCoinObject.SetActive(value:  true);
        this.rewardBonusGameObject.SetActive(value:  false);
        val_15 = null;
        val_15 = null;
        string val_1 = ToString();
        if(this.progress >= 0)
        {
                return;
        }
        
        string val_2 = Localization.Localize(key:  "lightning_words_appear_randomly", defaultValue:  "Lightning Words appear randomly during gameplay. Identify them before time expires to earn a reward!", useSingularKey:  false);
        val_12 = ???;
        val_13 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_3:
        string val_3 = Localization.Localize(key:  "bonus_spin_upper", defaultValue:  "BONUS SPIN", useSingularKey:  false);
        val_12 + 152.sprite = val_12 + 168;
        if((val_12 + 184) >= 0)
        {
            goto label_20;
        }
        
        val_16 = mem[val_12 + 24];
        val_16 = val_12 + 24;
        string val_4 = Localization.Localize(key:  "lightning_words_event_bonus_slots", defaultValue:  "Lightning Words appear randomly during gameplay. Identify them before time expires for a chance to earn up to 900 Coins and Golden Apples on the Bonus Spinner!", useSingularKey:  false);
        if(val_16 != 0)
        {
            goto label_16;
        }
        
        label_4:
        string val_5 = Localization.Localize(key:  "bonus_wheel_upper", defaultValue:  "BONUS WHEEL", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconWheel;
        if(this.progress >= 0)
        {
            goto label_20;
        }
        
        val_16 = this.descriptionText;
        val_13 = Localization.Localize(key:  "lightning_words_event_bonus_wheel", defaultValue:  "Lightning Words appear randomly during gameplay. Identify them before time expires for a chance to earn up to {0} Coins or {1} Golden Apples on the Bonus Wheel!", useSingularKey:  false);
        string val_11 = System.String.Format(format:  val_13, arg0:  App.getGameEcon.maxBonusGameWheelAwardCoins, arg1:  App.getGameEcon.maxBonusGameWheelAwardGoldenCurrency);
        label_16:
        label_20:
        this.rewardCoinObject.SetActive(value:  false);
        this.rewardBonusGameObject.SetActive(value:  true);
    }
    private void OnClick_LevelButton()
    {
        if(SceneDictator.IsInGameScene() != true)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_CollectButton(bool connected)
    {
        var val_15;
        var val_16;
        this.collectButton.interactable = false;
        if(connected == false)
        {
            goto label_2;
        }
        
        val_15 = null;
        val_15 = null;
        if(LightningWordsEcon.rewardType == 4)
        {
            goto label_5;
        }
        
        if(LightningWordsEcon.rewardType == 3)
        {
            goto label_6;
        }
        
        if(LightningWordsEcon.rewardType != 1)
        {
                return;
        }
        
        this.coinAnim.gameObject.SetActive(value:  true);
        val_16 = null;
        val_16 = null;
        decimal val_3 = System.Decimal.op_Implicit(value:  LightningWordsEcon.reward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  "Lightning Words Event Reward", subSource:  0, externalParams:  0, doTrack:  true);
        Player val_4 = App.Player;
        decimal val_5 = System.Decimal.op_Implicit(value:  LightningWordsEcon.reward);
        decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits, lo = 1}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        Player val_7 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return;
        label_2:
        LightningWordsHandler.DEFAULT_REWARD_VALUE.ShowInternetRequiredPopup();
        label_37:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_5:
        WGWindowManager val_10 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BonusGameSlotMachinePopup>(showNext:  true);
        mem2[0] = "Lightning Words Event Reward";
        val_10.waitingForGeneration = new System.Action(object:  LightningWordsHandler.DEFAULT_REWARD_VALUE, method:  typeof(System.Int32).__il2cppRuntimeField_578);
        goto label_37;
        label_6:
        WGWindowManager val_13 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BonusGameWheelPopup>(showNext:  true);
        mem2[0] = "Lightning Words Event Reward";
        mem2[0] = new System.Action(object:  LightningWordsHandler.DEFAULT_REWARD_VALUE, method:  typeof(System.Int32).__il2cppRuntimeField_578);
        goto label_37;
    }
    private void OnClick_CloseButton()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        goto typeof(System.Int32).__il2cppRuntimeField_540;
    }
    private void OnCoinAminFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGLightningWordsPopup()
    {
    
    }

}
