using UnityEngine;
public class TournamentsPopup : MonoBehaviour
{
    // Fields
    public bool allowProfileAccess;
    private TournamentsTierDisplay main_tier_display;
    private UnityEngine.UI.Text text_timer;
    private TournamentsMembersListView membersView;
    private UnityEngine.UI.Button prizesButton;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button closeButton;
    private TournamentsMemberGridItem fixedPlayerGridItem;
    private UnityEngine.GameObject pizesTooltip;
    private UnityEngine.UI.Text[] rankGroups;
    private UnityEngine.UI.Text[] prizeGifts;
    private UnityEngine.UI.Text[] prizeCoins;
    private UnityEngine.UI.Text[] prizeGems;
    private UnityEngine.GameObject[] prizePromotion;
    private UnityEngine.GameObject[] prizeDemotion;
    private TournamentsTierDisplay prizes_tier_display;
    private UnityEngine.GameObject infoTooltip;
    private UnityEngine.UI.Text infoDescription;
    private TournamentInfo tournamentInfo;
    private FrameSkipper skipper;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnMyProfileUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        this.prizesButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TournamentsPopup::OnPrizesClicked()));
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TournamentsPopup::OnInfoClicked()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TournamentsPopup::OnCloseClicked()));
        this.skipper = this.gameObject.AddComponent<FrameSkipper>();
        val_7.updateLogic = new System.Action(object:  this, method:  System.Void TournamentsPopup::UpdateTimer());
    }
    public void OnMyProfileUpdate()
    {
        this.RefreshUI(onEnable:  false);
    }
    public void OnFacebookPluginUpdate(Notification notification)
    {
        this.RefreshUI(onEnable:  false);
    }
    private void OnEnable()
    {
        this.RefreshUI(onEnable:  true);
    }
    private void RefreshUI(bool onEnable = False)
    {
        int val_12;
        var val_13;
        TournamentsManager val_1 = MonoSingleton<TournamentsManager>.Instance;
        this.tournamentInfo = val_1.currentTournamentInfo;
        if((val_1.currentTournamentInfo != null) && (val_1.currentTournamentInfo.me != null))
        {
                this.main_tier_display.RefreshDisplay(tierIndex:  val_1.currentTournamentInfo.tierIndex);
            this.membersView.Refresh(parentWindowObject:  this.gameObject, tournamentInfo:  this.tournamentInfo, refillCells:  onEnable);
            this.RefreshPrizesTooltip();
            this.RefreshInfoTooltip();
            this.fixedPlayerGridItem.UpdateUIFromMember(memberProfile:  this.tournamentInfo.me.ToProfile(), tierIndex:  this.tournamentInfo.tierIndex, rankIndex:  this.tournamentInfo.myRank, rankedWinnings:  this.tournamentInfo.myScore, clickAction:  new System.Action<System.Int32>(object:  this, method:  System.Void TournamentsPopup::ShowMyProfileFlyout(int whocares)), isMe:  true);
            return;
        }
        
        GameBehavior val_6 = App.getBehavior;
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_12 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_9.Length;
        val_9[1] = "NULL";
        val_13 = null;
        val_13 = null;
        val_6.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  "TRY AGAIN", messageTxt:  "Currently processing tournament results! Try again in a few minutes.", shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void ShowMyProfileFlyout(int whocares)
    {
        if(this.allowProfileAccess == false)
        {
                return;
        }
        
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        SLC.Social.Leagues.LeaguesUIManager.ShowPlayerProfile(serverId:  val_2.ServerId, gridItem:  0);
    }
    private void RefreshPrizesTooltip()
    {
        var val_23;
        this.prizes_tier_display.RefreshDisplay(tierIndex:  this.tournamentInfo.tierIndex);
        var val_38 = 0;
        do
        {
            if(val_38 >= this.rankGroups.Length)
        {
                return;
        }
        
            val_23 = null;
            UnityEngine.UI.Text val_23 = this.rankGroups[val_38];
            val_23 = null;
            System.Int32[][] val_24 = TournamentsEconomy.giftRewardsByTier;
            val_24 = val_24 + ((this.tournamentInfo.tierIndex) << 3);
            var val_25 = (TournamentsEconomy.giftRewardsByTier + (this.tournamentInfo.tierIndex) << 3) + 32;
            val_25 = val_25 + 0;
            this.prizeGifts[val_38].transform.parent.gameObject.SetActive(value:  ((((TournamentsEconomy.giftRewardsByTier + (this.tournamentInfo.tierIndex) << 3) + 32 + 0) + 32) > 0) ? 1 : 0);
            UnityEngine.UI.Text val_27 = this.prizeGifts[val_38];
            string val_5 = ((TournamentsEconomy.giftRewardsByTier + (this.tournamentInfo.tierIndex) << 3) + 32 + 0) + 32.ToString();
            System.Int32[][] val_28 = TournamentsEconomy.coinRewardsByTier;
            val_28 = val_28 + ((this.tournamentInfo.tierIndex) << 3);
            var val_29 = (TournamentsEconomy.coinRewardsByTier + (this.tournamentInfo.tierIndex) << 3) + 32;
            val_29 = val_29 + 0;
            this.prizeCoins[val_38].transform.parent.gameObject.SetActive(value:  ((((TournamentsEconomy.coinRewardsByTier + (this.tournamentInfo.tierIndex) << 3) + 32 + 0) + 32) > 0) ? 1 : 0);
            UnityEngine.UI.Text val_31 = this.prizeCoins[val_38];
            string val_10 = ((TournamentsEconomy.coinRewardsByTier + (this.tournamentInfo.tierIndex) << 3) + 32 + 0) + 32.ToString();
            int val_33 = TournamentsEconomy.gemOrPetFoodRewardsByTier[this.tournamentInfo.tierIndex][0];
            this.prizeGems[val_38].transform.parent.gameObject.SetActive(value:  (val_33 > 0) ? 1 : 0);
            UnityEngine.UI.Text val_35 = this.prizeGems[val_38];
            string val_16 = val_33.ToString();
            this.prizePromotion[val_38].SetActive(value:  (((TournamentsEconomy.promotionByRankGroup + 32) > 0) ? 1 : 0) & (TournamentsEconomy.TierIndexCanPromote(tierIndex:  this.tournamentInfo.tierIndex)));
            this.prizeDemotion[val_38].SetActive(value:  (((TournamentsEconomy.promotionByRankGroup + 32) < 0) ? 1 : 0) & (TournamentsEconomy.TierIndexCanDemote(tierIndex:  this.tournamentInfo.tierIndex)));
            val_38 = val_38 + 1;
        }
        while(this.rankGroups != null);
        
        throw new NullReferenceException();
    }
    private void RefreshInfoTooltip()
    {
        var val_15;
        var val_16;
        var val_17;
        int val_18;
        val_15 = null;
        val_15 = null;
        val_16 = null;
        val_16 = null;
        string val_6 = Localization.Localize(key:  (App.game == 17) ? "tournament_info_2_trv" : "tournament_info_2", defaultValue:  (App.game == 17) ? "Earn #currency by completing quizzes!" : "Earn #currency by getting long streaks during levels.", useSingularKey:  false);
        val_17 = null;
        val_17 = null;
        string val_9 = System.String.Format(format:  Localization.Localize(key:  "tournament_info_3", defaultValue:  "The top {0} players get promoted to a higher tournament tier.", useSingularKey:  false), arg0:  ToString());
        string val_12 = System.String.Format(format:  Localization.Localize(key:  "tournament_info_4", defaultValue:  "The bottom {0} players get demoted to a lower tournament tier.", useSingularKey:  false), arg0:  ToString());
        object[] val_13 = new object[4];
        val_18 = val_13.Length;
        val_13[0] = System.String.Format(format:  Localization.Localize(key:  "tournament_info_1", defaultValue:  "Tournaments are {0} hours long and give rewards to the players that earn the most #currency.", useSingularKey:  false), arg0:  ToString());
        if(val_6 != null)
        {
                val_18 = val_13.Length;
        }
        
        val_13[1] = val_6;
        if(val_9 != null)
        {
                val_18 = val_13.Length;
        }
        
        val_13[2] = val_9;
        if(val_12 != null)
        {
                val_18 = val_13.Length;
        }
        
        val_13[3] = val_12;
        string val_14 = System.String.Format(format:  "{0}\n{1}\n{2}\n{3}", args:  val_13);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UpdateTimer()
    {
        if(this.tournamentInfo == null)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.tournamentInfo.endTime}, d2:  new System.DateTime() {dateData = val_1.dateData});
        string val_3 = val_2._ticks.FormatTimeRemaining(timeSpan:  new System.TimeSpan() {_ticks = val_2._ticks});
        this = ???;
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
    private void OnPrizesClicked()
    {
        this.pizesTooltip.gameObject.SetActive(value:  true);
    }
    private void OnInfoClicked()
    {
        this.infoTooltip.gameObject.SetActive(value:  true);
    }
    private void OnCloseClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TournamentsPopup()
    {
        this.allowProfileAccess = true;
    }

}
