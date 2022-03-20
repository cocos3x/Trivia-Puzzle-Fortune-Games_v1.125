using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesDataController : MonoBehaviour
    {
        // Fields
        public bool FirstGuild;
        public bool HasCollectedFirstGuildReward;
        public SLC.Social.Leagues.LeaguesManager.GuildStateChange statusChangeToShowThisSession;
        public bool needToShowSeasonResultsThisSession;
        public decimal DailyRewardAmount;
        public decimal SeasonRewardAmount;
        public bool SeasonPromotion;
        public bool SeasonDemotion;
        public int LastSeasonRank;
        public int LastSeasonTier;
        public decimal LastSeasonMultiplier;
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> LastSeasonGuildRanking;
        public SLC.Social.Leagues.GuildMembers SeasonMvpMembers;
        public int MyId;
        private SLC.Social.Profile dummyProfile;
        private SLC.Social.Leagues.Guilds rankedGuilds;
        private SLC.Social.Leagues.Guilds rankedGuildsInTier;
        private SLC.Social.Leagues.Guilds knownGuilds;
        private SLC.Social.Leagues.Guilds eligibleGuilds;
        private SLC.Social.Leagues.Guilds myGuildInvites;
        private SLC.Social.Leagues.GuildMembers knownMembers;
        public static System.Collections.Generic.Dictionary<int, System.Collections.Generic.Dictionary<string, string>> LeaguesProMembershipPackages;
        
        // Properties
        public int MyGuildServerId { get; }
        public int Pref_GuildId { get; set; }
        public bool IsMaster { get; set; }
        public bool IsOfficer { get; set; }
        public bool Pref_CreatedGuild { get; set; }
        public int Pref_PendingInviteId { get; set; }
        public SLC.Social.Profile MyProfile { get; }
        public SLC.Social.Leagues.Guild MyGuild { get; }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> GuildsToJoin { get; }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> GuildsInvited { get; }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> GuildsInMyTier { get; }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> GuildsInSearchedTier { get; }
        
        // Methods
        private void Start()
        {
            SLC.Social.Leagues.LeaguesServerController val_1 = SLC.Social.Leagues.LeaguesManager.API;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_2 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::DataFilter(System.Collections.Generic.Dictionary<string, object> responseObject));
            SLC.Social.Leagues.LeaguesChatController val_3 = SLC.Social.Leagues.LeaguesManager.CHAT_API;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_4 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::DataFilter(System.Collections.Generic.Dictionary<string, object> responseObject));
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        }
        private void DataFilter(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_46;
            var val_47;
            string val_106;
            string val_107;
            var val_108;
            var val_109;
            var val_110;
            var val_111;
            var val_112;
            var val_113;
            object val_114;
            var val_115;
            var val_116;
            var val_117;
            string val_119;
            GuildStateChange val_120;
            var val_121;
            var val_122;
            if(responseObject == null)
            {
                    throw new NullReferenceException();
            }
            
            if((responseObject.ContainsKey(key:  "first_guild")) != false)
            {
                    val_107 = "first_guild";
                object val_2 = responseObject.Item[val_107];
                if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.FirstGuild = System.Boolean.Parse(value:  val_2.ToLower());
            }
            
            if((responseObject.ContainsKey(key:  "first_rew")) != false)
            {
                    val_107 = "first_rew";
                object val_7 = responseObject.Item[val_107];
                if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.HasCollectedFirstGuildReward = System.Boolean.Parse(value:  val_7.ToLower());
            }
            
            if((responseObject.ContainsKey(key:  "rolling")) != false)
            {
                    val_107 = "rolling";
                object val_13 = responseObject.Item[val_107];
                if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_106 = val_13.ToLower();
                val_107 = 0;
                if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_12._IsInSeasonRollover = System.Boolean.Parse(value:  val_106);
            }
            
            if((responseObject.ContainsKey(key:  "season_rewards")) != false)
            {
                    val_107 = "season_rewards";
                val_108 = 1152921510214912464;
                object val_18 = responseObject.Item[val_107];
                if(val_18 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((val_18.ContainsKey(key:  "reward")) != false)
            {
                    val_107 = "reward";
                object val_20 = val_18.Item[val_107];
                if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
                decimal val_22 = System.Decimal.Parse(s:  val_20, provider:  System.Globalization.CultureInfo.InvariantCulture);
                this.SeasonRewardAmount = val_22;
                mem[1152921519635863084] = val_22.lo;
                mem[1152921519635863088] = val_22.mid;
            }
            
                if((val_18.ContainsKey(key:  "promoted")) != false)
            {
                    val_107 = "promoted";
                object val_24 = val_18.Item[val_107];
                if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.SeasonPromotion = System.Boolean.Parse(value:  val_24);
            }
            
                if((val_18.ContainsKey(key:  "demoted")) != false)
            {
                    val_107 = "demoted";
                object val_28 = val_18.Item[val_107];
                if(val_28 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.SeasonDemotion = System.Boolean.Parse(value:  val_28);
            }
            
                if((val_18.ContainsKey(key:  "last_rank")) != false)
            {
                    val_107 = "last_rank";
                object val_32 = val_18.Item[val_107];
                if(val_32 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.LastSeasonRank = System.Int32.Parse(s:  val_32);
            }
            
                if((val_18.ContainsKey(key:  "last_tier")) != false)
            {
                    val_107 = "last_tier";
                object val_35 = val_18.Item[val_107];
                if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.LastSeasonTier = System.Int32.Parse(s:  val_35);
            }
            
                if((val_18.ContainsKey(key:  "last_points_multiplier")) != false)
            {
                    val_107 = "last_points_multiplier";
                object val_38 = val_18.Item[val_107];
                if(val_38 == null)
            {
                    throw new NullReferenceException();
            }
            
                decimal val_40 = System.Decimal.Parse(s:  val_38, provider:  System.Globalization.CultureInfo.InvariantCulture);
                this.LastSeasonMultiplier = val_40;
                mem[1152921519635863112] = val_40.lo;
                mem[1152921519635863116] = val_40.mid;
            }
            
                val_109 = 1;
            }
            else
            {
                    val_109 = 0;
            }
            
            if((responseObject.ContainsKey(key:  "season_ranks")) == false)
            {
                goto label_49;
            }
            
            this.LastSeasonGuildRanking = new System.Collections.Generic.List<SLC.Social.Leagues.Guild>();
            val_107 = "season_ranks";
            if(responseObject.Item[val_107] == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_54;
            label_49:
            val_110 = 0;
            goto label_55;
            label_54:
            List.Enumerator<T> val_45 = GetEnumerator();
            val_108 = 1152921510211410768;
            label_62:
            val_107 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_47.MoveNext() == false)
            {
                goto label_56;
            }
            
            if(val_46 != 0)
            {
                    val_107 = null;
            }
            
            SLC.Social.Leagues.Guild val_49 = new SLC.Social.Leagues.Guild();
            if(val_49 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49.Decode(jasonObject:  val_46, sourceModel:  0);
            this.LastSeasonGuildRanking.Add(item:  val_49);
            goto label_62;
            label_56:
            val_47.Dispose();
            val_110 = 1;
            label_55:
            if((val_110 & val_109) == 0)
            {
                    this.needToShowSeasonResultsThisSession = true;
            }
            
            val_111 = 1152921504617017344;
            val_112 = null;
            val_112 = null;
            val_107 = "season_ranks";
            if(((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = this.SeasonRewardAmount, hi = this.SeasonRewardAmount, lo = "season_ranks"}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false) && (this.needToShowSeasonResultsThisSession != false))
            {
                    this.statusChangeToShowThisSession = 3;
                SLC.Social.Leagues.LeaguesManager val_51 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_51 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_113 = 0;
                val_51.OnGuildStatusChanged(state:  3, source:  "", leftGuildId:  0, forDisplayOnly:  true);
            }
            
            val_114 = "mvp_ranks";
            if((responseObject.ContainsKey(key:  "mvp_ranks")) != false)
            {
                    val_107 = "mvp_ranks";
                object val_53 = responseObject.Item[val_107];
                val_114 = 0;
                SLC.Social.Leagues.GuildMembers val_55 = new SLC.Social.Leagues.GuildMembers();
                this.SeasonMvpMembers = val_55;
                if(val_55 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_113 = 0;
                val_55.UpdateMembers(guildMembers:  null, fromModel:  0, excludeId:  0);
            }
            
            if((responseObject.ContainsKey(key:  "tournament_info")) != false)
            {
                    val_111 = 1152921510214912464;
                val_113 = 0;
                val_114 = "Tournament Info from Leagues:\n"("Tournament Info from Leagues:\n") + PrettyPrint.printJSON(obj:  responseObject.Item["tournament_info"], types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  responseObject.Item["tournament_info"], types:  false, singleLineOutput:  false));
                UnityEngine.Debug.Log(message:  val_114);
                object val_60 = responseObject.Item["tournament_info"];
                if(val_60 != null)
            {
                    val_114 = val_60;
                val_111 = 1152921504893161472;
                val_108 = 1152921515677572976;
                val_107 = 0;
                if((MonoSingleton<TournamentsManager>.Instance) != val_107)
            {
                    if(App.getBehavior == null)
            {
                    throw new NullReferenceException();
            }
            
                val_106 = val_63.<metaGameBehavior>k__BackingField;
                if(val_106 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((val_106 & 1) != 0)
            {
                    TournamentsManager val_64 = MonoSingleton<TournamentsManager>.Instance;
                if(val_64 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_64.OnTournamentDataResponse(responseData:  val_114);
            }
            
            }
            
            }
            
            }
            
            if((responseObject.ContainsKey(key:  "myself")) == false)
            {
                    return;
            }
            
            if((responseObject.ContainsKey(key:  "data_flush")) != false)
            {
                    val_107 = "data_flush";
                if(responseObject.Item[val_107] == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = null;
                if(null != null)
            {
                    val_115 = null;
                val_115 = null;
                if(Logger.Leagues != false)
            {
                    val_113 = 0;
                val_107 = 0;
                UnityEngine.Debug.LogWarning(message:  "|Flush Leagues Data| "("|Flush Leagues Data| ") + PrettyPrint.printJSON(obj:  responseObject, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  responseObject, types:  false, singleLineOutput:  false)));
            }
            
                val_106 = this.knownMembers;
                if(val_106 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = public System.Void System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Profile>::Clear();
                val_106.Clear();
                val_106 = this.knownGuilds;
                if(val_106 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = public System.Void System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild>::Clear();
                val_106.Clear();
                val_106 = this.rankedGuilds;
                if(val_106 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = public System.Void System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild>::Clear();
                val_106.Clear();
                val_106 = this.rankedGuildsInTier;
                if(val_106 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = public System.Void System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild>::Clear();
                val_106.Clear();
                val_106 = this.eligibleGuilds;
                if(val_106 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_106.Clear();
            }
            
            }
            
            SLC.Social.Profile val_70 = null;
            val_114 = val_70;
            val_70 = new SLC.Social.Profile();
            val_107 = "myself";
            object val_71 = responseObject.Item[val_107];
            if(val_114 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_116 = 0;
            val_70.Decode(jasonObject:  null, sourceModel:  0);
            val_107 = val_114;
            this.MyId = (SLC.Social.Profile)[1152921519636058864].ServerId;
            this.AddOrMergeKnownMember(toKnow:  val_70);
            if(this.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_73 = this.MyGuild;
                if(val_73 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = this.MyProfile;
                val_73.AddMember(toAdd:  val_107);
                val_117 = 0;
                SLC.Social.Leagues.LeaguesTracker.CheckDailyRollover();
            }
            
            if(this.Pref_GuildId == 1)
            {
                    SLC.Social.Profile val_76 = this.MyProfile;
                if(val_76 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_76.GuildServerId != 1)
            {
                    if(val_76.Pref_CreatedGuild != false)
            {
                    if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_119 = "";
                val_120 = 2;
                val_121 = 0;
                val_122 = 1;
            }
            else
            {
                    SLC.Social.Leagues.LeaguesManager val_79 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_79 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_119 = "";
                val_121 = 0;
                val_120 = 0;
                val_122 = 0;
            }
            
                val_79.OnGuildStatusChanged(state:  val_120, source:  val_119, leftGuildId:  0, forDisplayOnly:  false);
                val_107 = 0;
                val_79.Pref_CreatedGuild = false;
            }
            
            }
            
            if((val_79.Pref_GuildId & 2147483648) == 0)
            {
                    if(this.MyProfile == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_81.GuildServerId == 1)
            {
                    this.statusChangeToShowThisSession = 1;
                SLC.Social.Leagues.LeaguesManager val_82 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_82 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = 1;
                val_117 = val_82;
                val_117.OnGuildStatusChanged(state:  val_107, source:  "", leftGuildId:  val_82.Pref_GuildId, forDisplayOnly:  false);
            }
            
            }
            
            if((val_117.Pref_GuildId & 2147483648) == 0)
            {
                    SLC.Social.Leagues.Guild val_85 = this.MyGuild;
                if(val_85 != null)
            {
                    SLC.Social.Leagues.Guild val_87 = this.MyGuild;
                if(val_87 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_85.Pref_GuildId != val_87.ServerId)
            {
                    if(val_87.Pref_CreatedGuild != true)
            {
                    SLC.Social.Leagues.LeaguesManager val_89 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_89 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = 0;
                val_89.OnGuildStatusChanged(state:  val_107, source:  "", leftGuildId:  0, forDisplayOnly:  false);
            }
            
            }
            
            }
            
            }
            
            if(val_89.IsMaster != true)
            {
                    if(this.MyProfile == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_91.GuildMaster != false)
            {
                    this.statusChangeToShowThisSession = 4;
                SLC.Social.Leagues.LeaguesManager val_92 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_92 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = 4;
                val_92.OnGuildStatusChanged(state:  val_107, source:  "", leftGuildId:  0, forDisplayOnly:  false);
            }
            
            }
            
            if(val_92.IsOfficer != true)
            {
                    if(this.MyProfile == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_94.Officer != false)
            {
                    this.statusChangeToShowThisSession = 5;
                SLC.Social.Leagues.LeaguesManager val_95 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_95 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = 5;
                val_95.OnGuildStatusChanged(state:  5, source:  "", leftGuildId:  0, forDisplayOnly:  false);
            }
            
            }
            
            if(this.statusChangeToShowThisSession != 7)
            {
                    SLC.Social.Leagues.LeaguesManager val_96 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_96 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = this.statusChangeToShowThisSession;
                val_96.OnGuildStatusChanged(state:  val_107, source:  "", leftGuildId:  0, forDisplayOnly:  true);
            }
            
            if(this.MyProfile == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_96.Pref_PendingInviteId != val_98.PendingGuildRequestId)
            {
                    if(this.MyProfile == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_99.PendingGuildRequestId != 0)
            {
                    SLC.Social.Leagues.LeaguesManager val_100 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
                if(val_100 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_107 = 6;
                val_100.OnGuildStatusChanged(state:  val_107, source:  "", leftGuildId:  0, forDisplayOnly:  false);
            }
            
            }
            
            SLC.Social.Profile val_101 = this.MyProfile;
            if(val_101 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_107 = val_101.GuildServerId;
            val_101.Pref_GuildId = val_107;
            SLC.Social.Profile val_102 = this.MyProfile;
            if(val_102 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_107 = val_102.GuildMaster;
            val_102.IsMaster = val_107;
            SLC.Social.Profile val_103 = this.MyProfile;
            if(val_103 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_107 = val_103.Officer;
            val_103.IsOfficer = val_107;
            SLC.Social.Profile val_104 = this.MyProfile;
            if(val_104 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_104.Pref_PendingInviteId = val_104.PendingGuildRequestId;
        }
        public int get_MyGuildServerId()
        {
            int val_5;
            if(this.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_2 = this.MyGuild;
                val_5 = val_2.ServerId;
                return val_5;
            }
            
            SLC.Social.Profile val_3 = this.MyProfile;
            if(val_3 == null)
            {
                    return val_3.Pref_GuildId;
            }
            
            SLC.Social.Profile val_4 = this.MyProfile;
            val_5 = val_4.GuildServerId;
            return val_5;
        }
        public int get_Pref_GuildId()
        {
            return UnityEngine.PlayerPrefs.GetInt(key:  "guild_id", defaultValue:  -2);
        }
        public void set_Pref_GuildId(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "guild_id", value:  value);
        }
        public bool get_IsMaster()
        {
            return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "is_master", defaultValue:  0)) == 1) ? 1 : 0;
        }
        public void set_IsMaster(bool value)
        {
            value = value;
            UnityEngine.PlayerPrefs.SetInt(key:  "is_master", value:  value);
        }
        public bool get_IsOfficer()
        {
            return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "is_officer", defaultValue:  0)) == 1) ? 1 : 0;
        }
        public void set_IsOfficer(bool value)
        {
            value = value;
            UnityEngine.PlayerPrefs.SetInt(key:  "is_officer", value:  value);
        }
        public bool get_Pref_CreatedGuild()
        {
            return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "is_creating", defaultValue:  0)) == 1) ? 1 : 0;
        }
        public void set_Pref_CreatedGuild(bool value)
        {
            value = value;
            UnityEngine.PlayerPrefs.SetInt(key:  "is_creating", value:  value);
        }
        public int get_Pref_PendingInviteId()
        {
            return UnityEngine.PlayerPrefs.GetInt(key:  "is_pending", defaultValue:  0);
        }
        public void set_Pref_PendingInviteId(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "is_pending", value:  value);
        }
        public SLC.Social.Profile get_MyProfile()
        {
            SLC.Social.Profile val_3;
            if(this.MyId != 1)
            {
                    if((this.GetGuildMember(memberId:  this.MyId)) != null)
            {
                    return this.GetGuildMember(memberId:  this.MyId);
            }
            
            }
            
            val_3 = this.dummyProfile;
            if(val_3 != null)
            {
                    return val_3;
            }
            
            this.dummyProfile = new SLC.Social.Profile();
            .ServerId = 0;
            this.dummyProfile.GuildServerId = 0;
            val_3 = this.dummyProfile;
            return val_3;
        }
        public SLC.Social.Leagues.Guild get_MyGuild()
        {
            SLC.Social.Profile val_1 = this.MyProfile;
            return this.GetGuild(guildId:  val_1.GuildServerId);
        }
        public SLC.Social.Leagues.Guild GetGuild(int guildId)
        {
            if((this.knownGuilds.ContainsKey(key:  guildId)) != false)
            {
                    if(this.knownGuilds != null)
            {
                    return (SLC.Social.Leagues.Guild)this.myGuildInvites.Item[guildId];
            }
            
            }
            
            if((this.rankedGuilds.ContainsKey(key:  guildId)) != false)
            {
                    if(this.rankedGuilds != null)
            {
                    return (SLC.Social.Leagues.Guild)this.myGuildInvites.Item[guildId];
            }
            
            }
            
            if((this.rankedGuildsInTier.ContainsKey(key:  guildId)) != false)
            {
                    if(this.rankedGuildsInTier != null)
            {
                    return (SLC.Social.Leagues.Guild)this.myGuildInvites.Item[guildId];
            }
            
            }
            
            if((this.myGuildInvites.ContainsKey(key:  guildId)) == false)
            {
                    return (SLC.Social.Leagues.Guild)this.myGuildInvites.Item[guildId];
            }
            
            return (SLC.Social.Leagues.Guild)this.myGuildInvites.Item[guildId];
        }
        public SLC.Social.Profile GetGuildMember(int memberId)
        {
            var val_3;
            if((this.knownMembers.ContainsKey(key:  memberId)) != false)
            {
                    SLC.Social.Profile val_2 = this.knownMembers.Item[memberId];
                return (SLC.Social.Profile)val_3;
            }
            
            val_3 = 0;
            return (SLC.Social.Profile)val_3;
        }
        public void ContributePoints(int points)
        {
            var val_10;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_12;
            .points = points;
            .<>4__this = this;
            if(this.MyGuild != null)
            {
                    SLC.Social.Leagues.LeaguesManager.API.ContributePoints(myself:  this.MyProfile, myGuild:  this.MyGuild, pointsToContribute:  (LeaguesDataController.<>c__DisplayClass40_0)[1152921519638183120].points, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LeaguesDataController.<>c__DisplayClass40_0(), method:  System.Void LeaguesDataController.<>c__DisplayClass40_0::<ContributePoints>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)));
                return;
            }
            
            val_10 = null;
            val_10 = null;
            val_12 = LeaguesDataController.<>c.<>9__40_1;
            if(val_12 == null)
            {
                    System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_9 = null;
                val_12 = val_9;
                val_9 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void LeaguesDataController.<>c::<ContributePoints>b__40_1(System.Collections.Generic.Dictionary<string, object> responseObject));
                LeaguesDataController.<>c.<>9__40_1 = val_12;
            }
            
            SLC.Social.Leagues.LeaguesManager.API.ContributePointsNoGuild(myself:  this.MyProfile, pointsToContribute:  (LeaguesDataController.<>c__DisplayClass40_0)[1152921519638183120].points, responseCallback:  val_9);
        }
        public void ContributeCoins(decimal coinsToContribute, System.Action<bool> resultAction)
        {
            var val_10;
            SLC.Social.Profile val_11;
            decimal val_12;
            SLC.Social.Leagues.Guild val_14;
            IntPtr val_16;
            .<>4__this = this;
            .resultAction = resultAction;
            .coinsToContribute = coinsToContribute;
            mem[1152921519638387320] = coinsToContribute.lo;
            mem[1152921519638387324] = coinsToContribute.mid;
            GameBehavior val_2 = App.getBehavior;
            if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    val_10 = SLC.Social.Leagues.LeaguesManager.API;
                val_11 = this.MyProfile;
                val_12 = (LeaguesDataController.<>c__DisplayClass41_0)[1152921519638387280].coinsToContribute;
                val_14 = this.MyGuild;
                val_16 = 1152921519638308752;
            }
            else
            {
                    val_10 = SLC.Social.Leagues.LeaguesManager.API;
                val_11 = this.MyProfile;
                val_12 = (LeaguesDataController.<>c__DisplayClass41_0)[1152921519638387280].coinsToContribute;
                val_14 = this.MyGuild;
                System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_9 = null;
                val_16 = 1152921519638326160;
            }
            
            val_9 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LeaguesDataController.<>c__DisplayClass41_0(), method:  val_16);
            val_10.ContributeCoins(myself:  val_11, myGuild:  val_14, coinsToContribute:  new System.Decimal() {flags = val_12, hi = val_12, lo = coinsToContribute.flags, mid = coinsToContribute.hi}, responseCallback:  val_9);
        }
        public void ContributeMultiplier(int multiplierOption, decimal multiplierToContribute, decimal multiplierCost, System.Action<bool> resultAction)
        {
            var val_10;
            SLC.Social.Profile val_11;
            SLC.Social.Leagues.Guild val_12;
            IntPtr val_14;
            .multiplierOption = multiplierOption;
            .multiplierCost = multiplierCost;
            mem[1152921519638599660] = multiplierCost.lo;
            mem[1152921519638599664] = multiplierCost.mid;
            .resultAction = resultAction;
            GameBehavior val_2 = App.getBehavior;
            if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    val_10 = SLC.Social.Leagues.LeaguesManager.API;
                val_11 = this.MyProfile;
                val_12 = this.MyGuild;
                val_14 = 1152921519638521104;
            }
            else
            {
                    val_10 = SLC.Social.Leagues.LeaguesManager.API;
                val_11 = this.MyProfile;
                val_12 = this.MyGuild;
                System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_9 = null;
                val_14 = 1152921519638538512;
            }
            
            val_9 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LeaguesDataController.<>c__DisplayClass42_0(), method:  val_14);
            val_10.ContributeMultiplier(myself:  val_11, myGuild:  val_12, multiplierToContribute:  new System.Decimal() {flags = multiplierToContribute.flags, hi = multiplierToContribute.hi, lo = multiplierToContribute.lo, mid = multiplierToContribute.mid}, responseCallback:  val_9);
        }
        public void OnFacebookPluginUpdate(Notification notification)
        {
            if(FacebookPlugin.IsLoggedIn == false)
            {
                    return;
            }
            
            if(null == null)
            {
                    return;
            }
            
            if(null != 1)
            {
                    return;
            }
            
            if(this.MyProfile == null)
            {
                    return;
            }
            
            SLC.Social.Profile val_3 = this.MyProfile;
            if((((val_3.UseFacebook == true) ? 1 : 0) ^ FacebookPlugin.IsLoggedIn) == false)
            {
                    return;
            }
            
            SLC.Social.Profile val_7 = this.MyProfile;
            Player val_8 = App.Player;
            val_7.Name = val_8.properties._profile_name;
            SLC.Social.Profile val_9 = this.MyProfile;
            Player val_10 = App.Player;
            val_9.FacebookId = val_10.properties.offline_fb_id;
            SLC.Social.Profile val_11 = this.MyProfile;
            val_11.UseFacebook = FacebookPlugin.IsLoggedIn;
            this.UpdateMyProfileInfo(force:  true);
        }
        public void UpdateLocalProfile()
        {
            if(this.MyProfile == null)
            {
                    return;
            }
            
            SLC.Social.Profile val_2 = this.MyProfile;
            Player val_3 = App.Player;
            val_2.FacebookId = val_3.properties.offline_fb_id;
            SLC.Social.Profile val_4 = this.MyProfile;
            GameBehavior val_5 = App.getBehavior;
            val_4.Level = val_5.<metaGameBehavior>k__BackingField;
            SLC.Social.Profile val_6 = this.MyProfile;
            val_6.UseFacebook = FacebookPlugin.IsLoggedIn;
            Player val_10 = App.Player;
            this.MyProfile.WordIQ = val_10.properties.PlayerIQ;
            SLC.Social.Profile val_11 = this.MyProfile;
            Player val_12 = App.Player;
            val_11.goldenCurrency = val_12._stars;
            SLC.Social.Leagues.LeaguesManager.API.UpdateUserInfo(myself:  this.MyProfile, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::SynchedProfileCallback(System.Collections.Generic.Dictionary<string, object> response)), hasCollectedFirstGuildReward:  this.HasCollectedFirstGuildReward);
        }
        public void UpdateMyProfileInfo(bool force = False)
        {
            if((this.ProfileNeedsUpdate() != true) && (force != true))
            {
                    return;
            }
            
            this.UpdateMyProfileBeforeSync();
            SLC.Social.Leagues.LeaguesManager.API.UpdateUserInfo(myself:  this.MyProfile, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::SynchedProfileCallback(System.Collections.Generic.Dictionary<string, object> response)), hasCollectedFirstGuildReward:  this.HasCollectedFirstGuildReward);
        }
        private bool ProfileNeedsUpdate()
        {
            int val_16;
            var val_17;
            val_16 = this;
            if(this.MyProfile == null)
            {
                    return (bool)val_17;
            }
            
            SLC.Social.Profile val_2 = this.MyProfile;
            if((val_2.Name.Equals(value:  "Player")) != true)
            {
                    SLC.Social.Profile val_4 = this.MyProfile;
                Player val_5 = App.Player;
                if((System.String.op_Inequality(a:  val_4.FacebookId, b:  val_5.properties.offline_fb_id)) != true)
            {
                    SLC.Social.Profile val_7 = this.MyProfile;
                if((((val_7.UseFacebook == true) ? 1 : 0) ^ FacebookPlugin.IsLoggedIn) != true)
            {
                    SLC.Social.Profile val_11 = this.MyProfile;
                if(val_11.AvatarId != 1)
            {
                    SLC.Social.Profile val_12 = this.MyProfile;
                GameBehavior val_13 = App.getBehavior;
                if(val_12.Level == (val_13.<metaGameBehavior>k__BackingField))
            {
                    SLC.Social.Profile val_14 = this.MyProfile;
                val_16 = val_14.goldenCurrency;
                Player val_15 = App.Player;
                if(val_16 == val_15._stars)
            {
                    val_17 = 0;
                return (bool)val_17;
            }
            
            }
            
            }
            
            }
            
            }
            
            }
            
            val_17 = 1;
            return (bool)val_17;
        }
        private void UpdateMyProfileBeforeSync()
        {
            if(this.MyProfile == null)
            {
                    return;
            }
            
            SLC.Social.Profile val_2 = this.MyProfile;
            if((val_2.Name.Equals(value:  "Player")) != false)
            {
                    SLC.Social.Profile val_4 = this.MyProfile;
                val_4.Name = SLC.Social.SocialManager.ProfileName;
                SLC.Social.Profile val_6 = this.MyProfile;
                val_6.AvatarId = SLC.Social.SocialManager.AvatarID;
                SLC.Social.Profile val_8 = this.MyProfile;
                val_8.Portrait_ID = SLC.Social.SocialManager.PortraitID;
            }
            
            SLC.Social.Profile val_10 = this.MyProfile;
            Player val_11 = App.Player;
            val_10.FacebookId = val_11.properties.offline_fb_id;
            SLC.Social.Profile val_12 = this.MyProfile;
            GameBehavior val_13 = App.getBehavior;
            val_12.Level = val_13.<metaGameBehavior>k__BackingField;
            SLC.Social.Profile val_14 = this.MyProfile;
            val_14.UseFacebook = FacebookPlugin.IsLoggedIn;
            Player val_18 = App.Player;
            this.MyProfile.WordIQ = val_18.properties.PlayerIQ;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnStarsUpdated");
            this.SyncGoldenCurrency();
        }
        private void SyncGoldenCurrency()
        {
            SLC.Social.Profile val_1 = this.MyProfile;
            Player val_2 = App.Player;
            if(val_1.goldenCurrency > val_2._stars)
            {
                    SLC.Social.Profile val_4 = this.MyProfile;
                App.Player.stars = val_4.goldenCurrency;
                return;
            }
            
            SLC.Social.Profile val_5 = this.MyProfile;
            Player val_6 = App.Player;
            val_5.goldenCurrency = val_6._stars;
        }
        private void SynchedProfileCallback(System.Collections.Generic.Dictionary<string, object> response)
        {
            PlayerProperties val_22;
            var val_23;
            var val_24;
            var val_25;
            Player val_1 = App.Player;
            SLC.Social.Profile val_2 = this.MyProfile;
            val_1.properties._profile_name = val_2.Name;
            Player val_3 = App.Player;
            val_22 = val_3.properties;
            SLC.Social.Profile val_4 = this.MyProfile;
            val_3.properties.profile_avatar_id = val_4.AvatarId;
            Player val_5 = App.Player;
            if(val_5.synchedGoldenCurrency == true)
            {
                    return;
            }
            
            if((response.ContainsKey(key:  "myself")) != false)
            {
                    val_23 = null;
                val_23 = null;
                if(App.game == 18)
            {
                    object val_7 = response.Item["myself"];
                val_22 = 0;
                App.Player.stars = System.Int32.Parse(s:  Item["golden_currency"], style:  511);
                App.Player.SynchedGoldenCurrency = true;
            }
            
            }
            
            if((response.ContainsKey(key:  "myself")) == false)
            {
                    return;
            }
            
            val_24 = null;
            val_24 = null;
            if(App.game != 20)
            {
                    return;
            }
            
            object val_14 = response.Item["myself"];
            val_25 = 0;
            Player val_17 = App.Player;
            App.Player.stars = UnityEngine.Mathf.Max(a:  val_17._stars, b:  System.Int32.Parse(s:  Item["golden_currency"], style:  511));
            App.Player.SynchedGoldenCurrency = true;
        }
        public void UpdateMyGuildInfo(System.Action<bool> resultAction)
        {
            .<>4__this = this;
            .resultAction = resultAction;
            SLC.Social.Leagues.LeaguesManager.API.UpdateGuildInfo(myself:  this.MyProfile, myGuild:  this.MyGuild, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LeaguesDataController.<>c__DisplayClass50_0(), method:  System.Void LeaguesDataController.<>c__DisplayClass50_0::<UpdateMyGuildInfo>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public void RemoveGuildMember(SLC.Social.Profile toRemove)
        {
            .toRemove = toRemove;
            .<>4__this = this;
            this.MyGuild.RemoveMember(toRemove:  (LeaguesDataController.<>c__DisplayClass51_0)[1152921519640524112].toRemove);
            SLC.Social.Leagues.Guild val_3 = this.MyGuild;
            .guild_id = val_3.ServerId;
            SLC.Social.Profile val_4 = this.MyProfile;
            if(((LeaguesDataController.<>c__DisplayClass51_0)[1152921519640524112].toRemove.ServerId) == val_4.ServerId)
            {
                    SLC.Social.Leagues.LeaguesManager.DAO.Pref_GuildId = 0;
            }
            
            SLC.Social.Leagues.LeaguesManager.API.RemoveGuildMember(myself:  this.MyProfile, myGuild:  this.MyGuild, toDelete:  (LeaguesDataController.<>c__DisplayClass51_0)[1152921519640524112].toRemove, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LeaguesDataController.<>c__DisplayClass51_0(), method:  System.Void LeaguesDataController.<>c__DisplayClass51_0::<RemoveGuildMember>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public void RejectGuildRequest(SLC.Social.Leagues.GuildJoinRequest inviteRequest)
        {
            SLC.Social.Profile val_1 = this.MyProfile;
            if(val_1.GuildMaster != true)
            {
                    SLC.Social.Profile val_2 = this.MyProfile;
                if(val_2.Officer == false)
            {
                    return;
            }
            
            }
            
            SLC.Social.Leagues.Guild val_3 = this.MyGuild;
            bool val_4 = val_3.pendingRequests.Remove(item:  inviteRequest);
            SLC.Social.Leagues.LeaguesManager.API.RejectInviteRequest(myself:  this.MyProfile, requested:  inviteRequest, responseCallback:  0);
        }
        public void DemoteMember(SLC.Social.Profile toDemote, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            SLC.Social.Profile val_1 = this.MyProfile;
            if(val_1.GuildMaster == false)
            {
                    return;
            }
            
            toDemote.Officer = false;
            SLC.Social.Leagues.LeaguesManager.API.DemoteMember(myself:  this.MyProfile, myGuild:  this.MyGuild, toDemote:  toDemote, responseCallback:  responseCallback);
        }
        public void PromoteMember(SLC.Social.Profile toPromote, System.Action<System.Collections.Generic.Dictionary<string, object>> responseCallback)
        {
            SLC.Social.Profile val_1 = this.MyProfile;
            if(val_1.GuildMaster == false)
            {
                    return;
            }
            
            toPromote.Officer = true;
            SLC.Social.Leagues.LeaguesManager.API.PromoteMember(myself:  this.MyProfile, myGuild:  this.MyGuild, toPromote:  toPromote, responseCallback:  responseCallback);
        }
        public void AcceptGuildRequest(SLC.Social.Leagues.GuildJoinRequest inviteRequest)
        {
            SLC.Social.Profile val_1 = this.MyProfile;
            if(val_1.GuildMaster != true)
            {
                    SLC.Social.Profile val_2 = this.MyProfile;
                if(val_2.Officer == false)
            {
                    return;
            }
            
            }
            
            SLC.Social.Leagues.Guild val_3 = this.MyGuild;
            bool val_4 = val_3.pendingRequests.Remove(item:  inviteRequest);
            SLC.Social.Leagues.LeaguesManager.API.AcceptInviteRequest(myself:  this.MyProfile, requested:  inviteRequest, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<AcceptGuildRequest>b__55_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public SLC.Social.Leagues.Guild GetMembersAndUpdateMyGuild()
        {
            SLC.Social.Leagues.Guild val_1 = this.MyGuild;
            return this.GetGuildAndMembers(guildId:  val_1.ServerId);
        }
        public SLC.Social.Leagues.Guild GetGuildAndMembers(int guildId)
        {
            SLC.Social.Leagues.LeaguesManager.API.GetOtherGuild(member:  this.MyProfile, guildServerId:  guildId, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::GetGuildAndMembersCallback(System.Collections.Generic.Dictionary<string, object> responseObject)));
            return this.GetGuild(guildId:  guildId);
        }
        private void GetGuildAndMembersCallback(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.DelayedGetGuildAndMembers(responseObject:  responseObject));
        }
        private System.Collections.IEnumerator DelayedGetGuildAndMembers(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .responseObject = responseObject;
            return (System.Collections.IEnumerator)new LeaguesDataController.<DelayedGetGuildAndMembers>d__59();
        }
        public void UpdateEligibleGuildsToJoin()
        {
            if(this.MyGuild != null)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesManager.API.GetEligibleGuildsToJoin(member:  this.MyProfile, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<UpdateEligibleGuildsToJoin>b__60_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public void UpdateMyGuildInvites()
        {
            if(this.MyGuild != null)
            {
                    return;
            }
            
            if(this.MyId == 1)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesManager.API.GetMyGuildInvites(member:  this.MyProfile, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<UpdateMyGuildInvites>b__61_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public void InviteMemberToMyGuild(int memberID, System.Action<System.Collections.Generic.Dictionary<string, object>> responseObject)
        {
            if(this.MyGuild == null)
            {
                    return;
            }
            
            SLC.Social.Profile val_4 = this.MyProfile;
            SLC.Social.Leagues.LeaguesManager.API.InviteToMyGuild(me:  this.MyProfile, myClubId:  val_4.GuildServerId, idToInvite:  memberID, responseCallback:  responseObject);
        }
        public void RespondToClubInvite(int clubID, bool accepted)
        {
            var val_6;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_8;
            if(this.MyGuild != null)
            {
                    return;
            }
            
            val_6 = null;
            val_6 = null;
            val_8 = LeaguesDataController.<>c.<>9__63_0;
            if(val_8 == null)
            {
                    System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_4 = null;
                val_8 = val_4;
                val_4 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void LeaguesDataController.<>c::<RespondToClubInvite>b__63_0(System.Collections.Generic.Dictionary<string, object> responseObject));
                LeaguesDataController.<>c.<>9__63_0 = val_8;
            }
            
            SLC.Social.Leagues.LeaguesManager.API.ConsumeClubInvite(me:  this.MyProfile, inviteClubId:  clubID, accepted:  accepted, responseCallback:  val_4);
        }
        public System.Collections.Generic.Dictionary<int, SLC.Social.Leagues.Guild> GetGuildsByName(string queryString)
        {
            string val_11;
            SLC.Social.Leagues.LeaguesDataController val_12;
            var val_13;
            var val_14;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_16;
            val_11 = queryString;
            val_12 = this;
            LeaguesDataController.<>c__DisplayClass64_0 val_1 = new LeaguesDataController.<>c__DisplayClass64_0();
            .<>4__this = val_12;
            .queryString = val_11;
            val_13 = 0;
            if((System.String.IsNullOrEmpty(value:  val_11)) == true)
            {
                    return (System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild>)val_13;
            }
            
            if(((LeaguesDataController.<>c__DisplayClass64_0)[1152921519642536144].queryString.m_stringLength) >= 2)
            {
                    SLC.Social.Leagues.LeaguesManager.API.GetGuildsByName(member:  this.MyProfile, queryString:  (LeaguesDataController.<>c__DisplayClass64_0)[1152921519642536144].queryString, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_1, method:  System.Void LeaguesDataController.<>c__DisplayClass64_0::<GetGuildsByName>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)));
                val_12 = System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>>(source:  this.knownGuilds, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Boolean>(object:  val_1, method:  System.Boolean LeaguesDataController.<>c__DisplayClass64_0::<GetGuildsByName>b__1(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> p)));
                val_14 = null;
                val_14 = null;
                val_16 = LeaguesDataController.<>c.<>9__64_2;
                if(val_16 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_8 = null;
                val_16 = val_8;
                val_8 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesDataController.<>c::<GetGuildsByName>b__64_2(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
                val_14 = null;
                LeaguesDataController.<>c.<>9__64_2 = val_16;
            }
            
                val_14 = null;
                val_11 = LeaguesDataController.<>c.<>9__64_3;
                if(val_11 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild> val_9 = null;
                val_11 = val_9;
                val_9 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  SLC.Social.Leagues.Guild LeaguesDataController.<>c::<GetGuildsByName>b__64_3(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
                LeaguesDataController.<>c.<>9__64_3 = val_11;
            }
            
                System.Collections.Generic.Dictionary<TKey, TElement> val_10 = System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  val_12, keySelector:  val_8, elementSelector:  val_9);
                return (System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild>)val_13;
            }
            
            val_13 = 0;
            return (System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild>)val_13;
        }
        public SLC.Social.Leagues.Guilds GetGuildsInMyTier()
        {
            SLC.Social.Leagues.Guild val_2 = this.MyGuild;
            SLC.Social.Leagues.LeaguesManager.API.GetGuildsInMyTier(serverId:  val_2.ServerId, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<GetGuildsInMyTier>b__65_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
            return (SLC.Social.Leagues.Guilds)this.rankedGuilds;
        }
        public void RequestGuildsByTier(int tier, System.Action callBack)
        {
            .<>4__this = this;
            .callBack = callBack;
            SLC.Social.Leagues.LeaguesManager.API.GetGuildsInThisTier(tier:  tier, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LeaguesDataController.<>c__DisplayClass66_0(), method:  System.Void LeaguesDataController.<>c__DisplayClass66_0::<RequestGuildsByTier>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public SLC.Social.Leagues.Guild PurchaseGuild(int guildIconIndex, string guildName, string motto, bool requiresInvite, int vipLevelRequired = 0)
        {
            string val_9;
            var val_10;
            SLC.Social.Leagues.Guild val_11;
            val_9 = motto;
            Player val_1 = App.Player;
            val_10 = null;
            val_10 = null;
            bool val_2 = System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41967616}, d2:  new System.Decimal() {flags = SLC.Social.Leagues.LeaguesEconomy.CostToCreate, hi = SLC.Social.Leagues.LeaguesEconomy.CostToCreate, lo = SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_8, mid = SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_8});
            val_11 = 0;
            if(val_2 == true)
            {
                    return val_11;
            }
            
            val_2.Pref_CreatedGuild = true;
            val_11 = SLC.Social.Leagues.Guild.Create(guildName:  guildName, guildIcon:  guildIconIndex, motto:  val_9, guildMaster:  this.MyProfile, requiresInvite:  requiresInvite, vipLevelRequired:  vipLevelRequired);
            val_9 = this.MyProfile;
            SLC.Social.Leagues.LeaguesManager.API.CreateGuild(member:  val_9, guild:  val_11, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<PurchaseGuild>b__67_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
            return val_11;
        }
        public SLC.Social.Leagues.Guild JoinGuild(int idToJoin)
        {
            int val_6 = idToJoin;
            LeaguesDataController.<>c__DisplayClass68_0 val_1 = new LeaguesDataController.<>c__DisplayClass68_0();
            .<>4__this = this;
            val_1.Pref_CreatedGuild = false;
            SLC.Social.Leagues.Guild val_2 = this.GetGuild(guildId:  val_6 = idToJoin);
            if(val_2.InviteRequired != false)
            {
                    this.JoinPrivateGuild(idToJoin:  val_6);
                return val_2;
            }
            
            .oldGuild = this.MyGuild;
            val_6 = (LeaguesDataController.<>c__DisplayClass68_0)[1152921519643193040].oldGuild;
            SLC.Social.Leagues.LeaguesManager.API.JoinGuild(toJoin:  val_2, oldGuild:  val_6, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_1, method:  System.Void LeaguesDataController.<>c__DisplayClass68_0::<JoinGuild>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)));
            return val_2;
        }
        public void JoinPrivateGuild(int idToJoin)
        {
            var val_4;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_6;
            val_4 = null;
            val_4 = null;
            val_6 = LeaguesDataController.<>c.<>9__69_0;
            if(val_6 == null)
            {
                    System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_3 = null;
                val_6 = val_3;
                val_3 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void LeaguesDataController.<>c::<JoinPrivateGuild>b__69_0(System.Collections.Generic.Dictionary<string, object> responseObject));
                LeaguesDataController.<>c.<>9__69_0 = val_6;
            }
            
            SLC.Social.Leagues.LeaguesManager.API.JoinPrivateGuild(toJoin:  this.GetGuild(guildId:  idToJoin), responseCallback:  val_3);
        }
        public void ResetMembership(string fields)
        {
            SLC.Social.Leagues.LeaguesManager.API.ResetMembership(member:  this.MyProfile, responseCallback:  0, fields:  fields);
        }
        public void GetGuildChat()
        {
            SLC.Social.Leagues.LeaguesManager.CHAT_API.GetGuildChat(myself:  this.MyProfile, guildServerId:  this.MyGuildServerId, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<GetGuildChat>b__71_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        public void SendChatMessage(string message, System.Action<bool, string> OnMessagerResponse)
        {
            LeaguesDataController.<>c__DisplayClass72_0 val_1 = new LeaguesDataController.<>c__DisplayClass72_0();
            .OnMessagerResponse = OnMessagerResponse;
            .message = message;
            .<>4__this = this;
            SLC.Social.Leagues.LeaguesManager.CHAT_API.SendChat(myself:  this.MyProfile, guild:  this.MyGuild, messageToPost:  (LeaguesDataController.<>c__DisplayClass72_0)[1152921519643788496].message, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_1, method:  System.Void LeaguesDataController.<>c__DisplayClass72_0::<SendChatMessage>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)), onRequestFails:  new System.Action<System.String>(object:  val_1, method:  System.Void LeaguesDataController.<>c__DisplayClass72_0::<SendChatMessage>b__1(string apiCall)));
        }
        public void GetGuildLog()
        {
            SLC.Social.Leagues.LeaguesManager.CHAT_API.GetGuildLog(myself:  this.MyProfile, guild:  this.MyGuild, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesDataController::<GetGuildLog>b__73_0(System.Collections.Generic.Dictionary<string, object> responseObject)));
        }
        private void DecodeAndAddOrMergeGuild(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            SLC.Social.Leagues.Guild val_1 = new SLC.Social.Leagues.Guild();
            val_1.Decode(jasonObject:  responseObject, sourceModel:  0);
            this.AddOrMergeKnownGuild(toKnow:  val_1);
        }
        private void DecodeAndAnddOrMergeGuildMember(System.Collections.Generic.Dictionary<string, object> guildMemberData)
        {
            SLC.Social.Profile val_1 = new SLC.Social.Profile();
            val_1.Decode(jasonObject:  guildMemberData, sourceModel:  0);
            this.AddOrMergeKnownMember(toKnow:  val_1);
        }
        public void AddOrMergeKnownGuild(SLC.Social.Leagues.Guild toKnow)
        {
            this.knownGuilds.AddGuild(id:  toKnow.ServerId, toAdd:  toKnow);
        }
        public void AddOrMergeKnownMember(SLC.Social.Profile toKnow)
        {
            SLC.Social.Profile val_8 = toKnow;
            if(val_8 == null)
            {
                    return;
            }
            
            if((this.knownMembers.ContainsKey(key:  toKnow.ServerId)) != false)
            {
                    SLC.Social.Profile val_2 = this.knownMembers.Item[toKnow.ServerId];
                val_8 = ???;
            }
            else
            {
                    this.knownMembers.Add(key:  toKnow.ServerId, value:  val_8 = toKnow);
            }
        
        }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> get_GuildsToJoin()
        {
            var val_5;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_7;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild> val_9;
            val_5 = null;
            val_5 = null;
            val_7 = LeaguesDataController.<>c.<>9__85_0;
            if(val_7 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_1 = null;
                val_7 = val_1;
                val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesDataController.<>c::<get_GuildsToJoin>b__85_0(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
                val_5 = null;
                LeaguesDataController.<>c.<>9__85_0 = val_7;
            }
            
            val_5 = null;
            val_9 = LeaguesDataController.<>c.<>9__85_1;
            if(val_9 != null)
            {
                    return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  this.eligibleGuilds, keySelector:  val_1, elementSelector:  System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild> val_2 = null).Values);
            }
            
            val_9 = val_2;
            val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  SLC.Social.Leagues.Guild LeaguesDataController.<>c::<get_GuildsToJoin>b__85_1(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
            LeaguesDataController.<>c.<>9__85_1 = val_9;
            return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  this.eligibleGuilds, keySelector:  val_1, elementSelector:  val_2).Values);
        }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> get_GuildsInvited()
        {
            var val_5;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_7;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild> val_9;
            val_5 = null;
            val_5 = null;
            val_7 = LeaguesDataController.<>c.<>9__87_0;
            if(val_7 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_1 = null;
                val_7 = val_1;
                val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesDataController.<>c::<get_GuildsInvited>b__87_0(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
                val_5 = null;
                LeaguesDataController.<>c.<>9__87_0 = val_7;
            }
            
            val_5 = null;
            val_9 = LeaguesDataController.<>c.<>9__87_1;
            if(val_9 != null)
            {
                    return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  this.myGuildInvites, keySelector:  val_1, elementSelector:  System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Object>, System.Object> val_2 = null).Values);
            }
            
            val_9 = val_2;
            val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Object>, System.Object>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  SLC.Social.Leagues.Guild LeaguesDataController.<>c::<get_GuildsInvited>b__87_1(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
            LeaguesDataController.<>c.<>9__87_1 = val_9;
            return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  this.myGuildInvites, keySelector:  val_1, elementSelector:  val_2).Values);
        }
        public void RemoveGuildInviteById(int guildId)
        {
            if(this.myGuildInvites != null)
            {
                    this.myGuildInvites.RemoveKnownGuild(id:  guildId);
                return;
            }
            
            throw new NullReferenceException();
        }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> GetKnownGuildsByName(string queryString)
        {
            var val_8;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_10;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild> val_12;
            .queryString = queryString;
            val_8 = null;
            val_8 = null;
            val_10 = LeaguesDataController.<>c.<>9__89_1;
            if(val_10 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32> val_4 = null;
                val_10 = val_4;
                val_4 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesDataController.<>c::<GetKnownGuildsByName>b__89_1(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
                val_8 = null;
                LeaguesDataController.<>c.<>9__89_1 = val_10;
            }
            
            val_8 = null;
            val_12 = LeaguesDataController.<>c.<>9__89_2;
            if(val_12 != null)
            {
                    return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>>(source:  this.knownGuilds, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Boolean>(object:  new LeaguesDataController.<>c__DisplayClass89_0(), method:  System.Boolean LeaguesDataController.<>c__DisplayClass89_0::<GetKnownGuildsByName>b__0(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> p))), keySelector:  val_4, elementSelector:  System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild> val_5 = null).Values);
            }
            
            val_12 = val_5;
            val_5 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, SLC.Social.Leagues.Guild>(object:  LeaguesDataController.<>c.__il2cppRuntimeField_static_fields, method:  SLC.Social.Leagues.Guild LeaguesDataController.<>c::<GetKnownGuildsByName>b__89_2(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> t));
            LeaguesDataController.<>c.<>9__89_2 = val_12;
            return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Int32, SLC.Social.Leagues.Guild>(source:  System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>>(source:  this.knownGuilds, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Leagues.Guild>, System.Boolean>(object:  new LeaguesDataController.<>c__DisplayClass89_0(), method:  System.Boolean LeaguesDataController.<>c__DisplayClass89_0::<GetKnownGuildsByName>b__0(System.Collections.Generic.KeyValuePair<int, SLC.Social.Leagues.Guild> p))), keySelector:  val_4, elementSelector:  val_5).Values);
        }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> get_GuildsInMyTier()
        {
            return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  this.rankedGuilds.Values);
        }
        public System.Collections.Generic.List<SLC.Social.Leagues.Guild> get_GuildsInSearchedTier()
        {
            return System.Linq.Enumerable.ToList<SLC.Social.Leagues.Guild>(source:  this.rankedGuildsInTier.Values);
        }
        public LeaguesDataController()
        {
            decimal val_1;
            this.HasCollectedFirstGuildReward = true;
            this.statusChangeToShowThisSession = 7;
            this.LastSeasonRank = -1;
            this.LastSeasonTier = -1;
            val_1 = new System.Decimal(lo:  10, mid:  0, hi:  0, isNegative:  false, scale:  1);
            this.MyId = 0;
            this.LastSeasonMultiplier = val_1.flags;
            this.rankedGuilds = new SLC.Social.Leagues.Guilds();
            this.rankedGuildsInTier = new SLC.Social.Leagues.Guilds();
            this.knownGuilds = new SLC.Social.Leagues.Guilds();
            this.eligibleGuilds = new SLC.Social.Leagues.Guilds();
            this.myGuildInvites = new SLC.Social.Leagues.Guilds();
            this.knownMembers = new SLC.Social.Leagues.GuildMembers();
        }
        private static LeaguesDataController()
        {
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.Dictionary<System.String, System.String>> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.Dictionary<System.String, System.String>>();
            System.Collections.Generic.Dictionary<System.String, System.String> val_2 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_2.Add(key:  "id", value:  "id_leagues_pro0");
            val_2.Add(key:  "sale_price", value:  "19.99");
            val_1.Add(key:  0, value:  val_2);
            System.Collections.Generic.Dictionary<System.String, System.String> val_3 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_3.Add(key:  "id", value:  "id_leagues_pro1");
            val_3.Add(key:  "sale_price", value:  "34.99");
            val_1.Add(key:  1, value:  val_3);
            System.Collections.Generic.Dictionary<System.String, System.String> val_4 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_4.Add(key:  "id", value:  "id_leagues_pro2");
            val_4.Add(key:  "sale_price", value:  "49.99");
            val_1.Add(key:  2, value:  val_4);
            SLC.Social.Leagues.LeaguesDataController.LeaguesProMembershipPackages = val_1;
        }
        private void <AcceptGuildRequest>b__55_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_9;
            var val_10;
            var val_11;
            object val_1 = responseObject.Item["guild"];
            val_9 = 0;
            this.DecodeAndAddOrMergeGuild(responseObject:  null);
            if((responseObject.ContainsKey(key:  "invites")) != false)
            {
                    object val_4 = responseObject.Item["invites"];
                val_10 = 0;
                this.MyGuild.MergeInvites(invitesToParse:  null);
                SLC.Social.Leagues.Guild val_5 = this.MyGuild;
                this.knownMembers.UpdateMembers(requests:  val_5.pendingRequests);
            }
            
            SLC.Social.Profile val_6 = new SLC.Social.Profile();
            object val_7 = responseObject.Item["membership"];
            val_11 = 0;
            val_6.Decode(jasonObject:  null, sourceModel:  0);
            this.MyGuild.AddMember(toAdd:  val_6);
            this.AddOrMergeKnownMember(toKnow:  val_6);
        }
        private void <UpdateEligibleGuildsToJoin>b__60_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_3;
            var val_4;
            this.eligibleGuilds.Clear();
            object val_1 = responseObject.Item["guilds"];
            val_3 = 0;
            this.eligibleGuilds.Update(guilds:  null, fromModel:  0);
            object val_2 = responseObject.Item["guilds"];
            val_4 = 0;
            this.knownGuilds.Update(guilds:  null, fromModel:  0);
        }
        private void <UpdateMyGuildInvites>b__61_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_2;
            this.myGuildInvites.Clear();
            object val_1 = responseObject.Item["guilds"];
            val_2 = 0;
            this.myGuildInvites.Update(guilds:  null, fromModel:  0);
        }
        private void <GetGuildsInMyTier>b__65_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_2;
            this.rankedGuilds.Clear();
            object val_1 = responseObject.Item["guilds"];
            val_2 = 0;
            this.rankedGuilds.Update(guilds:  null, fromModel:  0);
        }
        private void <PurchaseGuild>b__67_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_5;
            var val_6;
            val_5 = null;
            val_5 = null;
            decimal val_2 = System.Decimal.op_UnaryNegation(d:  new System.Decimal() {flags = SLC.Social.Leagues.LeaguesEconomy.CostToCreate, hi = SLC.Social.Leagues.LeaguesEconomy.CostToCreate, lo = SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_8, mid = SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_8});
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Club Creation", subSource:  0, externalParams:  0, doTrack:  true);
            CurrencyController.HandleBalanceChanged(type:  0);
            object val_3 = responseObject.Item["guild"];
            val_6 = 0;
            this.DecodeAndAddOrMergeGuild(responseObject:  null);
            this.rankedGuilds.Clear();
            MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.OnGuildStatusChanged(state:  2, source:  "", leftGuildId:  0, forDisplayOnly:  false);
        }
        private void <GetGuildChat>b__71_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_4;
            if((responseObject.ContainsKey(key:  "chat")) == false)
            {
                    return;
            }
            
            object val_3 = responseObject.Item["chat"];
            val_4 = 0;
            this.MyGuild.MergeChat(toParse:  null);
        }
        private void <GetGuildLog>b__73_0(System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            var val_3;
            object val_2 = responseObject.Item["log"];
            val_3 = 0;
            this.MyGuild.MergeLog(toParse:  null);
        }
    
    }

}
