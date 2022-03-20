using UnityEngine;
public class WordStreak : MonoSingleton<WordStreak>
{
    // Fields
    public const string STREAK_UPDATED = "OnWordStreakUpdated";
    protected int currentStreak;
    public static System.Collections.Generic.Dictionary<int, string> streakFeedback;
    public bool streakSaved;
    public bool streakSaverOffered;
    protected UnityEngine.UI.Button buttonStreakSaver;
    protected UnityEngine.UI.Text labelStreakSaverCoinCost;
    protected GameLevel currentLevel;
    protected int brokenStreak;
    
    // Properties
    public static int CurrentStreak { get; }
    public static int LargestStreak { get; }
    public static int ApplesFromStreak { get; }
    public static int ApplesFromStreakSub { get; }
    public GameLevel CurrentLevel { get; }
    protected bool StreakSaverEnabled { get; }
    protected int MinOffer { get; }
    protected decimal CostMultiplier { get; }
    
    // Methods
    public static int get_CurrentStreak()
    {
        int val_4;
        if((MonoSingleton<WordStreak>.Instance) == 0)
        {
                val_4 = 0;
            return val_4;
        }
        
        WordStreak val_3 = MonoSingleton<WordStreak>.Instance;
        val_4 = val_3.currentStreak;
        return val_4;
    }
    public static int get_LargestStreak()
    {
        int val_5;
        if((MonoSingleton<WordStreak>.Instance) != 0)
        {
                WordStreak val_3 = MonoSingleton<WordStreak>.Instance;
            if(val_3.currentLevel != null)
        {
                WordStreak val_4 = MonoSingleton<WordStreak>.Instance;
            val_5 = val_4.currentLevel.highestWordStreak;
            return (int)val_5;
        }
        
        }
        
        val_5 = 0;
        return (int)val_5;
    }
    public static int get_ApplesFromStreak()
    {
        int val_5;
        if((MonoSingleton<WordStreak>.Instance) != 0)
        {
                WordStreak val_3 = MonoSingleton<WordStreak>.Instance;
            if(val_3.currentLevel != null)
        {
                WordStreak val_4 = MonoSingleton<WordStreak>.Instance;
            val_5 = val_4.currentLevel.goldenApplesStreaks;
            return (int)val_5;
        }
        
        }
        
        val_5 = 0;
        return (int)val_5;
    }
    public static int get_ApplesFromStreakSub()
    {
        int val_5;
        if((MonoSingleton<WordStreak>.Instance) != 0)
        {
                WordStreak val_3 = MonoSingleton<WordStreak>.Instance;
            if(val_3.currentLevel != null)
        {
                WordStreak val_4 = MonoSingleton<WordStreak>.Instance;
            val_5 = val_4.currentLevel.goldenApplesStreaksSubBonus;
            return (int)val_5;
        }
        
        }
        
        val_5 = 0;
        return (int)val_5;
    }
    public GameLevel get_CurrentLevel()
    {
        return (GameLevel)this.currentLevel;
    }
    protected bool get_StreakSaverEnabled()
    {
        GameEcon val_1 = App.getGameEcon;
        return (bool)val_1.ss_enabled;
    }
    protected int get_MinOffer()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ss_min_offer;
    }
    protected decimal get_CostMultiplier()
    {
        GameEcon val_1 = App.getGameEcon;
        return System.Decimal.op_Implicit(value:  val_1.ss_cost_multiplier);
    }
    protected virtual void Start()
    {
        WordRegion.instance.addOnValidWordSubmittedAction(callback:  new System.Action<System.String, System.Boolean>(object:  this, method:  typeof(WordStreak).__il2cppRuntimeField_1E8));
        WordRegion.instance.addOnInvalidWordSubmittedAction(callback:  new System.Action(object:  this, method:  typeof(WordStreak).__il2cppRuntimeField_1F8));
        WordRegion.instance.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  typeof(WordStreak).__il2cppRuntimeField_1B8));
        MainController val_7 = MainController.instance;
        val_7.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WordStreak).__il2cppRuntimeField_1C8));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFadeInBegin");
        WordRegion.instance.addOnHintedUsedAction(callback:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  System.Void WordStreak::OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)));
        goto typeof(WordStreak).__il2cppRuntimeField_200;
    }
    private void OnFadeInBegin()
    {
        this.OnPlayerInput();
    }
    private void OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)
    {
        this.OnPlayerInput();
    }
    private void OnPlayerInput()
    {
        if(this.buttonStreakSaver.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.buttonStreakSaver.gameObject.SetActive(value:  false);
    }
    protected virtual void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CheckAndBreakStreak());
    }
    public void PlayBorderEffects(bool restoreEffects = False)
    {
        UnityEngine.Object val_7;
        if(restoreEffects != false)
        {
                if(this.currentStreak < 2)
        {
                return;
        }
        
            var val_7 = 2;
            do
        {
            val_7 = MonoSingleton<GoldenApplesEffectController>.Instance;
            if(val_7 != 0)
        {
                MonoSingleton<GoldenApplesEffectController>.Instance.PlayEffects(streak:  2);
        }
        
            val_7 = val_7 + 1;
        }
        while(val_7 <= this.currentStreak);
        
            return;
        }
        
        val_7 = 1152921504893161472;
        if((MonoSingleton<GoldenApplesEffectController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<GoldenApplesEffectController>.Instance.PlayEffects(streak:  this.currentStreak);
    }
    protected virtual void OnLevelLoaded(GameLevel level)
    {
        this.currentLevel = level;
        if(GoldenMultiplierManager.IsAvaialable != false)
        {
                NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnWordStreakUpdated");
        }
        
        this.buttonStreakSaver.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WordStreak).__il2cppRuntimeField_218));
        goto typeof(WordStreak).__il2cppRuntimeField_200;
    }
    protected virtual void OnLevelComplete()
    {
        goto typeof(WordStreak).__il2cppRuntimeField_1D0;
    }
    private System.Collections.IEnumerator CheckAndBreakStreak()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordStreak.<CheckAndBreakStreak>d__33();
    }
    private bool IsBreakingStreak()
    {
        var val_2;
        var val_3;
        var val_4;
        val_2 = 1152921504885227520;
        val_3 = null;
        val_3 = null;
        if(TrackingComponent.lastIntent == 0)
        {
                return (bool)((InAppPurchasesManager.<inPurchaseIntent>k__BackingField) == false) ? 1 : 0;
        }
        
        val_4 = 0;
        return (bool)((InAppPurchasesManager.<inPurchaseIntent>k__BackingField) == false) ? 1 : 0;
    }
    protected void StopBorderEffects()
    {
        if((MonoSingleton<GoldenApplesEffectController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<GoldenApplesEffectController>.Instance.StopEffects();
    }
    public virtual void ResetStreak()
    {
        this.currentStreak = 0;
    }
    protected virtual void OnValidWordSubmitted(string word, bool extra)
    {
        int val_25;
        if(extra != false)
        {
                GameBehavior val_1 = App.getBehavior;
            if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        }
        
        int val_2 = this.currentStreak + 1;
        mem[1152921517556466152] = 0;
        this.currentStreak = val_2;
        GameBehavior val_3 = App.getBehavior;
        if(val_2 < (val_3.<metaGameBehavior>k__BackingField))
        {
                val_3.<metaGameBehavior>k__BackingField.StopBorderEffects();
            return;
        }
        
        this.PlayBorderEffects(restoreEffects:  false);
        GameBehavior val_4 = App.getBehavior;
        val_25 = this.currentStreak;
        if(((val_4.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                val_25 = (val_25 < 12) ? (val_25 - 1) : 10;
        }
        
        int val_25 = this.currentLevel.goldenApplesStreaks;
        val_25 = val_25 + val_25;
        this.currentLevel.goldenApplesStreaks = val_25;
        this.currentLevel.highestWordStreak = UnityEngine.Mathf.Max(a:  this.currentLevel.highestWordStreak, b:  this.currentStreak);
        Player val_7 = App.Player;
        val_7.properties.SetLifetimeLargestStreak = this.currentStreak;
        if(GoldenMultiplierManager.IsAvaialable != false)
        {
                MonoSingleton<GoldenMultiplierManager>.Instance.CurrentLevelWordStreaked(currentStreak:  this.currentLevel.goldenApplesStreaks);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnWordStreakUpdated");
        }
        else
        {
                this.currentLevel.goldenApplesStreaksSubBonus = (WGSubscriptionManager.GetAdditionalPoints(basePoints:  val_25)) + this.currentLevel.goldenApplesStreaksSubBonus;
            GoldenApplesManager val_13 = MonoSingleton<GoldenApplesManager>.Instance;
            string val_15 = "streak_" + this.currentStreak.ToString();
            if((MonoSingleton<DifficultySettingManagerGameplay>.Instance) != 0)
        {
                MonoSingleton<DifficultySettingManagerGameplay>.Instance.AwardExtraApples(earnedAmount:  val_25);
        }
        
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<GoldenApplesFeedbackWord>.Instance)) != false)
        {
                MonoSingleton<GoldenApplesFeedbackWord>.Instance.OnWordStreakUpdated(extra:  extra);
        }
        
        DG.Tweening.Tween val_24 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  typeof(WordStreak).__il2cppRuntimeField_208), ignoreTimeScale:  true);
    }
    protected virtual void OnInvalidWordSubmitted()
    {
        var val_3;
        if(this.StreakSaverEnabled != false)
        {
                val_3 = null;
            int val_2 = WordStreak.CurrentStreak;
            this.brokenStreak = val_2;
        }
        
        val_2.StopBorderEffects();
        goto typeof(WordStreak).__il2cppRuntimeField_200;
    }
    protected virtual void UpdateStreakCounterLabel()
    {
        UnityEngine.Transform val_19;
        var val_20;
        val_19 = this;
        decimal val_3 = System.Decimal.op_Implicit(value:  this.brokenStreak);
        decimal val_4 = val_3.flags.CostMultiplier;
        decimal val_5 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        string val_6 = val_5.flags.ToString();
        this.buttonStreakSaver.interactable = true;
        UnityEngine.GameObject val_7 = this.buttonStreakSaver.gameObject;
        bool val_8 = val_7.StreakSaverEnabled;
        if(val_8 != false)
        {
                if(this.brokenStreak >= val_8.MinOffer)
        {
            goto label_9;
        }
        
        }
        
        val_20 = 0;
        if(val_7 == null)
        {
                label_9:
        }
        
        val_7.SetActive(value:  (this.brokenStreak > this.currentStreak) ? 1 : 0);
        if(this.buttonStreakSaver.gameObject.activeSelf == true)
        {
                return;
        }
        
        if(this.buttonStreakSaver.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.streakSaverOffered = true;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.zero;
        this.buttonStreakSaver.transform.localScale = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        val_19 = this.buttonStreakSaver.transform;
        UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  1f, y:  1f, z:  1f);
        DG.Tweening.Tweener val_18 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_19, endValue:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, duration:  0.55f), ease:  31);
    }
    protected virtual void OnStreakSaverButtonClicked()
    {
        var val_12;
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  this.brokenStreak);
        decimal val_3 = val_2.flags.CostMultiplier;
        decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41967616}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
        {
                val_12 = null;
            val_12 = null;
            PurchaseProxy.currentPurchasePoint = 121;
            GameBehavior val_6 = App.getBehavior;
            val_6.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
            return;
        }
        
        decimal val_8 = System.Decimal.op_Implicit(value:  this.brokenStreak);
        decimal val_9 = val_8.flags.CostMultiplier;
        decimal val_10 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
        bool val_11 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, source:  "Streak Saver", externalParams:  0, animated:  false);
        this.brokenStreak = 0;
        this.currentStreak = this.brokenStreak;
        this.streakSaved = true;
        this.buttonStreakSaver.interactable = false;
        this.PlayBorderEffects(restoreEffects:  true);
    }
    public WordStreak()
    {
    
    }
    private static WordStreak()
    {
        System.Collections.Generic.Dictionary<System.Int32, System.String> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.String>();
        val_1.Add(key:  1, value:  "streak_upper");
        val_1.Add(key:  2, value:  "awesome_upper");
        val_1.Add(key:  3, value:  "fantastic_upper");
        val_1.Add(key:  4, value:  "amazing_upper");
        val_1.Add(key:  5, value:  "spectacular_upper");
        val_1.Add(key:  6, value:  "incredible_upper");
        WordStreak.streakFeedback = val_1;
    }

}
