using UnityEngine;
public class TRVExtraLifePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject rewardedVideoPopup;
    private UnityEngine.GameObject basicPopup;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button OGContinueButton;
    private UnityEngine.UI.Button getFreeLivesButton;
    private UnityEngine.UI.Text infoText;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Text extraLifeQuantityText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text OGinfoText;
    private UGUINetworkedButton extraLifeRewardedButton;
    private bool init;
    private HeyZapAdTag myTag;
    
    // Properties
    private int videosWatched { get; set; }
    
    // Methods
    private int get_videosWatched()
    {
        return CPlayerPrefs.GetInt(key:  "trvELP", defaultValue:  0);
    }
    private void set_videosWatched(int value)
    {
        CPlayerPrefs.SetInt(key:  "trvELP", val:  value);
    }
    private void OnEnable()
    {
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExtraLifePopup::OnContinueClicked()));
        this.OGContinueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExtraLifePopup::OnContinueClicked()));
        this.getFreeLivesButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExtraLifePopup::OnGetLivesClicked()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        this.extraLifeRewardedButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void TRVExtraLifePopup::OnFreeHintClick(bool result));
        string val_6 = Localization.Localize(key:  "", defaultValue:  "EARN EXTRA LIFE", useSingularKey:  false);
        TRVEcon val_8 = App.GetGameSpecificEcon<TRVEcon>();
        string val_9 = System.String.Format(format:  Localization.Localize(key:  "trv_how_to_play_pg5", defaultValue:  "Use an Extra Life if you get a question wrong. Get a free Extra Life every {0} minutes.", useSingularKey:  false), arg0:  val_8.extraLifeCoolDown);
        this.UpdatePopup();
        FrameSkipper val_11 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_11.updateLogic = new System.Action(object:  this, method:  System.Void TRVExtraLifePopup::UpdateTimerText());
        val_11._framesToSkip = 10;
    }
    public void Init(bool rewardedPopup, HeyZapAdTag tag)
    {
        var val_13;
        bool val_14;
        if(this.myTag == 0)
        {
                this.myTag = tag;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed) == false)
        {
            goto label_9;
        }
        
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_3.bonusRewardedLivesEnabled == false)
        {
            goto label_9;
        }
        
        this.rewardedVideoPopup.SetActive(value:  rewardedPopup);
        this.basicPopup.SetActive(value:  (~rewardedPopup) & 1);
        UnityEngine.GameObject val_6 = this.getFreeLivesButton.gameObject;
        TRVDataParser val_7 = MonoSingleton<TRVDataParser>.Instance;
        if((val_7.<playerPersistance>k__BackingField.TotalFreeLivesAvailable()) == 0)
        {
            goto label_17;
        }
        
        val_13 = 0;
        if(val_6 != null)
        {
            goto label_18;
        }
        
        label_9:
        this.rewardedVideoPopup.SetActive(value:  false);
        this.basicPopup.SetActive(value:  true);
        UnityEngine.GameObject val_9 = this.getFreeLivesButton.gameObject;
        val_14 = 0;
        goto label_24;
        label_17:
        label_18:
        val_14 = MonoSingletonSelfGenerating<AdsManager>.Instance.VideoEnabledAndUnlocked();
        label_24:
        val_6.SetActive(value:  val_14);
        this.init = true;
    }
    public void OnFreeHintClick(bool result)
    {
        string val_19;
        System.Boolean[] val_20;
        int val_21;
        var val_22;
        var val_23;
        var val_24;
        int val_25;
        var val_26;
        if(result == false)
        {
            goto label_1;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  this.myTag, adCapExempt:  false)) == false)
        {
            goto label_5;
        }
        
        return;
        label_1:
        GameBehavior val_3 = App.getBehavior;
        val_19 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        bool[] val_7 = new bool[2];
        val_20 = val_7;
        val_20[0] = true;
        string[] val_8 = new string[2];
        val_21 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_21 = val_8.Length;
        val_8[1] = "NULL";
        val_22 = 1152921504617017344;
        val_23 = null;
        val_23 = null;
        val_3.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  val_19, messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        string val_10 = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_24 = 0;
        goto label_24;
        label_5:
        GameBehavior val_11 = App.getBehavior;
        val_19 = Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false);
        bool[] val_15 = new bool[2];
        val_20 = val_15;
        val_20[0] = true;
        string[] val_16 = new string[2];
        val_25 = val_16.Length;
        val_16[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_25 = val_16.Length;
        val_16[1] = "NULL";
        val_22 = 1152921504617017344;
        val_26 = null;
        val_26 = null;
        val_11.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  val_19, messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_15, buttonTexts:  val_16, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        string val_18 = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_24 = 1;
        label_24:
        this.extraLifeRewardedButton.interactable = true;
    }
    private void OnContinueClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnGetLivesClicked()
    {
        this.rewardedVideoPopup.SetActive(value:  true);
        this.basicPopup.SetActive(value:  false);
    }
    private void OnVideoResponse(Notification notif)
    {
        string val_22;
        var val_23;
        string val_24;
        System.String[] val_25;
        int val_26;
        var val_27;
        val_23 = this;
        val_24 = notif.data.ToString();
        bool val_2 = System.Boolean.Parse(value:  val_24);
        if(val_2 == false)
        {
            goto label_6;
        }
        
        int val_3 = val_2.videosWatched;
        val_3.videosWatched = val_3 + 1;
        if(val_3.videosWatched >= null)
        {
            goto label_10;
        }
        
        CPlayerPrefs.Save();
        goto label_13;
        label_6:
        GameBehavior val_7 = App.getBehavior;
        val_23 = val_7.<metaGameBehavior>k__BackingField;
        val_22 = Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false);
        bool[] val_11 = new bool[2];
        val_11[0] = true;
        string[] val_12 = new string[2];
        val_25 = val_12;
        val_26 = val_12.Length;
        val_25[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_26 = val_12.Length;
        val_25[1] = "NULL";
        val_27 = null;
        val_27 = null;
        val_23.SetupMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  val_22, shownButtons:  val_11, buttonTexts:  val_12, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        return;
        label_10:
        App.GetGameSpecificEcon<WordForest.WFOGameEcon>().videosWatched = 0;
        TRVDataParser val_14 = MonoSingleton<TRVDataParser>.Instance;
        val_14.<playerPersistance>k__BackingField.AddFreeLife(addExtraLife:  false);
        val_22 = this.myTag;
        val_25 = val_22;
        mem2[0] = val_22;
        App.Player.TrackNonCoinReward(source:  val_22.ToString(), subSource:  0, rewardType:  "Extra Life", rewardAmount:  "1", additionalParams:  0);
        GameBehavior val_17 = App.getBehavior;
        label_13:
        this.UpdateTimerText();
        this.UpdatePopup();
        TRVDataParser val_19 = MonoSingleton<TRVDataParser>.Instance;
        TRVEcon val_21 = App.GetGameSpecificEcon<TRVEcon>();
        if((val_19.<playerPersistance>k__BackingField.TotalFreeLivesAvailable()) < val_21.maxExtraLives)
        {
                return;
        }
        
        this.OnContinueClicked();
    }
    private void UpdatePopup()
    {
        string val_1 = Localization.Localize(key:  "extra_life_video", defaultValue:  "Earn a free life by/n watching videos!", useSingularKey:  false);
        string val_2 = Localization.Localize(key:  "watch_#_videos", defaultValue:  "WATCH VIDEOS {0} / {1}", useSingularKey:  false);
        TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
        string val_5 = System.String.Format(format:  val_2, arg0:  val_2.videosWatched, arg1:  val_4.videosForExtraLife);
        TRVDataParser val_6 = MonoSingleton<TRVDataParser>.Instance;
        string val_8 = val_6.<playerPersistance>k__BackingField.TotalFreeLivesAvailable().ToString();
        TRVDataParser val_9 = MonoSingleton<TRVDataParser>.Instance;
        TRVEcon val_11 = App.GetGameSpecificEcon<TRVEcon>();
        if((val_9.<playerPersistance>k__BackingField.TotalFreeLivesAvailable()) < val_11.maxExtraLives)
        {
                return;
        }
        
        string val_12 = Localization.Localize(key:  "max_lives_reached_upper", defaultValue:  "MAX LIVES REACHED", useSingularKey:  false);
        this.extraLifeRewardedButton.interactable = false;
    }
    private void UpdateTimerText()
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        if((val_1.<playerPersistance>k__BackingField.freeLifeAvailable) != false)
        {
                this.timerText.gameObject.SetActive(value:  false);
            MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject).enabled = false;
            return;
        }
        
        System.DateTime val_7 = MonoSingleton<TRVMainController>.Instance.freeLifeAvailableAt;
        System.DateTime val_8 = ServerHandler.ServerTime;
        System.TimeSpan val_9 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7.dateData}, d2:  new System.DateTime() {dateData = val_8.dateData});
        string val_12 = System.String.Format(format:  "{1} {0}", arg0:  GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_9._ticks}, formatted:  true), arg1:  Localization.Localize(key:  "next_extra_life_ready", defaultValue:  "Next Extra Life Ready:", useSingularKey:  false));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
    }
    public TRVExtraLifePopup()
    {
    
    }

}
