using UnityEngine;
public class WGMenuPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text bannerText;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.UI.Button libraryButton;
    private UnityEngine.UI.Button difficultyButton;
    private UnityEngine.UI.Button bookRewardsButton;
    private UnityEngine.UI.Button categoriesButton;
    private UnityEngine.UI.Button settingsButton;
    private UnityEngine.UI.Button helpButton;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button removeAdsButton;
    private UnityEngine.UI.Button quitButton;
    private UnityEngine.UI.Button[] buttonOrder;
    private UnityEngine.RectTransform[] rowContainers;
    private float widthTwoIcons;
    private float widthThreeIcons;
    private int maxButtonPerRow;
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
    private const string HOME_MENU_BANNER_TEXT = "MENU";
    private const string PAUSED_MENU_BANNER_TEXT = "PAUSED";
    private bool inRequest;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Events.UnityAction val_19;
        this.homeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClick_Home()));
        if(this.libraryButton != 0)
        {
                this.libraryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClick_Library()));
        }
        
        if(this.difficultyButton != 0)
        {
                this.difficultyButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClick_Difficulty()));
        }
        
        if(this.bookRewardsButton != 0)
        {
                this.bookRewardsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClick_BookRewards()));
        }
        
        if(this.categoriesButton != 0)
        {
                this.categoriesButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClick_Categories()));
        }
        
        this.settingsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClickSettingsButton()));
        this.helpButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClickHelpButton()));
        this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClickStore()));
        this.removeAdsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClickRemoveAds()));
        UnityEngine.Events.UnityAction val_14 = null;
        val_19 = val_14;
        val_14 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMenuPopup::OnClick_Quit());
        this.quitButton.m_OnClick.AddListener(call:  val_14);
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDailyChallengeDataUpdate");
        if(this.challenge_Button == 0)
        {
                return;
        }
        
        val_19 = this.challenge_Button;
        this.challenge_Button.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGMenuPopup::<Awake>b__29_0(bool success));
    }
    private void OnEnable()
    {
        var val_58;
        var val_59;
        int val_60;
        var val_61;
        var val_62;
        var val_63;
        var val_64;
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_3;
        }
        
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_6;
        }
        
        string val_6 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "paused_upper", defaultValue:  "PAUSED", useSingularKey:  false));
        this.quitButton.gameObject.SetActive(value:  false);
        UnityEngine.GameObject val_8 = this.homeButton.gameObject;
        val_58 = 1;
        goto label_15;
        label_3:
        string val_12 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "menu_upper", defaultValue:  "MENU", useSingularKey:  false));
        this.quitButton.gameObject.SetActive(value:  true);
        val_58 = 0;
        label_15:
        this.homeButton.gameObject.SetActive(value:  false);
        label_6:
        val_59 = null;
        val_59 = null;
        if(App.game == 16)
        {
                this.homeButton.gameObject.SetActive(value:  true);
        }
        
        if(this.libraryButton != 0)
        {
                this.libraryButton.gameObject.SetActive(value:  (TheLibraryLogic.LifetimeBooksEarned != 0) ? 1 : 0);
        }
        
        if(this.bookRewardsButton != 0)
        {
                this.bookRewardsButton.gameObject.SetActive(value:  (TheLibraryLogic.LifetimeBooksEarned != 0) ? 1 : 0);
        }
        
        if(this.categoriesButton == 0)
        {
            goto label_48;
        }
        
        UnityEngine.GameObject val_25 = this.categoriesButton.gameObject;
        GameBehavior val_26 = App.getBehavior;
        if((((val_26.<metaGameBehavior>k__BackingField) & 1) == 0) || (CategoryPacksManager.FeatureAvailable == false))
        {
            goto label_57;
        }
        
        GameEcon val_29 = App.getGameEcon;
        val_60 = App.Player;
        bool val_30 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_60, knobValue:  val_29.categoryUnlockLevel);
        if(val_25 != null)
        {
            goto label_64;
        }
        
        label_57:
        val_60 = 0;
        label_64:
        val_25.SetActive(value:  val_60 & 1);
        label_48:
        if(this.difficultyButton != 0)
        {
                GameEcon val_35 = App.getGameEcon;
            this.difficultyButton.gameObject.SetActive(value:  (App.Player >= val_35.difficultySettingPromptLevel) ? 1 : 0);
        }
        
        this.removeAdsButton.gameObject.SetActive(value:  AdsManager.ShowAdsControlButtons(fromSettings:  true));
        int val_64 = 0;
        val_61 = 0;
        var val_65 = 4;
        label_102:
        if((val_65 - 4) >= this.buttonOrder.Length)
        {
            goto label_81;
        }
        
        if(this.buttonOrder[0].gameObject.activeInHierarchy != false)
        {
                this.buttonOrder[0].gameObject.transform.SetParent(p:  this.rowContainers[val_64]);
            this.buttonOrder[0].gameObject.transform.SetSiblingIndex(index:  0);
            val_62 = val_61 + 1;
        }
        
        if(val_62 >= this.maxButtonPerRow)
        {
                val_64 = val_64 + 1;
            int val_48 = UnityEngine.Mathf.Min(a:  val_64, b:  this.rowContainers.Length - 1);
        }
        
        val_65 = val_65 + 1;
        if(this.buttonOrder != null)
        {
            goto label_102;
        }
        
        label_81:
        var val_67 = 0;
        label_114:
        if(val_67 >= this.rowContainers.Length)
        {
            goto label_105;
        }
        
        UnityEngine.RectTransform val_66 = this.rowContainers[val_67];
        if(val_66.childCount >= 1)
        {
                do
        {
            this.rowContainers[val_67] = val_66.GetChild(index:  0).gameObject.activeSelf;
            val_63 = 0 + this.rowContainers[val_67];
            val_64 = 0 + 1;
        }
        while(val_64 < val_66.childCount);
        
        }
        else
        {
                val_63 = 0;
        }
        
        var val_54 = (val_63 < 3) ? 128 : 132;
        UnityEngine.Rect val_55 = val_66.rect;
        UnityEngine.Vector2 val_57 = new UnityEngine.Vector2(x:  4.273228E-25f, y:  val_55.m_XMin.height);
        val_66.sizeDelta = new UnityEngine.Vector2() {x = val_57.x, y = val_57.y};
        val_66.gameObject.SetActive(value:  (val_63 > 0) ? 1 : 0);
        val_67 = val_67 + 1;
        if(this.rowContainers != null)
        {
            goto label_114;
        }
        
        throw new NullReferenceException();
        label_105:
        this.UpdateChallengeUI();
    }
    private void OnClick_Quit()
    {
        App.Quit();
    }
    private void OnClick_Home()
    {
        if(SceneDictator.IsInGameScene() != false)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Library()
    {
        var val_5;
        var val_6;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_5 = null;
            val_5 = null;
            val_6 = 58;
        }
        else
        {
                val_5 = null;
            val_5 = null;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = (SceneDictator.IsInGameScene() != true) ? (53 + 1) : 53;
        TheLibraryUI.ShowTheLibrary(onCloseAction:  0);
    }
    private void OnClick_Difficulty()
    {
        var val_6;
        System.Action val_8;
        WGWindow val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDifficultySettingPopup>(showNext:  false).GetComponent<WGWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = WGMenuPopup.<>c.<>9__34_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  WGMenuPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGMenuPopup.<>c::<OnClick_Difficulty>b__34_0());
            WGMenuPopup.<>c.<>9__34_0 = val_8;
        }
        
        mem2[0] = val_8;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_BookRewards()
    {
        var val_9;
        var val_10;
        var val_11;
        System.Action val_13;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_9 = null;
            val_9 = null;
            val_10 = 56;
        }
        else
        {
                val_9 = null;
            val_9 = null;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = (SceneDictator.IsInGameScene() != true) ? 55 : 57;
        GameBehavior val_5 = App.getBehavior;
        val_11 = null;
        val_11 = null;
        val_13 = WGMenuPopup.<>c.<>9__35_0;
        if(val_13 == null)
        {
                System.Action val_7 = null;
            val_13 = val_7;
            val_7 = new System.Action(object:  WGMenuPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGMenuPopup.<>c::<OnClick_BookRewards>b__35_0());
            WGMenuPopup.<>c.<>9__35_0 = val_13;
        }
        
        val_5.<metaGameBehavior>k__BackingField.DisplayBooksEarned(onCloseCallback:  val_7);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Categories()
    {
        var val_4 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = (SceneDictator.IsInGameScene() != true) ? (62 + 1) : 62;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        CategoryPacksMenuUI.ShowMainScreen();
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
        
        if(this.inRequest != false)
        {
                return;
        }
        
        this.inRequest = true;
        this.challenge_Button.WaitingStatus(waiting:  true);
        MonoSingleton<WGDailyChallengeManager>.Instance.RequestServerUpdate(callback:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGMenuPopup::OnComplete(bool success)));
        return;
        label_2:
        this.UpdateChallengeUI();
    }
    private void UpdateChallengeUI()
    {
        GameBehavior val_1 = App.getBehavior;
        if((((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)) || ((MonoSingleton<WGDailyChallengeManager>.Instance.FeatureAvailable) == false)) || ((MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLanguageSupported()) == false))
        {
            goto label_26;
        }
        
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_19;
        }
        
        WGDailyChallengeManager val_9 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_9.todaysProgress.morningChallenge.done == false)
        {
            goto label_32;
        }
        
        label_19:
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_26;
        }
        
        WGDailyChallengeManager val_11 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_11.todaysProgress.eveningChallenge.done == false)
        {
            goto label_32;
        }
        
        label_26:
        label_65:
        if((UnityEngine.Object.op_Implicit(exists:  this.ChallengeGroup)) != false)
        {
                this.ChallengeGroup.SetActive(value:  (0 != 0) ? 1 : 0);
        }
        
        if(0 == 0)
        {
                return;
        }
        
        bool val_14 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        var val_22 = 0;
        label_42:
        if(val_22 >= this.sun_groups.Length)
        {
            goto label_39;
        }
        
        this.sun_groups[val_22].SetActive(value:  val_14);
        val_22 = val_22 + 1;
        if(this.sun_groups != null)
        {
            goto label_42;
        }
        
        label_39:
        if(val_14 != false)
        {
                this.challenge_number_text.color = new UnityEngine.Color() {r = this.sunTextColor};
            if((UnityEngine.Object.op_Implicit(exists:  this.challenge_number_text_outline)) != false)
        {
                this.challenge_number_text_outline.effectColor = new UnityEngine.Color() {r = this.sunTextOutlineColor};
        }
        
        }
        
        bool val_17 = WGDailyChallengeManagerHelper.EveningChallengeAvailableNow();
        var val_24 = 0;
        label_54:
        if(val_24 >= this.moon_groups.Length)
        {
            goto label_51;
        }
        
        this.moon_groups[val_24].SetActive(value:  val_17);
        val_24 = val_24 + 1;
        if(this.moon_groups != null)
        {
            goto label_54;
        }
        
        label_51:
        if(val_17 == false)
        {
                return;
        }
        
        this.challenge_number_text.color = new UnityEngine.Color() {r = this.moonTextColor};
        if((UnityEngine.Object.op_Implicit(exists:  this.challenge_number_text_outline)) == false)
        {
                return;
        }
        
        this.challenge_number_text_outline.effectColor = new UnityEngine.Color() {r = this.moonTextOutlineColor};
        return;
        label_32:
        WGDailyChallengeManager val_20 = MonoSingleton<WGDailyChallengeManager>.Instance;
        goto label_65;
    }
    private void OnDailyChallengeDataUpdate()
    {
        this.UpdateChallengeUI();
    }
    private void OnClickSettingsButton()
    {
        var val_6;
        System.Action val_8;
        WGWindow val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSettingsMiniPopup>(showNext:  false).GetComponent<WGWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = WGMenuPopup.<>c.<>9__40_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  WGMenuPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGMenuPopup.<>c::<OnClickSettingsButton>b__40_0());
            WGMenuPopup.<>c.<>9__40_0 = val_8;
        }
        
        mem2[0] = val_8;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickHelpButton()
    {
        var val_6;
        System.Action val_8;
        WGWindow val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHelpMenuPopup>(showNext:  false).GetComponent<WGWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = WGMenuPopup.<>c.<>9__41_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  WGMenuPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGMenuPopup.<>c::<OnClickHelpButton>b__41_0());
            WGMenuPopup.<>c.<>9__41_0 = val_8;
        }
        
        mem2[0] = val_8;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickStore()
    {
        var val_6;
        TrackerPurchasePoints val_7;
        var val_8;
        System.Action val_10;
        if(SceneDictator.IsInGameScene() != false)
        {
                val_6 = null;
            val_6 = null;
            val_7 = 13;
        }
        else
        {
                val_6 = null;
            val_6 = null;
            val_7 = 12;
        }
        
        PurchaseProxy.currentPurchasePoint = val_7;
        val_8 = null;
        val_8 = null;
        val_10 = WGMenuPopup.<>c.<>9__42_0;
        if(val_10 == null)
        {
                System.Action val_4 = null;
            val_10 = val_4;
            val_4 = new System.Action(object:  WGMenuPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGMenuPopup.<>c::<OnClickStore>b__42_0());
            WGMenuPopup.<>c.<>9__42_0 = val_10;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  false, onCloseAction:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickRemoveAds()
    {
        HeyZapAdTag val_8;
        if(SceneDictator.IsInGameScene() != false)
        {
                WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false);
            val_8 = 13;
        }
        else
        {
                val_8 = 2;
        }
        
        WGAdsControlPopup val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false).InitEntryTag(tag:  val_8);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnComplete(bool success)
    {
        var val_6;
        var val_7;
        this.inRequest = false;
        this.challenge_Button.WaitingStatus(waiting:  false);
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_2;
        }
        
        val_6 = null;
        val_6 = null;
        val_7 = 6;
        goto label_8;
        label_2:
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_9;
        }
        
        val_6 = null;
        val_6 = null;
        val_7 = 9;
        label_8:
        AmplitudePluginHelper.lastFeatureAccessPoint = 9;
        label_9:
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGMenuPopup()
    {
        this.maxButtonPerRow = 3;
        this.widthTwoIcons = 774f;
        this.widthThreeIcons = 920f;
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.sunTextColor = val_1;
        mem[1152921517923892012] = val_1.g;
        mem[1152921517923892016] = val_1.b;
        mem[1152921517923892020] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.moonTextColor = val_2;
        mem[1152921517923892028] = val_2.g;
        mem[1152921517923892032] = val_2.b;
        mem[1152921517923892036] = val_2.a;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.5f);
        UnityEngine.Color val_4;
        this.sunTextOutlineColor = val_3.r;
        val_4 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.5f);
        this.moonTextOutlineColor = val_4.r;
        mem[1152921517923892068] = val_4.g;
        mem[1152921517923892076] = val_4.a;
    }
    private void <Awake>b__29_0(bool success)
    {
        this.OnClick_Challenge();
    }

}
