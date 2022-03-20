using UnityEngine;
public class IslandParadiseProgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button buttonClose;
    private UnityEngine.UI.Slider progressBar;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.GameObject rewardGroup;
    private UnityEngine.UI.Image rewardIconImage;
    private UnityEngine.UI.Text rewardAmountText;
    private UnityEngine.UI.Text collectAmountText;
    private UnityEngine.UI.Image collectTextSymbol;
    private UnityEngine.UI.Text collectAmountText2;
    private UnityEngine.UI.Text rewardAmountText1;
    private UnityEngine.UI.Text rewardAmountText2;
    private UnityEngine.UI.Text rewardAmountText3;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button okButton;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.RectTransform centerTransform;
    private UnityEngine.Sprite iconCoins;
    private UnityEngine.Sprite iconGold;
    private UnityEngine.Sprite iconFood;
    private DG.Tweening.Sequence timerSequence;
    private int currentProgress;
    
    // Properties
    public UnityEngine.GameObject RewardGroup { get; }
    private IslandParadiseEventHandler handler { get; }
    
    // Methods
    public UnityEngine.GameObject get_RewardGroup()
    {
        return (UnityEngine.GameObject)this.rewardGroup;
    }
    private IslandParadiseEventHandler get_handler()
    {
        return (IslandParadiseEventHandler)IslandParadiseEventHandler._Instance;
    }
    private void Start()
    {
        UnityEngine.UI.Text val_19;
        UnityEngine.Sprite val_20;
        var val_21;
        UnityEngine.Events.UnityAction val_1 = null;
        val_19 = 1152921516281878320;
        val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void IslandParadiseProgressPopup::Close());
        this.buttonClose.m_OnClick.AddListener(call:  val_1);
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void IslandParadiseProgressPopup::OnMainButtonClicked()));
        this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void IslandParadiseProgressPopup::Close()));
        if(IslandParadiseEventHandler._Instance.HasCollectedAllRewards() == false)
        {
            goto label_9;
        }
        
        this.collectTextSymbol.gameObject.SetActive(value:  false);
        this.rewardGroup.SetActive(value:  false);
        this.okButton.gameObject.SetActive(value:  true);
        this.playButton.gameObject.SetActive(value:  false);
        goto label_41;
        label_9:
        this.okButton.gameObject.SetActive(value:  false);
        this.playButton.gameObject.SetActive(value:  true);
        int val_10 = UnityEngine.Mathf.Clamp(value:  IslandParadiseEventHandler._Instance, min:  0, max:  IslandParadiseEventHandler._Instance + 20);
        string val_11 = System.String.Format(format:  "Collect {0}", arg0:  IslandParadiseEventHandler._Instance + 20);
        UnityEngine.GameObject val_12 = this.collectTextSymbol.gameObject;
        val_12.SetActive(value:  true);
        val_19 = this.rewardAmountText;
        string val_13 = val_12.ToString();
        float val_19 = (float)val_10;
        val_19 = val_19 / ((float)IslandParadiseEventHandler._Instance + 20);
        this.SetProgressText(pointSoFar:  val_10, pointRequired:  IslandParadiseEventHandler._Instance + 20);
        if((IslandParadiseEventHandler._Instance + 16) == 1)
        {
            goto label_39;
        }
        
        if((IslandParadiseEventHandler._Instance + 16) == 3)
        {
            goto label_40;
        }
        
        if((IslandParadiseEventHandler._Instance + 16) != 4)
        {
            goto label_41;
        }
        
        val_20 = this.iconFood;
        goto label_45;
        label_39:
        val_20 = this.iconCoins;
        goto label_45;
        label_40:
        val_20 = this.iconGold;
        label_45:
        this.rewardIconImage.sprite = val_20;
        label_41:
        val_21 = null;
        val_21 = null;
        string val_14 = ToString();
        string val_15 = ToString();
        string val_16 = ToString();
        string val_18 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        this.SetTimer();
        if((IslandParadiseEventHandler._Instance.<NeedToShowProgress>k__BackingField) != false)
        {
                this.ShowProgress();
            return;
        }
        
        this.TryShowRewardFlow();
    }
    private void OnDisable()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    private void OnDestroy()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    public void ShowRewardGroup()
    {
        if(this.rewardGroup != null)
        {
                this.rewardGroup.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void HideRewardGroup()
    {
        if(this.rewardGroup != null)
        {
                this.rewardGroup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnMainButtonClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void SetTimer()
    {
        if(this.timerSequence != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
        }
        
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.timerSequence = val_1;
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void IslandParadiseProgressPopup::<SetTimer>b__33_0()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    private string GetTimerText()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = IslandParadiseEventHandler._Instance}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days;
        val_3[1] = val_2._ticks.Hours;
        val_3[2] = val_2._ticks.Minutes;
        val_3[3] = val_2._ticks.Seconds;
        return (string)System.String.Format(format:  "{0:00}:{1:00}:{2:00}:{3:00}", args:  val_3);
    }
    private void SetProgressText(int pointSoFar, int pointRequired)
    {
        string val_1 = System.String.Format(format:  "{0}/{1}", arg0:  pointSoFar, arg1:  pointRequired);
    }
    private void SetProgressBar(int pointSoFar, int pointRequired)
    {
        if(this.progressBar != null)
        {
                float val_1 = (float)pointSoFar;
            val_1 = val_1 / (float)pointRequired;
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    private void ShowProgress()
    {
        DG.Tweening.TweenCallback val_14;
        IslandParadiseProgressPopup.<>c__DisplayClass37_0 val_1 = new IslandParadiseProgressPopup.<>c__DisplayClass37_0();
        .<>4__this = this;
        val_14 = 1152921504917336064;
        if((IslandParadiseEventHandler._Instance.<NeedToShowProgress>k__BackingField) == false)
        {
                return;
        }
        
        .pointRequired = IslandParadiseEventHandler._Instance + 20;
        int val_2 = UnityEngine.Mathf.Clamp(value:  IslandParadiseEventHandler._Instance, min:  0, max:  IslandParadiseEventHandler._Instance + 20);
        string val_3 = System.String.Format(format:  "{0}/{1}", arg0:  0, arg1:  (IslandParadiseProgressPopup.<>c__DisplayClass37_0)[1152921516283865312].pointRequired);
        float val_14 = (float)(IslandParadiseProgressPopup.<>c__DisplayClass37_0)[1152921516283865312].pointRequired;
        val_14 = (float)val_2 / val_14;
        float val_4 = val_14 + val_14;
        DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.TweenCallback val_9 = null;
        val_14 = val_9;
        val_9 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void IslandParadiseProgressPopup::TryShowRewardFlow());
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Int32>(object:  val_1, method:  System.Int32 IslandParadiseProgressPopup.<>c__DisplayClass37_0::<ShowProgress>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Int32>(object:  val_1, method:  System.Void IslandParadiseProgressPopup.<>c__DisplayClass37_0::<ShowProgress>b__1(int x)), endValue:  val_2, duration:  val_4), action:  val_9));
        float val_15 = (float)(IslandParadiseProgressPopup.<>c__DisplayClass37_0)[1152921516283865312].pointRequired;
        val_15 = (float)val_2 / val_15;
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_5, t:  DG.Tweening.ShortcutExtensions46.DOValue(target:  this.progressBar, endValue:  val_15, duration:  val_4, snapping:  false));
    }
    private void TryShowRewardFlow()
    {
        object val_6;
        bool val_7;
        val_6 = this;
        val_7 = static_value_02805EA0;
        if(IslandParadiseEventHandler._Instance.HasCollectedAllRewards() != true)
        {
                if((IslandParadiseEventHandler._Instance & 1) != 0)
        {
                this.PlayRewardSequence(onComplete:  new System.Action(object:  this, method:  System.Void IslandParadiseProgressPopup::<TryShowRewardFlow>b__38_0()));
            return;
        }
        
            val_6 = WordRegion.instance;
            if(val_6 != 0)
        {
                WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  3);
        }
        
            val_7 = static_value_02805EA0;
        }
        
        IslandParadiseEventHandler._Instance.<NeedToShowProgress>k__BackingField = false;
    }
    private void PlayRewardSequence(System.Action onComplete)
    {
        .onComplete = onComplete;
        .<>4__this = this;
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.rewardGroup, parent:  this.rewardGroup.transform.parent);
        .newRewardGroup = val_4;
        val_4.transform.SetParent(p:  this.centerTransform);
        this.HideRewardGroup();
        DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector3 val_8 = this.centerTransform.position;
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.ShortcutExtensions.DOMove(target:  (IslandParadiseProgressPopup.<>c__DisplayClass39_0)[1152921516284271584].newRewardGroup.transform, endValue:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, duration:  0.7f, snapping:  false));
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, d:  1.93f);
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (IslandParadiseProgressPopup.<>c__DisplayClass39_0)[1152921516284271584].newRewardGroup.transform, endValue:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, duration:  0.5f));
        if(((IslandParadiseProgressPopup.<>c__DisplayClass39_0)[1152921516284271584].onComplete) == null)
        {
                return;
        }
        
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_6, action:  new DG.Tweening.TweenCallback(object:  new IslandParadiseProgressPopup.<>c__DisplayClass39_0(), method:  System.Void IslandParadiseProgressPopup.<>c__DisplayClass39_0::<PlayRewardSequence>b__0()));
    }
    private void ShowRewardCollection()
    {
        IslandParadiseEventHandler._Instance.ShowRewardCollection();
    }
    public IslandParadiseProgressPopup()
    {
    
    }
    private void <SetTimer>b__33_0()
    {
        string val_1 = this.GetTimerText();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void <TryShowRewardFlow>b__38_0()
    {
        this.ShowRewardCollection();
    }

}
