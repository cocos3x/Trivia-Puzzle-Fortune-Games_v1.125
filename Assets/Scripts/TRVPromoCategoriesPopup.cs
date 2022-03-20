using UnityEngine;
public class TRVPromoCategoriesPopup : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Image categoryImage;
    private UnityEngine.UI.Image progressFillBar;
    private UnityEngine.UI.Text levelText;
    private UnityEngine.UI.Text entryCostText;
    private UnityEngine.UI.Text categoryNameText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text nextLevelText;
    private UnityEngine.GameObject sponsoredByObject;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button entryButton;
    private UnityEngine.UI.Button rewardButton;
    private CoinCurrencyCollectAnimationInstantiator coinAnim;
    private UnityEngine.Transform coinFlyTo;
    private UnityEngine.GameObject playbuttonLobbyGroup;
    private System.Collections.Generic.List<TRVPromoCategoriesSliderTick> sliderTicks;
    private GemsCollectAnimationInstantiator gemsAnim;
    private TRVPromoCategory currentPromo;
    private TRVQuizProgress currentGame;
    private bool categoryComplete;
    private bool shouldReward;
    private bool initNextLevelOnContinue;
    private bool returnToCategorySelectOnClose;
    private bool paidForEntryAlready;
    
    // Properties
    private int entryCost { get; }
    private TRVPromoCategoriesHandler PromoHandler { get; }
    
    // Methods
    private int get_entryCost()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1._quizEntryCost;
    }
    private TRVPromoCategoriesHandler get_PromoHandler()
    {
        return MonoSingleton<TRVPromoCategoriesHandler>.Instance;
    }
    public void SetupWithPromo(TRVPromoCategory promo, bool hidePaidEntry, bool returnToCategorySelectOnButtonClose = False, bool continueToNextLevel = False)
    {
        var val_5;
        bool val_1 = hidePaidEntry;
        object[] val_2 = new object[3];
        val_2[0] = val_1;
        bool val_3 = returnToCategorySelectOnButtonClose;
        val_2[1] = val_3;
        bool val_4 = continueToNextLevel;
        val_2[2] = val_4;
        UnityEngine.Debug.LogErrorFormat(format:  "SetupWithPromo hidePaidEntry {0} returnToCategorySelectOnButtonClose {1} continueToNextLevel {2}", args:  val_2);
        val_5 = null;
        val_5 = null;
        TRVPromoCategoriesHandler.CurrentlyShownPromo = promo;
        this.currentPromo = promo;
        this.paidForEntryAlready = val_1;
        this.initNextLevelOnContinue = val_4;
        this.returnToCategorySelectOnClose = val_3;
        this.SetupUI();
    }
    private void SetupUI()
    {
        ButtonClickedEvent val_51;
        UnityEngine.Events.UnityAction val_52;
        IntPtr val_53;
        var val_54;
        var val_55;
        System.Action<TRVPromoCategoriesSliderTick> val_57;
        var val_60;
        string val_63;
        var val_64;
        TRVQuizProgress val_65;
        var val_66;
        var val_67;
        System.Delegate val_68;
        var val_69;
        if(this.currentPromo == null)
        {
            goto label_1;
        }
        
        if(this.paidForEntryAlready == false)
        {
            goto label_3;
        }
        
        this.playbuttonLobbyGroup.SetActive(value:  false);
        val_51 = this.entryButton.m_OnClick;
        val_52 = new UnityEngine.Events.UnityAction();
        if(this.initNextLevelOnContinue == false)
        {
            goto label_5;
        }
        
        val_53 = 1152921517201667456;
        goto label_6;
        label_1:
        UnityEngine.Debug.LogError(message:  "TRVPromoCategoriesPopup attempted to show & SetupUI without a currentPromo! Closing window!");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_3:
        this.playbuttonLobbyGroup.SetActive(value:  true);
        string val_3 = this.playbuttonLobbyGroup.entryCost.ToString();
        val_51 = this.entryButton.m_OnClick;
        val_52 = new UnityEngine.Events.UnityAction();
        val_54 = System.Void TRVPromoCategoriesPopup::OnButtonClickLobby();
        goto label_12;
        label_5:
        val_53 = 1152921517201694336;
        label_6:
        label_12:
        val_52 = new UnityEngine.Events.UnityAction(object:  this, method:  val_53);
        val_51.AddListener(call:  new UnityEngine.Events.UnityAction());
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVPromoCategoriesPopup::<SetupUI>b__28_1()));
        this.sponsoredByObject.SetActive(value:  (this.currentPromo.promoCategoryType == 0) ? 1 : 0);
        if(this.currentPromo.promoCategoryType != 0)
        {
                string val_7 = this.currentPromo.subCategoryName.ToUpper();
        }
        
        string val_8 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
        this.categoryImage.sprite = MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetIcon(promoCategory:  this.currentPromo);
        int val_12 = this.categoryImage.PromoHandler.GetActivePromoProgress(subcategory:  this.currentPromo.subCategoryName);
        int val_13 = this.currentPromo.RequiredQuizzesToComplete;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_15 = val_13.PromoHandler.GetPromoRewards(promoCategory:  this.currentPromo.subCategoryName);
        System.Collections.Generic.List<TSource> val_17 = System.Linq.Enumerable.ToList<System.Int32>(source:  val_15.Keys);
        val_55 = null;
        val_55 = null;
        val_57 = TRVPromoCategoriesPopup.<>c.<>9__28_2;
        if(val_57 == null)
        {
                System.Action<TRVPromoCategoriesSliderTick> val_18 = null;
            val_57 = val_18;
            val_18 = new System.Action<TRVPromoCategoriesSliderTick>(object:  TRVPromoCategoriesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVPromoCategoriesPopup.<>c::<SetupUI>b__28_2(TRVPromoCategoriesSliderTick x));
            TRVPromoCategoriesPopup.<>c.<>9__28_2 = val_57;
        }
        
        this.sliderTicks.ForEach(action:  val_18);
        if(1152921504955195392 < 1)
        {
            goto label_42;
        }
        
        var val_52 = 0;
        label_53:
        if(val_52 >= 1152921517201817216)
        {
            goto label_42;
        }
        
        if(1152921517201817216 <= val_52)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(1152921504955195392 <= val_52)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_57 = null;
        val_60 = val_57;
        if(1152921504955195392 <= val_52)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_60 = null;
        }
        
        if(1152921504955195392 <= val_52)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_51 = val_12;
        Init(myValue:  279392256, maxValue:  val_13, myDisplayAmount:  279392256, lastTickOffset:  22, isComplete:  (val_51 >= null) ? 1 : 0);
        if(null <= val_52)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_51 = val_51 + 0;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        var val_53 = 1152921515438572976;
        (val_12 + 0) + 32.ShowRewardAmount(showReward:  (this.currentPromo.promoCategoryType == 1) ? 1 : 0, rewardAmount:  val_15.Item[TRVPromoCategory.__il2cppRuntimeField_byval_arg]);
        val_52 = val_52 + 1;
        if(val_52 < this.currentPromo.promoCategoryType)
        {
            goto label_53;
        }
        
        label_42:
        if(this.currentPromo.promoCategoryType == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_53 = val_53 + ((this.currentPromo.promoCategoryType - 1) << 2);
        float val_54 = (float)(1152921515438572976 + ((this.currentPromo.promoCategoryType - 1)) << 2) + 32;
        val_54 = (float)val_12 / val_54;
        this.progressFillBar.fillAmount = val_54;
        int val_24 = this.progressFillBar.PromoHandler.GetRemainingLevelsForPromo(currentPromo:  this.currentPromo);
        this.categoryComplete = (val_24 < 1) ? 1 : 0;
        if(this.currentPromo.promoCategoryType == 0)
        {
            goto label_58;
        }
        
        if(val_24 <= 0)
        {
            goto label_61;
        }
        
        val_63 = "Complete {0} level{1} to earn\nthe next reward!";
        goto label_60;
        label_58:
        if(val_24 <= 0)
        {
            goto label_61;
        }
        
        val_63 = "Complete {0} level{1} to earn a\nspecial reward!";
        label_60:
        string val_27 = System.String.Format(format:  val_63, arg0:  val_24, arg1:  (val_24 == 1) ? "" : "s");
        goto label_62;
        label_61:
        label_62:
        val_64 = 1152921504765632512;
        if((MonoSingleton<TRVMainController>.Instance) != 0)
        {
                TRVMainController val_30 = MonoSingleton<TRVMainController>.Instance;
            if(val_30.currentGame != null)
        {
                TRVMainController val_31 = MonoSingleton<TRVMainController>.Instance;
            this.currentGame = val_31.currentGame;
        }
        
        }
        
        if((MonoSingleton<TRVMainController>.Instance) == 0)
        {
            goto label_86;
        }
        
        val_65 = this.currentGame;
        if(val_65 == null)
        {
            goto label_88;
        }
        
        bool val_34 = System.String.op_Equality(a:  this.currentGame.quizCategory, b:  this.currentPromo.subCategoryName);
        if(val_34 == false)
        {
            goto label_86;
        }
        
        bool val_36 = val_34.PromoHandler.IsActivePromo(subCategoryName:  this.currentGame.quizCategory);
        if(val_36 == false)
        {
            goto label_86;
        }
        
        var val_39 = ((val_36.PromoHandler.GetCurrentQuizReward(progress:  this.currentGame)) > 0) ? 1 : 0;
        goto label_88;
        label_86:
        val_65 = false;
        label_88:
        this.shouldReward = val_65;
        this.rewardButton.m_OnClick.RemoveAllListeners();
        this.rewardButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVPromoCategoriesPopup::OnRewardButtonClicked()));
        UnityEngine.GameObject val_41 = this.rewardButton.gameObject;
        if(this.categoryComplete == false)
        {
            goto label_94;
        }
        
        val_66 = 1;
        if(val_41 != null)
        {
            goto label_95;
        }
        
        label_94:
        label_95:
        val_41.SetActive(value:  (this.shouldReward == true) ? 1 : 0);
        UnityEngine.GameObject val_43 = this.entryButton.gameObject;
        if(this.categoryComplete == false)
        {
            goto label_99;
        }
        
        val_67 = 0;
        if(val_43 != null)
        {
            goto label_100;
        }
        
        label_99:
        label_100:
        val_43.SetActive(value:  (this.shouldReward == false) ? 1 : 0);
        this.closeButton.gameObject.SetActive(value:  (this.shouldReward == false) ? 1 : 0);
        if(this.shouldReward != false)
        {
                val_64 = 1152921504614301696;
            System.Action val_47 = null;
            val_68 = val_47;
            val_47 = new System.Action(object:  this, method:  System.Void TRVPromoCategoriesPopup::OnGemsRewardAnimComplete());
            System.Delegate val_48 = System.Delegate.Combine(a:  this.rewardButton.m_OnClick, b:  val_47);
            val_69 = null;
            if(val_48 != null)
        {
                if(null != val_69)
        {
            goto label_108;
        }
        
        }
        
            mem2[0] = val_48;
        }
        else
        {
                val_68 = 1152921504614301696;
            mem2[0] = new System.Action(object:  this, method:  System.Void TRVPromoCategoriesPopup::<SetupUI>b__28_3());
            val_69 = null;
        }
        
        mem[1152921517202027112] = new System.Action(object:  this, method:  System.Void TRVPromoCategoriesPopup::UpdateTime());
        return;
        label_108:
    }
    private void OnRewardButtonClicked()
    {
        this.rewardButton.interactable = false;
        if(this.currentGame == null)
        {
            goto label_2;
        }
        
        bool val_1 = System.String.op_Inequality(a:  this.currentGame.quizCategory, b:  this.currentPromo.subCategoryName);
        if(val_1 == false)
        {
            goto label_4;
        }
        
        label_2:
        this.GoToExternalUrl();
        return;
        label_4:
        int val_3 = val_1.PromoHandler.GetCurrentQuizReward(progress:  this.currentGame);
        val_3.PromoHandler.CollectReward(progress:  this.currentGame);
        if((val_3 >= 1) && (this.shouldReward != false))
        {
                Player val_5 = App.Player;
            Player val_6 = App.Player;
            decimal val_7 = System.Decimal.op_Implicit(value:  val_6._gems);
            this.gemsAnim.Play(fromValue:  val_5._gems - val_3, toValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
            return;
        }
        
        this.GoToExternalUrl();
        this.CloseButtonClicked();
    }
    private void OnGemsRewardAnimComplete()
    {
        this.GoToExternalUrl();
        this.CloseButtonClicked();
    }
    private void GoToExternalUrl()
    {
        if(this.currentPromo == null)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  this.currentPromo.rewardUrl)) != false)
        {
                return;
        }
        
        TrackingComponent.CurrentIntent = 11;
        UnityEngine.Application.OpenURL(url:  this.currentPromo.rewardUrl);
    }
    private void OnButtonClickLobby()
    {
        var val_17;
        var val_18;
        System.Action val_20;
        decimal val_3 = System.Decimal.op_Implicit(value:  App.Player.entryCost);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) != false)
        {
                WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
            val_5.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            int val_6 = val_5.sound.entryCost;
            decimal val_7 = System.Decimal.op_Implicit(value:  val_6);
            bool val_8 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, source:  "Promo Category", externalParams:  0, animated:  true);
            UnityEngine.Vector3 val_9 = this.coinFlyTo.position;
            int val_10 = this.coinFlyTo.entryCost;
            val_6.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, particleCount:  0, animateStatView:  false);
            this.entryButton.interactable = false;
            UUI_EventsController.DisableInputs();
            this.GetComponentInChildren<UnityEngine.ParticleSystem>().Stop(withChildren:  true, stopBehavior:  0);
            UnityEngine.Coroutine val_13 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
            return;
        }
        
        val_17 = null;
        val_17 = null;
        PurchaseProxy.currentPurchasePoint = 0;
        GameBehavior val_14 = App.getBehavior;
        val_18 = null;
        val_18 = null;
        val_20 = TRVPromoCategoriesPopup.<>c.<>9__32_0;
        if(val_20 == null)
        {
                System.Action val_16 = null;
            val_20 = val_16;
            val_16 = new System.Action(object:  TRVPromoCategoriesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVPromoCategoriesPopup.<>c::<OnButtonClickLobby>b__32_0());
            TRVPromoCategoriesPopup.<>c.<>9__32_0 = val_20;
        }
        
        val_14.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_16);
        this.CloseButtonClicked();
    }
    private void OnButtonClickedCatSelectMenu()
    {
        null = null;
        TRVMainController.noAnswerSelectedCharacter = 3;
        .categoryName = this.currentPromo.subCategoryName;
        MonoSingleton<TRVMainController>.Instance.InitSpecialCategories(categorySelectionInfo:  new TRVCategorySelectionInfo(), primaryCategoryName:  this.currentPromo.subCategoryName);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVPromoCategoriesPopup.<WaitForCoinAnimation>d__34();
    }
    private void UpdateTime()
    {
        var val_15;
        var val_16;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = this.currentPromo.timeEnd.Subtract(value:  new System.DateTime() {dateData = val_1.dateData});
        val_15 = null;
        val_15 = null;
        if((System.TimeSpan.Compare(t1:  new System.TimeSpan() {_ticks = val_2._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) == 1)
        {
                val_16 = null;
            val_16 = null;
        }
        
        object[] val_4 = new object[4];
        val_4[0] = System.TimeSpan.Zero.Days.ToString(format:  "0");
        val_4[1] = System.TimeSpan.Zero.Hours.ToString(format:  "00");
        val_4[2] = System.TimeSpan.Zero.Minutes.ToString(format:  "00");
        val_4[3] = System.TimeSpan.Zero.Seconds.ToString(format:  "00");
        string val_13 = System.String.Format(format:  "Event ends : {0}d {1}h {2}m {3}s", args:  val_4);
        if(System.TimeSpan.Zero.TotalSeconds > 0f)
        {
                return;
        }
        
        this.CloseButtonClicked();
    }
    private void CloseButtonClicked()
    {
        if(this.returnToCategorySelectOnClose != false)
        {
                if((MonoSingleton<TRVMainController>.Instance) != 0)
        {
                MonoSingleton<TRVMainController>.Instance.Init(currentlySelectedCategores:  0, fromReroll:  false);
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVPromoCategoriesPopup()
    {
    
    }
    private void <SetupUI>b__28_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <SetupUI>b__28_1()
    {
        this.CloseButtonClicked();
    }
    private void <SetupUI>b__28_3()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  static_value_02807000, b:  new System.Action(object:  this, method:  System.Void TRVPromoCategoriesPopup::OnGemsRewardAnimComplete()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        mem2[0] = val_2;
        return;
        label_3:
    }

}
