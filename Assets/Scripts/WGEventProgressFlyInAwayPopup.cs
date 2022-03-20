using UnityEngine;
public class WGEventProgressFlyInAwayPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.RectTransform flyoutRectTransform;
    private UnityEngine.UI.Text titleText;
    private UnityEngine.UI.Image eventIconImage;
    private UnityEngine.UI.Image rewardIconImage;
    private UnityEngine.UI.Slider progressSlider;
    private UnityEngine.UI.Text textProgress;
    private UnityEngine.Sprite icon_lightningLevel;
    private UnityEngine.Sprite icon_wildWord;
    private UnityEngine.Sprite iconCoins;
    private UnityEngine.Sprite iconGold;
    private UnityEngine.Sprite iconFood;
    private UnityEngine.Sprite iconGiftBox;
    private System.Collections.Generic.List<WGEventProgressFlyInAwayPopup.EventProgressPopupData> eventsProgressPopupData;
    private WGEventProgressFlyInAwayPopup.EventProgressPopupData currentEventProgressPopupData;
    private float progressStart;
    private float progressEnd;
    private string textProgressStart;
    private string textProgressEnd;
    
    // Methods
    public void SetUp(WGEventHandler handler, System.Action onCLoseCallback)
    {
        System.Collections.Generic.List<EventProgressPopupData> val_7;
        System.Collections.Generic.List<EventProgressPopupData> val_8;
        .handler = handler;
        val_7 = this.eventsProgressPopupData;
        if(val_7 == null)
        {
                System.Collections.Generic.List<EventProgressPopupData> val_2 = null;
            val_7 = val_2;
            val_2 = new System.Collections.Generic.List<EventProgressPopupData>();
            this.eventsProgressPopupData = val_7;
        }
        
        if((val_2.Find(match:  new System.Predicate<EventProgressPopupData>(object:  new WGEventProgressFlyInAwayPopup.<>c__DisplayClass19_0(), method:  System.Boolean WGEventProgressFlyInAwayPopup.<>c__DisplayClass19_0::<SetUp>b__0(WGEventProgressFlyInAwayPopup.EventProgressPopupData d)))) != null)
        {
                return;
        }
        
        val_8 = this.eventsProgressPopupData;
        if((public EventProgressPopupData System.Collections.Generic.List<EventProgressPopupData>::Find(System.Predicate<T> match)) == 0)
        {
                WordRegion.instance.AddLevelCompleteBlocker(blocker:  4);
            val_8 = this.eventsProgressPopupData;
        }
        
        .eventHandler = (WGEventProgressFlyInAwayPopup.<>c__DisplayClass19_0)[1152921517827658912].handler;
        .onCLose = onCLoseCallback;
        val_8.Add(item:  new WGEventProgressFlyInAwayPopup.EventProgressPopupData());
    }
    private void Start()
    {
        if(this.eventsProgressPopupData == null)
        {
                return;
        }
        
        if(this.eventsProgressPopupData < 1)
        {
                return;
        }
        
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ShowPopup());
    }
    private void SetUpUI()
    {
        UnityEngine.UI.Text val_23;
        var val_24;
        val_23 = this;
        string val_1 = (this.currentEventProgressPopupData.eventHandler.myEvent == 0) ? "" : this.currentEventProgressPopupData.eventHandler.myEvent.type;
        if((System.String.op_Equality(a:  val_1, b:  "LightningLevels")) == false)
        {
            goto label_4;
        }
        
        this.eventIconImage.sprite = this.icon_lightningLevel;
        this.rewardIconImage.sprite = this.iconCoins;
        val_24 = 1152921504924897280;
        this.progressStart = ;
        goto label_14;
        label_4:
        if((System.String.op_Equality(a:  val_1, b:  "WildWordWeekend")) == false)
        {
                return;
        }
        
        this.eventIconImage.sprite = this.icon_wildWord;
        this.rewardIconImage.sprite = this.iconGiftBox;
        val_24 = 1152921504920850432;
        float val_23 = (float)GetLevelsComplete();
        val_23 = val_23 / (float)WildWeekendHandler.econ_default_award.GetLevelsTotal();
        this.progressStart = val_23;
        float val_24 = (float)WildWeekendHandler.econ_default_award.GetLevelsComplete() + 1;
        val_24 = val_24 / (float)WildWeekendHandler.econ_default_award.GetLevelsTotal();
        this.progressEnd = val_24;
        this.textProgressStart = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  WildWeekendHandler.econ_default_award.GetLevelsComplete().ToString(), arg1:  WildWeekendHandler.econ_default_award.GetLevelsTotal().ToString());
        string val_19 = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  WildWeekendHandler.econ_default_award.GetLevelsComplete() + 1.ToString(), arg1:  WildWeekendHandler.econ_default_award.GetLevelsTotal().ToString());
        goto label_26;
        label_14:
        this.progressEnd = GetNextEventProgressValue();
        this.textProgressStart = LightningLevelsEventHandler.<Instance>k__BackingField;
        label_26:
        this.textProgressEnd = LightningLevelsEventHandler.<Instance>k__BackingField.GetNextLightningEventProgress(spaced:  true);
        val_23 = this.titleText;
    }
    private System.Collections.IEnumerator ShowPopup()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGEventProgressFlyInAwayPopup.<ShowPopup>d__22();
    }
    private System.Collections.IEnumerator PlayFallAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGEventProgressFlyInAwayPopup.<PlayFallAnimation>d__23();
    }
    private void Close()
    {
        this.StopAllCoroutines();
        WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGEventProgressFlyInAwayPopup()
    {
    
    }
    private float <PlayFallAnimation>b__23_0()
    {
        return (float)this.progressStart;
    }
    private void <PlayFallAnimation>b__23_1(float x)
    {
        this.progressStart = x;
    }
    private void <PlayFallAnimation>b__23_2()
    {
        if(this.progressSlider != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    private void <PlayFallAnimation>b__23_3()
    {
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGEventProgressFlyInAwayPopup::<PlayFallAnimation>b__23_4()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.1f);
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGEventProgressFlyInAwayPopup::<PlayFallAnimation>b__23_5()));
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.1f);
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.textProgress.transform, endValue:  1f, duration:  0.1f), ease:  26));
    }
    private void <PlayFallAnimation>b__23_4()
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.textProgress.transform, endValue:  1.2f, duration:  0.2f);
    }
    private void <PlayFallAnimation>b__23_5()
    {
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGameSpecificSound(id:  "Progress Update", clipIndex:  0);
    }

}
