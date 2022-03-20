using UnityEngine;
public class RestaurantMasterPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject viewGroup;
    private UnityEngine.GameObject collectGroup;
    private UnityEngine.UI.Button buttonClose;
    private UnityEngine.UI.Text coinsViewText;
    private UnityEngine.UI.Text spinsViewText;
    private UnityEngine.UI.Text coinsCollectText;
    private UnityEngine.UI.Text spinsCollectText;
    private UnityEngine.UI.Button gotItButton;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Text timerText;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private SpinsCollectAnimationInstantiator spinsAnim;
    private DG.Tweening.Sequence timerSequence;
    
    // Methods
    private void Start()
    {
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void RestaurantMasterPopup::Close()));
        this.gotItButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void RestaurantMasterPopup::Close()));
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void RestaurantMasterPopup::OnCollectClicked()));
        decimal val_4 = RestaurantMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showNextLevel:  true);
        decimal val_5 = new System.Decimal(value:  232);
        string val_6 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_5.lo, mid = val_5.lo}, useRichText:  false, withSpaces:  false);
        decimal val_7 = RestaurantMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showNextLevel:  false);
        decimal val_8 = new System.Decimal(value:  232);
        string val_9 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo}, useRichText:  false, withSpaces:  false);
        string val_11 = RestaurantMasterEventHandler.<Instance>k__BackingField.GetSpinReward(showNextLevel:  true).ToString();
        string val_13 = RestaurantMasterEventHandler.<Instance>k__BackingField.GetSpinReward(showNextLevel:  false).ToString();
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
    public void SetupView()
    {
        this.viewGroup.SetActive(value:  true);
        this.collectGroup.SetActive(value:  false);
        this.SetTimer();
    }
    public void SetupCollect()
    {
        this.viewGroup.SetActive(value:  false);
        this.collectGroup.SetActive(value:  true);
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGeneralSound(type:  0, oneshot:  true, pitch:  1f, vol:  1f);
    }
    private void SetTimer()
    {
        if(this.timerSequence != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
        }
        
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.timerSequence = val_1;
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void RestaurantMasterPopup::<SetTimer>b__18_0()));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    private string GetTimerText()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = RestaurantMasterEventHandler.<Instance>k__BackingField + 16 + 48}, d2:  new System.DateTime() {dateData = val_1.dateData});
        return (string)System.String.Format(format:  "Time Left: {0}:{1:00}:{2:00}", arg0:  val_2._ticks.Hours, arg1:  val_2._ticks.Minutes, arg2:  val_2._ticks.Seconds);
    }
    private void OnCollectClicked()
    {
        .<>4__this = this;
        decimal val_2 = RestaurantMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showNextLevel:  false);
        .coinAmount = val_2;
        mem[1152921516682627216] = val_2.lo;
        mem[1152921516682627220] = val_2.mid;
        int val_3 = RestaurantMasterEventHandler.<Instance>k__BackingField.GetSpinReward(showNextLevel:  false);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = (RestaurantMasterPopup.<>c__DisplayClass20_0)[1152921516682627184].coinAmount, hi = (RestaurantMasterPopup.<>c__DisplayClass20_0)[1152921516682627184].coinAmount}, source:  "Restaurant Master Event", subSource:  0, externalParams:  0, doTrack:  true);
        System.Delegate val_6 = System.Delegate.Combine(a:  41975808, b:  new System.Action(object:  new RestaurantMasterPopup.<>c__DisplayClass20_0(), method:  System.Void RestaurantMasterPopup.<>c__DisplayClass20_0::<OnCollectClicked>b__0()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        mem2[0] = val_6;
        System.Delegate val_8 = System.Delegate.Combine(a:  this.coinsAnim.OnCompleteCallback, b:  new System.Action(object:  this, method:  System.Void RestaurantMasterPopup::Close()));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        this.coinsAnim.OnCompleteCallback = val_8;
        return;
        label_14:
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public RestaurantMasterPopup()
    {
    
    }
    private void <SetTimer>b__18_0()
    {
        string val_1 = this.GetTimerText();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
