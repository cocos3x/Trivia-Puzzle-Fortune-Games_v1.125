using UnityEngine;
public class ClubClashEventWindow : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
    // Fields
    private UnityEngine.UI.Text primaryWindowText;
    private UnityEngine.UI.Text rewardHeaderText;
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.UI.Text rewardGoldenCurrencyText;
    private UnityEngine.UI.Text playerContributionText;
    private UnityEngine.UI.Text playerTeamNameText;
    private UnityEngine.UI.Text opposingTeamNameText;
    private UnityEngine.UI.Text playerPointsText;
    private UnityEngine.UI.Text opposingPointsText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.GameObject rewardBox;
    private UnityEngine.GameObject playerTeamNameBox;
    private UnityEngine.GameObject opposingTeamNameBox;
    private UnityEngine.GameObject timerParent;
    private UnityEngine.GameObject infoPopup;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button infoButton;
    private UGUINetworkedButton primaryButton;
    private UnityEngine.UI.Text buttonText;
    private UGUINetworkedButton secondaryButton;
    private UnityEngine.UI.Text secondaryButtonText;
    private UnityEngine.UI.Image playerBarImage;
    private UnityEngine.UI.Image playerClubImage;
    private UnityEngine.UI.Image opposingClubImage;
    private System.Collections.Generic.List<UnityEngine.UI.Text> infoReqText;
    private System.Collections.Generic.List<UnityEngine.UI.Text> infoRewardText;
    private System.Collections.Generic.List<UnityEngine.UI.Text> infoRewardGoldenCurrencyText;
    public SLC.Social.AvatarConfig guildAvatarHandler;
    public System.Action onStartAction;
    public GameEventV2 myEvent;
    private FrameSkipper mySkipper;
    private GridCoinCollectAnimationInstantiator coinCollector;
    private GoldenCurrencyCollectAnimationInstantiator goldenCollector;
    private UnityEngine.Sprite missingOpponentClubImage;
    private UnityEngine.ParticleSystem victorySystem;
    
    // Methods
    private void Start()
    {
        var val_5;
        var val_6;
        var val_7;
        this.mySkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2._framesToSkip = 10;
        if(this.onStartAction != null)
        {
                this.onStartAction.Invoke();
        }
        
        val_5 = 1152921504884269056;
        GameBehavior val_3 = App.getBehavior;
        if((val_3.<metaGameBehavior>k__BackingField) == 1)
        {
                val_5 = 1152921504887996416;
            val_6 = null;
            val_6 = null;
            val_7 = 39;
        }
        else
        {
                GameBehavior val_4 = App.getBehavior;
            if((val_4.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
            val_5 = 1152921504887996416;
            val_6 = null;
            val_6 = null;
            val_7 = 40;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 40;
    }
    public void SetUpWindow(bool fromGameButton = False)
    {
        System.Action val_10;
        var val_11;
        IntPtr val_13;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY.hasRewardData == false)
        {
            goto label_3;
        }
        
        val_10 = this.onStartAction;
        val_11 = 1152921504614301696;
        val_13 = 1152921516161463040;
        goto label_27;
        label_3:
        if((SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() != false) && ((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56) == 0))
        {
                if((System.String.op_Equality(a:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 64, b:  "created")) == true)
        {
            goto label_11;
        }
        
        }
        
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = ClubClashEvent.LAST_PROGRESS_STAMP_KEY.m_stringLength + 40}, t2:  new System.DateTime() {dateData = val_4.dateData})) == false)
        {
            goto label_19;
        }
        
        label_11:
        val_10 = this.onStartAction;
        val_11 = 1152921504614301696;
        System.Action val_6 = null;
        val_13 = 1152921516161472256;
        label_27:
        val_6 = new System.Action(object:  this, method:  val_13);
        System.Delegate val_7 = System.Delegate.Combine(a:  val_10, b:  val_6);
        if(val_7 != null)
        {
                if(null != val_11)
        {
            goto label_21;
        }
        
        }
        
        this.onStartAction = val_7;
        return;
        label_19:
        if(((ClubClashEvent.LAST_PROGRESS_STAMP_KEY.m_stringLength + 82) != 0) || ((System.String.op_Equality(a:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 64, b:  "created")) == false))
        {
            goto label_26;
        }
        
        goto label_27;
        label_26:
        this.gameObject.SetActive(value:  false);
        return;
        label_21:
    }
    public void DisplayCrownClashResult()
    {
        object val_32;
        UGUINetworkedButton val_33;
        val_32 = this;
        if(((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 72) != 0) && ((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 72.ContainsKey(key:  "reward")) != false))
        {
                int val_7 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY.baseRewardCoins;
            int val_11 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY.baseRewardGoldenCurrency;
            object val_4 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 72.Item["reward"];
            if((val_4.ContainsKey(key:  "coins")) != false)
        {
                bool val_8 = System.Int32.TryParse(s:  val_4.Item["coins"], result: out  val_7);
        }
        
            if((val_4.ContainsKey(key:  "golden")) != false)
        {
                bool val_12 = System.Int32.TryParse(s:  val_4.Item["golden"], result: out  val_11);
        }
        
        }
        
        this.CleanUI();
        if((val_7 <= 0) && (val_11 < 1))
        {
                string val_13 = Localization.Localize(key:  "your_club_lost", defaultValue:  "Your Club Lost.", useSingularKey:  false);
            this.secondaryButton.gameObject.SetActive(value:  true);
            val_33 = this.secondaryButton;
            this.secondaryButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::CollectReward(bool connected));
            string val_16 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
            this.DisplayClubValues();
            val_32 = this.playerContributionText;
            string val_18 = System.String.Format(format:  Localization.Localize(key:  "earn_apples_for_club", defaultValue:  "You\'ve earned {0} Golden Apples for your Club!", useSingularKey:  false), arg0:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48);
            return;
        }
        
        this.coinCollector.gameObject.SetActive(value:  true);
        this.goldenCollector.gameObject.SetActive(value:  true);
        string val_21 = Localization.Localize(key:  "your_club_won_upper", defaultValue:  "YOUR CLUB WON!", useSingularKey:  false);
        this.primaryButton.gameObject.SetActive(value:  true);
        this.primaryButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::CollectReward(bool connected));
        string val_24 = Localization.Localize(key:  "prize_pool_upper", defaultValue:  "PRIZE POOL", useSingularKey:  false);
        string val_25 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        this.DisplayClubValues();
        val_33 = Localization.Localize(key:  "earn_apples_for_club", defaultValue:  "You\'ve earned {0} Golden Apples for your Club!", useSingularKey:  false);
        string val_27 = System.String.Format(format:  val_33, arg0:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48);
        string val_28 = val_7.ToString();
        string val_29 = val_11.ToString();
        this.rewardBox.SetActive(value:  true);
        if(this.victorySystem == 0)
        {
                return;
        }
        
        this.victorySystem.gameObject.SetActive(value:  true);
        this.victorySystem.Play();
    }
    public void DisplayEvent()
    {
        string val_38;
        string val_55;
        string val_56;
        int val_57;
        GameEventV2 val_58;
        FrameSkipper val_59;
        var val_60;
        string val_61;
        string val_62;
        UnityEngine.UI.Image val_63;
        SLC.Social.AvatarConfig val_64;
        var val_65;
        UnityEngine.UI.Text val_66;
        val_55 = this;
        this.CleanUI();
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        this.myEvent = ClubClashEvent.LAST_PROGRESS_STAMP_KEY.m_stringLength;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY.m_stringLength == 0)
        {
            goto label_11;
        }
        
        val_56 = "lastCrownClashPrompt";
        val_57 = 0;
        val_55 = "lastCrownClashPrompt";
        if((CPlayerPrefs.GetInt(key:  val_55, defaultValue:  0)) == 0)
        {
            goto label_6;
        }
        
        val_55 = "lastCrownClashPrompt";
        val_57 = 0;
        val_58 = this.myEvent;
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        if((CPlayerPrefs.GetInt(key:  val_55, defaultValue:  0)) != this.myEvent.id)
        {
            goto label_10;
        }
        
        goto label_11;
        label_6:
        val_58 = this.myEvent;
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        label_10:
        val_57 = this.myEvent.id;
        CPlayerPrefs.SetInt(key:  "lastCrownClashPrompt", val:  val_57);
        label_11:
        val_55 = this.timerParent;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_55.SetActive(value:  true);
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
        {
            goto label_18;
        }
        
        System.Action val_4 = null;
        val_57 = this;
        val_4 = new System.Action(object:  this, method:  System.Void ClubClashEventWindow::UpdateTimerText());
        if(this.mySkipper == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = this;
        this.mySkipper.updateLogic = val_4;
        this.DisplayClubValues();
        if(this.mySkipper == null)
        {
                throw new NullReferenceException();
        }
        
        System.Delegate val_6 = System.Delegate.Combine(a:  this.mySkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void ClubClashEventWindow::DisplayClubValues()));
        if(val_6 != null)
        {
                val_57 = null;
            if(null != val_57)
        {
            goto label_137;
        }
        
        }
        
        this.mySkipper.updateLogic = val_6;
        val_57 = "PRIZE POOL";
        if(this.rewardHeaderText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = Localization.Localize(key:  "prize_pool_upper", defaultValue:  val_57, useSingularKey:  false);
        val_55 = this.rewardHeaderText;
        val_59 = this.mySkipper;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Delegate val_9 = System.Delegate.Combine(a:  this.mySkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void ClubClashEventWindow::DisplayCurrentPrize()));
        if(val_9 != null)
        {
                val_57 = null;
            if(null != val_57)
        {
            goto label_137;
        }
        
        }
        
        this.mySkipper.updateLogic = val_9;
        val_60 = null;
        val_60 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
            goto label_32;
        }
        
        val_61 = "club_most_apples_wins";
        val_62 = "Club that earns the most Golden Apples wins!";
        goto label_33;
        label_18:
        if(SLC.Social.Leagues.LeaguesManager.IsAvailable() == false)
        {
            goto label_36;
        }
        
        System.Action val_11 = null;
        val_57 = this;
        val_11 = new System.Action(object:  this, method:  System.Void ClubClashEventWindow::UpdateTimerText());
        if(this.mySkipper == null)
        {
                throw new NullReferenceException();
        }
        
        this.mySkipper.updateLogic = val_11;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if(((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 88) & 2147483648) != 0)
        {
            goto label_40;
        }
        
        val_63 = this.playerClubImage;
        val_64 = this.guildAvatarHandler;
        goto label_79;
        label_36:
        UnityEngine.Debug.LogError(message:  "no leagues manager available, closing Crown Clash popup");
        val_57 = 0;
        if(this.gameObject == null)
        {
                throw new NullReferenceException();
        }
        
        val_65 = 0;
        goto label_45;
        label_32:
        val_61 = "connect_for_udpates";
        val_62 = "Internet required for updates!";
        label_33:
        if(this.primaryWindowText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = Localization.Localize(key:  val_61, defaultValue:  val_62, useSingularKey:  false);
        val_55 = this.rewardBox;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 1;
        val_55.SetActive(value:  true);
        val_55 = this.infoButton;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 0;
        UnityEngine.GameObject val_14 = val_55.gameObject;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 1;
        val_14.SetActive(value:  true);
        if(this.infoButton == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Events.UnityAction val_15 = null;
        val_57 = this;
        val_15 = new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void ClubClashEventWindow::ToggleInfo());
        if(this.infoButton.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_15;
        this.infoButton.m_OnClick.AddListener(call:  val_15);
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = val_16.<metaGameBehavior>k__BackingField;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_55 != 1)
        {
            goto label_56;
        }
        
        val_55 = this.primaryButton;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 0;
        UnityEngine.GameObject val_17 = val_55.gameObject;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17.SetActive(value:  true);
        System.Action<System.Boolean> val_18 = null;
        val_57 = this;
        val_18 = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::LoadGameplayScene(bool connected));
        if(this.primaryButton == null)
        {
                throw new NullReferenceException();
        }
        
        this.primaryButton.OnConnectionClick = val_18;
        val_66 = this.buttonText;
        val_57 = "LEVEL {0}";
        Player val_20 = App.Player;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_20;
        string val_21 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  val_57, useSingularKey:  false), arg0:  val_20);
        if(val_66 != null)
        {
            goto label_63;
        }
        
        throw new NullReferenceException();
        label_56:
        val_55 = this.secondaryButton;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 0;
        UnityEngine.GameObject val_22 = val_55.gameObject;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22.SetActive(value:  true);
        System.Action<System.Boolean> val_23 = null;
        val_57 = this;
        val_23 = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::LoadGameplayScene(bool connected));
        if(this.secondaryButton == null)
        {
                throw new NullReferenceException();
        }
        
        this.secondaryButton.OnConnectionClick = val_23;
        val_66 = this.secondaryButtonText;
        val_57 = "CONTINUE";
        string val_24 = Localization.Localize(key:  "continue_upper", defaultValue:  val_57, useSingularKey:  false);
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        label_63:
        val_57 = "You\'ve earned {0} Golden Apples for your Club!";
        val_56 = Localization.Localize(key:  "earn_apples_for_club", defaultValue:  val_57, useSingularKey:  false);
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48;
        if(this.playerContributionText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = System.String.Format(format:  val_56, arg0:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48);
        val_55 = this.closeButton;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 0;
        UnityEngine.GameObject val_27 = val_55.gameObject;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_65 = 1;
        label_45:
        val_27.SetActive(value:  true);
        return;
        label_40:
        val_55 = this.guildAvatarHandler;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_55.AvatarSpritesCount;
        ClubClashEvent.LAST_PROGRESS_STAMP_KEY.__unknownFiledOffset_58 = UnityEngine.Random.Range(min:  0, max:  val_57);
        val_55 = this.guildAvatarHandler;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_55.AvatarSpritesCount;
        val_55 = 0;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        ClubClashEvent.LAST_PROGRESS_STAMP_KEY.__unknownFiledOffset_5C = UnityEngine.Random.Range(min:  0, max:  val_57);
        val_63 = this.playerClubImage;
        val_64 = this.guildAvatarHandler;
        label_79:
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_64 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 88];
        val_57 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 88;
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_64.GetAvatarSpriteByID(id:  val_57, portraitID:  0);
        val_55 = val_63;
        val_55.sprite = val_57;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.guildAvatarHandler == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 92];
        val_57 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 92;
        if(this.opposingClubImage == null)
        {
                throw new NullReferenceException();
        }
        
        this.opposingClubImage.sprite = this.guildAvatarHandler.GetAvatarSpriteByID(id:  val_57, portraitID:  0);
        val_57 = "Club that earns the most Golden Apples wins!";
        string val_34 = Localization.Localize(key:  "club_clash_info", defaultValue:  val_57, useSingularKey:  false);
        if(this.primaryWindowText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = "REWARDS UP TO";
        if(this.rewardHeaderText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = Localization.Localize(key:  "rewards_up_to_upper", defaultValue:  val_57, useSingularKey:  false);
        val_55 = this.rewardHeaderText;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104];
        val_55 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104;
        if(val_55 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_57 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Object>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_36 = val_55.Keys;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_37 = val_36.GetEnumerator();
        val_59 = 1152921504619999232;
        goto label_99;
        label_105:
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104];
        val_55 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104;
        if(val_55 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_38;
        if(val_55.Item[val_57] == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = null;
        if(null > 0)
        {
                if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
            val_55 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104];
            val_55 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104;
            if(val_55 == 0)
        {
                throw new NullReferenceException();
        }
        
            object val_40 = val_55.Item[val_38];
            val_57 = null;
        }
        
        label_99:
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48.MoveNext()) == true)
        {
            goto label_105;
        }
        
        ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48.Dispose();
        label_140:
        val_57 = 0;
        if(this.rewardText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = null.ToString();
        val_55 = this.rewardText;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112];
        val_55 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112;
        if(val_55 == 0)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_43 = val_55.GetEnumerator();
        goto label_110;
        label_113:
        val_55 = val_38;
        if(val_55 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_57 = null;
        label_110:
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48.MoveNext()) == true)
        {
            goto label_113;
        }
        
        ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48.Dispose();
        val_57 = 0;
        string val_47 = (val_55 > 0) ? (val_55) : 0.ToString();
        if(this.rewardGoldenCurrencyText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = "FIND CLUB";
        if(this.secondaryButtonText == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = Localization.Localize(key:  "find_club_upper", defaultValue:  val_57, useSingularKey:  false);
        val_55 = this.secondaryButton;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 0;
        UnityEngine.GameObject val_49 = val_55.gameObject;
        if(val_49 == null)
        {
                throw new NullReferenceException();
        }
        
        val_49.SetActive(value:  true);
        System.Action<System.Boolean> val_50 = null;
        val_57 = this;
        val_50 = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::FindClubButtonClick(bool result));
        if(this.secondaryButton == null)
        {
                throw new NullReferenceException();
        }
        
        this.secondaryButton.OnConnectionClick = val_50;
        val_55 = this.closeButton;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 0;
        UnityEngine.GameObject val_51 = val_55.gameObject;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = 1;
        val_51.SetActive(value:  true);
        val_55 = this.rewardBox;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_55.SetActive(value:  true);
        val_56 = this.playerContributionText;
        val_57 = "You\'ve earned {0} Golden Apples for your Club!";
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48;
        if(val_56 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = System.String.Format(format:  Localization.Localize(key:  "earn_apples_for_club", defaultValue:  val_57, useSingularKey:  false), arg0:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48);
        val_55 = this.playerBarImage;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_55.fillAmount = 0.5f;
        return;
        label_137:
        if(W1 != 1)
        {
            goto label_142;
        }
        
        ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 48.Dispose();
        if(6042 == 0)
        {
            goto label_140;
        }
        
        throw null;
        label_142:
    }
    private void SetTimerSpecialBoyPlacement()
    {
    
    }
    public void DisplayInBetweenState()
    {
        object val_20;
        UnityEngine.UI.Text val_21;
        UnityEngine.UI.Image val_23;
        UnityEngine.Sprite val_24;
        val_20 = this;
        this.CleanUI();
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() != false)
        {
                if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56) == 0)
        {
            goto label_46;
        }
        
        }
        
        label_46:
        string val_2 = Localization.Localize(key:  "crown_clash_complete", defaultValue:  "Event Complete! Your reward will be available soon!", useSingularKey:  false);
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
        {
            goto label_10;
        }
        
        GameBehavior val_4 = App.getBehavior;
        if((val_4.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_17;
        }
        
        this.primaryButton.gameObject.SetActive(value:  true);
        this.primaryButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::CloseWindow(bool connected));
        val_21 = this.buttonText;
        string val_9 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        if(val_21 != null)
        {
            goto label_24;
        }
        
        label_10:
        this.gameObject.SetActive(value:  false);
        return;
        label_17:
        this.secondaryButton.gameObject.SetActive(value:  true);
        this.secondaryButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void ClubClashEventWindow::CloseWindow(bool connected));
        val_21 = this.secondaryButtonText;
        string val_13 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
        label_24:
        val_23 = this.playerClubImage;
        SLC.Social.Leagues.Guild val_15 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        val_23.sprite = this.guildAvatarHandler.GetAvatarSpriteByID(id:  val_15.AvatarId, portraitID:  0);
        if(((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56) != 0) && ((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.ContainsKey(key:  "avatar")) != false))
        {
                val_23 = this.opposingClubImage;
            val_20 = this.guildAvatarHandler;
            object val_18 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["avatar"];
            val_24 = val_20.GetAvatarSpriteByID(id:  19914752, portraitID:  0);
        }
        else
        {
                val_24 = this.missingOpponentClubImage;
        }
        
        this.opposingClubImage.sprite = val_24;
    }
    public void ToggleInfo()
    {
        var val_20;
        var val_21;
        this.infoPopup.SetActive(value:  (~this.infoPopup.activeSelf) & 1);
        if(this.infoPopup.activeSelf == false)
        {
                return;
        }
        
        val_20 = 1152921504912117760;
        System.Collections.Generic.List<TSource> val_5 = System.Linq.Enumerable.ToList<System.String>(source:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104.Keys);
        int val_7 = 0;
        if((System.Int32.TryParse(s:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["capacity"], result: out  val_7)) == false)
        {
            goto label_11;
        }
        
        val_21 = "0";
        if((val_5.Contains(item:  "0")) != false)
        {
                bool val_10 = val_5.Remove(item:  "0");
        }
        
        if(1152921515471706608 < 1)
        {
                return;
        }
        
        var val_22 = 4;
        val_21 = "not enough ui elements for the crown clash rewards";
        var val_11 = val_22 - 4;
        if(((val_11 >= this.infoReqText) || (val_11 >= this.infoRewardText)) || (val_11 >= this.infoRewardGoldenCurrencyText))
        {
            goto label_20;
        }
        
        int val_12 = 0;
        if(val_11 >= 1152921515471706608)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((System.Int32.TryParse(s:  "Not allowed character was in the input string, at {0}", result: out  val_12)) == false)
        {
            goto label_48;
        }
        
        decimal val_16 = System.Decimal.op_Implicit(value:  (val_7 + (ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 40)) * val_12);
        decimal val_17 = new System.Decimal(value:  232);
        string val_18 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_17.flags, hi = val_17.flags, lo = val_17.lo, mid = val_17.lo}, useRichText:  false, withSpaces:  false);
        val_20 = val_20;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        object val_19 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104.Item[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 32];
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        object val_20 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112.Item[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 32];
        goto label_48;
        label_20:
        UnityEngine.Debug.LogError(message:  "not enough ui elements for the crown clash rewards");
        label_48:
        var val_21 = val_22 - 3;
        val_22 = val_22 + 1;
        return;
        label_11:
        UnityEngine.Debug.LogError(message:  "unable to parse opposing club capacity");
    }
    private void DisplayCurrentPrize()
    {
        string val_11;
        var val_12;
        ClubClashEventWindow val_36;
        string val_37;
        string val_38;
        string val_39;
        var val_40;
        object val_41;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56) == 0)
        {
                return;
        }
        
        int val_2 = 0;
        val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56];
        val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_36 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 40];
        val_36 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 40;
        val_38 = "capacity";
        object val_1 = val_37.Item[val_38];
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_1, result: out  val_2)) == false)
        {
            goto label_6;
        }
        
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        int val_5 = 0;
        val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56];
        val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = "crowns";
        object val_4 = val_37.Item[val_38];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_4, result: out  val_5)) == false)
        {
            goto label_11;
        }
        
        val_39 = val_5;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104];
        val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Object>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_7 = val_37.Keys;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_8 = val_39 + (ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44);
        var val_9 = val_2 + val_36;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_10 = val_7.GetEnumerator();
        string val_35 = val_11;
        val_40 = 0;
        goto label_16;
        label_25:
        val_39 = val_35;
        val_37 = val_39;
        val_38 = 0;
        val_35 = (System.Int32.Parse(s:  val_37)) * val_9;
        if(val_8 < val_35)
        {
            goto label_17;
        }
        
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104];
        val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_39;
        object val_14 = val_37.Item[val_38];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = 0;
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104];
        val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 104;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_40 = val_40 | (System.String.op_Equality(a:  val_39, b:  System.Linq.Enumerable.Last<System.String>(source:  val_37.Keys)));
        label_16:
        if(val_12.MoveNext() == true)
        {
            goto label_25;
        }
        
        label_17:
        val_38 = public System.Void Dictionary.KeyCollection.Enumerator<System.String, System.Object>::Dispose();
        val_12.Dispose();
        if((System.Int32.Parse(s:  val_14)) <= 0)
        {
                val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY;
            if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
            val_38 = 0;
        }
        
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112];
        val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Object>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_21 = val_37.Keys;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_22 = val_21.GetEnumerator();
        string val_36 = val_11;
        goto label_34;
        label_42:
        val_39 = val_36;
        val_37 = val_39;
        val_38 = 0;
        val_36 = (System.Int32.Parse(s:  val_37)) * val_9;
        if(val_8 >= val_36)
        {
                if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
            val_37 = mem[ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112];
            val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112;
            if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_38 = val_39;
            object val_24 = val_37.Item[val_38];
            if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
            val_38 = 0;
            if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_37 = false;
            val_37 = val_37 | (System.String.op_Equality(a:  val_39, b:  System.Linq.Enumerable.Last<System.String>(source:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 112.Keys)));
        }
        
        label_34:
        if(val_12.MoveNext() == true)
        {
            goto label_42;
        }
        
        val_38 = public System.Void Dictionary.KeyCollection.Enumerator<System.String, System.Object>::Dispose();
        val_12.Dispose();
        val_36 = this;
        if((System.Int32.Parse(s:  val_24)) <= 0)
        {
                val_37 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY;
            if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_38 = 0;
        if(mem[1152921516163706888] == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_37.baseRewardCoins.ToString();
        val_37 = mem[1152921516163706888];
        if(val_40 != true)
        {
                if(mem[1152921516163706888] == 0)
        {
                throw new NullReferenceException();
        }
        
            string val_32 = mem[1152921516163706888] + "+"("+");
        }
        
        val_38 = 0;
        if(mem[1152921516163706896] == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_37.baseRewardGoldenCurrency.ToString();
        val_37 = mem[1152921516163706896];
        if(val_37 == true)
        {
                return;
        }
        
        val_36 = mem[1152921516163706896];
        if(val_36 == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_34 = val_36 + "+"("+");
        return;
        label_6:
        val_41 = "unable to parse opposing club capacity";
        goto label_55;
        label_11:
        val_41 = "unable to parse opposing club crowns";
        label_55:
        UnityEngine.Debug.LogError(message:  val_41);
    }
    private void UpdateTimerText()
    {
        object val_21;
        string val_22;
        System.Delegate val_23;
        int val_26;
        val_21 = this;
        if(this.myEvent == null)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.myEvent.timeEnd}, d2:  new System.DateTime() {dateData = val_1.dateData});
        if(val_2._ticks.TotalSeconds < 0)
        {
                ClubClashEvent.LAST_PROGRESS_STAMP_KEY.PutData(crownsCollected:  0);
            this.CleanUI();
            this.DisplayInBetweenState();
            val_22 = 1152921504614301696;
            System.Action val_4 = null;
            val_23 = val_4;
            val_4 = new System.Action(object:  this, method:  System.Void ClubClashEventWindow::UpdateTimerText());
            System.Delegate val_5 = System.Delegate.Remove(source:  this.mySkipper.updateLogic, value:  val_4);
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
            this.mySkipper.updateLogic = val_5;
            return;
        }
        
        int val_7 = val_2._ticks.Seconds;
        if(val_2._ticks.Seconds > 9)
        {
                string val_8 = val_7.ToString();
        }
        else
        {
                string val_9 = "0" + val_7;
        }
        
        int val_11 = val_2._ticks.Minutes;
        if(val_2._ticks.Minutes > 9)
        {
                string val_12 = val_11.ToString();
        }
        else
        {
            
        }
        
        val_23 = "0" + val_11;
        val_22 = val_2._ticks.Hours.ToString();
        if(val_2._ticks.Hours <= 9)
        {
                val_22 = "0" + val_22;
        }
        
        val_21 = this.timerText;
        object[] val_18 = new object[4];
        val_26 = val_18.Length;
        val_18[0] = val_2._ticks.Days;
        if(val_22 != null)
        {
                val_26 = val_18.Length;
        }
        
        val_18[1] = val_22;
        if(val_23 != null)
        {
                val_26 = val_18.Length;
        }
        
        val_18[2] = val_23;
        if(val_9 != null)
        {
                val_26 = val_18.Length;
        }
        
        val_18[3] = val_9;
        string val_20 = System.String.Format(format:  "{0}:{1}:{2}:{3}", args:  val_18);
        return;
        label_11:
    }
    private void FindClubButtonClick(bool result)
    {
        int val_17;
        var val_18;
        System.Func<System.Boolean> val_20;
        var val_21;
        if(((result != false) && (SLC.Social.Leagues.LeaguesManager.IsAvailable() != false)) && ((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) != 0))
        {
                SLC.Social.Leagues.LeaguesManager val_4 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            if(val_4._InitialResponseSuccess != false)
        {
                WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesLoadingPopup>(showNext:  true);
            this.CloseWindow(connected:  false);
            return;
        }
        
        }
        
        GameBehavior val_7 = App.getBehavior;
        bool[] val_11 = new bool[2];
        val_11[0] = true;
        string[] val_12 = new string[2];
        val_17 = val_12.Length;
        val_12[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_17 = val_12.Length;
        val_12[1] = "NULL";
        System.Func<System.Boolean>[] val_14 = new System.Func<System.Boolean>[2];
        val_18 = null;
        val_18 = null;
        val_20 = ClubClashEventWindow.<>c.<>9__44_0;
        if(val_20 == null)
        {
                System.Func<System.Boolean> val_15 = null;
            val_20 = val_15;
            val_15 = new System.Func<System.Boolean>(object:  ClubClashEventWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean ClubClashEventWindow.<>c::<FindClubButtonClick>b__44_0());
            ClubClashEventWindow.<>c.<>9__44_0 = val_20;
        }
        
        val_14[0] = val_20;
        val_21 = null;
        val_21 = null;
        val_7.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_11, buttonTexts:  val_12, showClose:  false, buttonCallbacks:  val_14, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void DisplayClubValues()
    {
        UnityEngine.UI.Image val_28;
        var val_29;
        var val_30;
        UnityEngine.UI.Text val_32;
        val_28 = this;
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56) == 0)
        {
                return;
        }
        
        val_29 = 1152921505022660608;
        if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
        {
                return;
        }
        
        this.playerTeamNameBox.SetActive(value:  true);
        SLC.Social.Leagues.Guild val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        this.playerPointsText.gameObject.SetActive(value:  true);
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44) >= 1000)
        {
            goto label_17;
        }
        
        val_30 = 0;
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44.ToString()) != null)
        {
            goto label_18;
        }
        
        label_17:
        decimal val_6 = System.Decimal.op_Implicit(value:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44);
        decimal val_7 = new System.Decimal(value:  232);
        string val_8 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_7.flags, hi = val_7.flags, lo = val_7.lo, mid = val_7.lo}, useRichText:  false, withSpaces:  false);
        label_18:
        SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        this.playerClubImage.sprite = this.guildAvatarHandler.GetAvatarSpriteByID(id:  val_10.AvatarId, portraitID:  0);
        this.opposingTeamNameBox.SetActive(value:  true);
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.ContainsKey(key:  "name")) != false)
        {
                object val_13 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["name"];
        }
        
        this.opposingPointsText.gameObject.SetActive(value:  true);
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.ContainsKey(key:  "crowns")) == false)
        {
            goto label_39;
        }
        
        int val_17 = System.Int32.Parse(s:  ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["crowns"]);
        val_32 = this.opposingPointsText;
        if(val_17 < 1000)
        {
            goto label_41;
        }
        
        decimal val_18 = System.Decimal.op_Implicit(value:  val_17);
        decimal val_19 = new System.Decimal(value:  232);
        string val_20 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_19.flags, hi = val_19.flags, lo = val_19.lo, mid = val_19.lo}, useRichText:  false, withSpaces:  false);
        goto label_47;
        label_39:
        val_32 = this.opposingPointsText;
        label_41:
        string val_21 = val_17.ToString();
        label_47:
        val_29 = "avatar";
        if((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.ContainsKey(key:  "avatar")) != false)
        {
                object val_23 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 56.Item["avatar"];
            this.opposingClubImage.sprite = this.guildAvatarHandler.GetAvatarSpriteByID(id:  19914752, portraitID:  0);
        }
        
        if(((ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44) | val_17) == 0)
        {
                return;
        }
        
        val_28 = this.playerBarImage;
        float val_28 = (float)ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44;
        val_28 = val_28 / ((float)val_17 + (ClubClashEvent.LAST_PROGRESS_STAMP_KEY + 44));
        val_28.fillAmount = UnityEngine.Mathf.Clamp(value:  val_28, min:  0.1f, max:  0.9f);
    }
    private void CollectReward(bool connected)
    {
        ClubClashEventWindow.<>c__DisplayClass46_0 val_1 = new ClubClashEventWindow.<>c__DisplayClass46_0();
        .<>4__this = this;
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Object> val_2 = ClubClashEvent.LAST_PROGRESS_STAMP_KEY.CollectReward();
        .rewardedCoins = 0;
        mem[1152921516164802572] = 0;
        if(val_2 != null)
        {
                if((val_2.ContainsKey(key:  1)) != false)
        {
                bool val_6 = System.Int32.TryParse(s:  val_2.Item[1], result: out  1152921516164802568);
        }
        
            if((val_2.ContainsKey(key:  2)) != false)
        {
                bool val_10 = System.Int32.TryParse(s:  val_2.Item[2], result: out  1152921516164802572);
        }
        
            if(.rewardedCoins <= 0)
        {
                if(mem[1152921516164802572] <= 0)
        {
            goto label_10;
        }
        
        }
        
            this.primaryButton.interactable = false;
            this.secondaryButton.interactable = false;
            mem2[0] = new System.Action(object:  this, method:  public System.Void ClubClashEventWindow::CloseWindow());
            DG.Tweening.Sequence val_12 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_12, atPosition:  0f, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void ClubClashEventWindow.<>c__DisplayClass46_0::<CollectReward>b__0()));
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_12, atPosition:  1.1f, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void ClubClashEventWindow.<>c__DisplayClass46_0::<CollectReward>b__1()));
            return;
        }
        
        label_10:
        this.CloseWindow(connected:  false);
    }
    private void LoadGameplayScene(bool connected)
    {
        var val_5;
        var val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                val_5 = 1152921504887996416;
            val_6 = null;
            val_6 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 39;
            GameBehavior val_2 = App.getBehavior;
        }
        else
        {
                GameBehavior val_3 = App.getBehavior;
            if((val_3.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
            val_7 = null;
            val_7 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 40;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void CloseWindow()
    {
        this.CloseWindow(connected:  false);
    }
    private void CloseWindow(bool connected = True)
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    private void CleanUI()
    {
        this.rewardBox.gameObject.SetActive(value:  false);
        this.infoButton.gameObject.SetActive(value:  false);
        this.infoPopup.SetActive(value:  false);
        this.playerTeamNameBox.SetActive(value:  false);
        this.opposingTeamNameBox.SetActive(value:  false);
        this.playerPointsText.gameObject.SetActive(value:  false);
        this.opposingPointsText.gameObject.SetActive(value:  false);
        this.closeButton.gameObject.SetActive(value:  false);
        this.timerParent.SetActive(value:  false);
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void ClubClashEventWindow::CloseWindow()));
        this.primaryButton.OnConnectionClick = 0;
        this.secondaryButton.OnConnectionClick = 0;
        this.primaryButton.gameObject.SetActive(value:  false);
        this.secondaryButton.gameObject.SetActive(value:  false);
        if(this.victorySystem == 0)
        {
                return;
        }
        
        this.victorySystem.gameObject.SetActive(value:  false);
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        UnityEngine.Object val_8;
        if(this.infoPopup.activeSelf == false)
        {
                return;
        }
        
        val_8 = eventData.selectedObject;
        if(val_8 == this.infoButton.gameObject)
        {
                return;
        }
        
        val_8 = this.infoPopup.gameObject;
        if(eventData.selectedObject == val_8)
        {
                return;
        }
        
        this.infoPopup.SetActive(value:  false);
    }
    public ClubClashEventWindow()
    {
        this.infoReqText = new System.Collections.Generic.List<UnityEngine.UI.Text>();
        this.infoRewardText = new System.Collections.Generic.List<UnityEngine.UI.Text>();
        this.infoRewardGoldenCurrencyText = new System.Collections.Generic.List<UnityEngine.UI.Text>();
    }

}
