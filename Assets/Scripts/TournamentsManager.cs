using UnityEngine;
public class TournamentsManager : MonoSingleton<TournamentsManager>
{
    // Fields
    public const string tracked_reward_source = "Tournament Reward";
    private TournamentInfo currentTournamentInfo;
    private static bool _IsEnabled;
    private const string pp_last_tournament = "lst_tnmt";
    private TournamentInfo lastTournamentInfo;
    public System.Action OnTournamentUpdate;
    
    // Properties
    public TournamentInfo CurrentTournamentInfo { get; }
    public static bool IsEnabled { get; }
    private TournamentInfo LastTournamentInfo { get; }
    
    // Methods
    public TournamentInfo get_CurrentTournamentInfo()
    {
        return (TournamentInfo)this.currentTournamentInfo;
    }
    public static bool get_IsEnabled()
    {
        null = null;
        return (bool)TournamentsManager.pp_last_tournament;
    }
    private TournamentInfo get_LastTournamentInfo()
    {
        TournamentInfo val_4 = this.lastTournamentInfo;
        if(val_4 != null)
        {
                return val_4;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lst_tnmt")) != false)
        {
                this.lastTournamentInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<TournamentInfo>(value:  UnityEngine.PlayerPrefs.GetString(key:  "lst_tnmt", defaultValue:  "{}"));
            return val_4;
        }
        
        val_4 = this.lastTournamentInfo;
        return val_4;
    }
    private void OnApplicationPause(bool pause)
    {
        var val_9;
        var val_10;
        TournamentInfo val_11;
        var val_12;
        val_9 = 1152921504900882432;
        val_10 = null;
        val_10 = null;
        if(TournamentsManager.pp_last_tournament == null)
        {
                return;
        }
        
        val_11 = this.currentTournamentInfo;
        if(val_11 == null)
        {
                return;
        }
        
        if(pause == false)
        {
                return;
        }
        
        val_12 = null;
        val_11 = this.currentTournamentInfo;
        val_12 = null;
        System.Int32[] val_9 = TournamentsEconomy.rewardIndexByRank;
        System.Int32[][] val_1 = TournamentsEconomy.coinRewardsByTier + ((this.currentTournamentInfo.tierIndex) << 3);
        var val_10 = (TournamentsEconomy.coinRewardsByTier + (this.currentTournamentInfo.tierIndex) << 3) + 32;
        val_9 = val_9 + ((this.currentTournamentInfo.myRank) << 2);
        val_10 = val_10 + (((TournamentsEconomy.rewardIndexByRank + (this.currentTournamentInfo.myRank) << 2) + 32) << 2);
        System.Int32[][] val_3 = TournamentsEconomy.giftRewardsByTier + ((this.currentTournamentInfo.tierIndex) << 3);
        var val_12 = (TournamentsEconomy.giftRewardsByTier + (this.currentTournamentInfo.tierIndex) << 3) + 32;
        val_12 = val_12 + (((TournamentsEconomy.rewardIndexByRank + (this.currentTournamentInfo.myRank) << 2) + 32) << 2);
        val_9 = 1152921505040338944;
        var val_4 = ((((TournamentsEconomy.coinRewardsByTier + (this.currentTournamentInfo.tierIndex) << 3) + 32 + ((TournamentsEconomy.rewardIndexByRank + (this.currentTournamentInfo.myRank) << 2) + 32) << 2) + 32) > 0) ? 1 : 0;
        val_4 = val_4 | (((TournamentsEconomy.gemOrPetFoodRewardsByTier[this.currentTournamentInfo.tierIndex][((TournamentsEconomy.rewardIndexByRank + (this.currentTournamentInfo.myRank) << 2) + 32) << 2]) > 0) ? 1 : 0);
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  28);
        if((val_4 | (((((TournamentsEconomy.giftRewardsByTier + (this.currentTournamentInfo.tierIndex) << 3) + 32 + ((TournamentsEconomy.rewardIndexByRank + (this.currentTournamentInfo.myRank) << 2) + 32) << 2) + 32) > 0) ? 1 : 0)) == 0)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_8.Add(key:  "notification_type", value:  "tournament_end");
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  28, when:  new System.DateTime() {dateData = this.currentTournamentInfo.endTime}, optMessage:  "Tournament Over! Collect your reward now!", extraData:  val_8);
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public void OnTournamentDataResponse(System.Collections.Generic.Dictionary<string, object> responseData)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_46;
        var val_47;
        TournamentInfo val_48;
        bool val_49;
        var val_50;
        var val_51;
        var val_52;
        string val_53;
        val_46 = responseData;
        val_47 = this;
        if((val_46.ContainsKey(key:  "enabled")) == false)
        {
            goto label_2;
        }
        
        val_48 = 1152921504900882432;
        val_49 = System.Boolean.Parse(value:  val_46.Item["enabled"]);
        val_50 = null;
        val_50 = null;
        TournamentsManager.pp_last_tournament = val_49;
        if(TournamentsManager.pp_last_tournament == false)
        {
            goto label_52;
        }
        
        label_2:
        val_48 = "tier_priority";
        if((val_46.ContainsKey(key:  "tier_priority")) != false)
        {
                this.currentTournamentInfo = new TournamentInfo();
            val_51 = 1152921510214912464;
            .tierIndex = (System.Int32.Parse(s:  val_46.Item["tier_priority"])) - 1;
            val_48 = this.currentTournamentInfo;
            System.DateTime val_11 = SLCDateTime.Parse(dateTime:  val_46.Item["ends_at"]);
            this.currentTournamentInfo.endTime = val_11;
            val_49 = val_46.Item["rankings"];
            if(null >= 1)
        {
                val_52 = 1152921504900722688;
            val_48 = 1152921504685600768;
            int val_45 = 0;
            do
        {
            TournamentPlayer val_28 = new TournamentPlayer();
            if(val_45 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Debug.LogError(message:  "Error parsing Tournaments members:\n"("Error parsing Tournaments members:\n") + PrettyPrint.printJSON(obj:  val_46, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_46, types:  false, singleLineOutput:  false)));
            val_45 = val_45 + 1;
        }
        while(val_45 < null);
        
        }
        
            if(this.currentTournamentInfo.me != null)
        {
                val_53 = "last_tier_priority";
            if(((val_46.ContainsKey(key:  "last_tier_priority")) != false) && ((val_46.ContainsKey(key:  "last_rank")) != false))
        {
                val_48 = "last_score";
            if((val_46.ContainsKey(key:  "last_score")) != false)
        {
                TournamentInfo val_34 = null;
            val_49 = val_34;
            val_34 = new TournamentInfo();
            .tierIndex = (System.Int32.Parse(s:  val_46.Item["last_tier_priority"])) - 1;
            .myRank = (System.Int32.Parse(s:  val_46.Item["last_rank"])) - 1;
            .myScore = System.Int32.Parse(s:  val_46.Item["last_score"]);
            this.lastTournamentInfo = val_49;
            UnityEngine.PlayerPrefs.SetString(key:  "lst_tnmt", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_34));
            bool val_44 = PrefsSerializationManager.SavePlayerPrefs();
            this.TrackTournamentRollover();
        }
        
        }
        
            if(this.OnTournamentUpdate == null)
        {
                return;
        }
        
            this.OnTournamentUpdate.Invoke();
            return;
        }
        
        }
        
        label_52:
        this.currentTournamentInfo = 0;
    }
    public bool ShowTournamentResults()
    {
        TournamentInfo val_34;
        var val_35;
        System.Int32[] val_37;
        string val_39;
        TournamentInfo val_40;
        System.Int32[][] val_41;
        var val_42;
        var val_44;
        System.Collections.Generic.List<GiftReward> val_45;
        var val_46;
        var val_47;
        val_34 = this;
        if(this.LastTournamentInfo == null)
        {
                return false;
        }
        
        val_35 = null;
        val_35 = null;
        val_37 = TournamentsEconomy.rewardIndexByRank;
        if(this.lastTournamentInfo.myRank <= TournamentsEconomy.rewardIndexByRank.Length)
        {
            goto label_6;
        }
        
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "TournamentsManager.ShowTournamentResults() - bad rank! {0} is not in range.", arg0:  this.lastTournamentInfo.myRank));
        val_34 = this.lastTournamentInfo;
        string val_3 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_34, formatting:  1);
        val_39 = "TournamentsManager.ShowTournamentresults() bad rank:\n{0}";
        goto label_24;
        label_6:
        val_35 = null;
        val_37 = TournamentsEconomy.rewardIndexByRank;
        val_40 = this.lastTournamentInfo;
        val_41 = TournamentsEconomy.coinRewardsByTier;
        if(this.lastTournamentInfo.tierIndex <= TournamentsEconomy.coinRewardsByTier.Length)
        {
            goto label_19;
        }
        
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "TournamentsManager.ShowTournamentResults() - bad tier index! {0} is not in range.", arg0:  this.lastTournamentInfo.tierIndex));
        val_34 = this.lastTournamentInfo;
        string val_5 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_34, formatting:  1);
        val_39 = "TournamentsManager.ShowTournamentresults() bad tier index:\n{0}";
        goto label_24;
        label_19:
        val_37 = val_37 + ((this.lastTournamentInfo.myRank) << 2);
        val_40 = this.lastTournamentInfo;
        val_35 = null;
        val_41 = TournamentsEconomy.coinRewardsByTier;
        System.Int32[][] val_6 = val_41 + ((this.lastTournamentInfo.tierIndex) << 3);
        if(((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32) <= ((TournamentsEconomy.coinRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + 24))
        {
            goto label_31;
        }
        
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "TournamentsManager.ShowTournamentResults() - bad reward index! {0} is not in range.", arg0:  (TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32));
        val_34 = this.lastTournamentInfo;
        val_39 = "TournamentsManager.ShowTournamentresults() bad reward index:\n{0}";
        label_24:
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  val_39, arg0:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_34, formatting:  1)));
        return false;
        label_31:
        val_40 = this.lastTournamentInfo;
        val_41 = TournamentsEconomy.coinRewardsByTier;
        System.Int32[][] val_10 = val_41 + ((this.lastTournamentInfo.tierIndex) << 3);
        var val_33 = (TournamentsEconomy.coinRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32;
        val_33 = val_33 + (((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2);
        int val_35 = TournamentsEconomy.gemOrPetFoodRewardsByTier[this.lastTournamentInfo.tierIndex][((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2];
        System.Int32[][] val_12 = TournamentsEconomy.giftRewardsByTier + ((this.lastTournamentInfo.tierIndex) << 3);
        var val_36 = (TournamentsEconomy.giftRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32;
        val_36 = val_36 + (((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2);
        if((((TournamentsEconomy.coinRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + ((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2) + 32) >= 1)
        {
                decimal val_14 = System.Decimal.op_Implicit(value:  ((TournamentsEconomy.coinRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + ((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2) + 32);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid}, source:  "Tournament Reward", subSource:  "Tournament Reward", externalParams:  0, doTrack:  true);
        }
        
        if(val_35 >= 1)
        {
                val_42 = null;
            val_44 = 0;
            if(App.game == 17)
        {
                App.Player.AddGems(amount:  val_35, source:  "Tournament Reward", subsource:  "Tournament Reward");
            App.Player.TrackNonCoinReward(source:  "Tournament Reward", subSource:  0, rewardType:  "Gems", rewardAmount:  val_35.ToString(), additionalParams:  0);
        }
        else
        {
                App.Player.AddPetsFood(amount:  val_35, source:  "Tournament Reward", subSource:  "Tournament Reward", FoodSpentParams:  0, additionalParam:  0);
        }
        
        }
        
        System.Collections.Generic.List<GiftReward> val_19 = null;
        val_45 = val_19;
        val_19 = new System.Collections.Generic.List<GiftReward>();
        bool val_21 = false;
        if((((TournamentsEconomy.giftRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + ((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2) + 32) >= 1)
        {
                val_46 = null;
            val_46 = null;
            if(App.game == 17)
        {
                val_45 = System.Linq.Enumerable.ToList<GiftReward>(source:  System.Linq.Enumerable.Cast<GiftReward>(source:  WGGiftRewardManager<TRVGiftRewardManager>.Instance.GetRewards(rewardsSource:  12, expertLeveledUp: out  val_21, cardsGranted:  ((TournamentsEconomy.giftRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + ((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2) + 32)));
        }
        else
        {
                val_45 = WGGiftRewardManager<WADGiftRewardManager>.Instance.MakeRewards(rewardType:  3, rewardAmount:  ((TournamentsEconomy.giftRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + ((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2) + 32);
            WGGiftRewardManager<WADGiftRewardManager>.Instance.CollectRewards(rewards:  val_45, rewardSource:  12);
        }
        
        }
        
        GameBehavior val_28 = App.getBehavior;
        val_28.<metaGameBehavior>k__BackingField.ShowResults(coinReward:  ((TournamentsEconomy.coinRewardsByTier + (this.lastTournamentInfo.tierIndex) << 3) + 32 + ((long)(int)((TournamentsEconomy.rewardIndexByRank + (this.lastTournamentInfo.myRank) << 2) + 32)) << 2) + 32, gemsOrPetFoodReward:  val_35, giftRewards:  val_45, rankIndex:  this.lastTournamentInfo.myRank, lastTournamentTier:  this.lastTournamentInfo.tierIndex);
        val_47 = null;
        val_47 = null;
        if((((App.game == 17) ? 1 : 0) & val_21) != 0)
        {
                return false;
        }
        
        GameBehavior val_31 = App.getBehavior;
        return false;
    }
    public void HandleTournamentResultsCollected()
    {
        this.lastTournamentInfo = 0;
        UnityEngine.PlayerPrefs.DeleteKey(key:  "lst_tnmt");
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void Hack_1_thru_3()
    {
        .myRank = UnityEngine.Random.Range(min:  0, max:  3);
        .tierIndex = UnityEngine.Random.Range(min:  0, max:  20);
        .myScore = UnityEngine.Random.Range(min:  1, max:  232);
        this.lastTournamentInfo = new TournamentInfo();
        bool val_5 = this.ShowTournamentResults();
    }
    public void Hack_4_thru_10()
    {
        .myRank = UnityEngine.Random.Range(min:  3, max:  10);
        .tierIndex = UnityEngine.Random.Range(min:  0, max:  20);
        .myScore = UnityEngine.Random.Range(min:  1, max:  232);
        this.lastTournamentInfo = new TournamentInfo();
        bool val_5 = this.ShowTournamentResults();
    }
    public void Hack_11_thru_30()
    {
        .myRank = UnityEngine.Random.Range(min:  10, max:  30);
        .tierIndex = UnityEngine.Random.Range(min:  0, max:  20);
        .myScore = UnityEngine.Random.Range(min:  1, max:  232);
        this.lastTournamentInfo = new TournamentInfo();
        bool val_5 = this.ShowTournamentResults();
    }
    public void Hack_31_thru_50()
    {
        .myRank = UnityEngine.Random.Range(min:  30, max:  49);
        .tierIndex = UnityEngine.Random.Range(min:  0, max:  20);
        .myScore = UnityEngine.Random.Range(min:  1, max:  232);
        this.lastTournamentInfo = new TournamentInfo();
        bool val_5 = this.ShowTournamentResults();
    }
    public void Hack_Master_Promoted()
    {
        .myRank = UnityEngine.Random.Range(min:  0, max:  10);
        .tierIndex = 0;
        .myScore = UnityEngine.Random.Range(min:  1, max:  232);
        this.lastTournamentInfo = new TournamentInfo();
        bool val_4 = this.ShowTournamentResults();
    }
    public void Hack_BronzeVII_Demoted()
    {
        .myRank = UnityEngine.Random.Range(min:  30, max:  49);
        .tierIndex = 19;
        .myScore = UnityEngine.Random.Range(min:  1, max:  232);
        this.lastTournamentInfo = new TournamentInfo();
        bool val_4 = this.ShowTournamentResults();
    }
    private void TrackTournamentRollover()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8;
        var val_9;
        if(this.lastTournamentInfo == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_8 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Player Demoted", value:  TournamentsEconomy.RankIndexIsDemotion(rankIndex:  this.lastTournamentInfo.myRank - 1));
        val_1.Add(key:  "Player League Points", value:  this.lastTournamentInfo.myScore);
        val_1.Add(key:  "Player Promoted", value:  TournamentsEconomy.RankIndexIsPromotion(rankIndex:  this.lastTournamentInfo.myRank - 1));
        val_1.Add(key:  "Tournament Rank", value:  this.lastTournamentInfo.myRank);
        System.String[] val_8 = TournamentsEconomy.TierNames;
        val_8 = val_8 + ((this.lastTournamentInfo.tierIndex) << 3);
        val_1.Add(key:  "Tournament Tier", value:  (TournamentsEconomy.TierNames + (this.lastTournamentInfo.tierIndex) << 3) + 32);
        val_9 = null;
        val_9 = null;
        App.trackerManager.track(eventName:  "Tournament Rollover", data:  val_1);
    }
    public TournamentsManager()
    {
    
    }
    private static TournamentsManager()
    {
    
    }

}
