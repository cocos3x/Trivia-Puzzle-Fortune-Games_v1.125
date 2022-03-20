using UnityEngine;
public class WGChallengeProgressDisplay : MonoBehaviour
{
    // Fields
    private WGChallengeDefinition.PerChallengeInfo myInfo;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Text buttonCoinValueText;
    private UnityEngine.UI.Image challengeImage;
    private UnityEngine.UI.Image progressBar;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Text challengeNameText;
    private UnityEngine.GameObject fillBarParentObject;
    private bool inRequest;
    private UGUINetworkedButton challenge_Button;
    private UnityEngine.Transform parentPopup;
    
    // Properties
    public ChallengeType getType { get; }
    public UnityEngine.UI.Button getButton { get; }
    
    // Methods
    public ChallengeType get_getType()
    {
        if(this.myInfo != null)
        {
                return (ChallengeType)this.myInfo.cType;
        }
        
        throw new NullReferenceException();
    }
    public UnityEngine.UI.Button get_getButton()
    {
        return (UnityEngine.UI.Button)this.collectButton;
    }
    public void Init(ChallengeTask myDatas, UnityEngine.Transform myPopup, WGChallengeDefinition.PerChallengeInfo incInfo)
    {
        UnityEngine.UI.Text val_27;
        IntPtr val_29;
        this.myInfo = incInfo;
        this.parentPopup = myPopup;
        this.collectButton.gameObject.SetActive(value:  myDatas.isComplete());
        this.fillBarParentObject.SetActive(value:  (~myDatas.isComplete()) & 1);
        WGChallengeController val_6 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
        string val_7 = val_6._challengeReward.ToString();
        this.challengeImage.sprite = this.myInfo.image;
        string val_8 = Localization.Localize(key:  this.myInfo.displayNameLocKey, defaultValue:  this.myInfo.displayName, useSingularKey:  false);
        this.progressBar.fillAmount = myDatas.getPercent();
        val_27 = this.progressText;
        string val_10 = System.String.Format(format:  "{0}/{1}", arg0:  myDatas.progress, arg1:  myDatas.target);
        this.challenge_Button.gameObject.SetActive(value:  this.myInfo.usesButton);
        if(myDatas.id == 3)
        {
                this.challenge_Button.gameObject.SetActive(value:  false);
            val_27 = 1152921504893161472;
            if((MonoSingleton<WGDailyChallengeManager>.Instance.FeatureAvailable) == false)
        {
                return;
        }
        
            if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
            WGDailyChallengeManager val_17 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_17.PlayingMorning == true)
        {
                return;
        }
        
            if(val_17.PlayingEvening == true)
        {
                return;
        }
        
            if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != true)
        {
                if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
                return;
        }
        
        }
        
            if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != false)
        {
                WGDailyChallengeManager val_21 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_21.todaysProgress.morningChallenge.done != true)
        {
                this.challenge_Button.gameObject.SetActive(value:  true);
        }
        
        }
        
            if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() != false)
        {
                WGDailyChallengeManager val_24 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_24.todaysProgress.eveningChallenge.done != true)
        {
                this.challenge_Button.gameObject.SetActive(value:  true);
        }
        
        }
        
            val_27 = this.challenge_Button;
            val_29 = 1152921516008890208;
        }
        else
        {
                if(myDatas.subject != 5)
        {
                if(myDatas.subject != 4)
        {
                return;
        }
        
            val_27 = this.challenge_Button;
            val_29 = 1152921516008903520;
        }
        else
        {
                val_27 = this.challenge_Button;
            System.Action<System.Boolean> val_26 = null;
            val_29 = 1152921516008912736;
        }
        
        }
        
        val_26 = new System.Action<System.Boolean>(object:  this, method:  val_29);
        this.challenge_Button.OnConnectionClick = val_26;
    }
    private void OnDailyChallengePressed(bool connected)
    {
        if(connected == false)
        {
            goto label_1;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.FeatureAvailable) == false)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_11;
        }
        
        WGDailyChallengeManager val_6 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_6.todaysProgress.morningChallenge.done == false)
        {
            goto label_17;
        }
        
        label_11:
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
                return;
        }
        
        WGDailyChallengeManager val_8 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_8.todaysProgress.eveningChallenge.done == true)
        {
                return;
        }
        
        label_17:
        WGDailyChallengeManager val_9 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_9.<IsDataReady>k__BackingField) == false)
        {
                return;
        }
        
        if(this.inRequest == false)
        {
            goto label_29;
        }
        
        return;
        label_1:
        this.ShowInternetConnection();
        return;
        label_29:
        this.inRequest = true;
        val_10.currentRequestCallback = new System.Action<System.Boolean>(object:  this, method:  System.Void WGChallengeProgressDisplay::OnComplete(bool success));
        MonoSingleton<WGDailyChallengeManager>.Instance.DoRequest();
    }
    private void OnTwitterButtonPressed(bool connected)
    {
        if(connected != false)
        {
                AppConfigs val_1 = App.Configuration;
            AppConfigs val_2 = App.Configuration;
            twelvegigs.plugins.SharePlugin.ShareTwitter(message:  val_1.gameConfig.twitterViralText, url:  val_2.gameConfig.twitterInviteURL);
            TrackingComponent.CurrentIntent = 9;
            if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnTweetSent();
        }
        
            this.parentPopup.GetComponent<WGChallengeWindow>().SetupUI();
            return;
        }
        
        this.ShowInternetConnection();
    }
    private void OnShareButtonPressed(bool connected)
    {
        if(connected != false)
        {
                WGInvite val_1 = WGInviteManager.ShowInvitePopup(status:  0);
            SLCWindow.CloseWindow(window:  this.parentPopup.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        this.ShowInternetConnection();
    }
    private void ShowInternetConnection()
    {
        int val_11;
        var val_12;
        System.Func<System.Boolean> val_14;
        var val_15;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_11 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_11 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_12 = null;
        val_12 = null;
        val_14 = WGChallengeProgressDisplay.<>c.<>9__19_0;
        if(val_14 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_14 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  WGChallengeProgressDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGChallengeProgressDisplay.<>c::<ShowInternetConnection>b__19_0());
            WGChallengeProgressDisplay.<>c.<>9__19_0 = val_14;
        }
        
        val_8[0] = val_14;
        val_15 = null;
        val_15 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.parentPopup.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnComplete(bool success)
    {
        this.inRequest = false;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
        SLCWindow.CloseWindow(window:  this.parentPopup.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGChallengeProgressDisplay()
    {
    
    }

}
