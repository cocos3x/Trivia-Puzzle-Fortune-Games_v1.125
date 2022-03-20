using UnityEngine;
public class WGPrizeBalloonManager : MonoSingleton<WGPrizeBalloonManager>
{
    // Fields
    public bool hack_setNonPurchaser;
    public bool hack_forceToShow;
    private PrizeBalloon.Progress progress;
    
    // Methods
    private void Start()
    {
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2._framesToSkip = 1000;
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void WGPrizeBalloonManager::CheckEligibility());
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGPrizeBalloonManager::Instance_OnSceneLoaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        val_4.OnSceneLoaded = val_6;
        return;
        label_6:
    }
    private void OnApplicationQuit()
    {
        this.progress.levelsCompletedThisSession = 0;
        goto typeof(PrizeBalloon.Progress).__il2cppRuntimeField_180;
    }
    public override void InitMonoSingleton()
    {
        this.progress = new PrizeBalloon.Progress();
        goto typeof(PrizeBalloon.Progress).__il2cppRuntimeField_170;
    }
    public string GetEligibilityInfo()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        GameEcon val_2 = App.getGameEcon;
        System.Text.StringBuilder val_3 = val_1.AppendFormat(format:  "Feature enabled? {0}\n", arg0:  val_2.prize_balloon_econ.FeatureEnabled);
        bool val_5 = SceneDictator.IsInGameScene();
        val_5 = val_1.AppendFormat(format:  "Is in the game scene? {0}\n", arg0:  val_5).IsGameModeEligible();
        System.Text.StringBuilder val_8 = val_1.AppendFormat(format:  "Is in correct game mode? (not daily challenge or category mode) {0}\n", arg0:  val_5);
        GameEcon val_10 = App.getGameEcon;
        System.Text.StringBuilder val_12 = val_1.AppendFormat(format:  "Level eligible? {0}\n", arg0:  (App.Player >= val_10.prize_balloon_econ.UnlockLevel) ? 1 : 0);
        GameEcon val_13 = App.getGameEcon;
        System.Text.StringBuilder val_15 = val_1.AppendFormat(format:  "Shown daily: {0}, eligible? {1}\n", arg0:  this.progress.dailyShownTimes, arg1:  (this.progress.dailyShownTimes < val_13.prize_balloon_econ.DailyLimit) ? 1 : 0);
        Player val_16 = App.Player;
        GameEcon val_17 = App.getGameEcon;
        decimal val_18 = System.Decimal.op_Implicit(value:  val_17.prize_balloon_econ.TriggerCoinBalance);
        System.Text.StringBuilder val_21 = val_1.AppendFormat(format:  "Credits balance eligible? {0}\n", arg0:  System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_16._credits, hi = val_16._credits, lo = this.progress.dailyShownTimes, mid = this.progress.dailyShownTimes}, d2:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid}));
        GameEcon val_22 = App.getGameEcon;
        System.Text.StringBuilder val_24 = val_1.AppendFormat(format:  "Levels completed this session: {0}, eligible? {1}\n", arg0:  this.progress.levelsCompletedThisSession, arg1:  (this.progress.levelsCompletedThisSession >= val_22.prize_balloon_econ.MinLevelsToCompletePerSession) ? 1 : 0);
        System.Text.StringBuilder val_29 = val_1.AppendFormat(format:  "Payer type: {0}, eligible? {1} ({2})\n", arg0:  this.GetPayerType().ToString(), arg1:  (this.GetPayerType() != 0) ? 1 : 0, arg2:  "Undefined Payer Type means that the payer is a purchaser but not a lapsed purchaser");
        GameEcon val_32 = App.getGameEcon;
        System.Text.StringBuilder val_34 = val_1.AppendFormat(format:  "Cooldown in seconds: {0}, eligible? {1}\n", arg0:  this.GetSecondsSinceLastBalloon(), arg1:  (this.GetSecondsSinceLastBalloon() >= val_32.prize_balloon_econ.CooldownInSeconds) ? 1 : 0);
        System.Text.StringBuilder val_38 = val_1.AppendFormat(format:  "Any window showing? {0}\n", arg0:  MonoSingleton<WGWindowManager>.Instance.HasQueuedWindows());
        System.Text.StringBuilder val_39 = val_1.AppendLine();
        System.Text.StringBuilder val_42 = val_1.AppendFormat(format:  "Overall eligible? {0}\n", arg0:  this.IsEligibleToTrigger());
        return (string)val_1;
    }
    public bool IsEligibleToTrigger()
    {
        var val_19;
        var val_20;
        val_19 = this;
        if(this.hack_forceToShow != false)
        {
                bool val_1 = SceneDictator.IsInGameScene();
            if(val_1 != false)
        {
                if(val_1.IsGameModeEligible() != false)
        {
                val_20 = 1;
            return (bool)val_20;
        }
        
        }
        
        }
        
        GameEcon val_3 = App.getGameEcon;
        if(val_3.prize_balloon_econ.FeatureEnabled == false)
        {
            goto label_41;
        }
        
        bool val_4 = SceneDictator.IsInGameScene();
        if((val_4 == false) || (val_4.IsGameModeEligible() == false))
        {
            goto label_41;
        }
        
        GameEcon val_7 = App.getGameEcon;
        if(App.Player < val_7.prize_balloon_econ.UnlockLevel)
        {
            goto label_41;
        }
        
        GameEcon val_8 = App.getGameEcon;
        if(this.progress.dailyShownTimes >= val_8.prize_balloon_econ.DailyLimit)
        {
            goto label_41;
        }
        
        Player val_9 = App.Player;
        GameEcon val_10 = App.getGameEcon;
        decimal val_11 = System.Decimal.op_Implicit(value:  val_10.prize_balloon_econ.TriggerCoinBalance);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_9._credits, hi = val_9._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid})) == true)
        {
            goto label_41;
        }
        
        GameEcon val_13 = App.getGameEcon;
        if(this.progress.levelsCompletedThisSession < val_13.prize_balloon_econ.MinLevelsToCompletePerSession)
        {
            goto label_41;
        }
        
        if(this.GetPayerType() == 0)
        {
                return (bool)val_20;
        }
        
        val_19 = this.GetSecondsSinceLastBalloon();
        GameEcon val_16 = App.getGameEcon;
        if(val_19 >= val_16.prize_balloon_econ.CooldownInSeconds)
        {
            goto label_47;
        }
        
        label_41:
        val_20 = 0;
        return (bool)val_20;
        label_47:
        bool val_18 = MonoSingleton<WGWindowManager>.Instance.HasQueuedWindows();
        val_18 = (~val_18) & 1;
        return (bool)val_20;
    }
    public bool IsGameModeEligible()
    {
        var val_7;
        if(((MonoSingleton<WGDailyChallengeManager>.Instance) != 0) && ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false))
        {
                val_7 = 0;
        }
        else
        {
                bool val_5 = CategoryPacksManager.IsPlaying;
            val_7 = val_5 ^ 1;
        }
        
        val_5 = val_7;
        return (bool)val_5;
    }
    public int GetCoinReward()
    {
        null = null;
        RandomSet val_3 = new RandomSet();
        List.Enumerator<T> val_4 = PrizeBalloon.Econ.CoinRewardsData.Item[this.GetPayerType()].GetEnumerator();
        label_8:
        if(0.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.add(item:  11993091, weight:  1f);
        goto label_8;
        label_5:
        0.Dispose();
        return (int)val_3.roll(unweighted:  false);
    }
    public void ShowBalloon()
    {
        var val_4;
        System.Action val_6;
        this.MarkProgress();
        val_4 = null;
        val_4 = null;
        val_6 = WGPrizeBalloonManager.<>c.<>9__10_0;
        if(val_6 == null)
        {
                System.Action val_3 = null;
            val_6 = val_3;
            val_3 = new System.Action(object:  WGPrizeBalloonManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGPrizeBalloonManager.<>c::<ShowBalloon>b__10_0());
            WGPrizeBalloonManager.<>c.<>9__10_0 = val_6;
        }
        
        MonoSingleton<PrizeBalloonUIController>.Instance.Setup(amount:  this.GetCoinReward(), onClose:  val_3);
    }
    public void CollectReward(int amount)
    {
        Player val_1 = App.Player;
        int val_5 = val_1.properties.prizeBalloonTapped;
        val_5 = val_5 + 1;
        val_1.properties.prizeBalloonTapped = val_5;
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
        decimal val_4 = System.Decimal.op_Implicit(value:  amount);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, source:  "Prize Balloon", subSource:  0, externalParams:  0, doTrack:  true);
    }
    public void ValidateProgress()
    {
        System.DateTime val_1 = this.progress.lastBalloonShownTime.Date;
        System.DateTime val_2 = DateTimeCheat.Now;
        System.DateTime val_3 = val_2.dateData.Date;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_3.dateData})) == false)
        {
                return;
        }
        
        this.progress.dailyShownTimes = 0;
    }
    public int GetTracking_BalloonsAppearedInLevel()
    {
        if(this.progress != null)
        {
                return (int)this.progress.balloonAppearedWithinLevel;
        }
        
        throw new NullReferenceException();
    }
    private void CheckEligibility()
    {
        this.ValidateProgress();
        if(this.IsEligibleToTrigger() == false)
        {
                return;
        }
        
        this.ShowBalloon();
    }
    private void Instance_OnSceneLoaded(SceneType obj)
    {
        if(obj != 2)
        {
                return;
        }
        
        if(this.IsGameModeEligible() == false)
        {
                return;
        }
        
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        MainController val_4 = MainController.instance;
        val_4.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPrizeBalloonManager::OnLevelComplete()));
    }
    private void OnLevelComplete()
    {
        this.progress.balloonAppearedWithinLevel = 0;
        int val_1 = this.progress.levelsCompletedThisSession;
        val_1 = val_1 + 1;
        this.progress.levelsCompletedThisSession = val_1;
        goto typeof(PrizeBalloon.Progress).__il2cppRuntimeField_180;
    }
    private void MarkProgress()
    {
        Player val_1 = App.Player;
        int val_4 = val_1.properties.prizeBalloonAppeared;
        val_4 = val_4 + 1;
        val_1.properties.prizeBalloonAppeared = val_4;
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
        int val_5 = this.progress.balloonAppearedWithinLevel;
        val_5 = val_5 + 1;
        this.progress.balloonAppearedWithinLevel = val_5;
        System.DateTime val_3 = DateTimeCheat.Now;
        this.progress.lastBalloonShownTime = val_3;
        int val_6 = this.progress.dailyShownTimes;
        val_6 = val_6 + 1;
        this.progress.dailyShownTimes = val_6;
        goto typeof(PrizeBalloon.Progress).__il2cppRuntimeField_180;
    }
    private PrizeBalloon.PayerType GetPayerType()
    {
        var val_6;
        ulong val_7;
        if(this.hack_setNonPurchaser == true)
        {
                return 1;
        }
        
        if(this.hack_forceToShow != false)
        {
                return 1;
        }
        
        Player val_1 = App.Player;
        val_6 = null;
        val_6 = null;
        val_7 = val_1.last_purchase;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_7}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                if(val_3.total_purchased == 0f)
        {
                return 1;
        }
        
        }
        
        var val_5 = (App.Player.IsLapsedPayer() != true) ? 2 : 0;
        return 1;
    }
    private bool IsLapsedPayer()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        Player val_2 = App.Player;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.last_purchase});
        double val_4 = val_3._ticks.TotalDays;
        GameEcon val_5 = App.getGameEcon;
        return (bool)(val_5.prize_balloon_econ.LapsedPayerDays <= ((int)(val_4 == Infinity) ? (-val_4) : (val_4))) ? 1 : 0;
    }
    private int GetSecondsSinceLastBalloon()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.progress.lastBalloonShownTime});
        double val_3 = val_2._ticks.TotalSeconds;
        val_3 = (val_3 == Infinity) ? (-val_3) : (val_3);
        return (int)(int)val_3;
    }
    public WGPrizeBalloonManager()
    {
    
    }

}
