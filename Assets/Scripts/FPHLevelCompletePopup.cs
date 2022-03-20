using UnityEngine;
public class FPHLevelCompletePopup : MonoBehaviour
{
    // Fields
    private const string lastChapterCollectedKey = "lastChapterCollected";
    private static int lastLevelCompletAnimShownAt;
    private UnityEngine.GameObject levelSuccessGroup;
    private UnityEngine.GameObject levelCompleteBanner;
    private UnityEngine.UI.Text pregameCointext;
    private UnityEngine.UI.Text pregameStarText;
    private UnityEngine.UI.Button pregameOpenButton;
    private UnityEngine.GameObject preminigameTapContinueObject;
    private UnityEngine.UI.Image openChestImage;
    private UnityEngine.UI.Image closedChestImage;
    private FPHPickerGameButton minigameButtonPrefab;
    private System.Collections.Generic.List<FPHPickerGameButton> gameButtons;
    private UnityEngine.GameObject chestRewardMultiParent;
    private UnityEngine.GameObject tapToPick;
    private UnityEngine.UI.Image minigameBackdrop;
    private TweenCoinsText minigameCoinText;
    private TweenCoinsText minigameStarText;
    private UnityEngine.GameObject postMinigameGroup;
    private UnityEngine.GameObject nextQuizCostHolder;
    private UnityEngine.UI.Text chapterProgressBarText;
    private UnityEngine.UI.Text nextGameButtonText;
    private UnityEngine.UI.Text nextQuizCostText;
    private UnityEngine.UI.Image progressBarImage;
    private UnityEngine.UI.Button nextQuizButton;
    private PortraitCollectionProgressBar portraitProgressBar;
    private System.Collections.Generic.List<UnityEngine.GameObject> statViews;
    private CoinCurrencyParticles coinParticle;
    private GoldenApplesParticles goldParticle;
    private CurrencyStatView starStatView;
    private CurrencyStatView coinStatView;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button gemStoreButton;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.Sprite WoodChestIcon;
    private UnityEngine.Sprite WoodChestOpen;
    private UnityEngine.Sprite SilverChestIcon;
    private UnityEngine.Sprite SilverChestOpen;
    private UnityEngine.Sprite GoldenChestIcon;
    private UnityEngine.Sprite GoldenChestOpen;
    private UnityEngine.Sprite DiamondChestIcon;
    private UnityEngine.Sprite DiamondChestOpen;
    private System.Collections.Generic.List<UnityEngine.Sprite> cardSpecificSprites;
    
    // Properties
    private int chapterLength { get; }
    private int playerLevel { get; }
    private bool ChapterRewardAvailable { get; }
    private FPHGameplayState currentGame { get; }
    private FPHEcon econ { get; }
    
    // Methods
    private int get_chapterLength()
    {
        FPHEcon val_1 = this.econ;
        return (int)val_1.levelsPerChapter;
    }
    private int get_playerLevel()
    {
        Player val_1 = App.Player;
        val_1 = val_1 - 1;
        return (int)val_1;
    }
    private bool get_ChapterRewardAvailable()
    {
        var val_7;
        int val_1 = this.playerLevel;
        FPHEcon val_2 = val_1.econ;
        int val_7 = val_2.levelsPerChapter;
        val_7 = val_1 - ((val_1 / val_7) * val_7);
        if(val_7 != 0)
        {
                val_7 = 0;
            return (bool)(val_4 != val_4.playerLevel) ? 1 : 0;
        }
        
        int val_4 = CPlayerPrefs.GetInt(key:  "lastChapterCollected", defaultValue:  0);
        return (bool)(val_4 != val_4.playerLevel) ? 1 : 0;
    }
    private FPHGameplayState get_currentGame()
    {
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        return (FPHGameplayState)val_1.currentGame;
    }
    private FPHEcon get_econ()
    {
        return App.GetGameSpecificEcon<FPHEcon>();
    }
    private void Start()
    {
        var val_15;
        System.Action<UnityEngine.GameObject> val_17;
        this.levelSuccessGroup.gameObject.SetActive(value:  false);
        this.postMinigameGroup.gameObject.SetActive(value:  false);
        this.storeButton.m_OnClick.RemoveAllListeners();
        this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHLevelCompletePopup::StoreButtonClicked()));
        this.gemStoreButton.m_OnClick.RemoveAllListeners();
        this.gemStoreButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHLevelCompletePopup::GemStoreButtonClicked()));
        this.homeButton.m_OnClick.RemoveAllListeners();
        this.homeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHLevelCompletePopup::HomeButtonClicked()));
        this.homeButton.gameObject.SetActive(value:  false);
        val_15 = null;
        val_15 = null;
        val_17 = FPHLevelCompletePopup.<>c.<>9__52_0;
        if(val_17 == null)
        {
                System.Action<UnityEngine.GameObject> val_7 = null;
            val_17 = val_7;
            val_7 = new System.Action<UnityEngine.GameObject>(object:  FPHLevelCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHLevelCompletePopup.<>c::<Start>b__52_0(UnityEngine.GameObject x));
            FPHLevelCompletePopup.<>c.<>9__52_0 = val_17;
        }
        
        this.statViews.ForEach(action:  val_7);
        if((val_8.<tokensRemaining>k__BackingField) >= 1)
        {
                if(val_9.hasCollectedChest == false)
        {
            goto label_28;
        }
        
        }
        
        label_34:
        this.SetupPostMinigameState();
        label_35:
        if((val_10.<tokensRemaining>k__BackingField) > 0)
        {
                return;
        }
        
        FPHGameplayState val_11 = this.currentGame.currentGame;
        if(val_11.hasCollectedChest == false)
        {
            goto label_32;
        }
        
        return;
        label_28:
        FPHGameplayState val_12 = this.statViews.currentGame.currentGame.currentGame;
        if(val_12.chestType == 1)
        {
            goto label_34;
        }
        
        this.SetupPreGameState();
        goto label_35;
        label_32:
        FPHGameplayController.Instance.RewardMultiPicked(multiplier:  1);
        FPHGameplayController.Instance.TrackLevelComplete(isSuccess:  true, failReason:  0);
    }
    private void SetupPreGameState()
    {
        var val_17;
        var val_18;
        this.levelCompleteBanner.gameObject.SetActive(value:  true);
        this.setChestSprite(image:  this.closedChestImage, closed:  true);
        UnityEngine.GameObject val_2 = this.openChestImage.gameObject;
        val_2.SetActive(value:  false);
        FPHGameplayState val_3 = val_2.currentGame;
        int val_17 = val_3.<tokensRemaining>k__BackingField;
        val_17 = val_3.rewardMultiplier * val_17;
        val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        string val_5 = System.String.Format(format:  val_17.ToString(), args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        FPHGameplayState val_6 = this.pregameCointext.currentGame;
        int val_18 = val_6.starsEarned;
        val_18 = val_6.eventReward + (val_6.rewardMultiplier * val_18);
        val_18 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_18 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_18 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_18 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        string val_8 = System.String.Format(format:  val_18.ToString(), args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        this.pregameCointext.gameObject.SetActive(value:  false);
        this.pregameStarText.gameObject.SetActive(value:  false);
        this.pregameOpenButton.m_OnClick.RemoveAllListeners();
        this.pregameOpenButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHLevelCompletePopup::<SetupPreGameState>b__53_0()));
        this.levelSuccessGroup.gameObject.SetActive(value:  true);
        UnityEngine.CanvasGroup val_13 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.levelSuccessGroup);
        val_13.alpha = 0f;
        DG.Tweening.Tweener val_15 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  val_13, endValue:  1f, duration:  0.5f), delay:  0.3f);
        this.minigameBackdrop.gameObject.SetActive(value:  false);
    }
    private void SetupPostMinigameState()
    {
        int val_41;
        var val_42;
        System.Action<UnityEngine.GameObject> val_44;
        var val_45;
        var val_46;
        var val_47;
        var val_48;
        int val_49;
        val_41 = 1152921504902746112;
        val_42 = null;
        val_42 = null;
        val_44 = FPHLevelCompletePopup.<>c.<>9__54_0;
        if(val_44 == null)
        {
                System.Action<UnityEngine.GameObject> val_1 = null;
            val_44 = val_1;
            val_1 = new System.Action<UnityEngine.GameObject>(object:  FPHLevelCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHLevelCompletePopup.<>c::<SetupPostMinigameState>b__54_0(UnityEngine.GameObject x));
            FPHLevelCompletePopup.<>c.<>9__54_0 = val_44;
        }
        
        this.statViews.ForEach(action:  val_1);
        this.homeButton.gameObject.SetActive(value:  (~this.ChapterRewardAvailable) & 1);
        val_45 = null;
        val_45 = null;
        this.portraitProgressBar.Init(animate:  (FPHLevelCompletePopup.lastLevelCompletAnimShownAt != playerLevel) ? 1 : 0);
        int val_7 = this.portraitProgressBar.playerLevel;
        if(FPHLevelCompletePopup.lastLevelCompletAnimShownAt == val_7)
        {
                Player val_8 = App.Player;
            decimal val_9 = System.Decimal.op_Implicit(value:  val_8._stars);
            this.starStatView.SetBalanceNow(newBalance:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            Player val_10 = App.Player;
            this.coinStatView.SetBalanceNow(newBalance:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = val_9.lo, mid = val_9.mid});
        }
        else
        {
                val_46 = null;
            val_46 = null;
            FPHLevelCompletePopup.lastLevelCompletAnimShownAt = val_7.playerLevel;
            WGAudioController val_12 = MonoSingleton<WGAudioController>.Instance;
            val_12.sound.PlayGameSpecificSound(id:  "TRVQuizCompleteCollect", clipIndex:  0);
            this.nextQuizButton.interactable = false;
        }
        
        FPHEcon val_15 = this.StartCoroutine(routine:  this.OnRewardAnimFinished(delay:  3f)).econ;
        string val_16 = val_15.levelEntryFee.ToString();
        if(this.ChapterRewardAvailable != false)
        {
                string val_18 = Localization.Localize(key:  "collect_reward_upper", defaultValue:  "COLLECT REWARD", useSingularKey:  false);
            val_47 = 0;
        }
        else
        {
                GameBehavior val_20 = App.getBehavior;
            decimal val_21 = System.Decimal.op_Implicit(value:  val_20.<metaGameBehavior>k__BackingField);
            val_41 = val_21.lo;
            decimal val_22 = new System.Decimal(value:  16);
            string val_24 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "level_upper", defaultValue:  "LEVEL", useSingularKey:  false), arg1:  MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_41, mid = val_21.mid}, maxSigFigs:  2, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_22.flags, hi = val_22.flags, lo = val_22.lo, mid = val_22.lo}, useRichText:  false, withSpaces:  false));
            val_47 = 1;
        }
        
        this.nextQuizCostHolder.SetActive(value:  true);
        val_48 = null;
        val_48 = null;
        if(FPHLevelCompletePopup.lastLevelCompletAnimShownAt == playerLevel)
        {
                bool val_26 = this.ChapterRewardAvailable;
            if(val_26 != false)
        {
                FPHEcon val_27 = val_26.econ;
            val_49 = val_27.levelsPerChapter;
        }
        else
        {
                int val_28 = val_26.playerLevel;
            FPHEcon val_29 = val_28.econ;
            val_49 = val_28 - ((val_28 / val_29.levelsPerChapter) * val_29.levelsPerChapter);
        }
        
            FPHEcon val_31 = val_49.econ;
            val_41 = val_31.levelsPerChapter;
            string val_33 = System.String.Format(format:  "{0}/{1} {2}", arg0:  val_49, arg1:  val_31.levelsPerChapter, arg2:  Localization.Localize(key:  "levels", defaultValue:  "Levels", useSingularKey:  false));
            bool val_34 = this.ChapterRewardAvailable;
            if(val_34 != false)
        {
            
        }
        else
        {
                int val_35 = val_34.playerLevel;
            FPHEcon val_37 = val_35.econ.econ;
            int val_38 = val_35 / val_36.levelsPerChapter;
            val_38 = val_35 - (val_38 * val_36.levelsPerChapter);
            float val_41 = (float)val_37.levelsPerChapter;
            val_41 = (float)val_38 / val_41;
        }
        
            this.progressBarImage.fillAmount = val_41;
        }
        
        this.nextQuizButton.m_OnClick.RemoveAllListeners();
        this.nextQuizButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void FPHLevelCompletePopup::NextQuizButtonClicked()));
        this.postMinigameGroup.gameObject.SetActive(value:  true);
    }
    private System.Collections.IEnumerator OnRewardAnimFinished(float delay = 0)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .delay = delay;
        return (System.Collections.IEnumerator)new FPHLevelCompletePopup.<OnRewardAnimFinished>d__55();
    }
    private System.Collections.IEnumerator StartMinigame()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new FPHLevelCompletePopup.<StartMinigame>d__56();
    }
    private void MultiplierPicked(int multi, FPHPickerGameButton selectedButton)
    {
        UnityEngine.Object val_5;
        var val_6;
        int val_19;
        var val_20;
        var val_21;
        UnityEngine.Object val_22;
        UnityEngine.Object val_23;
        var val_24;
        var val_25;
        val_19 = multi;
        val_20 = 1152921504901894144;
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        if((val_1 & 1) == 0)
        {
            goto label_40;
        }
        
        FPHEcon val_2 = val_1.econ;
        val_19 = val_2.keyboardTutorialRewardMultiplier;
        System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
        val_3.Add(item:  4);
        val_3.Add(item:  7);
        List.Enumerator<T> val_4 = this.gameButtons.GetEnumerator();
        val_21 = 0;
        goto label_8;
        label_20:
        val_22 = val_5;
        val_23 = selectedButton;
        if(val_22 == val_23)
        {
                val_24 = val_19;
        }
        else
        {
                val_22 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_24 = mem[(UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32];
            val_24 = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32;
            val_21 = 1;
        }
        
        if(this.cardSpecificSprites == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = 0;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = ;
        label_8:
        if(val_6.MoveNext() == true)
        {
            goto label_20;
        }
        
        val_6.Dispose();
        val_20 = 1152921504901894144;
        label_40:
        FPHGameplayController.Instance.RewardMultiPicked(multiplier:  val_19);
        FPHGameplayController.Instance.TrackLevelComplete(isSuccess:  true, failReason:  0);
        FPHGameplayController val_12 = FPHGameplayController.Instance;
        List.Enumerator<T> val_13 = this.gameButtons.GetEnumerator();
        label_30:
        val_23 = public System.Boolean List.Enumerator<FPHPickerGameButton>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_27;
        }
        
        val_22 = val_5;
        if(val_22 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.UI.Button val_15 = val_22.myButton;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.interactable = false;
        goto label_30;
        label_27:
        val_6.Dispose();
        UnityEngine.Coroutine val_17 = this.StartCoroutine(routine:  this.animateReveal(selected:  selectedButton));
    }
    private System.Collections.IEnumerator animateReveal(FPHPickerGameButton selected)
    {
        .<>1__state = 0;
        .selected = selected;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new FPHLevelCompletePopup.<animateReveal>d__58();
    }
    public void NextQuizButtonClicked()
    {
        var val_33;
        var val_34;
        System.Action val_36;
        bool val_1 = this.ChapterRewardAvailable;
        if(val_1 != false)
        {
                WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
            val_2.sound.PlayGeneralSound(type:  1, oneshot:  true, pitch:  1f, vol:  1f);
            GameBehavior val_4 = App.getBehavior;
            decimal val_5 = System.Decimal.op_Implicit(value:  val_4.<metaGameBehavior>k__BackingField);
            decimal val_6 = new System.Decimal(value:  16);
            string val_8 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "level_upper", defaultValue:  "LEVEL", useSingularKey:  false), arg1:  MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, maxSigFigs:  2, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo}, useRichText:  false, withSpaces:  false));
            this.nextQuizCostHolder.SetActive(value:  true);
            this.homeButton.gameObject.SetActive(value:  true);
            GameBehavior val_10 = App.getBehavior;
            val_10.<metaGameBehavior>k__BackingField.Setup(rewardSource:  3);
            CPlayerPrefs.SetInt(key:  "lastChapterCollected", val:  val_10.<metaGameBehavior>k__BackingField.playerLevel);
            CPlayerPrefs.Save();
            return;
        }
        
        FPHEcon val_13 = val_1.econ;
        Player val_14 = App.Player;
        decimal val_15 = System.Decimal.op_Implicit(value:  val_13.levelEntryFee);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_14._credits, hi = val_14._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid})) != false)
        {
                WGAudioController val_17 = MonoSingleton<WGAudioController>.Instance;
            val_17.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            FPHGameplayController val_18 = FPHGameplayController.Instance;
            val_18.currentGame.trackingLevel = App.Player;
            decimal val_20 = System.Decimal.op_Implicit(value:  val_13.levelEntryFee);
            bool val_21 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid}, source:  "Start Quiz", externalParams:  0, animated:  true);
            UnityEngine.Vector3 val_24 = this.coinStatView.AppleIcon.position;
            this.coinParticle.transform.position = new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z};
            UnityEngine.Vector3 val_26 = this.nextQuizButton.transform.position;
            this.coinParticle.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z}, particleCount:  0, animateStatView:  false);
            this.nextQuizButton.interactable = false;
            UUI_EventsController.DisableInputs();
            UnityEngine.Coroutine val_28 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
            return;
        }
        
        val_33 = null;
        val_33 = null;
        PurchaseProxy.currentPurchasePoint = 93;
        GameBehavior val_29 = App.getBehavior;
        val_34 = null;
        val_34 = null;
        val_36 = FPHLevelCompletePopup.<>c.<>9__59_0;
        if(val_36 == null)
        {
                System.Action val_31 = null;
            val_36 = val_31;
            val_31 = new System.Action(object:  FPHLevelCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHLevelCompletePopup.<>c::<NextQuizButtonClicked>b__59_0());
            FPHLevelCompletePopup.<>c.<>9__59_0 = val_36;
        }
        
        val_29.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_31);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new FPHLevelCompletePopup.<WaitForCoinAnimation>d__60();
    }
    private void setChestSprite(UnityEngine.UI.Image image, bool closed)
    {
        FPHGameplayState val_1 = this.currentGame;
        if(val_1.chestType > 3)
        {
                return;
        }
        
        var val_3 = 32562476 + (val_1.chestType) << 2;
        val_3 = val_3 + 32562476;
        goto (32562476 + (val_1.chestType) << 2 + 32562476);
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
        val_8 = FPHLevelCompletePopup.<>c.<>9__62_0;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  FPHLevelCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHLevelCompletePopup.<>c::<StoreButtonClicked>b__62_0());
            FPHLevelCompletePopup.<>c.<>9__62_0 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_3);
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
        val_9 = FPHLevelCompletePopup.<>c.<>9__63_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  FPHLevelCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHLevelCompletePopup.<>c::<GemStoreButtonClicked>b__63_0());
            FPHLevelCompletePopup.<>c.<>9__63_0 = val_9;
        }
        
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void HomeButtonClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        this.Close(showAd:  true);
    }
    private void Close(bool showAd = True)
    {
        if(showAd != false)
        {
                bool val_2 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        }
        
        this.StopAllCoroutines();
        this.portraitProgressBar.StopAllCoroutines();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public FPHLevelCompletePopup()
    {
        this.gameButtons = new System.Collections.Generic.List<FPHPickerGameButton>();
        this.statViews = new System.Collections.Generic.List<UnityEngine.GameObject>();
        this.cardSpecificSprites = new System.Collections.Generic.List<UnityEngine.Sprite>();
    }
    private static FPHLevelCompletePopup()
    {
        FPHLevelCompletePopup.lastLevelCompletAnimShownAt = 0;
    }
    private void <SetupPreGameState>b__53_0()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.StartMinigame());
    }

}
