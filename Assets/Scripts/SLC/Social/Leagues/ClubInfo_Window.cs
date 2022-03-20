using UnityEngine;

namespace SLC.Social.Leagues
{
    public class ClubInfo_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text leaguePoints;
        private UnityEngine.UI.Text activeMembers;
        private UnityEngine.UI.Text vipRequirement;
        private UnityEngine.UI.Image requirementMetByYou;
        private UGUINetworkedButton joinButton;
        private UnityEngine.UI.Text joinButtonText;
        private UnityEngine.GameObject errorTooltip;
        private UnityEngine.UI.Text errorTooltipMessage;
        private UnityEngine.UI.Image errorTooltipCurrencyImage;
        private SLC.Social.Leagues.LeaguesUIMembersView membersView;
        private SLC.Social.Leagues.LeaguesUIGuildDisplay infoDisplay;
        private int currentGuildId;
        private int guildIdToDisplay;
        private System.Action onDisable_callback;
        private float nextSlowRefresh;
        
        // Properties
        private SLC.Social.Leagues.Guild CurrentGuild { get; }
        public System.Action OnDisable_callback { set; }
        
        // Methods
        private SLC.Social.Leagues.Guild get_CurrentGuild()
        {
            return SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  this.currentGuildId);
        }
        public void set_OnDisable_callback(System.Action value)
        {
            this.onDisable_callback = value;
        }
        private void Start()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  7.ToString());
            this.joinButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.ClubInfo_Window::OnJoinGuildClick(bool result));
        }
        private void OnEnable()
        {
            this.RequestGuildUpdate();
        }
        private void Update()
        {
            if(UnityEngine.Time.time <= this.nextSlowRefresh)
            {
                    return;
            }
            
            this.RequestGuildUpdate();
        }
        private void RequestGuildUpdate()
        {
            var val_4;
            if(this.guildIdToDisplay == 1)
            {
                    return;
            }
            
            val_4 = null;
            val_4 = null;
            float val_4 = SLC.Social.Leagues.LeaguesManager.SlowRefreshRequestInterval;
            val_4 = UnityEngine.Time.time + val_4;
            this.nextSlowRefresh = val_4;
            SLC.Social.Leagues.Guild val_3 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuildAndMembers(guildId:  this.guildIdToDisplay);
        }
        public void OnMyGuildUpdate()
        {
            this.RefreshInfoAndMembers();
        }
        public void OnGuildListUpdate()
        {
            this.RefreshInfoAndMembers();
        }
        public void ShowGuild(int guildId)
        {
            this.guildIdToDisplay = guildId;
            this.RequestGuildUpdate();
            this.RefreshInfoAndMembers();
        }
        private void RefreshInfoAndMembers()
        {
            this.Refresh();
            this.infoDisplay.Refresh(guildId:  this.guildIdToDisplay);
            this.membersView.Refresh(guildId:  this.guildIdToDisplay);
        }
        private void Refresh()
        {
            UnityEngine.UI.Text val_33;
            int val_34;
            var val_35;
            val_33 = this;
            this.currentGuildId = this.guildIdToDisplay;
            if(this.CurrentGuild == null)
            {
                    return;
            }
            
            decimal val_3 = this.CurrentGuild.LeaguePointsFinal;
            GameEcon val_4 = App.getGameEcon;
            string val_5 = val_3.flags.ToString(format:  val_4.numberFormatInt);
            SLC.Social.Leagues.Guild val_6 = this.CurrentGuild;
            SLC.Social.Leagues.Guild val_7 = this.CurrentGuild;
            string val_9 = System.String.Format(format:  "{0}/{1} {2}", arg0:  val_6.MemberCount, arg1:  val_7.maximumMembers, arg2:  Localization.Localize(key:  "members_upper", defaultValue:  "MEMBERS", useSingularKey:  false));
            GameBehavior val_10 = App.getBehavior;
            SLC.Social.Leagues.Guild val_11 = this.CurrentGuild;
            this.joinButton.gameObject.SetActive(value:  (val_10.<metaGameBehavior>k__BackingField) & 1);
            SLC.Social.Leagues.Guild val_14 = this.CurrentGuild;
            SLC.Social.Profile val_16 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            GameBehavior val_17 = App.getBehavior;
            if(((val_17.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                goto label_21;
            }
            
            if(val_14.requiredVIPLevel <= val_16.goldenCurrency)
            {
                goto label_24;
            }
            
            UnityEngine.Color val_18 = UnityEngine.Color.red;
            this.vipRequirement.color = new UnityEngine.Color() {r = val_18.r, g = val_18.g, b = val_18.b, a = val_18.a};
            goto label_24;
            label_21:
            this.joinButton.interactable = true;
            label_24:
            val_34 = this.CurrentGuild;
            GameEcon val_20 = App.getGameEcon;
            string val_21 = val_19.requiredVIPLevel.ToString(format:  val_20.numberFormatInt);
            SLC.Social.Leagues.Guild val_22 = this.CurrentGuild;
            UnityEngine.GameObject val_23 = this.requirementMetByYou.gameObject;
            if(val_22.requiredVIPLevel == 0)
            {
                goto label_34;
            }
            
            val_23.SetActive(value:  true);
            GameBehavior val_24 = App.getBehavior;
            if(((val_24.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                goto label_39;
            }
            
            val_35 = 1;
            goto label_41;
            label_34:
            val_23.SetActive(value:  false);
            goto label_42;
            label_39:
            label_41:
            this.joinButton.interactable = (val_14.requiredVIPLevel <= val_16.goldenCurrency) ? 1 : 0;
            label_42:
            SLC.Social.Leagues.Guild val_26 = this.CurrentGuild;
            if(val_26.InviteRequired == false)
            {
                goto label_45;
            }
            
            SLC.Social.Leagues.Guild val_27 = this.CurrentGuild;
            val_34 = val_27.ServerId;
            SLC.Social.Profile val_29 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(val_34 != val_29.PendingGuildRequestId)
            {
                goto label_51;
            }
            
            string val_30 = Localization.Localize(key:  "requested_upper", defaultValue:  "REQUESTED", useSingularKey:  false);
            this.joinButton.interactable = false;
            return;
            label_45:
            val_33 = this.joinButtonText;
            string val_31 = Localization.Localize(key:  "join_club", defaultValue:  "JOIN CLUB", useSingularKey:  false);
            return;
            label_51:
            string val_32 = Localization.Localize(key:  "request_join", defaultValue:  "REQUEST JOIN", useSingularKey:  false);
        }
        private void OnJoinGuildClick(bool result)
        {
            var val_35;
            int val_36;
            int val_37;
            UnityEngine.UI.Text val_38;
            string val_40;
            string val_41;
            val_35 = this;
            if(result == false)
            {
                goto label_1;
            }
            
            SLC.Social.Leagues.Guild val_1 = this.CurrentGuild;
            val_36 = val_1.requiredVIPLevel;
            SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            SLC.Social.Leagues.Guild val_4 = this.CurrentGuild;
            val_37 = val_4.MemberCount;
            SLC.Social.Leagues.Guild val_5 = this.CurrentGuild;
            GameBehavior val_6 = App.getBehavior;
            if(((val_6.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    if(this.errorTooltipCurrencyImage != 0)
            {
                    this.errorTooltipCurrencyImage.gameObject.SetActive(value:  false);
            }
            
            }
            
            if(val_36 <= val_3.goldenCurrency)
            {
                goto label_19;
            }
            
            GameBehavior val_9 = App.getBehavior;
            if(((val_9.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    if(this.errorTooltipCurrencyImage != 0)
            {
                    this.errorTooltipCurrencyImage.gameObject.SetActive(value:  true);
            }
            
            }
            
            this.errorTooltip.SetActive(value:  true);
            val_38 = this.errorTooltipMessage;
            GameBehavior val_13 = App.getBehavior;
            string val_14 = System.String.Format(format:  Localization.Localize(key:  "clubs_item_requirement_not_met", defaultValue:  "{0} requirement not met.", useSingularKey:  false), arg0:  val_13.<metaGameBehavior>k__BackingField);
            if(val_38 != null)
            {
                goto label_35;
            }
            
            label_1:
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.ShowConnectionRequired();
            return;
            label_19:
            if(val_37 >= val_5.maximumMembers)
            {
                goto label_40;
            }
            
            SLC.Social.Leagues.Guild val_17 = this.CurrentGuild;
            if(val_17.InviteRequired == false)
            {
                goto label_48;
            }
            
            SLC.Social.Leagues.Guild val_18 = this.CurrentGuild;
            SLC.Social.Profile val_20 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(val_18.ServerId != val_20.PendingGuildRequestId)
            {
                goto label_48;
            }
            
            this.errorTooltip.SetActive(value:  true);
            val_38 = this.errorTooltipMessage;
            val_40 = "request_already_sent";
            val_41 = "Request already sent!";
            goto label_50;
            label_40:
            this.errorTooltip.SetActive(value:  true);
            val_38 = this.errorTooltipMessage;
            val_40 = "club_full";
            val_41 = "Club is full!";
            label_50:
            string val_21 = Localization.Localize(key:  val_40, defaultValue:  val_41, useSingularKey:  false);
            label_35:
            val_35 = ???;
            val_36 = ???;
            val_37 = ???;
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
            label_48:
            SLC.Social.Leagues.Guild val_23 = val_35.CurrentGuild;
            MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.OnLeaveGuildClicked(newGuildIdToJoin:  val_35 + 112, inviteRequired:  val_23.InviteRequired);
            SLCWindow.CloseWindow(window:  val_35.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnDisable()
        {
            if(this.onDisable_callback != null)
            {
                    this.onDisable_callback.Invoke();
            }
            
            this.onDisable_callback = 0;
            this.errorTooltip.SetActive(value:  false);
        }
        public ClubInfo_Window()
        {
            this.guildIdToDisplay = 0;
            this.nextSlowRefresh = 30f;
        }
    
    }

}
