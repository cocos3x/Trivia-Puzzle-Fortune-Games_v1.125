using UnityEngine;
public class WGDailyChallengeMainController : MainController
{
    // Fields
    private UnityEngine.GameObject progress_bar_group;
    private UnityEngine.RectTransform progress_bar_image;
    private UnityEngine.GameObject starPrefab;
    private UnityEngine.RectTransform progress_bar;
    private UnityEngine.UI.Text progress_bar_text;
    private WGGameplayMessage gameplayMessage;
    private DailyChallengeDefinition challengeDefinition;
    private DailyChallengeStarGroup starGroup;
    
    // Properties
    public static WGDailyChallengeMainController SpecificInstance { get; }
    public UnityEngine.GameObject GetProgressBarGroup { get; }
    
    // Methods
    public static WGDailyChallengeMainController get_SpecificInstance()
    {
        var val_3;
        string val_4;
        var val_5;
        var val_6;
        val_3 = null;
        val_3 = null;
        val_4 = MainController.extra_words_prefs_key;
        if(val_4 == 0)
        {
                val_5 = null;
            val_4 = UnityEngine.Object.FindObjectOfType<WGDailyChallengeMainController>();
            val_5 = null;
            MainController.extra_words_prefs_key = val_4;
        }
        
        val_6 = null;
        val_6 = null;
        return (WGDailyChallengeMainController)MainController.extra_words_prefs_key;
    }
    public UnityEngine.GameObject get_GetProgressBarGroup()
    {
        return (UnityEngine.GameObject)this.progress_bar_group;
    }
    private void Start()
    {
        this.OnStartLogic();
    }
    private void OnStartLogic()
    {
        object val_38;
        UnityEngine.Transform val_39;
        var val_40;
        var val_41;
        var val_42;
        var val_44;
        var val_46;
        val_38 = this;
        val_39 = 1152921515401808240;
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_1.PlayingMorning != true)
        {
                if(val_1.PlayingEvening == false)
        {
            goto label_5;
        }
        
        }
        
        DailyChallengeGameLevel val_3 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        mem[1152921517783013136] = val_3.gameLevel;
        WGDailyChallengeManager val_4 = MonoSingleton<WGDailyChallengeManager>.Instance;
        this.challengeDefinition = val_4.<Econ>k__BackingField.ChallengeDefinition;
        if(1152921504893161472 == 0)
        {
            goto label_14;
        }
        
        val_39 = 1152921504884269056;
        val_40 = null;
        val_40 = null;
        if(App.game == 1)
        {
            goto label_26;
        }
        
        val_41 = null;
        val_41 = null;
        if(App.game == 10)
        {
            goto label_26;
        }
        
        val_42 = null;
        val_42 = null;
        if(App.game != 7)
        {
            goto label_32;
        }
        
        label_26:
        label_98:
        SetActive(value:  true);
        label_14:
        UnityEngine.Vector2 val_7 = this.progress_bar_group.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        System.Collections.Generic.List<UnityEngine.Transform> val_8 = new System.Collections.Generic.List<UnityEngine.Transform>();
        WGDailyChallengeWordRegion.anim_delay = val_8;
        this.starGroup = this.progress_bar_group.GetComponentInChildren<DailyChallengeStarGroup>();
        float val_38 = 0.5f;
        val_38 = val_7.x * val_38;
        val_44 = 1152921515831934128;
        var val_40 = 0;
        label_54:
        if(val_40 >= this.challengeDefinition.StarThresholds)
        {
            goto label_39;
        }
        
        if(this.challengeDefinition <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        float val_39 = 0f;
        val_39 = val_7.x * val_39;
        val_39 = val_39 / 100f;
        val_39 = val_39 - val_38;
        UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  val_39, y:  0f, z:  0f);
        UnityEngine.Vector3 val_12 = this.progress_bar_group.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        UnityEngine.Quaternion val_13 = UnityEngine.Quaternion.identity;
        val_39 = this.starGroup.transform;
        val_8.Add(item:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.starPrefab, position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, rotation:  new UnityEngine.Quaternion() {x = val_13.x, y = val_13.y, z = val_13.z, w = val_13.w}, parent:  val_39).transform);
        val_40 = val_40 + 1;
        if(this.challengeDefinition != null)
        {
            goto label_54;
        }
        
        throw new NullReferenceException();
        label_39:
        this.progress_bar_group.SetActive(value:  true);
        this.UpdateProgressBar(delay:  0f);
        if(this.challengeDefinition == null)
        {
            goto label_56;
        }
        
        WordRegion val_17 = WordRegion.instance;
        val_44 = 1152921504614301696;
        System.Action val_18 = new System.Action(object:  Pan.tappingAllowed, method:  public System.Void Pan::EnablePan());
        val_17.addOnLevelLoadCompleteAction(callback:  val_18);
        Pan.tappingAllowed.Load(gameLevel:  val_18);
        WordRegion val_19 = WordRegion.instance;
        System.Action val_20 = new System.Action(object:  this, method:  System.Void WGDailyChallengeMainController::CheckDailyChallengeValidity());
        this.TrackLevelGenerationLevelStart(levelWord:  this.GetLevelWord());
        val_39 = 1152921504893161472;
        MonoSingleton<WordGameEventsController>.Instance.OnDailyChallengeInit();
        bool val_23 = UnityEngine.Object.op_Implicit(exists:  val_17);
        if(val_23 != false)
        {
                val_23.SetActive(value:  false);
        }
        
        bool val_24 = UnityEngine.Object.op_Implicit(exists:  val_17);
        if(val_24 != false)
        {
                val_24.SetActive(value:  true);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_17)) != false)
        {
                val_17.SetActive(value:  (~GoldenMultiplierManager.IsAvaialable) & 1);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_17)) != false)
        {
                val_17.SetActive(value:  GoldenMultiplierManager.IsAvaialable);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_17)) == false)
        {
            goto label_83;
        }
        
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_84;
        }
        
        string val_33 = WGDailyChallengeManagerHelper.GetLocMorningChallenge();
        goto label_85;
        label_56:
        this.FailedLoadingLevelData();
        return;
        label_5:
        this.progress_bar_group.SetActive(value:  false);
        return;
        label_84:
        string val_34 = WGDailyChallengeManagerHelper.GetLocEveningChallenge();
        label_85:
        label_83:
        UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene> val_36 = null;
        val_38 = val_36;
        val_36 = new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  MonoSingleton<WGDailyChallengeManager>.Instance, method:  public System.Void WGDailyChallengeManager::OnSceneChanged(UnityEngine.SceneManagement.Scene current, UnityEngine.SceneManagement.Scene next));
        UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  val_36);
        return;
        label_32:
        val_46 = null;
        val_46 = null;
        var val_37 = (App.game == 4) ? 1 : 0;
        if(null != 0)
        {
            goto label_98;
        }
    
    }
    private void CheckDailyChallengeValidity()
    {
        var val_9;
        System.Func<LineWord, System.Boolean> val_11;
        WordRegion val_1 = WordRegion.instance;
        val_9 = null;
        val_9 = null;
        val_11 = WGDailyChallengeMainController.<>c.<>9__14_0;
        if(val_11 == null)
        {
                System.Func<LineWord, System.Boolean> val_2 = null;
            val_11 = val_2;
            val_2 = new System.Func<LineWord, System.Boolean>(object:  WGDailyChallengeMainController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeMainController.<>c::<CheckDailyChallengeValidity>b__14_0(LineWord x));
            WGDailyChallengeMainController.<>c.<>9__14_0 = val_11;
        }
        
        System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<LineWord>(source:  System.Linq.Enumerable.Where<LineWord>(source:  41963520, predicate:  val_2));
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<LineWord>(System.Collections.Generic.IEnumerable<TSource> source)) != 0)
        {
                return;
        }
        
        DailyChallengeGameLevel val_6 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        if(val_6.points == 0)
        {
                return;
        }
        
        UnityEngine.Debug.LogWarning(message:  "Catching attempted exploit and shutting it down");
        DailyChallengeGameLevel val_8 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        val_8.points = 0;
        this.UpdateProgressBar(delay:  0f);
    }
    public void UpdateProgressBar(float delay = 0)
    {
        UnityEngine.Rect val_1 = this.progress_bar_image.rect;
        float val_4 = MonoSingleton<WGDailyChallengeManager>.Instance.GetProgressPercentage();
        if(val_4 > (MonoSingleton<WGDailyChallengeManager>.Instance.GetNextProgressTarget()))
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.HandleStarProgress();
        }
        
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  val_1.m_XMin.width * val_4, y:  -15f);
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> val_13 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Vector2>(object:  this, method:  UnityEngine.Vector2 WGDailyChallengeMainController::<UpdateProgressBar>b__15_0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Vector2>(object:  this, method:  System.Void WGDailyChallengeMainController::<UpdateProgressBar>b__15_1(UnityEngine.Vector2 x)), endValue:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y}, duration:  0.3f), delay:  delay);
        DailyChallengeGameLevel val_15 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        this.starGroup.Setup(stars:  val_15.stars);
    }
    public void SetLevelComplete()
    {
        mem[1152921517783656508] = 1;
    }
    public override void OnComplete()
    {
        35486.Invoke();
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnDailyChallengeComplete();
        }
        
        MonoSingleton<WordGameEventsController>.Instance.OnDailyChallengeLevelComplete();
        DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.75f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGDailyChallengeMainController::<OnComplete>b__17_0()), ignoreTimeScale:  true);
    }
    private void FailedLoadingLevelData()
    {
        int val_12;
        var val_13;
        System.Func<System.Boolean> val_15;
        var val_16;
        GameBehavior val_1 = App.getBehavior;
        WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_2.PlayingMorning = false;
        val_2.PlayingEvening = false;
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_12 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_8.Length;
        val_8[1] = "NULL";
        System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
        val_13 = null;
        val_13 = null;
        val_15 = WGDailyChallengeMainController.<>c.<>9__18_0;
        if(val_15 == null)
        {
                System.Func<System.Boolean> val_11 = null;
            val_15 = val_11;
            val_11 = new System.Func<System.Boolean>(object:  WGDailyChallengeMainController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeMainController.<>c::<FailedLoadingLevelData>b__18_0());
            WGDailyChallengeMainController.<>c.<>9__18_0 = val_15;
        }
        
        val_10[0] = val_15;
        val_16 = null;
        val_16 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "daily_challenge_unavailable", defaultValue:  "Sorry, Daily Challenge is not available. Please try again.", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public override void OnLevelClearClosed()
    {
        bool val_10 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentChallengeComplete();
        var val_3 = ((val_10 & true) != 0) ? (1 + 1) : 1;
        GameBehavior val_4 = App.getBehavior;
        if(val_10 != false)
        {
                val_10 = MonoSingleton<WGDailyChallengeManager>.Instance;
            val_5.PlayingMorning = false;
            val_5.PlayingEvening = false;
            WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
        }
        
        bool val_9 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
    }
    public void ShowMessage(string message)
    {
        if(this.gameplayMessage == 0)
        {
                return;
        }
        
        bool val_2 = this.gameplayMessage.ShowMessage(message:  message, showLetterNo:  false, letterCount:  0);
    }
    public WGDailyChallengeMainController()
    {
    
    }
    private UnityEngine.Vector2 <UpdateProgressBar>b__15_0()
    {
        if(this.progress_bar != null)
        {
                return this.progress_bar.sizeDelta;
        }
        
        throw new NullReferenceException();
    }
    private void <UpdateProgressBar>b__15_1(UnityEngine.Vector2 x)
    {
        if(this.progress_bar != null)
        {
                this.progress_bar.sizeDelta = new UnityEngine.Vector2() {x = x.x, y = x.y};
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <OnComplete>b__17_0()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.OnChallengeCompleted();
        this.progress_bar_group.SetActive(value:  false);
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
                return;
        }
        
        WGGenericNotificationsManager.CancelDailyChallengeNotification();
    }

}
