using UnityEngine;
public class WildWeekendPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Text description;
    private UnityEngine.GameObject description_collect;
    private UnityEngine.GameObject bonusBox;
    private UnityEngine.UI.Text description_collect_text;
    private UnityEngine.UI.Text amount;
    private UnityEngine.UI.Text progress;
    private UnityEngine.UI.Text playButtonText;
    private ExtraProgress progress_bar;
    private UnityEngine.UI.Button button_collect;
    private UnityEngine.UI.Button button_continue;
    private UnityEngine.UI.Button button_play;
    private UnityEngine.UI.Button button_close;
    private UnityEngine.UI.Image slotRewardImage;
    private UnityEngine.UI.Image wheelRewardImage;
    private UnityEngine.UI.VerticalLayoutGroup popupLayoutGroup;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private UnityEngine.ParticleSystem victoryParticles;
    protected UnityEngine.GameObject timerGroup;
    protected UnityEngine.UI.Text timer;
    private decimal AwardAmount;
    private float coinSpacing;
    private float nonCoinSpacing;
    private System.Action HandleCollectCallback;
    private System.Action HandleFirstSeenCallback;
    private WildWeekendHandler myHandler;
    
    // Methods
    private void Awake()
    {
        this.button_collect.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WildWeekendPopup::OnClick_Collect()));
        this.button_continue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WildWeekendPopup::OnClick_Continue()));
        this.button_play.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WildWeekendPopup::OnClick_Continue()));
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WildWeekendPopup::OnClick_Close()));
        this.coinsAnimControl.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WildWeekendPopup::OnCoinsAnimFinished());
    }
    public virtual void Setup(int levelsCompleted, int totalLevels, bool hasCollected, GameEventRewardType RewardType, System.DateTime eventEndDate, System.Action collectCallback, System.Action firstSeenCallback, WildWeekendHandler handler)
    {
        var val_73;
        var val_74;
        var val_75;
        var val_76;
        object val_77;
        System.Object[] val_78;
        UnityEngine.UI.Text val_79;
        string val_81;
        string val_82;
        int val_83;
        val_73 = 1152921504920850432;
        this.HandleCollectCallback = collectCallback;
        this.HandleFirstSeenCallback = firstSeenCallback;
        this.myHandler = WildWeekendHandler.econ_default_award;
        this.button_collect.gameObject.SetActive(value:  (levelsCompleted >= totalLevels) ? 1 : 0);
        this.button_collect.interactable = ((levelsCompleted >= totalLevels) ? 1 : 0) & hasCollected ^ 1;
        UnityEngine.GameObject val_6 = this.button_continue.gameObject;
        if(levelsCompleted < totalLevels)
        {
            goto label_5;
        }
        
        val_74 = 0;
        if(val_6 != null)
        {
            goto label_6;
        }
        
        label_5:
        GameBehavior val_7 = App.getBehavior;
        label_6:
        val_6.SetActive(value:  ((val_7.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        UnityEngine.GameObject val_9 = this.button_play.gameObject;
        if(levelsCompleted < totalLevels)
        {
            goto label_14;
        }
        
        val_75 = 0;
        if(val_9 != null)
        {
            goto label_15;
        }
        
        label_14:
        GameBehavior val_10 = App.getBehavior;
        label_15:
        val_9.SetActive(value:  ((val_10.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        bool val_13 = (levelsCompleted < totalLevels) ? 1 : 0;
        val_13 = val_13 | hasCollected;
        this.button_close.gameObject.SetActive(value:  val_13);
        string val_17 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        val_76 = 1152921504765632512;
        if((UnityEngine.Object.op_Implicit(exists:  this.timerGroup)) != false)
        {
                val_77 = val_76;
            this.timerGroup.SetActive(value:  val_13);
            FrameSkipper val_19 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this.timer);
            System.Delegate val_21 = System.Delegate.Combine(a:  val_19.updateLogic, b:  new System.Action(object:  this, method:  System.Void WildWeekendPopup::UpdateEventTimer()));
            if(val_21 != null)
        {
                if(null != null)
        {
            goto label_34;
        }
        
        }
        
            val_76 = val_77;
            val_73 = val_73;
            val_19.updateLogic = val_21;
        }
        
        this.slotRewardImage.gameObject.SetActive(value:  false);
        this.wheelRewardImage.gameObject.SetActive(value:  false);
        if(this.victoryParticles != 0)
        {
                this.victoryParticles.gameObject.SetActive(value:  (levelsCompleted >= totalLevels) ? 1 : 0);
            if(levelsCompleted >= totalLevels)
        {
                this.victoryParticles.Play();
        }
        
        }
        
        if(RewardType != 4)
        {
            goto label_46;
        }
        
        this.popupLayoutGroup.spacing = this.nonCoinSpacing;
        if(this.slotRewardImage != null)
        {
            goto label_48;
        }
        
        label_46:
        if(RewardType == 1)
        {
            goto label_50;
        }
        
        if(RewardType != 3)
        {
            goto label_85;
        }
        
        this.popupLayoutGroup.spacing = this.nonCoinSpacing;
        label_48:
        this.wheelRewardImage.gameObject.SetActive(value:  true);
        this.bonusBox.gameObject.SetActive(value:  false);
        label_85:
        string val_31 = System.String.Format(format:  "{0}/{1}", arg0:  levelsCompleted.ToString(format:  "0"), arg1:  totalLevels.ToString(format:  "0"));
        this.progress_bar.target = (float)totalLevels;
        this.progress_bar.current = (float)levelsCompleted;
        System.DateTime val_32 = eventEndDate.dateData.AddSeconds(value:  1);
        System.DateTime val_33 = val_32.dateData.ToLocalTime();
        System.DayOfWeek val_36 = val_33.dateData.DayOfWeek;
        val_78 = val_36;
        string val_37 = Localization.Localize(key:  val_33.dateData.DayOfWeek.ToLower(), defaultValue:  val_36, useSingularKey:  false);
        if(levelsCompleted < totalLevels)
        {
            goto label_63;
        }
        
        if(this.description_collect == 0)
        {
            goto label_66;
        }
        
        char[] val_42 = new char[1];
        val_42[0] = '
        ';
        System.String[] val_43 = System.String.Format(format:  Localization.Localize(key:  "wildweekendpopup_complete_desc", defaultValue:  "Congratulations!\nYou\'ve completed {0} levels!\nCollect your reward!", useSingularKey:  false), arg0:  totalLevels.ToString()).Split(separator:  val_42);
        val_79 = this.description_collect_text;
        string val_44 = System.String.Format(format:  "{0}\n{1}", arg0:  val_43[1], arg1:  val_43[2]);
        if(val_79 != null)
        {
            goto label_106;
        }
        
        label_63:
        int val_45 = val_33.dateData.Hour;
        var val_47 = (levelsCompleted < totalLevels) ? (val_45) : (val_45 - 12);
        val_47 = (val_45 == 11) ? ((val_47 == 0) ? 12 : (val_47)) : (val_45);
        val_77 = val_47.ToString() + (levelsCompleted < totalLevels) ? "am" : "pm"((levelsCompleted < totalLevels) ? "am" : "pm");
        if(RewardType == 3)
        {
            goto label_75;
        }
        
        if(RewardType != 1)
        {
            goto label_76;
        }
        
        val_79 = this.description;
        val_81 = "wildweekendpopup_description";
        val_82 = "Complete {0} levels by {1} at {2} and get a huge coin reward!";
        goto label_77;
        label_66:
        val_79 = this.description;
        string val_54 = System.String.Format(format:  Localization.Localize(key:  "wildweekendpopup_complete_desc", defaultValue:  "Congratulations!\nYou\'ve completed {0} levels!\nCollect your reward!", useSingularKey:  false), arg0:  totalLevels.ToString());
        if(val_79 != null)
        {
            goto label_106;
        }
        
        label_50:
        this.popupLayoutGroup.spacing = this.coinSpacing;
        this.bonusBox.gameObject.SetActive(value:  true);
        string val_57 = WildWeekendHandler.econ_default_award.getRewardValue().ToString();
        goto label_85;
        label_75:
        val_79 = this.description;
        object[] val_59 = new object[5];
        val_78 = val_59;
        val_83 = val_59.Length;
        val_78[0] = totalLevels.ToString();
        if(val_37 != null)
        {
                val_83 = val_59.Length;
        }
        
        val_76 = val_76;
        val_78[1] = val_37;
        if(val_77 != null)
        {
                val_83 = val_59.Length;
        }
        
        val_78[2] = val_77;
        val_78[3] = App.getGameEcon.maxBonusGameWheelAwardCoins;
        val_78[4] = App.getGameEcon.maxBonusGameWheelAwardGoldenCurrency;
        string val_65 = System.String.Format(format:  Localization.Localize(key:  "wild_word_weekend_popup_bonus_wheel", defaultValue:  "Complete {0} levels by {1} at {2} for a chance to earn up to {3} Coins or {4} Golden Apples on the Bonus Wheel!", useSingularKey:  false), args:  val_59);
        if(val_79 != null)
        {
            goto label_106;
        }
        
        label_76:
        if(RewardType != 4)
        {
            goto label_108;
        }
        
        val_79 = this.description;
        val_81 = "wild_word_weekend_popup_bonus_slots";
        val_82 = "Complete {0}  levels by {1} at {2} for a chance to earn up to 900 Coins and Golden Apples on the Bonus Spinner!";
        label_77:
        string val_68 = System.String.Format(format:  Localization.Localize(key:  val_81, defaultValue:  val_82, useSingularKey:  false), arg0:  totalLevels.ToString(), arg1:  val_37, arg2:  val_77);
        label_106:
        label_108:
        if(this.description_collect == 0)
        {
                return;
        }
        
        this.description.gameObject.SetActive(value:  val_13);
        this.description_collect.gameObject.SetActive(value:  (levelsCompleted >= totalLevels) ? 1 : 0);
        return;
        label_34:
    }
    private void Start()
    {
        mem2[0] = 0;
    }
    private void OnEnable()
    {
        if(this.HandleFirstSeenCallback == null)
        {
                return;
        }
        
        this.HandleFirstSeenCallback.Invoke();
    }
    private void OnClick_Close()
    {
        this.CloseWindow();
    }
    private void OnClick_Continue()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Collect()
    {
        GameEventRewardType val_1 = this.myHandler.getRewardType();
        if(this.HandleCollectCallback != null)
        {
                this.HandleCollectCallback.Invoke();
        }
        
        if(val_1 != 4)
        {
                if(val_1 != 3)
        {
                if(val_1 != 1)
        {
                return;
        }
        
            decimal val_3 = System.Decimal.op_Implicit(value:  this.myHandler.getRewardValue());
            this.button_collect.interactable = false;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  "Wild Weekend Complete", externalParams:  0, animated:  false);
            this.coinsAnimControl.gameObject.SetActive(value:  true);
            Player val_5 = App.Player;
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = 1}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            Player val_7 = App.Player;
            this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
            GameBehavior val_8 = App.getBehavior;
            mem2[0] = "Wild Weekend Complete";
        }
        else
        {
                GameBehavior val_10 = App.getBehavior;
            mem2[0] = "Wild Weekend Complete";
        }
        
        this.CloseWindow();
    }
    private void UpdateEventTimer()
    {
        string val_1 = this.GetEventRemainingTime();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private string GetEventRemainingTime()
    {
        return WildWeekendHandler.econ_default_award.GetEventRemainingTime();
    }
    private string GetEventEndsText()
    {
        return "EVENT ENDS IN";
    }
    private void OnCoinsAnimFinished()
    {
        this.CloseWindow();
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        this.myHandler.OnMyEventPopupClosed();
    }
    public WildWeekendPopup()
    {
        this.coinSpacing = 22f;
        this.nonCoinSpacing = 80f;
    }

}
