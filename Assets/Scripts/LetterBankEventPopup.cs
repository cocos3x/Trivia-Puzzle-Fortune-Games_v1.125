using UnityEngine;
public class LetterBankEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject timer_group;
    private UnityEngine.UI.Text text_timer;
    private UnityEngine.UI.Text text_club_bank;
    private UnityEngine.GameObject leaderboard_group;
    private LetterBankMembersListView membersListView;
    private LetterBankProgressBar progress_bar;
    private UnityEngine.UI.Button button_close;
    private UnityEngine.UI.Button button_info;
    private UnityEngine.UI.Text text_play_level;
    private UnityEngine.UI.Button button_play_level;
    private UnityEngine.UI.Button button_continue_level;
    private UnityEngine.UI.Text text_body_message;
    private UGUINetworkedButton button_join_club;
    private UnityEngine.GameObject min_requirements_group;
    private UnityEngine.UI.Text text_min_requirements;
    private UnityEngine.GameObject info_popup;
    private FrameSkipper skipper;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnMyProfileUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLetterBankEventDataUpdate");
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LetterBankEventPopup::OnCloseClicked()));
        this.button_info.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LetterBankEventPopup::OnInfoClicked()));
        this.button_play_level.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LetterBankEventPopup::OnPlayClicked()));
        this.button_continue_level.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LetterBankEventPopup::OnPlayClicked()));
        System.Delegate val_11 = System.Delegate.Combine(a:  this.button_join_club.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void LetterBankEventPopup::OnJoinClubClicked(bool connected)));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_18;
        }
        
        }
        
        this.button_join_club.OnConnectionClick = val_11;
        this.skipper = this.gameObject.AddComponent<FrameSkipper>();
        val_13.updateLogic = new System.Action(object:  this, method:  System.Void LetterBankEventPopup::UpdateTimer());
        return;
        label_18:
    }
    public void OnMyProfileUpdate()
    {
        this.RefreshUI(onEnable:  false);
    }
    public void OnFacebookPluginUpdate(Notification notification)
    {
        this.RefreshUI(onEnable:  false);
    }
    public void OnMyGuildUpdate()
    {
        this.RefreshUI(onEnable:  false);
    }
    public void OnLetterBankEventDataUpdate()
    {
        this.RefreshUI(onEnable:  false);
    }
    private void OnEnable()
    {
        this.RefreshUI(onEnable:  true);
    }
    private void RefreshUI(bool onEnable = False)
    {
        bool val_38;
        var val_39;
        var val_40;
        object val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        bool val_46;
        var val_47;
        UnityEngine.GameObject val_48;
        var val_49;
        bool val_50;
        var val_51;
        var val_52;
        var val_53;
        var val_54;
        var val_55;
        var val_56;
        val_38 = onEnable;
        GameBehavior val_2 = App.getBehavior;
        string val_3 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  val_2.<metaGameBehavior>k__BackingField);
        this.button_join_club.gameObject.SetActive(value:  (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == 0) ? 1 : 0);
        UnityEngine.GameObject val_8 = this.button_play_level.gameObject;
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
        {
            goto label_13;
        }
        
        GameBehavior val_11 = App.getBehavior;
        var val_12 = ((val_11.<metaGameBehavior>k__BackingField) != 2) ? 1 : 0;
        if(val_8 != null)
        {
            goto label_18;
        }
        
        label_13:
        val_39 = 0;
        label_18:
        val_8.SetActive(value:  false);
        UnityEngine.GameObject val_13 = this.button_continue_level.gameObject;
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
        {
            goto label_25;
        }
        
        GameBehavior val_16 = App.getBehavior;
        var val_17 = ((val_16.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0;
        if(val_13 != null)
        {
            goto label_30;
        }
        
        label_25:
        val_40 = 0;
        label_30:
        val_13.SetActive(value:  false);
        val_42 = null;
        val_42 = null;
        this.text_club_bank.gameObject.SetActive(value:  LetterBankEventHandler._EligibleForEvent);
        val_43 = null;
        val_43 = null;
        this.text_body_message.gameObject.SetActive(value:  (LetterBankEventHandler._EligibleForEvent == false) ? 1 : 0);
        val_44 = null;
        val_44 = null;
        this.leaderboard_group.gameObject.SetActive(value:  LetterBankEventHandler._EligibleForEvent);
        val_45 = null;
        val_45 = null;
        val_46 = LetterBankEventHandler._EligibleForEvent;
        if(val_46 != false)
        {
                val_47 = null;
            val_47 = null;
            val_46 = LetterBankEventHandler._EligibleForRewards;
        }
        
        this.progress_bar.gameObject.SetActive(value:  (val_46 == true) ? 1 : 0);
        val_48 = this.min_requirements_group;
        val_49 = null;
        val_49 = null;
        val_50 = LetterBankEventHandler._EligibleForEvent;
        if(val_50 != false)
        {
                val_51 = null;
            val_51 = null;
            val_50 = LetterBankEventHandler._EligibleForRewards ^ 1;
        }
        
        val_48.SetActive(value:  (val_50 == true) ? 1 : 0);
        val_52 = null;
        val_52 = null;
        if(LetterBankEventHandler._EligibleForEvent != false)
        {
                val_53 = null;
            val_53 = null;
            string val_25 = LetterBankEventHandler._TotalClubBank.ToString();
            this.progress_bar.UpdateSlider();
            val_54 = null;
            val_54 = null;
            val_41 = LetterBankEventHandler._MembersRequirement;
            val_55 = null;
            val_55 = null;
            string val_27 = System.String.Format(format:  Localization.Localize(key:  "letter_bank_minimum", defaultValue:  "CLUB MUST HAVE AT LEAST {0} MEMBERS AND {1} PARTICIPANTS TO WIN AWARDS.", useSingularKey:  false), arg0:  LetterBankEventHandler._MembersRequirement, arg1:  LetterBankEventHandler._ParticipantsRequirement);
            val_48 = this.membersListView;
            val_56 = null;
            val_56 = null;
            val_48.Refresh(parentWindowObject:  this.gameObject, eventPlayers:  LetterBankEventHandler._EventPlayers, refillCells:  val_38);
            if(val_38 == false)
        {
                return;
        }
        
            System.Collections.Generic.List<GiftReward> val_30 = LetterBankEventHandler.GetCollectableRewards();
            if(val_30 == null)
        {
                return;
        }
        
            val_38 = val_30;
            GameBehavior val_31 = App.getBehavior;
            LetterBankEventHandler.CollectedTierReward();
            return;
        }
        
        val_38 = this.text_body_message;
        SLC.Social.Leagues.Guild val_34 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        string val_37 = Localization.Localize(key:  (val_34 == 0) ? "letter_bank_must_join" : "letter_bank_ineligible", defaultValue:  (val_34 == 0) ? "MUST JOIN A CLUB TO PARTICIPATE" : "YOU ARE NOT ELIGIBLE TO PARTICIPATE IN THIS EVENT. PLEASE SEE EVENT INFO FOR EVENT RULES.", useSingularKey:  false);
    }
    public void ShowGameplayVersion()
    {
        if(this.timer_group != null)
        {
                this.timer_group.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void UpdateTimer()
    {
        null = null;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = LetterBankEventHandler._EventEndTime}, d2:  new System.DateTime() {dateData = val_1.dateData});
        string val_3 = val_2._ticks.FormatTimeRemaining(timeSpan:  new System.TimeSpan() {_ticks = val_2._ticks});
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private string FormatTimeRemaining(System.TimeSpan timeSpan)
    {
        object val_7;
        var val_8;
        if(timeSpan._ticks.TotalSeconds > 0f)
        {
                int val_7 = 24;
            val_7 = timeSpan._ticks.Hours + (timeSpan._ticks.Days * val_7);
            val_7 = val_7;
            string val_6 = System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_7, arg1:  timeSpan._ticks.Minutes, arg2:  timeSpan._ticks.Seconds);
            return (string)val_8;
        }
        
        val_8 = "00:00:00";
        return (string)val_8;
    }
    private void OnCloseClicked()
    {
        var val_2;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        val_2 = null;
        val_2 = null;
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    private void OnInfoClicked()
    {
        if(this.info_popup != null)
        {
                this.info_popup.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnPlayClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 2)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_410;
    }
    private void OnJoinClubClicked(bool connected)
    {
        var val_12;
        int val_13;
        var val_14;
        if(connected != false)
        {
                val_12 = null;
            val_12 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 101;
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField) != 4)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        GameBehavior val_5 = App.getBehavior;
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_13 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_13 = val_10.Length;
        val_10[1] = "NULL";
        val_14 = null;
        val_14 = null;
        val_5.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public LetterBankEventPopup()
    {
    
    }

}
