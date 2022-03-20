using UnityEngine;
public class Pan : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    // Fields
    private string word;
    private System.Collections.Generic.List<string> tileStrings;
    private System.Collections.Generic.List<UnityEngine.Vector3> letterPositions;
    private System.Collections.Generic.List<UnityEngine.Vector3> letterLocalPositions;
    private System.Collections.Generic.List<int> indexes;
    private bool hasInitialized;
    private int level;
    public UnityEngine.Transform centerPoint;
    public TextPreview textPreview;
    public static Pan instance;
    public System.Collections.Generic.List<LetterTile> letterTexts;
    private bool isShuffling;
    private UnityEngine.RectTransform SelectableLetters;
    private WGGameplayMessage swipeLettersMessage;
    private UnityEngine.CanvasGroup canvasGroup;
    private UGUIFadeCanvasGroup myFader;
    private int wrongClickCount;
    private const bool tappingAllowed = False;
    private bool didDrag;
    
    // Properties
    public System.Collections.Generic.List<string> getTileStrings { get; }
    public int numberOfLetters { get; }
    private int WrongClickCounter { get; set; }
    
    // Methods
    public System.Collections.Generic.List<string> get_getTileStrings()
    {
        return (System.Collections.Generic.List<System.String>)this.tileStrings;
    }
    public int get_numberOfLetters()
    {
        return 20641;
    }
    private int get_WrongClickCounter()
    {
        return (int)this.wrongClickCount;
    }
    private void set_WrongClickCounter(int value)
    {
        this.wrongClickCount = value;
        if(value < 3)
        {
                return;
        }
        
        this.wrongClickCount = 0;
        if(this.swipeLettersMessage == 0)
        {
                return;
        }
        
        bool val_3 = this.swipeLettersMessage.ShowMessage(message:  Localization.Localize(key:  "gameplay_message_swipe_letters", defaultValue:  "Swipe the Letters", useSingularKey:  false), showLetterNo:  false, letterCount:  0);
    }
    private void Awake()
    {
        Pan.tappingAllowed = this;
        UnityEngine.CanvasGroup val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        this.canvasGroup = val_2;
        val_2.interactable = false;
        this.canvasGroup.blocksRaycasts = false;
    }
    private void Start()
    {
        this.level = Prefs.currentLevel;
        MainController val_2 = MainController.instance;
        val_2.onBeforeLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void Pan::OnLevelComplete()));
        WordRegion val_4 = WordRegion.instance;
        val_4.onWordFound.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void Pan::OnWordFound()));
    }
    private void RecalculatePanPositions()
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.letterLocalPositions.Clear();
        this.letterPositions.Clear();
        this.CalculatePostions();
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.SetLettersPositions());
        this.RecalculateLetterPositions();
    }
    private void CalculatePostions()
    {
        float val_9;
        GameBehavior val_1 = App.getBehavior;
        val_9 = 90f;
        var val_9 = 0;
        label_20:
        val_9 = val_9 + 1;
        if(val_9 >= this.tileStrings)
        {
            goto label_7;
        }
        
        float val_4 = (val_9 * 3.141593f) / 180f;
        float val_10 = val_4;
        float val_11 = val_4;
        GameBehavior val_5 = App.getBehavior;
        val_10 = V0.16B * val_10;
        val_11 = val_11 / V0.16B;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_10, y:  val_11, z:  0f);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Multiply(d:  (float)val_5.<gameplayBehavior>k__BackingField, a:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        this.letterLocalPositions.Add(item:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        if(null != null)
        {
            goto label_18;
        }
        
        UnityEngine.Vector3 val_8 = this.centerPoint.TransformPoint(position:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        this.letterPositions.Add(item:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
        val_9 = (360f / (float)S9) + val_9;
        if(this.tileStrings != null)
        {
            goto label_20;
        }
        
        throw new NullReferenceException();
        label_7:
        LineDrawer.instance.letterPositions = this.letterPositions;
        return;
        label_18:
    }
    public void Load(GameLevel gameLevel)
    {
        GameLevel val_51;
        System.Collections.Generic.List<System.String> val_52;
        var val_53;
        System.Collections.Generic.List<System.Int32> val_54;
        var val_55;
        System.Func<System.String, System.Int32> val_57;
        System.Collections.Generic.List<System.Int32> val_59;
        var val_60;
        var val_61;
        System.Collections.Generic.List<System.Int32> val_62;
        val_51 = gameLevel;
        System.Collections.Generic.List<T> val_3 = CUtils.BuildListFromString<System.String>(values:  gameLevel.word.Trim(), split:  '|');
        this.tileStrings = val_3;
        if(1152921515450531344 <= 1)
        {
                val_3.Clear();
            string val_4 = gameLevel.word.Trim();
            if(val_4.m_stringLength >= 1)
        {
                var val_49 = 0;
            do
        {
            val_52 = this.tileStrings;
            string val_6 = gameLevel.word.Chars[0].ToString();
            val_52.Add(item:  val_6);
            val_49 = val_49 + 1;
        }
        while(val_49 < val_4.m_stringLength);
        
        }
        
        }
        
        this.CalculatePostions();
        val_53 = 1152921515450562064;
        val_54 = 1152921515450563088;
        var val_50 = 0;
        label_32:
        if(val_50 >= val_6)
        {
            goto label_14;
        }
        
        LetterTile val_8 = UnityEngine.Object.Instantiate<LetterTile>(original:  MonoUtils.instance.letterTile);
        val_8.transform.SetParent(p:  this.centerPoint);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, d:  this.GetScaleMultBasedOnCount(count:  0));
        val_8.transform.localScale = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (float)UnityEngine.Random.Range(min:  9, max:  10));
        UnityEngine.Quaternion val_17 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
        val_8.transform.localRotation = new UnityEngine.Quaternion() {x = val_17.x, y = val_17.y, z = val_17.z, w = val_17.w};
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        string val_18 = (UnityEngine.Quaternion.__il2cppRuntimeField_cctor_finished + 0) + 32.ToUpper();
        this.letterTexts.Add(item:  val_8);
        val_50 = val_50 + 1;
        if(this.tileStrings != null)
        {
            goto label_32;
        }
        
        label_14:
        System.Collections.Generic.List<TSource> val_20 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Range(start:  0, count:  val_6));
        this.indexes = val_20;
        System.Nullable<System.Int32> val_21 = new System.Nullable<System.Int32>(value:  this.level);
        PluginExtension.Shuffle<System.Int32>(list:  val_20, seed:  new System.Nullable<System.Int32>() {HasValue = val_21.HasValue});
        GameBehavior val_22 = App.getBehavior;
        GameEcon val_23 = App.getGameEcon;
        if(((val_22.<metaGameBehavior>k__BackingField) > val_23.finalForcedLetterLayoutLevel) || ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true))
        {
            goto label_43;
        }
        
        char[] val_26 = new char[1];
        val_26[0] = 124;
        val_55 = null;
        val_55 = null;
        val_57 = Pan.<>c.<>9__28_0;
        if(val_57 == null)
        {
                System.Func<System.String, System.Int32> val_29 = null;
            val_57 = val_29;
            val_29 = new System.Func<System.String, System.Int32>(object:  Pan.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 Pan.<>c::<Load>b__28_0(string p));
            Pan.<>c.<>9__28_0 = val_57;
        }
        
        System.Collections.Generic.List<TSource> val_31 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.OrderByDescending<System.String, System.Int32>(source:  new System.Collections.Generic.List<System.String>(collection:  gameLevel + 72.Split(separator:  val_26)), keySelector:  val_29));
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.String>(System.Collections.Generic.IEnumerable<TSource> source)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<System.Int32> val_32 = new System.Collections.Generic.List<System.Int32>();
        this.indexes.Clear();
        val_53 = 1152921510479955696;
        var val_52 = 0;
        var val_51 = 0;
        val_51 = Chars[0];
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((val_51 & 65535) == (Dictionary<TKey, TValue>.__il2cppRuntimeField_20.Chars[0]))
        {
                if((val_32.Contains(item:  0)) == false)
        {
            goto label_63;
        }
        
        }
        
        val_51 = val_51 + 1;
        goto label_65;
        label_63:
        val_32.Add(item:  0);
        label_65:
        val_52 = val_52 + 1;
        System.Collections.Generic.List<System.String> val_54 = this.tileStrings;
        var val_53 = 0;
        label_71:
        if(val_53 >= val_54)
        {
            goto label_69;
        }
        
        if((val_32.Contains(item:  0)) != true)
        {
                val_32.Add(item:  0);
        }
        
        val_53 = val_53 + 1;
        if(this.tileStrings != null)
        {
            goto label_71;
        }
        
        label_69:
        val_59 = this.indexes;
        if(val_53 < 0)
        {
            goto label_73;
        }
        
        val_60 = (long)val_54 - 1;
        val_61 = val_54 - 2;
        goto label_74;
        label_77:
        val_60 = val_60 - 1;
        val_61 = val_61 - 1;
        label_74:
        if(val_60 >= val_54)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_54 = val_54 + ((((long)(int)((this.tileStrings - 1)) - 1)) << 2);
        val_59.Add(item:  0);
        val_59 = this.indexes;
        if((val_61 & 2147483648) == 0)
        {
            goto label_77;
        }
        
        label_73:
        if(val_54 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_54 = val_54 + ((val_54 - 1) << 2);
        val_59.Insert(index:  0, item:  1578141424);
        this.indexes.RemoveAt(index:  val_54 - 1);
        val_54 = this.indexes;
        val_52 = val_54 - 1;
        if(val_54 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_54 = val_54 + (val_52 << 2);
        val_54.Insert(index:  0, item:  -2050192688);
        this.indexes.RemoveAt(index:  val_54 - 1);
        label_43:
        if(WGFTUXManager.CanShow != false)
        {
                GameBehavior val_43 = App.getBehavior;
            System.Collections.Generic.List<System.Int32> val_44 = MonoSingletonSelfGenerating<WADataParser>.Instance.GetIndexesForTutorialLevel(level:  val_43.<metaGameBehavior>k__BackingField, lettersSize:  -2050192688, lettersArray:  this.tileStrings);
            val_62 = val_44;
            this.indexes = val_44;
        }
        else
        {
                val_62 = this.indexes;
        }
        
        UnityEngine.Coroutine val_46 = this.StartCoroutine(routine:  this.indexes.EnableLetters(tileStrings:  this.tileStrings, indexes:  val_62));
        this.hasInitialized = true;
        this.GetPanWord();
        UnityEngine.Coroutine val_48 = this.StartCoroutine(routine:  this.SetLettersPositions());
        this.RecalculateLetterPositions();
    }
    private System.Collections.IEnumerator EnableLetters(System.Collections.Generic.List<string> tileStrings, System.Collections.Generic.List<int> indexes)
    {
        .<>1__state = 0;
        .tileStrings = tileStrings;
        .indexes = indexes;
        return (System.Collections.IEnumerator)new Pan.<EnableLetters>d__29();
    }
    public void EnablePan()
    {
        this.canvasGroup.interactable = true;
        this.canvasGroup.blocksRaycasts = true;
        this.myFader.Execute();
    }
    private System.Collections.IEnumerator SetLettersPositions()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Pan.<SetLettersPositions>d__31();
    }
    private float GetScaleMultBasedOnCount(int count)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_2A0;
    }
    private void RecalculateLetterPositions()
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.gameObject.activeSelf == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.RecalculateSize());
    }
    private System.Collections.IEnumerator RecalculateSize()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Pan.<RecalculateSize>d__34();
    }
    private void OnRectTransformDimensionsChange()
    {
        if((UnityEngine.Object.op_Implicit(exists:  LineDrawer.instance)) == false)
        {
                return;
        }
        
        this.RecalculatePanPositions();
    }
    private void GetShuffeWord()
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.AddRange(collection:  this.indexes);
        do
        {
            PluginExtension.Shuffle<System.Int32>(list:  this.indexes, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        }
        while((System.Linq.Enumerable.SequenceEqual<System.Int32>(first:  val_1, second:  this.indexes)) == true);
        
        this.GetPanWord();
    }
    private void GetPanWord()
    {
        System.Collections.Generic.List<System.String> val_1 = null;
        var val_3 = 1152921509851217984;
        val_1 = new System.Collections.Generic.List<System.String>();
        var val_4 = 0;
        label_7:
        if(val_4 >= val_3)
        {
            goto label_2;
        }
        
        if(val_4 >= X9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_2 = X9 + 0;
        if(val_3 <= ((X9 + 0) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + (((X9 + 0) + 32) << 3);
        val_1.Add(item:  (1152921509851217984 + ((X9 + 0) + 32) << 3) + 32);
        val_4 = val_4 + 1;
        if(this.tileStrings != null)
        {
            goto label_7;
        }
        
        label_2:
        this.textPreview.tileStrings = val_1;
    }
    public string GetLetter(int i)
    {
        bool val_1 = true;
        if(val_1 <= i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + (i << 2);
        if(val_1 <= ((true + (i) << 2) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + (((true + (i) << 2) + 32) << 3);
        return (string)((true + (i) << 2) + ((true + (i) << 2) + 32) << 3) + 32;
    }
    public void HighlightLetter(int i, bool state)
    {
        var val_8;
        var val_9;
        val_8 = state;
        val_9 = this;
        bool val_8 = this.hasInitialized;
        if(val_8 == false)
        {
                return;
        }
        
        if(val_8 <= i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (i << 2);
        if(val_8 <= ((this.hasInitialized + (i) << 2) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (((this.hasInitialized + (i) << 2) + 32) << 3);
        bool val_1 = val_8;
        val_8 = ???;
        val_9 = ???;
        goto ((this.hasInitialized + (i) << 2) + ((this.hasInitialized + (i) << 2) + 32) << 3) + 32 + 416;
    }
    public void UnhighlightAllLetters()
    {
        System.Collections.Generic.List<LetterTile> val_2;
        bool val_2 = this.hasInitialized;
        if(val_2 == false)
        {
                return;
        }
        
        val_2 = this.letterTexts;
        var val_3 = 0;
        do
        {
            if(val_3 >= val_2)
        {
                return;
        }
        
            if(W9 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_1 = X9 + 0;
            if(val_2 <= ((X9 + 0) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = val_2 + (((X9 + 0) + 32) << 3);
            val_2 = this.letterTexts;
            val_3 = val_3 + 1;
        }
        while(val_2 != null);
        
        throw new NullReferenceException();
    }
    public int IsInRectofAnyTile(UnityEngine.Vector2 mousePos)
    {
        System.Collections.Generic.List<System.Int32> val_3;
        var val_4;
        bool val_3 = true;
        val_3 = this.indexes;
        val_4 = 0;
        label_10:
        if(val_4 >= val_3)
        {
            goto label_2;
        }
        
        if(val_3 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + 0;
        if(val_3 <= ((true + 0) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + (((true + 0) + 32) << 3);
        val_3 = mem[((true + 0) + ((true + 0) + 32) << 3) + 32 + 40];
        val_3 = ((true + 0) + ((true + 0) + 32) << 3) + 32 + 40;
        if((UnityEngine.RectTransformUtility.RectangleContainsScreenPoint(rect:  val_3, screenPoint:  new UnityEngine.Vector2() {x = mousePos.x, y = mousePos.y}, cam:  UnityEngine.Camera.main)) == true)
        {
                return (int)val_4;
        }
        
        val_3 = this.indexes;
        val_4 = val_4 + 1;
        if(val_3 != null)
        {
            goto label_10;
        }
        
        throw new NullReferenceException();
        label_2:
        val_4 = 0;
        return (int)val_4;
    }
    public bool IsInRectofTile(int index, UnityEngine.Vector2 mousePos)
    {
        bool val_2 = true;
        if(val_2 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (index << 2);
        if(val_2 <= ((true + (index) << 2) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (((true + (index) << 2) + 32) << 3);
        return UnityEngine.RectTransformUtility.RectangleContainsScreenPoint(rect:  ((true + (index) << 2) + ((true + (index) << 2) + 32) << 3) + 32 + 40, screenPoint:  new UnityEngine.Vector2() {x = mousePos.x, y = mousePos.y}, cam:  UnityEngine.Camera.main);
    }
    public void Shuffle()
    {
        if(WGFTUXManager.IsShowing == true)
        {
                return;
        }
        
        if(this.isShuffling == true)
        {
                return;
        }
        
        this.isShuffling = true;
        this.GetShuffeWord();
        this.MoveLettersToCenter();
        this = 1152921515404623536;
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.sound.PlayButtonSound(type:  0, pitch:  1f, vol:  1f);
        WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
        val_3.sound.PlayGeneralSound(type:  10, oneshot:  true, pitch:  1f, vol:  1f);
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        MainController.instance.ShufflesUsed = val_6.shufflesUsed + 1;
    }
    private void MoveLettersToCenter()
    {
        System.Collections.Generic.List<LetterTile> val_17;
        if(this.letterTexts == this.indexes)
        {
                if(this.letterTexts < 1)
        {
                return;
        }
        
            var val_17 = 0;
            do
        {
            float val_1 = UnityEngine.Random.Range(min:  0.12f, max:  0.2f);
            if(32555008 <= val_17)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  UnityEngine.Random.Range(min:  -15f, max:  15f), y:  UnityEngine.Random.Range(min:  -15f, max:  15f), z:  0f);
            val_17 = this.letterTexts;
            if(val_17 == 32555007)
        {
                DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  -11037348.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, duration:  val_1, snapping:  false), ease:  5), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Pan::MoveLettersToPositions()));
            val_17 = this.letterTexts;
        }
        
            if(32555007 <= val_17)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (float)UnityEngine.Random.Range(min:  719, max:  208));
            DG.Tweening.Tweener val_16 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  1469406271.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, duration:  val_1, mode:  0), ease:  5);
            val_17 = val_17 + 1;
        }
        while(val_17 < this.letterTexts);
        
            return;
        }
        
        this.isShuffling = false;
    }
    private void MoveLettersToPositions()
    {
        System.Collections.Generic.List<LetterTile> val_16;
        if(this.letterTexts == this.indexes)
        {
                if(this.letterTexts < 1)
        {
                return;
        }
        
            var val_18 = 0;
            do
        {
            float val_16 = UnityEngine.Random.Range(min:  0.12f, max:  0.2f);
            if(32555008 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.Collections.Generic.List<System.Int32> val_17 = this.indexes;
            int val_5 = val_17.IndexOf(item:  0);
            val_16 = val_16 + (UnityEngine.Random.Range(min:  0f, max:  0.2f));
            if(val_17 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_17 = val_17 + (val_5 * 12);
            val_16 = this.letterTexts;
            val_17 = val_17 - 1;
            if(val_18 == val_17)
        {
                DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  -11037348.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = (val_5 * 12) + this.indexes + 32, y = (val_5 * 12) + this.indexes + 32 + 4, z = (val_5 * 12) + this.indexes + 40}, duration:  val_16, snapping:  false), ease:  6), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Pan::ShuffleComplete()));
            val_16 = this.letterTexts;
        }
        
            if(1152921504797261824 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  UnityEngine.Random.Range(min:  -10f, max:  10f));
            DG.Tweening.Tweener val_15 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, duration:  val_16, mode:  0), ease:  6);
            val_18 = val_18 + 1;
        }
        while(val_18 < this.letterTexts);
        
            return;
        }
        
        this.isShuffling = false;
    }
    private void ShuffleComplete()
    {
        this.isShuffling = false;
    }
    private void OnLevelComplete()
    {
        bool val_1 = true;
        var val_2 = 0;
        do
        {
            if(val_2 >= val_1)
        {
                return;
        }
        
            if(val_1 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1 = val_1 + 0;
            val_2 = val_2 + 1;
        }
        while(this.letterTexts != null);
        
        throw new NullReferenceException();
    }
    public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.didDrag = true;
        LineDrawer.instance.BeginDrag();
    }
    public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        LineDrawer.instance.DoDrag(mousePos:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField});
    }
    public void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.didDrag = false;
        LineDrawer.instance.EndDrag(checkAnswer:  true);
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        LineDrawer.instance.DoPointerDown(mousePos:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField});
    }
    public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(this.didDrag != false)
        {
                this.wrongClickCount = 0;
        }
        else
        {
                this.WrongClickCounter = this.wrongClickCount + 1;
        }
        
        LineDrawer.instance.EndDrag(checkAnswer:  true);
    }
    public void OnWordFound()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.EnableLetters(tileStrings:  this.tileStrings, indexes:  this.indexes));
    }
    public Pan()
    {
        this.tileStrings = new System.Collections.Generic.List<System.String>();
        this.letterPositions = new System.Collections.Generic.List<UnityEngine.Vector3>();
        this.letterLocalPositions = new System.Collections.Generic.List<UnityEngine.Vector3>();
        this.indexes = new System.Collections.Generic.List<System.Int32>();
        this.letterTexts = new System.Collections.Generic.List<LetterTile>();
    }

}
