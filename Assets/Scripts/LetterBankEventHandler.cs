using UnityEngine;
public class LetterBankEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "LetterBank";
    public static LetterBankEventHandler _Instance;
    private const string level_letters_accum_key = "lbe_lvl_accum";
    public static string log;
    public static int hack_multiplier;
    private AggregateEventCalculator levelLettersAggregate;
    private static bool _EligibleForEvent;
    private static int _CurrentBankValue;
    private static int _Tier1RequiredPoints;
    private static int _Tier2RequiredPoints;
    private static int _Tier3RequiredPoints;
    private static int _TotalRequiredPoints;
    private static int _MembersRequirement;
    private static int _ParticipantsRequirement;
    private static bool _EligibleForRewards;
    private static bool _RewardedTier1;
    private static bool _RewardedTier2;
    private static bool _RewardedTier3;
    private int _MyRank;
    private static int _CachedScore;
    private static int _MyServerScore;
    private static int _TotalClubBank;
    private static System.Collections.Generic.List<LetterBankEventPlayer> _EventPlayers;
    private static System.DateTime _EventEndTime;
    private static int lastKnownGuildId;
    private float lastWordUpdateTime;
    
    // Properties
    public static LetterBankEventHandler Instance { get; }
    private static int LastProgressTimestampPref { get; set; }
    public static bool EligibleForEvent { get; }
    public static int CurrentBankValue { get; }
    public static int Tier1RequiredPoints { get; }
    public static int Tier2RequiredPoints { get; }
    public static int Tier3RequiredPoints { get; }
    public static int TotalRequiredPoints { get; }
    public static int MembersRequirement { get; }
    public static int ParticipantsRequirement { get; }
    public static bool EligibleForRewards { get; }
    public static bool RewardedTier1 { get; }
    public static bool RewardedTier2 { get; }
    public static bool RewardedTier3 { get; }
    public int MyRank { get; }
    private static int CachedScore { get; set; }
    public static int MyScore { get; }
    public static int TotalClubBank { get; }
    public static System.Collections.Generic.List<LetterBankEventPlayer> EventPlayers { get; }
    public static System.DateTime EventEndTime { get; }
    
    // Methods
    public static LetterBankEventHandler get_Instance()
    {
        null = null;
        return (LetterBankEventHandler)LetterBankEventHandler.level_letters_accum_key;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "lbe_lst_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "lbe_lst_prog_ts", value:  value);
    }
    public static string GetLog()
    {
        null = null;
        return (string)LetterBankEventHandler.log;
    }
    public static bool get_EligibleForEvent()
    {
        null = null;
        return (bool)LetterBankEventHandler._EligibleForEvent;
    }
    public static int get_CurrentBankValue()
    {
        null = null;
        return (int)LetterBankEventHandler._CurrentBankValue;
    }
    public static int get_Tier1RequiredPoints()
    {
        null = null;
        return (int)LetterBankEventHandler._Tier1RequiredPoints;
    }
    public static int get_Tier2RequiredPoints()
    {
        null = null;
        return (int)LetterBankEventHandler._Tier2RequiredPoints;
    }
    public static int get_Tier3RequiredPoints()
    {
        null = null;
        return (int)LetterBankEventHandler._Tier3RequiredPoints;
    }
    public static int get_TotalRequiredPoints()
    {
        null = null;
        return (int)LetterBankEventHandler._TotalRequiredPoints;
    }
    public static int get_MembersRequirement()
    {
        null = null;
        return (int)LetterBankEventHandler._MembersRequirement;
    }
    public static int get_ParticipantsRequirement()
    {
        null = null;
        return (int)LetterBankEventHandler._ParticipantsRequirement;
    }
    public static bool get_EligibleForRewards()
    {
        null = null;
        return (bool)LetterBankEventHandler._EligibleForRewards;
    }
    public static bool get_RewardedTier1()
    {
        null = null;
        return (bool)LetterBankEventHandler._RewardedTier1;
    }
    public static bool get_RewardedTier2()
    {
        null = null;
        return (bool)LetterBankEventHandler._RewardedTier2;
    }
    public static bool get_RewardedTier3()
    {
        null = null;
        return (bool)LetterBankEventHandler._RewardedTier3;
    }
    public int get_MyRank()
    {
        var val_1;
        int val_2;
        val_1 = null;
        val_1 = null;
        if(LetterBankEventHandler._EligibleForEvent != false)
        {
                val_2 = this._MyRank;
            return (int)val_2;
        }
        
        val_2 = 0;
        return (int)val_2;
    }
    private static int get_CachedScore()
    {
        int val_3;
        var val_4 = null;
        if(LetterBankEventHandler._CachedScore == 0)
        {
                val_3 = "lbe_chd";
            if((UnityEngine.PlayerPrefs.HasKey(key:  "lbe_chd")) != false)
        {
                val_4 = null;
            val_3 = UnityEngine.PlayerPrefs.GetInt(key:  "lbe_chd", defaultValue:  0);
            val_4 = null;
            LetterBankEventHandler._CachedScore = val_3;
        }
        else
        {
                val_4 = null;
        }
        
        }
        
        val_4 = null;
        return (int)LetterBankEventHandler._CachedScore;
    }
    private static void set_CachedScore(int value)
    {
        var val_2;
        int val_3;
        val_2 = null;
        val_2 = null;
        LetterBankEventHandler._CachedScore = value;
        val_3 = LetterBankEventHandler._CachedScore;
        if(val_3 > 0)
        {
                val_3 = LetterBankEventHandler._CachedScore;
            UnityEngine.PlayerPrefs.SetInt(key:  "lbe_chd", value:  val_3);
        }
        else
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lbe_chd");
        }
        
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static int get_MyScore()
    {
        null = null;
        int val_1 = LetterBankEventHandler.CachedScore;
        val_1 = val_1 + LetterBankEventHandler._MyServerScore;
        return (int)val_1;
    }
    public static int get_TotalClubBank()
    {
        null = null;
        return (int)LetterBankEventHandler._TotalClubBank;
    }
    public static System.Collections.Generic.List<LetterBankEventPlayer> get_EventPlayers()
    {
        null = null;
        return (System.Collections.Generic.List<LetterBankEventPlayer>)LetterBankEventHandler._EventPlayers;
    }
    public static System.DateTime get_EventEndTime()
    {
        null = null;
        return (System.DateTime)LetterBankEventHandler._EventEndTime;
    }
    public override void Init(GameEventV2 eventV2)
    {
        null = null;
        LetterBankEventHandler.level_letters_accum_key = this;
        mem[1152921516316162304] = eventV2;
        this.UpdateData(eventV2:  eventV2);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        this.UpdateData(eventV2:  eventV2);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnLetterBankEventDataUpdate");
    }
    public override void OnProfileUpdated()
    {
        MonoSingleton<GameEventsManager>.Instance.CheckAndRequestServerEvents();
        LetterBankEventHandler.CheckTemporaryEventEligibility();
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        bool val_1 = CategoryPacksManager.IsPlaying;
        val_1 = (~(val_1 | dailyChallengeState)) & 1;
        return (bool)val_1;
    }
    public override void OnValidWordSubmitted(string word)
    {
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        int val_27;
        UnityEngine.Object val_28;
        val_24 = this;
        if(PlayingLevel.CurrentGameplayMode == 4)
        {
                return;
        }
        
        val_25 = null;
        val_25 = null;
        if(LetterBankEventHandler._EligibleForEvent == false)
        {
                return;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
        {
                return;
        }
        
        val_26 = null;
        val_26 = null;
        decimal val_5 = System.Decimal.op_Implicit(value:  LetterBankEventHandler.hack_multiplier * word.m_stringLength);
        this.levelLettersAggregate.Calculate(valueToAggregate:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, autoFlush:  false);
        int val_23 = word.m_stringLength;
        val_23 = LetterBankEventHandler._CurrentBankValue + (LetterBankEventHandler.hack_multiplier * val_23);
        LetterBankEventHandler._CurrentBankValue = val_23;
        int val_6 = LetterBankEventHandler.CachedScore;
        val_6 = val_6 + (LetterBankEventHandler.hack_multiplier * word.m_stringLength);
        LetterBankEventHandler.CachedScore = val_6;
        val_27 = 1152921504893161472;
        val_28 = MonoSingleton<LetterBankEventGameplayUIController>.Instance;
        if(val_28 != 0)
        {
                val_28 = MonoSingleton<LetterBankEventGameplayUIController>.Instance;
            val_27 = word.m_stringLength;
            val_28.UpdateCurrency(from:  LetterBankEventHandler.MyScore - val_27, to:  LetterBankEventHandler.MyScore);
        }
        
        float val_13 = UnityEngine.Time.time;
        val_13 = val_13 - this.lastWordUpdateTime;
        if(val_13 > 60f)
        {
                LetterBankEventHandler.UpdateStatus();
            this.lastWordUpdateTime = UnityEngine.Time.time;
        }
        
        val_24 = ???;
        val_23 = ???;
        goto typeof(LetterBankEventHandler).__il2cppRuntimeField_2B0;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        var val_4;
        var val_5;
        if(PlayingLevel.CurrentGameplayMode == 4)
        {
                return;
        }
        
        val_4 = 1152921504919412736;
        val_5 = null;
        val_5 = null;
        if(LetterBankEventHandler._EligibleForEvent == false)
        {
                return;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
        {
                return;
        }
        
        LetterBankEventHandler.TryShowCollectableRewards(flyout:  false);
        LetterBankEventHandler.UpdateStatus();
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "letter_bank_upper", defaultValue:  "LETTER BANK", useSingularKey:  false);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "letter_bank_upper", defaultValue:  "LETTER BANK", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return "n/a";
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        null = null;
        EventListItemContentLetterBank val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentLetterBank>(allowMultiple:  false);
        float val_2 = (float)LetterBankEventHandler._CurrentBankValue;
        val_2 = val_2 / (float)LetterBankEventHandler._Tier3RequiredPoints;
        goto typeof(EventListItemContentLetterBank).__il2cppRuntimeField_180;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public LetterBankEventPopup MetaGameBehavior::ShowUGUIMonolith<LetterBankEventPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override void OnGameButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.ShowGameplayVersion();
    }
    public override void OnLevelCompleteRewarded()
    {
        LetterBankEventHandler.TryShowCollectableRewards(flyout:  false);
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return false;
    }
    public override bool EventCompleted()
    {
        var val_3;
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        Player val_1 = App.Player;
        if(val_1.isHacker != false)
        {
                val_4 = 1;
            return (bool)val_4;
        }
        
        val_3 = 1152921504919412736;
        val_5 = null;
        val_5 = null;
        if(LetterBankEventHandler._RewardedTier1 != false)
        {
                val_6 = null;
            val_6 = null;
            if(LetterBankEventHandler._RewardedTier2 != false)
        {
                val_7 = null;
            val_7 = null;
            var val_2 = (LetterBankEventHandler._RewardedTier3 == true) ? 1 : 0;
            return (bool)val_4;
        }
        
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public override bool IsExcludedFromGameSceneButtonOrdering()
    {
        var val_5;
        var val_6;
        var val_7;
        if(CategoryPacksManager.IsPlaying != true)
        {
                val_5 = 1152921504919412736;
            val_6 = null;
            val_6 = null;
            if(LetterBankEventHandler._EligibleForEvent != false)
        {
                var val_4 = (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == 0) ? 1 : 0;
            return (bool)val_7;
        }
        
        }
        
        val_7 = 1;
        return (bool)val_7;
    }
    public static void TryShowCollectableRewards(bool flyout = True)
    {
        var val_7 = null;
        if(LetterBankEventHandler.RewardsAvailable() == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        goto mem[(1152921504946249728 + (public LetterBankEventPopup MetaGameBehavior::ShowUGUIMonolith<LetterBankEventPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public static void CollectedTierReward()
    {
        var val_3;
        var val_5;
        var val_6;
        var val_8;
        val_3 = null;
        val_5 = 0;
        if(LetterBankEventHandler._RewardedTier1 == false)
        {
            goto label_7;
        }
        
        val_3 = null;
        val_8 = 0;
        goto label_12;
        label_7:
        val_3 = null;
        val_6 = 1152921504919416885;
        goto label_28;
        label_12:
        if(LetterBankEventHandler._RewardedTier2 == false)
        {
            goto label_17;
        }
        
        val_3 = null;
        val_3 = null;
        if(LetterBankEventHandler._RewardedTier3 == true)
        {
            goto label_23;
        }
        
        val_3 = null;
        val_6 = 1152921504919416887;
        goto label_28;
        label_17:
        val_3 = null;
        val_6 = 1152921504919416886;
        label_28:
        LetterBankEventHandler._RewardedTier2 = true;
        label_23:
        LetterBankEventHandler.UpdateStatus();
    }
    public static void UpdateStatus()
    {
        var val_3;
        var val_4;
        var val_5;
        var val_6;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3 = null;
        val_1.Add(key:  "bank", value:  LetterBankEventHandler.MyScore);
        val_4 = null;
        val_4 = null;
        val_1.Add(key:  "rewarded_1", value:  LetterBankEventHandler._RewardedTier1);
        val_5 = null;
        val_5 = null;
        val_1.Add(key:  "rewarded_2", value:  LetterBankEventHandler._RewardedTier2);
        val_6 = null;
        val_6 = null;
        val_1.Add(key:  "rewarded_3", value:  LetterBankEventHandler._RewardedTier3);
        LetterBankEventHandler.UpdateToServer(data:  val_1);
    }
    public static bool RewardsAvailable()
    {
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        val_2 = null;
        val_2 = null;
        if(LetterBankEventHandler._EligibleForEvent == false)
        {
                return false;
        }
        
        val_3 = null;
        val_3 = null;
        if(LetterBankEventHandler._EligibleForRewards == false)
        {
                return false;
        }
        
        val_4 = null;
        val_4 = null;
        val_4 = null;
        val_4 = null;
        if(LetterBankEventHandler._TotalClubBank >= LetterBankEventHandler._Tier1RequiredPoints)
        {
                val_4 = null;
            val_4 = null;
            if(LetterBankEventHandler._RewardedTier1 == false)
        {
                return false;
        }
        
        }
        
        val_5 = null;
        val_5 = null;
        val_5 = null;
        val_5 = null;
        if(LetterBankEventHandler._TotalClubBank >= LetterBankEventHandler._Tier2RequiredPoints)
        {
                val_5 = null;
            val_5 = null;
            if(LetterBankEventHandler._RewardedTier2 == false)
        {
                return false;
        }
        
        }
        
        val_6 = null;
        val_6 = null;
        val_6 = null;
        val_6 = null;
        if(LetterBankEventHandler._TotalClubBank < LetterBankEventHandler._Tier3RequiredPoints)
        {
                return false;
        }
        
        val_7 = null;
        val_7 = null;
        var val_1 = (LetterBankEventHandler._RewardedTier3 == false) ? 1 : 0;
        return false;
    }
    public static System.Collections.Generic.List<GiftReward> GetCollectableRewards()
    {
        var val_5;
        var val_6;
        var val_7;
        int val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        System.Collections.Generic.List<GiftReward> val_14;
        string val_15;
        val_5 = null;
        val_5 = null;
        if(LetterBankEventHandler._EligibleForEvent == false)
        {
                return 0;
        }
        
        val_6 = null;
        val_6 = null;
        if(LetterBankEventHandler._EligibleForRewards == false)
        {
                return 0;
        }
        
        val_7 = null;
        val_7 = null;
        val_8 = LetterBankEventHandler._TotalClubBank;
        val_7 = null;
        val_7 = null;
        if(val_8 < LetterBankEventHandler._Tier1RequiredPoints)
        {
                return 0;
        }
        
        System.Collections.Generic.List<GiftReward> val_1 = new System.Collections.Generic.List<GiftReward>();
        val_9 = null;
        val_9 = null;
        if(LetterBankEventHandler._RewardedTier1 == false)
        {
            goto label_27;
        }
        
        val_10 = null;
        val_10 = null;
        val_8 = LetterBankEventHandler._TotalClubBank;
        val_10 = null;
        val_10 = null;
        if(val_8 < LetterBankEventHandler._Tier2RequiredPoints)
        {
                return 0;
        }
        
        val_11 = null;
        val_11 = null;
        if(LetterBankEventHandler._RewardedTier2 == false)
        {
            goto label_42;
        }
        
        val_12 = null;
        val_12 = null;
        val_12 = null;
        val_12 = null;
        if(LetterBankEventHandler._TotalClubBank < LetterBankEventHandler._Tier3RequiredPoints)
        {
                return 0;
        }
        
        val_13 = null;
        val_13 = null;
        if(LetterBankEventHandler._RewardedTier3 == false)
        {
            goto label_57;
        }
        
        return 0;
        label_27:
        val_14 = LetterBankEconomy.tier_1.RollRewards();
        val_15 = "Letter Bank Tier 1";
        goto label_65;
        label_42:
        val_14 = LetterBankEconomy.tier_2.RollRewards();
        val_15 = "Letter Bank Tier 2";
        goto label_65;
        label_57:
        val_14 = LetterBankEconomy.tier_3.RollRewards();
        val_15 = "Letter Bank Tier 3";
        label_65:
        LetterBankEventHandler.AddRewardsToPlayer(giftRewards:  val_14, source:  val_15);
        return 0;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "Letters Collected", value:  this.levelLettersAggregate.aggregate);
        this.levelLettersAggregate.Flush();
    }
    public override void AppendLeaguesRolloverData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        null = null;
        currentData.Add(key:  "Letters Collected", value:  LetterBankEventHandler._CurrentBankValue);
    }
    public override int LastProgressTimestamp()
    {
        return LetterBankEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        LetterBankEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    private static void UpdateToServer(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_2 = null;
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  LetterBankEventHandler.level_letters_accum_key.m_stringLength + 56, data:  data);
    }
    private void UpdateData(GameEventV2 eventV2)
    {
        LetterBankTierRewardInfo val_123;
        int val_124;
        var val_125;
        var val_126;
        System.DateTime val_127;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_128;
        var val_129;
        var val_130;
        var val_131;
        var val_132;
        var val_133;
        var val_134;
        var val_135;
        string val_136;
        var val_137;
        var val_138;
        var val_139;
        var val_140;
        var val_141;
        var val_142;
        var val_143;
        var val_144;
        var val_145;
        var val_147;
        var val_148;
        var val_149;
        var val_150;
        var val_151;
        var val_152;
        val_123 = eventV2;
        if(val_123 == null)
        {
                return;
        }
        
        if(eventV2.eventData == null)
        {
                return;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.IsAvailable() != false)
        {
                SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_124 = val_3.GuildServerId;
        }
        else
        {
                val_124 = 0;
        }
        
        val_125 = null;
        val_125 = null;
        LetterBankEventHandler.lastKnownGuildId = val_124;
        if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Debug.Log(message:  "LetterBank event data: "("LetterBank event data: ") + PrettyPrint.printJSON(obj:  eventV2.eventData, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  eventV2.eventData, types:  false, singleLineOutput:  false)));
        }
        
        val_126 = null;
        val_127 = eventV2.timeEnd;
        val_126 = null;
        LetterBankEventHandler._EventEndTime = val_127;
        val_128 = eventV2.eventData;
        if((val_128.ContainsKey(key:  "eligible")) != false)
        {
                val_127 = val_128.Item["eligible"];
            bool val_10 = System.Boolean.TryParse(value:  val_127, result: out  1152921504919416852);
        }
        
        val_129 = null;
        val_129 = null;
        if(LetterBankEventHandler._EligibleForEvent == false)
        {
                return;
        }
        
        if((val_128.ContainsKey(key:  "reward_req")) != false)
        {
                val_130 = null;
            val_130 = null;
            object[] val_12 = new object[4];
            System.DateTime val_13 = System.DateTime.UtcNow;
            val_12[0] = val_13.dateData.ToString();
            Player val_15 = App.Player;
            val_12[1] = val_15.id;
            SLC.Social.Leagues.Guild val_17 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_12[2] = val_17.guildLevel.ToString();
            val_12[3] = PrettyPrint.printJSON(obj:  val_128.Item["reward_req"], types:  false, singleLineOutput:  false);
            LetterBankEventHandler.log = LetterBankEventHandler.log + System.String.Format(format:  "[{0}]\n\tPlayer id: {1}\n\tClub Level: {2}\n\treward_req: {3}\n", args:  val_12)(System.String.Format(format:  "[{0}]\n\tPlayer id: {1}\n\tClub Level: {2}\n\treward_req: {3}\n", args:  val_12));
            val_127 = val_128.Item["reward_req"];
            if((val_127.ContainsKey(key:  "members")) != false)
        {
                val_131 = null;
            val_131 = null;
            bool val_27 = System.Int32.TryParse(s:  val_127.Item["members"], result: out  1152921504919416876);
        }
        
            if((val_127.ContainsKey(key:  "tier_1")) != false)
        {
                val_132 = null;
            val_132 = null;
            bool val_31 = System.Int32.TryParse(s:  val_127.Item["tier_1"], result: out  1152921504919416860);
        }
        
            if((val_127.ContainsKey(key:  "tier_2")) != false)
        {
                val_133 = null;
            val_133 = null;
            bool val_35 = System.Int32.TryParse(s:  val_127.Item["tier_2"], result: out  1152921504919416864);
        }
        
            if((val_127.ContainsKey(key:  "tier_3")) != false)
        {
                val_134 = null;
            val_134 = null;
            bool val_39 = System.Int32.TryParse(s:  val_127.Item["tier_3"], result: out  1152921504919416868);
        }
        
            if((val_127.ContainsKey(key:  "total")) != false)
        {
                val_135 = null;
            val_135 = null;
            bool val_43 = System.Int32.TryParse(s:  val_127.Item["total"], result: out  1152921504919416872);
        }
        
            if((val_127.ContainsKey(key:  "eligible")) != false)
        {
                val_127 = val_127.Item["eligible"];
            bool val_47 = System.Boolean.TryParse(value:  val_127, result: out  1152921504919416884);
        }
        
        }
        
        val_136 = "club_total";
        val_137 = 1152921504919412736;
        if((val_128.ContainsKey(key:  "club_total")) != false)
        {
                val_138 = null;
            val_127 = val_128.Item["club_total"];
            val_138 = null;
            bool val_51 = System.Int32.TryParse(s:  val_127, result: out  1152921504919416856);
        }
        
        if(((val_128.ContainsKey(key:  "progress")) != false) && (val_128.Item["progress"] != null))
        {
                object val_54 = val_128.Item["progress"];
            if(val_54 != null)
        {
                val_127 = val_54;
            if((val_127.ContainsKey(key:  "rewarded_1")) != false)
        {
                if(val_127.Item["rewarded_1"] != null)
        {
                bool val_59 = System.Boolean.TryParse(value:  val_127.Item["rewarded_1"], result: out  1152921504919416885);
        }
        
        }
        
            if((val_127.ContainsKey(key:  "rewarded_2")) != false)
        {
                if(val_127.Item["rewarded_2"] != null)
        {
                bool val_64 = System.Boolean.TryParse(value:  val_127.Item["rewarded_2"], result: out  1152921504919416886);
        }
        
        }
        
            if((val_127.ContainsKey(key:  "rewarded_3")) != false)
        {
                if(val_127.Item["rewarded_3"] != null)
        {
                val_127 = val_127.Item["rewarded_3"];
            bool val_69 = System.Boolean.TryParse(value:  val_127, result: out  1152921504919416887);
        }
        
        }
        
        }
        
        }
        
        if((val_128.ContainsKey(key:  "rankings")) == false)
        {
            goto label_119;
        }
        
        System.Collections.Generic.List<LetterBankEventPlayer> val_71 = new System.Collections.Generic.List<LetterBankEventPlayer>();
        val_139 = null;
        val_139 = null;
        LetterBankEventHandler._EventPlayers = val_71;
        object val_72 = val_128.Item["rankings"];
        if(null < 1)
        {
            goto label_125;
        }
        
        var val_124 = 0;
        label_173:
        if(val_124 >= 1152921504919199744)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((ContainsKey(key:  "id")) != false)
        {
                .guildMemberId = System.Int32.Parse(s:  Item["id"]);
        }
        
        if((ContainsKey(key:  "name")) != false)
        {
                .name = Item["name"];
        }
        
        if((ContainsKey(key:  "bank")) != false)
        {
                .score = System.Int32.Parse(s:  Item["bank"]);
        }
        
        if((ContainsKey(key:  "avatar_id")) != false)
        {
                .avatarId = System.Int32.Parse(s:  Item["avatar_id"]);
        }
        
        if((ContainsKey(key:  "fb_id")) != false)
        {
                if(Item["fb_id"] != null)
        {
                .facebookId = Item["fb_id"];
        }
        
        }
        
        if((ContainsKey(key:  "use_fb_pic")) != false)
        {
                .useFacebook = System.Boolean.Parse(value:  Item["use_fb_pic"]);
            val_137 = 1152921504919412736;
        }
        
        if((ContainsKey(key:  "is_me")) != false)
        {
                .isMe = System.Boolean.Parse(value:  Item["is_me"]);
        }
        
        if((LetterBankEventPlayer)[1152921516319875504].isMe == false)
        {
            goto label_158;
        }
        
        mem[1152921516319687864] = val_124;
        val_140 = null;
        var val_123 = LetterBankEventHandler.CachedScore;
        val_141 = null;
        val_123 = val_123 + LetterBankEventHandler._MyServerScore;
        if(val_123 <= (LetterBankEventPlayer)[1152921516319875504].score)
        {
            goto label_161;
        }
        
        val_141 = null;
        val_142 = (LetterBankEventHandler.CachedScore + LetterBankEventHandler._MyServerScore) - (LetterBankEventPlayer)[1152921516319875504].score;
        goto label_164;
        label_158:
        val_143 = null;
        goto label_165;
        label_161:
        val_142 = 0;
        label_164:
        LetterBankEventHandler.CachedScore = 0;
        val_143 = null;
        val_143 = null;
        LetterBankEventHandler._MyServerScore = (LetterBankEventPlayer)[1152921516319875504].score;
        label_165:
        val_143 = null;
        val_71.Add(item:  new LetterBankEventPlayer());
        val_124 = val_124 + 1;
        if(val_124 < 1152921516319605120)
        {
            goto label_173;
        }
        
        label_125:
        val_144 = null;
        val_136 = "club_total";
        val_145 = null;
        val_128 = val_128;
        val_127 = LetterBankEventHandler.<>c.<>9__95_0;
        if(val_127 == null)
        {
                System.Func<LetterBankEventPlayer, System.Int32> val_99 = null;
            val_127 = val_99;
            val_99 = new System.Func<LetterBankEventPlayer, System.Int32>(object:  LetterBankEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LetterBankEventHandler.<>c::<UpdateData>b__95_0(LetterBankEventPlayer p));
            LetterBankEventHandler.<>c.<>9__95_0 = val_127;
        }
        
        val_147 = null;
        val_147 = null;
        LetterBankEventHandler._EventPlayers = System.Linq.Enumerable.ToList<LetterBankEventPlayer>(source:  System.Linq.Enumerable.OrderByDescending<LetterBankEventPlayer, System.Int32>(source:  val_71, keySelector:  val_99));
        label_119:
        if((ContainsKey(key:  null)) != false)
        {
                val_148 = null;
            val_148 = null;
            bool val_105 = System.Int32.TryParse(s:  Item["club_total"], result: out  1152921504919416896);
        }
        
        val_123 = "economy";
        if((ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_136 = 1152921510214912464;
        val_123 = Item["economy"];
        val_127 = 1152921504919412736;
        if((val_123.ContainsKey(key:  "ptcps_req")) != false)
        {
                val_149 = null;
            val_149 = null;
            bool val_111 = System.Int32.TryParse(s:  val_123.Item["ptcps_req"], result: out  1152921504919416880);
        }
        
        if((val_123.ContainsKey(key:  "rew")) == false)
        {
                return;
        }
        
        val_123 = val_123.Item["rew"];
        if((val_123.ContainsKey(key:  "t_1")) != false)
        {
                val_127 = val_123.Item["t_1"];
            val_150 = 0;
            new LetterBankTierRewardInfo() = new LetterBankTierRewardInfo(chances:  null);
            if((LetterBankTierRewardInfo)[1152921516319945136].successfullyParsed != false)
        {
                LetterBankEconomy.tier_1 = new LetterBankTierRewardInfo();
        }
        
        }
        
        if((val_123.ContainsKey(key:  "t_2")) != false)
        {
                val_127 = val_123.Item["t_2"];
            val_151 = 0;
            new LetterBankTierRewardInfo() = new LetterBankTierRewardInfo(chances:  null);
            if((LetterBankTierRewardInfo)[1152921516319953328].successfullyParsed != false)
        {
                LetterBankEconomy.tier_2 = new LetterBankTierRewardInfo();
        }
        
        }
        
        if((val_123.ContainsKey(key:  "t_3")) == false)
        {
                return;
        }
        
        object val_121 = val_123.Item["t_3"];
        val_123 = new LetterBankTierRewardInfo();
        val_152 = 0;
        val_123 = new LetterBankTierRewardInfo(chances:  null);
        if((LetterBankTierRewardInfo)[1152921516319961520].successfullyParsed == false)
        {
                return;
        }
        
        LetterBankEconomy.tier_3 = val_123;
    }
    private static void AddRewardsToPlayer(System.Collections.Generic.List<GiftReward> giftRewards, string source)
    {
        var val_2;
        var val_3;
        int val_11;
        int val_12;
        var val_13;
        List.Enumerator<T> val_1 = giftRewards.GetEnumerator();
        label_25:
        val_11 = public System.Boolean List.Enumerator<GiftReward>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_13 = null;
        val_13 = null;
        val_11 = val_2 + 40 + 8;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_2 + 40, hi = val_2 + 40, lo = val_11, mid = val_11}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
            goto label_25;
        }
        
        if((val_2 + 16) == 3)
        {
            goto label_7;
        }
        
        if((val_2 + 16) == 1)
        {
            goto label_8;
        }
        
        if((val_2 + 16) != 0)
        {
            goto label_25;
        }
        
        Player val_6 = App.Player;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.AddCredits(amount:  new System.Decimal() {flags = val_2 + 40, hi = val_2 + 40, lo = val_2 + 40 + 8, mid = val_2 + 40 + 8}, source:  source, subSource:  0, externalParams:  0, doTrack:  true);
        goto label_25;
        label_7:
        WADPetsManager val_7 = MonoSingleton<WADPetsManager>.Instance;
        val_12 = val_2 + 40;
        val_11 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_12, hi = val_12, lo = val_2 + 40 + 8, mid = val_2 + 40 + 8});
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.RewardPetCards(amount:  val_11, pet:  val_2 + 32, source:  source, subsource:  0, additionalParam:  0);
        goto label_25;
        label_8:
        Player val_9 = App.Player;
        val_12 = val_2 + 40;
        val_11 = System.Convert.ToInt32(value:  new System.Decimal() {flags = val_12, hi = val_12, lo = val_2 + 40 + 8, mid = val_2 + 40 + 8});
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.AddPetsFood(amount:  val_11, source:  source, subSource:  0, FoodSpentParams:  0, additionalParam:  0);
        goto label_25;
        label_2:
        val_3.Dispose();
    }
    private static void CheckTemporaryEventEligibility()
    {
        var val_6;
        var val_8;
        int val_10;
        var val_11;
        var val_12;
        val_6 = null;
        val_6 = null;
        if(LetterBankEventHandler._EligibleForEvent != true)
        {
                if(LetterBankEventHandler.lastKnownGuildId == 1)
        {
            goto label_6;
        }
        
        }
        
        label_30:
        val_8 = null;
        val_8 = null;
        if(LetterBankEventHandler._EligibleForEvent == false)
        {
                return;
        }
        
        val_8 = null;
        val_10 = LetterBankEventHandler.lastKnownGuildId;
        if(val_10 == 1)
        {
                return;
        }
        
        val_10 = LetterBankEventHandler.lastKnownGuildId;
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if(val_10 == val_2.GuildServerId)
        {
                return;
        }
        
        val_11 = null;
        val_11 = null;
        LetterBankEventHandler._EligibleForEvent = false;
        return;
        label_6:
        SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        if((val_4.GuildServerId == 1) || (App.Player < 50))
        {
            goto label_30;
        }
        
        val_12 = null;
        val_12 = null;
        LetterBankEventHandler._EligibleForEvent = true;
    }
    public LetterBankEventHandler()
    {
        this.levelLettersAggregate = new AggregateEventCalculator(name:  "lbe_lvl_accum");
        this._MyRank = 0;
    }
    private static LetterBankEventHandler()
    {
        LetterBankEventHandler.log = "Requirements Response Log:\n";
        LetterBankEventHandler.hack_multiplier = 1;
        LetterBankEventHandler._EligibleForEvent = false;
        LetterBankEventHandler._CurrentBankValue = 0;
        LetterBankEventHandler._Tier1RequiredPoints = 1000;
        LetterBankEventHandler._Tier2RequiredPoints = 2000;
        LetterBankEventHandler._Tier3RequiredPoints = 3000;
        LetterBankEventHandler._TotalRequiredPoints = 3000;
        LetterBankEventHandler._MembersRequirement = 5;
        LetterBankEventHandler._ParticipantsRequirement = 3;
        LetterBankEventHandler._EligibleForRewards = false;
        LetterBankEventHandler._RewardedTier1 = false;
        LetterBankEventHandler._RewardedTier2 = false;
        LetterBankEventHandler._RewardedTier3 = false;
        LetterBankEventHandler._CachedScore = 0;
        LetterBankEventHandler._MyServerScore = 0;
        LetterBankEventHandler._TotalClubBank = 0;
        LetterBankEventHandler.lastKnownGuildId = 0;
    }

}
