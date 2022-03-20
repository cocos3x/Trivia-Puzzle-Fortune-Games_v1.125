using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesManager : MonoSingleton<SLC.Social.Leagues.LeaguesManager>
    {
        // Fields
        private bool _InitialResponseSuccess;
        private bool _IsInSeasonRollover;
        public SLC.Social.AvatarConfig guildAvatarHandler;
        public SLC.Social.AvatarConfig memberAvatarHandler;
        private UnityEngine.Coroutine initialResponseCoroutine;
        private bool onInitialRequest;
        public static System.Action<System.Decimal> OnContributeLeaguePointsFromWinningsCallback;
        private static int cachedPoints;
        private const string PP_CachedPoints = "PP_iuon213-xzc";
        private static System.DateTime lastContributed;
        private static System.DateTime seasonEnd;
        public static float RefreshRequestInterval;
        public static float SlowRefreshRequestInterval;
        private static System.Collections.Generic.List<int> clubCountByTier;
        private int guildIdToJoin;
        private SLC.Social.Leagues.LeaguesServerController serverController;
        private SLC.Social.Leagues.LeaguesDataController dataController;
        private SLC.Social.Leagues.LeaguesChatController chatController;
        private SLC.Social.Leagues.LeaguesNotifyController notifyController;
        private bool justPurchasedProMembership;
        private float nextRefresh;
        private float nextSlowRefresh;
        
        // Properties
        public static SLC.Social.Leagues.LeaguesDataController DAO { get; }
        public static SLC.Social.Leagues.LeaguesServerController API { get; }
        public static SLC.Social.Leagues.LeaguesChatController CHAT_API { get; }
        public static SLC.Social.Leagues.LeaguesNotifyController NOTIFY_API { get; }
        public bool InitialResponseSuccess { get; }
        public bool IsInSeasonRollover { get; set; }
        
        // Methods
        public static SLC.Social.Leagues.LeaguesDataController get_DAO()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            return (SLC.Social.Leagues.LeaguesDataController)val_1.dataController;
        }
        public static SLC.Social.Leagues.LeaguesServerController get_API()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            return (SLC.Social.Leagues.LeaguesServerController)val_1.serverController;
        }
        public static SLC.Social.Leagues.LeaguesChatController get_CHAT_API()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            return (SLC.Social.Leagues.LeaguesChatController)val_1.chatController;
        }
        public static SLC.Social.Leagues.LeaguesNotifyController get_NOTIFY_API()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            return (SLC.Social.Leagues.LeaguesNotifyController)val_1.notifyController;
        }
        public bool get_InitialResponseSuccess()
        {
            return (bool)this._InitialResponseSuccess;
        }
        public bool get_IsInSeasonRollover()
        {
            return (bool)this._IsInSeasonRollover;
        }
        public void set_IsInSeasonRollover(bool value)
        {
            this._IsInSeasonRollover = value;
        }
        private void RequestInitialDataCallback(System.Collections.Generic.Dictionary<string, object> response)
        {
            this.onInitialRequest = false;
            if(this.initialResponseCoroutine != null)
            {
                    return;
            }
            
            this.initialResponseCoroutine = this.StartCoroutine(routine:  this.InitialLeaguesDataRequest_coroutine(response:  response));
        }
        private System.Collections.IEnumerator InitialLeaguesDataRequest_coroutine(System.Collections.Generic.Dictionary<string, object> response)
        {
            .response = response;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new LeaguesManager.<InitialLeaguesDataRequest_coroutine>d__19(<>1__state:  0);
        }
        public void RequestInitialData()
        {
            Player val_1 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_1.id)) == true)
            {
                    return;
            }
            
            Player val_3 = App.Player;
            if((val_3.id.Equals(value:  " ")) == true)
            {
                    return;
            }
            
            if(this.initialResponseCoroutine != null)
            {
                    return;
            }
            
            this.onInitialRequest = true;
            this.serverController.InitialRequest(responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesManager::RequestInitialDataCallback(System.Collections.Generic.Dictionary<string, object> response)));
        }
        public void HandleError(string apiCall, System.Collections.Generic.Dictionary<string, object> responseObject)
        {
            string val_22;
            var val_23;
            string val_24;
            object val_25;
            val_23 = responseObject;
            if(val_23 == null)
            {
                goto label_1;
            }
            
            val_22 = "";
            if((val_23.ContainsKey(key:  "errors")) == false)
            {
                    return;
            }
            
            object val_2 = val_23.Item["errors"];
            if(null == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((System.String.op_Equality(a:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, b:  "Forbidden")) != false)
            {
                    SLC.Social.Leagues.LeaguesManager.DAO.UpdateEligibleGuildsToJoin();
                return;
            }
            
            if((System.String.op_Equality(a:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, b:  "Private club")) != true)
            {
                    if((System.String.op_Equality(a:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, b:  "Vip level required")) == false)
            {
                goto label_14;
            }
            
            }
            
            val_24 = "guild";
            if((val_23.ContainsKey(key:  val_24)) == false)
            {
                goto label_27;
            }
            
            int val_9 = 0;
            bool val_10 = System.Int32.TryParse(s:  val_23.Item["guild"], result: out  val_9);
            if(val_9 == 1)
            {
                goto label_27;
            }
            
            val_24 = val_9;
            SLC.Social.Leagues.Guild val_12 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuildAndMembers(guildId:  0);
            goto label_27;
            label_14:
            if((System.String.op_Equality(a:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, b:  "Nothing to collect")) != false)
            {
                    NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "NothingToCollectError");
                return;
            }
            
            val_24 = "WebException";
            if((System.String.op_Equality(a:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, b:  val_24)) == false)
            {
                goto label_27;
            }
            
            label_1:
            SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  9);
            return;
            label_27:
            if("Vip level required" >= 1)
            {
                    do
            {
                if("Vip level required" <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_23 = 0 + 1;
                val_22 = val_22 + public FTUXFeatureWindow MetaGameBehavior::ShowUGUIMonolith<FTUXFeatureWindow>(bool showNext)(public FTUXFeatureWindow MetaGameBehavior::ShowUGUIMonolith<FTUXFeatureWindow>(bool showNext)) + "\n";
            }
            while(val_23 < as. 
               
               
              
            
            
            
            );
            
            }
            
            if(CompanyDevices.Instance.CompanyDevice() != false)
            {
                    val_25 = "API Call: "("API Call: ") + apiCall;
            }
            else
            {
                    val_25 = "";
            }
            
            this.DisplayError(message:  System.String.Format(format:  "{0}\n{1}", arg0:  val_22, arg1:  val_25), title:  "ERROR");
        }
        public void DisplayError(string message, string title = "ERROR")
        {
            System.String[] val_13;
            UnityEngine.Object val_14;
            var val_15;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "DisplayLeaguesErrorPopup");
            if(CompanyDevices.Instance.CompanyDevice() != false)
            {
                    UnityEngine.Debug.LogError(message:  "LEAGUES ERROR: "("LEAGUES ERROR: ") + title + " - "(" - ") + message);
            }
            
            val_13 = 1152921516201187312;
            val_14 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance;
            if(val_14 == 0)
            {
                    return;
            }
            
            val_14 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesError_Window>(showNext:  false);
            bool[] val_9 = new bool[2];
            val_9[0] = true;
            string[] val_10 = new string[2];
            val_13 = val_10;
            val_13[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_13[1] = Localization.Localize(key:  "close_upper", defaultValue:  "CLOSE", useSingularKey:  false);
            val_15 = null;
            val_15 = null;
            val_14.SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public static bool IsAvailable()
        {
            UnityEngine.Object val_7 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            if(val_7 == 0)
            {
                    return false;
            }
            
            SLC.Social.Leagues.LeaguesManager val_3 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            val_7 = val_3.dataController;
            if(val_7 == 0)
            {
                    return false;
            }
            
            GameEcon val_6 = App.getGameEcon;
            return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_6.leaguesUnlockLevel);
        }
        public static bool IsAvailableAndInGuild()
        {
            var val_5;
            var val_6;
            val_5 = null;
            if(SLC.Social.Leagues.LeaguesManager.IsAvailable() != false)
            {
                    var val_4 = (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != 0) ? 1 : 0;
                return (bool)val_6;
            }
            
            val_6 = 0;
            return (bool)val_6;
        }
        public static void OnAppleAwarded(int appleAwarded)
        {
            null = null;
            string val_1 = App.game.ToString();
            SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  appleAwarded, machineName:  public System.String System.Enum::ToString(), applyLTO:  false, bypassCaching:  false);
        }
        private static void LoadCachedPoints()
        {
            var val_2 = null;
            SLC.Social.Leagues.LeaguesManager.cachedPoints = UnityEngine.PlayerPrefs.GetInt(key:  "PP_iuon213-xzc", defaultValue:  0);
        }
        private static void SaveCachedPoints()
        {
            null = null;
            UnityEngine.PlayerPrefs.SetInt(key:  "PP_iuon213-xzc", value:  SLC.Social.Leagues.LeaguesManager.cachedPoints);
            bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public static void RemoveCachedGC()
        {
            null = null;
            SLC.Social.Leagues.LeaguesManager.cachedPoints = 0;
            SLC.Social.Leagues.LeaguesManager.SaveCachedPoints();
        }
        private static void FlushGCContributions()
        {
            SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  0, machineName:  null, applyLTO:  false, bypassCaching:  true);
        }
        public static void ContributePointsFromWinnings(int goldenCurrencyWinnings, string machineName, bool applyLTO = True, bool bypassCaching = False)
        {
            ulong val_25;
            var val_26;
            var val_27;
            var val_28;
            var val_29;
            var val_30;
            var val_31;
            var val_32;
            int val_33;
            var val_34;
            var val_35;
            val_25 = bypassCaching;
            val_26 = null;
            if(SLC.Social.Leagues.LeaguesManager.IsAvailable() == false)
            {
                    return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_7;
            }
            
            if(val_25 == false)
            {
                goto label_8;
            }
            
            goto label_28;
            label_7:
            val_27 = null;
            val_27 = null;
            System.DateTime val_5 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "leagues_last_cont_day"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
            val_28 = 1152921504880381952;
            System.DateTime val_6 = DateTimeCheat.Today;
            if((val_5.dateData.Equals(value:  new System.DateTime() {dateData = val_6.dateData})) != true)
            {
                    SLC.Social.Leagues.LeaguesDataController val_8 = SLC.Social.Leagues.LeaguesManager.DAO;
                val_29 = null;
                val_29 = null;
                val_8.DailyRewardAmount = System.Decimal.MinusOne;
                SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  1);
            }
            
            System.DateTime val_10 = DateTimeCheat.Today;
            UnityEngine.PlayerPrefs.SetString(key:  "leagues_last_cont_day", value:  val_10.dateData.ToString());
            if(val_25 == true)
            {
                goto label_28;
            }
            
            label_8:
            System.DateTime val_12 = System.DateTime.UtcNow;
            val_30 = null;
            val_25 = val_12.dateData;
            val_30 = null;
            System.TimeSpan val_13 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_25}, d2:  new System.DateTime() {dateData = SLC.Social.Leagues.LeaguesManager.lastContributed});
            if(val_13._ticks.TotalSeconds < 0)
            {
                    val_31 = null;
                val_31 = null;
                int val_24 = SLC.Social.Leagues.LeaguesManager.cachedPoints;
                val_24 = goldenCurrencyWinnings + val_24;
                SLC.Social.Leagues.LeaguesManager.cachedPoints = val_24;
                SLC.Social.Leagues.LeaguesManager.SaveCachedPoints();
                return;
            }
            
            label_28:
            val_32 = null;
            val_25 = goldenCurrencyWinnings;
            val_32 = null;
            val_33 = SLC.Social.Leagues.LeaguesManager.cachedPoints + val_25;
            SLC.Social.Leagues.LeaguesManager.cachedPoints = val_33;
            SLC.Social.Leagues.LeaguesManager.SaveCachedPoints();
            if(val_33 < 1)
            {
                    return;
            }
            
            val_28 = 1152921504619999232;
            val_34 = null;
            val_34 = null;
            val_33 = val_33;
            SLCDebug.Log(logMessage:  System.String.Format(format:  "Leagues Contribution: Contributing winnings ({0}) + cachedPoints ({1}), total {2}", arg0:  goldenCurrencyWinnings, arg1:  SLC.Social.Leagues.LeaguesManager.cachedPoints, arg2:  val_33), colorHash:  "#DD7BEE", isError:  false);
            val_25 = SLC.Social.Leagues.LeaguesManager.PP_CachedPoints;
            if(val_25 != null)
            {
                    val_25 = SLC.Social.Leagues.LeaguesManager.PP_CachedPoints;
                decimal val_16 = System.Decimal.op_Implicit(value:  val_33);
                val_25.Invoke(obj:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid});
            }
            
            if(CompanyDevices.Instance.CompanyDevice() != false)
            {
                    val_25 = 1152921504884002816;
                val_35 = null;
                val_35 = null;
                if(Logger.Leagues != false)
            {
                    val_25 = "ContributePointsFromWinnings() winnings: "("ContributePointsFromWinnings() winnings: ") + goldenCurrencyWinnings.ToString(format:  "#,##0")(goldenCurrencyWinnings.ToString(format:  "#,##0")) + ", league points: "(", league points: ") + val_33.ToString();
                UnityEngine.Debug.Log(message:  val_25);
            }
            
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.ContributePoints(points:  val_33);
            System.DateTime val_23 = System.DateTime.UtcNow;
            SLC.Social.Leagues.LeaguesManager.lastContributed = val_23.dateData;
        }
        public void OnGuildStatusChanged(SLC.Social.Leagues.LeaguesManager.GuildStateChange state, string source = "", int leftGuildId = -1, bool forDisplayOnly = False)
        {
            int val_25;
            UnityEngine.Object val_26;
            val_25 = leftGuildId;
            val_26 = state;
            if(val_26 <= 6)
            {
                    var val_25 = 32556364 + (state) << 2;
                val_25 = val_25 + 32556364;
            }
            else
            {
                    if( == true)
            {
                    return;
            }
            
                this.nextRefresh = UnityEngine.Time.time;
            }
        
        }
        public static System.TimeSpan GetSeasonTimeRemaining()
        {
            null = null;
            System.DateTime val_1 = DateTimeCheat.UtcNow;
            return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = SLC.Social.Leagues.LeaguesManager.seasonEnd}, d2:  new System.DateTime() {dateData = val_1.dateData});
        }
        public static int GetClubCountByTier(int tier)
        {
            null = null;
            if((SLC.Social.Leagues.LeaguesManager.clubCountByTier + 24) <= tier)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_1 = SLC.Social.Leagues.LeaguesManager.clubCountByTier + 16;
            val_1 = val_1 + (tier << 2);
            return (int)(SLC.Social.Leagues.LeaguesManager.clubCountByTier + 16 + (tier) << 2) + 32;
        }
        public void OnLeaveGuildClicked(int newGuildIdToJoin, bool inviteRequired = False)
        {
            string val_22;
            string val_23;
            var val_25;
            this.guildIdToJoin = newGuildIdToJoin;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_4;
            }
            
            if(this.guildIdToJoin == 1)
            {
                goto label_5;
            }
            
            if(inviteRequired == false)
            {
                goto label_6;
            }
            
            val_22 = "request_join_club_leave_club";
            val_23 = "If you request to join this club you will leave your current club.";
            goto label_7;
            label_4:
            this.OnLeaveGuildConfirm();
            return;
            label_5:
            GameBehavior val_3 = App.getBehavior;
            string val_8 = System.String.Format(format:  "{0}\n{1}\n{2}", arg0:  Localization.Localize(key:  "letter_bank_loss_leave", defaultValue:  "Are you sure you want to leave this club?", useSingularKey:  false), arg1:  System.String.Format(format:  Localization.Localize(key:  "letter_bank_loss_ln1", defaultValue:  "• Previously earned {0} will not transfer.", useSingularKey:  false), arg0:  val_3.<metaGameBehavior>k__BackingField), arg2:  Localization.Localize(key:  "letter_bank_loss_ln2", defaultValue:  "• You will be ineligible to participate in a Club event if you switch Clubs during an event.", useSingularKey:  false));
            goto label_12;
            label_6:
            val_22 = "join_club_leave_club";
            val_23 = "If you join this club you will leave your current club.";
            label_7:
            label_12:
            bool[] val_13 = new bool[2];
            val_13[0] = true;
            val_13[1] = true;
            string[] val_14 = new string[2];
            val_14[0] = Localization.Localize(key:  "cancel_upper", defaultValue:  "CANCEL", useSingularKey:  false);
            val_14[1] = Localization.Localize(key:  (this.guildIdToJoin != 1) ? "join_club" : "yes_leave_club", defaultValue:  (this.guildIdToJoin != 1) ? "JOIN CLUB" : "YES, LEAVE CLUB", useSingularKey:  false);
            System.Func<System.Boolean>[] val_19 = new System.Func<System.Boolean>[2];
            val_19[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean SLC.Social.Leagues.LeaguesManager::<OnLeaveGuildClicked>b__45_0());
            val_19[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean SLC.Social.Leagues.LeaguesManager::<OnLeaveGuildClicked>b__45_1());
            val_25 = null;
            val_25 = null;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "are_you_sure_upper", defaultValue:  "ARE YOU SURE?", useSingularKey:  false), messageTxt:  Localization.Localize(key:  val_22, defaultValue:  val_23, useSingularKey:  false), shownButtons:  val_13, buttonTexts:  val_14, showClose:  false, buttonCallbacks:  val_19, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public void OnLeaveGuildConfirm()
        {
            if(this.guildIdToJoin == 1)
            {
                goto label_1;
            }
            
            label_15:
            if(((SLC.Social.Leagues.LeaguesManager.DAO.JoinGuild(idToJoin:  this.guildIdToJoin)) == null) || (val_2.InviteRequired == true))
            {
                goto label_11;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.Wait_Window>(showNext:  true).ShowError(message:  Localization.Localize(key:  "joining_club_wait", defaultValue:  "Joining Club.\nPlease Wait...", useSingularKey:  false), title:  "", notificationType:  2);
            goto label_11;
            label_1:
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_15;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.Wait_Window>(showNext:  true).ShowError(message:  Localization.Localize(key:  "leaving_club_wait", defaultValue:  "Leaving your Club.\nPlease Wait...", useSingularKey:  false), title:  "", notificationType:  1);
            SLC.Social.Leagues.LeaguesManager.DAO.RemoveGuildMember(toRemove:  SLC.Social.Leagues.LeaguesManager.DAO.MyProfile);
            label_11:
            this.guildIdToJoin = 0;
        }
        public void OnLeaveGuildCancel()
        {
            this.guildIdToJoin = 0;
        }
        private void InitializeComponents()
        {
            this.serverController = this.gameObject.AddComponent<SLC.Social.Leagues.LeaguesServerController>();
            this.dataController = this.gameObject.AddComponent<SLC.Social.Leagues.LeaguesDataController>();
            this.chatController = this.gameObject.AddComponent<SLC.Social.Leagues.LeaguesChatController>();
            this.notifyController = this.gameObject.AddComponent<SLC.Social.Leagues.LeaguesNotifyController>();
        }
        public override void InitMonoSingleton()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerResponded");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerImportResponded");
            this.InitializeComponents();
            UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
            System.Delegate val_5 = System.Delegate.Combine(a:  GoldenApplesManager.OnAppleAwarded, b:  new System.Action<System.Int32>(object:  0, method:  public static System.Void SLC.Social.Leagues.LeaguesManager::OnAppleAwarded(int appleAwarded)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            GoldenApplesManager.OnAppleAwarded = val_5;
            System.Delegate val_7 = System.Delegate.Combine(a:  TRVStarsManager.OnStarAwarded, b:  new System.Action<System.Int32>(object:  0, method:  public static System.Void SLC.Social.Leagues.LeaguesManager::OnAppleAwarded(int appleAwarded)));
            if(val_7 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            TRVStarsManager.OnStarAwarded = val_7;
            SLC.Social.Leagues.LeaguesManager.LoadCachedPoints();
            return;
            label_10:
        }
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            this.nextRefresh = UnityEngine.Time.time;
            SLC.Social.Leagues.LeaguesManager.FlushGCContributions();
        }
        private void OnServerResponded()
        {
            if(this._InitialResponseSuccess != false)
            {
                    return;
            }
            
            this.RequestInitialData();
        }
        private void OnServerImportResponded()
        {
            UnityEngine.Debug.Log(message:  "LeaguesManager: OnServerImportResponded RequestInitialDataCallback");
            SLC.Social.Leagues.LeaguesManager.DAO.IsMaster = false;
            SLC.Social.Leagues.LeaguesManager.DAO.IsOfficer = false;
            SLC.Social.Leagues.LeaguesDataController val_3 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_3.FirstGuild = false;
            SLC.Social.Leagues.LeaguesDataController val_4 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_4.HasCollectedFirstGuildReward = true;
            SLC.Social.Leagues.LeaguesManager.DAO.Pref_GuildId = 0;
            SLC.Social.Leagues.LeaguesDataController val_6 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_6.MyId = 0;
            App.Player.SynchedGoldenCurrency = false;
            this.serverController.InitialRequest(responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesManager::RequestInitialDataCallback(System.Collections.Generic.Dictionary<string, object> response)));
        }
        public bool WaitFullDataUpdate()
        {
            if(this._InitialResponseSuccess == false)
            {
                    return true;
            }
            
            return (bool)(UnityEngine.Time.time > this.nextSlowRefresh) ? 1 : 0;
        }
        public void ResetRefreshTime()
        {
            this.nextRefresh = UnityEngine.Time.time;
        }
        private void Update()
        {
            this.Refresh();
        }
        private void Refresh()
        {
            var val_11;
            var val_12;
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField) == 3)
            {
                    return;
            }
            
            if(this.onInitialRequest == true)
            {
                    return;
            }
            
            if(UnityEngine.Time.time > this.nextSlowRefresh)
            {
                    val_11 = null;
                val_11 = null;
                float val_11 = SLC.Social.Leagues.LeaguesManager.SlowRefreshRequestInterval;
                val_11 = UnityEngine.Time.time + val_11;
                this.nextSlowRefresh = val_11;
                if(this._InitialResponseSuccess != false)
            {
                    FullDataUpdate();
            }
            else
            {
                    this.RequestInitialData();
            }
            
            }
            
            if(UnityEngine.Time.time <= this.nextRefresh)
            {
                    return;
            }
            
            val_12 = null;
            val_12 = null;
            float val_12 = SLC.Social.Leagues.LeaguesManager.RefreshRequestInterval;
            val_12 = UnityEngine.Time.time + val_12;
            this.nextRefresh = val_12;
            if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == 0)
            {
                    return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.GetGuildChat();
        }
        private void FullDataUpdate()
        {
            SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  false);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_5 = SLC.Social.Leagues.LeaguesManager.DAO.GetMembersAndUpdateMyGuild();
                SLC.Social.Leagues.Guilds val_7 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuildsInMyTier();
                return;
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.UpdateEligibleGuildsToJoin();
        }
        private void Notification_OnExtraGoldenCurrency(Notification notif)
        {
            SLC.Social.Leagues.LeaguesManager.OnAppleAwarded(appleAwarded:  75878400);
        }
        public LeaguesManager()
        {
            this.guildIdToJoin = 0;
            this.nextRefresh = 5;
        }
        private static LeaguesManager()
        {
            SLC.Social.Leagues.LeaguesManager.cachedPoints = 0;
            System.DateTime val_1 = System.DateTime.UtcNow;
            System.DateTime val_2 = val_1.dateData.AddSeconds(value:  -30);
            SLC.Social.Leagues.LeaguesManager.lastContributed = val_2.dateData;
            SLC.Social.Leagues.LeaguesManager.RefreshRequestInterval = 30f;
            SLC.Social.Leagues.LeaguesManager.SlowRefreshRequestInterval = 50f;
            System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
            val_3.Add(item:  80000);
            val_3.Add(item:  112);
            val_3.Add(item:  32);
            val_3.Add(item:  60);
            val_3.Add(item:  30);
            val_3.Add(item:  15);
            SLC.Social.Leagues.LeaguesManager.clubCountByTier = val_3;
        }
        private bool <OnLeaveGuildClicked>b__45_0()
        {
            this.guildIdToJoin = 0;
            return true;
        }
        private bool <OnLeaveGuildClicked>b__45_1()
        {
            this.OnLeaveGuildConfirm();
            return true;
        }
    
    }

}
