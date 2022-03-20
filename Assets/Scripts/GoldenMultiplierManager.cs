using UnityEngine;
public class GoldenMultiplierManager : MonoSingleton<GoldenMultiplierManager>
{
    // Fields
    public const string MULTI_UPDATED = "OnGoldenMultiplierUpdate";
    private const int STREAK_TOOLIP = 50;
    private int currentLevelCompleteBonus;
    private bool hasShownTooltipThisLevel;
    private System.Collections.Generic.Dictionary<float, float> multiplierCosts;
    
    // Properties
    public static bool IsAvaialable { get; }
    public float GetMultiplierIncrement { get; }
    public float GetNextCost { get; }
    public bool IsMaxGoldedMultiplier { get; }
    public float GetCurrentGoldenMultiplier { get; }
    public float GetCurrentBaseMultiplier { get; }
    public int GetCurrentLevelCompleteBonus { get; }
    public float GetCurrentBonusFromSubs { get; }
    public float GetCurrentBonusFromDifficulty { get; }
    private bool knobEnabled { get; }
    private float defaultMultiplier { get; }
    private float defaultCost { get; }
    private float multiplierIncrement { get; }
    private float costIncrementCoefficient { get; }
    private float maxGoldenMultiplier { get; }
    private float currentMultiplier { get; set; }
    
    // Methods
    public static bool get_IsAvaialable()
    {
        UnityEngine.Object val_7 = MonoSingleton<GoldenMultiplierManager>.Instance;
        if(val_7 == 0)
        {
                return false;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return MonoSingleton<GoldenMultiplierManager>.Instance.knobEnabled;
        }
        
        val_7 = MonoSingleton<GoldenMultiplierManager>.Instance.gameObject;
        UnityEngine.Object.Destroy(obj:  val_7);
        return false;
    }
    public float get_GetMultiplierIncrement()
    {
        return this.multiplierIncrement;
    }
    public float get_GetNextCost()
    {
        System.Collections.Generic.Dictionary<System.Single, System.Single> val_13;
        System.Func<TSource, System.Boolean> val_14;
        var val_16;
        val_13 = this;
        int val_2 = this.multiplierCosts.Count;
        if(val_2 != 0)
        {
                val_14 = 1152921516439486560;
            bool val_4 = this.multiplierCosts.ContainsKey(key:  val_2.defaultMultiplier);
            if(val_4 != false)
        {
                if((this.multiplierCosts.ContainsKey(key:  val_4.currentMultiplier)) == true)
        {
            goto label_6;
        }
        
        }
        
        }
        
        UnityEngine.Debug.LogWarning(message:  "GoldenMultiplierManager: Recalculating Cost Econ");
        this.PopulateMultiplierCosts();
        label_6:
        bool val_8 = this.multiplierCosts.ContainsKey(key:  this.currentMultiplier);
        if(val_8 != false)
        {
                val_13 = this.multiplierCosts;
            float val_9 = val_8.currentMultiplier;
            val_16 = 1152921516439500048;
            return this.multiplierCosts.Item[val_12];
        }
        
        UnityEngine.Debug.LogWarning(message:  "GoldenMultiplierManager: currentMuliplier not in econ");
        System.Func<System.Single, System.Boolean> val_11 = null;
        val_14 = val_11;
        val_11 = new System.Func<System.Single, System.Boolean>(object:  this, method:  System.Boolean GoldenMultiplierManager::<get_GetNextCost>b__10_0(float x));
        float val_12 = System.Linq.Enumerable.FirstOrDefault<System.Single>(source:  this.multiplierCosts.Keys, predicate:  val_11);
        if(val_12 > 0f)
        {
                val_16 = 1152921516439500048;
            return this.multiplierCosts.Item[val_12];
        }
        
        UnityEngine.Debug.LogError(message:  "GoldenMultiplierManager: Error Calculating Next Cost, using default cost");
        return (float)this.defaultCost;
    }
    public bool get_IsMaxGoldedMultiplier()
    {
        return (bool)(this.currentMultiplier >= this.maxGoldenMultiplier) ? 1 : 0;
    }
    public float get_GetCurrentGoldenMultiplier()
    {
        return this.GetTotalMultipliers();
    }
    public float get_GetCurrentBaseMultiplier()
    {
        return this.currentMultiplier;
    }
    public int get_GetCurrentLevelCompleteBonus()
    {
        return (int)this.currentLevelCompleteBonus;
    }
    public float get_GetCurrentBonusFromSubs()
    {
        return WGSubscriptionManager.GetPointMultiplier();
    }
    public float get_GetCurrentBonusFromDifficulty()
    {
        return DifficultySettingManager.GetCurrentPointMultiplier;
    }
    private bool get_knobEnabled()
    {
        GameEcon val_1 = App.getGameEcon;
        return (bool)val_1.gm_enabled;
    }
    private float get_defaultMultiplier()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.gm_defaultMultiplier;
    }
    private float get_defaultCost()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.gm_defaultMultiplierCost;
    }
    private float get_multiplierIncrement()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.gm_multiplierIncrement;
    }
    private float get_costIncrementCoefficient()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.gm_costIncrementCoefficient;
    }
    private float get_maxGoldenMultiplier()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.gm_maxGoldenMultiplier;
    }
    private float get_currentMultiplier()
    {
        if(val_1.properties.GoldenMultiplier < 0)
        {
                return App.Player.defaultMultiplier;
        }
        
        Player val_2 = App.Player;
        return (float)val_2.properties.GoldenMultiplier;
    }
    private void set_currentMultiplier(float value)
    {
        Player val_1 = App.Player;
        val_1.properties.GoldenMultiplier = value;
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void GoldenMultiplierManager::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    public bool PurchaseMultiplier()
    {
        float val_18;
        var val_19;
        float val_1 = this.GetNextCost;
        Player val_3 = App.Player;
        if(val_3._stars < ((int)(val_1 == Infinityf) ? (-(double)val_1) : ((double)val_1)))
        {
                val_19 = 0;
            return (bool)val_19;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        float val_6 = val_4.multiplierIncrement;
        val_6 = val_4.currentMultiplier + val_6;
        val_4.Add(key:  "Multiplier Purchased", value:  System.String.Format(format:  "multiplier {0}", arg0:  (float)System.Math.Round(value:  (double)val_6, digits:  1)));
        GoldenApplesManager val_9 = MonoSingleton<GoldenApplesManager>.Instance;
        val_9.DebitBalance(debitAmount:  (int)(val_1 == Infinityf) ? (-(double)val_1) : ((double)val_1), source:  "Golden Multiplier", additionalParams:  val_4);
        val_18 = val_9.currentMultiplier + val_9.multiplierIncrement;
        val_9.currentMultiplier = val_18;
        this.currentMultiplier = (float)System.Math.Round(value:  (double)val_18, digits:  1);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGoldenMultiplierUpdate");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        if(SLC.Social.Leagues.LeaguesManager.DAO != 0)
        {
                val_19 = 1;
            SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
            return (bool)val_19;
        }
        
        val_19 = 1;
        return (bool)val_19;
    }
    public void CurrentLevelWordStreaked(int currentStreak)
    {
        if(currentStreak < 50)
        {
                return;
        }
        
        if((UnityEngine.Mathf.Approximately(a:  this.currentMultiplier, b:  this.defaultMultiplier)) == false)
        {
                return;
        }
        
        if(this.hasShownTooltipThisLevel == true)
        {
                return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_4.<metaGameBehavior>k__BackingField.PlayCompleteFlyout();
        this.hasShownTooltipThisLevel = true;
    }
    private void PopulateMultiplierCosts()
    {
        var val_5;
        long val_12;
        float val_13;
        var val_14;
        this.multiplierCosts.Clear();
        float val_10 = this.multiplierCosts.defaultCost;
        var val_12 = 0;
        label_15:
        float val_4 = this.costIncrementCoefficient;
        val_10 = val_10 + ((float)System.Math.Round(value:  (double)this.multiplierCosts.defaultMultiplier, digits:  1));
        if(val_10 >= 0f)
        {
            goto label_6;
        }
        
        if((double)val_10 != (-0.5))
        {
            goto label_7;
        }
        
        val_12 = (long)val_5;
        val_13 = (float)val_5;
        val_14 = val_13 + (-1f);
        goto label_8;
        label_6:
        if((double)val_10 != 0.5)
        {
            goto label_9;
        }
        
        val_12 = (long)val_5;
        val_13 = (float)val_5;
        val_14 = val_13 + 1f;
        label_8:
        var val_6 = ((val_12 & 1) != 0) ? (val_13) : (val_14);
        goto label_11;
        label_7:
        float val_11 = -0.5f;
        val_11 = val_10 + val_11;
        goto label_11;
        label_9:
        float val_7 = val_10 + 0.5f;
        label_11:
        this.multiplierCosts.Add(key:  (float)System.Math.Round(value:  (double)this.multiplierCosts.defaultMultiplier, digits:  1), value:  val_10);
        float val_8 = this.multiplierCosts.multiplierIncrement;
        val_8 = val_8 + ((float)System.Math.Round(value:  (double)this.multiplierCosts.defaultMultiplier, digits:  1));
        double val_9 = System.Math.Round(value:  (double)val_8, digits:  1);
        val_12 = val_12 + 1;
        if(val_12 < 991)
        {
            goto label_15;
        }
    
    }
    private float GetTotalMultipliers()
    {
        float val_4 = DifficultySettingManager.GetCurrentPointMultiplier + (-1f);
        float val_5 = this.currentMultiplier;
        val_5 = (val_5 + S2) + (WGSubscriptionManager.GetPointMultiplier() + (-1f));
        return (float)(float)System.Math.Round(value:  (double)val_5, digits:  1);
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
        var val_8;
        if(sceneType != 2)
        {
                return;
        }
        
        if(GoldenMultiplierManager.IsAvaialable == false)
        {
                return;
        }
        
        val_8 = 1152921504879157248;
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void GoldenMultiplierManager::OnLevelLoaded(GameLevel level)));
        WordRegion.instance.addOnLevelCompleteAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void GoldenMultiplierManager::OnLevelComplete(GameLevel level)));
    }
    private void OnLevelLoaded(GameLevel level)
    {
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnGoldenMultiplierUpdate");
        this.hasShownTooltipThisLevel = false;
    }
    private void OnLevelComplete(GameLevel level)
    {
        var val_10;
        var val_11;
        float val_12;
        val_11 = level;
        if(GoldenMultiplierManager.IsAvaialable == false)
        {
                return;
        }
        
        int val_10 = level.goldenApplesStreaks;
        val_12 = this.GetTotalMultipliers() * (float)val_10;
        int val_3 = UnityEngine.Mathf.RoundToInt(f:  val_12);
        this.currentLevelCompleteBonus = val_3;
        val_11 = val_3;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_10 = 1152921515419383392;
        val_10 = val_11 - val_10;
        val_4.Add(key:  "Base Award", value:  val_10);
        val_4.Add(key:  "Golden Multiplier Bonus", value:  val_10);
        if(DifficultySettingManager.GetCurrentPointMultiplier > 0f)
        {
                float val_6 = DifficultySettingManager.GetCurrentPointMultiplier;
            val_6 = val_6 + (-1f);
            val_12 = val_6 * (float)val_10;
            val_4.Add(key:  "Challenge Bonus", value:  val_12);
        }
        
        if(WGSubscriptionManager.GetPointMultiplier() > 0f)
        {
                float val_8 = WGSubscriptionManager.GetPointMultiplier();
            val_8 = val_8 + (-1f);
            val_8 = val_8 * (float)val_10;
            val_4.Add(key:  "Golden Ticket Bonus", value:  val_8);
        }
        
        GoldenApplesManager val_9 = MonoSingleton<GoldenApplesManager>.Instance;
    }
    public GoldenMultiplierManager()
    {
        this.multiplierCosts = new System.Collections.Generic.Dictionary<System.Single, System.Single>();
    }
    private bool <get_GetNextCost>b__10_0(float x)
    {
        return (bool)(this.currentMultiplier < 0) ? 1 : 0;
    }

}
