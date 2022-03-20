using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIManager : MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>
    {
        // Fields
        public static int openDirectlyToContainer;
        public static System.Action DoOnStart;
        public const string ON_AVATAR_CHANGED = "OnAvatarChanged";
        private UnityEngine.GameObject noGuildContainer;
        private UnityEngine.UI.Toggle defaultNoGuildContainerToggle;
        private UnityEngine.GameObject hasGuildContainer;
        private UnityEngine.UI.Toggle defaultHasGuildContainerToggle;
        private UnityEngine.GameObject tierStandingsContainer;
        private TweenCoinsText coinsText;
        private UGUIMonolithTutorialHighlights tutorialHighlights;
        private UnityEngine.GameObject loadingPopup;
        
        // Properties
        public static SLC.Social.AvatarConfig guildAvatarHandler { get; }
        public static SLC.Social.AvatarConfig memberAvatarHandler { get; }
        public UGUIMonolithTutorialHighlights GetMyClubTutorialHighlights { get; }
        
        // Methods
        public static SLC.Social.AvatarConfig get_guildAvatarHandler()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            return (SLC.Social.AvatarConfig)val_1.guildAvatarHandler;
        }
        public static SLC.Social.AvatarConfig get_memberAvatarHandler()
        {
            SLC.Social.Leagues.LeaguesManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            return (SLC.Social.AvatarConfig)val_1.memberAvatarHandler;
        }
        public UGUIMonolithTutorialHighlights get_GetMyClubTutorialHighlights()
        {
            return (UGUIMonolithTutorialHighlights)this.tutorialHighlights;
        }
        private void Start()
        {
            var val_23;
            var val_24;
            var val_25;
            MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.DisableSnapshottedCameras();
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  9.ToString());
            if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == 0)
            {
                goto label_12;
            }
            
            SLC.Social.Leagues.LeaguesManager val_6 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            if(val_6._InitialResponseSuccess == true)
            {
                goto label_16;
            }
            
            label_12:
            UnityEngine.Debug.LogError(message:  "ERROR: Shouldn\'t be in Leagues Scene w/o initial response success!");
            label_16:
            val_23 = null;
            val_23 = null;
            if(SLC.Social.Leagues.LeaguesUIManager.ON_AVATAR_CHANGED != 1)
            {
                    this.hasGuildContainer.SetActive(value:  (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != 0) ? 1 : 0);
                this.noGuildContainer.SetActive(value:  (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == 0) ? 1 : 0);
                val_24 = 0;
            }
            else
            {
                    this.hasGuildContainer.SetActive(value:  false);
                this.noGuildContainer.SetActive(value:  (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == 0) ? 1 : 0);
            }
            
            this.tierStandingsContainer.SetActive(value:  (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != 0) ? 1 : 0);
            val_25 = null;
            val_25 = null;
            SLC.Social.Leagues.LeaguesUIManager.ON_AVATAR_CHANGED = 0;
            if(SLC.Social.Leagues.LeaguesUIManager.DoOnStart != null)
            {
                    SLC.Social.Leagues.LeaguesUIManager.DoOnStart.Invoke();
                SLC.Social.Leagues.LeaguesUIManager.DoOnStart = 0;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.ResetRefreshTime();
            WGAudioController val_20 = MonoSingleton<WGAudioController>.Instance;
            if(val_20.music.currentMusicType == 0)
            {
                    return;
            }
            
            GameBehavior val_21 = App.getBehavior;
            if(((val_21.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                    return;
            }
            
            WGAudioController val_22 = MonoSingleton<WGAudioController>.Instance;
            val_22.music.PlayRandomMusicTrack(type:  0);
        }
        private void OnEnable()
        {
            DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIManager::HandleBackButtonClose()));
        }
        private void HandleBackButtonClose()
        {
            SLC.Social.Leagues.LeaguesUIManager.LeaveLeaguesScene();
        }
        private void OnError_Null_Response()
        {
            var val_11;
            var val_12;
            var val_13;
            int val_14;
            var val_15;
            System.Func<System.Boolean> val_17;
            var val_18;
            val_11 = 1152921504884269056;
            val_12 = null;
            val_12 = null;
            if(App.networkManager != null)
            {
                    val_13 = null;
                val_13 = null;
                if(App.networkManager.Reachable() == true)
            {
                    return;
            }
            
            }
            
            val_11 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true);
            bool[] val_6 = new bool[2];
            val_6[0] = true;
            string[] val_7 = new string[2];
            val_14 = val_7.Length;
            val_7[0] = Localization.Localize(key:  "return_home_upper", defaultValue:  "RETURN HOME", useSingularKey:  false);
            val_14 = val_7.Length;
            val_7[1] = "";
            System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
            val_15 = null;
            val_15 = null;
            val_17 = LeaguesUIManager.<>c.<>9__20_0;
            if(val_17 == null)
            {
                    System.Func<System.Boolean> val_10 = null;
                val_17 = val_10;
                val_10 = new System.Func<System.Boolean>(object:  LeaguesUIManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LeaguesUIManager.<>c::<OnError_Null_Response>b__20_0());
                LeaguesUIManager.<>c.<>9__20_0 = val_17;
            }
            
            val_9[0] = val_17;
            val_18 = null;
            val_18 = null;
            val_11.SetupMessage(titleTxt:  Localization.Localize(key:  "connection_lost_upper", defaultValue:  "CONNECTION LOST", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "league_requires_connection", defaultValue:  "Leagues Requires a Network Connection", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public void AnimateCreditGain(decimal creditsToGain, float seconds)
        {
            this.coinsText.gameObject.SetActive(value:  true);
            Player val_2 = App.Player;
            decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = 41975808}, d2:  new System.Decimal() {flags = creditsToGain.flags, hi = creditsToGain.hi, lo = creditsToGain.lo, mid = creditsToGain.mid});
            Player val_4 = App.Player;
            this.coinsText.Tween(startValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, endValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, seconds:  seconds);
        }
        public void OnSeasonRollover()
        {
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.needToShowSeasonResultsThisSession = false;
            SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_2.statusChangeToShowThisSession = 7;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.SeasonResult_Window>(showNext:  false).Show();
        }
        public void OnRemovedFromGuild()
        {
            var val_10;
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.statusChangeToShowThisSession = 7;
            bool[] val_6 = new bool[2];
            val_6[0] = true;
            string[] val_7 = new string[2];
            val_7[0] = Localization.Localize(key:  "join_another_club", defaultValue:  "JOIN ANOTHER CLUB", useSingularKey:  false);
            val_7[1] = Localization.Localize(key:  "close_upper", defaultValue:  "CLOSE", useSingularKey:  false);
            val_10 = null;
            val_10 = null;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "club_notice_upper", defaultValue:  "CLUB NOTICE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "removed_from_club", defaultValue:  "You\'ve been removed from your club.", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
            this.tierStandingsContainer.SetActive(value:  false);
            this.hasGuildContainer.SetActive(value:  false);
            this.noGuildContainer.SetActive(value:  true);
            this.defaultNoGuildContainerToggle.isOn = true;
        }
        public void OnBecameMaster()
        {
            var val_10;
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.statusChangeToShowThisSession = 7;
            bool[] val_6 = new bool[2];
            val_6[0] = true;
            string[] val_7 = new string[2];
            val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_7[1] = Localization.Localize(key:  "close_upper", defaultValue:  "CLOSE", useSingularKey:  false);
            val_10 = null;
            val_10 = null;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "congrats_upper", defaultValue:  "CONGRATULATIONS!", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "league_now_leader", defaultValue:  "You are now the LEADER of your club!\nCongratulations!", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public void OnBecameOfficer()
        {
            var val_10;
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.statusChangeToShowThisSession = 7;
            bool[] val_6 = new bool[2];
            val_6[0] = true;
            string[] val_7 = new string[2];
            val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_7[1] = Localization.Localize(key:  "close_upper", defaultValue:  "CLOSE", useSingularKey:  false);
            val_10 = null;
            val_10 = null;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "congrats_upper", defaultValue:  "CONGRATULATIONS!", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "league_now_co_leader", defaultValue:  "You are now a CO-LEADER of your club!\nCongratulations!", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public void OnGotGuildInvite()
        {
            var val_8;
            bool[] val_4 = new bool[2];
            val_4[0] = true;
            string[] val_5 = new string[2];
            val_5[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_5[1] = Localization.Localize(key:  "close_upper", defaultValue:  "CLOSE", useSingularKey:  false);
            val_8 = null;
            val_8 = null;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  "", messageTxt:  Localization.Localize(key:  "join_request_success", defaultValue:  "Join request successful!", useSingularKey:  false), shownButtons:  val_4, buttonTexts:  val_5, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public void OnGuildJoinSuccess(bool created)
        {
            this.noGuildContainer.SetActive(value:  false);
            this.tierStandingsContainer.SetActive(value:  false);
            this.hasGuildContainer.SetActive(value:  true);
            this.defaultHasGuildContainerToggle.isOn = true;
            if(created != false)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesWindowManager val_2 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesWelcome_Window>(showNext:  false);
        }
        public void ShowGuildInfoPopup(int guildId)
        {
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                if(val_4.ServerId == guildId)
            {
                    this.ShowHasGuildContainer();
                return;
            }
            
            }
            
            if((guildId == 1) && (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null))
            {
                    this.ShowNoGuildContainer();
                return;
            }
            
            if(guildId == 1)
            {
                    return;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.ClubInfo_Window>(showNext:  false).ShowGuild(guildId:  guildId);
        }
        public void ShowHasGuildContainer()
        {
            this.noGuildContainer.SetActive(value:  false);
            this.tierStandingsContainer.SetActive(value:  false);
            this.hasGuildContainer.SetActive(value:  true);
        }
        public void ShowNoGuildContainer()
        {
            this.tierStandingsContainer.SetActive(value:  false);
            this.hasGuildContainer.SetActive(value:  false);
            this.noGuildContainer.SetActive(value:  true);
        }
        public void ShowTierStandingsContainer()
        {
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                    return;
            }
            
            this.noGuildContainer.SetActive(value:  false);
            this.hasGuildContainer.SetActive(value:  false);
            this.tierStandingsContainer.SetActive(value:  true);
        }
        public void OnShowContributePopup()
        {
            SLC.Social.Leagues.LeaguesWindowManager val_2 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.ClubLevelContribution_Window>(showNext:  false);
        }
        public void ToggleLoadingPopup(bool state)
        {
            if(this.loadingPopup != null)
            {
                    this.loadingPopup.SetActive(value:  state);
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void ShowPlayerProfile(int serverId, UnityEngine.GameObject gridItem)
        {
            var val_36;
            UnityEngine.Object val_37;
            int val_38;
            var val_39;
            var val_40;
            var val_41;
            val_37 = gridItem;
            val_38 = serverId;
            val_39 = 1152921505022660608;
            SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(val_2.ServerId != val_38)
            {
                goto label_5;
            }
            
            GameBehavior val_3 = App.getBehavior;
            val_38 = ???;
            val_37 = ???;
            val_39 = ???;
            val_36 = ???;
            goto mem[(1152921504946249728 + (public EditProfileFlyout MetaGameBehavior::ShowUGUIFlyOut<EditProfileFlyout>().__il2cppRuntimeField_48) << 4) + 312];
            label_5:
            if(val_37 == 0)
            {
                    return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.IsOfficer != true)
            {
                    if(SLC.Social.Leagues.LeaguesManager.DAO.IsMaster == false)
            {
                    return;
            }
            
            }
            
            val_36 = SLC.Social.Leagues.LeaguesManager.DAO.IsMaster;
            if(SLC.Social.Leagues.LeaguesManager.DAO.IsOfficer == false)
            {
                goto label_26;
            }
            
            if(val_11.Officer == true)
            {
                goto label_29;
            }
            
            val_36 = val_36 | ((val_11.GuildMaster == false) ? 1 : 0);
            goto label_29;
            label_26:
            label_29:
            SLC.Social.Leagues.Guild val_18 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            var val_19 = (val_11.GuildServerId != val_18.ServerId) ? 1 : 0;
            val_19 = val_19 | (~val_36);
            if(val_19 == true)
            {
                    return;
            }
            
            GameBehavior val_20 = App.getBehavior;
            if(SLC.Social.Leagues.LeaguesManager.DAO.IsMaster != false)
            {
                    val_40 = val_11.Officer ^ 1;
            }
            else
            {
                    val_40 = 0;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.IsMaster == false)
            {
                goto label_48;
            }
            
            var val_33 = (val_11.Officer == true) ? 1 : 0;
            if((val_20.<metaGameBehavior>k__BackingField) != null)
            {
                goto label_49;
            }
            
            label_48:
            val_41 = 0;
            label_49:
            val_20.<metaGameBehavior>k__BackingField.SetupControls(gridItem:  val_37, profile:  SLC.Social.Leagues.LeaguesManager.DAO.GetGuildMember(memberId:  val_38), promoteButton:  (val_40 != 0) ? 1 : 0, demoteButton:  false);
        }
        public void ShowConnectionRequired()
        {
            int val_8;
            var val_9;
            bool[] val_5 = new bool[2];
            val_5[0] = true;
            string[] val_6 = new string[2];
            val_8 = val_6.Length;
            val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_8 = val_6.Length;
            val_6[1] = "NULL";
            val_9 = null;
            val_9 = null;
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesError_Window>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        public static void LeaveLeaguesScene()
        {
            string val_12;
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField) == 2)
            {
                    WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
                val_2.music.PlayRandomMusicTrack(type:  1);
            }
            
            GameBehavior val_3 = App.getBehavior;
            if((System.String.IsNullOrEmpty(value:  App.ThemesHandler.CurrentThemeName)) != false)
            {
                    val_12 = "";
            }
            else
            {
                    val_12 = "_" + App.ThemesHandler.CurrentThemeName;
            }
            
            UnityEngine.AsyncOperation val_11 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_3.<metaGameBehavior>k__BackingField(val_3.<metaGameBehavior>k__BackingField) + val_12);
        }
        private void OnDestroy()
        {
            MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.RestoreCameraStateSnapshot();
            DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIManager::HandleBackButtonClose()));
        }
        public LeaguesUIManager()
        {
        
        }
        private static LeaguesUIManager()
        {
            SLC.Social.Leagues.LeaguesUIManager.ON_AVATAR_CHANGED = 0;
            SLC.Social.Leagues.LeaguesUIManager.DoOnStart = 0;
        }
    
    }

}
