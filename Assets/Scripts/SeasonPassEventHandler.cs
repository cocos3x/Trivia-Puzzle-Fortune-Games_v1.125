using UnityEngine;
public class SeasonPassEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "SeasonPass";
    public const string EVENT_TRACKING_ID = "Season Event";
    public const string EVENT_TRACKING_SUBSOURCE_TIER = "Season Event Reward Tier ";
    public const string SEASON_PLUAS_PASS_ID = "id_season_plus_pass";
    private static SeasonPassEventHandler <Instance>k__BackingField;
    public System.Action<bool> OnPurchaseAttempt;
    private SeasonPassEcon <econ>k__BackingField;
    private SeasonPassProgression <progression>k__BackingField;
    private string _uniqueSeasonName;
    private System.Collections.Generic.List<System.Tuple<SeasonPassEcon.Item, System.Decimal>> claimedAwards;
    private System.Collections.Generic.List<System.Tuple<WADPets.WADPet, int>> petCardAwards;
    private System.Collections.Generic.Dictionary<WADPets.WADPet, int> petCardsDict;
    
    // Properties
    public static SeasonPassEventHandler Instance { get; set; }
    public static bool IsPlaying { get; }
    public SeasonPassEcon econ { get; set; }
    public SeasonPassProgression progression { get; set; }
    public string uniqueSeasonName { get; }
    public static int PassHintDiscount { get; }
    public static int PassPickHintDiscount { get; }
    public static bool IsPlusPassActive { get; }
    public override bool OverrideEventButton { get; }
    
    // Methods
    public static SeasonPassEventHandler get_Instance()
    {
        return (SeasonPassEventHandler)SeasonPassEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(SeasonPassEventHandler value)
    {
        SeasonPassEventHandler.<Instance>k__BackingField = value;
    }
    public static bool get_IsPlaying()
    {
        var val_3;
        if((SeasonPassEventHandler.<Instance>k__BackingField) != null)
        {
                if((SeasonPassEventHandler.<Instance>k__BackingField.InExpireInterval()) == false)
        {
            goto label_2;
        }
        
        }
        
        val_3 = 0;
        goto label_3;
        label_2:
        SeasonPassEventHandler val_2 = SeasonPassEventHandler.<Instance>k__BackingField;
        val_3 = val_2 ^ 1;
        label_3:
        val_2 = val_3 & 1;
        return (bool)val_2;
    }
    public SeasonPassEcon get_econ()
    {
        return (SeasonPassEcon)this.<econ>k__BackingField;
    }
    private void set_econ(SeasonPassEcon value)
    {
        this.<econ>k__BackingField = value;
    }
    public SeasonPassProgression get_progression()
    {
        return (SeasonPassProgression)this.<progression>k__BackingField;
    }
    private void set_progression(SeasonPassProgression value)
    {
        this.<progression>k__BackingField = value;
    }
    public string get_uniqueSeasonName()
    {
        if((System.String.IsNullOrEmpty(value:  this._uniqueSeasonName)) == false)
        {
                return this._uniqueSeasonName.ToUpper();
        }
        
        return "SEASON";
    }
    public static int get_PassHintDiscount()
    {
        SeasonPassEventHandler val_3;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_3 = SeasonPassEventHandler.<Instance>k__BackingField;
            if(val_3 == null)
        {
                return (int)val_3;
        }
        
            if((val_3 & 1) == 0)
        {
                return (int)val_3;
        }
        
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public static int get_PassPickHintDiscount()
    {
        SeasonPassEventHandler val_3;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_3 = SeasonPassEventHandler.<Instance>k__BackingField;
            if(val_3 == null)
        {
                return (int)val_3;
        }
        
            if((val_3 & 1) == 0)
        {
                return (int)val_3;
        }
        
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public static bool get_IsPlusPassActive()
    {
        SeasonPassEventHandler val_4;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        val_4 = SeasonPassEventHandler.<Instance>k__BackingField;
        if(val_4 == null)
        {
                return (bool)val_4;
        }
        
        if((val_4 & 1) == 0)
        {
            goto label_8;
        }
        
        label_5:
        val_4 = 0;
        return (bool)val_4;
        label_8:
        var val_2 = (typeof(SeasonPassProgression).__il2cppRuntimeField_1C != 0) ? 1 : 0;
        return (bool)val_4;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516685721232] = eventV2;
        SeasonPassEventHandler.<Instance>k__BackingField = this;
        this.<econ>k__BackingField = WGResources.Load<SeasonPassEcon>(fileName:  "Events/SeasonPass/SeasonPassEcon", extension:  ".asset", errorLog:  true);
        this.<progression>k__BackingField = new SeasonPassProgression();
        if(eventV2.id != (this.<progression>k__BackingField.currentEventId))
        {
                this.<progression>k__BackingField.InitEvent(eventId:  eventV2.id, playerLevel:  App.Player);
        }
        
        this.ParseEventData(eventData:  eventV2.eventData);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        if((this.<progression>k__BackingField.currentTier) == this.CurrentUnlockedTier())
        {
                return;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SeasonPassEventPopup>(showNext:  false);
        mem2[0] = 1;
    }
    public override void UpdateProgress()
    {
        this.<progression>k__BackingField.currentTier = this.CurrentUnlockedTier();
        this.UpdateProgress();
    }
    public int CurrentUnlockedTier()
    {
        if((this.<progression>k__BackingField.initLevel) > App.Player)
        {
                this.<progression>k__BackingField.initLevel = App.Player;
        }
        
        int val_12 = this.<econ>k__BackingField.BronzeTierLevels;
        Player val_4 = App.Player - (this.<progression>k__BackingField.initLevel);
        Player val_5 = val_4 / val_12;
        if(val_5 <= 10)
        {
                return UnityEngine.Mathf.FloorToInt(f:  (float)val_5);
        }
        
        val_12 = val_4 + (val_12 * 9);
        int val_6 = val_12 / (this.<econ>k__BackingField.SilverTierLevels);
        if(val_6 > 10)
        {
                return UnityEngine.Mathf.Min(a:  30, b:  (UnityEngine.Mathf.FloorToInt(f:  (float)(val_12 + ((this.<econ>k__BackingField.SilverTierLevels) * 9)) / (this.<econ>k__BackingField.GoldTierLevels))) + 20);
        }
        
        int val_11 = UnityEngine.Mathf.FloorToInt(f:  (float)val_6);
        val_11 = val_11 + 10;
        return (int)val_11;
    }
    public int NextTierTarget()
    {
        if((this.<progression>k__BackingField) != null)
        {
                return this.LevelsForTier(tier:  (this.<progression>k__BackingField.currentTier) + 1);
        }
        
        throw new NullReferenceException();
    }
    public int LevelsForTier(int tier)
    {
        var val_6;
        int val_7;
        val_6 = tier;
        int val_1 = val_6 - 1;
        if()
        {
                val_6 = new int[3];
            val_6[0] = this.<econ>k__BackingField.BronzeTierLevels;
            val_6[0] = this.<econ>k__BackingField.SilverTierLevels;
            val_6[1] = this.<econ>k__BackingField.GoldTierLevels;
            val_7 = val_6[(UnityEngine.Mathf.Min(a:  UnityEngine.Mathf.FloorToInt(f:  0f), b:  val_2.Length - 1)) << 2];
            return (int)val_7;
        }
        
        val_7 = 0;
        return (int)val_7;
    }
    public int TotalLevelsForTier(int tier)
    {
        var val_2;
        if((tier & 2147483648) == 0)
        {
                var val_2 = 0;
            do
        {
            val_2 = (this.LevelsForTier(tier:  0)) + 0;
            if(val_2 >= tier)
        {
                return (int)val_2;
        }
        
            val_2 = val_2 + 1;
        }
        while(val_2 < 30);
        
            return (int)val_2;
        }
        
        val_2 = 0;
        return (int)val_2;
    }
    public int CurrentTierProgression()
    {
        var val_4;
        var val_5;
        val_4 = 0;
        if(((this.<progression>k__BackingField.currentTier) & 2147483648) != 0)
        {
            goto label_6;
        }
        
        val_5 = 0;
        label_7:
        int val_2 = this.LevelsForTier(tier:  0);
        val_4 = val_2 + val_4;
        if(val_5 >= (this.<progression>k__BackingField.currentTier))
        {
            goto label_6;
        }
        
        val_5 = val_5 + 1;
        if(val_5 < 30)
        {
            goto label_7;
        }
        
        label_6:
        val_2 = (App.Player - (this.<progression>k__BackingField.initLevel)) - val_4;
        return (int)val_2;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SeasonPassEventPopup>(showNext:  false);
    }
    public override bool get_OverrideEventButton()
    {
        return true;
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SeasonPassEventPopup>(showNext:  false);
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return false;
    }
    public override bool EventCompleted()
    {
        var val_4;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40})) != false)
        {
                val_4 = 1;
            return (bool)((this.<progression>k__BackingField.freeAwardsCollected) >= (this.<econ>k__BackingField.tiers)) ? 1 : 0;
        }
        
        if((this.<progression>k__BackingField.hasPass) != false)
        {
                if((this.<progression>k__BackingField.passAwardsCollected) >= (this.<econ>k__BackingField.tiers))
        {
                return (bool)((this.<progression>k__BackingField.freeAwardsCollected) >= (this.<econ>k__BackingField.tiers)) ? 1 : 0;
        }
        
        }
        
        val_4 = 0;
        return (bool)((this.<progression>k__BackingField.freeAwardsCollected) >= (this.<econ>k__BackingField.tiers)) ? 1 : 0;
    }
    public override string GetEventDisplayName()
    {
        return this.uniqueSeasonName;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        if((this.CurrentTierProgression() + 1) != this.NextTierTarget())
        {
                return;
        }
        
        1152921516687604992 = currentData;
        int val_4 = this.<progression>k__BackingField.currentTier;
        val_4 = val_4 + 1;
        1152921516687604992.Add(key:  "Season Event Reward Tier Complete", value:  val_4);
    }
    public override string GetMainMenuButtonText()
    {
        System.Collections.Generic.List<Tier> val_4 = this.<econ>k__BackingField.tiers;
        val_4 = val_4 - 1;
        return (string)System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "season_pass_title", defaultValue:  "SEASON REWARDS", useSingularKey:  false), arg1:  System.String.Format(format:  "{0}/{1}", arg0:  this.<progression>k__BackingField.currentTier, arg1:  val_4));
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        System.Collections.Generic.List<Tier> val_4 = this.<econ>k__BackingField.tiers;
        val_4 = val_4 - 1;
        float val_5 = (float)this.<progression>k__BackingField.currentTier;
        val_5 = val_5 / ((float)W22 - 1);
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentSeasonPass>(allowMultiple:  false).SetupSlider(sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  this.<progression>k__BackingField.currentTier, arg1:  val_4), sliderValue:  val_5);
    }
    public override string GetGameButtonText()
    {
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.CurrentTierProgression(), arg1:  this.NextTierTarget());
    }
    public string GetPlusPackagePrice()
    {
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageById(packageId:  "id_season_plus_pass");
        string val_2 = val_1.getString(key:  "regular_price", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_2)) == false)
        {
                return val_2;
        }
        
        return "$" + val_1.getString(key:  "sale_price", defaultValue:  "")(val_1.getString(key:  "sale_price", defaultValue:  ""));
    }
    public void PurchasePlusPassPackage()
    {
        var val_4;
        if((this.<progression>k__BackingField.hasPass) != false)
        {
                if(this.OnPurchaseAttempt == null)
        {
                return;
        }
        
            this.OnPurchaseAttempt.Invoke(obj:  false);
            return;
        }
        
        val_4 = null;
        val_4 = null;
        PurchaseProxy.currentPurchasePoint = 115;
        bool val_3 = PurchaseProxy.Purchase(purchase:  new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  "id_season_plus_pass")));
    }
    public override void OnProcessPurchase(ref PurchaseModel purchase)
    {
        this.OnProcessPurchase(purchase: ref  PurchaseModel val_1 = purchase);
    }
    public override void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "id_season_plus_pass")) == false)
        {
                return;
        }
        
        if(this.OnPurchaseAttempt == null)
        {
                return;
        }
        
        this.OnPurchaseAttempt.Invoke(obj:  false);
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "id_season_plus_pass")) == false)
        {
                return;
        }
        
        this.<progression>k__BackingField.hasPass = true;
        this.UpdateProgressToServer();
        this.UpdateHintDiscounts();
        if(this.OnPurchaseAttempt == null)
        {
                return;
        }
        
        this.OnPurchaseAttempt.Invoke(obj:  true);
    }
    public override void OnEventEnded()
    {
        SeasonPassEventHandler.<Instance>k__BackingField = 0;
        goto typeof(SeasonPassProgression).__il2cppRuntimeField_190;
    }
    public override string GetHackPanelEventData()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_3 = val_1.AppendLine(value:  System.String.Format(format:  "hass pass {0}", arg0:  this.<progression>k__BackingField.hasPass));
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  System.String.Format(format:  "pass awards collected {0}", arg0:  this.<progression>k__BackingField.passAwardsCollected));
        System.Text.StringBuilder val_7 = val_1.AppendLine(value:  System.String.Format(format:  "free awards collected {0}", arg0:  this.<progression>k__BackingField.freeAwardsCollected));
        System.Text.StringBuilder val_9 = val_1.AppendLine(value:  System.String.Format(format:  "award econ tiers {0}", arg0:  this.<econ>k__BackingField.tiers));
        System.Text.StringBuilder val_11 = val_1.AppendLine(value:  System.String.Format(format:  "event completed? {0}", arg0:  0));
        return (string)val_1;
    }
    public bool InExpireInterval()
    {
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = 504464731990392832})) != false)
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28});
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28})) == false)
        {
                return false;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_5.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48});
    }
    public SeasonPassEventHandler.TierData GetTierData(int tierIndex)
    {
        bool val_7;
        bool val_8;
        TierData val_0;
        val_7 = this;
        if((this.<econ>k__BackingField) < tierIndex)
        {
                val_0.tierIndex = 0;
            mem[1152921516689489092] = 0;
            val_0.tier = 0;
            val_0.lvlUnlocked = false;
            val_0.passActive = false;
            val_0.freeCollected = false;
            val_0.passCollected = false;
            val_0.currentTier = false;
            mem[1152921516689489109] = 0;
            return val_0;
        }
        
        if((this.<econ>k__BackingField) <= tierIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_3 = (this.<progression>k__BackingField.currentTier) + (tierIndex << 3);
        val_7 = this.<progression>k__BackingField.freeAwardsCollected.Contains(item:  tierIndex);
        val_8 = this.<progression>k__BackingField.passAwardsCollected.Contains(item:  tierIndex);
        val_0.tierIndex = tierIndex;
        mem[1152921516689489092] = 0;
        val_0.tier = (this.<progression>k__BackingField.currentTier + (tierIndex) << 3) + 32;
        val_0.lvlUnlocked = ((this.<progression>k__BackingField.currentTier) >= tierIndex) ? 1 : 0;
        val_0.passActive = this.<progression>k__BackingField.hasPass;
        val_0.freeCollected = val_7;
        val_0.currentTier = ((this.<progression>k__BackingField.currentTier) == tierIndex) ? 1 : 0;
        val_0.passCollected = val_8;
        mem[1152921516689489111] = 0;
        mem[1152921516689489109] = 0;
        return val_0;
    }
    public string GetChestContent(int itemAward)
    {
        object[] val_1 = new object[6];
        int val_7 = this.<econ>k__BackingField.ChestCoins;
        val_7 = val_7 * itemAward;
        val_1[0] = val_7;
        val_1[1] = Localization.Localize(key:  "coins_meta", defaultValue:  "Coins", useSingularKey:  false);
        int val_8 = this.<econ>k__BackingField.ChestCards;
        val_8 = val_8 * itemAward;
        val_1[2] = val_8;
        val_1[3] = Localization.Localize(key:  "cards_meta", defaultValue:  (itemAward == 1) ? "Card" : "Cards", useSingularKey:  true);
        int val_9 = this.<econ>k__BackingField.ChestApples;
        val_9 = val_9 * itemAward;
        val_1[4] = val_9;
        val_1[5] = Localization.Localize(key:  "golden_apples_cap_first", defaultValue:  "", useSingularKey:  false);
        return (string)System.String.Format(format:  "x{0} {1}\nx{2} {3}\nx{4} {5}", args:  val_1);
    }
    public System.Collections.Generic.List<System.Tuple<SeasonPassEcon.Item, System.Decimal>> ClaimAward(int tierIndex, bool isPass)
    {
        int val_16;
        Item val_17;
        object val_18;
        int val_19;
        int val_20;
        Item val_21;
        int val_22;
        val_16 = isPass;
        this.claimedAwards = new System.Collections.Generic.List<System.Tuple<Item, System.Decimal>>();
        this.petCardAwards = new System.Collections.Generic.List<System.Tuple<WADPets.WADPet, System.Int32>>();
        SeasonPassEcon val_14 = this.<econ>k__BackingField;
        this.petCardsDict = new System.Collections.Generic.Dictionary<WADPets.WADPet, System.Int32>();
        if(val_14 <= tierIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_14 = val_14 + (tierIndex << 3);
        if(val_16 == false)
        {
            goto label_4;
        }
        
        if((this.<progression>k__BackingField.hasPass) == false)
        {
            goto label_6;
        }
        
        val_17 = ((this.<econ>k__BackingField + (tierIndex) << 3).SilverTierLevels) + 16;
        goto label_8;
        label_4:
        val_17 = ((this.<econ>k__BackingField + (tierIndex) << 3).SilverTierLevels) + 24;
        label_8:
        var val_4 = (val_16 != true) ? 20 : 28;
        var val_5 = (val_16 != true) ? 40 : 32;
        val_16 = mem[(this.<econ>k__BackingField + (tierIndex) << 3).SilverTierLevels + val_16 != true ? 20 : 28];
        val_16 = (this.<econ>k__BackingField + (tierIndex) << 3).SilverTierLevels + val_16 != true ? 20 : 28;
        if((1152921504933842944.Contains(item:  tierIndex)) == false)
        {
            goto label_12;
        }
        
        val_18 = "SeasonPassEventHandler: Reward already collected";
        goto label_15;
        label_12:
        1152921504933842944.Add(item:  tierIndex);
        if(val_17 == 5)
        {
                decimal val_8 = System.Decimal.op_Implicit(value:  (this.<econ>k__BackingField.ChestCoins) * val_16);
            this.RewardPlayer(tierIndex:  tierIndex, item:  0, amount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
            decimal val_10 = System.Decimal.op_Implicit(value:  (this.<econ>k__BackingField.ChestApples) * val_16);
            this.RewardPlayer(tierIndex:  tierIndex, item:  4, amount:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid});
            decimal val_12 = System.Decimal.op_Implicit(value:  (this.<econ>k__BackingField.ChestCards) * val_16);
            val_19 = val_12.flags;
            val_20 = val_12.lo;
            val_21 = 1;
            val_22 = tierIndex;
        }
        else
        {
                decimal val_13 = System.Decimal.op_Implicit(value:  val_16);
            val_19 = val_13.flags;
            val_20 = val_13.lo;
            val_22 = tierIndex;
            val_21 = val_17;
        }
        
        this.RewardPlayer(tierIndex:  val_22, item:  val_21, amount:  new System.Decimal() {flags = val_19, hi = val_13.hi, lo = val_20, mid = val_13.mid});
        this.UpdateProgressToServer();
        return (System.Collections.Generic.List<System.Tuple<Item, System.Decimal>>)this.claimedAwards;
        label_6:
        val_18 = "SeasonPassEventHandler: Pass is not active, cannot collect reward";
        label_15:
        UnityEngine.Debug.LogError(message:  val_18);
        return (System.Collections.Generic.List<System.Tuple<Item, System.Decimal>>)this.claimedAwards;
    }
    public System.Collections.Generic.List<System.Tuple<WADPets.WADPet, int>> GetRewardedPetCards()
    {
        return (System.Collections.Generic.List<System.Tuple<WADPets.WADPet, System.Int32>>)this.petCardAwards;
    }
    public void Hack_ResetProgress()
    {
        SeasonPassProgression val_1 = new SeasonPassProgression();
        this.<progression>k__BackingField = val_1;
        val_1.InitEvent(eventId:  1683417024, playerLevel:  App.Player);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "plus_pass", value:  null);
        val_3.Add(key:  "s_level", value:  App.Player);
        val_3.Add(key:  "p_prog", value:  "0");
        val_3.Add(key:  "f_prog", value:  "0");
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_3);
    }
    private void UpdateHintDiscounts()
    {
        UnityEngine.Object val_14 = this;
        if(SceneDictator.IsInGameScene() == false)
        {
                return;
        }
        
        if((this.<progression>k__BackingField.hasPass) == false)
        {
                return;
        }
        
        if((MonoSingleton<HintFeatureManager>.Instance) != 0)
        {
                HintFeatureManager val_4 = MonoSingleton<HintFeatureManager>.Instance;
            if((val_4.<wgHbutton>k__BackingField) != 0)
        {
                HintFeatureManager val_6 = MonoSingleton<HintFeatureManager>.Instance;
            val_6.<wgHbutton>k__BackingField.UpdateDisplay();
        }
        
        }
        
        val_14 = MonoSingleton<HintPickerController>.Instance;
        if(val_14 == 0)
        {
                return;
        }
        
        HintPickerController val_9 = MonoSingleton<HintPickerController>.Instance;
        val_14 = val_9.gameHintPickerButton;
        if(val_14 == 0)
        {
                return;
        }
        
        HintPickerController val_11 = MonoSingleton<HintPickerController>.Instance;
        val_14 = val_11.gameHintPickerButton.GetComponent<WGHintPickerButton>();
        if(val_14 == 0)
        {
                return;
        }
        
        val_14.UpdateDisplay();
    }
    private void UpdateProgressToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "plus_pass", value:  this.<progression>k__BackingField.hasPass);
        val_1.Add(key:  "s_level", value:  this.<progression>k__BackingField.initLevel);
        val_1.Add(key:  "p_prog", value:  this.<progression>k__BackingField.EncodeProgression(pass:  true));
        val_1.Add(key:  "f_prog", value:  this.<progression>k__BackingField.EncodeProgression(pass:  false));
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_28;
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        if((eventData.ContainsKey(key:  "progress")) != false)
        {
                object val_3 = eventData.Item["progress"];
            if((val_3.ContainsKey(key:  "plus_pass")) != false)
        {
                bool val_7 = System.Boolean.TryParse(value:  val_3.Item["plus_pass"], result: out  this.<progression>k__BackingField.hasPass);
        }
        
            if((val_3.ContainsKey(key:  "s_level")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_3.Item["s_level"], result: out  this.<progression>k__BackingField.initLevel);
        }
        
            if((val_3.ContainsKey(key:  "p_prog")) != false)
        {
                this.<progression>k__BackingField.DecodeProgression(pass:  true, progression:  val_3.Item["p_prog"]);
        }
        
            if((val_3.ContainsKey(key:  "f_prog")) != false)
        {
                this.<progression>k__BackingField.DecodeProgression(pass:  false, progression:  val_3.Item["f_prog"]);
        }
        
        }
        
        val_28 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_28 = 1152921510214912464;
        object val_17 = eventData.Item["economy"];
        if((val_17.ContainsKey(key:  "pp_phd")) != false)
        {
                bool val_21 = System.Int32.TryParse(s:  val_17.Item["pp_phd"], result: out  this.<econ>k__BackingField.PassPickerHintDiscount);
        }
        
        if((val_17.ContainsKey(key:  "pp_hd")) != false)
        {
                bool val_25 = System.Int32.TryParse(s:  val_17.Item["pp_hd"], result: out  this.<econ>k__BackingField.PassHintDiscount);
        }
        
        if((val_17.ContainsKey(key:  "s_name")) == false)
        {
                return;
        }
        
        this._uniqueSeasonName = val_17.Item["s_name"];
    }
    private void RewardPlayer(int tierIndex, SeasonPassEcon.Item item, decimal amount)
    {
        int val_14 = amount.flags;
        string val_1 = "Season Event Reward Tier " + tierIndex;
        if(item <= 4)
        {
                var val_14 = 32561612 + (item) << 2;
            val_14 = val_14 + 32561612;
        }
        else
        {
                this.claimedAwards.Add(item:  new System.Tuple<Item, System.Decimal>(item1:  item, item2:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}));
        }
    
    }
    private void RewardPetCards(int amount, string subSource)
    {
        System.Collections.Generic.Dictionary<WADPets.WADPet, System.Int32> val_10;
        WADPets.WADPet val_11;
        if(amount >= 1)
        {
                var val_10 = 0;
            do
        {
            WADPetsManager val_1 = MonoSingleton<WADPetsManager>.Instance;
            if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
            val_11 = 0;
            WADPets.WADPet val_2 = val_1.GetRandomPet();
            if(this.petCardsDict == null)
        {
                throw new NullReferenceException();
        }
        
            val_10 = this.petCardsDict;
            val_11 = val_2;
            if(this.petCardsDict == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_10.ContainsKey(key:  val_11)) != false)
        {
                val_11 = val_2;
            this.petCardsDict.set_Item(key:  val_11, value:  this.petCardsDict.Item[val_2] + 1);
        }
        else
        {
                val_11 = val_2;
            this.petCardsDict.Add(key:  val_11, value:  1);
        }
        
            val_10 = val_10 + 1;
        }
        while(val_10 < amount);
        
        }
        
        val_10 = this.petCardsDict;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_6 = val_10.GetEnumerator();
        label_16:
        if(0.MoveNext() == false)
        {
            goto label_11;
        }
        
        System.Tuple<WADPets.WADPet, System.Int32> val_8 = null;
        val_11 = 0;
        val_8 = new System.Tuple<WADPets.WADPet, System.Int32>(item1:  val_11, item2:  0);
        if(this.petCardAwards == null)
        {
                throw new NullReferenceException();
        }
        
        this.petCardAwards.Add(item:  val_8);
        MonoSingleton<WADPetsManager>.Instance.RewardPetCards(amount:  0, pet:  0, source:  "Season Event", subsource:  subSource, additionalParam:  0);
        goto label_16;
        label_11:
        0.Dispose();
    }
    public SeasonPassEventHandler()
    {
    
    }

}
