using UnityEngine;
public class UnlockableUIDailyChallenge : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.UI.Text myText;
    private UnityEngine.GameObject starsParent;
    private System.Collections.Generic.List<UnityEngine.UI.Image> starFills;
    private UnityEngine.UI.Image morningImage;
    private UnityEngine.UI.Image eveningImage;
    private UnityEngine.UI.Image availableToolTip;
    private UGUINetworkedButton netWorkedButton;
    
    // Properties
    protected override int UnlockLevel { get; }
    protected override bool FeatureHidden { get; }
    
    // Methods
    private void Awake()
    {
        this.netWorkedButton = this.GetComponent<UGUINetworkedButton>();
        val_1.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void UnlockableUIDailyChallenge::OnConnectionClicked(bool connected));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
    }
    protected override int get_UnlockLevel()
    {
        return 6;
    }
    protected override bool get_FeatureHidden()
    {
        var val_10;
        var val_11;
        val_10 = this;
        GameEcon val_1 = App.getGameEcon;
        if(((val_1.dcButtonDisplayLevel & 2147483648) == 0) && ((MonoSingleton<WGDailyChallengeManager>.Instance) != 0))
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLanguageSupported()) != false)
        {
                if(App.Player >= val_10)
        {
                return (bool)val_11;
        }
        
            val_10 = App.Player;
            GameEcon val_8 = App.getGameEcon;
            var val_9 = (val_10 < val_8.dcButtonDisplayLevel) ? 1 : 0;
            return (bool)val_11;
        }
        
        }
        
        val_11 = 1;
        return (bool)val_11;
    }
    protected override void UpdateButton()
    {
        DailyChallengeSimplifiedLevel val_16;
        if(true != 3)
        {
                return;
        }
        
        bool val_1 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        this.morningImage.gameObject.SetActive(value:  val_1);
        this.eveningImage.gameObject.SetActive(value:  (~val_1) & 1);
        this.availableToolTip.gameObject.SetActive(value:  false);
        WGDailyChallengeManager val_7 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_7.todaysProgress.morningChallenge.done == false) || (WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false))
        {
            goto label_14;
        }
        
        WGDailyChallengeManager val_9 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_16 = val_9.todaysProgress.morningChallenge;
        if(val_16 != null)
        {
            goto label_19;
        }
        
        return;
        label_14:
        WGDailyChallengeManager val_10 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_10.todaysProgress.eveningChallenge.done == false) || (WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false))
        {
            goto label_27;
        }
        
        WGDailyChallengeManager val_12 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_16 = val_12.todaysProgress.eveningChallenge;
        label_19:
        this.DisplayStars(stars:  0);
        return;
        label_27:
        if(this.myText != 0)
        {
                this.myText.gameObject.SetActive(value:  true);
        }
        
        this.starsParent.SetActive(value:  false);
        this.availableToolTip.gameObject.SetActive(value:  true);
    }
    protected override void SetNewState(WGUnlockableUIElement.UiLockedState newState)
    {
        if(newState != 2)
        {
                return;
        }
        
        bool val_1 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        this.morningImage.gameObject.SetActive(value:  val_1);
        this.eveningImage.gameObject.SetActive(value:  (~val_1) & 1);
        this.starsParent.SetActive(value:  false);
        this.availableToolTip.gameObject.SetActive(value:  false);
    }
    private void OnConnectionClicked(bool connected)
    {
        if(connected == false)
        {
            goto label_1;
        }
        
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_1.<IsDataReady>k__BackingField) == false)
        {
            goto label_5;
        }
        
        val_1.ShowDailyChallengePopup();
        return;
        label_1:
        this.ShowConnectionRequired();
        return;
        label_5:
        val_1.GetComponent<UGUINetworkedButton>().WaitingStatus(waiting:  true);
        MonoSingleton<WGDailyChallengeManager>.Instance.RequestServerUpdate(callback:  new System.Action<System.Boolean>(object:  this, method:  System.Void UnlockableUIDailyChallenge::OnComplete(bool success)));
    }
    private void ShowDailyChallengePopup()
    {
        var val_5;
        var val_6;
        FeatureAccessPoints val_7;
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_1;
        }
        
        val_5 = 1152921504887996416;
        val_6 = null;
        val_6 = null;
        val_7 = 5;
        goto label_7;
        label_1:
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_8;
        }
        
        val_5 = 1152921504887996416;
        val_6 = null;
        val_6 = null;
        val_7 = 8;
        label_7:
        AmplitudePluginHelper.lastFeatureAccessPoint = val_7;
        label_8:
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
    }
    private void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = UnlockableUIDailyChallenge.<>c.<>9__16_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  UnlockableUIDailyChallenge.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean UnlockableUIDailyChallenge.<>c::<ShowConnectionRequired>b__16_0());
            UnlockableUIDailyChallenge.<>c.<>9__16_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void DisplayStars(int stars)
    {
        var val_5;
        var val_6;
        this.starsParent.SetActive(value:  true);
        if(this.myText != 0)
        {
                this.myText.gameObject.SetActive(value:  false);
        }
        
        val_5 = 4;
        do
        {
            var val_3 = val_5 - 3;
            var val_5 = val_3 - 1;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(val_3 > (long)stars)
        {
                val_6 = 0;
        }
        else
        {
                val_6 = 1;
        }
        
            UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.gameObject.SetActive(value:  true);
            val_5 = val_5 + 1;
        }
        while(this.starFills != null);
        
        throw new NullReferenceException();
    }
    private void OnComplete(bool success)
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_1.UnregisterRequestCallback(callback:  new System.Action<System.Boolean>(object:  this, method:  System.Void UnlockableUIDailyChallenge::OnComplete(bool success)));
        UGUINetworkedButton val_3 = val_1.GetComponent<UGUINetworkedButton>();
        val_3.WaitingStatus(waiting:  false);
        if(success != false)
        {
                val_3.ShowDailyChallengePopup();
            return;
        }
        
        val_3.ShowConnectionRequired();
    }
    private void OnDestroy()
    {
        var val_5;
        null = null;
        if(App.isQuitting == true)
        {
                return;
        }
        
        val_5 = 1152921504893161472;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WGDailyChallengeManager>.Instance.UnregisterRequestCallback(callback:  new System.Action<System.Boolean>(object:  this, method:  System.Void UnlockableUIDailyChallenge::OnComplete(bool success)));
    }
    public UnlockableUIDailyChallenge()
    {
        this.starFills = new System.Collections.Generic.List<UnityEngine.UI.Image>();
    }

}
