using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesTracker
    {
        // Fields
        private const string key_league_points_contrib_winnings = "my_lp_ctrb_wins";
        private const string key_event_credit_contribution = "my_event_credit_ctrb";
        private const string key_credit_direct_contribution = "my_credit_ctrb";
        private const string key_lifetime_credit_direct = "my_credit_ctrb_lifetime";
        private const string pref_key_num_completed_events = "sll_complete_events";
        private const string pref_key_date_daily_rollover = "sll_daily_event_rollover";
        private static System.DateTime _ScheduledDailyRollover;
        private static string coinsColor;
        private static string pointsColor;
        private static System.Collections.Generic.Queue<string> _DebugLogicLogs;
        
        // Properties
        private static System.DateTime ScheduledDailyRollover { get; set; }
        public static System.DateTime LastNameChange { get; set; }
        public static System.DateTime LastAvatarChange { get; set; }
        private static int NumCompletedEvents { get; set; }
        public static System.Collections.Generic.Queue<string> DebugLogicLogs { get; }
        
        // Methods
        private static System.DateTime get_ScheduledDailyRollover()
        {
            var val_12;
            var val_13;
            var val_14;
            if((UnityEngine.PlayerPrefs.HasKey(key:  "sll_daily_event_rollover")) != false)
            {
                    System.DateTime val_3 = System.DateTime.UtcNow;
                System.DateTime val_4 = val_3.dateData.Date;
                System.DateTime val_5 = val_4.dateData.AddDays(value:  1);
                System.DateTime val_6 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "sll_daily_event_rollover"), defaultValue:  new System.DateTime() {dateData = val_5.dateData});
                val_12 = null;
                val_12 = null;
                SLC.Social.Leagues.LeaguesTracker._ScheduledDailyRollover = val_6.dateData;
            }
            else
            {
                    System.DateTime val_7 = DateTimeCheat.UtcNow;
                System.DateTime val_8 = val_7.dateData.Date;
                System.DateTime val_9 = val_8.dateData.AddDays(value:  1);
                val_13 = null;
                val_13 = null;
                SLC.Social.Leagues.LeaguesTracker._ScheduledDailyRollover = val_9.dateData;
                UnityEngine.PlayerPrefs.SetString(key:  "sll_daily_event_rollover", value:  SLC.Social.Leagues.LeaguesTracker._ScheduledDailyRollover.ToString());
                bool val_11 = PrefsSerializationManager.SavePlayerPrefs();
            }
            
            val_14 = null;
            val_14 = null;
            return (System.DateTime)SLC.Social.Leagues.LeaguesTracker._ScheduledDailyRollover;
        }
        private static void set_ScheduledDailyRollover(System.DateTime value)
        {
            null = null;
            SLC.Social.Leagues.LeaguesTracker._ScheduledDailyRollover = value.dateData;
            UnityEngine.PlayerPrefs.SetString(key:  "sll_daily_event_rollover", value:  SLC.Social.Leagues.LeaguesTracker._ScheduledDailyRollover.ToString());
            bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public static System.DateTime get_LastNameChange()
        {
            var val_2 = null;
            return SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "lastNameChange"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        }
        public static void set_LastNameChange(System.DateTime value)
        {
            CPlayerPrefs.SetString(key:  "lastNameChange", val:  value.dateData.ToString());
        }
        public static System.DateTime get_LastAvatarChange()
        {
            var val_2 = null;
            return SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "lastAvatarChange"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        }
        public static void set_LastAvatarChange(System.DateTime value)
        {
            CPlayerPrefs.SetString(key:  "lastAvatarChange", val:  value.dateData.ToString());
        }
        public static void AddLeaguePointsContributionFromSlots(int leaguePoints)
        {
            var val_6;
            int val_7;
            decimal val_2 = System.Decimal.op_Implicit(value:  leaguePoints);
            new AggregateEventCalculator(name:  "my_lp_ctrb_wins").Calculate(valueToAggregate:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, autoFlush:  false);
            object[] val_3 = new object[5];
            val_6 = null;
            val_6 = null;
            val_3[0] = SLC.Social.Leagues.LeaguesTracker.pointsColor;
            val_7 = val_3.Length;
            val_3[1] = leaguePoints.ToString(format:  "#,##0");
            val_7 = val_3.Length;
            val_3[2] = "POINTS";
            val_7 = val_3.Length;
            val_3[3] = "C7325F";
            val_7 = val_3.Length;
            val_3[4] = "From Slots Winnings";
            SLC.Social.Leagues.LeaguesTracker.AddDebugLogicLog(log:  System.String.Format(format:  "<color=#{0}>+{1} {2}</color> : <color=#{3}>{4}</color>", args:  val_3));
        }
        public static void AddToChatMessageCount()
        {
            var val_2 = null;
            new AggregateEventCalculator(name:  "Total Club Wall Posts Made").Calculate(valueToAggregate:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0}, autoFlush:  false);
        }
        public static void AddDirectCreditContribution(decimal contribution, string source)
        {
            var val_14;
            var val_15;
            int val_16;
            new AggregateEventCalculator(name:  "my_credit_ctrb").Calculate(valueToAggregate:  new System.Decimal() {flags = contribution.flags, hi = contribution.hi, lo = contribution.lo, mid = contribution.mid}, autoFlush:  false);
            new AggregateEventCalculator(name:  "my_credit_ctrb_lifetime").Calculate(valueToAggregate:  new System.Decimal() {flags = contribution.flags, hi = contribution.hi, lo = contribution.lo, mid = contribution.mid}, autoFlush:  false);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_5.Add(key:  "Source", value:  source);
            val_5.Add(key:  "Amount Contributed", value:  contribution);
            SLC.Social.Leagues.Guild val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_5.Add(key:  "Club Name", value:  val_7.Name);
            SLC.Social.Leagues.Guild val_9 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_5.Add(key:  "Club ID", value:  val_9.ServerId);
            val_5.Add(key:  "League Tier", value:  val_4.tier);
            val_5.Add(key:  "Club Level", value:  val_4.guildLevel);
            val_5.Add(key:  "Num Members", value:  val_4.MemberCount);
            decimal val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.GetLeagueContributedCoins;
            val_5.Add(key:  "Total Coin Contribution of Club", value:  val_10);
            val_14 = null;
            val_14 = null;
            App.trackerManager.track(eventName:  "Leagues Contribution", data:  val_5);
            object[] val_11 = new object[5];
            val_15 = null;
            val_15 = null;
            val_11[0] = SLC.Social.Leagues.LeaguesTracker.coinsColor;
            val_16 = val_11.Length;
            val_11[1] = contribution.flags.ToString(format:  "#,##0");
            val_16 = val_11.Length;
            val_11[2] = "COINS";
            val_16 = val_11.Length;
            val_11[3] = "5F7AB9";
            val_16 = val_11.Length;
            val_11[4] = "Leagues Contribution";
            SLC.Social.Leagues.LeaguesTracker.AddDebugLogicLog(log:  System.String.Format(format:  "<color=#{0}>+{1} {2}</color> : <color=#{3}>{4}</color>", args:  val_11));
        }
        public static void AddDirectGemContribution(decimal contribution, string source)
        {
            var val_14;
            var val_15;
            int val_16;
            new AggregateEventCalculator(name:  "my_credit_ctrb").Calculate(valueToAggregate:  new System.Decimal() {flags = contribution.flags, hi = contribution.hi, lo = contribution.lo, mid = contribution.mid}, autoFlush:  false);
            new AggregateEventCalculator(name:  "my_credit_ctrb_lifetime").Calculate(valueToAggregate:  new System.Decimal() {flags = contribution.flags, hi = contribution.hi, lo = contribution.lo, mid = contribution.mid}, autoFlush:  false);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_5.Add(key:  "Source", value:  source);
            val_5.Add(key:  "Amount Contributed", value:  contribution);
            SLC.Social.Leagues.Guild val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_5.Add(key:  "Club Name", value:  val_7.Name);
            SLC.Social.Leagues.Guild val_9 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_5.Add(key:  "Club ID", value:  val_9.ServerId);
            val_5.Add(key:  "League Tier", value:  val_4.tier);
            val_5.Add(key:  "Club Level", value:  val_4.guildLevel);
            val_5.Add(key:  "Num Members", value:  val_4.MemberCount);
            decimal val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.GetLeagueContributedCoins;
            val_5.Add(key:  "Total Gem Contribution of Club", value:  val_10);
            val_14 = null;
            val_14 = null;
            App.trackerManager.track(eventName:  "Leagues Contribution", data:  val_5);
            object[] val_11 = new object[5];
            val_15 = null;
            val_15 = null;
            val_11[0] = SLC.Social.Leagues.LeaguesTracker.coinsColor;
            val_16 = val_11.Length;
            val_11[1] = contribution.flags.ToString(format:  "#,##0");
            val_16 = val_11.Length;
            val_11[2] = "GEMS";
            val_16 = val_11.Length;
            val_11[3] = "5F7AB9";
            val_16 = val_11.Length;
            val_11[4] = "Leagues Contribution";
            SLC.Social.Leagues.LeaguesTracker.AddDebugLogicLog(log:  System.String.Format(format:  "<color=#{0}>+{1} {2}</color> : <color=#{3}>{4}</color>", args:  val_11));
        }
        private static int get_NumCompletedEvents()
        {
            return UnityEngine.PlayerPrefs.GetInt(key:  "sll_complete_events", defaultValue:  0);
        }
        private static void set_NumCompletedEvents(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "sll_complete_events", value:  value);
            bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public static void SetNumCompletedEvents(int num)
        {
            var val_2 = null;
            if(SLC.Social.Leagues.LeaguesTracker.NumCompletedEvents >= num)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesTracker.NumCompletedEvents = num;
        }
        public static void CheckDailyRollover()
        {
            System.DateTime val_1 = DateTimeCheat.UtcNow;
            System.DateTime val_2 = SLC.Social.Leagues.LeaguesTracker.ScheduledDailyRollover;
            System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
            if(val_3._ticks.TotalSeconds <= 0f)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesTracker.TrackDailyRollover();
        }
        private static void TrackDailyRollover()
        {
            var val_24;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_3.Add(key:  "Club Name", value:  val_2.Name);
            val_3.Add(key:  "Club ID", value:  val_2.ServerId);
            val_3.Add(key:  "Club Level", value:  val_2.guildLevel);
            val_3.Add(key:  "Club Requirement", value:  val_2.requiredVIPLevel);
            val_3.Add(key:  "League Tier", value:  val_2.tier);
            val_3.Add(key:  "Num Members", value:  val_2.MemberCount);
            AggregateEventCalculator val_4 = new AggregateEventCalculator(name:  "my_lp_ctrb_wins");
            val_3.Add(key:  "My Point Contribution", value:  (AggregateEventCalculator)[1152921519682211808].aggregate);
            AggregateEventCalculator val_5 = new AggregateEventCalculator(name:  "my_credit_ctrb");
            val_3.Add(key:  "My Coin Contribution", value:  (AggregateEventCalculator)[1152921519682220000].aggregate);
            decimal val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.GetLeagueContributedCoins;
            val_3.Add(key:  "Total Coin Contribution of Club", value:  val_6);
            System.DateTime val_7 = SLC.Social.Leagues.LeaguesTracker.LastAvatarChange;
            System.DateTime val_8 = val_7.dateData.Date;
            System.DateTime val_9 = DateTimeCheat.UtcNow;
            System.DateTime val_10 = val_9.dateData.AddDays(value:  -1);
            System.DateTime val_11 = val_10.dateData.Date;
            val_3.Add(key:  "Profile Avatar Changed", value:  System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_8.dateData}, d2:  new System.DateTime() {dateData = val_11.dateData}));
            System.DateTime val_14 = SLC.Social.Leagues.LeaguesTracker.LastNameChange;
            System.DateTime val_15 = val_14.dateData.Date;
            System.DateTime val_16 = DateTimeCheat.UtcNow;
            System.DateTime val_17 = val_16.dateData.AddDays(value:  -1);
            System.DateTime val_18 = val_17.dateData.Date;
            val_3.Add(key:  "Profile Name Changed", value:  System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_15.dateData}, d2:  new System.DateTime() {dateData = val_18.dateData}));
            if((MonoSingleton<WordGameEventsController>.Instance) != 0)
            {
                    MonoSingleton<WordGameEventsController>.Instance.AppendLeaguesRolloverData(curData: ref  val_3);
            }
            
            val_24 = null;
            val_24 = null;
            App.trackerManager.track(eventName:  "Leagues Daily Rollover", data:  val_3);
            SLC.Social.Leagues.LeaguesTracker.FlushDailyData();
        }
        private static void FlushDailyData()
        {
            new AggregateEventCalculator(name:  "my_event_credit_ctrb").Flush();
            new AggregateEventCalculator(name:  "my_lp_ctrb_wins").Flush();
            new AggregateEventCalculator(name:  "my_credit_ctrb").Flush();
            SLC.Social.Leagues.LeaguesTracker.NumCompletedEvents = 0;
            System.DateTime val_4 = DateTimeCheat.UtcNow;
            System.DateTime val_5 = val_4.dateData.Date;
            System.DateTime val_6 = val_5.dateData.AddDays(value:  1);
            SLC.Social.Leagues.LeaguesTracker.ScheduledDailyRollover = new System.DateTime() {dateData = val_6.dateData};
        }
        public static void TrackSeasonRollover()
        {
            var val_14;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.Add(key:  "Previous Tier", value:  val_2.LastSeasonTier);
            SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_1.Add(key:  "Current Tier", value:  val_4.tier);
            SLC.Social.Leagues.LeaguesDataController val_5 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.Add(key:  "Multiplier Level", value:  val_5.LastSeasonMultiplier);
            SLC.Social.Leagues.LeaguesDataController val_6 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.Add(key:  "Club Promoted", value:  val_6.SeasonPromotion);
            SLC.Social.Leagues.LeaguesDataController val_7 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.Add(key:  "Club Demoted", value:  val_7.SeasonDemotion);
            SLC.Social.Leagues.LeaguesDataController val_8 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.Add(key:  "Amount Earned", value:  val_8.SeasonRewardAmount);
            SLC.Social.Leagues.LeaguesDataController val_9 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.Add(key:  "Rank", value:  val_9.LastSeasonRank);
            SLC.Social.Profile val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_1.Add(key:  "Member Rank", value:  val_11.LastSeasonRankInClub);
            SLC.Social.Profile val_13 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_1.Add(key:  "Player League Points", value:  val_13.LastSeasonLeaguePoints);
            val_14 = null;
            val_14 = null;
            App.trackerManager.track(eventName:  "Leagues Season Rollover", data:  val_1);
        }
        public static void TrackGuildJoined(bool createdGuild)
        {
            string val_9;
            var val_10;
            var val_11;
            var val_12;
            SLC.Social.Leagues.LeaguesTracker.FlushDailyData();
            SLC.Social.Profile val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    val_5.Add(key:  "Club Name", value:  val_2.Name);
                val_5.Add(key:  "Club ID", value:  val_2.ServerId);
                val_5.Add(key:  "Club Level", value:  val_2.guildLevel);
                val_5.Add(key:  "Club Requirement", value:  val_2.requiredVIPLevel);
                val_5.Add(key:  "League Tier", value:  val_2.tier);
                val_9 = "Num Members";
                val_10 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            }
            else
            {
                    val_5.Add(key:  "Club Name", value:  "Guild Not Yet Known");
                val_5.Add(key:  "Club ID", value:  val_4.GuildServerId);
                val_5.Add(key:  "Club Level", value:  0);
                val_5.Add(key:  "Club Requirement", value:  0);
                val_5.Add(key:  "League Tier", value:  "Guild Not Yet Known");
                val_9 = "Num Members";
                val_10 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            }
            
            val_5.Add(key:  val_9, value:  0);
            object val_8 = ~createdGuild;
            val_8 = val_8 & 1;
            val_5.Add(key:  "Existing Club", value:  val_8);
            val_5.Add(key:  "Leader", value:  val_4.GuildMaster);
            GameBehavior val_6 = App.getBehavior;
            if(((val_6.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    val_11 = null;
                val_11 = null;
                val_5.Add(key:  "Join From Letter Bank", value:  (AmplitudePluginHelper.lastFeatureAccessPoint == 101) ? 1 : 0);
            }
            
            val_12 = null;
            val_12 = null;
            App.trackerManager.track(eventName:  "Leagues Join Club", data:  val_5);
        }
        public static void TrackGuildLeft(int guildId, bool wasKicked)
        {
            string val_9;
            var val_10;
            object val_11;
            var val_12;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if((SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  guildId)) != null)
            {
                    val_3.Add(key:  "Club Name", value:  val_2.Name);
                val_3.Add(key:  "Club ID", value:  val_2.ServerId);
                val_3.Add(key:  "Club Level", value:  val_2.guildLevel);
                val_3.Add(key:  "Num Members", value:  val_2.MemberCount);
                val_9 = "League Tier";
                val_10 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
                val_11 = val_2.tier;
            }
            else
            {
                    val_3.Add(key:  "Club Name", value:  "n/a");
                val_3.Add(key:  "Club ID", value:  guildId);
                val_3.Add(key:  "Club Level", value:  "n/a");
                val_3.Add(key:  "Num Members", value:  "n/a");
                val_9 = "League Tier";
                val_11 = "n/a";
                val_10 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            }
            
            val_3.Add(key:  val_9, value:  val_11);
            val_3.Add(key:  "Was Kicked", value:  wasKicked);
            if(wasKicked == true)
            {
                goto label_8;
            }
            
            SLC.Social.Profile val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(val_6.isMemberActive == true)
            {
                goto label_13;
            }
            
            label_8:
            SLC.Social.Profile val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            bool val_9 = val_8.isMemberActive;
            val_9 = val_9 ^ 1;
            val_3.Add(key:  "Inactive Member", value:  val_9);
            label_13:
            val_12 = null;
            val_12 = null;
            App.trackerManager.track(eventName:  "Leagues Leave Club", data:  val_3);
        }
        public static void InjectLeaguesPlayerGlobals(ref System.Collections.Generic.Dictionary<string, object> globals)
        {
            object val_53;
            bool val_54;
            bool val_55;
            string val_56;
            int val_57;
            int val_58;
            object val_60;
            val_53 = 1152921504765632512;
            if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == 0)
            {
                    return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO == 0)
            {
                    return;
            }
            
            globals.Add(key:  "League Member", value:  (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != 0) ? 1 : 0);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Profile val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
                val_54 = val_11.GuildMaster;
            }
            else
            {
                    val_54 = false;
            }
            
            globals.Add(key:  "Leagues Leader", value:  val_54);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Profile val_15 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
                val_55 = val_15.Officer;
            }
            else
            {
                    val_55 = false;
            }
            
            globals.Add(key:  "Leagues Co-Leader", value:  val_55);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_36;
            }
            
            SLC.Social.Leagues.Guild val_19 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_56 = val_19.Name;
            if(globals != null)
            {
                goto label_41;
            }
            
            label_36:
            val_56 = "";
            label_41:
            globals.Add(key:  "Club Name", value:  val_56);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_23 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_57 = val_23.guildLevel;
            }
            else
            {
                    val_57 = 0;
            }
            
            globals.Add(key:  "Club Level", value:  val_57);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_27 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_58 = val_27.ServerId;
            }
            else
            {
                    val_58 = 0;
            }
            
            globals.Add(key:  "Club ID", value:  val_58);
            SLC.Social.Profile val_29 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            SLC.Social.Profile val_31 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            decimal val_32 = System.Decimal.op_Implicit(value:  val_31.LifetimeLeaguePoints);
            decimal val_33 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_29.leaguePoints, hi = val_29.leaguePoints, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_32.flags, hi = val_32.hi, lo = val_32.lo, mid = val_32.mid});
            globals.Add(key:  "League Points", value:  val_33);
            SLC.Social.Profile val_35 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            globals.Add(key:  "Golden Currency", value:  val_35.goldenCurrency);
            Player val_36 = App.Player;
            globals.Add(key:  "Golden Currency Extra Words", value:  val_36.properties.LifetimeApplesEarnedFromExtraWords);
            AggregateEventCalculator val_37 = new AggregateEventCalculator(name:  "my_credit_ctrb_lifetime");
            globals.Add(key:  "League Contributions", value:  (AggregateEventCalculator)[1152921519683748144].aggregate);
            AggregateEventCalculator val_38 = new AggregateEventCalculator(name:  "Total Club Wall Posts Made");
            globals.Add(key:  "Club Chats Sent", value:  (AggregateEventCalculator)[1152921519683756336].aggregate);
            SLC.Social.Profile val_40 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            bool val_53 = val_40.isMemberActive;
            val_53 = val_53 ^ 1;
            globals.Add(key:  "League Inactive Member", value:  val_53);
            Player val_41 = App.Player;
            globals.Add(key:  "Lifetime Profile Avatar Changes", value:  val_41.properties.LifetimeProfileAvatarChanges);
            Player val_42 = App.Player;
            globals.Add(key:  "Lifetime Profile Name Changes", value:  val_42.properties.LifetimeProfileNameChanges);
            val_60 = "None";
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_95;
            }
            
            SLC.Social.Leagues.Guild val_46 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_53 = val_60;
            if(val_46.tier != 1)
            {
                    SLC.Social.Leagues.Guild val_48 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_53 = val_48.tier.ToString();
            }
            
            SLC.Social.Leagues.LeaguesDataController val_50 = SLC.Social.Leagues.LeaguesManager.DAO;
            if(val_50.LastSeasonTier == 1)
            {
                goto label_114;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_51 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_60 = val_51.LastSeasonTier.ToString();
            goto label_114;
            label_95:
            val_53 = val_60;
            label_114:
            globals.Add(key:  "Leagues Tier Current", value:  val_53);
            globals.Add(key:  "Leagues Tier Previous", value:  val_60);
        }
        public static System.Collections.Generic.Queue<string> get_DebugLogicLogs()
        {
            null = null;
            return (System.Collections.Generic.Queue<System.String>)SLC.Social.Leagues.LeaguesTracker._DebugLogicLogs;
        }
        private static void AddDebugLogicLog(string log)
        {
            var val_4;
            if(CompanyDevices.Instance.CompanyDevice() == false)
            {
                    return;
            }
            
            val_4 = null;
            val_4 = null;
            SLC.Social.Leagues.LeaguesTracker._DebugLogicLogs.Enqueue(item:  log);
            if((SLC.Social.Leagues.LeaguesTracker._DebugLogicLogs + 32) < 51)
            {
                    return;
            }
            
            string val_3 = SLC.Social.Leagues.LeaguesTracker._DebugLogicLogs.Dequeue();
        }
        public LeaguesTracker()
        {
        
        }
        private static LeaguesTracker()
        {
            SLC.Social.Leagues.LeaguesTracker.coinsColor = "D3FB57";
            SLC.Social.Leagues.LeaguesTracker.pointsColor = "24DDEA";
            SLC.Social.Leagues.LeaguesTracker._DebugLogicLogs = new System.Collections.Generic.Queue<System.String>();
        }
    
    }

}
