using UnityEngine;
[Serializable]
public class PlayerProperties
{
    // Fields
    private EasySaver<PlayerProperties> mySaver;
    public const string DefaultProfileLocation = "Slotsville, USA";
    public string offline_fb_id;
    public string fb_access_token;
    public string online_fb_id;
    private bool <PurchaseHackUser>k__BackingField;
    private const string install_from_mg_deeplink_key = "inst_mg_deeplink";
    public bool InstalledFromMGDeeplink;
    private const string mg_play_count_key = "mg_play_ct";
    public int MGPlaysCount;
    private const string mg_coins_earned_key = "mg_coins_rwd";
    public decimal MGCoinsRewarded;
    private const string mg_ads_watched_key = "mg_ads_ct";
    public int MGAdsCount;
    private const string mg_hints_used_key = "mg_hnts_ct";
    public int MGHintsCount;
    private const string lifetime_hints_key = "total_hnts";
    public int LifetimeHints;
    private const string lifetime_fr_hints_key = "free_hnts";
    public int LifetimeFreeHints;
    private const string lifetime_sr_hints_key = "str_hints";
    public int LifetimeStruggleHints;
    private const string lifetime_dc_hints_key = "dc_hnts";
    public int LifetimeDCHints;
    private const string lifetime_hintpickers_key = "total_hntpck";
    public int LifetimeHintPickers;
    private const string lifetime_megahint_key = "total_mga_hnt";
    public int LifetimeMegaHints;
    private const string lifetime_checkhint_key = "total_chk_hnt";
    public int LifetimeCheckHints;
    private const string chapters_played_key = "ch_no_hnts";
    public int ChaptersPlayedWithoutHints;
    private const string hints_used_chapter_key = "hnts_used_ch";
    public int HintsUsedOnCurrentChapter;
    private const string incentivised_vids_key = "total_ivds";
    public int incentivisedVideosWatched;
    private const string prize_balloon_tapped_key = "balloon_tapped";
    public int prizeBalloonTapped;
    private const string prize_balloon_appeared_key = "balloon_appeared";
    public int prizeBalloonAppeared;
    private const string grid_size_key = "pp_grid_size";
    public float gridSize;
    public bool SkippedTutorial;
    public int AdvancedSkipLevel;
    private const string www_timestamp_key = "www_ts";
    public int WWWServerTimestamp;
    private const string www_progress_key = "www_prg";
    public int WWWEventProgress;
    private const string www_collected_key = "www_col";
    public int wWWEventCollected;
    private const string ads_not_clicked_key = "ads_not_clicked";
    public int adsNotClicked;
    private const string lvls_post_purchase_key = "lvls_post_purch";
    public int LevelsPlayedPostPurchase;
    private const string last_seen_date_string = "last_seen_date";
    public string LastSeenDateString;
    private const string noAdsEndTimeKey = "no_ads_end";
    public System.DateTime NoAdsEndTime;
    private string _profile_name;
    public int profile_avatar_id;
    public string profile_location;
    private decimal credits_purchased;
    private int gems_spent;
    public string story_mode_vote;
    public bool gdprConsent;
    private System.Collections.Generic.List<string> gdprCountries;
    public string WHDPlayerVarsTokenized;
    private const string ads_last_clicked_time_key = "ads_last_clicked_time";
    public System.DateTime AdsLastClickedTime;
    private const string gotd_last_shown_time_key = "gotd_last_shown_time";
    public System.DateTime GOTDLastShownTime;
    private const string gotd_days_seen_wo_installation_key = "gotd_days_seen_wo_installation";
    public int GOTDDaysSeenWoInstallation;
    private const string gotd_dont_show_until_key = "gotd_dont_show_until";
    public System.DateTime GOTDDontShowUntil;
    private const string lifetime_definitions_viewed = "defs_seen";
    public int LifetimeDefinitionsViewed;
    private const string ag_goal_extra_words_key = "goal_extra_words";
    public int GoalExtraWords;
    private const string ag_goal_use_hints_key = "goal_use_hints";
    public int GoalUseHints;
    private const string ag_goal_golden_currency_key = "goal_golden_curr";
    public int GoalGoldenCurrency;
    private const string ag_goal_daily_challenge_key = "goal_daily_chal";
    public int GoalDailyChallenge;
    private const string ag_goal_twitter_post_key = "goal_twitter_post";
    public int GoalTwitterPosts;
    private const string ag_goal_friend_invited_key = "goal_friend_invite";
    public int GoalFriendInvites;
    public bool MysteryGiftReceived;
    private const string ab_currentCollectionIndex_key = "ab_curr_coll_ind";
    public int ab_currentCollectionIndex;
    private const string ab_totalCollectionsComplete_key = "ab_tot_coll_com";
    public int ab_totalCollectionsComplete;
    private const string ab_currentCollectionBonus_key = "ab_curr_coll_bns";
    public decimal ab_currentCollectionBonus;
    private const string ab_currentCollectionBox_key = "ab_curr_coll_box";
    public System.Collections.Generic.List<string> ab_currentCollectionBox;
    private const string ab_currentCollectionProgress_key = "ab_curr_coll_prg";
    public System.Collections.Generic.List<string> ab_currentCollectionProgress;
    private const string ab_nextLevel_key = "ab_next_lvl";
    public int ab_nextLevel;
    private const string ab_currentLanguage_key = "ab_curr_lng";
    public string ab_currentLanguage;
    private const string ab_lifetime_redraws_key = "ab_tot_red";
    public int ab_lifeftime_redraws;
    public bool has_Active_Subscription;
    public int numSubscriptionsPurchased;
    public int numTrialSubs;
    public bool has_Active_Subscription_Silver;
    public int numSubscriptionsPurchased_Silver;
    public int numTrialSubs_Silver;
    private const string lifetime_apples_extrawords = "lt_extra_word_apples";
    public int LifetimeApplesEarnedFromExtraWords;
    private const string last_coin_spent_key = "LastCoinSpent";
    public System.DateTime LastCoinSpent;
    private const string last_gem_spent_key = "LastGemSpent";
    public System.DateTime LastGemSpent;
    public const string pp_player_iq_key = "word_player_iq";
    public float PlayerIQ;
    private const string vip_party_lifetime_purchases_key = "vip_party_lifetime_purchases";
    public int LifetimeVipPartyPurchases;
    public const string pp_lifetime_streak_key = "largest_word_streak";
    public int LifetimeLargestStreak;
    public const string pp_lifetime_profile_avatar_change = "profile_avatar_changes";
    public int LifetimeProfileAvatarChanges;
    public const string pp_lifetime_profile_name_change = "profile_name_changes";
    public int LifetimeProfileNameChanges;
    public const string ftux_tracking_key = "ftux_tracking";
    public bool FTUXWasBlockedByKnob;
    public const string pp_apple_user_id = "apple_user_id";
    public string appleUserId;
    public const string pp_verified_email = "verified_email";
    public bool verifiedEmail;
    public string ads_segment;
    public bool imported;
    public string oldSupportId;
    public const string treasure_chest_key = "treasure_chest";
    public string treasure_chest;
    public const string cp_categories = "categories";
    public const string cp_pack_progress = "ctpk_lvls";
    private System.Collections.Generic.Dictionary<int, int> cpPackProgress;
    public const string cp_pack_rewtar = "ctpk_rewtar";
    private int cpRewardTargetPacks;
    public const string cp_pack_rewcur = "ctpk_rewcur";
    private int cpRewardCurrentPacks;
    public const string golden_multiplier_key = "g_mult";
    public float GoldenMultiplier;
    public const string daily_challenge_tutorial_seen_key = "dct_seen";
    public int DailyChallengeTutorialStatus;
    public System.Collections.Generic.Dictionary<string, object> releaseEventMachineRanks;
    
    // Properties
    public EasySaver<PlayerProperties> getSaver { get; }
    public bool PurchaseHackUser { get; set; }
    private long noAdsEndTimestamp { get; }
    private long adsWatchedCooldown { get; }
    public int SetLifetimeLargestStreak { set; }
    public string CategoriesJson { get; }
    public System.Collections.Generic.Dictionary<int, int> CategoryPacksProgress { get; }
    public int CategoryRewardTargetPacks { get; set; }
    public int CategoryRewardCurrentPacks { get; set; }
    public bool nonClicker { get; }
    public bool WWWEventCollected { get; set; }
    public string profile_name { get; set; }
    public decimal CreditsPurchased { get; set; }
    public int GemsSpent { get; set; }
    
    // Methods
    public EasySaver<PlayerProperties> get_getSaver()
    {
        return (EasySaver<PlayerProperties>)this.mySaver;
    }
    public PlayerProperties(bool isPlayerNew)
    {
        var val_8;
        var val_9;
        val_8 = null;
        this.offline_fb_id = System.String.alignConst;
        this.fb_access_token = System.String.alignConst;
        this.gridSize = 10f;
        this.WWWServerTimestamp = -1;
        this.WWWEventProgress = -1;
        this.LevelsPlayedPostPurchase = 0;
        this.online_fb_id = System.String.alignConst;
        this.LastSeenDateString = "unknown";
        val_9 = null;
        val_9 = null;
        val_8 = 1152921504622235832;
        this.NoAdsEndTime = System.DateTime.MinValue;
        this.profile_avatar_id = 0;
        this._profile_name = "Player";
        this.profile_location = System.String.alignConst;
        this.story_mode_vote = "None";
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "AT");
        val_1.Add(item:  "BE");
        val_1.Add(item:  "BG");
        val_1.Add(item:  "HR");
        val_1.Add(item:  "CY");
        val_1.Add(item:  "CZ");
        val_1.Add(item:  "DK");
        val_1.Add(item:  "EE");
        val_1.Add(item:  "FI");
        val_1.Add(item:  "FR");
        val_1.Add(item:  "DE");
        val_1.Add(item:  "GR");
        val_1.Add(item:  "HU");
        val_1.Add(item:  "IE");
        val_1.Add(item:  "IT");
        val_1.Add(item:  "LV");
        val_1.Add(item:  "LT");
        val_1.Add(item:  "LU");
        val_1.Add(item:  "MT");
        val_1.Add(item:  "NL");
        val_1.Add(item:  "PL");
        val_1.Add(item:  "PT");
        val_1.Add(item:  "RO");
        val_1.Add(item:  "SK");
        val_1.Add(item:  "SI");
        val_1.Add(item:  "ES");
        val_1.Add(item:  "SE");
        val_1.Add(item:  "GF");
        val_1.Add(item:  "GP");
        val_1.Add(item:  "MQ");
        val_1.Add(item:  "ME");
        val_1.Add(item:  "YT");
        val_1.Add(item:  "RE");
        val_1.Add(item:  "MF");
        val_1.Add(item:  "GI");
        val_1.Add(item:  "AX");
        val_1.Add(item:  "PM");
        val_1.Add(item:  "GL");
        val_1.Add(item:  "BL");
        val_1.Add(item:  "SX");
        val_1.Add(item:  "AW");
        val_1.Add(item:  "CW");
        val_1.Add(item:  "WF");
        val_1.Add(item:  "PF");
        val_1.Add(item:  "NC");
        val_1.Add(item:  "TF");
        val_1.Add(item:  "AI");
        val_1.Add(item:  "BM");
        val_1.Add(item:  "IO");
        val_1.Add(item:  "VG");
        val_1.Add(item:  "KY");
        val_1.Add(item:  "FK");
        val_1.Add(item:  "MS");
        val_1.Add(item:  "PN");
        val_1.Add(item:  "SH");
        val_1.Add(item:  "GS");
        val_1.Add(item:  "TC");
        val_1.Add(item:  "AD");
        val_1.Add(item:  "LI");
        val_1.Add(item:  "MC");
        val_1.Add(item:  "SM");
        val_1.Add(item:  "VA");
        val_1.Add(item:  "JE");
        val_1.Add(item:  "GG");
        val_1.Add(item:  "GI");
        this.gdprCountries = val_1;
        this.WHDPlayerVarsTokenized = System.String.alignConst;
        this.AdsLastClickedTime = System.DateTime.MinValue;
        this.GOTDLastShownTime = System.DateTime.MinValue;
        this.GOTDDontShowUntil = System.DateTime.MinValue;
        this.ab_currentCollectionBox = new System.Collections.Generic.List<System.String>();
        this.ab_currentCollectionProgress = new System.Collections.Generic.List<System.String>();
        this.ab_currentLanguage = "";
        this.appleUserId = System.String.alignConst;
        this.ads_segment = System.String.alignConst;
        this.oldSupportId = System.String.alignConst;
        this.treasure_chest = "{}";
        this.cpPackProgress = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        GameEcon val_5 = App.getGameEcon;
        this.GoldenMultiplier = -1f;
        this.cpRewardTargetPacks = val_5.categoryCompletionGoal;
        this.releaseEventMachineRanks = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(isPlayerNew != false)
        {
                this.CreateNew();
        }
        else
        {
                this.LoadFromLocal();
        }
        
        this.mySaver = new EasySaver<PlayerProperties>(incInstance:  this);
    }
    private void CreateNew()
    {
        var val_1;
        this.profile_avatar_id = 0;
        this._profile_name = "Player";
        this.offline_fb_id = System.String.alignConst;
        this.fb_access_token = System.String.alignConst;
        this.<PurchaseHackUser>k__BackingField = false;
        this.online_fb_id = System.String.alignConst;
        val_1 = null;
        val_1 = null;
        this.credits_purchased = 0m;
        mem[1152921515616831968] = 0;
        this.gems_spent = 0;
        this.NoAdsEndTime = System.DateTime.MinValue;
    }
    public bool get_PurchaseHackUser()
    {
        return (bool)this.<PurchaseHackUser>k__BackingField;
    }
    public void set_PurchaseHackUser(bool value)
    {
        this.<PurchaseHackUser>k__BackingField = value;
    }
    private long get_noAdsEndTimestamp()
    {
        return twelvegigs.storage.JsonDictionary.TotalSeconds(dateTime:  new System.DateTime() {dateData = this.NoAdsEndTime});
    }
    private long get_adsWatchedCooldown()
    {
        System.DateTime val_1 = AdsManager.AdsCooldownEnd;
        return twelvegigs.storage.JsonDictionary.TotalSeconds(dateTime:  new System.DateTime() {dateData = val_1.dateData});
    }
    public bool ShouldShowGdprConsent()
    {
        var val_5;
        if((this.gdprCountries.Contains(item:  DeviceIdPlugin.GetCountryFromLocale())) != false)
        {
                object[] val_3 = new object[2];
            val_3[0] = this.gdprConsent;
            bool val_5 = this.gdprConsent;
            val_5 = val_5 ^ 1;
            val_3[1] = val_5;
            UnityEngine.Debug.LogFormat(format:  "We are in the EU list. Have we consented? {0} Should we show? {1}", args:  val_3);
            var val_4 = (this.gdprConsent == false) ? 1 : 0;
            return (bool)val_5;
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    public void set_SetLifetimeLargestStreak(int value)
    {
        this.LifetimeLargestStreak = System.Math.Max(val1:  value, val2:  this.LifetimeLargestStreak);
    }
    public string get_CategoriesJson()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "ctpk_lvls", value:  this.cpPackProgress);
        val_1.Add(key:  "ctpk_rewtar", value:  this.CategoryRewardTargetPacks);
        val_1.Add(key:  "ctpk_rewcur", value:  this.cpRewardCurrentPacks);
        return (string)Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1);
    }
    public System.Collections.Generic.Dictionary<int, int> get_CategoryPacksProgress()
    {
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)this.cpPackProgress;
    }
    public int get_CategoryRewardTargetPacks()
    {
        GameEcon val_1 = App.getGameEcon;
        GameEcon val_2 = App.getGameEcon;
        return UnityEngine.Mathf.Clamp(value:  this.cpRewardTargetPacks, min:  val_1.categoryCompletionGoal, max:  val_2.categoryCompletionGoalMax);
    }
    public void set_CategoryRewardTargetPacks(int value)
    {
        this.cpRewardTargetPacks = value;
    }
    public int get_CategoryRewardCurrentPacks()
    {
        return (int)this.cpRewardCurrentPacks;
    }
    public void set_CategoryRewardCurrentPacks(int value)
    {
        this.cpRewardCurrentPacks = value;
    }
    public bool get_nonClicker()
    {
        return (bool)(this.adsNotClicked > AdsManager.getNonClickerThreshold) ? 1 : 0;
    }
    public bool get_WWWEventCollected()
    {
        return (bool)(this.wWWEventCollected == 1) ? 1 : 0;
    }
    public void set_WWWEventCollected(bool value)
    {
        if(this != null)
        {
                this.wWWEventCollected = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public string get_profile_name()
    {
        return (string)this._profile_name;
    }
    public void set_profile_name(string value)
    {
        this._profile_name = value;
    }
    public decimal get_CreditsPurchased()
    {
        return new System.Decimal() {flags = this.credits_purchased, hi = this.credits_purchased};
    }
    public void set_CreditsPurchased(decimal value)
    {
        null = null;
        decimal val_1 = System.Math.Max(val1:  new System.Decimal() {flags = value.flags, hi = value.hi, lo = value.lo, mid = value.mid}, val2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10});
        this.credits_purchased = val_1;
        mem[1152921515619083376] = val_1.lo;
        mem[1152921515619083380] = val_1.mid;
    }
    public int get_GemsSpent()
    {
        return (int)this.gems_spent;
    }
    public void set_GemsSpent(int value)
    {
        this.gems_spent = System.Math.Max(val1:  value, val2:  0);
    }
    public void UpdateData(System.Collections.IDictionary diff)
    {
        var val_10;
        var val_11;
        var val_13;
        var val_15;
        var val_16;
        var val_18;
        object val_19;
        var val_21;
        var val_15 = 0;
        val_15 = val_15 + 1;
        val_10 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "word_fbid")) != false)
        {
                var val_16 = 0;
            val_16 = val_16 + 1;
            val_11 = 0;
            val_13 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.online_fb_id = diff.Item["word_fbid"];
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_13 = 4;
        val_15 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "no_ads_end")) != false)
        {
                var val_18 = 0;
            val_18 = val_18 + 1;
            val_16 = 0;
            decimal val_9 = System.Decimal.Parse(s:  diff.Item["no_ads_end"]);
            val_18 = 0;
            System.DateTime val_10 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            this.NoAdsEndTime = val_10;
        }
        
        val_19 = "total_ivds";
        var val_19 = 0;
        val_19 = val_19 + 1;
        val_18 = 4;
        val_21 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  val_19)) == false)
        {
                return;
        }
        
        val_19 = "total_ivds";
        var val_20 = 0;
        val_20 = val_20 + 1;
        val_21 = 0;
        object val_14 = diff.Item[val_19];
        this.incentivisedVideosWatched = null;
    }
    public void TrustServerData(System.Collections.IDictionary diff)
    {
        object val_123;
        var val_124;
        var val_126;
        var val_127;
        var val_129;
        var val_131;
        var val_132;
        var val_134;
        var val_136;
        var val_137;
        var val_139;
        var val_141;
        var val_142;
        var val_144;
        var val_145;
        var val_147;
        var val_148;
        var val_150;
        var val_152;
        var val_153;
        var val_155;
        var val_157;
        var val_158;
        var val_160;
        var val_162;
        var val_163;
        var val_165;
        var val_167;
        var val_168;
        var val_170;
        var val_172;
        if((diff & 1) != 0)
        {
                this.online_fb_id = diff;
        }
        
        if((diff & 1) != 0)
        {
                this.InstalledFromMGDeeplink = System.Boolean.Parse(value:  diff);
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.MGPlaysCount = null;
        }
        
        if((diff & 1) != 0)
        {
                decimal val_11 = System.Decimal.Parse(s:  diff);
            this.MGCoinsRewarded = val_11;
            mem[1152921515619624256] = val_11.lo;
            mem[1152921515619624260] = val_11.mid;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.MGAdsCount = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.MGHintsCount = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.LifetimeHints = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.LifetimeFreeHints = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.LifetimeStruggleHints = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.LifetimeDCHints = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.LifetimeHintPickers = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.LifetimeMegaHints = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.ChaptersPlayedWithoutHints = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.HintsUsedOnCurrentChapter = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.WWWServerTimestamp = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.WWWEventProgress = null;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.wWWEventCollected = (null == 1) ? 1 : 0;
        }
        
        if((diff & 1) != 0)
        {
                decimal val_41 = System.Decimal.Parse(s:  diff);
            System.DateTime val_42 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_41.flags, hi = val_41.hi, lo = val_41.lo, mid = val_41.mid});
            this.NoAdsEndTime = val_42;
        }
        
        if((diff & 1) != 0)
        {
                this.LevelsPlayedPostPurchase = System.Int32.Parse(s:  diff);
        }
        
        if((diff & 1) != 0)
        {
                this.gdprConsent = System.Boolean.Parse(value:  diff);
        }
        
        if((diff & 1) != 0)
        {
                this.WHDPlayerVarsTokenized = diff;
        }
        
        if((diff & 1) != 0)
        {
                this.LifetimeApplesEarnedFromExtraWords = System.Int32.Parse(s:  diff);
        }
        
        if((diff & 1) != 0)
        {
                System.DateTime val_57 = SLCDateTime.Parse(dateTime:  diff, defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
            this.LastCoinSpent = val_57;
        }
        
        if((diff & 1) != 0)
        {
                val_123 = null;
            this.incentivisedVideosWatched = null;
        }
        
        if((diff & 1) != 0)
        {
                if((diff.ContainsKey(key:  "ab_next_lvl")) != false)
        {
                object val_63 = diff.Item["ab_next_lvl"];
            val_123 = null;
            this.ab_nextLevel = null;
        }
        
            if((diff.ContainsKey(key:  "ab_curr_coll_box")) != false)
        {
                this.ab_currentCollectionBox = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  diff.Item["ab_curr_coll_box"]);
        }
        
            if((diff.ContainsKey(key:  "ab_curr_coll_bns")) != false)
        {
                decimal val_69 = System.Decimal.Parse(s:  diff.Item["ab_curr_coll_bns"]);
            this.ab_currentCollectionBonus = val_69;
            mem[1152921515619624528] = val_69.lo;
            mem[1152921515619624532] = val_69.mid;
        }
        
            if((diff.ContainsKey(key:  "ab_curr_coll_ind")) != false)
        {
                object val_71 = diff.Item["ab_curr_coll_ind"];
            val_123 = null;
            this.ab_currentCollectionIndex = null;
        }
        
            if((diff.ContainsKey(key:  "ab_curr_coll_prg")) != false)
        {
                this.ab_currentCollectionProgress = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  diff.Item["ab_curr_coll_prg"]);
        }
        
            if((diff.ContainsKey(key:  "ab_curr_lng")) != false)
        {
                this.ab_currentLanguage = diff.Item["ab_curr_lng"];
        }
        
            if((diff.ContainsKey(key:  "ab_tot_coll_com")) != false)
        {
                object val_78 = diff.Item["ab_tot_coll_com"];
            val_123 = null;
            this.ab_totalCollectionsComplete = null;
        }
        
            if((diff.ContainsKey(key:  "ab_tot_red")) != false)
        {
                object val_80 = diff.Item["ab_tot_red"];
            val_123 = null;
            this.ab_lifeftime_redraws = null;
        }
        
        }
        
        if((diff & 1) != 0)
        {
                val_124 = 0;
            this.PlayerIQ = System.Single.Parse(s:  diff, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
        var val_143 = 0;
        val_143 = val_143 + 1;
        val_124 = 4;
        val_126 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "largest_word_streak")) != false)
        {
                var val_144 = 0;
            val_144 = val_144 + 1;
            val_127 = 0;
            val_129 = 0;
            bool val_90 = System.Int32.TryParse(s:  diff.Item["largest_word_streak"], result: out  this.LifetimeLargestStreak);
        }
        
        var val_145 = 0;
        val_145 = val_145 + 1;
        val_129 = 4;
        val_131 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "profile_avatar_changes")) != false)
        {
                var val_146 = 0;
            val_146 = val_146 + 1;
            val_132 = 0;
            val_134 = 0;
            bool val_96 = System.Int32.TryParse(s:  diff.Item["profile_avatar_changes"], result: out  this.LifetimeProfileNameChanges);
        }
        
        var val_147 = 0;
        val_147 = val_147 + 1;
        val_134 = 4;
        val_136 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "profile_name_changes")) != false)
        {
                var val_148 = 0;
            val_148 = val_148 + 1;
            val_137 = 0;
            val_139 = 0;
            bool val_102 = System.Int32.TryParse(s:  diff.Item["profile_name_changes"], result: out  this.LifetimeProfileNameChanges);
        }
        
        var val_149 = 0;
        val_149 = val_149 + 1;
        val_139 = 4;
        val_141 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "treasure_chest")) != false)
        {
                var val_150 = 0;
            val_150 = val_150 + 1;
            val_142 = 0;
            val_144 = public System.Object System.Collections.IDictionary::get_Item(object key);
            val_145 = diff;
            if(val_145.Item["treasure_chest"] != null)
        {
                val_145 = 0;
        }
        
            this.treasure_chest = MiniJSON.Json.Serialize(obj:  null);
        }
        
        var val_151 = 0;
        val_151 = val_151 + 1;
        val_144 = 4;
        val_147 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "categories")) != false)
        {
                var val_152 = 0;
            val_152 = val_152 + 1;
            val_148 = 0;
            val_150 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.ParseCategoryPacksPlayerData(json:  diff.Item["categories"]);
        }
        
        var val_153 = 0;
        val_153 = val_153 + 1;
        val_150 = 4;
        val_152 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "g_mult")) != false)
        {
                var val_154 = 0;
            val_154 = val_154 + 1;
            val_153 = 0;
            val_155 = 0;
            this.GoldenMultiplier = System.Single.Parse(s:  diff.Item["g_mult"], provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
        var val_155 = 0;
        val_155 = val_155 + 1;
        val_155 = 4;
        val_157 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "verified_email")) == false)
        {
            goto label_386;
        }
        
        var val_156 = 0;
        val_156 = val_156 + 1;
        val_158 = 0;
        goto label_390;
        label_386:
        this.verifiedEmail = false;
        goto label_391;
        label_390:
        val_160 = 0;
        bool val_124 = System.Boolean.TryParse(value:  diff.Item["verified_email"], result: out  this.verifiedEmail);
        label_391:
        var val_157 = 0;
        val_157 = val_157 + 1;
        val_160 = 4;
        val_162 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "apple_user_id")) != false)
        {
                var val_158 = 0;
            val_158 = val_158 + 1;
            val_163 = 0;
            val_165 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.appleUserId = diff.Item["apple_user_id"];
        }
        
        var val_159 = 0;
        val_159 = val_159 + 1;
        val_165 = 4;
        val_167 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "dct_seen")) != false)
        {
                var val_160 = 0;
            val_160 = val_160 + 1;
            val_168 = 0;
            val_170 = 0;
            bool val_134 = System.Int32.TryParse(s:  diff.Item["dct_seen"], result: out  this.DailyChallengeTutorialStatus);
        }
        
        var val_161 = 0;
        val_161 = val_161 + 1;
        val_170 = 4;
        val_172 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "balloon_tapped")) != false)
        {
                val_172 = 0;
            this.prizeBalloonTapped = UnityEngine.PlayerPrefs.GetInt(key:  "balloon_tapped", defaultValue:  0);
        }
        
        var val_162 = 0;
        val_162 = val_162 + 1;
        val_172 = 4;
        val_123 = "balloon_appeared";
        if((diff.Contains(key:  val_123)) != false)
        {
                val_123 = 0;
            this.prizeBalloonAppeared = UnityEngine.PlayerPrefs.GetInt(key:  "balloon_appeared", defaultValue:  0);
        }
        
        NotificationCenter val_141 = NotificationCenter.DefaultCenter;
        if(val_141 == null)
        {
                throw new NullReferenceException();
        }
        
        val_141.PostNotification(aSender:  0, aName:  "OnServerDataReceived");
    }
    public void Encode(ref System.Collections.Generic.Dictionary<string, object> jsonPlayer)
    {
    
    }
    private void LoadFromLocal()
    {
        var val_114;
        var val_115;
        this._profile_name = UnityEngine.PlayerPrefs.GetString(key:  "player_profile_name", defaultValue:  "Player");
        this.profile_avatar_id = UnityEngine.PlayerPrefs.GetInt(key:  "player_profile_avatar_id", defaultValue:  0);
        this.profile_location = UnityEngine.PlayerPrefs.GetString(key:  "player_profile_location", defaultValue:  System.String.alignConst);
        this.<PurchaseHackUser>k__BackingField = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "purchase_hack_user", defaultValue:  "false"));
        this.offline_fb_id = UnityEngine.PlayerPrefs.GetString(key:  "player_offline_fb_id", defaultValue:  System.String.alignConst);
        this.fb_access_token = UnityEngine.PlayerPrefs.GetString(key:  "fb_access_token", defaultValue:  System.String.alignConst);
        this.online_fb_id = UnityEngine.PlayerPrefs.GetString(key:  "player_online_fb_id", defaultValue:  System.String.alignConst);
        this.gdprConsent = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "player_gdpr_consent", defaultValue:  "False"));
        this.WHDPlayerVarsTokenized = UnityEngine.PlayerPrefs.GetString(key:  "whd_pl_vars", defaultValue:  System.String.alignConst);
        this.InstalledFromMGDeeplink = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "inst_mg_deeplink", defaultValue:  "false"));
        this.MGPlaysCount = UnityEngine.PlayerPrefs.GetInt(key:  "mg_play_ct", defaultValue:  0);
        decimal val_19 = System.Decimal.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "mg_coins_rwd", defaultValue:  "0"), style:  511);
        this.MGCoinsRewarded = val_19;
        mem[1152921515620123760] = val_19.lo;
        mem[1152921515620123764] = val_19.mid;
        this.MGAdsCount = UnityEngine.PlayerPrefs.GetInt(key:  "mg_ads_ct", defaultValue:  0);
        this.MGHintsCount = UnityEngine.PlayerPrefs.GetInt(key:  "mg_hnts_ct", defaultValue:  0);
        this.LifetimeHints = UnityEngine.PlayerPrefs.GetInt(key:  "total_hnts", defaultValue:  0);
        this.LifetimeFreeHints = UnityEngine.PlayerPrefs.GetInt(key:  "free_hnts", defaultValue:  0);
        this.LifetimeStruggleHints = UnityEngine.PlayerPrefs.GetInt(key:  "str_hints", defaultValue:  0);
        this.LifetimeDCHints = UnityEngine.PlayerPrefs.GetInt(key:  "dc_hnts", defaultValue:  0);
        this.LifetimeHintPickers = UnityEngine.PlayerPrefs.GetInt(key:  "total_hntpck", defaultValue:  0);
        this.LifetimeMegaHints = UnityEngine.PlayerPrefs.GetInt(key:  "total_mga_hnt", defaultValue:  0);
        this.LifetimeCheckHints = UnityEngine.PlayerPrefs.GetInt(key:  "total_chk_hnt", defaultValue:  0);
        this.ChaptersPlayedWithoutHints = UnityEngine.PlayerPrefs.GetInt(key:  "ch_no_hnts", defaultValue:  0);
        this.HintsUsedOnCurrentChapter = UnityEngine.PlayerPrefs.GetInt(key:  "hnts_used_ch", defaultValue:  0);
        this.adsNotClicked = UnityEngine.PlayerPrefs.GetInt(key:  "ads_not_clicked", defaultValue:  0);
        val_114 = null;
        val_114 = null;
        System.DateTime val_34 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "ads_last_clicked_time", defaultValue:  System.DateTime.MinValue.ToString()));
        this.AdsLastClickedTime = val_34;
        System.DateTime val_37 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "gotd_last_shown_time", defaultValue:  System.DateTime.MinValue.ToString()));
        this.GOTDLastShownTime = val_37;
        this.GOTDDaysSeenWoInstallation = UnityEngine.PlayerPrefs.GetInt(key:  "gotd_days_seen_wo_installation", defaultValue:  0);
        System.DateTime val_41 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "gotd_dont_show_until", defaultValue:  System.DateTime.MinValue.ToString()));
        this.GOTDDontShowUntil = val_41;
        this.incentivisedVideosWatched = UnityEngine.PlayerPrefs.GetInt(key:  "total_ivds", defaultValue:  0);
        this.WWWServerTimestamp = UnityEngine.PlayerPrefs.GetInt(key:  "www_ts", defaultValue:  0);
        this.WWWEventProgress = UnityEngine.PlayerPrefs.GetInt(key:  "www_prg", defaultValue:  0);
        this.wWWEventCollected = ((UnityEngine.PlayerPrefs.GetInt(key:  "www_col", defaultValue:  0)) == 1) ? 1 : 0;
        this.gridSize = UnityEngine.PlayerPrefs.GetFloat(key:  "pp_grid_size", defaultValue:  6f);
        System.DateTime val_50 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "no_ads_end", defaultValue:  System.DateTime.MinValue.ToString()));
        this.NoAdsEndTime = val_50;
        this.LevelsPlayedPostPurchase = UnityEngine.PlayerPrefs.GetInt(key:  "lvls_post_purch", defaultValue:  0);
        decimal val_53 = System.Decimal.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "pp_credits_purchas", defaultValue:  "0"), style:  511);
        this.credits_purchased = val_53;
        mem[1152921515620123904] = val_53.lo;
        mem[1152921515620123908] = val_53.mid;
        this.LastSeenDateString = UnityEngine.PlayerPrefs.GetString(key:  "last_seen_date", defaultValue:  "unknown");
        this.SkippedTutorial = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "pp_skp_t", defaultValue:  "false"));
        this.AdvancedSkipLevel = UnityEngine.PlayerPrefs.GetInt(key:  "pp_adv_l", defaultValue:  0);
        this.LifetimeDefinitionsViewed = UnityEngine.PlayerPrefs.GetInt(key:  "defs_seen", defaultValue:  0);
        this.GoalExtraWords = UnityEngine.PlayerPrefs.GetInt(key:  "goal_extra_words", defaultValue:  0);
        this.GoalUseHints = UnityEngine.PlayerPrefs.GetInt(key:  "goal_use_hints", defaultValue:  0);
        this.GoalGoldenCurrency = UnityEngine.PlayerPrefs.GetInt(key:  "goal_golden_curr", defaultValue:  0);
        this.GoalDailyChallenge = UnityEngine.PlayerPrefs.GetInt(key:  "goal_daily_chal", defaultValue:  0);
        this.GoalTwitterPosts = UnityEngine.PlayerPrefs.GetInt(key:  "goal_twitter_post", defaultValue:  0);
        this.GoalFriendInvites = UnityEngine.PlayerPrefs.GetInt(key:  "goal_friend_invite", defaultValue:  0);
        this.MysteryGiftReceived = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "mystery_gift_received", defaultValue:  "false"));
        this.story_mode_vote = UnityEngine.PlayerPrefs.GetString(key:  "story_mode_vote", defaultValue:  "None");
        this.ab_nextLevel = UnityEngine.PlayerPrefs.GetInt(key:  "ab_next_lvl", defaultValue:  0);
        this.ab_currentCollectionBox = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "ab_curr_coll_box", defaultValue:  "[]"));
        this.ab_currentCollectionProgress = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "ab_curr_coll_prg", defaultValue:  "[]"));
        decimal val_76 = System.Decimal.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "ab_curr_coll_bns", defaultValue:  "0"));
        this.ab_currentCollectionBonus = val_76;
        mem[1152921515620124032] = val_76.lo;
        mem[1152921515620124036] = val_76.mid;
        this.ab_currentCollectionIndex = UnityEngine.PlayerPrefs.GetInt(key:  "ab_curr_coll_ind", defaultValue:  0);
        this.ab_currentLanguage = UnityEngine.PlayerPrefs.GetString(key:  "ab_curr_lng", defaultValue:  "");
        this.ab_totalCollectionsComplete = UnityEngine.PlayerPrefs.GetInt(key:  "ab_tot_coll_com", defaultValue:  0);
        this.ab_lifeftime_redraws = UnityEngine.PlayerPrefs.GetInt(key:  "ab_tot_red", defaultValue:  0);
        this.numSubscriptionsPurchased = UnityEngine.PlayerPrefs.GetInt(key:  "numSubscriptionPurchases", defaultValue:  0);
        this.numTrialSubs = UnityEngine.PlayerPrefs.GetInt(key:  "numTrialSubs", defaultValue:  0);
        this.has_Active_Subscription = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "hasGoldenTicketSub", defaultValue:  "false"));
        this.numSubscriptionsPurchased_Silver = UnityEngine.PlayerPrefs.GetInt(key:  "numSubscriptionPurchasesSilver", defaultValue:  0);
        this.numTrialSubs_Silver = UnityEngine.PlayerPrefs.GetInt(key:  "numTrialSubsSilver", defaultValue:  0);
        this.has_Active_Subscription_Silver = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "hasSilverTicketSub", defaultValue:  "false"));
        this.LifetimeApplesEarnedFromExtraWords = UnityEngine.PlayerPrefs.GetInt(key:  "lt_extra_word_apples", defaultValue:  0);
        val_115 = null;
        val_115 = null;
        System.DateTime val_93 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "LastCoinSpent"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        this.LastCoinSpent = val_93;
        this.LifetimeLargestStreak = UnityEngine.PlayerPrefs.GetInt(key:  "largest_word_streak", defaultValue:  0);
        this.PlayerIQ = UnityEngine.PlayerPrefs.GetFloat(key:  "word_player_iq", defaultValue:  0f);
        this.LifetimeVipPartyPurchases = UnityEngine.PlayerPrefs.GetInt(key:  "vip_party_lifetime_purchases", defaultValue:  0);
        this.LifetimeProfileAvatarChanges = UnityEngine.PlayerPrefs.GetInt(key:  "profile_avatar_changes", defaultValue:  0);
        this.LifetimeProfileNameChanges = UnityEngine.PlayerPrefs.GetInt(key:  "profile_name_changes", defaultValue:  0);
        this.ads_segment = UnityEngine.PlayerPrefs.GetString(key:  "ads_segment", defaultValue:  System.String.alignConst);
        this.imported = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "imported_user", defaultValue:  "false"));
        this.oldSupportId = UnityEngine.PlayerPrefs.GetString(key:  "old_support_id", defaultValue:  System.String.alignConst);
        this.appleUserId = UnityEngine.PlayerPrefs.GetString(key:  "apple_user_id", defaultValue:  System.String.alignConst);
        this.ParseCategoryPacksPlayerData(json:  UnityEngine.PlayerPrefs.GetString(key:  "categories", defaultValue:  "{}"));
        this.treasure_chest = UnityEngine.PlayerPrefs.GetString(key:  "treasure_chest", defaultValue:  "{}");
        this.GoldenMultiplier = UnityEngine.PlayerPrefs.GetFloat(key:  "g_mult", defaultValue:  1f);
        this.verifiedEmail = System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "verified_email", defaultValue:  "false"));
        this.DailyChallengeTutorialStatus = UnityEngine.PlayerPrefs.GetInt(key:  "dct_seen", defaultValue:  0);
        this.prizeBalloonTapped = UnityEngine.PlayerPrefs.GetInt(key:  "balloon_tapped", defaultValue:  0);
        this.prizeBalloonAppeared = UnityEngine.PlayerPrefs.GetInt(key:  "balloon_appeared", defaultValue:  0);
    }
    public void Save(bool writePrefs = True)
    {
        this.mySaver.SoftSaveFull();
        if(writePrefs == false)
        {
                return;
        }
        
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void ParseCategoryPacksPlayerData(string json)
    {
        var val_7;
        string val_8;
        string val_22;
        var val_24;
        val_22 = 0;
        object val_1 = MiniJSON.Json.Deserialize(json:  json);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = 1152921504685600768;
        if((val_1.ContainsKey(key:  "ctpk_lvls")) == false)
        {
            goto label_23;
        }
        
        this.cpPackProgress = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        object val_4 = val_1.Item["ctpk_lvls"];
        if(val_4 == null)
        {
            goto label_23;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_5 = val_4.GetEnumerator();
        val_24 = 1152921510193071136;
        label_12:
        if(val_7.MoveNext() == false)
        {
            goto label_8;
        }
        
        int val_10 = 0;
        if(((System.Int32.TryParse(s:  val_8, result: out  val_10)) == false) || ((System.Int32.TryParse(s:  val_8, result: out  val_10)) == false))
        {
            goto label_12;
        }
        
        EnumerableExtentions.SetOrAdd<System.Int32, System.Int32>(dic:  this.cpPackProgress, key:  0, newValue:  0);
        goto label_12;
        label_8:
        val_7.Dispose();
        label_23:
        if((val_1.ContainsKey(key:  "ctpk_rewcur")) != false)
        {
                val_22 = "ctpk_rewcur";
            object val_14 = val_1.Item[val_22];
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_16 = System.Int32.TryParse(s:  val_14, result: out  this.cpRewardCurrentPacks);
        }
        
        if((val_1.ContainsKey(key:  "ctpk_rewtar")) == false)
        {
                return;
        }
        
        val_22 = "ctpk_rewtar";
        object val_18 = val_1.Item[val_22];
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_20 = System.Int32.TryParse(s:  val_18, result: out  this.cpRewardTargetPacks);
    }
    private void UpdateReleaseEvent(System.Collections.IDictionary diff)
    {
        object val_6;
        var val_8;
        val_6 = "machine_ranks";
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = public System.Object System.Collections.IDictionary::get_Item(object key);
        if(diff.Item[val_6] == null)
        {
                return;
        }
        
        this.releaseEventMachineRanks = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_8 = 0;
        Dictionary.Enumerator<TKey, TValue> val_6 = diff.Item["machine_ranks"].GetEnumerator();
        val_6 = 1152921515419383392;
        label_16:
        if(0.MoveNext() == false)
        {
            goto label_14;
        }
        
        if(this.releaseEventMachineRanks == null)
        {
                throw new NullReferenceException();
        }
        
        this.releaseEventMachineRanks.Add(key:  0, value:  0);
        goto label_16;
        label_14:
        0.Dispose();
    }

}
