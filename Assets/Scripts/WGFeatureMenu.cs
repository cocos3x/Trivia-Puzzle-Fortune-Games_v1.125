using UnityEngine;
public class WGFeatureMenu : MonoBehaviour
{
    // Fields
    public LevelCompletePopup levelCompletePopup;
    protected UnityEngine.Transform menuItemParent;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.UI.Button settingsButton;
    private UnityEngine.UI.Button helpButton;
    private UnityEngine.UI.Button restoreButton;
    private TournamentsButton tournamentsButton;
    private UnityEngine.UI.Text homeButtonText;
    protected UnityEngine.Sprite dailyChallengeSprite;
    protected UnityEngine.Sprite eventSprite;
    protected UnityEngine.Sprite leaguesSprite;
    protected UnityEngine.Sprite categoriesSprite;
    protected UnityEngine.Sprite librarySprite;
    protected UnityEngine.Sprite bookRewardSprite;
    protected UnityEngine.Sprite difficultySprite;
    protected UnityEngine.Sprite adControlSprite;
    protected UnityEngine.Sprite moreGamesSprite;
    protected UnityEngine.Sprite wordIQSprite;
    protected UnityEngine.Sprite wadPetsSprite;
    protected UnityEngine.Sprite wadPetsActionableFood;
    protected UnityEngine.Sprite wadPetsActionableUpgrade;
    public System.Action OnNonHomeCloseAction;
    
    // Properties
    private FeatureMenuItem MenuItemPrefab { get; }
    private TournamentsButton TournamentsMenuItemPrefab { get; }
    
    // Methods
    private FeatureMenuItem get_MenuItemPrefab()
    {
        return PrefabLoader.LoadPrefab<FeatureMenuItem>(featureName:  "FeatureMenu");
    }
    private TournamentsButton get_TournamentsMenuItemPrefab()
    {
        return PrefabLoader.LoadPrefab<TournamentsButton>(featureName:  "FeatureMenu");
    }
    private void OnEnable()
    {
        object val_16;
        UnityEngine.Events.UnityAction val_17;
        val_16 = this;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFeatureMenu::Close()));
        this.settingsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFeatureMenu::OnClickSettings()));
        this.helpButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFeatureMenu::OnClickHelp()));
        if((UnityEngine.Object.op_Implicit(exists:  this.restoreButton)) != false)
        {
                this.restoreButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFeatureMenu::OnClickRestore()));
        }
        
        UnityEngine.Events.UnityAction val_6 = null;
        val_17 = val_6;
        val_6 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFeatureMenu::OnClickHome());
        this.homeButton.m_OnClick.AddListener(call:  val_6);
        string val_7 = Localization.Localize(key:  "home_upper", defaultValue:  "HOME", useSingularKey:  false);
        GameBehavior val_8 = App.getBehavior;
        if((val_8.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        string val_9 = Localization.Localize(key:  "quit_upper", defaultValue:  "QUIT", useSingularKey:  false);
        val_16 = ???;
        val_17 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void Start()
    {
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void WGFeatureMenu::Close()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void WGFeatureMenu::Close()));
    }
    protected FeatureMenuItem getNewItem()
    {
        return UnityEngine.Object.Instantiate<FeatureMenuItem>(original:  this.MenuItemPrefab, parent:  this.menuItemParent, worldPositionStays:  false);
    }
    protected virtual void SetupMenuItems()
    {
        if(this.menuItemParent == 0)
        {
                return;
        }
        
        this.SetupDailyChallenge();
        this.SetupLeaguesItem();
        this.SetupWADPets();
        this.SetupCategories();
        this.SetupBookRewards();
        this.SetupDifficulty();
        bool val_2 = AdsManager.ShowAdsControlMenuItem();
        this.SetupMoreGames();
        this.SetupSpecialTournamentsButton();
    }
    private bool HasNoInternet()
    {
        string val_11;
        var val_12;
        var val_13;
        int val_14;
        var val_15;
        val_12 = null;
        val_12 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                val_13 = 0;
            return (bool)val_13;
        }
        
        val_11 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_14 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_14 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_8[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGFeatureMenu::<HasNoInternet>b__32_0());
        val_15 = null;
        val_15 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  val_11, messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        val_13 = 1;
        return (bool)val_13;
    }
    private void OnClickHome()
    {
        if(this.levelCompletePopup != 0)
        {
                SLCWindow val_2 = this.GetComponent<SLCWindow>();
            System.Delegate val_4 = System.Delegate.Remove(source:  val_2.Action_OnClose, value:  new System.Action(object:  this.levelCompletePopup, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            val_2.Action_OnClose = val_4;
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  MonoSingleton<WGWindowManager>.Instance, callback:  new System.Action(object:  this, method:  System.Void WGFeatureMenu::<OnClickHome>b__33_0()), count:  1);
        }
        
        GameBehavior val_7 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_6:
    }
    private void OnClickSettings()
    {
        if(this.levelCompletePopup != 0)
        {
                SLCWindow val_2 = this.GetComponent<SLCWindow>();
            System.Delegate val_4 = System.Delegate.Remove(source:  val_2.Action_OnClose, value:  new System.Action(object:  this.levelCompletePopup, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            val_2.Action_OnClose = val_4;
        }
        
        WGWindow val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSettingsMiniPopup>(showNext:  false).GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  this, method:  System.Void WGFeatureMenu::<OnClickSettings>b__34_0());
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_6:
    }
    private void OnClickHelp()
    {
        if(this.levelCompletePopup != 0)
        {
                SLCWindow val_2 = this.GetComponent<SLCWindow>();
            System.Delegate val_4 = System.Delegate.Remove(source:  val_2.Action_OnClose, value:  new System.Action(object:  this.levelCompletePopup, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            val_2.Action_OnClose = val_4;
        }
        
        WGWindow val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHelpMenuPopup>(showNext:  false).GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  this, method:  System.Void WGFeatureMenu::<OnClickHelp>b__35_0());
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_6:
    }
    private void OnClickRestore()
    {
        if(this.levelCompletePopup != 0)
        {
                SLCWindow val_2 = this.GetComponent<SLCWindow>();
            System.Delegate val_4 = System.Delegate.Remove(source:  val_2.Action_OnClose, value:  new System.Action(object:  this.levelCompletePopup, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            val_2.Action_OnClose = val_4;
        }
        
        WGWindow val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGRestoreProgressionPopup>(showNext:  false).GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  this, method:  System.Void WGFeatureMenu::<OnClickRestore>b__36_0());
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_6:
    }
    protected void SetupDailyChallenge()
    {
        System.Action val_21;
        bool val_22;
        val_21 = 1152921504765632512;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLanguageSupported()) == false)
        {
                return;
        }
        
        WGFeatureMenu.FeatureMenuItemConfig val_5 = new WGFeatureMenu.FeatureMenuItemConfig();
        .enabled = (App.Player > 5) ? 1 : 0;
        if(((MonoSingleton<WGDailyChallengeManager>.Instance) == 0) || ((MonoSingleton<WGDailyChallengeManager>.Instance.FeatureAvailable) == false))
        {
            goto label_30;
        }
        
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != false)
        {
                WGDailyChallengeManager val_13 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_13.todaysProgress.morningChallenge.done == false)
        {
            goto label_45;
        }
        
        }
        
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_30;
        }
        
        WGDailyChallengeManager val_15 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_22 = val_15.todaysProgress.eveningChallenge.done ^ 1;
        goto label_45;
        label_30:
        val_22 = false;
        label_45:
        .featureActionable = val_22;
        System.Action val_16 = null;
        val_21 = val_16;
        val_16 = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickDailyChallenge());
        .onClickAction = val_21;
        .itemSprite = this.dailyChallengeSprite;
        .featureNameText = Localization.Localize(key:  "daily_challenge_upper", defaultValue:  "Daily Challenge", useSingularKey:  false);
        .featureUnlockLevel = 6;
        FeatureMenuItem val_18 = this.getNewItem();
        WGDailyChallengeManager val_19 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_19.<IsDataReady>k__BackingField) != false)
        {
                return;
        }
        
        MonoSingleton<WGDailyChallengeManager>.Instance.RequestServerUpdate(callback:  0);
    }
    private void OnClickDailyChallenge()
    {
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        if(this.HasNoInternet() != false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 1)
        {
                val_8 = null;
            val_9 = 8;
            val_10 = 5;
        }
        else
        {
                val_8 = null;
            val_9 = 9;
            val_10 = 6;
        }
        
        val_11 = null;
        val_11 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = (WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != true) ? (val_10) : 9;
        if(this.levelCompletePopup != 0)
        {
                this.levelCompletePopup.OpenStackingMonolith<WGDailyChallengeV2Popup>();
        }
        else
        {
                WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
        }
        
        this.Close();
    }
    protected virtual void SetupEventsItem()
    {
        object val_12;
        WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
        GameBehavior val_2 = App.getBehavior;
        .enabled = (val_2.<metaGameBehavior>k__BackingField) & 1;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickEventsItem());
        .itemSprite = this.eventSprite;
        if((WGFeatureMenu.FeatureMenuItemConfig)[1152921516208422448].enabled != false)
        {
                val_12 = MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount.ToString();
        }
        else
        {
                val_12 = "";
        }
        
        .featureNameText = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "events_upper", defaultValue:  "EVENTS", useSingularKey:  false), arg1:  val_12);
        GameEcon val_10 = App.getGameEcon;
        .featureUnlockLevel = val_10.events_unlockLevel;
        FeatureMenuItem val_11 = this.getNewItem();
    }
    protected void OnClickEventsItem()
    {
        if(this.HasNoInternet() != false)
        {
                return;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGEventsListPopup>(showNext:  false);
        this.Close();
    }
    protected void SetupLeaguesItem()
    {
        var val_15;
        bool val_16;
        WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
        GameEcon val_3 = App.getGameEcon;
        .enabled = (App.Player >= val_3.leaguesUnlockLevel) ? 1 : 0;
        if((SLC.Social.Leagues.LeaguesManager.IsAvailable() != false) && (SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null))
        {
                SLC.Social.Leagues.LeaguesDataController val_8 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_15 = null;
            val_15 = null;
            val_16 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_8.SeasonRewardAmount, hi = val_8.SeasonRewardAmount, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        }
        else
        {
                val_16 = false;
        }
        
        .featureActionable = val_16;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickLeagueItem());
        .itemSprite = this.leaguesSprite;
        .featureNameText = Localization.Localize(key:  "the_league_upper", defaultValue:  "The League", useSingularKey:  false);
        GameEcon val_12 = App.getGameEcon;
        .featureUnlockLevel = val_12.leaguesUnlockLevel;
        FeatureMenuItem val_13 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickLeagueItem()
    {
        var val_4;
        if(this.HasNoInternet() != false)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 93;
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesLoadingPopup>(showNext:  false);
        this.Close();
    }
    protected void SetupCategories()
    {
        if((MonoSingleton<CategoryPacksManager>.Instance) == 0)
        {
                return;
        }
        
        if(CategoryPacksManager.FeatureAvailable == false)
        {
                return;
        }
        
        WGFeatureMenu.FeatureMenuItemConfig val_4 = new WGFeatureMenu.FeatureMenuItemConfig();
        GameEcon val_6 = App.getGameEcon;
        .enabled = (App.Player >= val_6.categoryUnlockLevel) ? 1 : 0;
        CategoryPacksManager val_8 = MonoSingleton<CategoryPacksManager>.Instance;
        .featureActionable = val_8.hasNewlyDiscoveredPacks;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickCategories());
        .itemSprite = this.categoriesSprite;
        .featureNameText = Localization.Localize(key:  "categories_upper", defaultValue:  "CATEGORIES", useSingularKey:  false);
        GameEcon val_11 = App.getGameEcon;
        .featureUnlockLevel = val_11.categoryUnlockLevel;
        FeatureMenuItem val_12 = this.getNewItem();
        this = ???;
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickCategories()
    {
        var val_3;
        GameBehavior val_1 = App.getBehavior;
        val_3 = null;
        val_3 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((val_1.<metaGameBehavior>k__BackingField) == 1) ? 61 : 63;
        CategoryPacksMenuUI.ShowMainScreen();
        this.Close();
    }
    protected void SetupLibrary()
    {
        var val_18;
        var val_19;
        val_18 = 0;
        val_19 = 0;
        System.Collections.Generic.List<BookInfo> val_9 = TheLibraryLogic.PurchasableBooks;
        WGFeatureMenu.FeatureMenuItemConfig val_10 = new WGFeatureMenu.FeatureMenuItemConfig();
        .enabled = (TheLibraryLogic.LifetimeBooksEarned > 0) ? 1 : 0;
        .featureActionable = ( > 0) ? 1 : 0;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickLibrary());
        .itemSprite = this.librarySprite;
        .featureNameText = Localization.Localize(key:  "library_upper", defaultValue:  "Library", useSingularKey:  false);
        .featureUnlockLevel = ChapterBookLogic.GetFirstLevelOfSecondBook();
        FeatureMenuItem val_17 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickLibrary()
    {
        var val_3;
        GameBehavior val_1 = App.getBehavior;
        val_3 = null;
        val_3 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((val_1.<metaGameBehavior>k__BackingField) != 1) ? (53 + 1) : 53;
        TheLibraryUI.ShowTheLibrary(onCloseAction:  0);
        this.Close();
    }
    protected void SetupBookRewards()
    {
        WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
        .enabled = (TheLibraryLogic.LifetimeBooksEarned > 0) ? 1 : 0;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickBookReward());
        .itemSprite = this.bookRewardSprite;
        .featureNameText = Localization.Localize(key:  "library_upper", defaultValue:  "LIBRARY", useSingularKey:  false);
        .featureUnlockLevel = ChapterBookLogic.GetFirstLevelOfSecondBook();
        FeatureMenuItem val_7 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickBookReward()
    {
        var val_3;
        this.Close();
        GameBehavior val_1 = App.getBehavior;
        val_3 = null;
        val_3 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((val_1.<metaGameBehavior>k__BackingField) == 1) ? 57 : 55;
        TheLibraryUI.ShowTheLibrary(onCloseAction:  0);
    }
    protected void SetupDifficulty()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage().Equals(value:  0)) == false)
        {
                return;
        }
        
        WGFeatureMenu.FeatureMenuItemConfig val_4 = new WGFeatureMenu.FeatureMenuItemConfig();
        GameEcon val_5 = App.getGameEcon;
        .featureUnlockLevel = val_5.difficultySettingPromptLevel;
        .enabled = (App.Player >= (WGFeatureMenu.FeatureMenuItemConfig)[1152921516210041024].featureUnlockLevel) ? 1 : 0;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickDifficulty());
        .itemSprite = this.difficultySprite;
        .featureNameText = Localization.Localize(key:  "difficulty_upper", defaultValue:  "Difficulty", useSingularKey:  false);
        FeatureMenuItem val_10 = this.getNewItem();
        this = ???;
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickDifficulty()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage().Equals(value:  "en")) == false)
        {
                return;
        }
        
        UnityEngine.Debug.LogWarning(message:  "Need difficulty entry point tracking");
        WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDifficultySettingPopup>(showNext:  false);
        this.Close();
    }
    protected virtual void SetupAdControl()
    {
        WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
        .enabled = true;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickAdControl());
        .itemSprite = this.adControlSprite;
        .featureNameText = Localization.Localize(key:  "ads_control_upper", defaultValue:  "Ad Control", useSingularKey:  false);
        .featureUnlockLevel = 0;
        FeatureMenuItem val_4 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    protected void OnClickAdControl()
    {
        var val_8;
        var val_9;
        HeyZapAdTag val_10;
        var val_11;
        val_8 = this;
        if(this.HasNoInternet() == true)
        {
                return;
        }
        
        val_9 = null;
        val_9 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 94;
        this.Close();
        if(SceneDictator.IsInGameScene() != false)
        {
                WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false);
            val_10 = 13;
        }
        else
        {
                val_10 = 2;
        }
        
        WGAdsControlPopup val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false).InitEntryTag(tag:  val_10);
        val_8 = 1152921504891564032;
        val_11 = null;
        val_11 = null;
        PurchaseProxy.currentPurchasePoint = 77;
    }
    protected void SetupMoreGames()
    {
        var val_10;
        var val_11;
        System.Action val_12;
        var val_13;
        var val_14;
        bool val_15;
        val_10 = null;
        val_10 = null;
        if(twelvegigs.plugins.InstalledAppsPlugin.fetched == false)
        {
                return;
        }
        
        GameApp[] val_1 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
        if(val_1.Length == 0)
        {
                return;
        }
        
        WGFeatureMenu.FeatureMenuItemConfig val_2 = new WGFeatureMenu.FeatureMenuItemConfig();
        val_11 = null;
        val_11 = null;
        .enabled = (App.Player >= WGMoreGamesManager._unlockLevel) ? 1 : 0;
        System.Action val_5 = null;
        val_12 = val_5;
        val_5 = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickMoreGames());
        .onClickAction = val_12;
        .itemSprite = this.moreGamesSprite;
        .featureNameText = Localization.Localize(key:  "more_games_upper", defaultValue:  "More Games", useSingularKey:  false);
        val_13 = null;
        val_13 = null;
        .featureUnlockLevel = WGMoreGamesManager._unlockLevel;
        if((WGFeatureMenu.FeatureMenuItemConfig)[1152921516210741488].enabled == false)
        {
            goto label_29;
        }
        
        val_14 = null;
        val_14 = null;
        if(WGMoreGamesManager.totalBonus < 1)
        {
            goto label_29;
        }
        
        val_15 = WGMoreGamesManager.CanCollect();
        goto label_32;
        label_29:
        val_15 = false;
        label_32:
        .featureActionable = val_15;
        FeatureMenuItem val_8 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickMoreGames()
    {
        this.Close();
        if(WGMoreGamesManager.CanShowMoreGames == false)
        {
                return;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMoreGamesPopup>(showNext:  false);
    }
    protected void SetupWordIQ()
    {
        WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
        .enabled = true;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickWordIQ());
        .itemSprite = this.wordIQSprite;
        .featureNameText = Localization.Localize(key:  "word_iq_upper", defaultValue:  "Word IQ", useSingularKey:  false);
        .featureUnlockLevel = 0;
        FeatureMenuItem val_4 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickWordIQ()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordIQFoundWordsMenu>(showNext:  false);
        this.Close();
    }
    protected void SetupWADPets()
    {
        WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
        bool val_2 = WADPetsManager.IsFeatureUnlocked();
        .enabled = val_2;
        .featureUnlockLevel = 0;
        .featureActionable = false;
        if(val_2 != false)
        {
                if((MonoSingleton<WADPetsManager>.Instance.IsAnyUpgradeAvailable()) != false)
        {
                .featureActionable = true;
            (WGFeatureMenu.FeatureMenuItemConfig)[1152921516211334240].customActionableIcons.Add(item:  this.wadPetsActionableUpgrade);
        }
        
            if(WADPetsManager.IsAnyPetHungry() != false)
        {
                .featureActionable = true;
            (WGFeatureMenu.FeatureMenuItemConfig)[1152921516211334240].customActionableIcons.Add(item:  this.wadPetsActionableFood);
        }
        
        }
        
        .featureNameText = Localization.Localize(key:  "pets_upper", defaultValue:  "PETS", useSingularKey:  false);
        .itemSprite = this.wadPetsSprite;
        .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickWADPets());
        FeatureMenuItem val_9 = this.getNewItem();
        goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
    }
    private void OnClickWADPets()
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 96;
        WADPetsScreenUI.ShowMainScreen();
        this.Close();
    }
    protected void SetupSpecialTournamentsButton()
    {
        System.Action<System.Boolean> val_8;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        val_8 = 1152921504765632512;
        if((MonoSingleton<TournamentsManager>.Instance) == 0)
        {
                return;
        }
        
        if(val_4.currentTournamentInfo == null)
        {
                return;
        }
        
        this.tournamentsButton = UnityEngine.Object.Instantiate<TournamentsButton>(original:  MonoSingleton<TournamentsManager>.Instance.TournamentsMenuItemPrefab, parent:  this.menuItemParent, worldPositionStays:  false);
        System.Action<System.Boolean> val_7 = null;
        val_8 = val_7;
        val_7 = new System.Action<System.Boolean>(object:  this, method:  System.Void WGFeatureMenu::OnClickTournamentsItem(bool isConnected));
        val_6.ExternalClickCallback = val_8;
    }
    private void OnClickTournamentsItem(bool isConnected)
    {
        var val_10;
        string val_12;
        if(isConnected == false)
        {
            goto label_1;
        }
        
        TournamentsManager val_1 = MonoSingleton<TournamentsManager>.Instance;
        if(val_1.currentTournamentInfo == null)
        {
            goto label_5;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TournamentsPopup>(showNext:  false);
        this.Close();
        return;
        label_1:
        val_10 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        UnityEngine.GameObject val_6 = this.tournamentsButton.gameObject;
        val_12 = "Internet connection required. Please check your connection and try again!";
        goto label_14;
        label_5:
        val_10 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_12 = "Currently processing tournament results! Try again in a few minutes.";
        label_14:
        val_10.ShowToolTip(objToToolTip:  this.tournamentsButton.gameObject, text:  val_12, topToolTip:  true, displayDuration:  3.5f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    protected void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(this.OnNonHomeCloseAction == null)
        {
                return;
        }
        
        this.OnNonHomeCloseAction.Invoke();
    }
    public WGFeatureMenu()
    {
    
    }
    private bool <HasNoInternet>b__32_0()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGFeatureMenu>(showNext:  false);
        mem2[0] = this.OnNonHomeCloseAction;
        return true;
    }
    private void <OnClickHome>b__33_0()
    {
        this.levelCompletePopup.gameObject.SetActive(value:  true);
        SLCWindow.CloseWindow(window:  this.levelCompletePopup.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  false);
    }
    private void <OnClickSettings>b__34_0()
    {
        LevelCompletePopup val_7;
        LevelCompletePopup val_8;
        val_7 = this;
        mem2[0] = this.OnNonHomeCloseAction;
        val_8 = this.levelCompletePopup;
        if(val_8 == 0)
        {
                return;
        }
        
        mem2[0] = this.levelCompletePopup;
        SLCWindow val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGFeatureMenu>(showNext:  false).GetComponent<SLCWindow>();
        val_8 = val_4.Action_OnClose;
        val_7 = this.levelCompletePopup;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_8, b:  new System.Action(object:  val_7, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.Action_OnClose = val_6;
        return;
        label_10:
    }
    private void <OnClickHelp>b__35_0()
    {
        LevelCompletePopup val_7;
        LevelCompletePopup val_8;
        val_7 = this;
        mem2[0] = this.OnNonHomeCloseAction;
        val_8 = this.levelCompletePopup;
        if(val_8 == 0)
        {
                return;
        }
        
        mem2[0] = this.levelCompletePopup;
        SLCWindow val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGFeatureMenu>(showNext:  false).GetComponent<SLCWindow>();
        val_8 = val_4.Action_OnClose;
        val_7 = this.levelCompletePopup;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_8, b:  new System.Action(object:  val_7, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.Action_OnClose = val_6;
        return;
        label_10:
    }
    private void <OnClickRestore>b__36_0()
    {
        LevelCompletePopup val_7;
        LevelCompletePopup val_8;
        val_7 = this;
        mem2[0] = this.OnNonHomeCloseAction;
        val_8 = this.levelCompletePopup;
        if(val_8 == 0)
        {
                return;
        }
        
        mem2[0] = this.levelCompletePopup;
        SLCWindow val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGFeatureMenu>(showNext:  false).GetComponent<SLCWindow>();
        val_8 = val_4.Action_OnClose;
        val_7 = this.levelCompletePopup;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_8, b:  new System.Action(object:  val_7, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.Action_OnClose = val_6;
        return;
        label_10:
    }

}
