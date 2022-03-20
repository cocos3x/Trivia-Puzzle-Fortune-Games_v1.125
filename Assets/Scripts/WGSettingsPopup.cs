using UnityEngine;
public class WGSettingsPopup : MonoBehaviour
{
    // Fields
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private UnityEngine.UI.Text titleText;
    private UnityEngine.UI.Button Button_Rate;
    private UnityEngine.UI.Button Button_NoAds;
    private UnityEngine.GameObject adsOn;
    private UnityEngine.GameObject adsOff;
    private UnityEngine.UI.Button Button_Home;
    private UnityEngine.UI.Button Button_Help;
    private UnityEngine.UI.Button Button_HowToPlay;
    private UnityEngine.UI.Button Button_Quit;
    private UnityEngine.UI.Button Button_Languages;
    private UnityEngine.GameObject topGrid;
    private UnityEngine.GameObject midGrid;
    private UnityEngine.GameObject bottomGrid;
    private UGUINetworkedButton Button_FbConnect;
    private UGUINetworkedButton Button_FbShare;
    private UnityEngine.GameObject FbConnectRewardGroup;
    private UnityEngine.UI.Text FbConnectRewardAmount;
    private UnityEngine.UI.Text version_info;
    private UnityEngine.UI.Text supportId_text;
    private UnityEngine.GameObject ChallengeGroup;
    private UnityEngine.GameObject[] sun_groups;
    private UnityEngine.GameObject[] moon_groups;
    private UnityEngine.UI.Text challenge_number_text;
    private UGUINetworkedButton challenge_Button;
    private UnityEngine.Color sunTextColor;
    private UnityEngine.Color moonTextColor;
    private UnityEngine.UI.Outline challenge_number_text_outline;
    private UnityEngine.Color sunTextOutlineColor;
    private UnityEngine.Color moonTextOutlineColor;
    private UnityEngine.RectTransform parentXfm;
    private bool isFbCherry;
    
    // Methods
    private void OnEnable()
    {
        var val_45;
        bool val_46;
        UnityEngine.RectTransform val_47;
        if(SceneDictator.IsInGameScene() != false)
        {
                string val_5 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "paused_upper", defaultValue:  "PAUSED", useSingularKey:  false));
            if((UnityEngine.Object.op_Implicit(exists:  this.Button_HowToPlay)) != false)
        {
                this.Button_HowToPlay.transform.SetParent(p:  this.midGrid.transform);
        }
        
            this.Button_Home.gameObject.SetActive(value:  true);
            UnityEngine.GameObject val_10 = this.Button_Quit.gameObject;
            val_45 = 0;
        }
        else
        {
                string val_14 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "settings_upper", defaultValue:  "SETTINGS", useSingularKey:  false));
            if((UnityEngine.Object.op_Implicit(exists:  this.Button_HowToPlay)) != false)
        {
                this.Button_HowToPlay.transform.SetParent(p:  this.topGrid.transform);
        }
        
            this.Button_Home.gameObject.SetActive(value:  false);
            val_45 = 1;
        }
        
        this.Button_Quit.gameObject.SetActive(value:  true);
        this.Button_Rate.gameObject.SetActive(value:  false);
        string val_21 = DeviceIdPlugin.GetClientVersion();
        Player val_22 = App.Player;
        this.Button_Rate.interactable = WGReviewManager.CanShow;
        this.Button_NoAds.gameObject.SetActive(value:  AdsManager.ShowAdsControlButtons(fromSettings:  false));
        if(AdsManager.isInVideoCooldown != false)
        {
                val_46 = 0;
        }
        else
        {
                val_46 = AdsManager.isInPurchaseCooldown ^ 1;
        }
        
        this.adsOff.SetActive(value:  (~val_46) & 1);
        this.adsOn.SetActive(value:  val_46);
        this.SetFacebookButtons();
        this.UpdateChallengeUI();
        if(this.parentXfm == 0)
        {
                UnityEngine.RectTransform val_35 = this.ChallengeGroup.transform.parent.GetComponent<UnityEngine.RectTransform>();
            val_47 = val_35;
            this.parentXfm = val_35;
        }
        else
        {
                val_47 = this.parentXfm;
        }
        
        if((MonoSingleton<AdsUIController>.Instance) == 0)
        {
            goto label_66;
        }
        
        float val_44 = 0.5f;
        val_44 = (MonoSingleton<AdsUIController>.Instance.GetBannerAdHeight()) * val_44;
        UnityEngine.Vector3 val_40 = new UnityEngine.Vector3(x:  0f, y:  val_44, z:  0f);
        if(val_47 != null)
        {
            goto label_70;
        }
        
        label_66:
        UnityEngine.Vector3 val_41 = UnityEngine.Vector3.zero;
        label_70:
        val_47.localPosition = new UnityEngine.Vector3() {x = val_41.x, y = val_41.y, z = val_41.z};
        UnityEngine.Coroutine val_43 = this.StartCoroutine(routine:  this.UpdateLayout());
    }
    private void Awake()
    {
        UGUINetworkedButton val_16;
        this.Button_Rate.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_Rate()));
        this.Button_Home.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_Home()));
        this.Button_NoAds.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_NoAds()));
        this.Button_Help.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_Help()));
        if((UnityEngine.Object.op_Implicit(exists:  this.Button_HowToPlay)) != false)
        {
                this.Button_HowToPlay.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_HowToPlay()));
        }
        
        this.Button_Quit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_Quit()));
        this.Button_FbConnect.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsPopup::OnClick_FbConnect(bool result));
        val_16 = this.Button_FbShare;
        this.Button_FbShare.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsPopup::OnClick_FbShare(bool result));
        if(this.Button_Languages != 0)
        {
                UnityEngine.Events.UnityAction val_11 = null;
            val_16 = val_11;
            val_11 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsPopup::OnClick_Languages());
            this.Button_Languages.m_OnClick.AddListener(call:  val_11);
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDailyChallengeDataUpdate");
        if(this.challenge_Button == 0)
        {
                return;
        }
        
        val_16 = this.challenge_Button;
        this.challenge_Button.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsPopup::<Awake>b__33_0(bool success));
    }
    private void OnFacebookPluginUpdate(Notification notification)
    {
        var val_8;
        int val_9;
        if((this.isFbCherry != false) && (FacebookPlugin.IsLoggedIn != false))
        {
                this.isFbCherry = false;
            val_8 = 1152921504884269056;
            GameEcon val_2 = App.getGameEcon;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_2.fbConnectBonus, hi = val_2.fbConnectBonus, lo = X21, mid = X21}, source:  "FB Connect Bonus", externalParams:  0, animated:  false);
            if(this.coinsAnim != 0)
        {
                this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGSettingsPopup::OnCoinsAnimFinished());
            Player val_5 = App.Player;
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = 1152921504884269056}, d2:  new System.Decimal() {flags = val_2.fbConnectBonus, hi = val_2.fbConnectBonus, lo = X21, mid = X21});
            val_9 = val_6.lo;
            Player val_7 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_9, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        }
        
        }
        
        this.SetFacebookButtons();
    }
    private void OnCoinsAnimFinished()
    {
    
    }
    private void SetFacebookButtons()
    {
        var val_29;
        var val_30;
        var val_31;
        this.Button_FbConnect.gameObject.SetActive(value:  false);
        this.Button_FbShare.gameObject.SetActive(value:  false);
        Player val_3 = App.Player;
        this.isFbCherry = System.String.IsNullOrEmpty(value:  val_3.properties.online_fb_id);
        GameBehavior val_6 = App.getBehavior;
        if(((val_6.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_29 = FacebookPlugin.TaskAvailable(taskToCheck:  1);
        }
        else
        {
                val_29 = 0;
        }
        
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_30 = FacebookPlugin.IsLoggedIn;
        }
        else
        {
                val_30 = 0;
        }
        
        this.Button_FbConnect.gameObject.SetActive(value:  false);
        if(val_29 == 0)
        {
            goto label_25;
        }
        
        var val_11 = (this.isFbCherry == true) ? 1 : 0;
        if(this.FbConnectRewardGroup != null)
        {
            goto label_26;
        }
        
        label_25:
        val_31 = 0;
        label_26:
        this.FbConnectRewardGroup.SetActive(value:  false);
        GameEcon val_12 = App.getGameEcon;
        GameEcon val_13 = App.getGameEcon;
        string val_14 = val_12.fbConnectBonus.ToString(format:  val_13.numberFormatInt);
        this.Button_FbShare.gameObject.SetActive(value:  val_30 & 1);
        if(this.Button_FbConnect.gameObject.activeSelf == true)
        {
                return;
        }
        
        if(this.Button_FbShare.gameObject.activeSelf != false)
        {
                return;
        }
        
        if(this.Button_Languages != 0)
        {
                if(this.Button_Languages.gameObject.activeSelf == true)
        {
                return;
        }
        
        }
        
        this.Button_FbConnect.transform.parent.gameObject.SetActive(value:  false);
        UnityEngine.Coroutine val_28 = this.StartCoroutine(routine:  this.UpdateLayout());
    }
    private System.Collections.IEnumerator UpdateLayout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGSettingsPopup.<UpdateLayout>d__37();
    }
    private void OnDailyChallengeDataUpdate()
    {
        this.UpdateChallengeUI();
    }
    private void UpdateChallengeUI()
    {
        var val_18;
        var val_19;
        val_18 = 1152921504893161472;
        if((((MonoSingleton<WGDailyChallengeManager>.Instance.FeatureAvailable) != false) && ((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)) && ((MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLanguageSupported()) != false))
        {
                if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != true)
        {
                if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_15;
        }
        
        }
        
            val_19 = (~(MonoSingleton<WGDailyChallengeManager>.Instance.CurrentChallengeComplete())) & 1;
        }
        else
        {
                label_15:
            val_19 = 0;
        }
        
        this.ChallengeGroup.SetActive(value:  false);
        if(val_19 == 0)
        {
                return;
        }
        
        bool val_11 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        var val_18 = 0;
        label_26:
        if(val_18 >= this.sun_groups.Length)
        {
            goto label_23;
        }
        
        this.sun_groups[val_18].SetActive(value:  val_11);
        val_18 = val_18 + 1;
        if(this.sun_groups != null)
        {
            goto label_26;
        }
        
        label_23:
        if(val_11 != false)
        {
                this.challenge_number_text.color = new UnityEngine.Color() {r = this.sunTextColor};
            if((UnityEngine.Object.op_Implicit(exists:  this.challenge_number_text_outline)) != false)
        {
                this.challenge_number_text_outline.effectColor = new UnityEngine.Color() {r = this.sunTextOutlineColor};
        }
        
        }
        
        bool val_14 = WGDailyChallengeManagerHelper.EveningChallengeAvailableNow();
        val_18 = 0;
        label_38:
        if(val_18 >= this.moon_groups.Length)
        {
            goto label_35;
        }
        
        this.moon_groups[val_18].SetActive(value:  val_14);
        val_18 = val_18 + 1;
        if(this.moon_groups != null)
        {
            goto label_38;
        }
        
        label_35:
        if(val_14 == false)
        {
                return;
        }
        
        this.challenge_number_text.color = new UnityEngine.Color() {r = this.moonTextColor};
        if((UnityEngine.Object.op_Implicit(exists:  this.challenge_number_text_outline)) == false)
        {
                return;
        }
        
        this.challenge_number_text_outline.effectColor = new UnityEngine.Color() {r = this.moonTextOutlineColor};
    }
    private void OnClick_Rate()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGReviewPopup>(showNext:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_NoAds()
    {
        var val_8;
        System.Action val_10;
        WGAdsControlPopup val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false).InitEntryTag(tag:  (SceneDictator.IsInGameScene() != true) ? 13 : 2);
        val_8 = null;
        val_8 = null;
        val_10 = WGSettingsPopup.<>c.<>9__41_0;
        if(val_10 == null)
        {
                System.Action val_6 = null;
            val_10 = val_6;
            val_6 = new System.Action(object:  WGSettingsPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSettingsPopup.<>c::<OnClick_NoAds>b__41_0());
            WGSettingsPopup.<>c.<>9__41_0 = val_10;
        }
        
        val_5.Action_OnClose = val_10;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Home()
    {
        GameBehavior val_1 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Help()
    {
        MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.ShowFAQs();
    }
    private void OnClick_HowToPlay()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHowToPlayPopup>(showNext:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Quit()
    {
        App.Quit();
    }
    private void OnClick_FbConnect(bool result)
    {
        int val_12;
        var val_13;
        System.Func<System.Boolean> val_15;
        var val_16;
        if(result != false)
        {
                if((FacebookPlugin.TaskAvailable(taskToCheck:  1)) == false)
        {
                return;
        }
        
            TrackingComponent.CurrentIntent = 4;
            FacebookPlugin.PerformTask(task:  1);
            return;
        }
        
        bool[] val_6 = new bool[2];
        val_6[0] = true;
        string[] val_7 = new string[2];
        val_12 = val_7.Length;
        val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_7.Length;
        val_7[1] = "NULL";
        System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
        val_13 = null;
        val_13 = null;
        val_15 = WGSettingsPopup.<>c.<>9__46_0;
        if(val_15 == null)
        {
                System.Func<System.Boolean> val_10 = null;
            val_15 = val_10;
            val_10 = new System.Func<System.Boolean>(object:  WGSettingsPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGSettingsPopup.<>c::<OnClick_FbConnect>b__46_0());
            WGSettingsPopup.<>c.<>9__46_0 = val_15;
        }
        
        val_9[0] = val_15;
        val_16 = null;
        val_16 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_FbShare(bool result)
    {
        int val_12;
        var val_13;
        System.Func<System.Boolean> val_15;
        var val_16;
        if(result != false)
        {
                MonoSingletonSelfGenerating<WGScreenshotter>.Instance.ShareDefault();
            return;
        }
        
        bool[] val_6 = new bool[2];
        val_6[0] = true;
        string[] val_7 = new string[2];
        val_12 = val_7.Length;
        val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_7.Length;
        val_7[1] = "NULL";
        System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
        val_13 = null;
        val_13 = null;
        val_15 = WGSettingsPopup.<>c.<>9__47_0;
        if(val_15 == null)
        {
                System.Func<System.Boolean> val_10 = null;
            val_15 = val_10;
            val_10 = new System.Func<System.Boolean>(object:  WGSettingsPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGSettingsPopup.<>c::<OnClick_FbShare>b__47_0());
            WGSettingsPopup.<>c.<>9__47_0 = val_15;
        }
        
        val_9[0] = val_15;
        val_16 = null;
        val_16 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Challenge()
    {
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != true)
        {
                if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_2;
        }
        
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_2:
        this.UpdateChallengeUI();
    }
    private void OnClick_Languages()
    {
        var val_8;
        System.Action val_10;
        WGWindow val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLanguageSelectPopup>(showNext:  false).GetComponent<WGWindow>();
        val_8 = null;
        val_8 = null;
        val_10 = WGSettingsPopup.<>c.<>9__49_0;
        if(val_10 == null)
        {
                System.Action val_4 = null;
            val_10 = val_4;
            val_4 = new System.Action(object:  WGSettingsPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSettingsPopup.<>c::<OnClick_Languages>b__49_0());
            WGSettingsPopup.<>c.<>9__49_0 = val_10;
        }
        
        mem2[0] = val_10;
        this.transform.parent.gameObject.SetActive(value:  false);
    }
    public WGSettingsPopup()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.sunTextColor = val_1;
        mem[1152921517972424372] = val_1.g;
        mem[1152921517972424376] = val_1.b;
        mem[1152921517972424380] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.moonTextColor = val_2;
        mem[1152921517972424388] = val_2.g;
        mem[1152921517972424392] = val_2.b;
        mem[1152921517972424396] = val_2.a;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.5f);
        UnityEngine.Color val_4;
        mem2[0] = val_3.r;
        val_4 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.5f);
        mem2[0] = val_4.r;
    }
    private void <Awake>b__33_0(bool success)
    {
        this.OnClick_Challenge();
    }

}
