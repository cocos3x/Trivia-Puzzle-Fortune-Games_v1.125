using UnityEngine;
public class WordIQLevelCompleteDisplayAnim : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text iqStat;
    private UnityEngine.UI.Text iqStatIncreaseFactor;
    private UnityEngine.UI.Text iqStatIncreaseFactor2;
    private UnityEngine.CanvasGroup newWordsGroup;
    private UnityEngine.UI.Button[] newWordButtons;
    private UnityEngine.UI.Text[] newWordButtonTexts;
    private WordIQMilestoneDisplay milestoneDisplay;
    private UnityEngine.CanvasGroup wholeDisplayGroup;
    private float whole_y_local_pos_start;
    private float whole_y_local_pos_end;
    private float statTweenDuration;
    private IQGains levelGains;
    private System.Collections.Generic.List<string> topThreeNewWords;
    private const float startDelay = 0.5;
    
    // Methods
    public void Setup()
    {
        WordIQManagerUI val_1 = MonoSingleton<WordIQManagerUI>.Instance;
        string val_2 = WordIQManagerUI.FormatPoints(iqPoints:  val_1._IQPointsAtStartOfLevel);
        WordIQManagerUI val_3 = MonoSingleton<WordIQManagerUI>.Instance;
        this.levelGains = val_3._IQPointsGainedLastLevel;
        WordIQManagerUI val_4 = MonoSingleton<WordIQManagerUI>.Instance;
        this.newWordsGroup.gameObject.SetActive(value:  false);
        if(this.levelGains != null)
        {
                if(this.levelGains.Total > 0f)
        {
                string val_9 = Localization.Localize(key:  "level_clear_iq_upper", defaultValue:  "LEVEL CLEAR + IQ", useSingularKey:  false)(Localization.Localize(key:  "level_clear_iq_upper", defaultValue:  "LEVEL CLEAR + IQ", useSingularKey:  false)) + " " + WordIQManagerUI.FormatPoints(iqPoints:  this.levelGains.levelClearPoints)(WordIQManagerUI.FormatPoints(iqPoints:  this.levelGains.levelClearPoints));
            this.iqStatIncreaseFactor2.gameObject.SetActive(value:  (this.levelGains.newWordsFoundPoints > 0f) ? 1 : 0);
            string val_14 = Localization.Localize(key:  "new_words_found_iq_upper", defaultValue:  "NEW WORDS FOUND + IQ", useSingularKey:  false)(Localization.Localize(key:  "new_words_found_iq_upper", defaultValue:  "NEW WORDS FOUND + IQ", useSingularKey:  false)) + " " + WordIQManagerUI.FormatPoints(iqPoints:  this.levelGains.newWordsFoundPoints)(WordIQManagerUI.FormatPoints(iqPoints:  this.levelGains.newWordsFoundPoints));
        }
        
        }
        
        WordIQManagerUI val_16 = MonoSingleton<WordIQManagerUI>.Instance;
        this.milestoneDisplay.UpdateMilestoneDisplay(newMilestoneIndex:  MonoSingleton<WordIQManager>.Instance.GetMilestone(iqPoints:  val_16._IQPointsAtStartOfLevel));
        UnityEngine.Vector3 val_19 = new UnityEngine.Vector3(x:  0f, y:  this.whole_y_local_pos_start, z:  0f);
        this.wholeDisplayGroup.transform.localPosition = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
    }
    public void ShowWithoutAnim()
    {
        this.wholeDisplayGroup.alpha = 1f;
        UnityEngine.Vector3 val_3 = this.wholeDisplayGroup.transform.localPosition;
        UnityEngine.Vector3 val_5 = this.wholeDisplayGroup.transform.localPosition;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_3.x, y:  this.whole_y_local_pos_end, z:  val_5.z);
        this.wholeDisplayGroup.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        if(this.newWordsGroup.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.newWordsGroup.alpha = 1f;
    }
    public void Play()
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.wholeDisplayGroup, endValue:  1f, duration:  0.35f), delay:  0.5f);
        System.Delegate val_4 = System.Delegate.Combine(a:  X21, b:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordIQLevelCompleteDisplayAnim::<Play>b__16_0()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        mem2[0] = val_4;
        DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.wholeDisplayGroup.transform, endValue:  this.whole_y_local_pos_end, duration:  0.35f, snapping:  false), delay:  0.5f);
        if(this.newWordsGroup.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.newWordsGroup.alpha = 1f;
        return;
        label_3:
    }
    public void BeginAnimations()
    {
        this.Invoke(methodName:  "BeginTweeningStat", time:  1f);
    }
    public void BeginTweeningStat()
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.TweenStat());
    }
    public void OnNewWordClicked(int index)
    {
    
    }
    private System.Collections.IEnumerator TweenStat()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordIQLevelCompleteDisplayAnim.<TweenStat>d__20();
    }
    private System.Collections.IEnumerator ShowMilestoneReached(int milestoneIndex, float milestoneAmount)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .milestoneIndex = milestoneIndex;
        .milestoneAmount = milestoneAmount;
        return (System.Collections.IEnumerator)new WordIQLevelCompleteDisplayAnim.<ShowMilestoneReached>d__21();
    }
    public WordIQLevelCompleteDisplayAnim()
    {
        this.statTweenDuration = 1f;
        this.whole_y_local_pos_start = -35f;
        this.whole_y_local_pos_end = 35f;
    }
    private void <Play>b__16_0()
    {
        this.BeginAnimations();
    }

}
