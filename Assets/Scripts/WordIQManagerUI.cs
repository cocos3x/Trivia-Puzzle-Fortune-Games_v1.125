using UnityEngine;
public class WordIQManagerUI : MonoSingleton<WordIQManagerUI>
{
    // Fields
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<WordIQCellOverlay>> NewWordCellsDict;
    private System.Collections.Generic.Dictionary<string, LineWord> NewWordLines;
    private float _IQPointsAtStartOfLevel;
    private IQGains _IQPointsGainedLastLevel;
    private System.Collections.Generic.List<string> _NewWordsFoundLastLevel;
    
    // Properties
    public UnityEngine.Sprite MilestoneColorableSprite { get; }
    public UnityEngine.Sprite MilestoneMasterSprite { get; }
    private WordIQCellOverlay NewWordCellPrefab { get; }
    private WordIQLineAnim NewWordNewAnimPrefab { get; }
    private WordIQLineAnim NewWordAnsweredAnimPrefab { get; }
    public float IQPointsAtStartOfLevel { get; }
    public IQGains IQPointsGainedLastLevel { get; }
    public System.Collections.Generic.List<string> NewWordsFoundLastLevel { get; }
    
    // Methods
    public static string FormatPoints(float iqPoints)
    {
        float val_3 = 100f;
        val_3 = (iqPoints * val_3) / val_3;
        return (string)val_3.ToString(format:  "#0.00");
    }
    public UnityEngine.Sprite get_MilestoneColorableSprite()
    {
        UnityEngine.Object val_6;
        UnityEngine.Sprite val_7;
        val_6 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
        val_6 = val_3.theme;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = val_5.theme.wordIQMilestoneColorableSprite;
        return val_7;
    }
    public UnityEngine.Sprite get_MilestoneMasterSprite()
    {
        UnityEngine.Object val_6;
        UnityEngine.Sprite val_7;
        val_6 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
        val_6 = val_3.theme;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = val_5.theme.wordIQMilestoneMasterSprite;
        return val_7;
    }
    private WordIQCellOverlay get_NewWordCellPrefab()
    {
        UnityEngine.Object val_6;
        WordIQCellOverlay val_7;
        val_6 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
        val_6 = val_3.theme;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = val_5.theme.wordIQCell;
        return val_7;
    }
    private WordIQLineAnim get_NewWordNewAnimPrefab()
    {
        UnityEngine.Object val_6;
        WordIQLineAnim val_7;
        val_6 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
        val_6 = val_3.theme;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = val_5.theme.wordIQNewWordTag;
        return val_7;
    }
    private WordIQLineAnim get_NewWordAnsweredAnimPrefab()
    {
        UnityEngine.Object val_6 = MonoSingleton<ThemesHandler>.Instance;
        if(val_6 == 0)
        {
                return 0;
        }
        
        ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
        val_6 = val_3.theme;
        if(val_6 == 0)
        {
                return 0;
        }
        
        ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
        return val_5.theme.WordIQNewWordAnswered;
    }
    public float get_IQPointsAtStartOfLevel()
    {
        return (float)this._IQPointsAtStartOfLevel;
    }
    public IQGains get_IQPointsGainedLastLevel()
    {
        return (IQGains)this._IQPointsGainedLastLevel;
    }
    public System.Collections.Generic.List<string> get_NewWordsFoundLastLevel()
    {
        return (System.Collections.Generic.List<System.String>)this._NewWordsFoundLastLevel;
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WordIQManagerUI::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    public void OnDestroy()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingletonSelfGenerating<SceneDictator>.Instance)) == false)
        {
                return;
        }
        
        SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        1152921504893267968 = val_3.OnSceneLoaded;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893267968, value:  new System.Action<SceneType>(object:  this, method:  System.Void WordIQManagerUI::OnSceneLoaded(SceneType sceneType)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.OnSceneLoaded = val_5;
        return;
        label_10:
    }
    public void PrepNewLevel()
    {
        this.NewWordCellsDict.Clear();
        this.NewWordLines.Clear();
    }
    public void DisplayNewWordsInLevel(System.Collections.Generic.List<string> newWords, bool showNewTag)
    {
        LineWord val_5;
        var val_6;
        var val_21;
        Cell val_22;
        if(this.NewWordCellPrefab == 0)
        {
                return;
        }
        
        WordRegion val_3 = WordRegion.instance;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_4 = val_3.GetEnumerator();
        val_21 = 1152921515446279280;
        label_28:
        if(val_6.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(newWords == null)
        {
                throw new NullReferenceException();
        }
        
        if((newWords.Contains(item:  val_5 + 24)) == false)
        {
            goto label_28;
        }
        
        if(mem[1152921516856582992] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921516856582992].Add(key:  val_5 + 24, value:  val_5);
        System.Collections.Generic.List<WordIQCellOverlay> val_9 = new System.Collections.Generic.List<WordIQCellOverlay>();
        if((val_5 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_10 = val_5 + 40.GetEnumerator();
        label_22:
        bool val_11 = val_6.MoveNext();
        if(val_11 == false)
        {
            goto label_14;
        }
        
        val_22 = val_5;
        if(val_22 == 0)
        {
                throw new NullReferenceException();
        }
        
        WordIQCellOverlay val_14 = UnityEngine.Object.Instantiate<WordIQCellOverlay>(original:  val_11.NewWordCellPrefab, parent:  val_22.transform);
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_15 = val_14.transform;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.SetSiblingIndex(index:  1);
        val_14.SetParentCell(parentCell:  val_22);
        UnityEngine.GameObject val_16 = val_14.gameObject;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16.SetActive(value:  ((val_5 + 72) == 0) ? 1 : 0);
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.Add(item:  val_14);
        goto label_22;
        label_14:
        var val_20 = 0;
        val_22 = 0;
        val_20 = val_20 + 1;
        mem2[0] = 205;
        val_6.Dispose();
        var val_21 = val_20;
        if(val_22 != 0)
        {
                throw X24;
        }
        
        if(val_21 != 1)
        {
                var val_18 = ((-635178144 + ((0 + 1)) << 2) == 205) ? 1 : 0;
            val_18 = ((val_21 >= 0) ? 1 : 0) & val_18;
            val_21 = val_21 - val_18;
        }
        
        mem[1152921516856582984].Add(key:  val_5 + 24, value:  val_9);
        if(showNewTag == false)
        {
            goto label_28;
        }
        
        this.PlayNewAnim(line:  val_5);
        goto label_28;
        label_8:
        val_6.Dispose();
    }
    public void NewWordFound(string word, bool isExtra)
    {
        bool val_7 = isExtra;
        if(val_7 != false)
        {
                MonoSingleton<WordIQFeedbackWord>.Instance.ShowIQWord(word:  word);
            return;
        }
        
        if((this.NewWordCellsDict.ContainsKey(key:  word)) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.NewWordCellsDict.Item[word].GetEnumerator();
        val_7 = 1152921516856731376;
        label_12:
        if(0.MoveNext() == false)
        {
            goto label_10;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.PlayFoundAnimation();
        goto label_12;
        label_10:
        0.Dispose();
        this.PlayAnsweredAnim(line:  this.NewWordLines.Item[word]);
    }
    public void WordHint(string word, int hintIndex, bool isFree, bool isPickerHint)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((MonoSingleton<WordIQManager>.Instance.IsNewWord(word:  word)) == false)
        {
                return;
        }
        
        if((this.NewWordCellsDict.ContainsKey(key:  word)) == false)
        {
                return;
        }
        
        var val_8 = 1152921516856725232;
        System.Collections.Generic.List<WordIQCellOverlay> val_6 = this.NewWordCellsDict.Item[word];
        if(val_8 <= hintIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (hintIndex << 3);
        (1152921516856725232 + (hintIndex) << 3) + 32.gameObject.SetActive(value:  false);
    }
    public void HandleLevelCompleted(float iqPointsTotal, IQGains iqPointsGainedLastLevel, System.Collections.Generic.List<string> newWordsFoundLastLevel)
    {
        IQGains val_7;
        int val_8;
        var val_9;
        var val_10;
        val_7 = iqPointsGainedLastLevel;
        val_8 = this;
        float val_1 = val_7.Total;
        val_1 = iqPointsTotal - val_1;
        this._IQPointsGainedLastLevel = val_7;
        this._NewWordsFoundLastLevel = newWordsFoundLastLevel;
        this._IQPointsAtStartOfLevel = val_1;
        int val_5 = MonoSingleton<WordIQManager>.Instance.PlayerMilestone;
        if((MonoSingleton<WordIQManager>.Instance.GetMilestone(iqPoints:  this._IQPointsAtStartOfLevel)) == val_5)
        {
                return;
        }
        
        val_8 = val_5;
        val_9 = null;
        val_9 = null;
        val_10 = null;
        val_10 = null;
        val_7 = Events.IQ_MILESTONE;
        App.trackerManager.track(eventName:  System.String.Format(format:  "{0}_{1}", arg0:  val_7, arg1:  val_8));
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
        if(sceneType != 2)
        {
                return;
        }
        
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnHintedUsedAction(callback:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  public System.Void WordIQManagerUI::WordHint(string word, int hintIndex, bool isFree, bool isPickerHint)));
    }
    private UnityEngine.Vector3 GetMidpoint(LineWord line)
    {
        var val_21 = 0;
        float val_20 = 0f;
        float val_19 = 0f;
        label_9:
        UnityEngine.Transform val_3 = line.transform;
        if(val_21 >= line.transform.childCount)
        {
            goto label_3;
        }
        
        UnityEngine.Vector3 val_6 = val_3.GetChild(index:  0).transform.localPosition;
        val_19 = val_19 + val_6.x;
        UnityEngine.Vector3 val_10 = line.transform.GetChild(index:  0).transform.localPosition;
        val_20 = val_20 + val_10.y;
        val_21 = val_21 + 1;
        if(line.transform != null)
        {
            goto label_9;
        }
        
        label_3:
        val_20 = val_20 / (float)line.transform.childCount;
        UnityEngine.Vector3 val_17 = line.transform.localPosition;
        UnityEngine.Vector3 val_18 = new UnityEngine.Vector3(x:  val_19 / (float)val_3.childCount, y:  val_20, z:  val_17.z);
        return new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
    }
    private void PlayNewAnim(LineWord line)
    {
        UnityEngine.Vector3 val_1 = this.GetMidpoint(line:  line);
        UnityEngine.Object.Instantiate<WordIQLineAnim>(original:  this.NewWordNewAnimPrefab, parent:  line.transform).transform.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
    }
    private void PlayAnsweredAnim(LineWord line)
    {
        UnityEngine.Vector3 val_1 = this.GetMidpoint(line:  line);
        UnityEngine.Object.Instantiate<WordIQLineAnim>(original:  this.NewWordAnsweredAnimPrefab, parent:  line.transform).transform.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
    }
    public WordIQManagerUI()
    {
        this.NewWordCellsDict = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<WordIQCellOverlay>>();
        this.NewWordLines = new System.Collections.Generic.Dictionary<System.String, LineWord>();
    }

}
