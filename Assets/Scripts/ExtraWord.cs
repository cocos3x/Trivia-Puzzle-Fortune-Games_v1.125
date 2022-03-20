using UnityEngine;
public class ExtraWord : MonoBehaviour
{
    // Fields
    private bool EXTAWORD_LENGTH_RESTRICT;
    public System.Collections.Generic.List<string> extraWordsFound;
    public UnityEngine.Transform beginPoint;
    public UnityEngine.Transform endPoint;
    public UnityEngine.GameObject lightEffect;
    public UnityEngine.GameObject lightOpenEffect;
    private int world;
    private int subWorld;
    private int level;
    private System.Collections.Generic.Queue<UnityEngine.UI.Text> flyTexts;
    public static ExtraWord instance;
    public UnityEngine.Animator extraWordAnimator;
    public UnityEngine.ParticleSystem extraWordParticles;
    public const string GAMETYPE_DAILY_CHALLENGE = "dailychallenge";
    public const string GAMETYPE_CATEGORY_LEVELS = "categorylevels";
    private ExtraWordGameplayIcon extraWordGameplayIcon;
    private WGGameplayMessage gameplayMessage;
    private UnityEngine.Transform flyToGoldenAppleBeginPoint;
    private UnityEngine.Transform flyToGoldenAppleEndPoint;
    private UnityEngine.GameObject flyToGoldenAppleParticleObject;
    private bool hasViewedWordList;
    public System.Action<int> OnExtraWordAdded;
    private GameLevel currentLevel;
    
    // Properties
    public static bool HasViewedWordList { get; set; }
    public static int ApplesFromExtra { get; }
    public static int ApplesFromExtraBonus { get; }
    
    // Methods
    public static bool get_HasViewedWordList()
    {
        var val_3;
        if(ExtraWord.GAMETYPE_CATEGORY_LEVELS != 0)
        {
                var val_2 = ((ExtraWord.GAMETYPE_CATEGORY_LEVELS + 152) != 0) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public static void set_HasViewedWordList(bool value)
    {
        if(ExtraWord.GAMETYPE_CATEGORY_LEVELS == 0)
        {
                return;
        }
        
        ExtraWord.GAMETYPE_CATEGORY_LEVELS.__unknownFiledOffset_98 = value;
    }
    public static int get_ApplesFromExtra()
    {
        var val_2;
        if((ExtraWord.GAMETYPE_CATEGORY_LEVELS != 0) && ((ExtraWord.GAMETYPE_CATEGORY_LEVELS + 168) != 0))
        {
                val_2 = mem[ExtraWord.GAMETYPE_CATEGORY_LEVELS + 168 + 44];
            val_2 = ExtraWord.GAMETYPE_CATEGORY_LEVELS + 168 + 44;
            return (int)val_2;
        }
        
        val_2 = 0;
        return (int)val_2;
    }
    public static int get_ApplesFromExtraBonus()
    {
        var val_2;
        if((ExtraWord.GAMETYPE_CATEGORY_LEVELS != 0) && ((ExtraWord.GAMETYPE_CATEGORY_LEVELS + 168) != 0))
        {
                val_2 = mem[ExtraWord.GAMETYPE_CATEGORY_LEVELS + 168 + 48];
            val_2 = ExtraWord.GAMETYPE_CATEGORY_LEVELS + 168 + 48;
            return (int)val_2;
        }
        
        val_2 = 0;
        return (int)val_2;
    }
    private void Awake()
    {
        ExtraWord.GAMETYPE_CATEGORY_LEVELS = this;
    }
    private void Start()
    {
        string val_16;
        this.world = Prefs.currentWorld;
        this.subWorld = Prefs.currentChapter;
        this.level = Prefs.currentLevel;
        ExtraWord.HasViewedWordList = false;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_4;
        }
        
        val_16 = "dailychallenge";
        goto label_5;
        label_4:
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_8;
        }
        
        val_16 = "categorylevels";
        label_5:
        System.String[] val_7 = Prefs.GetExtraWordsEvents(gameType:  val_16);
        goto label_9;
        label_8:
        label_9:
        this.extraWordsFound = System.Linq.Enumerable.ToList<System.String>(source:  Prefs.GetExtraWords(world:  this.world, subWorld:  this.subWorld, level:  this.level));
        WordRegion.instance.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void ExtraWord::OnLevelLoaded(GameLevel gamelevel)));
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_14 = MainController.instance;
            val_14.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ExtraWord::OnLevelComplete()));
        }
        
        this.UpdateUI();
    }
    private void OnLevelLoaded(GameLevel gamelevel)
    {
        this.currentLevel = gamelevel;
        gamelevel.goldenApplesExtraWords = this.extraWordsFound;
    }
    private void OnLevelComplete()
    {
        if(this.lightOpenEffect != 0)
        {
                this.lightOpenEffect.SetActive(value:  false);
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                this.AwardGoldenApples();
        }
        
        if(CategoryPacksManager.IsPlaying == false)
        {
                return;
        }
        
        ExtraWord.ClearEventExtraWordProgress(gameTypeId:  "categorylevels");
    }
    private void UpdateUI()
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        if(Prefs.extraProgress >= Prefs.extraTarget)
        {
            goto label_6;
        }
        
        val_6 = 0;
        if(this.lightOpenEffect != null)
        {
            goto label_7;
        }
        
        label_6:
        label_7:
        this.lightOpenEffect.SetActive(value:  (Prefs.extraTarget > 0) ? 1 : 0);
    }
    public bool ProcessWord(string word, System.Collections.Generic.List<LineWord> lines, bool isWord)
    {
        var val_6;
        int val_7;
        var val_36;
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> val_37;
        System.Collections.Generic.List<System.String> val_38;
        var val_39;
        WGGameplayMessage val_40;
        string val_41;
        string val_42;
        val_37 = isWord;
        val_38 = this.extraWordsFound;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_38.Contains(item:  word)) == false)
        {
            goto label_2;
        }
        
        if((MonoSingleton<WGAudioController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_2.sound;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38.PlayGeneralSound(type:  8, oneshot:  true, pitch:  1f, vol:  1f);
        if(this.gameplayMessage == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.gameplayMessage.<isMessageShowing>k__BackingField) == true)
        {
            goto label_61;
        }
        
        label_65:
        bool val_4 = this.gameplayMessage.ShowMessage(message:  Localization.Localize(key:  "already_found_extra_word", defaultValue:  "You already found this extra word!", useSingularKey:  false), showLetterNo:  false, letterCount:  0);
        goto label_61;
        label_2:
        if(word == null)
        {
                throw new NullReferenceException();
        }
        
        if(word.m_stringLength < 3)
        {
            goto label_61;
        }
        
        if((this.EXTAWORD_LENGTH_RESTRICT == false) || (val_37 == false))
        {
            goto label_13;
        }
        
        if(lines == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = lines.GetEnumerator();
        label_18:
        if(val_7.MoveNext() == false)
        {
            goto label_15;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_6 + 24) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(word.m_stringLength != (val_6 + 24 + 16))
        {
            goto label_18;
        }
        
        val_36 = 1152921515429108528;
        val_7.Dispose();
        List.Enumerator<T> val_9 = lines.GetEnumerator();
        label_23:
        if(val_7.MoveNext() == false)
        {
            goto label_19;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((val_6 + 24 + 16) != word.m_stringLength) || ((val_6 + 56) != 0))
        {
            goto label_23;
        }
        
        val_7.Dispose();
        label_13:
        if(val_37 == false)
        {
            goto label_61;
        }
        
        val_38 = this.beginPoint;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_11 = val_38.position;
        val_38 = this.endPoint;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_12 = val_38.position;
        UnityEngine.Vector3 val_13 = CUtils.GetMiddlePoint(begin:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, end:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, delta:  0.4f);
        UnityEngine.Vector3[] val_14 = new UnityEngine.Vector3[3];
        if(this.beginPoint == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = this.beginPoint;
        UnityEngine.Vector3 val_15 = val_38.position;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14[0] = val_15;
        val_14[0] = val_15.y;
        val_14[1] = val_15.z;
        val_14[1] = val_13;
        val_14[2] = val_13.y;
        val_14[2] = val_13.z;
        val_38 = this.endPoint;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_16 = val_38.position;
        val_14[3] = val_16;
        val_14[3] = val_16.y;
        val_14[4] = val_16.z;
        if(MonoUtils.instance == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.UI.Text val_17 = UnityEngine.Object.Instantiate<UnityEngine.UI.Text>(original:  MonoUtils.instance.letter);
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.beginPoint == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_17.transform;
        val_38 = this.beginPoint;
        UnityEngine.Vector3 val_19 = val_38.position;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        UnityEngine.Transform val_20 = val_17.transform;
        if(MonoUtils.instance == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20.SetParent(p:  MonoUtils.instance.textFlyTransform);
        if(TextPreview.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_17.transform;
        val_38 = mem[TextPreview.instance + 64];
        val_38 = TextPreview.instance.text;
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_22 = transform;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_23 = val_22.localScale;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36.localScale = new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z};
        val_38 = this.flyTexts;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38.Enqueue(item:  val_17);
        UnityEngine.GameObject val_24 = val_17.gameObject;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = DG.Tweening.ShortcutExtensions.DOPath(target:  val_24.transform, path:  val_14, duration:  0.3f, pathType:  0, pathMode:  1, resolution:  10, gizmoColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true});
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> val_28 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>(t:  val_37, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ExtraWord::OnTextMoveToComplete()));
        this.AddNewExtraWord(word:  word);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                WGChallengeController val_31 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
            if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
            val_31.OnExtraWordFound();
        }
        
        if((MonoSingleton<WGAudioController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_32.sound;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        val_39 = 1;
        val_38.PlayGeneralSound(type:  7, oneshot:  true, pitch:  1f, vol:  1f);
        return (bool)val_39;
        label_15:
        val_7.Dispose();
        val_40 = this.gameplayMessage;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.gameplayMessage.<isMessageShowing>k__BackingField) == true)
        {
            goto label_61;
        }
        
        val_41 = "extra_word_flyout_no_req";
        val_42 = "There are no {0}-letter required words!";
        goto label_62;
        label_19:
        val_7.Dispose();
        val_40 = this.gameplayMessage;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.gameplayMessage.<isMessageShowing>k__BackingField) == false)
        {
            goto label_64;
        }
        
        label_61:
        val_39 = 0;
        return (bool)val_39;
        label_64:
        val_41 = "extra_word_flyout_found_all";
        val_42 = "All {0}-letter words already found!";
        label_62:
        val_7 = word.m_stringLength;
        string val_34 = System.String.Format(format:  Localization.Localize(key:  val_41, defaultValue:  val_42, useSingularKey:  false), arg0:  val_7);
        goto label_65;
    }
    public void CheckRequiredExtraWord(string word)
    {
        if((App.Player - (UnityEngine.PlayerPrefs.GetInt(key:  "LastExtraWordDisplay", defaultValue:  0))) < 20)
        {
                return;
        }
        
        if(App.Player > 199)
        {
                return;
        }
        
        this.DisplayDefinitionFlyout();
        UnityEngine.PlayerPrefs.SetInt(key:  "LastExtraWordDisplay", value:  App.Player);
    }
    public void DisplayDefinitionFlyout()
    {
        bool val_2 = this.gameplayMessage.ShowMessage(message:  Localization.Localize(key:  "tap_any_word_definition", defaultValue:  "Tap any word to view\nits definition!", useSingularKey:  false), showLetterNo:  false, letterCount:  0);
    }
    public void AddNewExtraWord(string word)
    {
        int val_10;
        string val_11;
        string val_13;
        val_11 = word;
        this.extraWordsFound.Add(item:  val_11);
        if(this.currentLevel != null)
        {
                this.currentLevel.goldenApplesExtraWords = this.extraWordsFound;
            val_11 = this.currentLevel;
            this.currentLevel.goldenApplesExtraWordsSubBonus = WGSubscriptionManager.GetAdditionalPoints(basePoints:  this.extraWordsFound);
        }
        else
        {
                UnityEngine.Debug.LogError(message:  "ExtraWord: currentLevel is null somehow", context:  this);
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_12;
        }
        
        T[] val_4 = this.extraWordsFound.ToArray();
        val_13 = "dailychallenge";
        goto label_14;
        label_12:
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_17;
        }
        
        val_13 = "categorylevels";
        label_14:
        Prefs.SetExtraWordsEvents(gameType:  val_13, extraWords:  this.extraWordsFound.ToArray());
        goto label_19;
        label_17:
        val_10 = this.world;
        Prefs.SetExtraWords(world:  val_10, subWorld:  this.subWorld, level:  this.level, extraWords:  this.extraWordsFound.ToArray());
        label_19:
        int val_8 = Prefs.extraProgress;
        val_8 = val_8 + 1;
        Prefs.extraProgress = val_8;
        int val_9 = Prefs.totalExtraAdded;
        val_9 = val_9 + 1;
        Prefs.totalExtraAdded = val_9;
        if(this.OnExtraWordAdded == null)
        {
                return;
        }
        
        this.OnExtraWordAdded.Invoke(obj:  0);
    }
    public static void ClearEventExtraWordProgress(string gameTypeId)
    {
        if((System.String.IsNullOrEmpty(value:  gameTypeId)) != false)
        {
                return;
        }
        
        Prefs.SetExtraWordsEvents(gameType:  gameTypeId, extraWords:  new string[0]);
    }
    private void AwardGoldenApples()
    {
        var val_14;
        var val_15;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        val_15 = null;
        val_15 = null;
        if(App.game == 18)
        {
                return;
        }
        
        if(this.extraWordsFound >= 1)
        {
                Player val_3 = App.Player;
            System.Collections.Generic.List<System.String> val_14 = this.extraWordsFound;
            val_14 = val_14 + val_3.properties.LifetimeApplesEarnedFromExtraWords;
            val_3.properties.LifetimeApplesEarnedFromExtraWords = val_14;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_4.Add(key:  "Base Reward", value:  ExtraWord.ApplesFromExtra);
            val_14 = ExtraWord.ApplesFromExtra;
            if(GoldenMultiplierManager.IsAvaialable != true)
        {
                if(ExtraWord.ApplesFromExtraBonus >= 1)
        {
                val_4.Add(key:  "Golden Ticket Bonus", value:  ExtraWord.ApplesFromExtraBonus);
            val_14 = ExtraWord.ApplesFromExtraBonus + val_14;
        }
        
        }
        
            GoldenApplesManager val_11 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        if(GoldenMultiplierManager.IsAvaialable == true)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnStarsUpdated");
    }
    private void OnTextMoveToComplete()
    {
        this.UpdateUI();
        if(this.lightOpenEffect != 0)
        {
                if(this.lightOpenEffect.activeSelf != true)
        {
                this.lightEffect.SetActive(value:  true);
            UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -60f);
            DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  this.lightEffect.transform, endValue:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, duration:  0.4f, mode:  0), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ExtraWord::OnLightRotateComplete()));
        }
        
        }
        
        if(this.extraWordAnimator != 0)
        {
                this.extraWordAnimator.SetTrigger(name:  "Word Added");
        }
        
        if(this.extraWordParticles != 0)
        {
                this.extraWordParticles.Play();
        }
        
        UnityEngine.UI.Text val_11 = this.flyTexts.Dequeue();
        .flyText = val_11;
        DG.Tweening.Tweener val_14 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  val_11, endValue:  0f, duration:  0.3f), action:  new DG.Tweening.TweenCallback(object:  new ExtraWord.<>c__DisplayClass41_0(), method:  System.Void ExtraWord.<>c__DisplayClass41_0::<OnTextMoveToComplete>b__0()));
    }
    private void OnLightRotateComplete()
    {
        if(this.lightEffect != null)
        {
                this.lightEffect.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void OnClaimed()
    {
        this.UpdateUI();
    }
    public ExtraWord()
    {
        GameBehavior val_1 = App.getBehavior;
        this.EXTAWORD_LENGTH_RESTRICT = (val_1.<metaGameBehavior>k__BackingField) & 1;
        this.extraWordsFound = new System.Collections.Generic.List<System.String>();
        this.flyTexts = new System.Collections.Generic.Queue<UnityEngine.UI.Text>();
    }

}
