using UnityEngine;
public class WGDailyChallengeWordRegion : WordRegion
{
    // Fields
    private UnityEngine.GameObject _sunPrefab;
    private UnityEngine.GameObject _moonPrefab;
    private UnityEngine.GameObject _sunParticlePrefab;
    private UnityEngine.GameObject _moonParticlePrefab;
    private UnityEngine.Transform sunMoonParticleParent;
    private WGDailyChallengeParticles sunMoonParticles;
    protected DailyChallengeDefinition dailyChallengeDefinition;
    protected System.Collections.Generic.List<string> currentLevelProgress;
    private System.Collections.Generic.Dictionary<string, string> SavedLevelProgress;
    public static System.Collections.Generic.List<UnityEngine.Transform> particleDestinations;
    private UnityEngine.UI.VerticalLayoutGroup verticalGroup;
    private UnityEngine.Vector2 regionSize;
    private float spacing;
    private int longestAnswer;
    private bool complete;
    private const float anim_delay = 0.1;
    private UnityEngine.GameObject pointer;
    private LineWord currentWord;
    private bool granting_hint;
    
    // Properties
    private UnityEngine.GameObject sunPrefab { get; }
    private UnityEngine.GameObject moonPrefab { get; }
    private UnityEngine.GameObject sunParticlePrefab { get; }
    private UnityEngine.GameObject moonParticlePrefab { get; }
    private UnityEngine.UI.VerticalLayoutGroup VerticalGroup { get; }
    public LineWord GetCurrentSunMoonWord { get; }
    private DailyChallengeGameLevel currentLevel { get; }
    
    // Methods
    private UnityEngine.GameObject get_sunPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._sunPrefab == 0)
        {
                this._sunPrefab = PrefabLoader.LoadPrefab(featureName:  "DailyChallengeGameplay", prefabName:  "Sun");
            return val_3;
        }
        
        val_3 = this._sunPrefab;
        return val_3;
    }
    private UnityEngine.GameObject get_moonPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._moonPrefab == 0)
        {
                this._moonPrefab = PrefabLoader.LoadPrefab(featureName:  "DailyChallengeGameplay", prefabName:  "Moon");
            return val_3;
        }
        
        val_3 = this._moonPrefab;
        return val_3;
    }
    private UnityEngine.GameObject get_sunParticlePrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._sunParticlePrefab == 0)
        {
                this._sunParticlePrefab = PrefabLoader.LoadPrefab(featureName:  "DailyChallengeGameplay", prefabName:  "DailyChallengeSunParticles");
            return val_3;
        }
        
        val_3 = this._sunParticlePrefab;
        return val_3;
    }
    private UnityEngine.GameObject get_moonParticlePrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._moonParticlePrefab == 0)
        {
                this._moonParticlePrefab = PrefabLoader.LoadPrefab(featureName:  "DailyChallengeGameplay", prefabName:  "DailyChallengeMoonParticles");
            return val_3;
        }
        
        val_3 = this._moonParticlePrefab;
        return val_3;
    }
    private UnityEngine.UI.VerticalLayoutGroup get_VerticalGroup()
    {
        UnityEngine.UI.VerticalLayoutGroup val_3;
        if(0 == this.verticalGroup)
        {
                this.verticalGroup = this.GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
            return val_3;
        }
        
        val_3 = this.verticalGroup;
        return val_3;
    }
    public LineWord get_GetCurrentSunMoonWord()
    {
        return (LineWord)this.currentWord;
    }
    private DailyChallengeGameLevel get_currentLevel()
    {
        return MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
    }
    private void OnEnable()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
                return;
        }
        
        if(this.sunMoonParticles == 0)
        {
                WGDailyChallengeManager val_6 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_6.PlayingMorning != false)
        {
                UnityEngine.GameObject val_7 = this.sunParticlePrefab;
        }
        
            1152921504765632512 = this.sunMoonParticleParent;
            this.sunMoonParticles = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.moonParticlePrefab, parent:  1152921504765632512).GetComponent<WGDailyChallengeParticles>();
        }
        
        WGDailyChallengeManager val_11 = MonoSingleton<WGDailyChallengeManager>.Instance;
        this.dailyChallengeDefinition = val_11.<Econ>k__BackingField.ChallengeDefinition;
    }
    private void ResetPointer(bool hintUsed)
    {
        LineWord val_60;
        int val_61;
        RandomSet val_1 = new RandomSet();
        var val_61 = 0;
        label_7:
        if(val_61 >= (X23 + 24))
        {
            goto label_2;
        }
        
        if((X23 + 24) <= val_61)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_60 = X23 + 16;
        val_60 = val_60 + 0;
        if(((X23 + 16 + 0) + 32 + 56) == 0)
        {
                val_1.add(item:  0, weight:  1f);
        }
        
        val_61 = val_61 + 1;
        if(X23 != 0)
        {
            goto label_7;
        }
        
        label_2:
        if((val_1.count() == 0) && (hintUsed != false))
        {
                this.PlaySunMoonParticles();
            UnityEngine.Object.DestroyImmediate(obj:  this.pointer);
            return;
        }
        
        if(this.pointer == 0)
        {
            goto label_27;
        }
        
        if(val_1.count() == 0)
        {
            goto label_17;
        }
        
        if(val_1.count() != 1)
        {
            goto label_27;
        }
        
        bool val_6 = UnityEngine.Object.op_Inequality(x:  this.currentWord, y:  0);
        if((val_6 == false) || (this.currentWord.isShown == true))
        {
            goto label_27;
        }
        
        DailyChallengeGameLevel val_7 = val_6.currentLevel;
        int val_62 = this.currentWord.answer.m_stringLength;
        val_62 = val_62 - 1;
        if(val_7.pointerLetterIndex != val_62)
        {
            goto label_27;
        }
        
        label_17:
        this.PlaySunMoonParticles();
        UnityEngine.Object.DestroyImmediate(obj:  this.pointer);
        DailyChallengeGameLevel val_8 = this.pointer.currentLevel;
        val_8.pointerGone = (val_1.count() == 1) ? 1 : 0;
        return;
        label_27:
        bool val_11 = UnityEngine.Object.op_Inequality(x:  this.currentWord, y:  0);
        if(val_11 != false)
        {
                if(this.currentWord.isShown == false)
        {
            goto label_35;
        }
        
        }
        
        val_12.pointerWordIndex = val_11.currentLevel.GetPointerWordIndex(randomSet:  val_1);
        UnityEngine.Transform val_14 = this.transform;
        DailyChallengeGameLevel val_15 = val_14.currentLevel;
        this.currentWord = val_14.GetChild(index:  val_15.pointerWordIndex).GetComponent<LineWord>();
        DailyChallengeGameLevel val_19 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        val_19.currentSunMoonWord = this.currentWord.answer;
        int val_64 = 0;
        label_52:
        int val_63 = this.currentWord.answer.m_stringLength;
        if(val_64 >= val_63)
        {
            goto label_47;
        }
        
        if(val_63 <= val_64)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_63 = val_63 + 0;
        if(((this.currentWord.answer.m_stringLength + 0) + 32 + 72) == 0)
        {
            goto label_51;
        }
        
        val_64 = val_64 + 1;
        if(this.currentWord != null)
        {
            goto label_52;
        }
        
        label_51:
        DailyChallengeGameLevel val_20 = this.currentLevel;
        val_20.pointerLetterIndex = val_64;
        label_47:
        UnityEngine.Transform val_21 = this.currentWord.transform;
        DailyChallengeGameLevel val_22 = val_21.currentLevel;
        UnityEngine.Transform val_23 = val_21.GetChild(index:  val_22.pointerLetterIndex);
        this.PlaySunMoonParticles();
        label_130:
        if(this.pointer == 0)
        {
                this.CreatePointer(parent:  val_23);
        }
        
        this.pointer.transform.parent = val_23;
        UnityEngine.Vector3 val_27 = UnityEngine.Vector3.zero;
        this.pointer.transform.localPosition = new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z};
        return;
        label_35:
        if(hintUsed != false)
        {
                if(this.pointer != 0)
        {
                Cell val_31 = this.pointer.transform.parent.GetComponent<Cell>();
            if(val_31.isShown == false)
        {
                return;
        }
        
        }
        
        }
        
        int val_34 = this.pointer.transform.parent.GetSiblingIndex();
        if(val_34 >= (this.currentWord.answer.m_stringLength - 1))
        {
            goto label_95;
        }
        
        int val_39 = this.pointer.transform.parent.GetSiblingIndex();
        int val_65 = val_39;
        label_92:
        LineWord val_66 = this.currentWord;
        val_65 = val_65 + 1;
        if(val_65 >= this.currentWord.answer.m_stringLength)
        {
            goto label_88;
        }
        
        if(val_66 <= val_65)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_66 = val_66 + (val_65 << 3);
        if(((this.currentWord + ((val_39 + 1)) << 3).cellSize + 72) != 0)
        {
            goto label_92;
        }
        
        DailyChallengeGameLevel val_40 = this.currentLevel;
        val_40.pointerLetterIndex = val_65;
        UnityEngine.Transform val_41 = (this.currentWord + ((val_39 + 1)) << 3).cellSize.transform;
        goto label_94;
        label_98:
        int val_43 = val_34.currentLevel.currentLevel.GetPointerWordIndex(randomSet:  val_1);
        val_42.pointerWordIndex = val_43;
        label_95:
        DailyChallengeGameLevel val_44 = val_43.currentLevel;
        if(val_44.pointerWordIndex == val_35.pointerWordIndex)
        {
            goto label_98;
        }
        
        UnityEngine.Transform val_45 = this.transform;
        DailyChallengeGameLevel val_46 = val_45.currentLevel;
        this.currentWord = val_45.GetChild(index:  val_46.pointerWordIndex).GetComponent<LineWord>();
        val_61 = 0;
        label_109:
        int val_67 = val_48.answer.m_stringLength;
        if(val_61 >= val_67)
        {
            goto label_119;
        }
        
        if(val_67 <= val_61)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_67 = val_67 + 0;
        if(((val_48.answer.m_stringLength + 0) + 32 + 72) == 0)
        {
            goto label_123;
        }
        
        val_61 = val_61 + 1;
        if(this.currentWord != null)
        {
            goto label_109;
        }
        
        label_88:
        label_94:
        if(val_35.pointerLetterIndex != val_49.pointerLetterIndex)
        {
            goto label_130;
        }
        
        val_50.pointerWordIndex = val_39.currentLevel.currentLevel.GetPointerWordIndex(randomSet:  val_1);
        UnityEngine.Transform val_52 = this.transform;
        DailyChallengeGameLevel val_53 = val_52.currentLevel;
        this.currentWord = val_52.GetChild(index:  val_53.pointerWordIndex).GetComponent<LineWord>();
        val_61 = 0;
        label_124:
        int val_68 = val_55.answer.m_stringLength;
        if(val_61 >= val_68)
        {
            goto label_119;
        }
        
        if(val_68 <= val_61)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_68 = val_68 + 0;
        if(((val_55.answer.m_stringLength + 0) + 32 + 72) == 0)
        {
            goto label_123;
        }
        
        val_61 = val_61 + 1;
        if(this.currentWord != null)
        {
            goto label_124;
        }
        
        label_123:
        DailyChallengeGameLevel val_56 = this.currentLevel;
        val_56.pointerLetterIndex = val_61;
        val_60 = this.currentWord;
        label_119:
        UnityEngine.Transform val_57 = val_60.transform;
        DailyChallengeGameLevel val_58 = val_57.currentLevel;
        UnityEngine.Transform val_59 = val_57.GetChild(index:  val_58.pointerLetterIndex);
        goto label_130;
    }
    private int GetPointerWordIndex(RandomSet randomSet)
    {
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) == 0)
        {
                return randomSet.roll(unweighted:  false);
        }
        
        DailyChallengeTutorialManager val_3 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        if(val_3._GameplayTutorialActive == false)
        {
                return randomSet.roll(unweighted:  false);
        }
        
        int val_5 = MonoSingleton<DailyChallengeTutorialManager>.Instance.GetSunMoonWordIndex();
        if(val_5 == 1)
        {
                return randomSet.roll(unweighted:  false);
        }
        
        return val_5;
    }
    private void CreatePointer(UnityEngine.Transform parent)
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_1.PlayingMorning != false)
        {
                UnityEngine.GameObject val_2 = this.sunPrefab;
        }
        
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.moonPrefab, parent:  parent);
        this.pointer = val_4;
        UnityEngine.Vector2 val_7 = parent.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        val_4.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        this.pointer.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
    }
    private void LoadPointer(int wordIndex, int letterIndex)
    {
        if(mem[41963544] <= wordIndex)
        {
            goto label_2;
        }
        
        if(mem[41963544] <= wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_2 = mem[41963536];
        val_2 = val_2 + (wordIndex << 3);
        if(((mem[41963536] + (wordIndex) << 3) + 32 + 40 + 24) <= letterIndex)
        {
            goto label_6;
        }
        
        if((X23 + 24) <= wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_3 = X23 + 16;
        val_3 = val_3 + (((long)(int)(wordIndex)) << 3);
        if(((X23 + 16 + ((long)(int)(wordIndex)) << 3) + 32 + 40 + 24) <= letterIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_4 = (X23 + 16 + ((long)(int)(wordIndex)) << 3) + 32 + 40 + 16;
        val_4 = val_4 + (letterIndex << 3);
        this.CreatePointer(parent:  ((X23 + 16 + ((long)(int)(wordIndex)) << 3) + 32 + 40 + 16 + (letterIndex) << 3) + 32.transform);
        if((letterIndex + 24) <= wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = letterIndex + 16;
        val_5 = val_5 + (((long)(int)(wordIndex)) << 3);
        this.currentWord = (letterIndex + 16 + ((long)(int)(wordIndex)) << 3) + 32;
        return;
        label_2:
        UnityEngine.Debug.LogWarning(message:  "trying to get a child that is out of bounds, not loading the DC pointer");
        return;
        label_6:
        UnityEngine.Debug.LogError(message:  "trying to get a grandchild that is out of bounds, not loading the DC pointer");
    }
    private void PlaySunMoonParticles()
    {
        UnityEngine.Transform val_14;
        var val_15;
        val_14 = this;
        val_15 = 1152921504765632512;
        if(this.sunMoonParticles == 0)
        {
                return;
        }
        
        if(this.pointer == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_5 = this.pointer.transform.position;
        this.sunMoonParticles.transform.position = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        val_15 = 1152921504988155904;
        DailyChallengeGameLevel val_7 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        int val_9 = UnityEngine.Mathf.Min(a:  (WGDailyChallengeWordRegion.anim_delay + 24) - 1, b:  val_7.progressDefinitionsIndex);
        if((WGDailyChallengeWordRegion.anim_delay + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_14 = WGDailyChallengeWordRegion.anim_delay + 16;
        val_14 = val_14 + (val_9 << 3);
        UnityEngine.Vector3 val_10 = (WGDailyChallengeWordRegion.anim_delay + 16 + (val_9) << 3) + 32.position;
        this.sunMoonParticles.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
        if((WGDailyChallengeWordRegion.anim_delay + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_15 = WGDailyChallengeWordRegion.anim_delay + 16;
        UnityEngine.Vector3 val_11;
        val_15 = val_15 + (((long)(int)(val_9)) << 3);
        val_14 = mem[(WGDailyChallengeWordRegion.anim_delay + 16 + ((long)(int)(val_9)) << 3) + 32];
        val_14 = (WGDailyChallengeWordRegion.anim_delay + 16 + ((long)(int)(val_9)) << 3) + 32;
        val_11 = new UnityEngine.Vector3(x:  0.15f, y:  0.15f, z:  0f);
        DG.Tweening.Tweener val_13 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  val_14, punch:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, duration:  0.35f, vibrato:  0, elasticity:  0f), delay:  0.8f);
    }
    private float CalculateCellSizeForLines()
    {
        var val_2;
        var val_3;
        var val_16;
        var val_17;
        List.Enumerator<T> val_1 = 35596.GetEnumerator();
        var val_16 = val_2;
        val_16 = 0;
        goto label_2;
        label_5:
        val_17 = val_16;
        if(val_17 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_4 = val_17.gameObject;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16 = val_4.activeSelf;
        val_16 = val_16 + val_16;
        label_2:
        if(val_3.MoveNext() == true)
        {
            goto label_5;
        }
        
        val_3.Dispose();
        UnityEngine.Rect val_8 = this.transform.rect;
        UnityEngine.Vector2 val_9 = val_8.m_XMin.size;
        this.regionSize = val_9;
        mem[1152921517815700508] = val_9.y;
        var val_10 = (val_16 > true) ? (val_16) : (0 + 1);
        UnityEngine.UI.VerticalLayoutGroup val_11 = this.VerticalGroup;
        this.spacing = ;
        UnityEngine.Vector2 val_17 = this.regionSize;
        GameBehavior val_12 = App.getBehavior;
        val_9.x = val_9.x * ((float)this.longestAnswer - 1);
        val_9.x = val_9.x + (float)this.longestAnswer;
        val_17 = val_17 / val_9.x;
        float val_18 = (float)val_10 - 1;
        val_18 = S9 * val_18;
        val_18 = S10 - val_18;
        val_18 = val_18 / (float)val_10;
        return (float)System.Math.Min(val1:  val_18, val2:  val_17);
    }
    private System.Collections.IEnumerator CalculateCellSizeNextFrame()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeWordRegion.<CalculateCellSizeNextFrame>d__39();
    }
    public override void UpdateOverlayUI(LineWord word, bool hintUsed)
    {
        UnityEngine.Object val_34;
        var val_35;
        System.Predicate<Cell> val_37;
        val_34 = word;
        DailyChallengeGameLevel val_1 = this.currentLevel;
        if(val_1.pointerGone != false)
        {
                return;
        }
        
        if(val_34 == 0)
        {
                if(val_4.hasStartedPreviously != false)
        {
                DailyChallengeGameLevel val_6 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel.currentLevel.currentLevel;
            this.LoadPointer(wordIndex:  val_5.pointerWordIndex, letterIndex:  val_6.pointerLetterIndex);
            return;
        }
        
        }
        
        if((val_34 != 0) && (this.pointer != 0))
        {
                LineWord val_12 = this.pointer.transform.parent.parent.GetComponent<LineWord>();
            if(word.isShown != false)
        {
                if((System.String.op_Equality(a:  word.answer, b:  val_12.answer)) != false)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.OnPointsGained(word:  word.answer);
        }
        else
        {
                val_35 = null;
            val_35 = null;
            val_37 = WGDailyChallengeWordRegion.<>c.<>9__40_0;
            if(val_37 == null)
        {
                System.Predicate<Cell> val_17 = null;
            val_37 = val_17;
            val_17 = new System.Predicate<Cell>(object:  WGDailyChallengeWordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeWordRegion.<>c::<UpdateOverlayUI>b__40_0(Cell x));
            WGDailyChallengeWordRegion.<>c.<>9__40_0 = val_37;
        }
        
            System.Collections.Generic.List<T> val_18 = System.Linq.Enumerable.ToList<Cell>(source:  val_12.GetComponentsInChildren<Cell>()).FindAll(match:  val_17);
            val_34 = this.pointer.transform.parent.GetSiblingIndex();
            if(val_37 != 1)
        {
                if(val_34 != (val_12.transform.childCount - 1))
        {
            goto label_47;
        }
        
        }
        
            val_34 = 1152921504893161472;
            WGDailyChallengeManager val_25 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_25.OnMissedPoint != null)
        {
                WGDailyChallengeManager val_26 = MonoSingleton<WGDailyChallengeManager>.Instance;
            val_26.OnMissedPoint.Invoke();
        }
        
        }
        
        }
        
        }
        
        label_47:
        this.ResetPointer(hintUsed:  hintUsed);
        if((MonoSingleton<WGDailyChallengeManager>.Instance.IsPlayingPersistentLevel()) == false)
        {
                return;
        }
        
        DailyChallengeGameLevel val_31 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        val_31.hasStartedPreviously = true;
        DailyChallengeGameLevel val_33 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
    }
    public override void UpdateProgressBar()
    {
        WGDailyChallengeMainController.SpecificInstance.UpdateProgressBar(delay:  0.8f);
    }
    public override void Load(GameLevel gameLevel, System.Action loadCompleteCallback)
    {
        this.Load(gameLevel:  gameLevel, loadCompleteCallback:  loadCompleteCallback);
    }
    private System.Collections.Generic.Dictionary<string, string> LoadLevelProgress()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.String>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "challenge_lvl_prog", defaultValue:  "{}"));
    }
    private void ClearLevelProgress()
    {
        UnityEngine.PlayerPrefs.DeleteKey(key:  "challenge_lvl_prog");
    }
    public override void SaveLevelProgress()
    {
        var val_6;
        var val_7;
        var val_17;
        var val_19;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.IsPlayingPersistentLevel()) == false)
        {
                return;
        }
        
        if((PlayingLevel.GetLevel(currentMode:  2, parameters:  0)) == null)
        {
                return;
        }
        
        System.Collections.Generic.List<System.String> val_4 = new System.Collections.Generic.List<System.String>();
        val_4.Add(item:  public System.Int32 System.IO.Stream::EndRead(System.IAsyncResult asyncResult));
        List.Enumerator<T> val_5 = val_4.GetEnumerator();
        val_17 = 1152921515446279280;
        var val_17 = 0;
        label_21:
        if(val_7.MoveNext() == false)
        {
            goto label_11;
        }
        
        val_19 = val_6;
        System.Text.StringBuilder val_9 = new System.Text.StringBuilder();
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_6 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_10 = val_6 + 40.GetEnumerator();
        label_17:
        if(val_7.MoveNext() == false)
        {
            goto label_14;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_13 = val_9.Append(value:  ((val_6 + 72) == 0) ? "0" : "1");
        goto label_17;
        label_14:
        val_17 = val_17 + 1;
        val_19 = 0;
        mem2[0] = 151;
        val_7.Dispose();
        if(val_19 != 0)
        {
                throw val_19;
        }
        
        if(val_17 != 1)
        {
                var val_14 = ((1152921517816894896 + ((0 + 1)) << 2) == 151) ? 1 : 0;
            val_14 = ((val_17 >= 0) ? 1 : 0) & val_14;
            val_17 = val_17 - val_14;
        }
        
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_4.Add(item:  val_9);
        goto label_21;
        label_11:
        var val_16 = val_17 + 1;
        mem2[0] = 188;
        val_7.Dispose();
        mem2[0] = val_4;
        PlayingLevel.Save();
    }
    private string SerializeAnswer(string answer, int revealed)
    {
        string val_4;
        System.Text.StringBuilder val_1 = null;
        val_4 = 0;
        val_1 = new System.Text.StringBuilder();
        if(answer.m_stringLength >= 1)
        {
                var val_4 = 0;
            do
        {
            val_4 = mem[0 < revealed ? "1" : "0"];
            val_4 = (val_4 < revealed) ? "1" : "0";
            System.Text.StringBuilder val_3 = val_1.Append(value:  val_4);
            val_4 = val_4 + 1;
        }
        while(val_4 < answer.m_stringLength);
        
        }
    
    }
    private string SerializeAnswer(LineWord alreadyHintedLine)
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        List.Enumerator<T> val_2 = alreadyHintedLine.cells.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_5 = val_1.Append(value:  (0 == 0) ? "0" : "1");
        goto label_6;
        label_3:
        0.Dispose();
        return (string)val_1;
    }
    private void GrantHint(LineWord line)
    {
        .line = line;
        .<>4__this = this;
        if(this.complete == true)
        {
                return;
        }
        
        if(this.granting_hint != false)
        {
                return;
        }
        
        this.granting_hint = true;
        if(((WGDailyChallengeWordRegion.<>c__DisplayClass49_0)[1152921517817407200].line.gameObject.activeSelf) != true)
        {
                (WGDailyChallengeWordRegion.<>c__DisplayClass49_0)[1152921517817407200].line.gameObject.SetActive(value:  true);
            (WGDailyChallengeWordRegion.<>c__DisplayClass49_0)[1152921517817407200].line.MakeVisible(visible:  false);
            if(((WGDailyChallengeWordRegion.<>c__DisplayClass49_0)[1152921517817407200].line.numLetters) > this.longestAnswer)
        {
                this.longestAnswer = (WGDailyChallengeWordRegion.<>c__DisplayClass49_0)[1152921517817407200].line.numLetters;
        }
        
            UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.CalculateCellSizeNextFrame());
        }
        
        DG.Tweening.Tween val_8 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.1f, callback:  new DG.Tweening.TweenCallback(object:  new WGDailyChallengeWordRegion.<>c__DisplayClass49_0(), method:  System.Void WGDailyChallengeWordRegion.<>c__DisplayClass49_0::<GrantHint>b__0()), ignoreTimeScale:  true);
    }
    public override void HintReward()
    {
        var val_4;
        System.Predicate<LineWord> val_6;
        if(this.complete == true)
        {
                return;
        }
        
        if(this.granting_hint == true)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        val_6 = WGDailyChallengeWordRegion.<>c.<>9__50_0;
        if(val_6 == null)
        {
                System.Predicate<LineWord> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Predicate<LineWord>(object:  WGDailyChallengeWordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeWordRegion.<>c::<HintReward>b__50_0(LineWord x));
            WGDailyChallengeWordRegion.<>c.<>9__50_0 = val_6;
        }
        
        LineWord val_2 = Find(match:  val_1);
        if(val_2 == 0)
        {
                return;
        }
        
        this.GrantHint(line:  val_2);
    }
    public override void HintClick(bool free = False, LineWord line, Cell cell, bool isPickerHint = False)
    {
        if(isPickerHint != true)
        {
                DailyChallengeGameLevel val_1 = this.currentLevel;
            if(val_1.pointerGone != true)
        {
                line = this.currentWord;
        }
        
        }
        
        free = free;
        isPickerHint = isPickerHint;
        this.HintClick(free:  free, line:  line, cell:  cell, isPickerHint:  isPickerHint);
        Player val_2 = App.Player;
        int val_3 = val_2.properties.LifetimeDCHints;
        val_3 = val_3 + 1;
        val_2.properties.LifetimeDCHints = val_3;
    }
    public override void DoFreeHint(LineWord line, Cell cell, UnityEngine.Transform hintAnimStartTransform)
    {
        DailyChallengeGameLevel val_1 = this.currentLevel;
        if(val_1.pointerGone != true)
        {
                line = this.currentWord;
        }
        
        this.DoFreeHint(line:  line, cell:  cell, hintAnimStartTransform:  hintAnimStartTransform);
    }
    public override void CheckAnswer(string checkWord)
    {
        this.CheckAnswer(checkWord:  checkWord);
    }
    private void CheckAnswerBetter(string checkWord, bool fromHint = False)
    {
        DG.Tweening.TweenCallback val_32;
        System.Predicate<T> val_33;
        UnityEngine.Object val_34;
        var val_35;
        var val_36;
        val_32 = this;
        .checkWord = checkWord;
        if(this.complete != false)
        {
                return;
        }
        
        bool val_2 = System.String.IsNullOrEmpty(value:  checkWord);
        if(val_2 == false)
        {
            goto label_3;
        }
        
        label_22:
        val_2.FadeOut();
        val_2.SetWrongColor();
        WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
        val_3.sound.PlayGeneralSound(type:  5, oneshot:  true, pitch:  1f, vol:  1f);
        return;
        label_3:
        if(((WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord.m_stringLength) < this.dailyChallengeDefinition.MinRequiredLength)
        {
                val_2.FadeOut();
            val_2.SetWrongColor();
            WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
            val_4.sound.PlayGeneralSound(type:  5, oneshot:  true, pitch:  1f, vol:  1f);
            WGDailyChallengeMainController.SpecificInstance.ShowMessage(message:  System.String.Format(format:  Localization.Localize(key:  "word_length_message", defaultValue:  "Make words with at least\n{0} LETTERS", useSingularKey:  false), arg0:  this.dailyChallengeDefinition.MinRequiredLength.ToString()));
            return;
        }
        
        if((val_2.Contains(item:  (WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord)) == false)
        {
            goto label_22;
        }
        
        System.Predicate<LineWord> val_10 = null;
        val_33 = val_10;
        val_10 = new System.Predicate<LineWord>(object:  new WGDailyChallengeWordRegion.<>c__DisplayClass54_0(), method:  System.Boolean WGDailyChallengeWordRegion.<>c__DisplayClass54_0::<CheckAnswerBetter>b__0(LineWord x));
        val_34 = checkWord.Find(match:  val_10);
        bool val_12 = UnityEngine.Object.op_Inequality(x:  val_34, y:  0);
        if(val_12 == false)
        {
            goto label_26;
        }
        
        if((fromHint == true) || (val_11.isShown == false))
        {
            goto label_29;
        }
        
        val_12.SetExistColor();
        val_34.ShowExists();
        WGAudioController val_13 = MonoSingleton<WGAudioController>.Instance;
        val_13.sound.PlayGeneralSound(type:  6, oneshot:  true, pitch:  1f, vol:  1f);
        val_35 = 1152921517818250032;
        goto label_65;
        label_26:
        val_35 = 1152921517818250032;
        goto label_65;
        label_29:
        val_35 = val_32;
        val_12.SetAnswerColor();
        if(val_11.isStarred != false)
        {
                GameEcon val_15 = App.getGameEcon + 452;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_14.wordCoinBonus.flags, hi = val_14.wordCoinBonus.flags, lo = 366026752, mid = 268435456}, source:  "Word Coin Bonus", externalParams:  0, animated:  false);
        }
        
        WGAudioController val_16 = MonoSingleton<WGAudioController>.Instance;
        val_16.sound.PlayGeneralSound(type:  4, oneshot:  true, pitch:  1f, vol:  1f);
        bool val_17 = this.SavedLevelProgress.ContainsKey(key:  (WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord);
        val_33 = this.SavedLevelProgress;
        string val_18 = val_17.SerializeAnswer(answer:  (WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord, revealed:  (WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord.m_stringLength);
        if(val_17 != false)
        {
                val_33.set_Item(key:  (WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord, value:  val_18);
        }
        else
        {
                val_33.Add(key:  (WGDailyChallengeWordRegion.<>c__DisplayClass54_0)[1152921517818286048].checkWord, value:  val_18);
        }
        
        if(val_34.gameObject.activeSelf != true)
        {
                val_34.gameObject.SetActive(value:  true);
            val_34.MakeVisible(visible:  false);
            if(val_11.numLetters > this.longestAnswer)
        {
                this.longestAnswer = val_11.numLetters;
        }
        
            UnityEngine.Coroutine val_23 = this.StartCoroutine(routine:  this.CalculateCellSizeNextFrame());
        }
        
        if(fromHint != true)
        {
                val_34.ShowAnswer(waitTime:  0.1f);
        }
        
        System.Collections.Generic.List<System.String> val_32 = this.currentLevelProgress;
        val_32 = val_32 + 1;
        this.complete = (val_32 >= this.dailyChallengeDefinition.MinRequiredWordsAmount) ? 1 : 0;
        if(val_32 >= this.dailyChallengeDefinition.MinRequiredWordsAmount)
        {
                decimal val_26 = this.dailyChallengeDefinition.GetReward;
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid}, source:  "Daily Challenge Stage {0}", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
        WGDailyChallengeMainController.SpecificInstance.UpdateProgressBar(delay:  0.8f);
        if(this.complete != false)
        {
                WGDailyChallengeMainController.SpecificInstance.SetLevelComplete();
            val_34 = 1152921504988262400;
            val_36 = null;
            val_36 = null;
            val_32 = WGDailyChallengeWordRegion.<>c.<>9__54_1;
            if(val_32 == null)
        {
                DG.Tweening.TweenCallback val_29 = null;
            val_32 = val_29;
            val_29 = new DG.Tweening.TweenCallback(object:  WGDailyChallengeWordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGDailyChallengeWordRegion.<>c::<CheckAnswerBetter>b__54_1());
            WGDailyChallengeWordRegion.<>c.<>9__54_1 = val_32;
        }
        
            DG.Tweening.DOVirtual.DelayedCall(delay:  0.2f, callback:  val_29, ignoreTimeScale:  true).ClearLevelProgress();
        }
        
        label_65:
        PrefsSerializationManager.SavePlayerPrefs().FadeOut();
    }
    public override void Hack_GrantWord()
    {
        var val_11;
        var val_12;
        System.Predicate<LineWord> val_14;
        val_11 = this;
        val_12 = null;
        val_12 = null;
        val_14 = WGDailyChallengeWordRegion.<>c.<>9__55_0;
        if(val_14 == null)
        {
                System.Predicate<LineWord> val_1 = null;
            val_14 = val_1;
            val_1 = new System.Predicate<LineWord>(object:  WGDailyChallengeWordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeWordRegion.<>c::<Hack_GrantWord>b__55_0(LineWord x));
            WGDailyChallengeWordRegion.<>c.<>9__55_0 = val_14;
        }
        
        var val_11 = 1152921515469448608;
        if((FindAll(match:  val_1)) == null)
        {
                return;
        }
        
        if(val_14 < 1)
        {
                return;
        }
        
        int val_3 = UnityEngine.Random.Range(min:  0, max:  326805856);
        if(val_11 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = val_11 + (val_3 << 3);
        val_11 = ???;
        val_14 = ???;
        goto typeof(WGDailyChallengeWordRegion).__il2cppRuntimeField_1D0;
    }
    public void Hack_GrantSunMoonWord()
    {
        if(this.currentWord != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void Hack_CompleteLevel()
    {
        goto label_1;
        label_7:
        0 = 1;
        label_1:
        DailyChallengeGameLevel val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        if(0 < val_2.gameLevel.actualWordCount)
        {
            goto label_7;
        }
    
    }
    public WGDailyChallengeWordRegion()
    {
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  900f, y:  550f);
        this.spacing = 10f;
        this.regionSize = val_1.x;
    }

}
