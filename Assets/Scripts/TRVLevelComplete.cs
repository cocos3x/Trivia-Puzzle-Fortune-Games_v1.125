using UnityEngine;
public class TRVLevelComplete : MonoBehaviour
{
    // Fields
    private const string lastChapterCollectedKey = "LCCK";
    private static int lastLevelCompleteAnimShownAt;
    private static int lastEventLevelCompleteAnimShownAt;
    public UnityEngine.GameObject levelFailureGroup;
    public UnityEngine.GameObject levelFailureProgressBar;
    private UnityEngine.UI.Text failurePointRewardText;
    private UnityEngine.UI.Text failureLevelProgressText;
    private UnityEngine.UI.Text failureTryAgainCost;
    private UnityEngine.UI.Text failureStarMultiplierText;
    private UnityEngine.UI.Image failureLevelProgressBar;
    private UnityEngine.UI.Button tryAgainButton;
    private UnityEngine.GameObject levelSuccessGroup;
    private UnityEngine.GameObject levelCompleteBanner;
    private UnityEngine.UI.Text pregameCointext;
    private UnityEngine.UI.Text pregameStarText;
    private UnityEngine.UI.Button pregameOpenButton;
    private UnityEngine.GameObject preminigameTapContinueObject;
    private UnityEngine.GameObject preminigameRewardGroup;
    private UnityEngine.GameObject preCrazyCategoriesPointParent;
    private UnityEngine.UI.Text preCrazyCategoriesPointsAmount;
    private UnityEngine.UI.Text streakReward;
    private UnityEngine.GameObject streakGroup;
    private UnityEngine.GameObject chestGroup;
    private UnityEngine.UI.Image openChestImage;
    private UnityEngine.UI.Image closedChestImage;
    private TRVPickerGameButton minigameButtonPrefab;
    private System.Collections.Generic.Dictionary<TRVPickerGameButton, int> gameButtons;
    private UnityEngine.GameObject chestRewardMultiParent;
    private UnityEngine.UI.Image minigameBackdrop;
    private UnityEngine.UI.Text minigameOpenText;
    private UnityEngine.CanvasGroup multiplierChestGroup;
    private UGUINetworkedButton redrawButton;
    private UnityEngine.UI.Button noThanksButton;
    private UnityEngine.GameObject postMinigameGroup;
    public UnityEngine.GameObject progressBarParent;
    private UnityEngine.UI.Text postMinigameNextGameText;
    private UnityEngine.UI.Text postMinigameChapterProgressText;
    private UnityEngine.UI.Text postMinigameTryAgainCost;
    private UnityEngine.UI.Text postMinigameStarMultiText;
    private UnityEngine.UI.Image postMinigameChestImage;
    private UnityEngine.UI.Image postMinigameChapterProgressBar;
    private UnityEngine.UI.Button postMinigameNextButton;
    private UnityEngine.GameObject postMinigameNextButtonGroup;
    private TournamentsButton tournamentsButton;
    private System.Collections.Generic.List<UnityEngine.GameObject> statViews;
    public CoinCurrencyParticles ccp;
    public GoldenApplesParticles sp;
    public GemsParticles gp;
    public CurrencyStatView starStatView;
    public CurrencyStatView coinStatView;
    public CurrencyStatView gemStatView;
    private TRVLevelCompleteReward levelCompleteRewardPrefab;
    private UnityEngine.Transform levelCompleteRewardParent;
    private System.Collections.Generic.Dictionary<string, TRVLevelCompleteReward> spawnedRewards;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button gemStoreButton;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.Sprite WoodChestIcon;
    private UnityEngine.Sprite WoodChestOpen;
    private UnityEngine.Sprite SilverChestIcon;
    private UnityEngine.Sprite SilverChestOpen;
    private UnityEngine.Sprite GoldenChestIcon;
    private UnityEngine.Sprite GoldenChestOpen;
    private System.Collections.Generic.List<UnityEngine.Sprite> cardSpecificSprites;
    private UnityEngine.GameObject challengeFriendGroup;
    private UnityEngine.UI.Button challengeFriendButton;
    private UnityEngine.UI.Text completionTimeText;
    private TRVSpecialCategoriesLevelComplete specialCategoriesLevelComplete;
    public System.Action playNextLevelAction;
    
    // Properties
    private int chapterLength { get; }
    private bool ChapterRewardAvailable { get; }
    private bool CompletedChapterCycle { get; }
    private bool RerollBonusToday { get; set; }
    
    // Methods
    private int get_chapterLength()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1.levelsPerChapter;
    }
    private bool get_ChapterRewardAvailable()
    {
        var val_7;
        var val_8;
        Player val_1 = App.Player;
        val_7 = val_1;
        int val_2 = val_1.chapterLength;
        Player val_3 = val_7 / val_2;
        val_3 = val_7 - (val_3 * val_2);
        if(val_3 != null)
        {
                val_8 = 0;
            return (bool)(val_7 != App.Player) ? 1 : 0;
        }
        
        val_7 = CPlayerPrefs.GetInt(key:  "LCCK", defaultValue:  0);
        return (bool)(val_7 != App.Player) ? 1 : 0;
    }
    private bool get_CompletedChapterCycle()
    {
        Player val_1 = App.Player;
        int val_2 = val_1.chapterLength;
        Player val_3 = val_1 / val_2;
        val_3 = val_1 - (val_3 * val_2);
        return (bool)(val_3 == 0) ? 1 : 0;
    }
    private bool get_RerollBonusToday()
    {
        ulong val_8;
        var val_9;
        ulong val_10;
        val_8 = 1152921504874684416;
        if((CPlayerPrefs.HasKey(key:  "rerollLast")) != false)
        {
                val_9 = null;
            val_9 = null;
            System.DateTime val_3 = SLCDateTime.ParseInvariant(dateTime:  CPlayerPrefs.GetString(key:  "rerollLast", defaultValue:  ""), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
            System.DateTime val_4 = val_3.dateData.Date;
            val_8 = val_4.dateData;
            System.DateTime val_5 = DateTimeCheat.UtcNow;
            System.DateTime val_6 = val_5.dateData.Date;
            val_10 = val_8;
            bool val_7 = System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_10}, d2:  new System.DateTime() {dateData = val_6.dateData});
        }
        else
        {
                val_10 = 0;
        }
        
        val_10 = val_10 & 1;
        return (bool)val_10;
    }
    private void set_RerollBonusToday(bool value)
    {
        if(value == false)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        CPlayerPrefs.SetString(key:  "rerollLast", val:  SLCDateTime.SerializeInvariant(dateTime:  new System.DateTime() {dateData = val_1.dateData}));
        CPlayerPrefs.Save();
    }
    private void OnEnable()
    {
        object val_38;
        var val_39;
        System.Collections.Generic.List<UnityEngine.GameObject> val_40;
        var val_41;
        System.Action<UnityEngine.GameObject> val_43;
        TournamentsButton val_44;
        val_38 = this;
        this.levelFailureGroup.gameObject.SetActive(value:  false);
        this.levelSuccessGroup.gameObject.SetActive(value:  false);
        this.postMinigameGroup.gameObject.SetActive(value:  false);
        this.storeButton.m_OnClick.RemoveAllListeners();
        this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLevelComplete::StoreButtonClicked()));
        this.gemStoreButton.m_OnClick.RemoveAllListeners();
        this.gemStoreButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLevelComplete::GemStoreButtonClicked()));
        this.homeButton.m_OnClick.RemoveAllListeners();
        this.homeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLevelComplete::HomeButtonClicked()));
        this.homeButton.gameObject.SetActive(value:  false);
        val_39 = 1152921504614248448;
        this.redrawButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVLevelComplete::RedrawMultiplier(bool connected));
        TRVMainController val_9 = MonoSingleton<TRVMainController>.Instance;
        val_40 = this.statViews;
        val_41 = null;
        val_41 = null;
        val_43 = TRVLevelComplete.<>c.<>9__78_0;
        if(val_43 == null)
        {
                System.Action<UnityEngine.GameObject> val_10 = null;
            val_43 = val_10;
            val_10 = new System.Action<UnityEngine.GameObject>(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<OnEnable>b__78_0(UnityEngine.GameObject x));
            TRVLevelComplete.<>c.<>9__78_0 = val_43;
        }
        
        val_40.ForEach(action:  val_10);
        if(val_9.currentGame.successfullyCompletedQuiz == false)
        {
            goto label_32;
        }
        
        if(val_9.currentGame.hasCollectedChest == false)
        {
            goto label_33;
        }
        
        UnityEngine.Coroutine val_13 = this.StartCoroutine(routine:  this.SetupPostMinigameState());
        goto label_35;
        label_32:
        this.SetupLevelFailureState();
        goto label_35;
        label_33:
        this.SetupPreGameState();
        label_35:
        if(this.tournamentsButton != 0)
        {
                val_44 = this.tournamentsButton;
            System.Action<System.Boolean> val_15 = null;
            val_40 = val_15;
            val_15 = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVLevelComplete::OnTournamentsClicked(bool isConnected));
            System.Delegate val_16 = System.Delegate.Combine(a:  this.tournamentsButton.ExternalClickCallback, b:  val_15);
            if(val_16 != null)
        {
                if(null != null)
        {
            goto label_41;
        }
        
        }
        
            this.tournamentsButton.ExternalClickCallback = val_16;
        }
        
        if(this.challengeFriendGroup == 0)
        {
                return;
        }
        
        if(this.challengeFriendButton == 0)
        {
                return;
        }
        
        if(this.completionTimeText == 0)
        {
                return;
        }
        
        val_44 = 1152921504893161472;
        val_39 = 1152921515625797136;
        if((MonoSingleton<ChallengeFriendController>.Instance) == 0)
        {
                return;
        }
        
        ChallengeFriendController val_22 = MonoSingleton<ChallengeFriendController>.Instance;
        if(val_22.challengeToShare == null)
        {
                return;
        }
        
        this.challengeFriendGroup.gameObject.SetActive(value:  true);
        this.challengeFriendButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLevelComplete::ChallengeFriend()));
        ChallengeFriendController val_25 = MonoSingleton<ChallengeFriendController>.Instance;
        string val_26 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_25.challengeToShare.timespan}, formatted:  true);
        val_38 = ???;
        val_40 = ???;
        val_44 = ???;
        val_39 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_41:
    }
    private void ChallengeFriend()
    {
        MonoSingleton<ChallengeFriendController>.Instance.ShareChallenge();
    }
    private void SetupPreGameState()
    {
        this.levelCompleteBanner.gameObject.SetActive(value:  true);
        this.setChestSprite(image:  this.closedChestImage, closed:  true);
        this.openChestImage.gameObject.SetActive(value:  false);
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        TRVMainController val_4 = MonoSingleton<TRVMainController>.Instance;
        int val_33 = val_3.variableMultipliers[val_4.currentGame.starMultiplierIndex];
        TRVMainController val_5 = MonoSingleton<TRVMainController>.Instance;
        val_3.variableMultipliers[val_4.currentGame.starMultiplierIndex] = val_5.currentGame.GetQuizBaseStarReward() * val_33;
        TRVMainController val_7 = MonoSingleton<TRVMainController>.Instance;
        string val_10 = System.String.Format(format:  "{0}", arg0:  val_7.currentGame.GetQuizBaseReward().ToString());
        string val_12 = System.String.Format(format:  "{0}", arg0:  val_3.variableMultipliers[val_4.currentGame.starMultiplierIndex].ToString());
        this.pregameOpenButton.m_OnClick.RemoveAllListeners();
        this.pregameOpenButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLevelComplete::<SetupPreGameState>b__80_0()));
        this.pregameOpenButton.interactable = false;
        this.levelSuccessGroup.gameObject.SetActive(value:  true);
        this.minigameBackdrop.gameObject.SetActive(value:  false);
        this.minigameOpenText.gameObject.SetActive(value:  false);
        this.multiplierChestGroup.gameObject.SetActive(value:  false);
        this.redrawButton.gameObject.SetActive(value:  false);
        this.noThanksButton.gameObject.SetActive(value:  false);
        this.chestGroup.SetActive(value:  false);
        this.streakGroup.SetActive(value:  true);
        string val_23 = System.String.Format(format:  "+ {0}", arg0:  (MonoSingleton<TRVStreakManager>.Instance.GetBonusStarReward()) * val_33);
        if((TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID != null) && (TRVCrazyCategoriesEventHandler.BonusStarsEligable() != false))
        {
                this.preCrazyCategoriesPointParent.gameObject.SetActive(value:  true);
            TRVMainController val_26 = MonoSingleton<TRVMainController>.Instance;
            string val_29 = System.String.Format(format:  "{0}", arg0:  val_26.currentGame.GetQuizBaseStarReward().ToString());
        }
        else
        {
                this.preCrazyCategoriesPointParent.gameObject.SetActive(value:  false);
        }
        
        UnityEngine.Coroutine val_32 = this.StartCoroutine(routine:  this.PlayStreakAnimation());
    }
    private System.Collections.IEnumerator PlayStreakAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<PlayStreakAnimation>d__81();
    }
    private System.Collections.IEnumerator StartMinigame()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<StartMinigame>d__82();
    }
    private void MultiplierPicked(int multi, TRVPickerGameButton selectedButton)
    {
        var val_4;
        var val_5;
        TRVLevelComplete val_34;
        var val_35;
        var val_36;
        int val_37;
        System.Collections.Generic.IEnumerable<System.Int32> val_38;
        int val_39;
        val_34 = this;
        .<>4__this = val_34;
        .multi = multi;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = this.gameButtons.Keys.GetEnumerator();
        label_7:
        val_35 = public System.Boolean Dictionary.KeyCollection.Enumerator<TRVPickerGameButton, System.Int32>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_36 = val_4;
        if(val_36 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_35 = 0;
        UnityEngine.UI.Button val_7 = val_36.myButton;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.interactable = false;
        goto label_7;
        label_4:
        val_5.Dispose();
        val_37 = 1152921504884269056;
        TRVEcon val_8 = App.GetGameSpecificEcon<TRVEcon>();
        TRVMainController val_9 = MonoSingleton<TRVMainController>.Instance;
        System.Collections.Generic.List<System.Int32> val_10 = val_8.chestRewardMultis.Item[val_9.currentGame.myChest];
        val_10.Sort();
        val_38 = val_10;
        int val_11 = System.Linq.Enumerable.Max(source:  val_38);
        val_39 = val_11;
        if(((TRVLevelComplete.<>c__DisplayClass83_0)[1152921517274537968].multi) != val_11)
        {
                TRVMainController val_12 = MonoSingleton<TRVMainController>.Instance;
            if((val_12.currentGame.hasRerolledChest != true) && ((MonoSingletonSelfGenerating<AdsManager>.Instance.VideoEnabledAndUnlocked()) != false))
        {
                TRVEcon val_16 = App.GetGameSpecificEcon<TRVEcon>();
            val_37 = val_16.multiplierRedrawUnlockLevel;
            val_38 = App.Player - 1;
            if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_38, knobValue:  val_37)) != false)
        {
                TRVMainController val_18 = MonoSingleton<TRVMainController>.Instance;
            val_18.currentGame.selectedMulitplier = (TRVLevelComplete.<>c__DisplayClass83_0)[1152921517274537968].multi;
            UnityEngine.Coroutine val_20 = this.StartCoroutine(routine:  this.animateReveal(selected:  selectedButton, rerollAvailable:  true));
            val_34 = this.noThanksButton.m_OnClick;
            val_34.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVLevelComplete.<>c__DisplayClass83_0(), method:  System.Void TRVLevelComplete.<>c__DisplayClass83_0::<MultiplierPicked>b__0()));
            return;
        }
        
        }
        
        }
        
        if(val_11.RerollBonusToday == true)
        {
            goto label_41;
        }
        
        TRVMainController val_23 = MonoSingleton<TRVMainController>.Instance;
        if(val_39 <= val_23.currentGame.selectedMulitplier)
        {
            goto label_51;
        }
        
        val_39 = (TRVLevelComplete.<>c__DisplayClass83_0)[1152921517274537968].multi;
        TRVMainController val_24 = MonoSingleton<TRVMainController>.Instance;
        if(val_39 > val_24.currentGame.selectedMulitplier)
        {
            goto label_51;
        }
        
        TRVLevelComplete.<>c__DisplayClass83_1 val_25 = null;
        val_39 = val_25;
        val_25 = new TRVLevelComplete.<>c__DisplayClass83_1();
        .overrideValue = 0;
        if(1152921504960094208 < 1)
        {
            goto label_61;
        }
        
        var val_35 = 8;
        label_60:
        if(1152921504960094208 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37 = public System.Void System.Collections.Generic.List<System.Int32>::Insert(int index, System.Int32 item);
        TRVMainController val_26 = MonoSingleton<TRVMainController>.Instance;
        if(val_37 > val_26.currentGame.selectedMulitplier)
        {
            goto label_59;
        }
        
        val_35 = val_35 + 1;
        if((val_35 - 8) < val_26.currentGame.selectedMulitplier)
        {
            goto label_60;
        }
        
        goto label_61;
        label_59:
        if(val_26.currentGame.selectedMulitplier <= (val_35 - 8))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        .overrideValue = val_26.currentGame.selectedMulitplier + 32;
        label_61:
        System.Collections.Generic.KeyValuePair<TRVPickerGameButton, System.Int32> val_30 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.KeyValuePair<TRVPickerGameButton, System.Int32>>(source:  this.gameButtons, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<TRVPickerGameButton, System.Int32>, System.Boolean>(object:  val_25, method:  System.Boolean TRVLevelComplete.<>c__DisplayClass83_1::<MultiplierPicked>b__1(System.Collections.Generic.KeyValuePair<TRVPickerGameButton, int> x)));
        selectedButton.specificSprite = val_30.Value + 56;
        mem2[0] = selectedButton.specificSprite;
        .multi = (TRVLevelComplete.<>c__DisplayClass83_1)[1152921517274644464].overrideValue;
        label_51:
        val_30.Value.RerollBonusToday = true;
        label_41:
        TRVMainController val_31 = MonoSingleton<TRVMainController>.Instance;
        val_31.currentGame.selectedMulitplier = (TRVLevelComplete.<>c__DisplayClass83_0)[1152921517274537968].multi;
        MonoSingleton<TRVMainController>.Instance.RewardMultiPicked(multi:  (TRVLevelComplete.<>c__DisplayClass83_0)[1152921517274537968].multi);
        UnityEngine.Coroutine val_34 = this.StartCoroutine(routine:  this.animateReveal(selected:  selectedButton, rerollAvailable:  false));
    }
    private void RedrawMultiplier(bool connected)
    {
        string val_19;
        int val_20;
        var val_21;
        var val_22;
        int val_23;
        var val_24;
        this.redrawButton.interactable = false;
        this.noThanksButton.interactable = false;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        if(connected == false)
        {
            goto label_6;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  42, adCapExempt:  false)) == true)
        {
            goto label_10;
        }
        
        GameBehavior val_4 = App.getBehavior;
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_20 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_21 = "NULL";
        val_20 = val_9.Length;
        val_9[1] = "NULL";
        mem2[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean TRVLevelComplete::<RedrawMultiplier>b__84_0());
        val_22 = null;
        val_22 = null;
        val_4.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  X0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        return;
        label_6:
        GameBehavior val_12 = App.getBehavior;
        val_19 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        bool[] val_16 = new bool[2];
        val_16[0] = true;
        string[] val_17 = new string[2];
        val_23 = val_17.Length;
        val_17[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_23 = val_17.Length;
        val_17[1] = "NULL";
        val_24 = null;
        val_24 = null;
        val_12.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  val_19, messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_16, buttonTexts:  val_17, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        label_10:
        this.redrawButton.interactable = true;
        this.noThanksButton.interactable = true;
    }
    private void OnVideoResponse(Notification notif)
    {
        object val_21;
        string val_22;
        int val_23;
        var val_24;
        val_21 = this;
        this.redrawButton.interactable = false;
        this.noThanksButton.interactable = false;
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
            goto label_8;
        }
        
        this.noThanksButton.gameObject.SetActive(value:  false);
        this.redrawButton.gameObject.SetActive(value:  false);
        TRVMainController val_5 = MonoSingleton<TRVMainController>.Instance;
        val_5.currentGame.hasRerolledChest = true;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_7 = this.gameButtons.Keys.GetEnumerator();
        val_22 = 1152921517274331440;
        label_23:
        if(0.MoveNext() == false)
        {
            goto label_19;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Object.Destroy(obj:  0.gameObject);
        goto label_23;
        label_8:
        GameBehavior val_10 = App.getBehavior;
        val_22 = Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false);
        bool[] val_14 = new bool[2];
        val_14[0] = true;
        string[] val_15 = new string[2];
        val_23 = val_15.Length;
        val_15[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_23 = val_15.Length;
        val_15[1] = "NULL";
        System.Func<System.Boolean>[] val_17 = new System.Func<System.Boolean>[2];
        val_17[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean TRVLevelComplete::<OnVideoResponse>b__85_0());
        val_21 = 1152921504617017344;
        val_24 = null;
        val_24 = null;
        val_10.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  val_22, messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_14, buttonTexts:  val_15, showClose:  false, buttonCallbacks:  val_17, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        return;
        label_19:
        0.Dispose();
        this.gameButtons.Clear();
        UnityEngine.Coroutine val_20 = this.StartCoroutine(routine:  this.StartMinigame());
    }
    private System.Collections.IEnumerator animateReveal(TRVPickerGameButton selected, bool rerollAvailable)
    {
        .<>1__state = 0;
        .selected = selected;
        .<>4__this = this;
        .rerollAvailable = rerollAvailable;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<animateReveal>d__86();
    }
    private System.Collections.IEnumerator SetupPostMinigameState()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<SetupPostMinigameState>d__87();
    }
    private void HandlePostMinigameEventSetup(bool animate)
    {
        TRVQuizProgress val_37;
        int val_38;
        var val_39;
        UnityEngine.Transform val_40;
        TRVLevelReward val_41;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        val_37 = val_1.currentGame;
        this.specialCategoriesLevelComplete.Init(currentQuiz:  val_37, lcPopup:  this);
        if(TRVCrazyCategoriesEventHandler.BonusStarsEligable() != false)
        {
                .<desc>k__BackingField = Localization.Localize(key:  "crazy_categories", defaultValue:  "Crazy Categories", useSingularKey:  false);
            .<value>k__BackingField = TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID.bonusStars(stars:  val_1.currentGame.finalStarReward);
            .<rewardType>k__BackingField = 4.94065645841247E-324;
            UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.SetupReward(parent:  this.levelCompleteRewardParent, reward:  new TRVLevelReward(), anim:  false));
        }
        
        if((MonoSingleton<TRVSpecialCategoriesManager>.Instance) == 0)
        {
            goto label_44;
        }
        
        TRVMainController val_10 = MonoSingleton<TRVMainController>.Instance;
        if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  val_10.currentGame)) == false)
        {
            goto label_44;
        }
        
        if(val_37.successfullyCompletedQuiz == false)
        {
            goto label_19;
        }
        
        if(animate == false)
        {
            goto label_44;
        }
        
        val_37 = MonoSingleton<TRVSpecialCategoriesManager>.Instance;
        TRVMainController val_14 = MonoSingleton<TRVMainController>.Instance;
        if((val_37.IsRewardReadyToCollect(progress:  val_14.currentGame)) == false)
        {
            goto label_44;
        }
        
        TRVMainController val_17 = MonoSingleton<TRVMainController>.Instance;
        Player val_19 = App.Player;
        decimal val_20 = System.Decimal.op_Implicit(value:  val_19._gems);
        this.gemStatView.artificalTargetBalance = val_20;
        mem2[0] = val_20.lo;
        mem[4] = val_20.mid;
        TRVMainController val_22 = MonoSingleton<TRVMainController>.Instance;
        MonoSingleton<TRVSpecialCategoriesManager>.Instance.CollectReward(progress:  val_22.currentGame);
        .<desc>k__BackingField = "Special Category";
        .<value>k__BackingField = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetCurrentReward(progress:  val_17.currentGame);
        .<rewardType>k__BackingField = 9.88131291682493E-324;
        UnityEngine.Coroutine val_25 = this.StartCoroutine(routine:  this.SetupReward(parent:  this.levelCompleteRewardParent, reward:  new TRVLevelReward(), anim:  true));
        val_37 = this.gemStatView;
        Player val_26 = App.Player;
        decimal val_27 = System.Decimal.op_Implicit(value:  val_26._gems);
        this.gemStatView.artificalTargetBalance = val_27;
        mem2[0] = val_27.lo;
        mem[4] = val_27.mid;
        goto label_44;
        label_19:
        this.levelFailureProgressBar.SetActive(value:  false);
        label_44:
        if(TRVYouBetchaEventHandler.EVENT_TRACKING_ID == null)
        {
                return;
        }
        
        if(TRVYouBetchaEventHandler.EVENT_TRACKING_ID.shouldShowPopup == false)
        {
                return;
        }
        
        bool val_29 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID.TryRewardBet();
        string val_30 = Localization.Localize(key:  "you_betcha", defaultValue:  "You Betcha!", useSingularKey:  false);
        if((TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 41) != 0)
        {
                val_38 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID.betReward;
            .<desc>k__BackingField = val_30;
            .<rewardType>k__BackingField = 0;
            .<cardMulti>k__BackingField = 0;
            .<value>k__BackingField = val_38;
            val_39 = animate;
            val_40 = this.levelCompleteRewardParent;
            val_41 = new TRVLevelReward();
        }
        else
        {
                TRVLevelReward val_33 = new TRVLevelReward();
            val_40 = this.levelCompleteRewardParent;
            val_41 = val_33;
            val_39 = 0;
            .<desc>k__BackingField = val_30;
            .<value>k__BackingField = 0;
            .<rewardType>k__BackingField = 0;
            .<cardMulti>k__BackingField = 0;
        }
        
        UnityEngine.Coroutine val_35 = this.StartCoroutine(routine:  this.SetupReward(parent:  val_40, reward:  val_33, anim:  false));
    }
    private System.Collections.IEnumerator OnRewardAnimFinished(float delay = 0)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .delay = delay;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<OnRewardAnimFinished>d__89();
    }
    private void SetupLevelFailureState()
    {
        var val_48;
        System.Action<UnityEngine.GameObject> val_50;
        var val_51;
        var val_52;
        int val_53;
        var val_55;
        var val_56;
        var val_57;
        var val_58;
        object val_59;
        var val_60;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        val_48 = null;
        val_48 = null;
        val_50 = TRVLevelComplete.<>c.<>9__90_0;
        if(val_50 == null)
        {
                System.Action<UnityEngine.GameObject> val_2 = null;
            val_50 = val_2;
            val_2 = new System.Action<UnityEngine.GameObject>(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<SetupLevelFailureState>b__90_0(UnityEngine.GameObject x));
            TRVLevelComplete.<>c.<>9__90_0 = val_50;
        }
        
        this.statViews.ForEach(action:  val_2);
        this.homeButton.gameObject.SetActive(value:  true);
        val_51 = null;
        if((TRVSpecialCategoriesManager.IsOldSpecialQuiz(progress:  val_1.currentGame)) != false)
        {
                val_52 = null;
            val_53 = TRVLevelComplete.lastEventLevelCompleteAnimShownAt;
            int val_6 = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetQuizProgress(progress:  val_1.currentGame);
        }
        else
        {
                val_55 = null;
            val_53 = TRVLevelComplete.lastLevelCompleteAnimShownAt;
        }
        
        if(val_53 == App.Player)
        {
                val_56 = 0;
        }
        else
        {
                UnityEngine.Vector3 val_10 = this.starStatView.AppleIcon.transform.position;
            this.sp.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, particleCount:  val_1.currentGame.totalPointsGained, animateStatView:  true);
            Player val_12 = App.Player;
            decimal val_15 = System.Decimal.op_Implicit(value:  val_12._stars - val_1.currentGame.totalPointsGained);
            this.starStatView.artificalTargetBalance = val_15;
            mem2[0] = val_15.lo;
            mem[4] = val_15.mid;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnStarsUpdated");
            val_57 = null;
            val_57 = null;
            TRVLevelComplete.lastLevelCompleteAnimShownAt = App.Player;
            val_56 = 1;
        }
        
        string val_20 = App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost.ToString();
        string val_21 = val_1.currentGame.finalStarReward.ToString();
        Player val_22 = App.Player;
        int val_23 = val_22.chapterLength;
        Player val_24 = val_22 / val_23;
        val_24 = val_22 - (val_24 * val_23);
        if(val_24 != null)
        {
                Player val_25 = App.Player;
            int val_26 = val_25.chapterLength;
            val_58 = val_25 - ((val_25 / val_26) * val_26);
        }
        else
        {
                int val_28 = val_23.chapterLength;
        }
        
        val_59 = val_28;
        string val_30 = System.String.Format(format:  "{0} / {1}", arg0:  val_28, arg1:  val_28.chapterLength);
        Player val_31 = App.Player;
        int val_32 = val_31.chapterLength;
        Player val_33 = val_31 / val_32;
        val_33 = val_31 - (val_33 * val_32);
        if(val_33 == null)
        {
            goto label_63;
        }
        
        Player val_34 = App.Player;
        int val_35 = val_34.chapterLength;
        val_59 = val_35;
        Player val_37 = val_34 / val_59;
        val_37 = val_34 - (val_37 * val_59);
        float val_48 = (float)val_37;
        val_48 = val_48 / (float)val_35.chapterLength;
        if(this.failureLevelProgressBar != null)
        {
            goto label_67;
        }
        
        label_63:
        label_67:
        this.failureLevelProgressBar.fillAmount = 1f;
        TRVEcon val_38 = App.GetGameSpecificEcon<TRVEcon>();
        val_60 = null;
        string val_41 = System.String.Format(format:  "{0}X {1}", arg0:  val_38.variableMultipliers[TRVMainController.currentMultiplier], arg1:  Localization.Localize(key:  "golden_apples_upper", defaultValue:  "STARS", useSingularKey:  false));
        this.tryAgainButton.m_OnClick.RemoveAllListeners();
        this.tryAgainButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLevelComplete::NextQuizButtonClicked()));
        this.levelFailureGroup.gameObject.SetActive(value:  true);
        this.HandlePostMinigameEventSetup(animate:  true);
        UnityEngine.Coroutine val_45 = this.StartCoroutine(routine:  this.OnRewardAnimFinished(delay:  0f));
    }
    private void NextQuizButtonClicked()
    {
        var val_46;
        var val_47;
        var val_48;
        var val_49;
        System.Action val_51;
        if(this.ChapterRewardAvailable == false)
        {
            goto label_1;
        }
        
        WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
        val_3.sound.PlayGeneralSound(type:  1, oneshot:  true, pitch:  1f, vol:  1f);
        string val_4 = Localization.Localize(key:  "next_level_upper", defaultValue:  "NEXT LEVEL", useSingularKey:  false);
        this.postMinigameTryAgainCost.transform.parent.gameObject.SetActive(value:  true);
        this.postMinigameStarMultiText.transform.parent.gameObject.SetActive(value:  true);
        this.homeButton.gameObject.SetActive(value:  true);
        .expertLeveledUp = false;
        System.Collections.Generic.List<GiftReward> val_16 = WGGiftRewardManager<TRVGiftRewardManager>.Instance.GetRewards(rewardsSource:  3, expertLeveledUp: out  true, cardsGranted:  0);
        CPlayerPrefs.SetInt(key:  "LCCK", val:  App.Player);
        CPlayerPrefs.Save();
        WGWindow val_18 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVGiftRewardPopup>(showNext:  true).GetComponent<WGWindow>();
        val_46 = 0;
        val_47 = 0;
        mem2[0] = new System.Action(object:  new TRVLevelComplete.<>c__DisplayClass91_0(), method:  System.Void TRVLevelComplete.<>c__DisplayClass91_0::<NextQuizButtonClicked>b__0());
        goto label_31;
        label_1:
        if((MonoSingleton<TRVMainController>.Instance.IsOutOfQuestions()) == false)
        {
            goto label_35;
        }
        
        MonoSingleton<TRVMainController>.Instance.ShowOutOfQuestionsPopup(showFlyout:  true);
        val_46 = 1;
        val_47 = 1;
        label_31:
        this.Close(showAd:  true, load:  true);
        return;
        label_35:
        Player val_23 = App.Player;
        decimal val_26 = System.Decimal.op_Implicit(value:  App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_23._credits, hi = val_23._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid})) == false)
        {
            goto label_45;
        }
        
        WGAudioController val_28 = MonoSingleton<WGAudioController>.Instance;
        val_28.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
        decimal val_31 = System.Decimal.op_Implicit(value:  App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost);
        bool val_32 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_31.flags, hi = val_31.hi, lo = val_31.lo, mid = val_31.mid}, source:  "TRVQuizEntry", externalParams:  0, animated:  true);
        UnityEngine.Vector3 val_35 = this.coinStatView.AppleIcon.position;
        this.ccp.transform.position = new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z};
        TRVMainController val_36 = MonoSingleton<TRVMainController>.Instance;
        if(val_36.currentGame.successfullyCompletedQuiz == false)
        {
            goto label_63;
        }
        
        if(this.postMinigameNextButton != null)
        {
            goto label_64;
        }
        
        label_45:
        val_48 = null;
        val_48 = null;
        PurchaseProxy.currentPurchasePoint = 93;
        GameBehavior val_38 = App.getBehavior;
        val_49 = null;
        val_49 = null;
        val_51 = TRVLevelComplete.<>c.<>9__91_1;
        if(val_51 == null)
        {
                System.Action val_40 = null;
            val_51 = val_40;
            val_40 = new System.Action(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<NextQuizButtonClicked>b__91_1());
            TRVLevelComplete.<>c.<>9__91_1 = val_51;
        }
        
        val_38.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_40);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_63:
        label_64:
        UnityEngine.Vector3 val_43 = this.failureTryAgainCost.transform.position;
        this.ccp.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_43.x, y = val_43.y, z = val_43.z}, particleCount:  0, animateStatView:  false);
        this.postMinigameNextButton.interactable = false;
        this.tryAgainButton.interactable = false;
        UUI_EventsController.DisableInputs();
        UnityEngine.Coroutine val_45 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<WaitForCoinAnimation>d__92();
    }
    private void NoAdButtonClicked()
    {
        var val_5;
        System.Action val_7;
        GameBehavior val_1 = App.getBehavior;
        MetaGameBehavior val_2 = 1152921504946249728 + ((X1 + 72) << 4);
        val_5 = null;
        val_5 = null;
        val_7 = TRVLevelComplete.<>c.<>9__93_0;
        if(val_7 == null)
        {
                System.Action val_3 = null;
            val_7 = val_3;
            val_3 = new System.Action(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<NoAdButtonClicked>b__93_0());
            TRVLevelComplete.<>c.<>9__93_0 = val_7;
        }
        
        mem2[0] = val_7;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void StoreButtonClicked()
    {
        var val_5;
        var val_6;
        System.Action val_8;
        val_5 = null;
        val_5 = null;
        PurchaseProxy.currentPurchasePoint = 2;
        GameBehavior val_1 = App.getBehavior;
        val_6 = null;
        val_6 = null;
        val_8 = TRVLevelComplete.<>c.<>9__94_0;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<StoreButtonClicked>b__94_0());
            TRVLevelComplete.<>c.<>9__94_0 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void GemStoreButtonClicked()
    {
        var val_6;
        var val_7;
        System.Action val_9;
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = 2;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        GameBehavior val_2 = App.getBehavior;
        val_7 = null;
        val_7 = null;
        val_9 = TRVLevelComplete.<>c.<>9__95_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<GemStoreButtonClicked>b__95_0());
            TRVLevelComplete.<>c.<>9__95_0 = val_9;
        }
        
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void HomeButtonClicked()
    {
        var val_5;
        System.Action val_7;
        GameBehavior val_1 = App.getBehavior;
        val_5 = null;
        val_5 = null;
        val_7 = TRVLevelComplete.<>c.<>9__96_0;
        if(val_7 == null)
        {
                System.Action val_3 = null;
            val_7 = val_3;
            val_3 = new System.Action(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<HomeButtonClicked>b__96_0());
            TRVLevelComplete.<>c.<>9__96_0 = val_7;
        }
        
        mem2[0] = val_7;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private System.Collections.IEnumerator SetupReward(UnityEngine.Transform parent, TRVLevelReward reward, bool anim = False)
    {
        .<>1__state = 0;
        .reward = reward;
        .parent = parent;
        .<>4__this = this;
        .anim = anim;
        return (System.Collections.IEnumerator)new TRVLevelComplete.<SetupReward>d__97();
    }
    public void setChestSprite(UnityEngine.UI.Image image, bool closed)
    {
        var val_3;
        var val_4;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        if(val_1.currentGame.myChest == 2)
        {
            goto label_5;
        }
        
        if(val_1.currentGame.myChest == 1)
        {
            goto label_6;
        }
        
        if(val_1.currentGame.myChest != 0)
        {
                return;
        }
        
        val_3 = 464;
        val_4 = 456;
        goto label_11;
        label_6:
        val_3 = 480;
        val_4 = 472;
        goto label_11;
        label_5:
        val_3 = 496;
        val_4 = 488;
        label_11:
        var val_2 = (closed != true) ? 488 : (val_3);
        image.sprite = null;
    }
    public void Close(bool showAd = True, bool load = True)
    {
        if(this.tournamentsButton != 0)
        {
                System.Delegate val_3 = System.Delegate.Remove(source:  this.tournamentsButton.ExternalClickCallback, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVLevelComplete::OnTournamentsClicked(bool isConnected)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            this.tournamentsButton.ExternalClickCallback = val_3;
        }
        
        if(showAd != false)
        {
                val_3.TryShowFomoOnComplete();
            bool val_5 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        }
        
        if(load != false)
        {
                GameBehavior val_6 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_6:
    }
    private void PostLevelVideoButtonClicked(bool connected)
    {
        bool val_7 = connected;
        if(val_7 == false)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        val_7 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
    }
    private void TryShowFomoOnComplete()
    {
        if((FOMOPackEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if((FOMOPackEventHandler.<Instance>k__BackingField.AvailableShow) == false)
        {
                return;
        }
        
        if((FOMOPackEventHandler.<Instance>k__BackingField.CanLevelShow) == false)
        {
                return;
        }
        
        if((FOMOPackEventHandler.<Instance>k__BackingField.TryShowPopup(isOOC:  false)) == false)
        {
                return;
        }
        
        FOMOPackEventHandler.<Instance>k__BackingField.SetShowedLevel();
    }
    private void OnTournamentsClicked(bool isConnected)
    {
        var val_13;
        System.Action val_15;
        var val_16;
        string val_18;
        string val_19;
        if(isConnected == false)
        {
            goto label_1;
        }
        
        TournamentsManager val_1 = MonoSingleton<TournamentsManager>.Instance;
        if(val_1.currentTournamentInfo == null)
        {
            goto label_5;
        }
        
        GameBehavior val_2 = App.getBehavior;
        WGWindow val_4 = val_2.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        val_13 = null;
        val_13 = null;
        val_15 = TRVLevelComplete.<>c.<>9__102_0;
        if(val_15 == null)
        {
                System.Action val_5 = null;
            val_15 = val_5;
            val_5 = new System.Action(object:  TRVLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLevelComplete.<>c::<OnTournamentsClicked>b__102_0());
            TRVLevelComplete.<>c.<>9__102_0 = val_15;
        }
        
        mem2[0] = val_15;
        this.Close(showAd:  false, load:  false);
        return;
        label_1:
        val_16 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        UnityEngine.GameObject val_8 = this.tournamentsButton.gameObject;
        val_18 = "tournament_connection";
        val_19 = "Internet connection required. Please check your connection and try again!";
        goto label_21;
        label_5:
        val_16 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_18 = "tournament_processing";
        val_19 = "Currently processing tournament results! Try again in a few minutes.";
        label_21:
        val_16.ShowToolTip(objToToolTip:  this.tournamentsButton.gameObject, text:  Localization.Localize(key:  val_18, defaultValue:  val_19, useSingularKey:  false), topToolTip:  true, displayDuration:  3.5f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    public TRVLevelComplete()
    {
        this.gameButtons = new System.Collections.Generic.Dictionary<TRVPickerGameButton, System.Int32>();
        this.statViews = new System.Collections.Generic.List<UnityEngine.GameObject>();
        this.cardSpecificSprites = new System.Collections.Generic.List<UnityEngine.Sprite>();
    }
    private static TRVLevelComplete()
    {
        TRVLevelComplete.lastLevelCompleteAnimShownAt = 0;
        TRVLevelComplete.lastEventLevelCompleteAnimShownAt = 0;
    }
    private void <SetupPreGameState>b__80_0()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.StartMinigame());
    }
    private bool <RedrawMultiplier>b__84_0()
    {
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        MonoSingleton<TRVMainController>.Instance.RewardMultiPicked(multi:  val_2.currentGame.selectedMulitplier);
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.SetupPostMinigameState());
        return true;
    }
    private bool <OnVideoResponse>b__85_0()
    {
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        MonoSingleton<TRVMainController>.Instance.RewardMultiPicked(multi:  val_2.currentGame.selectedMulitplier);
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.SetupPostMinigameState());
        return true;
    }

}
