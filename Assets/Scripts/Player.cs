using UnityEngine;
public class Player : ScriptableObject
{
    // Fields
    public bool isNew;
    private bool <forceUpdateFromServer>k__BackingField;
    private decimal prevBalance;
    private bool playerCreated;
    private bool playerLoaded;
    public bool adExcludedNetworkPurchaser;
    public int totalRevenue;
    protected string country;
    protected PlayerProperties properties;
    public string id;
    public string uuid;
    public string support;
    protected decimal _credits;
    protected int _stars;
    protected int _monthlyStars;
    protected int _bonusRewardPoints;
    protected int _food;
    private bool synchedGoldenCurrency;
    protected int _gems;
    protected decimal _experience;
    public System.DateTime created_at;
    public string playerBucket;
    private const string key_created = "player_client_created";
    public int clientCreated;
    protected int _level;
    public int dcStars;
    public System.DateTime last_daily_credits;
    public int last_daily_amount;
    public int no_ads;
    protected int restoredTransactions;
    protected int lifetimePlays;
    protected string email;
    public System.DateTime last_purchase;
    public string max_item_purchased;
    public string last_item_purchased;
    public float lastItemPrice;
    protected int levelsRemoved;
    public string network_purchaser;
    protected float total_purchased;
    protected int num_purchase;
    protected int num_ad_clicks;
    protected float transactionsAverageAmount;
    protected decimal totalFreeCreditsCollected;
    protected float _avg_hours_played;
    protected string _challengeData;
    protected float lastPurchasePrice;
    protected bool samePurchases;
    protected bool isHacker;
    protected string hackerType;
    protected bool isTroll;
    protected System.Collections.Generic.Dictionary<string, string> promotedGames;
    protected System.Collections.Generic.Dictionary<string, System.Decimal> playerStats;
    public bool IsLapsingPurchaser;
    public bool IsLapsingNonPurchaser;
    public System.Action<int> OnCreditsGained;
    public const string hacker_purchase = "Purchase Fraud";
    public const string hacker_time_traveler = "Time Traveler";
    public System.Collections.Generic.List<string> QAHACK_FreeCoinsTrace;
    public System.Collections.Generic.List<string> QAHACK_NonCoinsAwardTrace;
    private static System.Collections.Generic.List<string> NotFreeCreditSources;
    
    // Properties
    public bool forceUpdateFromServer { get; set; }
    public bool networkPurchaserExcludedFromAds { get; }
    public int TotalRevenue { get; set; }
    public string Country { get; set; }
    public PlayerProperties Properties { get; set; }
    public decimal credits { get; }
    public int stars { get; set; }
    public int monthlyStars { get; set; }
    public int bonusRewardPoints { get; set; }
    public int food { get; }
    public bool SynchedGoldenCurrency { get; set; }
    public int gems { get; }
    public decimal experience { get; set; }
    public virtual int level { get; set; }
    public bool RemovedAds { get; set; }
    public bool RestoredTransactions { get; set; }
    public int LifetimePlays { get; set; }
    public string Email { get; set; }
    public string MaxItemPurchased { get; set; }
    public string LastItemPurchased { get; set; }
    public float LastItemPrice { get; set; }
    public int LevelsRemoved { get; set; }
    public bool NetworkPurchaser { get; }
    public float TotalPurchase { get; set; }
    public int NumPurchase { get; set; }
    public int NumAdClicks { get; set; }
    public float TransactionsAverageAmount { get; set; }
    public decimal TotalFreeCreditsCollected { get; set; }
    public float avg_hours_btween_played { get; set; }
    public string challengeData { get; set; }
    public float MaxPurchasePrice { get; set; }
    public bool SamePurchases { get; set; }
    public bool IsHacker { get; }
    public string HackerType { get; }
    public bool IsTroll { get; }
    protected string network_promo_json { get; }
    public System.Collections.Generic.Dictionary<string, string> PromotedGames { get; }
    protected string playerStats_json { get; }
    public System.Collections.Generic.Dictionary<string, System.Decimal> PLAYER_STATS { get; set; }
    
    // Methods
    public void Initialize()
    {
        this.Load();
    }
    public bool get_forceUpdateFromServer()
    {
        return (bool)this.<forceUpdateFromServer>k__BackingField;
    }
    public void set_forceUpdateFromServer(bool value)
    {
        this.<forceUpdateFromServer>k__BackingField = value;
    }
    public bool get_networkPurchaserExcludedFromAds()
    {
        var val_3;
        if(this.NetworkPurchaser != false)
        {
                var val_2 = (this.adExcludedNetworkPurchaser == true) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public int get_TotalRevenue()
    {
        return (int)this.totalRevenue;
    }
    public void set_TotalRevenue(int value)
    {
        this.totalRevenue = value;
    }
    public string get_Country()
    {
        if((System.String.IsNullOrEmpty(value:  this.country)) == false)
        {
                return (string)this.country;
        }
        
        if((System.String.IsNullOrEmpty(value:  DeviceIdPlugin.GetCountry())) == true)
        {
                return (string)this.country;
        }
        
        this.country = DeviceIdPlugin.GetCountry();
        return (string)this.country;
    }
    public void set_Country(string value)
    {
        this.country = value;
    }
    public PlayerProperties get_Properties()
    {
        return (PlayerProperties)this.properties;
    }
    public void set_Properties(PlayerProperties value)
    {
        this.properties = value;
    }
    private decimal ParseCredits()
    {
        decimal val_2 = System.Decimal.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "player_credits"));
        return new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid};
    }
    private decimal ParseExperience()
    {
        decimal val_2 = System.Decimal.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "player_experience"));
        return new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid};
    }
    private void ParsePlayerStats(System.Collections.IDictionary definition)
    {
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_5;
        var val_6;
        string val_7;
        if(definition == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Decimal> val_1 = null;
        val_5 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Decimal>();
        this.playerStats = val_5;
        Dictionary.Enumerator<TKey, TValue> val_2 = definition.GetEnumerator();
        label_9:
        val_6 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_7 = 0;
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_7 = val_7;
        val_6 = 0;
        decimal val_4 = System.Decimal.Parse(s:  val_7);
        if(this.playerStats == null)
        {
                throw new NullReferenceException();
        }
        
        this.playerStats.Add(key:  0, value:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        goto label_9;
        label_4:
        0.Dispose();
    }
    private void ParseNetworkPromo(System.Collections.IDictionary objects)
    {
        System.Collections.Generic.Dictionary<System.String, System.String> val_4;
        var val_5;
        if(objects == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = null;
        val_4 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        this.promotedGames = val_4;
        Dictionary.Enumerator<TKey, TValue> val_2 = objects.GetEnumerator();
        label_7:
        val_5 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_5 = mem[282584257677031];
        if(this.promotedGames == null)
        {
                throw new NullReferenceException();
        }
        
        this.promotedGames.Add(key:  0, value:  0);
        goto label_7;
        label_4:
        0.Dispose();
    }
    public decimal get_credits()
    {
        return new System.Decimal() {flags = this._credits, hi = this._credits};
    }
    public int get_stars()
    {
        return (int)this._stars;
    }
    public void set_stars(int value)
    {
        UnityEngine.Object val_9;
        UnityEngine.Object val_10;
        this._stars = value;
        val_9 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
        val_10 = 0;
        if(val_9 != val_10)
        {
                val_9 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_10 = 0;
            if(val_9 != val_10)
        {
                val_10 = 0;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyProfile != null)
        {
                val_10 = 0;
            SLC.Social.Profile val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_8.goldenCurrency = value;
        }
        
        }
        
        }
    
    }
    public int get_monthlyStars()
    {
        return (int)this._monthlyStars;
    }
    public void set_monthlyStars(int value)
    {
        this._monthlyStars = value;
        goto typeof(Player).__il2cppRuntimeField_190;
    }
    public int get_bonusRewardPoints()
    {
        return (int)this._bonusRewardPoints;
    }
    public void set_bonusRewardPoints(int value)
    {
        this._bonusRewardPoints = value;
    }
    public int get_food()
    {
        return (int)this._food;
    }
    public bool get_SynchedGoldenCurrency()
    {
        return (bool)this.synchedGoldenCurrency;
    }
    public void set_SynchedGoldenCurrency(bool value)
    {
        this.synchedGoldenCurrency = value;
        if(value == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "player_synched_gc", value:  10);
    }
    public int get_gems()
    {
        return (int)this._gems;
    }
    public decimal get_experience()
    {
        return new System.Decimal() {flags = this._experience, hi = this._experience};
    }
    public void set_experience(decimal value)
    {
        this._experience = value;
        mem[1152921515605600672] = value.lo;
        mem[1152921515605600676] = value.mid;
    }
    public virtual int get_level()
    {
        return (int)this._level;
    }
    public virtual void set_level(int value)
    {
        this._level = value;
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
    }
    public bool get_RemovedAds()
    {
        return (bool)(this.no_ads == 2) ? 1 : 0;
    }
    public void set_RemovedAds(bool value)
    {
        if(this != null)
        {
                this.no_ads = (value != true) ? (1 + 1) : 1;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_RestoredTransactions()
    {
        return (bool)(this.restoredTransactions == 1) ? 1 : 0;
    }
    public void set_RestoredTransactions(bool value)
    {
        if(this != null)
        {
                this.restoredTransactions = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public int get_LifetimePlays()
    {
        return (int)this.lifetimePlays;
    }
    public void set_LifetimePlays(int value)
    {
        this.lifetimePlays = value;
    }
    public string get_Email()
    {
        return (string)this.email;
    }
    public void set_Email(string value)
    {
        this.email = value;
    }
    public string get_MaxItemPurchased()
    {
        return (string)this.max_item_purchased;
    }
    public void set_MaxItemPurchased(string value)
    {
        this.max_item_purchased = value;
    }
    public string get_LastItemPurchased()
    {
        return (string)this.last_item_purchased;
    }
    public void set_LastItemPurchased(string value)
    {
        this.last_item_purchased = value;
    }
    public float get_LastItemPrice()
    {
        return (float)this.lastItemPrice;
    }
    public void set_LastItemPrice(float value)
    {
        this.lastItemPrice = value;
    }
    public int get_LevelsRemoved()
    {
        return (int)this.levelsRemoved;
    }
    public void set_LevelsRemoved(int value)
    {
        this.levelsRemoved = value;
    }
    public bool get_NetworkPurchaser()
    {
        return this.network_purchaser.Equals(value:  "true");
    }
    public float get_TotalPurchase()
    {
        return (float)this.total_purchased;
    }
    public void set_TotalPurchase(float value)
    {
        this.total_purchased = value;
    }
    public int get_NumPurchase()
    {
        return (int)this.num_purchase;
    }
    public void set_NumPurchase(int value)
    {
        this.num_purchase = value;
    }
    public int get_NumAdClicks()
    {
        return (int)this.num_ad_clicks;
    }
    public void set_NumAdClicks(int value)
    {
        this.num_ad_clicks = value;
    }
    public float get_TransactionsAverageAmount()
    {
        return (float)this.transactionsAverageAmount;
    }
    public void set_TransactionsAverageAmount(float value)
    {
        this.transactionsAverageAmount = value;
    }
    public decimal get_TotalFreeCreditsCollected()
    {
        return new System.Decimal() {flags = this.totalFreeCreditsCollected, hi = this.totalFreeCreditsCollected};
    }
    public void set_TotalFreeCreditsCollected(decimal value)
    {
        this.totalFreeCreditsCollected = value;
        mem[1152921515608906232] = value.lo;
        mem[1152921515608906236] = value.mid;
    }
    public float get_avg_hours_btween_played()
    {
        return (float)this._avg_hours_played;
    }
    public void set_avg_hours_btween_played(float value)
    {
        this._avg_hours_played = value;
    }
    public string get_challengeData()
    {
        return (string)this._challengeData;
    }
    public void set_challengeData(string value)
    {
        this._challengeData = value;
    }
    public float get_MaxPurchasePrice()
    {
        return (float)this.lastPurchasePrice;
    }
    public void set_MaxPurchasePrice(float value)
    {
        this.lastPurchasePrice = value;
    }
    public bool get_SamePurchases()
    {
        return (bool)this.samePurchases;
    }
    public void set_SamePurchases(bool value)
    {
        this.samePurchases = value;
    }
    public bool get_IsHacker()
    {
        return (bool)this.isHacker;
    }
    public string get_HackerType()
    {
        return (string)this.hackerType;
    }
    public bool get_IsTroll()
    {
        return (bool)this.isTroll;
    }
    protected string get_network_promo_json()
    {
        return MiniJSON.Json.Serialize(obj:  this.promotedGames);
    }
    public System.Collections.Generic.Dictionary<string, string> get_PromotedGames()
    {
        System.Collections.Generic.Dictionary<System.String, System.String> val_2 = this.promotedGames;
        if(val_2 != null)
        {
                return val_2;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = null;
        val_2 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        this.promotedGames = val_2;
        return val_2;
    }
    protected string get_playerStats_json()
    {
        return MiniJSON.Json.Serialize(obj:  this.playerStats);
    }
    public System.Collections.Generic.Dictionary<string, System.Decimal> get_PLAYER_STATS()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Decimal>)this.playerStats;
    }
    public void set_PLAYER_STATS(System.Collections.Generic.Dictionary<string, System.Decimal> value)
    {
        this.playerStats = value;
    }
    public virtual void SoftSave()
    {
        UnityEngine.Debug.LogError(message:  "Virtual SoftSave() called on base Player class");
    }
    protected virtual void Save()
    {
        UnityEngine.Debug.LogError(message:  "Virtual Save() called on base Player class");
    }
    public virtual void AddHardSaves(ref System.Collections.Generic.Dictionary<string, object> incDic)
    {
        UnityEngine.Debug.LogError(message:  "Virtual AddHardSaves(ref dictionary) called on base Player class");
    }
    public void SaveState()
    {
        this.properties.Save(writePrefs:  false);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void UpdateData(System.Collections.IDictionary diff)
    {
        var val_28;
        var val_29;
        var val_30;
        var val_33;
        var val_34;
        var val_36;
        var val_38;
        var val_39;
        var val_41;
        var val_43;
        var val_44;
        var val_46;
        var val_47;
        var val_49;
        var val_51;
        var val_52;
        var val_54;
        var val_56;
        var val_57;
        var val_59;
        object val_60;
        var val_62;
        var val_42 = 0;
        val_42 = val_42 + 1;
        val_28 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "id")) != false)
        {
                val_29 = 0;
            if((System.String.op_Equality(a:  this.id, b:  " ")) != false)
        {
                var val_43 = 0;
            val_43 = val_43 + 1;
            val_30 = 0;
            val_28 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.id = diff.Item["id"];
        }
        
        }
        
        var val_44 = 0;
        val_44 = val_44 + 1;
        val_28 = 4;
        val_33 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "support")) != false)
        {
                var val_45 = 0;
            val_45 = val_45 + 1;
            val_34 = 0;
            val_36 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.support = diff.Item["support"];
        }
        
        var val_46 = 0;
        val_46 = val_46 + 1;
        val_36 = 4;
        val_38 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "hacker")) != false)
        {
                var val_47 = 0;
            val_47 = val_47 + 1;
            val_39 = 0;
            val_41 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.isHacker = System.Boolean.Parse(value:  diff.Item["hacker"]);
        }
        
        var val_48 = 0;
        val_48 = val_48 + 1;
        val_41 = 4;
        val_43 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "hacker_type")) != false)
        {
                var val_49 = 0;
            val_49 = val_49 + 1;
            val_44 = 0;
            val_46 = public System.Object System.Collections.IDictionary::get_Item(object key);
            if(diff.Item["hacker_type"] != null)
        {
                var val_50 = 0;
            val_50 = val_50 + 1;
            val_47 = 0;
            val_49 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.hackerType = diff.Item["hacker_type"];
        }
        
        }
        
        var val_51 = 0;
        val_51 = val_51 + 1;
        val_49 = 4;
        val_51 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "troll")) != false)
        {
                var val_52 = 0;
            val_52 = val_52 + 1;
            val_52 = 0;
            val_54 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.isTroll = System.Boolean.Parse(value:  diff.Item["troll"]);
        }
        
        var val_53 = 0;
        val_53 = val_53 + 1;
        val_54 = 4;
        val_56 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "network_purchaser")) != false)
        {
                var val_54 = 0;
            val_54 = val_54 + 1;
            val_57 = 0;
            val_59 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.network_purchaser = diff.Item["network_purchaser"].ToLower();
        }
        
        val_60 = "client_upgrade";
        var val_55 = 0;
        val_55 = val_55 + 1;
        val_59 = 4;
        val_62 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  val_60)) != false)
        {
                var val_56 = 0;
            val_56 = val_56 + 1;
            val_62 = 0;
            val_60 = diff.Item["client_upgrade"];
            if((System.Boolean.Parse(value:  val_60)) != false)
        {
                UnityEngine.Debug.Log(message:  "Player: Client Update Found");
            val_60 = 1152921504888582144;
            if(((DeviceIdPlugin.GetClientVersion().Equals(value:  "1.113")) != false) && (this.total_purchased > 0f))
        {
                AdsManager.AddAdsWatchedFromVersionUpdate();
        }
        else
        {
                if(((DeviceIdPlugin.GetClientVersion().Equals(value:  "1.123")) != false) && (this.total_purchased > 0f))
        {
                AdsManager.AddPurchaseCooldownFromVersionUpdate();
        }
        
        }
        
        }
        
        }
        
        this.properties.UpdateData(diff:  diff);
        goto typeof(Player).__il2cppRuntimeField_1C0;
    }
    public System.Collections.Generic.Dictionary<string, object> Encode()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "experience_bind", value:  this._experience.ToString(format:  "0"));
        val_1.Add(key:  "google_ad_id", value:  DeviceIdPlugin.GetGoogleAdId());
        val_1.Add(key:  "client_version", value:  DeviceIdPlugin.GetClientVersion());
        if((System.String.IsNullOrEmpty(value:  this.Country)) != true)
        {
                val_1.Add(key:  "country", value:  this.Country);
        }
        
        val_1.Add(key:  "email", value:  this.email);
        if((UnityEngine.PlayerPrefs.HasKey(key:  "player_got_free_item")) != false)
        {
                val_1.Add(key:  "free_item", value:  1);
        }
        
        this.properties.mySaver.AddHardSavesToDictionary(refdic: ref  val_1);
        this.properties.Encode(jsonPlayer: ref  val_1);
        return val_1;
    }
    private void Load()
    {
        var val_2;
        var val_3;
        if((UnityEngine.PlayerPrefs.GetInt(key:  "player_client_created", defaultValue:  0)) >= 1)
        {
                val_3 = 0;
        }
        else
        {
                val_2 = " ";
            val_3 = 1;
        }
        
        this.CreateCustomProperties(isPlayerNew:  true);
        this.SaveState();
        goto typeof(Player).__il2cppRuntimeField_190;
    }
    protected virtual void ProcessRemainingAttributes(System.Collections.IDictionary diff)
    {
        var val_13;
        object val_14;
        var val_16;
        var val_18;
        var val_19;
        var val_21;
        val_13 = this;
        val_14 = "level";
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_16 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  val_14)) == false)
        {
                return;
        }
        
        val_14 = "override_user_data";
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_16 = 4;
        val_18 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  val_14)) == false)
        {
            goto label_19;
        }
        
        var val_18 = 0;
        val_18 = val_18 + 1;
        val_19 = 0;
        val_21 = public System.Object System.Collections.IDictionary::get_Item(object key);
        val_14 = diff.Item["override_user_data"];
        if((System.Boolean.Parse(value:  val_14)) == false)
        {
            goto label_19;
        }
        
        goto label_20;
        label_19:
        if((this.<forceUpdateFromServer>k__BackingField) == false)
        {
            goto label_21;
        }
        
        this.<forceUpdateFromServer>k__BackingField = false;
        label_20:
        val_13 = ???;
        val_14 = ???;
        goto typeof(Player).__il2cppRuntimeField_1D0;
        label_21:
        if((val_13 & 1) == 0)
        {
                return;
        }
    
    }
    protected virtual void TrustServerData(System.Collections.IDictionary diff)
    {
        var val_62;
        var val_63;
        var val_65;
        var val_66;
        var val_68;
        var val_70;
        var val_71;
        var val_73;
        var val_74;
        var val_76;
        var val_78;
        var val_79;
        var val_81;
        var val_83;
        var val_84;
        var val_86;
        var val_88;
        var val_89;
        var val_90;
        int val_92;
        var val_93;
        var val_95;
        var val_96;
        System.Globalization.NumberStyles val_98;
        string val_99;
        var val_100;
        var val_102;
        var val_103;
        var val_105;
        var val_107;
        var val_108;
        var val_110;
        var val_111;
        var val_113;
        var val_115;
        var val_116;
        var val_118;
        var val_120;
        var val_121;
        var val_123;
        var val_125;
        var val_126;
        var val_128;
        var val_130;
        var val_131;
        var val_133;
        var val_135;
        var val_136;
        var val_138;
        var val_140;
        var val_2 = (diff == 0) ? 0 : (this);
        if(diff != null)
        {
                int val_4 = System.Int32.Parse(s:  diff);
        }
        
        var val_6 = (diff == 0) ? 0 : (this);
        if(diff != null)
        {
                decimal val_8 = System.Decimal.Parse(s:  diff, style:  511);
        }
        
        mem2[0] = val_8.flags;
        mem[4] = val_8.hi;
        mem2[0] = val_8.lo;
        mem[4] = val_8.mid;
        val_62 = mem[val_8.flags + 8];
        val_62 = val_8.flags + 8;
        if(diff != null)
        {
                var val_92 = 0;
            val_92 = val_92 + 1;
            val_63 = 0;
            val_65 = public System.Object System.Collections.IDictionary::get_Item(object key);
            if((System.Int32.Parse(s:  diff.Item["stars"])) > this._stars)
        {
                var val_93 = 0;
            val_93 = val_93 + 1;
            val_66 = 0;
            val_68 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this._stars = System.Int32.Parse(s:  diff.Item["stars"]);
        }
        
        }
        
        var val_94 = 0;
        val_94 = val_94 + 1;
        val_68 = 0;
        val_70 = public System.Object System.Collections.IDictionary::get_Item(object key);
        if(diff.Item["bonus_reward_points"] != null)
        {
                var val_95 = 0;
            val_95 = val_95 + 1;
            val_71 = 0;
            val_73 = public System.Object System.Collections.IDictionary::get_Item(object key);
            if((System.Int32.Parse(s:  diff.Item["bonus_reward_points"])) > this._bonusRewardPoints)
        {
                var val_96 = 0;
            val_96 = val_96 + 1;
            val_74 = 0;
            val_76 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this._bonusRewardPoints = System.Int32.Parse(s:  diff.Item["bonus_reward_points"]);
        }
        
        }
        
        var val_97 = 0;
        val_97 = val_97 + 1;
        val_76 = 0;
        val_78 = public System.Object System.Collections.IDictionary::get_Item(object key);
        if(diff.Item["gems"] != null)
        {
                var val_98 = 0;
            val_98 = val_98 + 1;
            val_79 = 0;
            val_81 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this._gems = System.Int32.Parse(s:  diff.Item["gems"]);
        }
        
        var val_99 = 0;
        val_99 = val_99 + 1;
        val_81 = 0;
        val_83 = public System.Object System.Collections.IDictionary::get_Item(object key);
        if(diff.Item["pet_food"] != null)
        {
                var val_100 = 0;
            val_100 = val_100 + 1;
            val_84 = 0;
            val_86 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this._food = System.Int32.Parse(s:  diff.Item["pet_food"]);
        }
        
        var val_101 = 0;
        val_101 = val_101 + 1;
        val_86 = 0;
        val_88 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_35 = diff.Item["dc_stars"];
        var val_36 = (val_35 == 0) ? 0 : (this);
        if(val_35 == null)
        {
            goto label_84;
        }
        
        var val_102 = 0;
        val_102 = val_102 + 1;
        val_90 = 0;
        goto label_88;
        label_84:
        val_92 = this.dcStars;
        val_89 = this;
        goto label_89;
        label_88:
        val_93 = public System.Object System.Collections.IDictionary::get_Item(object key);
        val_92 = diff;
        label_89:
        mem2[0] = System.Int32.Parse(s:  val_92.Item["dc_stars"]);
        var val_103 = 0;
        val_103 = val_103 + 1;
        val_93 = 4;
        val_95 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "experience_bind")) == false)
        {
            goto label_96;
        }
        
        var val_104 = 0;
        val_104 = val_104 + 1;
        val_96 = 0;
        goto label_100;
        label_96:
        val_98 = 0;
        val_99 = 0;
        goto label_101;
        label_100:
        val_98 = 511;
        val_99 = diff.Item["experience_bind"];
        val_100 = 0;
        decimal val_44 = System.Decimal.Parse(s:  val_99, style:  val_98);
        label_101:
        this._experience = val_44;
        mem[1152921515612006624] = val_44.lo;
        mem[1152921515612006628] = val_44.mid;
        var val_105 = 0;
        val_105 = val_105 + 1;
        val_100 = 0;
        val_102 = public System.Object System.Collections.IDictionary::get_Item(object key);
        if(diff.Item["total_purchase"] != null)
        {
                var val_106 = 0;
            val_106 = val_106 + 1;
            val_103 = 0;
            val_105 = 0;
            float val_50 = System.Single.Parse(s:  diff.Item["total_purchase"], provider:  System.Globalization.CultureInfo.InvariantCulture);
            if(val_50 > this.total_purchased)
        {
                this.total_purchased = val_50;
        }
        
        }
        
        var val_107 = 0;
        val_107 = val_107 + 1;
        val_105 = 4;
        val_107 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "lifetime_plays")) == false)
        {
            goto label_122;
        }
        
        var val_108 = 0;
        val_108 = val_108 + 1;
        val_108 = 0;
        goto label_126;
        label_122:
        val_110 = 0;
        goto label_127;
        label_126:
        val_111 = public System.Object System.Collections.IDictionary::get_Item(object key);
        val_110 = System.Int32.Parse(s:  diff.Item["lifetime_plays"]);
        label_127:
        if(val_110 > this.lifetimePlays)
        {
                val_111 = 0;
            this.lifetimePlays = System.Math.Min(val1:  val_110 + 1, val2:  2147483646);
        }
        
        var val_109 = 0;
        val_109 = val_109 + 1;
        val_111 = 4;
        val_113 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "free_item")) != false)
        {
                val_113 = 0;
            UnityEngine.PlayerPrefs.SetInt(key:  "player_got_free_item", value:  1);
        }
        
        var val_110 = 0;
        val_110 = val_110 + 1;
        val_113 = 4;
        val_115 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "no_ads")) != false)
        {
                var val_111 = 0;
            val_111 = val_111 + 1;
            val_116 = 0;
            val_118 = public System.Object System.Collections.IDictionary::get_Item(object key);
            int val_64 = System.Int32.Parse(s:  diff.Item["no_ads"]);
            if(val_64 >= 2)
        {
                this.no_ads = val_64;
        }
        
        }
        
        var val_112 = 0;
        val_112 = val_112 + 1;
        val_118 = 4;
        val_120 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "same_purchases")) != false)
        {
                var val_113 = 0;
            val_113 = val_113 + 1;
            val_121 = 0;
            val_123 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.samePurchases = System.Boolean.Parse(value:  diff.Item["same_purchases"]);
        }
        
        var val_114 = 0;
        val_114 = val_114 + 1;
        val_123 = 4;
        val_125 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "challenge_data")) != false)
        {
                var val_115 = 0;
            val_115 = val_115 + 1;
            val_126 = 0;
            val_128 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this._challengeData = diff.Item["challenge_data"];
        }
        
        var val_116 = 0;
        val_116 = val_116 + 1;
        val_128 = 4;
        val_130 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "email")) != false)
        {
                var val_117 = 0;
            val_117 = val_117 + 1;
            val_131 = 0;
            val_133 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.email = diff.Item["email"];
        }
        
        var val_118 = 0;
        val_118 = val_118 + 1;
        val_133 = 4;
        val_135 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "last_purchase")) != false)
        {
                var val_119 = 0;
            val_119 = val_119 + 1;
            val_136 = 0;
            decimal val_83 = System.Decimal.Parse(s:  diff.Item["last_purchase"]);
            val_138 = 0;
            System.DateTime val_84 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_83.flags, hi = val_83.hi, lo = val_83.lo, mid = val_83.mid});
            this.last_purchase = val_84;
        }
        
        var val_120 = 0;
        val_120 = val_120 + 1;
        val_138 = 4;
        val_140 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "num_purchases")) != false)
        {
                var val_121 = 0;
            val_121 = val_121 + 1;
            val_140 = 0;
            this.num_purchase = System.Int32.Parse(s:  diff.Item["num_purchases"]);
        }
        
        this.properties.TrustServerData(diff:  diff);
        this.SaveState();
        NotificationCenter.DefaultCenter.PostNotificationDelayed(aSender:  0, aName:  "TrustingServerData", aData:  new System.Collections.Hashtable(), delay:  3f);
    }
    protected virtual void LoadFromLocal()
    {
        this.id = UnityEngine.PlayerPrefs.GetString(key:  "player_id");
        this.uuid = UnityEngine.PlayerPrefs.GetString(key:  "player_uuid");
        string val_3 = UnityEngine.PlayerPrefs.GetString(key:  "player_support", defaultValue:  "00-00-00");
        this.support = val_3;
        decimal val_4 = val_3.ParseCredits();
        this._credits = val_4;
        mem[1152921515612336728] = val_4.lo;
        mem[1152921515612336732] = val_4.mid;
        this._stars = UnityEngine.PlayerPrefs.GetInt(key:  "player_stars", defaultValue:  0);
        GameEcon val_6 = App.getGameEcon;
        this._gems = UnityEngine.PlayerPrefs.GetInt(key:  "player_gems", defaultValue:  val_6.InitialPlayerGems);
        this._food = UnityEngine.PlayerPrefs.GetInt(key:  "player_pet_food", defaultValue:  10);
        int val_9 = UnityEngine.PlayerPrefs.GetInt(key:  "bonusRewardPoints", defaultValue:  0);
        this._bonusRewardPoints = val_9;
        decimal val_10 = val_9.ParseExperience();
        this._experience = val_10;
        mem[1152921515612336768] = val_10.lo;
        mem[1152921515612336772] = val_10.mid;
        System.DateTime val_12 = System.DateTime.UtcNow;
        System.DateTime val_13 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "player_created_at"), defaultValue:  new System.DateTime() {dateData = val_12.dateData});
        this.created_at = val_13;
        this.playerBucket = UnityEngine.PlayerPrefs.GetString(key:  "player_bucket", defaultValue:  ((UnityEngine.Random.Range(min:  1, max:  11)) < 6) ? "A" : "B");
        System.DateTime val_18 = System.DateTime.UtcNow;
        System.DateTime val_19 = val_18.dateData.AddDays(value:  -1);
        System.DateTime val_20 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "player_last_daily_credits"), defaultValue:  new System.DateTime() {dateData = val_19.dateData});
        this.last_daily_credits = val_20;
        this.clientCreated = UnityEngine.PlayerPrefs.GetInt(key:  "player_client_created");
        int val_22 = UnityEngine.PlayerPrefs.GetInt(key:  "player_level", defaultValue:  1);
        this.dcStars = UnityEngine.PlayerPrefs.GetInt(key:  "dc_stars");
        this.no_ads = UnityEngine.PlayerPrefs.GetInt(key:  "player_no_ads", defaultValue:  1);
        this.restoredTransactions = UnityEngine.PlayerPrefs.GetInt(key:  "player_restored_transactions", defaultValue:  0);
        this.lifetimePlays = System.Math.Min(val1:  (UnityEngine.PlayerPrefs.GetInt(key:  "player_lifetime_plays", defaultValue:  0)) + 1, val2:  2147483646);
        this.last_daily_amount = UnityEngine.PlayerPrefs.GetInt(key:  "player_last_daily_amount", defaultValue:  0);
        this.email = UnityEngine.PlayerPrefs.GetString(key:  "player_email", defaultValue:  "");
        System.DateTime val_32 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "player_last_purchase"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        this.last_purchase = val_32;
        this.max_item_purchased = UnityEngine.PlayerPrefs.GetString(key:  "player_max_item_purchased");
        this.last_item_purchased = UnityEngine.PlayerPrefs.GetString(key:  "player_last_item_purchased");
        this.lastItemPrice = UnityEngine.PlayerPrefs.GetFloat(key:  "player_last_item_price", defaultValue:  0f);
        this.levelsRemoved = UnityEngine.PlayerPrefs.GetInt(key:  "player_levels_removed", defaultValue:  0);
        this.network_purchaser = UnityEngine.PlayerPrefs.GetString(key:  "network_purchaser", defaultValue:  "false");
        this.total_purchased = UnityEngine.PlayerPrefs.GetFloat(key:  "player_total_purchased", defaultValue:  0f);
        this.num_purchase = UnityEngine.PlayerPrefs.GetInt(key:  "player_num_purchase", defaultValue:  0);
        this.num_ad_clicks = UnityEngine.PlayerPrefs.GetInt(key:  "player_num_ad_clicks", defaultValue:  0);
        this.lastPurchasePrice = UnityEngine.PlayerPrefs.GetFloat(key:  "player_last_purchase_price", defaultValue:  0f);
        this.transactionsAverageAmount = UnityEngine.PlayerPrefs.GetFloat(key:  "player_transactions_average_amount", defaultValue:  0f);
        this._challengeData = UnityEngine.PlayerPrefs.GetString(key:  "ChallengeData", defaultValue:  "");
        object val_45 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "player_stats", defaultValue:  "{}"));
        this.ParsePlayerStats(definition:  X0);
        object val_47 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "player_promoted_games", defaultValue:  "{}"));
        this.ParseNetworkPromo(objects:  X0);
        this.samePurchases = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "player_same_purchases", defaultValue:  "true"));
        System.DateTime val_52 = System.DateTime.UtcNow;
        System.DateTime val_53 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "player_last_login"), defaultValue:  new System.DateTime() {dateData = val_52.dateData});
        System.DateTime val_54 = System.DateTime.UtcNow;
        System.TimeSpan val_55 = val_54.dateData.Subtract(value:  new System.DateTime() {dateData = val_53.dateData});
        this._avg_hours_played = new AverageEventCalculator(name:  "avg_hours_btween_played").CalculateCurrent(valueToAdd:  (float)val_55._ticks.TotalHours);
        System.DateTime val_59 = System.DateTime.UtcNow;
        UnityEngine.PlayerPrefs.SetString(key:  "player_last_login", value:  val_59.dateData.ToString());
        this.isHacker = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "player_is_hacker", defaultValue:  "False"));
        this.isTroll = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "player_is_troll", defaultValue:  "False"));
        this.hackerType = UnityEngine.PlayerPrefs.GetString(key:  "player_hacker_type", defaultValue:  "Unknown");
        this.IsLapsingPurchaser = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "player_is_lapsing_purchaser", defaultValue:  "False"));
        this.IsLapsingNonPurchaser = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "player_is_lapsing_non_purchaser", defaultValue:  "False"));
        this.synchedGoldenCurrency = UnityEngine.PlayerPrefs.HasKey(key:  "player_synched_gc");
        this.playerLoaded = true;
    }
    public virtual void BuildReflectedLists()
    {
    
    }
    public void SetCredits(decimal amount)
    {
        null = null;
        decimal val_1 = System.Math.Max(val1:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10}, val2:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
        this._credits = val_1;
        mem[1152921515612667320] = val_1.lo;
        mem[1152921515612667324] = val_1.mid;
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
    }
    public void AddCredits(decimal amount, string source, string subSource, System.Collections.Generic.Dictionary<string, object> externalParams, bool doTrack = True)
    {
        int val_9;
        decimal val_10;
        string val_11;
        var val_13;
        string val_14;
        var val_15;
        int val_16;
        this.prevBalance = this._credits;
        mem[1152921515612807924] = ???;
        decimal val_1 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this._credits, hi = this._credits, lo = X27, mid = X27}, d2:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
        val_9 = val_1.lo;
        val_10 = System.Decimal.Zero;
        decimal val_2 = System.Math.Max(val1:  new System.Decimal() {flags = val_10, hi = val_10, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10}, val2:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_9, mid = val_1.mid});
        this._credits = val_2;
        mem[1152921515612807992] = val_2.lo;
        mem[1152921515612807996] = val_2.mid;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_9 = this.properties.credits_purchased;
            decimal val_4 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_9, hi = val_9, lo = val_10, mid = val_10}, d2:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
            val_11 = 0;
            this.properties.CreditsPurchased = new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid};
            val_10 = this.properties;
            System.DateTime val_5 = DateTimeCheat.UtcNow;
            this.properties.LastCoinSpent = val_5;
            this.properties.Save(writePrefs:  true);
            if(doTrack != false)
        {
                val_11 = source;
            this.properties.TrackCreditsSpent(amount:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, source:  val_11, previousBalance:  new System.Decimal() {flags = this.prevBalance, hi = this.prevBalance, lo = externalParams, mid = externalParams}, externalParams:  externalParams);
        }
        
        }
        
        val_13 = null;
        val_13 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                if(this.OnCreditsGained != null)
        {
                this.OnCreditsGained.Invoke(obj:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}));
        }
        
            if(doTrack != false)
        {
                val_14 = source;
            this.TrackCreditsGained(amount:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, source:  val_14, previousBalance:  new System.Decimal() {flags = this.prevBalance, hi = this.prevBalance, lo = externalParams, mid = externalParams}, subSource:  subSource, extraParams:  externalParams);
        }
        
        }
        
        val_15 = null;
        val_15 = null;
        val_16 = amount.lo;
        if(((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = val_16, mid = amount.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false) && (doTrack != false))
        {
                val_16 = source;
            this.TrackNonCoinReward(source:  val_16, subSource:  subSource, rewardType:  0, rewardAmount:  0, additionalParams:  externalParams);
        }
    
    }
    public void ResetPlayerCredits()
    {
        GameBehavior val_1 = App.getBehavior;
        this._credits = val_1.<metaGameBehavior>k__BackingField;
        mem[1152921515612956856] = typeof(MetaGameBehavior).__il2cppRuntimeField_948;
    }
    public void AddGems(int amount, string source, string subsource)
    {
        this._gems = System.Math.Max(val1:  0, val2:  this._gems + amount);
        if((amount & 2147483648) == 0)
        {
                return;
        }
        
        this.properties.GemsSpent = this.properties.gems_spent + amount;
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        this.properties.LastGemSpent = val_4;
        this.properties.Save(writePrefs:  true);
        this.properties.TrackGemsSpent(amount:  amount, source:  source, previousBalance:  this._gems);
    }
    public void SetPetsFood(int amount)
    {
        this._food = UnityEngine.Mathf.Max(a:  0, b:  amount);
    }
    public void AddPetsFood(int amount, string source, string subSource, WADPets.Tracking_FoodSpent FoodSpentParams, System.Collections.Generic.Dictionary<string, object> additionalParam)
    {
        int val_13;
        var val_14;
        val_13 = amount;
        amount = this._food + val_13;
        this._food = UnityEngine.Mathf.Max(a:  0, b:  amount);
        if(val_13 < 1)
        {
            goto label_3;
        }
        
        MonoSingleton<WADPetsManager>.Instance.Tracking_LifetimeFoodIncreased(amount:  val_13);
        if((System.String.IsNullOrEmpty(value:  source)) == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_14 = 1152921504619999232;
        val_4.Add(key:  "Previous Food", value:  this._food);
        val_4.Add(key:  "Current Food", value:  this._food);
        val_4.Add(key:  "Daily Challenge", value:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge);
        if(additionalParam == null)
        {
            goto label_20;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_9 = additionalParam.Keys.GetEnumerator();
        val_14 = 1152921510214909392;
        label_15:
        if(0.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_4.Add(key:  0, value:  additionalParam.Item[0]);
        goto label_15;
        label_14:
        0.Dispose();
        label_20:
        this.TrackNonCoinReward(source:  source, subSource:  subSource, rewardType:  "Food", rewardAmount:  amount.ToString(), additionalParams:  val_4);
        val_13 = amount;
        label_3:
        if(FoodSpentParams == null)
        {
                return;
        }
        
        if((val_13 & 2147483648) == 0)
        {
                return;
        }
        
        this.TrackFoodSpent(FoodSpentParams:  FoodSpentParams);
    }
    private void ValidateCurrentPlayer()
    {
        if((UnityEngine.PlayerPrefs.GetInt(key:  "player_client_created", defaultValue:  0)) < 1)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  UnityEngine.PlayerPrefs.GetString(key:  "player_uuid"), b:  DeviceIdPlugin.GetDeviceId())) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteAll();
    }
    protected virtual bool ShouldTakeServerData(ref System.Collections.IDictionary _diff)
    {
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        System.Collections.IDictionary val_13;
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_11 = mem[_diff];
        if((mem[_diff] + 294) == 0)
        {
            goto label_5;
        }
        
        var val_8 = mem[_diff] + 176;
        var val_9 = 0;
        val_8 = val_8 + 8;
        label_4:
        if(((mem[_diff] + 176 + 8) + -8) == null)
        {
            goto label_3;
        }
        
        val_9 = val_9 + 1;
        val_8 = val_8 + 16;
        if(val_9 < (mem[_diff] + 294))
        {
            goto label_4;
        }
        
        goto label_5;
        label_3:
        var val_10 = val_8;
        val_10 = val_10 + 4;
        val_11 = val_11 + val_10;
        val_8 = val_11 + 304;
        label_5:
        val_9 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((_diff.Contains(key:  "level")) == false)
        {
            goto label_6;
        }
        
        var val_14 = mem[_diff];
        if((mem[_diff] + 294) == 0)
        {
            goto label_8;
        }
        
        var val_12 = mem[_diff] + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_10:
        if(((mem[_diff] + 176 + 8) + -8) == null)
        {
            goto label_9;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (mem[_diff] + 294))
        {
            goto label_10;
        }
        
        label_8:
        val_10 = 0;
        goto label_11;
        label_9:
        val_14 = val_14 + (((mem[_diff] + 176 + 8)) << 4);
        val_11 = val_14 + 304;
        label_11:
        val_12 = public System.Object System.Collections.IDictionary::get_Item(object key);
        val_13 = System.Int32.Parse(s:  _diff.Item["level"]);
        if(this < val_13)
        {
            goto label_28;
        }
        
        label_6:
        val_13 = _diff;
        var val_18 = mem[_diff];
        if((mem[_diff] + 294) == 0)
        {
            goto label_15;
        }
        
        var val_15 = mem[_diff] + 176;
        var val_16 = 0;
        val_15 = val_15 + 8;
        label_17:
        if(((mem[_diff] + 176 + 8) + -8) == null)
        {
            goto label_16;
        }
        
        val_16 = val_16 + 1;
        val_15 = val_15 + 16;
        if(val_16 < (mem[_diff] + 294))
        {
            goto label_17;
        }
        
        label_15:
        val_12 = 4;
        goto label_18;
        label_16:
        var val_17 = val_15;
        val_17 = val_17 + 4;
        val_18 = val_18 + val_17;
        val_14 = val_18 + 304;
        label_18:
        val_15 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((val_13.Contains(key:  "total_purchase")) == false)
        {
            goto label_19;
        }
        
        var val_21 = mem[_diff];
        val_13 = "total_purchase";
        if((mem[_diff] + 294) == 0)
        {
            goto label_21;
        }
        
        var val_19 = mem[_diff] + 176;
        var val_20 = 0;
        val_19 = val_19 + 8;
        label_23:
        if(((mem[_diff] + 176 + 8) + -8) == null)
        {
            goto label_22;
        }
        
        val_20 = val_20 + 1;
        val_19 = val_19 + 16;
        if(val_20 < (mem[_diff] + 294))
        {
            goto label_23;
        }
        
        label_21:
        val_15 = 0;
        goto label_24;
        label_22:
        val_21 = val_21 + (((mem[_diff] + 176 + 8)) << 4);
        val_16 = val_21 + 304;
        label_24:
        float val_7 = System.Single.Parse(s:  _diff.Item[val_13], provider:  System.Globalization.CultureInfo.InvariantCulture);
        if(this.total_purchased < 0)
        {
            goto label_28;
        }
        
        label_19:
        val_17 = 0;
        return (bool)val_17;
        label_28:
        val_17 = 1;
        return (bool)val_17;
    }
    protected virtual void CreateNewPlayer(string id = " ")
    {
        var val_9;
        var val_10;
        var val_11;
        this.id = id;
        this.uuid = DeviceIdPlugin.GetDeviceId();
        this.support = "00-00-00";
        GameBehavior val_2 = App.getBehavior;
        this._credits = val_2.<metaGameBehavior>k__BackingField;
        mem[1152921515613858472] = typeof(MetaGameBehavior).__il2cppRuntimeField_948;
        this._bonusRewardPoints = 0;
        GameBehavior val_3 = App.getBehavior;
        this._gems = val_3.<metaGameBehavior>k__BackingField;
        this._stars = 0;
        val_9 = null;
        val_9 = null;
        this._food = WADPets.WADPetsEcon.DefaultFoodQuantity;
        val_10 = null;
        val_10 = null;
        this._experience = System.Decimal.Zero;
        System.DateTime val_4 = System.DateTime.UtcNow;
        this.created_at = val_4;
        this.playerBucket = ((UnityEngine.Random.Range(min:  1, max:  11)) < 6) ? "A" : "B";
        val_11 = null;
        val_11 = null;
        this.last_daily_amount = 0;
        this.clientCreated = 1;
        this.last_daily_credits = System.DateTime.MinValue;
        this.dcStars = 0;
        this.lifetimePlays = 0;
        this.no_ads = 1;
        this.restoredTransactions = 0;
        this.email = "";
        this.last_purchase = System.DateTime.MinValue;
        this.max_item_purchased = " ";
        this.last_item_purchased = " ";
        this.lastItemPrice = 0f;
        this.total_purchased = 0f;
        this.num_purchase = 0;
        this.num_ad_clicks = 0;
        this.transactionsAverageAmount = 0f;
        this.lastPurchasePrice = 0f;
        this._challengeData = "";
        this._avg_hours_played = 0f;
        this.network_purchaser = "false";
        this.playerStats = new System.Collections.Generic.Dictionary<System.String, System.Decimal>();
        this.samePurchases = 1;
        this.isNew = 1;
        this.promotedGames = new System.Collections.Generic.Dictionary<System.String, System.String>();
        this.isHacker = false;
        this.isTroll = false;
        this.hackerType = "Unknown";
        this.IsLapsingPurchaser = false;
        this.IsLapsingNonPurchaser = false;
        this.playerCreated = 1;
        this.country = "";
    }
    private void CreateCustomProperties(bool isPlayerNew)
    {
        PlayerProperties val_1 = null;
        isPlayerNew = isPlayerNew;
        val_1 = new PlayerProperties(isPlayerNew:  isPlayerNew);
        this.properties = val_1;
    }
    public void HardReset()
    {
        this.CreateCustomProperties(isPlayerNew:  true);
    }
    public object GetDeviceProperties()
    {
        var val_15;
        var val_16;
        object val_17;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "mac", value:  DeviceProperties.MacAddress);
        val_1.Add(key:  "model", value:  DeviceProperties.DeviceModel);
        val_1.Add(key:  "os", value:  DeviceProperties.OSVersion);
        val_1.Add(key:  "language", value:  DeviceProperties.LanguageCode);
        val_1.Add(key:  "platform", value:  DeviceProperties.Platform);
        val_1.Add(key:  "idfa", value:  DeviceProperties.Idfa);
        val_1.Add(key:  "timetraveler", value:  DeviceProperties.timeTraveler);
        val_1.Add(key:  "client_version", value:  DeviceIdPlugin.GetClientVersion());
        val_1.Add(key:  "timezone", value:  DeviceIdPlugin.GetTimeZone());
        string val_12 = DeviceProperties.notificationToken;
        if((System.String.IsNullOrEmpty(value:  val_12)) == true)
        {
                return (object)val_1;
        }
        
        val_15 = null;
        val_15 = null;
        if(twelvegigs.plugins.LocalNotificationsPlugin.initialized == false)
        {
                return (object)val_1;
        }
        
        if(twelvegigs.plugins.LocalNotificationsPlugin.IsNotificationEnabled() != false)
        {
                val_16 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_17 = val_12;
        }
        else
        {
                val_16 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_17 = "-";
        }
        
        val_1.Add(key:  "notification_token", value:  val_17);
        return (object)val_1;
    }
    private void TrackOOC()
    {
        null = null;
        App.trackerManager.track(eventName:  Events.OUT_OF_CREDITS);
    }
    public static string GetLevelForTracking()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_240;
    }
    public static string GetLevelNameForTracking()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_230;
    }
    public static string GetDifficultyForTracking()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_1B0;
    }
    public static string GetProgressForTracking()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_1C0;
    }
    public static string GetProgressTypeForTracking()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_1D0;
    }
    public void TrackNonCoinReward(string source, string subSource, string rewardType, string rewardAmount, System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        string val_7;
        var val_8;
        string val_20;
        string val_21;
        string val_22;
        object val_23;
        var val_24;
        System.Collections.Generic.List<System.String> val_25;
        var val_26;
        int val_27;
        val_20 = rewardAmount;
        val_21 = rewardType;
        val_22 = subSource;
        val_23 = source;
        val_24 = this;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Source", value:  val_23);
        if((System.String.IsNullOrEmpty(value:  val_22)) != true)
        {
                val_1.Add(key:  "Sub Source", value:  val_22);
        }
        
        if((System.String.IsNullOrEmpty(value:  val_20)) != true)
        {
                val_1.Add(key:  "Amount", value:  val_20);
        }
        
        if((System.String.IsNullOrEmpty(value:  val_21)) != true)
        {
                val_1.Add(key:  "Type", value:  val_21);
        }
        
        if(additionalParams == null)
        {
            goto label_43;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_5 = additionalParams.GetEnumerator();
        label_8:
        if(val_8.MoveNext() == false)
        {
            goto label_6;
        }
        
        if((val_1.ContainsKey(key:  val_7)) == true)
        {
            goto label_8;
        }
        
        val_1.Add(key:  val_7, value:  val_7);
        goto label_8;
        label_6:
        val_8.Dispose();
        val_24 = val_24;
        val_23 = val_23;
        val_22 = val_22;
        val_20 = val_20;
        val_21 = val_21;
        label_43:
        GameBehavior val_11 = App.getBehavior;
        val_26 = null;
        val_26 = null;
        App.trackerManager.track(eventName:  "NonCoin Award", data:  val_1);
        if(CompanyDevices.Instance == 0)
        {
                return;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_25 = this.QAHACK_NonCoinsAwardTrace;
        object[] val_16 = new object[4];
        val_27 = val_16.Length;
        val_16[0] = val_21;
        if(val_20 != null)
        {
                val_27 = val_16.Length;
        }
        
        val_16[1] = val_20;
        if(val_23 != null)
        {
                val_27 = val_16.Length;
        }
        
        val_16[2] = val_23;
        if(val_22 != null)
        {
                val_27 = val_16.Length;
        }
        
        val_16[3] = val_22;
        val_25.Add(item:  System.String.Format(format:  "{2} {3} :\n\t {0} + {1}", args:  val_16));
    }
    public void TrackFoodSpent(WADPets.Tracking_FoodSpent FoodSpentParams)
    {
        var val_2;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Amount Spent", value:  FoodSpentParams.AmountSpent);
        val_1.Add(key:  "Previous Food", value:  FoodSpentParams.PreviousFood);
        val_1.Add(key:  "Current Food", value:  FoodSpentParams.CurrentFood);
        val_2 = null;
        val_2 = null;
        App.trackerManager.track(eventName:  Events.FOOD_SPENT, data:  val_1);
    }
    public void TrackGoldenCurrencySpent(int amount, string source, System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_800;
    }
    private void TrackCreditsGained(decimal amount, string source, decimal previousBalance, string subSource, System.Collections.Generic.Dictionary<string, object> extraParams)
    {
        string val_10;
        object val_24;
        System.Collections.Generic.List<System.String> val_25;
        var val_26;
        var val_27;
        int val_28;
        val_24 = extraParams;
        val_25 = this;
        val_26 = null;
        val_26 = null;
        if((Player.NotFreeCreditSources.Contains(item:  source)) == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "Source", value:  source);
        if((System.String.IsNullOrEmpty(value:  subSource)) != true)
        {
                val_2.Add(key:  "Sub Source", value:  subSource);
        }
        
        val_2.Add(key:  "Amount Collected", value:  amount);
        val_2.Add(key:  "Current Coins", value:  this._credits);
        val_2.Add(key:  "Previous Balance", value:  previousBalance);
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                bool val_7 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
            val_2.Add(key:  "Daily Challenge", value:  val_7);
        }
        
        if(val_24 == null)
        {
            goto label_55;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_8 = val_24.GetEnumerator();
        label_18:
        if(val_7.MoveNext() == false)
        {
            goto label_16;
        }
        
        if((val_2.ContainsKey(key:  val_10)) == true)
        {
            goto label_18;
        }
        
        val_2.Add(key:  val_10, value:  val_10);
        goto label_18;
        label_16:
        val_7.Dispose();
        label_55:
        UnityEngine.Debug.Log(message:  "Attempting to track free coins!\n"("Attempting to track free coins!\n") + PrettyPrint.printJSON(obj:  val_2, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_2, types:  false, singleLineOutput:  false)));
        val_27 = null;
        val_27 = null;
        App.trackerManager.track(eventName:  "Free Coins", data:  val_2);
        val_24 = 1152921504884535296;
        if(CompanyDevices.Instance == 0)
        {
                return;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_25 = this.QAHACK_FreeCoinsTrace;
        object[] val_19 = new object[4];
        val_19[0] = previousBalance.flags.ToString();
        val_24 = amount.flags.ToString();
        val_28 = val_19.Length;
        val_19[1] = val_24;
        if(source != null)
        {
                val_28 = val_19.Length;
        }
        
        val_19[2] = source;
        if(subSource != null)
        {
                val_28 = val_19.Length;
        }
        
        val_19[3] = subSource;
        val_25.Add(item:  System.String.Format(format:  "{2} {3} :\n\t {0} + {1}", args:  val_19));
    }
    private void TrackCreditsSpent(decimal amount, string source, decimal previousBalance, System.Collections.Generic.Dictionary<string, object> externalParams)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_7E0;
    }
    private void TrackGemsSpent(int amount, string source, int previousBalance)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_7F0;
    }
    public Player()
    {
        var val_5;
        this.isNew = true;
        val_5 = null;
        val_5 = null;
        this._food = WADPets.WADPetsEcon.DefaultFoodQuantity;
        System.DateTime val_1 = System.DateTime.UtcNow;
        this.created_at = val_1;
        this._level = 1;
        this.no_ads = 1;
        this.last_daily_credits = System.DateTime.MinValue;
        this.last_purchase = System.DateTime.MinValue;
        this.max_item_purchased = " ";
        this.last_item_purchased = " ";
        this.network_purchaser = "false";
        this.samePurchases = 1;
        this._challengeData = "";
        this.hackerType = "Unknown";
        this.playerStats = new System.Collections.Generic.Dictionary<System.String, System.Decimal>();
        this.QAHACK_FreeCoinsTrace = new System.Collections.Generic.List<System.String>();
        this.QAHACK_NonCoinsAwardTrace = new System.Collections.Generic.List<System.String>();
    }
    private static Player()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "PurchasesHandler");
        val_1.Add(item:  "Not Tracked");
        Player.NotFreeCreditSources = val_1;
    }

}
