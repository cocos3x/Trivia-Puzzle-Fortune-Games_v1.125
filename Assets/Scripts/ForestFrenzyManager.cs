using UnityEngine;
public class ForestFrenzyManager : MonoSingleton<ForestFrenzyManager>
{
    // Fields
    private System.Collections.Generic.List<WordForest.WFOForestContent> forestContentList;
    private WordForest.WFODigAnimation digAnimationPrefab;
    private UnityEngine.ParticleSystem prefabEfxTreeChoppedSmoke;
    private System.Collections.Generic.List<WordForest.WFOForestData> forestDataList;
    private int levelsPlayedThisSession;
    private System.DateTime lastLevelCompleteShownTime;
    
    // Properties
    public static bool IsFeatureUnlocked { get; }
    public System.Collections.Generic.List<WordForest.WFOForestData> ForestDataList { get; }
    public WordForest.WFOForestData CurrentForestData { get; }
    public WordForest.WFODigAnimation DigAnimationPrefab { get; }
    public UnityEngine.ParticleSystem ChoppedTreeSmokeEfxPrefab { get; }
    public int CurrentForestID { get; }
    public int CurrentForestGrowth { get; }
    public bool CurrentForestContainsDamagedTrees { get; }
    public int CurrentMaxGrowth { get; }
    public int CurrentGrowthCost { get; }
    public int CurrentForestLevel { get; }
    public string CurrentForestName { get; }
    public WordForest.WFOBackgroundType CurrentBGType { get; }
    public bool IsAtMaxGrowth { get; }
    public bool IsAtLastForest { get; }
    public int AffordableGrowthStages { get; }
    
    // Methods
    public static bool get_IsFeatureUnlocked()
    {
        var val_3 = null;
        return (bool)(App.Player >= ForestFrenzyEcon.UnlockLevel) ? 1 : 0;
    }
    public System.Collections.Generic.List<WordForest.WFOForestData> get_ForestDataList()
    {
        return (System.Collections.Generic.List<WordForest.WFOForestData>)this.forestDataList;
    }
    public WordForest.WFOForestData get_CurrentForestData()
    {
        WordForest.WFOForestData val_0;
        int val_1 = this.CurrentForestID;
        int val_2 = UnityEngine.Mathf.Clamp(value:  0, min:  0, max:  -1241891265);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_0.level = (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + ((long)(int)(val_2)) << 5) + 32;
        val_0.initialCost = (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + ((long)(int)(val_2)) << 5) + 32 + 16;
        return val_0;
    }
    public WordForest.WFODigAnimation get_DigAnimationPrefab()
    {
        return (WordForest.WFODigAnimation)this.digAnimationPrefab;
    }
    public UnityEngine.ParticleSystem get_ChoppedTreeSmokeEfxPrefab()
    {
        return (UnityEngine.ParticleSystem)this.prefabEfxTreeChoppedSmoke;
    }
    public int get_CurrentForestID()
    {
        return 1;
    }
    public int get_CurrentForestGrowth()
    {
        null = null;
        return ForestFrenzyEventProgress.forestMapData.CurrentForestGrowth(includeDamagedTrees:  false);
    }
    public bool get_CurrentForestContainsDamagedTrees()
    {
        null = null;
        return ForestFrenzyEventProgress.forestMapData.ContainsDamagedTrees;
    }
    public int get_CurrentMaxGrowth()
    {
        var val_2;
        WordForest.WFOForestData val_1 = this.CurrentForestData;
        return (int)val_2;
    }
    public int get_CurrentGrowthCost()
    {
        var val_7;
        System.Int32[] val_8;
        var val_9;
        val_7 = null;
        val_7 = null;
        val_8 = ForestFrenzyEcon.CostPerGrowthStage;
        if(this.CurrentForestGrowth < ForestFrenzyEcon.CostPerGrowthStage.Length)
        {
                val_9 = val_8 + (null.CurrentForestGrowth << 2);
            return (int)null;
        }
        
        val_8 = ForestFrenzyEcon.CostPerGrowthStage;
        val_9 = val_8 + (((-4294967296) + ((ForestFrenzyEcon.CostPerGrowthStage.Length) << 32)) >> 30);
        return (int)null;
    }
    public int get_CurrentForestLevel()
    {
        var val_2;
        WordForest.WFOForestData val_1 = this.CurrentForestData;
        return (int)val_2;
    }
    public string get_CurrentForestName()
    {
        string val_2;
        WordForest.WFOForestData val_1 = this.CurrentForestData;
        return (string)Localization.Localize(key:  val_2, defaultValue:  "", useSingularKey:  false);
    }
    public WordForest.WFOBackgroundType get_CurrentBGType()
    {
        var val_2;
        WordForest.WFOForestData val_1 = this.CurrentForestData;
        return (WordForest.WFOBackgroundType)val_2;
    }
    public bool get_IsAtMaxGrowth()
    {
        var val_3;
        WordForest.WFOForestData val_2 = this.CurrentForestData;
        return (bool)(this.CurrentForestGrowth >= val_3) ? 1 : 0;
    }
    public bool get_IsAtLastForest()
    {
        int val_1 = this.CurrentForestID;
        System.Collections.Generic.List<WordForest.WFOForestData> val_3 = this.forestDataList;
        val_3 = val_3 - 1;
        return (bool)(val_3 < 2) ? 1 : 0;
    }
    public int get_AffordableGrowthStages()
    {
        var val_3;
        var val_5;
        var val_12;
        var val_13;
        val_12 = null;
        val_12 = null;
        int val_11 = ForestFrenzyEventProgress.accumulatedCurrency;
        int val_12 = CurrentForestGrowth;
        WordForest.WFOForestData val_2 = this.CurrentForestData;
        if(val_12 < val_3)
        {
                do
        {
            WordForest.WFOForestData val_4 = this.CurrentForestData;
            int val_7 = val_5.GetGrowthCost(toStage:  val_12);
            val_11 = val_11 - ((val_11 < val_7) ? 0 : (val_7));
            var val_9 = (val_11 >= val_7) ? (0 + 1) : 0;
            val_12 = val_12 + 1;
            WordForest.WFOForestData val_10 = this.CurrentForestData;
        }
        while(val_12 < val_3);
        
            return (int)val_13;
        }
        
        val_13 = 0;
        return (int)val_13;
    }
    public override void InitMonoSingleton()
    {
        null = null;
        this.forestDataList = ForestFrenzyEcon.forests;
    }
    public void ShowForestScene()
    {
        GameBehavior val_1 = App.getBehavior;
        MonoSingleton<AdsUIController>.Instance.BannerAdsUnblocked = false;
    }
    public void CloseForestScene(bool playClicked = False)
    {
        if(ForestFrenzyMonolithProxy.Instance != 0)
        {
                SLCWindow.CloseWindow(window:  ForestFrenzyMonolithProxy.Instance.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        
        GameBehavior val_3 = App.getBehavior;
        UnityEngine.AsyncOperation val_4 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_3.<metaGameBehavior>k__BackingField);
        MonoSingleton<AdsUIController>.Instance.BannerAdsUnblocked = true;
        if(playClicked == false)
        {
            goto typeof(ForestFrenzyEventHandler).__il2cppRuntimeField_540;
        }
    
    }
    public void OnPlayLevelButtonClicked()
    {
        var val_14;
        var val_15;
        var val_16;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField.IsLoadingScene()) != false)
        {
                return;
        }
        
        val_14 = 1152921504893161472;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                val_15 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
        }
        else
        {
                val_15 = 0;
        }
        
        if((val_15 == 0) && (SceneDictator.IsInGameScene() != false))
        {
                if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_21;
        }
        
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
        val_15 = 1152921504887996416;
        val_16 = null;
        val_16 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 100;
        GameBehavior val_12 = App.getBehavior;
        label_21:
        val_12.<metaGameBehavior>k__BackingField.CloseForestScene(playClicked:  true);
    }
    public void AddCurrency(int amount)
    {
        var val_5;
        ForestFrenzyEventProgress.AddCurrency(amount:  amount);
        if((MonoSingleton<ForestFrenzyEventGameplayUIController>.Instance) == 0)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        MonoSingleton<ForestFrenzyEventGameplayUIController>.Instance.UpdateCurrency(from:  ForestFrenzyEventProgress.accumulatedCurrency - amount, to:  ForestFrenzyEventProgress.accumulatedCurrency);
    }
    private void DeductCurrency(int amount)
    {
        var val_5;
        ForestFrenzyEventProgress.DeductCurrency(amount:  amount);
        if((MonoSingleton<ForestFrenzyEventGameplayUIController>.Instance) == 0)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        MonoSingleton<ForestFrenzyEventGameplayUIController>.Instance.UpdateCurrency(from:  ForestFrenzyEventProgress.accumulatedCurrency + amount, to:  ForestFrenzyEventProgress.accumulatedCurrency);
    }
    public void AddGrowth(int damagedTreeIdToFix = -1, System.Action<bool> onServerResponse)
    {
        var val_5;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        .damagedTreeIdToFix = damagedTreeIdToFix;
        val_12 = null;
        val_12 = null;
        int val_2 = CurrentGrowthCost;
        if(ForestFrenzyEventProgress.accumulatedCurrency < val_2)
        {
            goto label_8;
        }
        
        WordForest.WFOForestData val_4 = this.CurrentForestData;
        if(val_2.CurrentForestGrowth >= val_5)
        {
            goto label_8;
        }
        
        val_13 = null;
        val_13 = null;
        System.Collections.Generic.List<WordForest.MapItem> val_6 = ForestFrenzyEventProgress.forestMapData.GetForestData();
        if((((ForestFrenzyManager.<>c__DisplayClass44_0)[1152921516252580672].damagedTreeIdToFix) & 2147483648) != 0)
        {
            goto label_12;
        }
        
        var val_12 = 1152921516252519424;
        int val_9 = val_6.FindIndex(match:  new System.Predicate<WordForest.MapItem>(object:  new ForestFrenzyManager.<>c__DisplayClass44_0(), method:  System.Boolean ForestFrenzyManager.<>c__DisplayClass44_0::<AddGrowth>b__0(WordForest.MapItem n)));
        val_14 = val_9;
        if((val_9 & 2147483648) != 0)
        {
            goto label_14;
        }
        
        if(val_12 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_12 = val_12 + (val_14 << 3);
        if(((1152921516252519424 + (val_9) << 3) + 32) != 0)
        {
            goto label_35;
        }
        
        label_8:
        if(onServerResponse == null)
        {
                return;
        }
        
        onServerResponse.Invoke(obj:  false);
        return;
        label_12:
        val_15 = 0;
        goto label_20;
        label_14:
        val_15 = val_14;
        label_20:
        if(val_12 >= 1)
        {
                var val_13 = 0;
            do
        {
            if(val_12 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.String.op_Inequality(a:  "IsEnclosedCJKLettersandMonths".__il2cppRuntimeField_10, b:  "tree")) != true)
        {
                if("IsEnclosedCJKLettersandMonths" <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_16 = 1152921516252520448;
        }
        
            val_13 = val_13 + 1;
        }
        while(val_13 < (-1239228384));
        
        }
        
        val_14 = val_15;
        label_35:
        this.DeductCurrency(amount:  val_6.CurrentGrowthCost);
        if((-1239228384) <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_11 = 1152921516252520480 + (val_14 << 3);
        mem2[0] = 1;
        ForestFrenzyEventProgress.UpdateForestMapData();
    }
    public void RewardForestComplete()
    {
        var val_7;
        var val_8;
        val_7 = null;
        val_7 = null;
        if(ForestFrenzyEventProgress.hasRewarded != false)
        {
                return;
        }
        
        ForestFrenzyEventProgress.HasRewarded = true;
        val_8 = null;
        val_8 = null;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = ForestFrenzyEcon.ForestCompleteReward, hi = ForestFrenzyEcon.ForestCompleteReward, lo = ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_14>>0&0xFFFFFFFF, mid = ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_14>>32&0x0}, source:  (this.IsAtLastForest != true) ? "Forest Frenzy All Complete" : "Forest Frenzy Location", subSource:  0, externalParams:  0, doTrack:  true);
        ForestFrenzyWindowManager val_5 = MonoSingleton<ForestFrenzyWindowManager>.Instance.ShowUGUIMonolith<ForestFrenzyForestCompleteRewardPopup>(showNext:  false);
        MonoSingleton<WordGameEventsController>.Instance.OnEventHandlerProgress();
    }
    public WordForest.WFOForestContent GetCurrentForestLayout()
    {
        int val_2;
        WordForest.WFOForestData val_1 = this.CurrentForestData;
        return this.GetForestLayout(forestId:  val_2);
    }
    public WordForest.WFOForestContent GetForestLayout(int forestId)
    {
        System.Collections.Generic.List<WordForest.WFOForestContent> val_6;
        UnityEngine.Object val_7;
        val_6 = this;
        .forestId = forestId;
        val_7 = this.forestContentList.Find(match:  new System.Predicate<WordForest.WFOForestContent>(object:  new ForestFrenzyManager.<>c__DisplayClass47_0(), method:  System.Boolean ForestFrenzyManager.<>c__DisplayClass47_0::<GetForestLayout>b__0(WordForest.WFOForestContent n)));
        if(val_7 != 0)
        {
                return (WordForest.WFOForestContent)val_7;
        }
        
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "Forest Layout Content for forest {0} not found, loading last forest as a failsafe", arg0:  (ForestFrenzyManager.<>c__DisplayClass47_0)[1152921516253032768].forestId));
        val_6 = this.forestContentList;
        if(null == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = mem[1152921505970741272];
        return (WordForest.WFOForestContent)val_7;
    }
    public bool TryShowForestBeforeLevelComplete()
    {
        var val_6;
        ulong val_7;
        var val_8;
        var val_9;
        var val_10;
        val_6 = null;
        val_6 = null;
        if(this.levelsPlayedThisSession < ForestFrenzyEcon.LevelsToPlay)
        {
            goto label_10;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        val_7 = val_1.dateData;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7}, d2:  new System.DateTime() {dateData = this.lastLevelCompleteShownTime});
        val_8 = null;
        val_8 = null;
        if(val_2._ticks.TotalSeconds <= (double)ForestFrenzyEcon.LevelsToPlayCooldownSeconds)
        {
            goto label_10;
        }
        
        val_9 = null;
        val_9 = null;
        int val_6 = this.levelsPlayedThisSession;
        val_6 = val_6 + 1;
        this.levelsPlayedThisSession = val_6;
        if(ForestFrenzyEventProgress.accumulatedCurrency >= CurrentGrowthCost)
        {
            goto label_16;
        }
        
        val_10 = 0;
        return (bool)val_10;
        label_10:
        int val_7 = this.levelsPlayedThisSession;
        val_10 = 0;
        val_7 = val_7 + 1;
        this.levelsPlayedThisSession = val_7;
        return (bool)val_10;
        label_16:
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        this.lastLevelCompleteShownTime = val_5;
        val_5.dateData.ShowForestScene();
        return (bool)val_10;
    }
    public void Hack_SetForestGrowth(int growth)
    {
    
    }
    public ForestFrenzyManager()
    {
        null = null;
        this.lastLevelCompleteShownTime = System.DateTime.MinValue;
    }

}
