using UnityEngine;
public class ClubClashEvent : WGEventHandler
{
    // Fields
    private static ClubClashEvent _Instance;
    public const string CROWN_CLASH_EVENT_ID = "CrownClashCvC";
    public const string EVENT_TRACKING_ID = "Club Clash Event";
    public const string crownClashPromptKey = "lastCrownClashPrompt";
    private const string crownClashCrownsCollectedThisLevel = "ccCrownsCollectedThisLevel";
    private const string crownClashRewardDataKey = "ccRewardData";
    private const string LAST_PROGRESS_STAMP_KEY = "ccCrowns_LastProgressTimestamp";
    private bool promptEvent;
    private bool hasShownNoInternetThisSession;
    private int unlockLevel;
    private int _clubCapacity;
    private int _clubCrowns;
    private int _membershipCrowns;
    private System.Collections.Generic.Dictionary<string, object> <opponentData>k__BackingField;
    private string <curStatus>k__BackingField;
    private System.Collections.Generic.Dictionary<string, object> rewardData;
    private System.Collections.Generic.Dictionary<GameEventRewardType, object> rewardEarnings;
    public int fallbackMyClubImageIndex;
    public int fallbackOtherClub;
    private bool hasInit;
    private bool hasInitLevel;
    private bool hasParsedEventData;
    private System.Collections.Generic.Dictionary<string, object> eventRewards;
    private System.Collections.Generic.Dictionary<string, object> eventRewardsGoldenCurrency;
    
    // Properties
    public static ClubClashEvent Instance { get; }
    public int clubCapacity { get; }
    public int clubCrowns { get; }
    public int membershipCrowns { get; }
    public System.Collections.Generic.Dictionary<string, object> opponentData { get; set; }
    public GameEventV2 myData { get; }
    public string curStatus { get; set; }
    public int crownsCollectedThisLevel { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    public bool hasRewardData { get; }
    public System.Collections.Generic.Dictionary<string, object> getRewardData { get; }
    public System.Collections.Generic.Dictionary<GameEventRewardType, object> getRewardEarnings { get; }
    public System.Collections.Generic.Dictionary<string, object> rewardValues { get; }
    public int baseRewardCoins { get; }
    public System.Collections.Generic.Dictionary<string, object> rewardValuesGoldenCurrency { get; }
    public int baseRewardGoldenCurrency { get; }
    public override bool SupportsGoldenApples { get; }
    
    // Methods
    public static ClubClashEvent get_Instance()
    {
        return (ClubClashEvent)ClubClashEvent.LAST_PROGRESS_STAMP_KEY;
    }
    public int get_clubCapacity()
    {
        return (int)this._clubCapacity;
    }
    public int get_clubCrowns()
    {
        return (int)this._clubCrowns;
    }
    public int get_membershipCrowns()
    {
        return (int)this._membershipCrowns;
    }
    public System.Collections.Generic.Dictionary<string, object> get_opponentData()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.<opponentData>k__BackingField;
    }
    private void set_opponentData(System.Collections.Generic.Dictionary<string, object> value)
    {
        this.<opponentData>k__BackingField = value;
    }
    public GameEventV2 get_myData()
    {
        return (GameEventV2)this;
    }
    public string get_curStatus()
    {
        return (string)this.<curStatus>k__BackingField;
    }
    private void set_curStatus(string value)
    {
        this.<curStatus>k__BackingField = value;
    }
    public int get_crownsCollectedThisLevel()
    {
        return CPlayerPrefs.GetInt(key:  "ccCrownsCollectedThisLevel", defaultValue:  0);
    }
    public void set_crownsCollectedThisLevel(int value)
    {
        CPlayerPrefs.SetInt(key:  "ccCrownsCollectedThisLevel", val:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ccCrowns_LastProgressTimestamp", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ccCrowns_LastProgressTimestamp", value:  value);
    }
    public bool get_hasRewardData()
    {
        return (bool)(this.rewardData != 0) ? 1 : 0;
    }
    public System.Collections.Generic.Dictionary<string, object> get_getRewardData()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.rewardData;
    }
    public System.Collections.Generic.Dictionary<GameEventRewardType, object> get_getRewardEarnings()
    {
        return (System.Collections.Generic.Dictionary<GameEventRewardType, System.Object>)this.rewardEarnings;
    }
    public System.Collections.Generic.Dictionary<string, object> get_rewardValues()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.eventRewards;
    }
    public int get_baseRewardCoins()
    {
        var val_3;
        if((this.eventRewards.ContainsKey(key:  "0")) != false)
        {
                object val_2 = this.eventRewards.Item["0"];
            return (int)val_3;
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public System.Collections.Generic.Dictionary<string, object> get_rewardValuesGoldenCurrency()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.eventRewardsGoldenCurrency;
    }
    public int get_baseRewardGoldenCurrency()
    {
        var val_3;
        if((this.eventRewardsGoldenCurrency.ContainsKey(key:  "0")) != false)
        {
                object val_2 = this.eventRewardsGoldenCurrency.Item["0"];
            return (int)val_3;
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    private void Start()
    {
    
    }
    public override void Init(GameEventV2 eventV2)
    {
        if(this.hasInit == true)
        {
                return;
        }
        
        mem[1152921516156612064] = eventV2;
        this.CheckData(gameEvent:  eventV2);
        this.ParseEventData(eventData:  eventV2.eventData);
        ClubClashEvent.LAST_PROGRESS_STAMP_KEY = this;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                this.LevelInit();
            this.hasInitLevel = true;
        }
        
        this.hasInit = true;
    }
    public override string GetGameButtonText()
    {
        return "CLUB CLASH";
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<ClubClashEventWindow>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<ClubClashEventWindow>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "club_clash_upper", defaultValue:  "CLUB CLASH", useSingularKey:  false);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "club_clash_upper", defaultValue:  "CLUB CLASH", useSingularKey:  false);
    }
    public override void OnMenuLoaded()
    {
    
    }
    public override void OnGameSceneInit()
    {
        if(this.hasInit == false)
        {
                return;
        }
        
        this.CheckRewardedPopup();
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        this.hasInitLevel = true;
        this.LevelInit();
        this.promptEvent = ((CPlayerPrefs.GetInt(key:  "lastCrownClashPrompt", defaultValue:  0)) != null) ? 1 : 0;
        GameBehavior val_4 = App.getBehavior;
        if((val_4.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        if(this.promptEvent == false)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  this.<curStatus>k__BackingField, b:  "created")) == false)
        {
                return;
        }
        
        mem2[0] = 1152921516156832624;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<ClubClashEventWindow>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    private void CheckRewardedPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        if(this.rewardData == null)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  this.<curStatus>k__BackingField, b:  "rewarded")) == false)
        {
                return;
        }
        
        mem2[0] = 1152921516156832624;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<ClubClashEventWindow>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    public override bool IsEventEndedOffline()
    {
        return this.IsEventEndedOffline();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        this.OnDataUpdated(eventV2:  eventV2);
        this.ParseEventData(eventData:  eventV2.eventData);
    }
    public override void OnEventEnded()
    {
        this.ResetData();
    }
    public override bool EventCompleted()
    {
        if(App.Player < this.unlockLevel)
        {
                return true;
        }
        
        Player val_2 = App.Player;
        if(val_2.isHacker != false)
        {
                return true;
        }
        
        if(this.rewardData != null)
        {
                return true;
        }
        
        if(((System.String.op_Equality(a:  this.<curStatus>k__BackingField, b:  "rewarded")) == true) || (this.hasParsedEventData == false))
        {
                return true;
        }
        
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40})) != false)
        {
                if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() != false)
        {
                if(this.rewardData == null)
        {
                return true;
        }
        
        }
        
        }
        
        if((System.String.op_Equality(a:  this.<curStatus>k__BackingField, b:  "rewarding")) == true)
        {
                return true;
        }
        
        if(this.rewardData == null)
        {
                return true;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
        {
                return true;
        }
        
        GameBehavior val_9 = App.getBehavior;
        if((val_9.<metaGameBehavior>k__BackingField) != 2)
        {
                return true;
        }
        
        if(this.hasInitLevel == true)
        {
                return true;
        }
        
        return true;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "CC League Points Total", value:  this._membershipCrowns);
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() != false)
        {
                1152921516158343488 = currentData;
            1152921516158343488.Add(key:  "CC Clubs League Points", value:  this._clubCrowns);
        }
        
        1152921516158343488.crownsCollectedThisLevel = 0;
    }
    public override int LastProgressTimestamp()
    {
        return ClubClashEvent.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        ClubClashEvent.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        var val_14;
        int val_15;
        var val_17;
        float val_18;
        val_14 = this._membershipCrowns.ToString();
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() != false)
        {
                val_14 = this._clubCrowns.ToString();
        }
        
        if(((this.<opponentData>k__BackingField) == null) || ((this.<opponentData>k__BackingField.ContainsKey(key:  "crowns")) == false))
        {
            goto label_5;
        }
        
        int val_6 = System.Int32.Parse(s:  this.<opponentData>k__BackingField.Item["crowns"]);
        val_15 = this._clubCrowns;
        var val_7 = (val_15 == 0) ? 1 : 0;
        var val_8 = (val_6 == 0) ? 1 : 0;
        if((val_6 == 0) || (val_15 == 0))
        {
            goto label_9;
        }
        
        val_15 = val_15 + val_6;
        val_18 = (float)val_15 / (float)val_15;
        goto label_13;
        label_5:
        val_15 = this._clubCrowns;
        val_17 = 1;
        label_9:
        if((val_17 != 0) && ((((val_15 == 0) ? 1 : 0) & 1) != 0))
        {
                val_18 = 0.5f;
        }
        
        label_13:
        float val_11 = UnityEngine.Mathf.Clamp(value:  (val_15 < 1) ? 0f : 1f, min:  0.1f, max:  0.9f);
        EventListItemContentCCCvC val_12 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentCCCvC>(allowMultiple:  false);
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public override void OnAppleAwarded(int appleAwarded)
    {
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        this.PutData(crownsCollected:  appleAwarded);
        int val_2 = this.crownsCollectedThisLevel;
        val_2.crownsCollectedThisLevel = val_2 + appleAwarded;
    }
    public override string GetHackPanelEventData()
    {
        return PrettyPrint.printJSON(obj:  147633, types:  false, singleLineOutput:  false);
    }
    public override void OnProfileUpdated()
    {
        MonoSingleton<GameEventsManager>.Instance.CheckAndRequestServerEvents();
    }
    private bool CanEngageWithEvent()
    {
        if(App.Player < this.unlockLevel)
        {
                return false;
        }
        
        Player val_2 = App.Player;
        if((val_2.isHacker != true) && ((val_2.isHacker + 82) == 0))
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40})) == false)
        {
                return false;
        }
        
        }
        
        return false;
    }
    private void ResetData()
    {
        if((CPlayerPrefs.HasKey(key:  "lastCrownClashPrompt")) != false)
        {
                CPlayerPrefs.DeleteKey(key:  "lastCrownClashPrompt");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "ccRewardData")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "ccRewardData");
        }
        
        if((CPlayerPrefs.HasKey(key:  "ccCrownsCollectedThisLevel")) != false)
        {
                CPlayerPrefs.DeleteKey(key:  "ccCrownsCollectedThisLevel");
        }
        
        this.rewardEarnings = 0;
        this.hasInit = false;
        CPlayerPrefs.Save();
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void CheckData(GameEventV2 gameEvent)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_10;
        var val_11;
        val_9 = 1152921504874684416;
        if((CPlayerPrefs.HasKey(key:  "ccRewardData")) == false)
        {
                return;
        }
        
        val_9 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "ccRewardData"));
        if((val_9.ContainsKey(key:  "id")) == false)
        {
            goto label_9;
        }
        
        object val_5 = val_9.Item["id"];
        if(gameEvent != null)
        {
            goto label_12;
        }
        
        label_9:
        val_11 = 0;
        label_12:
        if(gameEvent.id == val_11)
        {
                this.rewardData = val_9;
            if((val_9.ContainsKey(key:  "reward")) == false)
        {
                return;
        }
        
            val_10 = this.rewardData.Item["reward"];
            this.ParseRewardEarnings(rewardEarningsDict:  val_10);
            return;
        }
        
        this.ResetData();
        bool val_8 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private System.Collections.Generic.Dictionary<string, object> ParseEconomyCurrencyRewardData(System.Collections.Generic.Dictionary<string, object> currencyEconData)
    {
        var val_13;
        var val_14;
        string val_15;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((currencyEconData.ContainsKey(key:  "base_reward")) != false)
        {
                bool val_5 = System.Int32.TryParse(s:  currencyEconData.Item["base_reward"], result: out  0);
            val_1.Add(key:  "0", value:  0);
        }
        
        val_13 = "crown_threshold_rewards";
        if((currencyEconData.ContainsKey(key:  "crown_threshold_rewards")) == false)
        {
                return val_1;
        }
        
        val_15 = null;
        Dictionary.Enumerator<TKey, TValue> val_8 = currencyEconData.Item["crown_threshold_rewards"].GetEnumerator();
        val_13 = 1152921510193071136;
        label_14:
        val_15 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_9;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = val_1;
        val_15 = 0;
        if((val_1.ContainsKey(key:  val_15)) == true)
        {
            goto label_14;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  0, result: out  0)) == false)
        {
            goto label_14;
        }
        
        val_1.Add(key:  0, value:  0);
        goto label_14;
        label_9:
        0.Dispose();
        return val_1;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_19;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.Log(message:  PrettyPrint.printJSON(obj:  eventData, types:  false, singleLineOutput:  false));
        }
        
        this.hasParsedEventData = true;
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
            goto label_10;
        }
        
        object val_5 = eventData.Item["economy"];
        if((val_5.ContainsKey(key:  "coins")) != false)
        {
                object val_7 = val_5.Item["coins"];
            this.eventRewards = val_7.ParseEconomyCurrencyRewardData(currencyEconData:  val_7);
        }
        
        if((val_5.ContainsKey(key:  "golden")) == false)
        {
            goto label_22;
        }
        
        object val_10 = val_5.Item["golden"];
        this.eventRewardsGoldenCurrency = val_10.ParseEconomyCurrencyRewardData(currencyEconData:  val_10);
        goto label_22;
        label_10:
        UnityEngine.Debug.LogError(message:  "no Crown Clash econ values found");
        label_22:
        if((eventData.ContainsKey(key:  "membership_crowns")) != false)
        {
                if((System.Int32.TryParse(s:  eventData.Item["membership_crowns"], result: out  this._membershipCrowns)) == true)
        {
            goto label_27;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "unable to parse Crown Clash Member Crowns");
        label_27:
        if((eventData.ContainsKey(key:  "match")) == false)
        {
            goto label_30;
        }
        
        object val_17 = eventData.Item["match"];
        val_19 = 0;
        goto label_33;
        label_30:
        this._clubCapacity = 0;
        this._clubCrowns = 0;
        this.<opponentData>k__BackingField = 0;
        this.<curStatus>k__BackingField = "created";
        goto label_34;
        label_33:
        this.ParseMatchData(matchData:  null);
        label_34:
        if((eventData.ContainsKey(key:  "reward")) == false)
        {
                return;
        }
        
        this.ParseRewards(data:  eventData);
    }
    private void ParseMatchData(System.Collections.Generic.Dictionary<string, object> matchData)
    {
        var val_14;
        if((matchData.ContainsKey(key:  "status")) != false)
        {
                this.<curStatus>k__BackingField = matchData.Item["status"];
        }
        
        if((matchData.ContainsKey(key:  "capacity")) != false)
        {
                if((System.Int32.TryParse(s:  matchData.Item["capacity"], result: out  this._clubCapacity)) == true)
        {
            goto label_6;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "unable to parse Crown Clash Club Capacity");
        label_6:
        if((matchData.ContainsKey(key:  "crowns")) != false)
        {
                if((System.Int32.TryParse(s:  matchData.Item["crowns"], result: out  this._clubCrowns)) == true)
        {
            goto label_11;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "unable to parse Crown Clash Club Crowns");
        label_11:
        if((matchData.ContainsKey(key:  "opponent")) != false)
        {
                object val_12 = matchData.Item["opponent"];
            val_14 = 0;
        }
        else
        {
                UnityEngine.Debug.LogError(message:  "no Opponent Data found in Crown Clash Club Match Data");
            return;
        }
        
        this.<opponentData>k__BackingField = ;
    }
    private void LevelInit()
    {
        if(this.hasInit == false)
        {
                return;
        }
        
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
        {
                return;
        }
        
        if((this.<opponentData>k__BackingField) == null)
        {
                return;
        }
        
        if((this.<opponentData>k__BackingField.ContainsKey(key:  "crowns")) == false)
        {
                return;
        }
        
        int val_5 = System.Int32.Parse(s:  this.<opponentData>k__BackingField.Item["crowns"]);
    }
    public void PutData(int crownsCollected = 1)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "crowns", value:  crownsCollected);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
        int val_3 = this._clubCrowns;
        val_3 = V1.2S + val_3;
        this._clubCrowns = val_3;
    }
    private void ParseRewards(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_7;
        if(data.Item["reward"] != null)
        {
                val_7 = 0;
        }
        
        this.rewardData = ;
        UnityEngine.PlayerPrefs.SetString(key:  "ccRewardData", value:  MiniJSON.Json.Serialize(obj:  null));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        if(this.rewardData == null)
        {
                return;
        }
        
        if((this.rewardData.ContainsKey(key:  "reward")) == false)
        {
                return;
        }
        
        this.ParseRewardEarnings(rewardEarningsDict:  this.rewardData.Item["reward"]);
        this.CheckRewardedPopup();
    }
    private void ParseRewardEarnings(System.Collections.Generic.Dictionary<string, object> rewardEarningsDict)
    {
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Object> val_12;
        var val_13;
        var val_14;
        val_12 = this;
        this.rewardEarnings = new System.Collections.Generic.Dictionary<GameEventRewardType, System.Object>();
        if((rewardEarningsDict.ContainsKey(key:  "coins")) != false)
        {
                int val_4 = 0;
            if((System.Int32.TryParse(s:  rewardEarningsDict.Item["coins"], result: out  val_4)) != false)
        {
                val_13 = val_4;
        }
        else
        {
                val_13 = val_12;
        }
        
            this.rewardEarnings.Add(key:  1, value:  this.baseRewardCoins);
        }
        
        if((rewardEarningsDict.ContainsKey(key:  "golden")) == false)
        {
                return;
        }
        
        int val_9 = 0;
        if((System.Int32.TryParse(s:  rewardEarningsDict.Item["golden"], result: out  val_9)) != false)
        {
                val_14 = val_9;
        }
        else
        {
                val_14 = val_12;
        }
        
        val_12 = this.rewardEarnings;
        val_12.Add(key:  2, value:  this.baseRewardGoldenCurrency);
    }
    public System.Collections.Generic.Dictionary<GameEventRewardType, object> CollectReward()
    {
        var val_12;
        if(this.rewardEarnings != null)
        {
                val_12 = 1152921516160795552;
            int val_3 = 0;
            if((this.rewardEarnings.ContainsKey(key:  1)) != false)
        {
                bool val_4 = System.Int32.TryParse(s:  this.rewardEarnings.Item[1], result: out  val_3);
        }
        
            int val_7 = 0;
            if((this.rewardEarnings.ContainsKey(key:  2)) != false)
        {
                bool val_8 = System.Int32.TryParse(s:  this.rewardEarnings.Item[2], result: out  val_7);
        }
        
            if(val_3 >= 1)
        {
                val_12 = App.Player;
            decimal val_10 = System.Decimal.op_Implicit(value:  0);
            val_12.AddCredits(amount:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, source:  "Club Clash Event", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
            if(val_7 >= 1)
        {
                GoldenApplesManager val_11 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        }
        
        this.rewardData = 0;
        this.rewardEarnings = 0;
        this.ResetData();
        return (System.Collections.Generic.Dictionary<GameEventRewardType, System.Object>)this.rewardEarnings;
    }
    public void AddHackedCrowns(int crowns)
    {
        this.PutData(crownsCollected:  crowns);
    }
    public ClubClashEvent()
    {
        this.unlockLevel = 100;
        this.fallbackMyClubImageIndex = -1;
        this.fallbackOtherClub = -1;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "0", value:  10);
        val_1.Add(key:  "100", value:  25);
        val_1.Add(key:  "200", value:  50);
        val_1.Add(key:  "300", value:  100);
        val_1.Add(key:  "400", value:  250);
        val_1.Add(key:  "500", value:  500);
        this.eventRewards = val_1;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "0", value:  3);
        val_2.Add(key:  "100", value:  5);
        val_2.Add(key:  "200", value:  10);
        val_2.Add(key:  "300", value:  25);
        val_2.Add(key:  "400", value:  70);
        val_2.Add(key:  "500", value:  140);
        this.eventRewardsGoldenCurrency = val_2;
    }

}
