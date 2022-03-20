using UnityEngine;
public class WGDailyChallengePhaseBtn : FrameSkipper
{
    // Fields
    private UGUINetworkedButton button_play;
    private UGUINetworkedButton button_retry;
    private UnityEngine.GameObject playText;
    private UnityEngine.UI.Text retryUnlockAmount;
    private UnityEngine.Sprite starFillIcon;
    private DailyChallengeStarGroup starsGroup;
    private bool isMorning;
    private bool isRetryMode;
    
    // Methods
    private void Awake()
    {
        this.button_play.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengePhaseBtn::Play(bool success));
        this.button_retry.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengePhaseBtn::Play(bool success));
    }
    private void ResetUI()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.starsGroup)) != false)
        {
                this.starsGroup.gameObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.button_retry)) != false)
        {
                this.button_retry.gameObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.button_play)) == false)
        {
                return;
        }
        
        this.button_play.gameObject.SetActive(value:  false);
    }
    private void Play(bool success)
    {
        bool val_32;
        var val_34;
        var val_35;
        System.Action val_37;
        if(success == false)
        {
            goto label_1;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.IsPlayingValid()) == false)
        {
            goto label_5;
        }
        
        WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.IsPlayingTodaysLevel()) == false)
        {
            goto label_10;
        }
        
        bool val_30 = this.isMorning;
        val_30 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() ^ ((val_30 == false) ? 1 : 0);
        val_32 = val_30;
        if((val_3.<Status>k__BackingField) != null)
        {
            goto label_11;
        }
        
        label_1:
        this.ShowConnectionRequired();
        this.ClosePopup();
        return;
        label_5:
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "RefreshDailyChallengeCalendar");
        return;
        label_10:
        val_32 = false;
        label_11:
        val_3.<Status>k__BackingField.playingPersistentLevel = val_32;
        WGDailyChallengeManager val_9 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_9.<Status>k__BackingField.playingDayMorning = this.isMorning;
        this.ClosePopup();
        if(this.isRetryMode == false)
        {
            goto label_21;
        }
        
        decimal val_11 = MonoSingleton<WGDailyChallengeManager>.Instance.GetRetryCost();
        Player val_12 = App.Player;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_12._credits, hi = val_12._credits, lo = 41963520}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid})) == false)
        {
            goto label_30;
        }
        
        val_34 = null;
        val_34 = null;
        PurchaseProxy.currentPurchasePoint = 27;
        if(WGStarterPackController.featureRelavent == false)
        {
            goto label_36;
        }
        
        WGWindowManager val_16 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterPackPopup>(showNext:  false);
        WGStarterPackController val_17 = MonoSingleton<WGStarterPackController>.Instance;
        val_17._ap = 47;
        return;
        label_21:
        MonoSingleton<WGDailyChallengeManager>.Instance.Play();
        return;
        label_30:
        DailyChallengeGameLevel val_20 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        val_20.isRetryLevel = true;
        MonoSingleton<WGDailyChallengeManager>.Instance.Play();
        decimal val_26 = System.Decimal.op_UnaryNegation(d:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid}, source:  ((MonoSingleton<WGDailyChallengeManager>.Instance.IsPlayingPersistentLevel()) != true) ? "Daily Challenge Retry" : "Daily Challenge Missed Days Retry", subSource:  0, externalParams:  0, doTrack:  true);
        return;
        label_36:
        val_35 = null;
        val_35 = null;
        val_37 = WGDailyChallengePhaseBtn.<>c.<>9__10_0;
        if(val_37 == null)
        {
                System.Action val_29 = null;
            val_37 = val_29;
            val_29 = new System.Action(object:  WGDailyChallengePhaseBtn.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGDailyChallengePhaseBtn.<>c::<Play>b__10_0());
            WGDailyChallengePhaseBtn.<>c.<>9__10_0 = val_37;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  val_29);
    }
    private void ClosePopup()
    {
        mem[1152921517809442152] = 0;
        SLCWindow.CloseWindow(window:  MonoSingleton<WGWindowManager>.Instance.GetWindow<WGDailyChallengeV2Popup>().gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private bool OnClick_OkButtonOnConnectionRequired()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
        return true;
    }
    private void ShowConnectionRequired()
    {
        int val_11;
        var val_12;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_11 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_11 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_8[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGDailyChallengePhaseBtn::OnClick_OkButtonOnConnectionRequired());
        val_8[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGDailyChallengePhaseBtn::OnClick_OkButtonOnConnectionRequired());
        val_12 = null;
        val_12 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void UpdateRetryText()
    {
        decimal val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.GetRetryCost();
        string val_3 = val_2.flags.ToString();
        if(null != null)
        {
                return;
        }
        
        mem[1152921517809907264] = 30;
        mem[1152921517809907272] = new System.Action(object:  this, method:  System.Void WGDailyChallengePhaseBtn::UpdateRetryText());
    }
    public void UpdateUIForPreviousChallenge(int stars)
    {
        this.ResetUI();
        this.starsGroup.Setup(stars:  stars);
        this.starsGroup.gameObject.SetActive(value:  true);
        this.isRetryMode = true;
        if(stars > 2)
        {
                return;
        }
        
        this.UpdateRetryText();
        this.button_retry.gameObject.SetActive(value:  true);
    }
    public void UpdateUIForTodaysChallenge()
    {
        bool val_19;
        var val_20;
        DailyChallengeSimplifiedLevel val_21;
        DailyChallengeSimplifiedLevel val_22;
        bool val_23;
        bool val_24;
        this.ResetUI();
        if(this.isMorning != false)
        {
                bool val_1 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        }
        else
        {
                bool val_2 = WGDailyChallengeManagerHelper.EveningChallengeAvailableNow();
        }
        
        val_19 = this.isMorning;
        if(val_19 != false)
        {
                val_19 = this.isMorning;
            val_20 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        }
        else
        {
                val_20 = 1;
        }
        
        if(val_19 == false)
        {
            goto label_5;
        }
        
        WGDailyChallengeManager val_4 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_21 = val_4.todaysProgress.morningChallenge;
        if(val_21 != null)
        {
            goto label_10;
        }
        
        label_5:
        WGDailyChallengeManager val_5 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_21 = val_5.todaysProgress.eveningChallenge;
        label_10:
        if(this.isMorning == false)
        {
            goto label_17;
        }
        
        WGDailyChallengeManager val_6 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_22 = val_6.todaysProgress.morningChallenge;
        if(val_22 != null)
        {
            goto label_22;
        }
        
        label_17:
        WGDailyChallengeManager val_7 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_22 = val_7.todaysProgress.eveningChallenge;
        label_22:
        this.starsGroup.Setup(stars:  1152921504893161472);
        UnityEngine.GameObject val_8 = this.starsGroup.gameObject;
        if(val_5.todaysProgress.eveningChallenge.done == false)
        {
            goto label_31;
        }
        
        val_23 = 1;
        if(val_8 != null)
        {
            goto label_32;
        }
        
        label_31:
        val_23 = ((val_20 == 0) ? 1 : 0) & (~val_2);
        label_32:
        val_8.SetActive(value:  val_23);
        if(1152921504893161472 == 3)
        {
                return;
        }
        
        if(val_2 == false)
        {
            goto label_36;
        }
        
        DailyChallengeStatus val_10 = new DailyChallengeStatus(isMorning:  this.isMorning);
        (DailyChallengeStatus)[1152921517810376224].lastPlayedLevel.isPersistentLevel = true;
        var val_11 = ((DailyChallengeStatus)[1152921517810376224].lastPlayedLevel != 0) ? 1 : 0;
        val_11 = val_11 ^ ((this.isMorning == true) ? 1 : 0);
        if((val_11 & 1) == 0)
        {
            goto label_40;
        }
        
        val_24 = 0;
        goto label_44;
        label_36:
        if(val_20 == 0)
        {
            goto label_42;
        }
        
        return;
        label_40:
        if((UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeFinished", defaultValue:  0)) != 1)
        {
            goto label_43;
        }
        
        label_42:
        val_24 = 1;
        goto label_44;
        label_43:
        val_24 = (DailyChallengeStatus)[1152921517810376224].lastPlayedLevel.done;
        label_44:
        this.isRetryMode = val_24;
        this.UpdateRetryText();
        this.button_retry.gameObject.SetActive(value:  this.isRetryMode);
        this.button_play.gameObject.SetActive(value:  (this.isRetryMode == false) ? 1 : 0);
    }
    public WGDailyChallengePhaseBtn()
    {
    
    }

}
